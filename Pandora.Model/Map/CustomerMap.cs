using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class CustomerMap : CoreMap<Customer>
    {
        public CustomerMap()
        {
            ToTable("dbo.Customers");
            Property(x => x.BillAddressID).IsOptional();
            Property(x => x.ShipAddressID).IsOptional();
            Property(x => x.FirstName).HasMaxLength(20).IsRequired();
            Property(x => x.LastName).HasMaxLength(20).IsRequired();
            Property(x => x.Username).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(20).IsRequired();
        }
    }
}
