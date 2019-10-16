using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class StockDetailMap : CoreMap<StockDetail>
    {
        public StockDetailMap()
        {
            ToTable("dbo.StockDetails");
            Property(x => x.UnitsInStock).IsOptional();
        }
    }
}
