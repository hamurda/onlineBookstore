using Pandora.Model.Entities;
using Pandora.UI.Areas.Employee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class AddressController : Controller
    {
        Service.Option.AddressService ads = new Service.Option.AddressService();
        Service.Option.CityService cits = new Service.Option.CityService();
        Service.Option.CountryService cnts = new Service.Option.CountryService();

        public ActionResult Index()
        {
            return View(ads.GetAll());
        }

        public ActionResult Insert()
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName");
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(AddressVM item)
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName", item.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName", item.CountryID);

            //Address
            Address adr = new Address();
            adr.Street = item.Street;
            adr.PostalCode = item.PostalCode;

            //Country
            Country cnt = new Country();
            if (item.CountryID == null)
            {               
                cnt.CountryName = item.CountryName;
                bool addCnt = cnts.Add(cnt);
                item.CountryID = cnt.ID;
            }

            cnt = cnts.GetByID(item.CountryID);

            //City
            City city = new City();
            if (item.CityID == null)
            {               
                city.CityName = item.CityName;
                city.CountryID = cnt.ID;
                bool addCity = cits.Add(city);
                item.CityID = city.ID;
            }

            city = cits.GetByID(item.CityID);

            adr.CityID = city.ID;

            bool success = ads.Add(adr);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Update(Guid id)
        {
            Address adr = ads.GetByID(id);

            AddressVM avm = new AddressVM();
            avm.AddressID = id;
            avm.Street = adr.Street;
            avm.PostalCode = adr.PostalCode;
            avm.CityID = adr.CityID;
            if (adr.City!=null || adr.City.Country!=null)
            {
                avm.CountryID = adr.City.CountryID;
            }
            
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName",avm.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName", avm.CountryID);

            return View(avm);
        }

        [HttpPost]
        public ActionResult Update(AddressVM item)
        {
            ViewBag.CityID = new SelectList(cits.GetActive(), "ID", "CityName", item.CityID);
            ViewBag.CountryID = new SelectList(cnts.GetActive(), "ID", "CountryName", item.CountryID);

            //Address
            Address adr = ads.GetByID(item.AddressID);
            adr.Street = item.Street;
            adr.PostalCode = item.PostalCode;

            //Country
            Country cnt = new Country();            
            if (item.CountryID == null && item.CountryName!=null)
            {
                cnt.CountryName = item.CountryName;
                bool addCnt = cnts.Add(cnt);
                item.CountryID = cnt.ID;
            }
            cnt = cnts.GetByID(item.CountryID);

            //City
            City city = new City();
            if (item.CityID == null)
            {
                city.CityName = item.CityName;
                city.CountryID = cnt.ID;
                bool addCity = cits.Add(city);
                item.CityID = city.ID;
            }

            city = cits.GetByID(item.CityID);
            adr.CityID = city.ID;

            bool success = ads.Update(adr);

            if (success)
            {
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(Guid id)
        {
            ads.Remove(ads.GetByID(id));
            return RedirectToAction("Index");
        }
    }
}