using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DotNetService = DAL.DotNetService;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Drawing;
namespace WebUI.Controllers
{
    public class UserInfoController :BaseController
    {

		public ActionResult Index() {
			return View();
		}

		
		/// <summary>
		/// 添加信息
		/// </summary>
		public ActionResult Create(UserInfo entity) {

            if (WebHelper.CurrentUser != null)
            {
                entity.OpeID = WebHelper.CurrentUser.ID;
                entity.UserType = 0;

                if (entity.ImageData != null)
                {
                    string base64Str = entity.ImageData;
                    byte[] bytes = System.Convert.FromBase64String(base64Str.Substring(base64Str.IndexOf("base64") + 7));
                    using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
                    {
                        Image img = System.Drawing.Image.FromStream(ms);
                        string imgUrl = "Upload/S" + Guid.NewGuid().ToString() + ".png";
                        string path = Request.PhysicalApplicationPath.Substring(0, Request.PhysicalApplicationPath.LastIndexOf("WebUI\\")) + "BgAdmin/" + imgUrl;
                        img.Save(path);

                        entity.IMG = "/" + imgUrl;
                    }
                }

                DotNetService.ServiceManager.Instance.UserInfo.Add(entity);
                return Content("OK");
            }
            return Content("Error");
		}

       /// <summary>
		/// 删除数据
		/// </summary>
		public ActionResult Delete(UserInfo entity) {
			DotNetService.ServiceManager.Instance.UserInfo.Delete(entity.UID);
			return Content("OK");
		}

		/// <summary>
		/// 批量删除数据
		/// </summary>
		public ActionResult DeleteALL(string Ids) {
            if (string.IsNullOrEmpty(Ids))
            {
                return Content("请您选择需要删除的信息");
            }
            var idStrs = Ids.Split(',');
            foreach (var idStr in idStrs)
            {
                DotNetService.ServiceManager.Instance.UserInfo.Delete(int.Parse(idStr));
            }
            return Content("OK");
		}

		/// <summary>
		/// 根据ID得到对象实体
		/// </summary>
		public ActionResult GetEntity(int? UID) {
			var temp = DotNetService.ServiceManager.Instance.UserInfo.GetList().Where(c => c.UID == UID).FirstOrDefault();
           
                if (temp.IMG != null)
                {
                    temp.IMG = WebHelper.BgAdminServer + temp.IMG;
                }
			return Json(temp, JsonRequestBehavior.AllowGet);
		}



		/// <summary>
		/// 修改数据信息
		/// </summary>
		public ActionResult Edit(UserInfo entity) {
			UserInfo model = DotNetService.ServiceManager.Instance.UserInfo.GetList().Where(c => c.UID == entity.UID).FirstOrDefault();
			if (model == null) {
				return Content("请您检查，错误信息");
			}
			model.NAME = entity.NAME;
			model.SEX = entity.SEX;
			model.DATA = entity.DATA;
			model.PLACE = entity.PLACE;
			model.NATION = entity.NATION;
			model.HEIGHT = entity.HEIGHT;
			model.IMG = entity.IMG;
			model.HISTORY = entity.HISTORY;
			model.EDUCATION = entity.EDUCATION;
			model.SCHOOL = entity.SCHOOL;
			model.ADDRESS = entity.ADDRESS;
			model.WORKT = entity.WORKT;
			model.WORKPLACE = entity.WORKPLACE;
			model.PHONE = entity.PHONE;
			model.INTEREST = entity.INTEREST;
			model.OHEIGHT = entity.OHEIGHT;
			model.OWORK = entity.OWORK;
			model.OINTEREST = entity.OINTEREST;
			model.OSTRENGTH = entity.OSTRENGTH;
			model.MIN = entity.MIN;
			model.MAX = entity.MAX;
			model.OWORKPLACE = entity.OWORKPLACE;
			model.FAMILY = entity.FAMILY;
			if (DotNetService.ServiceManager.Instance.UserInfo.Update(model) > 0) {
				return Content("OK");
			}
			return Content("Error");
		}



        public ActionResult GetUserInfos()
        {

            var items = DotNetService.ServiceManager.Instance.UserInfo.GetList("usertype=1");

            foreach (var item in items)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
            }
           // JsonConvert.SerializeObject(items);
            return JsonDate(items);
        }


        public ActionResult GetFilter(string sex)
        {
            if (sex == "")
            {
                return GetUserInfos();
            }
            var items = DotNetService.ServiceManager.Instance.UserInfo.GetList("usertype=1 and sex='" + sex + "'");
            foreach (var item in items)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
            }
            // JsonConvert.SerializeObject(items);
            return JsonDate(items);
        }


        public ActionResult GetMyFilter(string sex)
        {
            if (sex == "")
            {
                return GetMyUserInfos();
            }
            var items = DotNetService.ServiceManager.Instance.UserInfo.GetList("sex='" + sex + "'  and OpeID=" + WebHelper.CurrentUser.ID);
            foreach (var item in items)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
            }
            // JsonConvert.SerializeObject(items);
            return JsonDate(items);
        }

        public ActionResult GetMyUserInfos()
        {
            var items = DotNetService.ServiceManager.Instance.UserInfo.GetList("OpeID=" + WebHelper.CurrentUser.ID);

            foreach (var item in items)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
            }

            return JsonDate(items);
        }


        public ActionResult GetAll(string PAGE_SIZE, string PAGE_INDEX, string KEY)
        {
            //首先拿到传递过来的参数
            int pageIndex = int.Parse(PAGE_INDEX);
            int pageSize = int.Parse(PAGE_SIZE);
            List<UserInfo> list = null;
            int total = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder("UserType=1");

            if (KEY != "")
            {
                sb.Append(" and sex='"+KEY+"'");
            }

            total = DotNetService.ServiceManager.Instance.UserInfo.GetCount(sb.ToString());
            list = DotNetService.ServiceManager.Instance.UserInfo.GetListByPage(sb.ToString(), "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);


            foreach(var item in list)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
                else
                {
                    item.IMG = WebHelper.BgAdminServer + "/Content/Images/nopic.gif";
                }
            }

            //var result = new { total = total, rows = list };
            return JsonDate(list);
        }


        public ActionResult Test()
        {
            var items = DotNetService.ServiceManager.Instance.UserInfo.GetList();

            foreach (var item in items)
            {
                if (item.IMG != null)
                {
                    item.IMG = WebHelper.BgAdminServer + item.IMG;
                }
            }

            return JsonDate(items);
        }

    }
}
