using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class AddressMap : CoreMap<Address>
    {
        public AddressMap()
        {
            ToTable("dbo.Addresses");
            Property(x => x.Street).HasMaxLength(50).IsOptional();
            Property(x => x.CityID).IsOptional();
            Property(x => x.PostalCode).IsOptional();
        }
    }
}
