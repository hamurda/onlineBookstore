using Pandora.Service.Option;
using Pandora.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService es = new EmployeeService();


        public ActionResult Index()
        {
            return View(es.GetActive());
        }

        public ActionResult Insert()
        {
            ViewBag.ReportsTo = new SelectList(es.GetActive(),"ID","EmployeeLabel");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(Pandora.Model.Entities.Employee person )
        {
            ViewBag.ReportsTo = new SelectList(es.GetActive(), "ID", "EmployeeLabel",person.ReportsTo);

            if (ModelState.IsValid)
            {
                bool sonuc = es.Add(person);
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
            ViewBag.ReportsTo = new SelectList(es.GetActive(), "ID", "EmployeeLabel", es.GetByID(id).ReportsTo);

            return View(es.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Pandora.Model.Entities.Employee person)
        {
            ViewBag.ReportsTo = new SelectList(es.GetActive(), "ID", "EmployeeLabel", person.ReportsTo);

            Pandora.Model.Entities.Employee toUpdate = es.GetByID(person.ID);
            toUpdate.FirstName = person.FirstName;
            toUpdate.LastName = person.LastName;
            toUpdate.Title = person.Title;
            toUpdate.Notes = person.Notes;
            toUpdate.IsAdmin = person.IsAdmin;
            toUpdate.Password = person.Password;

            if (person.ReportsTo != null || person.EmployeeReportsTo!=null)
            {
                toUpdate.ReportsTo = person.ReportsTo;
            }

            es.Update(toUpdate);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(Guid id)
        {
            es.Remove(id);
            return RedirectToAction("Index");
        }
    }
}