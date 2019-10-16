using Pandora.Core.Map;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Map
{
    public class CountryMap : CoreMap<Country>
    {
        public CountryMap()
        {
            ToTable("dbo.Countries");
            Property(x => x.CountryName).HasMaxLength(50).IsOptional();
        }
    }
}
