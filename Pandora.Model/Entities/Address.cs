using Pandora.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Address : CoreEntity
    {
        public string Street { get; set; }
        public Guid? CityID { get; set; }
        public int PostalCode { get; set; }        
        public virtual City City { get; set; }

        public virtual List<Publisher> Publishers { get; set; }
        public virtual List<Customer> BillCustomers { get; set; }
        public virtual List<Customer> ShipCustomers { get; set; }
        public virtual List<Dealer> Dealers { get; set; }
        public virtual List<Employee> Employees { get; set; }
        public virtual List<Order> BillOrders { get; set; }
        public virtual List<Order> ShipOrders { get; set; }

    }
}
