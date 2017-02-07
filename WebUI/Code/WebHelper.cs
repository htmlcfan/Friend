using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetService = DAL.DotNetService;
using Model;
using System.IO;

namespace WebUI
{
    public static class WebHelper
    {
        private static string _userSession = "UserCenter";
        public static bool IsUserLogin()
        {
            if (CurrentUser == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static Model.Admin CurrentUser
        {
            get
            {
                if (HttpContext.Current.Session[_userSession] != null)
                    return (Model.Admin)HttpContext.Current.Session[_userSession];
                else
                {
                    return null;
                }
            }
        }


        public static bool UserLogin(string name, string password)
        {
            Model.Admin user = DAL.DotNetService.ServiceManager.Instance.Admin.GetModel(name);
            if (user == null)
            {
                return false;
            }
            if (user.Password == password)
            {
                HttpContext.Current.Session[_userSession] = user ;
                return true;
            }
            else
            {
                HttpContext.Current.Session[_userSession] = null;
                return false;
            }
        }

        private static string _BgAdminServer = "";

        public static string BgAdminServer
        {
            get
            {
                if (string.IsNullOrEmpty(_BgAdminServer))
                {
                    _BgAdminServer = System.Configuration.ConfigurationManager.AppSettings["BgAdminServer"];
                }
                return _BgAdminServer;
            }
        }
    }
}