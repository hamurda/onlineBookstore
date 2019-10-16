using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class ShipperMap : CoreMap<Shipper>
    {
        public ShipperMap()
        {
            ToTable("dbo.Shippers");
            Property(x => x.CompanyName).HasMaxLength(50).IsRequired();
            Property(x => x.ContactName).HasMaxLength(50).IsOptional();
            Property(x => x.Phone).HasMaxLength(15).IsOptional();
        }
    }
}
