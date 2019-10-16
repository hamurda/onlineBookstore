using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class CategoryController : Controller
    {
        CategoryService cs = new CategoryService();

        public ActionResult Index()
        {
            return View(cs.GetAll());
        }

        public ActionResult Insert()
        {
            ViewBag.ID = new SelectList(cs.GetAll(), "ID", "Name");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(Category item)
        {
            ViewBag.ID = new SelectList(cs.GetAll(), "ID", "Name", item.SubCategoryOf);

            if (ModelState.IsValid)
            {
                bool exist = cs.CheckCategoryInsert(item);

                if (!exist)
                {
                    bool cat = cs.Add(item);
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
                    ViewBag.Message = "This category name already exists. ";
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
            Category cat = cs.GetByID(id);
            ViewBag.ID = new SelectList(cs.GetAll(), "ID", "Name", cat.SubCategoryOf);
            return View(cs.GetByID(id));
        }

        [HttpPost]
        public ActionResult Update(Category item)
        {
            ViewBag.ID = new SelectList(cs.GetAll(), "ID", "Name", item.SubCategoryOf);
            Category category = cs.GetByID(item.ID);

            bool exist = cs.CheckCategoryUpdate(item);
            if (!exist)
            {                
                category.Name = item.Name;
                category.Description = item.Description;
                category.SubCategoryOf = item.SubCategoryOf;
                category.Status = item.Status;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "This category already exists. ";
                return View(category);
            }
                      
        }

        public ActionResult Delete(Guid id)
        {
            cs.Remove(id);
            return RedirectToAction("Index");
        }

    }
}