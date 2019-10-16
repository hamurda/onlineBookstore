using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Dealer : CoreEntity
    {
        public Dealer()
        {
            Employees = new List<Employee>();
            StockDetails = new List<StockDetail>();
        }

        public string Name { get; set; }
        public string MainPhone { get; set; }

        public Guid? AddressID { get; set; }
        public virtual Address Address { get; set; }

        public virtual List<Employee> Employees { get; set; }
        public virtual List<StockDetail> StockDetails { get; set; }
    }
}
