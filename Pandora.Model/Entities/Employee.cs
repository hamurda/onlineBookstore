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
    public class Employee : CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ContactTitle Title { get; set; }
        public TitleCourtesy TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public string PhotoPath { get; set; }
        public string Notes { get; set; }
        public bool IsAdmin { get; set; }

        public string Username
        {
            get
            {
                return this.FirstName.Substring(0, 2).ToLower() + LastName.ToLower();
            }
        }


        public string EmailAddress
        {
            get
            {
                return $"{this.Username}@pandora.com";
            }
        }

        public string Password { get; set; }

        public Guid? ReportsTo { get; set; }
        [ForeignKey("ReportsTo")]
        public virtual Employee EmployeeReportsTo { get; set; }

        public string EmployeeLabel
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }

        public Guid? AddressID { get; set; }
        public virtual Address Address { get; set; }

        public Guid? DealerID { get; set; }
        public virtual Dealer Dealer { get; set; }
    }
}
