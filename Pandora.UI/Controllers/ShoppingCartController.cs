using Pandora.Model.Entities;
using Pandora.Service.Option;
using Pandora.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Controllers
{
    public class ShoppingCartController : Controller
    {
        BookService bs = new BookService();
        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();
        CustomerService cuss = new CustomerService();
        ShipperService ss = new ShipperService();
        AddressService adrs = new AddressService();
        Random rnd = new Random();

        public ActionResult CartList()
        {
            return View((List<CartProduct>)Session["cart"]);
        }

        //public ActionResult AddToCart(Guid id)
        //{
        //    //TODO: Sayfayı refresh etmeden yapabilmek lazım. AJAX falan çalış.

        //    List<CartProduct> myCart;
        //    Book toCart = bs.GetByID(id);
        //    int? stock = bs.GetStock(id);

        //    if (Session["cart"] == null)
        //    {
        //        myCart = new List<CartProduct>();
        //    }
        //    else
        //    {
        //        myCart = (List<CartProduct>)Session["cart"];
        //    }

        //    if (myCart.Count < 1 || myCart.FirstOrDefault(m => m.ID == toCart.ID) == null)
        //    {
        //        CartProduct b = new CartProduct();
        //        b.ID = toCart.ID;
        //        b.ImagePath = toCart.ImagePath;
        //        b.Name = toCart.Title;
        //        b.Price = toCart.UnitPrice;
        //        b.Quantity = 1;

        //        myCart.Add(b);
        //    }
        //    else
        //    {
        //        CartProduct toUpdate = myCart.FirstOrDefault(m => m.ID == toCart.ID);
        //        if (stock>=toUpdate.Quantity+1)
        //        {
        //            toUpdate.Quantity++;
        //        }
        //        else
        //        {
        //            ViewBag.Message = "Sorry for inconvenience. Not enough item in stocks.";
        //        }
        //    }

        //    Session["cart"] = myCart;

        //    return RedirectToAction("CartList", "ShoppingCart");
        //}

        public ActionResult AddToCart(Guid id)
        {
            //TODO: Sayfayı refresh etmeden yapabilmek lazım. AJAX falan çalış.

            List<CartProduct> myCart;
            Book toCart = bs.GetByID(id);
            int? stock = bs.GetStock(id);

            if (Session["cart"] == null)
            {
                myCart = new List<CartProduct>();
            }
            else
            {
                myCart = (List<CartProduct>)Session["cart"];
            }

            if (myCart.Count < 1 || myCart.FirstOrDefault(m => m.ID == toCart.ID) == null)
            {
                CartProduct b = new CartProduct();
                b.ID = toCart.ID;
                b.ImagePath = toCart.ImagePath;
                b.Name = toCart.Title;
                b.Price = toCart.UnitPrice;
                b.Quantity = 1;

                myCart.Add(b);               
            }
            else
            {
                CartProduct toUpdate = myCart.FirstOrDefault(m => m.ID == toCart.ID);
                if (stock >= toUpdate.Quantity + 1)
                {
                    toUpdate.Quantity++;
                }
                else
                {
                    ViewBag.Message = "Sorry for inconvenience. Not enough item in stocks.";
                }
            }

            Session["cart"] = myCart;

            return Json(myCart, JsonRequestBehavior.AllowGet);
            //return RedirectToAction("CartList", "ShoppingCart");
        }


        public ActionResult RemoveOne(Guid id)
        {
            List<CartProduct> myCart = (List<CartProduct>)Session["cart"];

            CartProduct cb = myCart.FirstOrDefault((m => m.ID == id));

            if (cb.Quantity > 1)
            {
                cb.Quantity--;
            }
            else
            {
                myCart.Remove(cb);
            }

            Session["cart"] = myCart;

            if (myCart.Count == 0)
            {
                Session["cart"] = null;
            }

            return Json(myCart, JsonRequestBehavior.AllowGet);
           // return RedirectToAction("CartList", "ShoppingCart");
        }

        public ActionResult CheckOut()
        {
            List<CartProduct> myCart = (List<CartProduct>)Session["cart"];

            if (Session["customer"] != null)
            {
                Customer cus = (Customer)Session["customer"];

                Order newOrder = new Order();
                newOrder.OrderDate = DateTime.Now;
                newOrder.OrderStatus = Model.Entities.Enum.OrderStatus.Processing;
                newOrder.CustomerID = cus.ID;
                newOrder.BillAddressID = cus.BillAddressID;
                newOrder.ShipAddressID = cus.ShipAddressID;
               
                List<Shipper> shippers = ss.GetActive();
                int r = rnd.Next(shippers.Count-1);
                Shipper s = shippers[r] ;

                newOrder.ShipperID = s.ID;                
                os.Add(newOrder);

                ViewBag.OrderID = newOrder.ID;
                ViewBag.ShipperName = s.CompanyName;

                foreach (CartProduct item in myCart)
                {
                    OrderDetail detail = new OrderDetail();
                    detail.OrderID = newOrder.ID;
                    detail.BookID = item.ID;                   
                    detail.Quantity = (short?)item.Quantity;
                    detail.UnitPrice = item.Price;

                    Book b = bs.GetByID(item.ID);
                    b.HowManySold += item.Quantity;
                    bs.Update(b);

                    newOrder.OrderDetails.Add(detail);
                }

                os.Update(newOrder);

                Session["cart"] = null;
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }

            return View(myCart);
        }             

        public ActionResult Wishlist()
        {
            return View();
        }

        public ActionResult Remove(Guid id)
        {
            List<CartProduct> myCart = (List<CartProduct>)Session["cart"];
            myCart.RemoveAll(m => m.ID == id);

            if (myCart.Count > 0)
            {
                Session["cart"] = myCart;
            }
            else
            {
                Session["cart"] = null;
            }

            
            return RedirectToAction("CartList", "ShoppingCart");
        }
    }
}