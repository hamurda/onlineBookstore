using Pandora.Model.Entities;
using Pandora.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Service.Option
{
    public class CategoryService : BaseService<Category>
    {
        public bool CheckCategoryInsert(Category item)
        {
            return Any(m => m.Name == item.Name);
        }

        public bool CheckCategoryUpdate(Category item)
        {
            return Any(m => m.Name == item.Name && m.SubCategoryOf==item.SubCategoryOf && m.Description==item.Description);
        }

        public List<Category> FindSubCategories(Guid id)
        {
            return GetDefault(m => m.SubCategoryOf == id);
        }

    }
}
