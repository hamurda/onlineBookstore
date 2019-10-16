using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class CityMap: CoreMap<City>
    {
        public CityMap()
        {
            ToTable("dbo.Cities");
            Property(x => x.CityName ).HasMaxLength(50).IsOptional();
            Property(x => x.CountryID).IsOptional();
        }
    }
}
