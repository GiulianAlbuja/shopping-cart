using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using ShoppingCartEntity;
using ShoppingCartBusiness;

namespace ShoppingCartAdmin.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ListUsers()
        {
            List<User> users = new List<User>();
            users = new BusinessUsers().ListUsers();
            return Json(new { data = users }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUser(User user)
        {
            object result;
            String message = String.Empty;

            if (user.IdUser == 0)
            {
                result = new BusinessUsers().RegisterUser(user, out message);
            }
            else
            {
                result = new BusinessUsers().EditUser(user, out message);
            }

            return Json(new { result = result, message = message }, JsonRequestBehavior.AllowGet);
        }
    }
}