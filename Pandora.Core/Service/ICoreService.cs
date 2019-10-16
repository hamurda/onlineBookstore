using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T item);
        bool Add(List<T> items);
        bool Remove(T item);
        bool Remove(Guid? id);
        bool RemoveAll(Expression<Func<T, bool>> exp);
        bool Update(T item);     
        bool Any(Expression<Func<T,bool>> exp);

        int Save();


        T GetByID(Guid? id);
        T GetByDefault(Expression<Func<T,bool>> exp);

        List<T> GetActive();
        List<T> GetDefault(Expression<Func<T,bool>> exp);
        List<T> GetAll();

    }
}
