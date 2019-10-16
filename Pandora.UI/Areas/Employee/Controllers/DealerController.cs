using Pandora.Model.Entities;
using Pandora.Service.Option;
using Pandora.UI.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class DealerController : Controller
    {
        DealerService ds = new DealerService();
        CityService cits = new CityService();
        CountryService cnts = new CountryService();
        AddressService adrs = new AddressService();
        BookService bs = new BookService();

        public ActionResult Index()
        {
            return View(ds.GetActive());
        }

        public ActionResult Insert()
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName");
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(DealerAddressVM item)
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName",item.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName",item.CountryID);
         
            if (ModelState.IsValid)
            {
                Dealer d = new Dealer();
                d.Name = item.Name;
                d.MainPhone = item.MainPhone;

                Address a = new Address();
                a.Street = item.Street;
                a.PostalCode = item.PostalCode;
                a.CityID = item.CityID;

                City c = cits.GetByID(item.CityID);
                if (c.Country == null)
                {
                    c.CountryID = item.CountryID;
                    cits.Update(c);
                }

                adrs.Add(a);
                d.AddressID = a.ID;

                bool sonuc = ds.Add(d);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                ViewBag.Message = "Invalid format.";
            }

            return View();
        }

        public ActionResult Update(Guid id)
        {
            Dealer d = ds.GetByID(id);
            DealerAddressVM davm = new DealerAddressVM();

            if (d.AddressID != null)
            {
                Address adr = adrs.GetByID(d.AddressID);
                davm.AddressID = adr.ID;
                davm.Street = adr.Street;
                davm.PostalCode = adr.PostalCode;
                davm.CityID = adr.CityID;
                davm.CityName = adr.City.CityName;

                if (adr.City != null && adr.City.Country != null)
                {
                    davm.CountryID = adr.City.CountryID;
                    davm.CountryName = adr.City.Country.CountryName;
                }
            }

            davm.DealerID = id;
            davm.Name = d.Name;
            davm.MainPhone = d.MainPhone;
            davm.AddressID = d.AddressID;

            ViewBag.CityID = new SelectList(cits.GetAll(), "ID", "CityName", davm.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetAll(), "ID", "CountryName", davm.CountryID);

            return View(davm);
        }

        [HttpPost]
        public ActionResult Update(DealerAddressVM item)
        {
            Dealer toUpdate = ds.GetByID(item.DealerID);
            toUpdate.Name = item.Name;
            toUpdate.MainPhone = item.MainPhone;
            toUpdate.AddressID = item.AddressID;

            Address a = adrs.GetByID(item.AddressID);
            a.Street = item.Street;
            a.PostalCode = item.PostalCode;
            a.CityID = item.CityID;

            City c = cits.GetByID(item.CityID);
            if (c.Country == null)
            {
                c.CountryID = item.CountryID;
                cits.Update(c);
            }

            adrs.Update(a);
            ds.Update(toUpdate);

            return RedirectToAction("Index");
        }

        public ActionResult InsertStockInfo(Guid id)
        {
            ViewBag.BookID = new SelectList(bs.GetActive(), "ID", "Title");




            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            return View(ds.Remove(id));
        }
    }
}