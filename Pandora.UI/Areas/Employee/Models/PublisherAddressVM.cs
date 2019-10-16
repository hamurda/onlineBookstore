using Pandora.Model.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandora.UI.Areas.Employee.Models
{
    public class PublisherAddressVM
    {
        //Publisher properties
        public Guid? PublisherID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public ContactTitle ContactTitle { get; set; }

        public Guid? AddressID { get; set; }
        public string Phone { get; set; }
        public string EmailAddress { get; set; }
        public string HomePage { get; set; }


        //Address Properties
        public string Street { get; set; }
        public int PostalCode { get; set; }

        //City
        public Guid? CityID { get; set; }

        //Country
        public Guid? CountryID { get; set; }


    }
}