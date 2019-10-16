using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class BookMap : CoreMap<Book>
    {
        public BookMap()
        {
            ToTable("dbo.Books");
            Property(x=> x.Title).HasColumnName("BookName").IsRequired().HasMaxLength(100);
            Property(x => x.AuthorID).HasColumnName("AuthorID").IsOptional();
            Property(x => x.TranslatorID).IsOptional();
            Property(x => x.CategoryID).HasColumnName("CategoryID").IsOptional();
           // Property(x => x.SubCategoryID).HasColumnName("SubCategoryID").IsOptional();
            Property(x => x.UnitPrice).HasColumnName("UnitPrice").HasColumnType("money").IsOptional();
            Property(x => x.MinUnitPrice).HasColumnType("money").IsOptional();
            Property(x => x.Language).IsOptional();
            Property(x => x.PublisherID).IsOptional();
            Property(x => x.HowManySold).IsOptional();
        }
    }
}
