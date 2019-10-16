using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class ShipperController : Controller
    {
        ShipperService ss = new ShipperService();

        public ActionResult Index()
        {
            return View(ss.GetActive());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Shipper item)
        {
            if (ModelState.IsValid)
            {
                Shipper s = new Shipper();
                s.CompanyName = item.CompanyName;
                s.ContactName = item.ContactName;
                s.Phone = item.Phone;

                ss.Add(s);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid Format";
            }

            return View();
        }

        public ActionResult Update(Guid id)
        {            
            return View(ss.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Shipper item)
        {
            if (ModelState.IsValid)
            {
                Shipper toUpdate = ss.GetByID(item.ID);
                toUpdate.CompanyName = item.CompanyName;
                toUpdate.ContactName = item.ContactName;
                toUpdate.Phone = item.Phone;

                ss.Update(toUpdate);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid Format";
            }

            return View(item);
        }

        public ActionResult Delete(Guid id)
        {
            ss.Remove(id);
            return RedirectToAction("Index");
        }
    }
}