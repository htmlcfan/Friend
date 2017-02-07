using BgAdmin;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class BaseController : Controller
    {
     
        /// <summary>
        /// 返回处理过的时间的Json字符串
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public ContentResult JsonDate(object date)
        {
            var timeConverter = new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" };
            return Content(JsonConvert.SerializeObject(date, Formatting.Indented, timeConverter));
        }


        protected void UserLogOut()
        {
            Session.Abandon();
            Response.Write("<script type='text/javascript'>top.location.href='"+WebHelper.BgAdmin+"/Gate/Login/';</script>");
        }

        /// <summary>
        /// 重新基类在Action执行之前的事情
        /// </summary>
        /// <param name="filterContext">重写方法的参数</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!WebHelper.IsUserLogin())
            {
                UserLogOut();
                Response.End();
                return;
            }
            ViewBag.AdminName = WebHelper.CurrentUser.UserName;
            ViewBag.BgAdmin = WebHelper.BgAdmin;
            if (Request.IsLocal)
            {
                ViewBag.BgAdmin1 = "BgAdminIsLocal";
            }
            else
            {
                ViewBag.BgAdmin1 = "BgAdminNoIsLocal";
            }
            base.OnActionExecuting(filterContext);
        }
        public ActionResult JsonRes(bool res, string msg, object data)
        {
            return JsonDate(new { success = res, msg = msg, data = data });
        }
    }
}

