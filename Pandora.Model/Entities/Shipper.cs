using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Shipper : CoreEntity
    {
        public Shipper()
        {
            this.Orders = new List<Order>();
        }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string Phone { get; set; }

        public virtual List<Order> Orders { get; set; }

    }
}
