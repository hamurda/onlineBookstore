using Pandora.Model.Entities;
using Pandora.UI.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class PublisherController : Controller
    {
        Service.Option.PublisherService ps = new Service.Option.PublisherService();
        Service.Option.AddressService ads = new Service.Option.AddressService();
        Service.Option.CityService cits = new Service.Option.CityService();
        Service.Option.CountryService cnts = new Service.Option.CountryService();

        public ActionResult Index()
        {
            return View(ps.GetAll());
        }

        public ActionResult Insert()
        {
            ViewBag.CityID = new SelectList(cits.GetAll(), "ID", "CityName");
            ViewBag.CountryID = new SelectList(cnts.GetAll(), "ID", "CountryName");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(PublisherAddressVM item)
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName", item.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName", item.CountryID);

            if (ModelState.IsValid)
            {
                //Address
                Address adr = new Address();
                adr.Street = item.Street;
                adr.PostalCode = item.PostalCode;

                //City
                if (item.CityID != null)
                {
                    adr.CityID = item.CityID;
                }

                //Country
                if (adr.City != null && item.CountryID != null)
                {
                    adr.City.CountryID = item.CountryID;
                }

                bool success = ads.Add(adr);

                Publisher publisher = new Publisher();
                publisher.CompanyName = item.CompanyName;
                publisher.ContactName = item.ContactName;
                publisher.ContactTitle = item.ContactTitle;
                publisher.EmailAddress = item.EmailAddress;
                publisher.Phone = item.Phone;
                publisher.AddressID = adr.ID;

                bool pub = ps.Add(publisher);
                if (pub)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Operation Unsuccessfull";
                }
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return View(item);
        }

        public ActionResult Update(Guid id)
        {
            Publisher publisher = ps.GetByID(id);
            PublisherAddressVM pavm = new PublisherAddressVM();

            if (publisher.AddressID!=null)
            {
                Address adr = ads.GetByID(publisher.AddressID);
                pavm.AddressID = adr.ID;
                pavm.Street = adr.Street;
                pavm.PostalCode = adr.PostalCode;
                pavm.CityID = adr.CityID;

                if (adr.City != null && adr.City.Country != null)
                {
                    pavm.CountryID = adr.City.CountryID;
                }
            }
            
            pavm.PublisherID = id;
            pavm.CompanyName = publisher.CompanyName;
            pavm.ContactTitle = publisher.ContactTitle;
            pavm.EmailAddress = publisher.EmailAddress;
            pavm.Phone = publisher.Phone;
            pavm.ContactName = publisher.ContactName;

            ViewBag.CityID = new SelectList(cits.GetAll(), "ID", "CityName", pavm.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetAll(), "ID", "CountryName", pavm.CountryID);

            return View(pavm);
        }

        [HttpPost]
        public ActionResult Update(PublisherAddressVM item)
        {
            ViewBag.CityID = new SelectList(cits.GetAll(), "ID", "CityName", item.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetAll(), "ID", "CountryName", item.CountryID);

            if (ModelState.IsValid)
            {
                Publisher publisher = ps.GetByID(item.PublisherID);
                Address adr = new Address();
                if (publisher.AddressID != null)
                {
                    adr = ads.GetByID(publisher.AddressID);
                }
                else
                {
                    bool success = ads.Add(adr);
                }

                adr.Street = item.Street;
                adr.PostalCode = item.PostalCode;

                if (item.CityID != null && item.CountryID!=null )
                {
                    City city = cits.GetByID(item.CityID);
                    if (city.Country==null)
                    {
                        Country cnt = cnts.GetByID(item.CountryID);
                        city.CountryID = cnt.ID;
                    }

                    adr.CityID = city.ID;
                }

                ads.Update(adr);

                publisher.AddressID = adr.ID;

                publisher.CompanyName = item.CompanyName;
                publisher.ContactName = item.ContactName;
                publisher.ContactTitle = item.ContactTitle;
                publisher.EmailAddress = item.EmailAddress;
                publisher.Phone = item.Phone;

                ps.Update(publisher);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return View(item);
        }

        public ActionResult Delete(Guid id)
        {
            ps.Remove(id);
            return RedirectToAction("Index");
        }
    }
}