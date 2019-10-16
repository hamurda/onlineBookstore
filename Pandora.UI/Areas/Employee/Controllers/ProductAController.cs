using Pandora.Model.Entities;
using Pandora.Model.Entities.Enum;
using Pandora.Service.Option;
using Pandora.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class ProductAController : Controller
    {
        BookService bs = new BookService();
        CategoryService cs = new CategoryService();
        AuthorService aus = new AuthorService();
        PublisherService ps = new PublisherService();

        public ActionResult Index()
        {
            return View(bs.GetAll());
        }

        public ActionResult Insert()
        {   
            ViewBag.CategoryID = new SelectList(cs.GetAll(), "ID", "Name");
            //TODO: Sadece Kategori seçtiriyorum bu kategorinin alt kategorisi varsa ayrıca sormak gerekebilir. Ya da alt kategorisi varsa viewbag ile mesaj söylemek gerekebilir. O zaman alt kategorisi olan bir ana kategori seçemiyor olur.
            ViewBag.AuthorID = new SelectList(aus.GetAll(), "ID", "AuthorLabel");
            ViewBag.PublisherID = new SelectList(ps.GetAll(), "ID", "CompanyName");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(Book item, HttpPostedFileBase pic)
        {
            ViewBag.CategoryID = new SelectList(cs.GetAll(), "ID", "Name", item.CategoryID);
            ViewBag.AuthorID = new SelectList(aus.GetAll(), "ID", "AuthorLabel", item.AuthorID);
            ViewBag.PublisherID = new SelectList(ps.GetAll(), "ID", "CompanyName", item.PublisherID);

            if (ModelState.IsValid)
            {
                bool exist = bs.CheckBook(item,pic);
                if (!exist)
                {
                    bool isPicLoaded;
                    string fileResult = FxFunction.ImageUpload(pic, FolderPath.product, out isPicLoaded);

                    if (isPicLoaded)
                    {
                        item.ImagePath = fileResult;
                    }

                    bool newBook = bs.Add(item);
                    if (newBook)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Unsuccessful";
                    }
                }
                else
                {
                    ViewBag.Message = "This book exists in the system. Please check title, auhtor, publisher, release date, translator and language.";
                }
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            //TODO: popup için ama sanırım modaldan data işlemek için ajax gerekiyor. https://www.youtube.com/watch?v=HGUgZqJUBkI
            Book book = bs.GetByID(id);

            List<SelectListItem> cats = new List<SelectListItem>();

            foreach (var item in cs.GetAll())
            {
                cats.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.ID.ToString(),
                    Selected = (item.ID == book.CategoryID ? true : false)
                });
            }

            ViewBag.CategoryID = cats;

            List<SelectListItem> auts = new List<SelectListItem>();

            foreach (var item in aus.GetAll())
            {
                auts.Add(new SelectListItem
                {
                    Text = item.AuthorLabel,
                    Value = item.ID.ToString(),
                    Selected = (item.ID == book.AuthorID ? true : false)
                });
            }

            ViewBag.AuthorID = auts;

            List<SelectListItem> pubs = new List<SelectListItem>();

            foreach (var item in ps.GetAll())
            {
                pubs.Add(new SelectListItem
                {
                    Text = item.CompanyName,
                    Value = item.ID.ToString(),
                    Selected = (item.ID == book.PublisherID ? true : false)
                });
            }

            ViewBag.PublisherID = pubs;

            return View(book);
        }

        [HttpPost]
        public ActionResult Update(Book item, HttpPostedFileBase pic)
        {
            ViewBag.CategoryID = new SelectList(cs.GetAll(), "ID", "Name", item.CategoryID);
            ViewBag.AuthorID = new SelectList(aus.GetAll(), "ID", "AuthorLabel", item.AuthorID);
            ViewBag.PublisherID = new SelectList(ps.GetAll(), "ID", "CompanyName", item.PublisherID);

            Book book = bs.GetByID(item.ID);

            if (ModelState.IsValid)
            {
                bool exist = bs.CheckBook(item,pic);

                if (!exist)
                {
                    if (pic != null)
                    {
                        bool isPicLoaded;
                        string fileResult = FxFunction.ImageUpload(pic, FolderPath.product, out isPicLoaded);

                        if (isPicLoaded)
                        {
                            book.ImagePath = fileResult;
                        }
                    }

                    book.Title = item.Title;
                    book.AuthorID = item.AuthorID;
                    book.CategoryID = item.CategoryID;
                    book.UnitPrice = item.UnitPrice;

                    bool updateBook = bs.Update(book);
                    if (updateBook)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Operation Unsuccessful";
                    }
                }
                else
                {
                    ViewBag.Message = "This book exists in the system. Please check title, auhtor, publisher, release date, translator and language";
                }
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return View(item);
        }

        public ActionResult Delete(Guid id)
        {
            bs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}