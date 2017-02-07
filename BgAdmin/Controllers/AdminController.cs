using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using DotNetService = DAL.DotNetService;
namespace MvcUI.Controllers
{
    public class AdminController : BaseController
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
            List<Admin> list = null;
            int total = 0;
            System.Text.StringBuilder sb = new System.Text.StringBuilder("1=1");
            string searchText = Request["search_text"] != "" ? Request["search_text"] : string.Empty;
            string searchValue = Request["search_value"] != "" ? Request["search_value"] : string.Empty;
            if (searchValue == null && searchText == null)
            {
                total = DotNetService.ServiceManager.Instance.Admin.GetCount();
                list = DotNetService.ServiceManager.Instance.Admin.GetListByPage("id>1", "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
            }
            else
            {
                if (searchValue.Trim() != "")
                {
                    sb.AppendFormat(" and charindex('{0}',{1})>0", searchValue.Trim(), searchText.Trim());
                    total = DotNetService.ServiceManager.Instance.Admin.GetCount(sb.ToString());
                    list = DotNetService.ServiceManager.Instance.Admin.GetListByPage(sb.ToString(), "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                }
                else
                {
                    total = DotNetService.ServiceManager.Instance.Admin.GetCount();
                    list = DotNetService.ServiceManager.Instance.Admin.GetListByPage("id>1", "", (pageIndex - 1) * pageSize + 1, pageSize * pageIndex);
                }
            }
			var result = new { total = total, rows = list };
			return JsonDate(result);
		}

		/// <summary>
		/// 添加信息
		/// </summary>
		public ActionResult Create(Admin entity) {

            Model.Admin admin = DAL.DotNetService.ServiceManager.Instance.Admin.GetModel(entity.UserName);
            if (admin != null)
            {
                return Content("用户名已经存在！");
            }

			DotNetService.ServiceManager.Instance.Admin.Add(entity);
			return Content("OK");
		}

       /// <summary>
		/// 删除数据
		/// </summary>
		public ActionResult Delete(Admin entity) {
			DotNetService.ServiceManager.Instance.Admin.Delete(entity.ID);
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
                DotNetService.ServiceManager.Instance.Admin.Delete(int.Parse(idStr));
            }
            return Content("OK");
		}

		/// <summary>
		/// 根据ID得到对象实体
		/// </summary>
		public ActionResult GetEntity(int? ID) {
			var temp = DotNetService.ServiceManager.Instance.Admin.GetList().Where(c => c.ID == ID).FirstOrDefault();
			return Json(temp, JsonRequestBehavior.AllowGet);
		}

		/// <summary>
		/// 修改数据信息
		/// </summary>
		public ActionResult Edit(Admin entity) {
			Admin model = DotNetService.ServiceManager.Instance.Admin.GetList().Where(c => c.ID == entity.ID).FirstOrDefault();
			if (model == null) {
				return Content("请您检查，错误信息");
			}
			model.UserName = entity.UserName;
			model.Password = entity.Password;
			if (DotNetService.ServiceManager.Instance.Admin.Update(model) > 0) {
				return Content("OK");
			}
			return Content("Error");
		}
    }
}
