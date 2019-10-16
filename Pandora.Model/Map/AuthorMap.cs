using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class AuthorMap : CoreMap<Author>
    {
        public AuthorMap()
        {
            ToTable("dbo.Authors");
            Property(x => x.FirstName).HasMaxLength(100).IsRequired();
            Property(x => x.LastName).HasMaxLength(100).IsRequired();
        }
    }
}
