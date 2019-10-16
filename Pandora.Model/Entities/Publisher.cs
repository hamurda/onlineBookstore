using Pandora.Core.Entity;
using Pandora.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pandora.Model.Entities
{
    public class Publisher : CoreEntity
    {

        public Publisher()
        {
            ContactTitle = ContactTitle.OrderAdministrator;
        }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public ContactTitle ContactTitle { get; set; }

        public Guid? AddressID { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string HomePage { get; set; }

        public virtual List<Book> Books { get; set; }
        public virtual Address Address { get; set; }
    }
}
