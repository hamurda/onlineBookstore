using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pandora.UI.Areas.Employee.Models
{
    public class DealerAddressVM
    {
        public Guid? DealerID { get; set; }
        public string Name { get; set; }
        public string MainPhone { get; set; }

        //Address
        public Guid? AddressID { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }

        //City
        public Guid? CityID { get; set; }
        public string CityName { get; set; }

        //Country
        public Guid? CountryID { get; set; }
        public string CountryName { get; set; }
    }
}