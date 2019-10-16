using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Areas.Employee.Controllers
{
    public class StockController : Controller
    {
        BookService bs = new BookService();
        DealerService ds = new DealerService();
        StockDetailService sds = new StockDetailService();

        public ActionResult Index()
        {    
            return View(bs.GetActive());
        }

        public ActionResult Insert()
        {
            ViewBag.DealerID = new SelectList(ds.GetActive(), "ID", "Name");
            ViewBag.BookID = new SelectList(bs.GetActive(), "ID", "Title");

            return View();
        }

        [HttpPost]
        public ActionResult Insert(StockDetail sd)
        {
            ViewBag.DealerID = new SelectList(ds.GetActive(), "ID", "Name", sd.DealerID);
            ViewBag.BookID = new SelectList(bs.GetActive(), "ID", "Title", sd.BookID);

            if (ModelState.IsValid)
            {
                StockDetail stockDetail = new StockDetail();
                stockDetail.BookID = sd.BookID;
                stockDetail.DealerID = sd.DealerID;
                stockDetail.UnitsInStock = sd.UnitsInStock;

                sds.Add(stockDetail);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return View();          
        }

        public ActionResult Update(Guid id)
        {
            StockDetail sd = sds.GetByID(id);

            ViewBag.DealerID = new SelectList(ds.GetActive(), "ID", "Name", sd.DealerID);
            ViewBag.BookID = new SelectList(bs.GetActive(), "ID", "Title", sd.BookID);

            return View(sd);
        }

        [HttpPost]
        public ActionResult Update(StockDetail sd)
        {
            ViewBag.DealerID = new SelectList(ds.GetActive(), "ID", "Name", sd.DealerID);
            ViewBag.BookID = new SelectList(bs.GetActive(), "ID", "Title", sd.BookID);

            if (ModelState.IsValid)
            {
                StockDetail stockDetail = sds.GetByID(sd.ID);
                stockDetail.Book = bs.GetByID(sd.BookID);
                stockDetail.Dealer = ds.GetByID(sd.DealerID);
                stockDetail.UnitsInStock = sd.UnitsInStock;

                sds.Update(stockDetail);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Invalid entry";
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetStockDetail(Guid id)
        {
            List<StockDetail> stocks = sds.GetDefault(m => m.BookID == id);

            return View(stocks);
        }

    }
}