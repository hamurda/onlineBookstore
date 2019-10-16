using Pandora.Model.Entities;
using Pandora.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pandora.UI.Controllers
{
    public class LoginController : Controller
    {
        CustomerService cs = new CustomerService();
        OrderService os = new OrderService();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Customer person)
        {
            if (cs.checkCredentials(person.EmailAddress,person.Password))
            {
                Customer cus = cs.GetByDefault(c=> c.EmailAddress == person.EmailAddress);

                Session["customer"] = cus;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["login"] = "Please check your email address and password.";
            }

            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult Register(Customer person)
        {
            if (cs.Any(c=> c.EmailAddress==person.EmailAddress))
            {
                TempData["new"] = "This email account has already been used.";
            }
            else
            {
                Customer cus = new Customer();
                cus.EmailAddress = person.EmailAddress;
                cus.Password = person.Password;
                cus.Username = person.Username;
                cus.FirstName = person.FirstName;
                cus.LastName = person.LastName;
                cus.Gender = person.Gender;

                bool result = cs.Add(person);
                if (result)
                {
                    Session["customer"] = person;
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            Session["customer"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}