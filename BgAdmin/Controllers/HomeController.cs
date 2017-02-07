using BgAdmin;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class HomeController : BaseController
    {


        public ActionResult Index()
        {
            ViewBag.BgAdmin = WebHelper.BgAdmin;
            if (Request.IsLocal)
            {
                ViewBag.BgAdmin1 = "BgAdminIsLocal";
            }
            else
            {
                ViewBag.BgAdmin1 = "BgAdminNoIsLocal";
            }
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

        private static List<TreeItem> menu;

        private static List<TreeItem> Menu
        {
            get
            {
                if (menu == null)
                {
                    //  _menu1 = DotNetService.ServiceManager.Instance.Menu.GetList();
                    menu = new List<TreeItem>();
                    menu.Add(new TreeItem() { Id = "1", FullName = "系统管理", ParentId = "0", Open = true });
                    menu.Add(new TreeItem() { Id = "11", FullName = "用户信息", ParentId = "1", NavigateUrl = WebHelper.BgAdmin+"/Admin/Index" });
                    menu.Add(new TreeItem() { Id = "12", FullName = "资料管理", ParentId = "1", NavigateUrl = WebHelper.BgAdmin+"/UserInfo/Index" });
                }
                return menu;
            }
        }


        //请把必用-测试数据库表结构.sql在数据库中执行下再把下面的注释去掉实现树形菜单功能！
        /*public JsonResult GetTree()
        {
            List<Model.BaseModule> list = DotNetService.ServiceManager.Instance.BaseModule.GetList().Where(c => c.IsMenu == 1).ToList();//用户可操作模块
            var jsonData = (
                       from m in list
                       select new
                       {
                           id = m.Id,
                           name = m.FullName,
                           weburl = m.NavigateUrl,
                           pId = m.ParentId,
                           open = true,
                           Iconic = m.ImageIndex
                       }
                   ).Distinct().OrderBy(c => c.id).ToList();
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }*/

        public JsonResult GetTree()
        {
            List<TreeItem> listMenu = new List<TreeItem>();
            listMenu = Menu;
            var jsonData = (
                       from m in listMenu
                       select new
                       {
                           id = m.Id,
                           name = m.FullName,
                           weburl = m.NavigateUrl,
                           pId = m.ParentId,
                           open = m.Open
                       }
                   ).ToList();

            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


    }
}

