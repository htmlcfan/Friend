using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DotNetService = DAL.DotNetService;
using System.Drawing;
using BgAdmin;
namespace MvcUI.Controllers
{
    public class UserInfoController : BaseController
    {

		public ActionResult Index() {
			return View();
		}

		/// <summary>
		/// 实现查询出所有的菜单组信息
		/// </summary>
		/// <returns>返回查询出来的菜单组的Json串</returns>
		public ActionResult GetAll() {
			//首先拿到传递过来的参数
			int pageIndex = Request["page"] == null ? 1 : int.Parse(Request["page"]);
			int pageSize = Request["rows"] == null ? 10 : int.Parse(Request["rows"]);
            List<UserInfo> list = null;
            int total = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder("1=1");
            string searchText = Request["search_text"] != "" ? Request["search_text"] : string.Empty;
            string searchValue = Request["search_value"] != "" ? Request["search_value"] : string.Empty;
            if (searchValue == null && searchText == null)
            {
                total = DotNetService.ServiceManager.Instance.UserInfo.GetCount();
                list = DotNetService.ServiceManager.Instance.UserInfo.GetListByPage("", "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
            }
            else
            {
                if (searchValue.Trim() != "")
                {
                    sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue.Trim(), searchText.Trim());
                    total = DotNetService.ServiceManager.Instance.UserInfo.GetCount(sb.ToString());
                    list = DotNetService.ServiceManager.Instance.UserInfo.GetListByPage(sb.ToString(), "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                }
                else
                {
                    total = DotNetService.ServiceManager.Instance.UserInfo.GetCount();
                    list = DotNetService.ServiceManager.Instance.UserInfo.GetListByPage("", "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                }
            }
			var result = new { total = total, rows = list };
			return JsonDate(result);
		}

		/// <summary>
		/// 添加信息
		/// </summary>
		public ActionResult Create(UserInfo entity) {

            entity.UserType = 0;
			DotNetService.ServiceManager.Instance.UserInfo.Add(entity);
			return Content("OK");
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
			return Json(temp, JsonRequestBehavior.AllowGet);
		}



        [HttpPost]
        public ActionResult UploadImg(string UID)
        {

            HttpFileCollectionBase files = Request.Files;
            if (files.Count == 0)
            {
                return JsonRes(false, "请选择上传文件", null);
            }
            string fileFolder = Server.MapPath("~/Upload/");
            string fileName = UID;
            string error = SaveFileImg(files, fileFolder, ref fileName);
            if (error != "")
            {
                return JsonRes(false, error, null);
            }
            return JsonRes(true, "11", fileName);
        }

        private string SaveFileImg(HttpFileCollectionBase files, string fileFolder, ref string fileName)
        {
            foreach (string k in files.AllKeys)
            {
                HttpPostedFileBase file = files[k];

                if (file == null || file.ContentLength == 0)
                {
                    continue;
                }

                string fileExtention = file.FileName.Substring(file.FileName.LastIndexOf('.')).ToUpper();
                fileName = fileName + fileExtention;
                string savePath = fileFolder + fileName;

                if (file.ContentLength > 1024 * 1024 * 20)
                {
                    return fileName + "文件大于20M，不能上传";
                }

                if ((fileName.LastIndexOf('.') > -1
                    && (fileExtention == ".JPG" || fileExtention == ".GIF" || fileExtention == ".PNG" || fileExtention == ".BMP")))
                {
                    file.SaveAs(savePath);
                }
                else
                {
                    return fileName + "文件格式不正确， 只允许图片";
                }
            }
            return "";
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


        public ActionResult CheckUser(string UID, string userType)
        {
            UID = DAL.DALHelper.GetSafeParam(UID);
            userType = DAL.DALHelper.GetSafeParam(userType);
            Model.UserInfo model = DotNetService.ServiceManager.Instance.UserInfo.GetModel(int.Parse(UID));


            DotNetService.ServiceManager.Instance.UserInfo.UpdateState(UID, userType);
            return JsonRes(true, "", null);
        }


        public ActionResult GetModel(string UID)
        {
            UID = DAL.DALHelper.GetSafeParam(UID);
            Model.UserInfo model = DotNetService.ServiceManager.Instance.UserInfo.GetModel(int.Parse(UID));

            if (model.IMG != null)
            {
                model.IMG = WebHelper.BgAdmin+model.IMG;
            }

            return JsonRes(true, "", model);
        }



        public ActionResult SaveImage(string UID, string base64Str)
        {
            byte[] bytes = System.Convert.FromBase64String(base64Str.Substring(base64Str.IndexOf("base64") + 7));
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(bytes))
            {
                Image img = System.Drawing.Image.FromStream(ms);

                string imgUrl = "Upload/S" + Guid.NewGuid().ToString() + ".png";
                string path = Request.PhysicalApplicationPath + imgUrl;
                img.Save(path);
                Model.UserInfo model = DotNetService.ServiceManager.Instance.UserInfo.GetModel(int.Parse(UID));
                model.IMG = "/" + imgUrl;
                DotNetService.ServiceManager.Instance.UserInfo.Update(model);
            }

            return JsonRes(true, "", null);
        }
    }
}
