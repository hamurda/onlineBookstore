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
    public class PublisherMap : CoreMap<Publisher>
    {
        public PublisherMap()
        {
            ToTable("dbo.Publishers");
            Property(x => x.CompanyName).HasMaxLength(200).IsRequired();
            Property(x => x.ContactName).HasMaxLength(100).IsOptional();
            Property(x => x.Phone).HasMaxLength(15).IsOptional();
            Property(x => x.EmailAddress).HasMaxLength(50).IsOptional();
            Property(x => x.HomePage).HasMaxLength(75).IsOptional();

        }
    }
}
