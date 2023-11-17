using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppingCartAdmin.Controllers
{
    public class MaintainerController : Controller
    {
        public ActionResult Categories()
        {
            return View();
        }

        public ActionResult Brands()
        {
            return View();
        }

        public ActionResult Products() 
        {
            return View();
        }

    }
}