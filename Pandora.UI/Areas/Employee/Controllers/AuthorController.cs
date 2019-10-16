using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class AuthorController : Controller
    {
        AuthorService aus = new AuthorService();

        public ActionResult Index()
        {
            return View(aus.GetAll());
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Author item)
        {
            if (ModelState.IsValid)
            {
                bool exist = aus.CheckAuthor(item);

                if (!exist)
                {
                    bool cat = aus.Add(item);
                    if (cat)
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
                    ViewBag.Message = "This author is already in the list.";
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
            return View(aus.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Author item)
        {
            Author author = aus.GetByID(item.ID);

            if (ModelState.IsValid)
            {

                bool exist = aus.CheckAuthor(item);

                if (!exist)
                {
                    author.FirstName = item.FirstName;
                    author.LastName = item.LastName;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "This author is already in the list.";
                }
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return View(author);
        }

        public ActionResult Delete(Guid id)
        {
            aus.Remove(id);
            return RedirectToAction("Index");
        }
    }
}