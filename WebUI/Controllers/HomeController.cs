using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }

        public ActionResult Center()
        {
            return View();
        }

    }
}

