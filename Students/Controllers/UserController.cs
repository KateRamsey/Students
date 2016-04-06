using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Students.Models;

namespace Students.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        [Route("user/{hello}")]
        public ActionResult Hello()
        {
            if (Request.Cookies["name"] != null)
            {
                var name = Request.Cookies["name"].ToString();
                User user = new User() {Name = name};
                return View(user);
            }

            return View();
        }

        [HttpPost]
        public ActionResult Hello(User user)
        {
            HttpCookie aCookie = new HttpCookie("name");
            aCookie.Value = user.Name;
            Response.Cookies.Add(aCookie);
            return View(user);
        }
    }
}