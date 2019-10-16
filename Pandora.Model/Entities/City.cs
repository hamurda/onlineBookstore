using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class City : CoreEntity
    {
        public string CityName { get; set; }
        public Guid? CountryID { get; set; }

        public virtual List<Address> Addresses { get; set; }
        public virtual Country Country { get; set; }
    }
}
