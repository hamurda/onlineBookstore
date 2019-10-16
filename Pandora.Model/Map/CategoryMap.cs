using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class CategoryMap : CoreMap<Category>
    {
        public CategoryMap()
        {
            ToTable("dbo.Categories");
            Property(x => x.Name).HasMaxLength(100).IsRequired();
            Property(x => x.Description).HasMaxLength(200).IsOptional();         
            Property(x => x.SubCategoryOf).IsOptional();         
        }
    }
}
