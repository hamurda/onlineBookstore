using Pandora.Model.Entities;
using Pandora.Service.Option;
using Pandora.UI.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Controllers
{
    public class AccountController : Controller
    {
        CustomerService cs = new CustomerService();

        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();

        AddressService ads = new AddressService();
        CityService cits = new CityService();
        CountryService cnts = new CountryService();

        public ActionResult MyAccount()
        {
            Customer person = (Customer)Session["customer"];

            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName");
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName");

            if (person.ShippingAddress != null)
            {
                Address adrS = ads.GetByID(person.ShipAddressID);
                City city = cits.GetByID(adrS.CityID);
                Country c = cnts.GetByID(city.CountryID);
                ViewBag.ship = $"{adrS.Street} Postal Code:{adrS.PostalCode}\n{city.CityName}/{c.CountryName}";
            }

            if (person.BillingAddress != null)
            {
                //SORULACAK: adrB = ads.GetByID(person.BillAddressID);
                //ViewBag.bill = $"{adrB.Street} Postal Code:{adrB.PostalCode}\n{adrB.City.CityName}/{adrB.City.Country.CountryName}";

                Address adrB = ads.GetByID(person.BillAddressID);
                City city = cits.GetByID(adrB.CityID);
                Country c = cnts.GetByID(city.CountryID);
                ViewBag.bill = $"{adrB.Street} Postal Code:{adrB.PostalCode}\n{city.CityName}/{c.CountryName}";
            }

            List<Order> orderList = new List<Order>();
            if (person.Orders != null)
            {
                orderList = os.GetDefault(m => m.CustomerID == person.ID && m.OrderStatus == Model.Entities.Enum.OrderStatus.Processing);
            }

            Tuple<Customer, List<Order>> TupList = new Tuple<Customer, List<Order>>(person, orderList);

            return View(TupList);
        }

        [HttpPost]
        public ActionResult Update(string firstName, string lastName, string email, string password, string newPass, string newPassRepeat)
        {
            Customer cus = (Customer)Session["customer"];

            if (newPass != "")
            {
                if (password == cus.Password)
                {
                    if (newPass == newPassRepeat)
                    {
                        cus.Password = newPass;
                    }
                    else
                    {
                        ViewBag.Pass = "Two passwords don't match.";
                    }
                }
                else
                {
                    ViewBag.Pass = "Your current password is not correct.";
                }

            }

            if (firstName != null)
            {
                cus.FirstName = firstName;
            }

            if (lastName != null)
            {
                cus.LastName = lastName;
            }

            if (email != null)
            {
                cus.EmailAddress = email;
            }

            cs.Update(cus);

            return RedirectToAction("MyAccount", "Account");
        }

        public ActionResult OrderHistory()
        {
            Customer person = (Customer)Session["customer"];
            List<Order> orderList = new List<Order>();
            List<OrderDetail> detailList = new List<OrderDetail>();

            if (person.Orders != null)
            {
                orderList = os.GetDefault(m => m.CustomerID == person.ID);
                detailList = ods.GetDefault(m => m.Order.CustomerID == person.ID);
            }

            Tuple<List<Order>, List<OrderDetail>> TupList = new Tuple<List<Order>, List<OrderDetail>>(orderList, detailList);
            return View(TupList);
        }
        
        public ActionResult OrderInfo(Guid id)
        {
            List<OrderDetail> orderDetails = ods.GetDefault(m => m.OrderID == id);

            return View(orderDetails);
        }

        [HttpPost]
        public ActionResult EditAddress(string street, int postCode, Guid? cityID, Guid? countryID, int form)
        {
            Customer person = (Customer)Session["customer"];

            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName", cityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName", countryID);

            //Address
            Address adr = new Address();

            if (form == 1)
            {
                if (person.ShippingAddress != null)
                {
                    adr = ads.GetByID(person.ShipAddressID);
                }
                else
                {
                    ads.Add(adr);
                    person.ShipAddressID = adr.ID;
                }
            }
            else
            {
                if (person.BillingAddress != null)
                {
                    adr = ads.GetByID(person.BillAddressID);
                }
                else
                {
                    ads.Add(adr);
                    person.BillAddressID = adr.ID;
                }
            }

            adr.Street = street;
            adr.PostalCode = postCode;

            //Country
            Country country = cnts.GetByID(countryID);

            //City
            City city = cits.GetByID(cityID);
            if (city.Country == null)
            {
                city.CountryID = countryID;
                cits.Update(city);
            }

            adr.CityID = city.ID;
            bool success = ads.Update(adr);

            if (success)
            {
                cs.Update(person);
            }
            
            return RedirectToAction("MyAccount", "Account");
        }
    }
}