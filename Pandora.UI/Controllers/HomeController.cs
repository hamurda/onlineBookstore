using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Controllers
{
    public class HomeController : Controller
    {
        //TODO: 404 not found sf.sı açılmıyor bir bakmak lazım

        BookService bs = new BookService();
        CategoryService cs = new CategoryService();
        OrderDetailService ods = new OrderDetailService();

        public ActionResult Index()
        {
            List<Category> csList = cs.GetActive();
            List<Book> bookList = bs.GetActive();
            List<OrderDetail> details = ods.GetAll();

            ViewBag.bestSeller = bs.SelectBestSellers();
            
            Tuple<List<Category>, List<Book>> TupList = new Tuple<List<Category>, List<Book>>(csList, bookList);

            return View(TupList);
        }

        public ActionResult ProductDetail(Guid id)
        {
            List<Category> csList = cs.GetActive();           
            Book book = bs.GetByID(id);
            List<Book> bookSameCat = bs.GetDefault(m => m.CategoryID == book.CategoryID);
            Tuple<List<Category>, Book, List<Book>> TupList = new Tuple<List<Category>, Book, List<Book>>(csList, book, bookSameCat);

            return View(TupList);
        }

        public ActionResult Products(Guid id)
        {
            List<Category> csList = cs.GetActive();
            List<Book> bookList = bs.GetDefault(m => m.CategoryID == id);
            Tuple<List<Category>, List<Book>> TupList = new Tuple<List<Category>, List<Book>>(csList, bookList);
            return View(TupList);
        }
    }
}