using Pandora.Core.Entity;
using Pandora.Core.Entity.Enum;
using Pandora.Core.Service;
using Pandora.Model.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Pandora.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private static ProjectContext _context;
        public ProjectContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new ProjectContext();
                }
                return _context;
            }
            set { _context = value; }
        }

        public bool Add(T item)
        {
            Context.Set<T>().Add(item);
            return Save() > 0;
        }

        public bool Add(List<T> items)
        {
            Context.Set<T>().AddRange(items);
            return Save() > 0;
        }

        public bool Any(System.Linq.Expressions.Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Any(exp);
        }

        public List<T> GetActive()
        {
            return Context.Set<T>().Where(x => x.Status != Status.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByDefault(System.Linq.Expressions.Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).FirstOrDefault();
        }

        public T GetByID(Guid? id)
        {
            return Context.Set<T>().Find(id);
        }

        public List<T> GetDefault(System.Linq.Expressions.Expression<Func<T, bool>> exp)
        {
            return Context.Set<T>().Where(exp).ToList();
        }

        public bool Remove(T item)
        {
            item.Status = Status.Deleted;
            return Update(item);
        }

        public bool Remove(Guid? id)
        {
            T removed = Context.Set<T>().Find(id);
            removed.Status = Status.Deleted;
            return Update(removed);
        }

        public bool RemoveAll(System.Linq.Expressions.Expression<Func<T, bool>> exp)
        {
            List<T> removed = GetDefault(exp);
            int recordCount = removed.Count;
            int successCount = 0;

            using(TransactionScope ts = new TransactionScope())
            {
                try
                {
                    foreach (var item in removed)
                    {
                        item.Status = Status.Deleted;
                        bool i = Update(item);
                        if (i)
                        {
                            successCount++;
                        }
                    }

                    if (recordCount==successCount)
                    {

                        ts.Complete();
                        return true;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    ts.Dispose();
                    return false;
                }
            }
        }

        public int Save()
        {
            return Context.SaveChanges();
        }

        public bool Update(T item)
        {
            T updated = GetByID(item.ID);
            DbEntityEntry entry = Context.Entry(updated);
            entry.CurrentValues.SetValues(item);
            return Save() > 0;
        }

        public void DetachEntity(T item)
        {
            Context.Entry<T>(item).State = System.Data.Entity.EntityState.Detached;
        }
    }
}
