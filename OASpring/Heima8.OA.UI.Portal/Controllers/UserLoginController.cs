using Heima8.OA.Common;
using Heima8.OA.IBLL;
using Heima8.OA.UI.Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    [LoginCheckFilterAttribute(IsCheck = false)]
    public class UserLoginController : Controller
    {
        public IUserInfoService UserInfoService { get; set; }
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }
        #region 验证码
        public ActionResult ShowVCode()
        {
            Common.ValidateCode validateCode = new ValidateCode();
            string strCode = validateCode.CreateValidateCode(4);

            //验证码放到Session
            Session["VCode"] = strCode;

            byte[] imgBytes = validateCode.CreateValidateGraphic(strCode);

            return File(imgBytes, @"image/jpeg");
        }
        #endregion

        #region 处理登陆的表单
        public ActionResult ProcessLogin()
        {
            //第一步:处理验证码
            //拿到表单中的验证码
            #region 验证码
            string strCode = Request["vercode"];

            //拿到Session中的验证码
            string sessionCode = Session["VCode"] as string;
            Session["VCode"] = null;
            if (string.IsNullOrEmpty(sessionCode))
            {
                return Content("验证码错误！");
            }

            if (strCode != sessionCode)
            {
                return Content("验证码错误！");
            }
            #endregion

            //第二步：处理验证用户名
            string name = Request["username"];
            string pwd = Request["password"];
            short delNormal = (short)Heima8.OA.Model.Enum.DelFlagEnum.Normal;
            var userInfo = UserInfoService.GetEntities(u => u.UName == name && u.Pwd == pwd && u.DelFlag == delNormal).FirstOrDefault();

            if(userInfo == null)//没有查询出数据
            {
                return Content("用户名密码错误！");
            }
            Session["loginUser"] = userInfo;
            //如果正确那么跳转到首页
            return Content("ok");
        }
        #endregion

    }
}