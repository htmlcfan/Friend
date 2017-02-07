using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using DotNetService = DAL.DotNetService;
using Model;
using System.IO;
using System.Drawing;

namespace WebUI.Controllers
{
    public class GateController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AdBoard()
        {
            return View();
        }

        public ActionResult CheckUser(string name, string password)
        {
            if (WebHelper.UserLogin(name, password))
            {
                return JsonRes(true, "", WebHelper.CurrentUser);
            }
            return JsonRes(false, "登录失败", null);
        }

        public ActionResult IsUserLogin()
        {
            bool islogin = (WebHelper.CurrentUser != null);
            if (islogin)
            {
                return JsonRes(true, "",null);
            }
            else
            {
                return JsonRes(false, "", "");
            }
        }


        public ActionResult JsonRes(bool res, string msg, object data)
        {
            return JsonDate(new { success = res, msg = msg, data = data });
        }
        public ContentResult JsonDate(object date)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(date, Formatting.Indented, timeConverter));
        }

    }
}
