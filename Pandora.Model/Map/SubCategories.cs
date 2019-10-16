using Pandora.Core.Entity;
using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");
            Property(x => x.Name).HasColumnName("SubCategoryName").HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(200).IsOptional();
        }
    }
}
