using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Country:CoreEntity
    {
        public string CountryName { get; set; }


        public virtual List<City> Cities { get; set; }
    }
}
