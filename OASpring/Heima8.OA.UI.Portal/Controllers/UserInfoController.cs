using Heima8.OA.IBLL;
using Heima8.OA.Model;
using Heima8.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    [LoginCheckFilterAttribute(IsCheck = false)]
    public class UserInfoController : Controller
    {
        public IUserInfoService UserInfoService { get; set; }
        // GET: UserInfo
        public ActionResult Index()
        {
            ViewData.Model = UserInfoService.GetEntities(u => true);
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetAllUserInfos()
        {
            //
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;


            short delFlagNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;

            //不带查询数据的页面数据加载方法
            var pageData = UserInfoService.GetPageEntites(pageSize,
                                                           pageIndex,
                                                           out total,
                                                           u => u.DelFlag == delFlagNormal,
                                                           u => u.Id, true)
                                                           .Select(u =>
                                                           new { u.Id, u.UName, u.Remark, u.ShowName, u.SubTime, u.ModifiedOn, u.Pwd });


            var result = new { code = 0, msg = "success", count = total, data = pageData.ToList() };
            JsonResult str = Json(result, JsonRequestBehavior.AllowGet);
            return str;
        }


        [HttpGet]
        public ActionResult GetAllUserInfoWithSearchParam()
        {
            //
            int pageSize = int.Parse(Request["limit"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");


            //过滤的用户名过滤备注
            string schName = Request["username"];
            string schRemark = Request["remark"];
            var queryParam = new Model.Param.UserQueryParam()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = 0,
                SchName = schName,
                SchRemark = schRemark
            };

            //带查询参数的数据查询方法
            var pageData = UserInfoService.LoadPageData(queryParam);

            var temp = pageData.Select(u => new { u.Id, u.UName, u.Remark, u.ShowName, u.SubTime, u.ModifiedOn, u.Pwd });
            var result = new { code = 0, msg="success", count = queryParam.Total, data = temp.ToList() };
            JsonResult str = Json(result, JsonRequestBehavior.AllowGet);
            return str;
        }

        public ActionResult Add(UserInfo userInfo)
        {
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfo.DelFlag = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            UserInfoService.Add(userInfo);

           
            return Content("success");
        }

        public ActionResult EditById(int id)
        {
            ViewData.Model = UserInfoService.GetEntities(u => u.Id == id).FirstOrDefault();
            return View();
        }

        public ActionResult Edit(UserInfo userInfo)
        {
            userInfo.ModifiedOn = DateTime.Now;
            userInfo.SubTime = DateTime.Now;
            userInfo.DelFlag = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            UserInfoService.Update(userInfo);
            return Content("success");
        }

        #region Create
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                UserInfoService.Add(userInfo);
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region 删除
        public ActionResult Delete(string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return Content("请选择要删除的数据！");
            }

            //正常的处理
            string[] strIds = ids.Split(',');
            List<int> idList = new List<int>();

            foreach (var strId in strIds)
            {
                idList.Add(int.Parse(strId));
            }
            UserInfoService.DeleteListByLogical(idList);
            return Content("ok");
        }
        #endregion



    }
}