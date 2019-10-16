using Pandora.Core.Entity;
using Pandora.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Customer : CoreEntity
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Gender Gender { get; set; }
        public Guid? BillAddressID { get; set; }
        public Guid? ShipAddressID { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }       

        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }

        public virtual List<Order> Orders { get; set; }
        public virtual List<Search> Searches { get; set; }
    }
}
