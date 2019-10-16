using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class DealerMap : CoreMap<Dealer>
    {
        public DealerMap()
        {
            ToTable("dbo.Dealers");
            Property(x => x.AddressID).IsOptional();
            Property(x => x.Name).HasMaxLength(50).IsOptional();
            Property(x => x.MainPhone).HasMaxLength(20).IsOptional();
        }
    }
}
