using Heima8.OA.IBLL;
using Heima8.OA.Model;
using Heima8.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Heima8.OA.UI.Portal.Controllers
{

    [LoginCheckFilterAttribute(IsCheck = false)]
    public class DailyWorkController : Controller
    {
        public IDailyWorkService DailyWorkService { get; set; }
        public IUserInfoService UserInfoService { get; set; }

        public ISysDeptService SysDeptService { get; set; }
        // GET: DailyWork
        public ActionResult Index()
        {
            short delFlagNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;

            var userInfos = UserInfoService.GetEntities(u => u.DelFlag == delFlagNormal);
            
            SelectList userInfoSel = new SelectList(userInfos, "Id", "UName");
            
            ViewData["userInfos"] = userInfoSel;

            var sysDepts = SysDeptService.GetEntities(u => u.DelFlag == delFlagNormal);
            SelectList sysDeptSel = new SelectList(sysDepts, "Id", "DeptName");
            ViewData["sysDepts"] = sysDeptSel;

            return View();
        }

        public ActionResult GetAllDailyWorks()
        {
            //
            int pageSize = int.Parse(Request["rows"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");
            int total = 0;
            //int total = 0;
            short delFlagNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            var pageData = DailyWorkService.GetPageEntites(pageSize,
                                                           pageIndex,
                                                           out total,
                                                           u => u.DelFlag == delFlagNormal,
                                                           u => u.Id, true)
                                                           .Select(u =>
                                                           new { u.Id, u.WorkName, u.WorkContent,u.SqlLog, u.SysDept.DeptName, u.Remark,u.UserInfo.UName, u.SubTime, u.ModifiedOn});
            var result = new { code = 0, msg = "success", count = total, data = pageData.ToList() };
            JsonResult str = Json(result, JsonRequestBehavior.AllowGet);
            return str;
        }

        [HttpGet]
        public ActionResult GetAllDailyWorksWithSearchParam()
        {
            //
            int pageSize = int.Parse(Request["limit"] ?? "10");
            int pageIndex = int.Parse(Request["page"] ?? "1");


            //过滤的用户名过滤备注
            string schWorkName = Request["workname"];
            string schWorkContent = Request["workcontent"];
            int schSysDeptId = Convert.ToInt32(Request["sysdeptid"]==""?"0":Request["sysdeptid"]);
            int schUserInfoId = Convert.ToInt32(Request["userinfoid"] == "" ? "0" : Request["userinfoid"]);
            string schRemark = Request["remark"];
            var queryParam = new Model.Param.DailyWorkParam()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                Total = 0,
                SchWorkName = schWorkName,
                SchWorkContent = schWorkContent,
                SchSysDeptId = schSysDeptId,
                SchUserInfoId = schUserInfoId,
                SchRemark = schRemark
            };

            //带查询参数的数据查询方法
            var pageData = DailyWorkService.LoadPageData(queryParam);

            var temp = pageData.Select(u => new { u.Id, u.WorkName, u.WorkContent, u.SqlLog, u.SysDept.DeptName, u.Remark, u.UserInfo.UName, u.SubTime, u.ModifiedOn });
            var result = new { code = 0, msg = "success", count = queryParam.Total, data = temp.ToList() };
            JsonResult str = Json(result, JsonRequestBehavior.AllowGet);
            return str;


        }

        public ActionResult Create()
        {
            short delFlagNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;

            var userInfos = UserInfoService.GetEntities(u => u.DelFlag == delFlagNormal);
            SelectList userInfoSel = new SelectList(userInfos, "Id", "UName");
            ViewData["userInfos"] = userInfoSel;

            var sysDepts = SysDeptService.GetEntities(u => u.DelFlag == delFlagNormal);
            SelectList sysDeptSel = new SelectList(sysDepts, "Id", "DeptName");
            ViewData["sysDepts"] = sysDeptSel;

            return View();
        }

        public ActionResult Add(DailyWork dailyWork)
        {
            dailyWork.ModifiedOn = DateTime.Now;
            dailyWork.SubTime = DateTime.Now;
            DailyWorkService.Add(dailyWork);
            return Content("success");
        }

        public ActionResult EditById(int id)
        {
            short delFlagNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;

            
            //获取Id所对应的对象
            DailyWork dailyWorkItem = DailyWorkService.GetEntities(u => u.Id == id).FirstOrDefault();
            var sysDept = SysDeptService.GetEntities(u => u.Id == dailyWorkItem.SysDeptId).FirstOrDefault();
            var userInfo = UserInfoService.GetEntities(u => u.Id == dailyWorkItem.UserInfoId).FirstOrDefault();

            var userInfos = UserInfoService.GetEntities(u => u.DelFlag == delFlagNormal);
            SelectList userInfoSel = new SelectList(userInfos, "Id", "UName", userInfo.UName);
            ViewData["userInfos"] = userInfoSel;


            var sysDepts = SysDeptService.GetEntities(u => u.DelFlag == delFlagNormal);
            SelectList sysDeptSel = new SelectList(sysDepts, "Id", "DeptName", sysDept.DeptName);
            ViewData["sysDepts"] = sysDeptSel;

            //获取科室Id所对应的对象数组
            //List<SysDept> sysDeptList = SysDeptService.GetEntities(u => u.Id == dailyWorkItem.SysDeptId).ToList();
            //List<UserInfo> userInfoList = UserInfoService.GetEntities(u => u.Id == dailyWorkItem.UserInfoId).ToList();
            //创建选择列表对象
            //SelectList sysDeptSel = new SelectList(sysDeptList, "Id", "DeptName", dailyWorkItem.SysDeptId);
            //SelectList userInfoSel = new SelectList(userInfoList, "Id", "UName", dailyWorkItem.UserInfoId);
            ViewData.Model = dailyWorkItem;
            ViewData["sysDepts"] = sysDeptSel;
            ViewData["userInfos"] = userInfoSel;
            return View();
        }

        public ActionResult Edit(DailyWork dailyWork)
        {
            dailyWork.ModifiedOn = DateTime.Now;
            dailyWork.SubTime = DateTime.Now;
            dailyWork.DelFlag = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            DailyWorkService.Update(dailyWork);
            return Content("success");
        }

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
            DailyWorkService.DeleteListByLogical(idList);
            return Content("ok");
        }


    }
}