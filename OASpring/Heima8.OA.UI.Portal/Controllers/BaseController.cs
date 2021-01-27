using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class BaseController:Controller
    {
        public bool IsCheckUserLogin = true;
        public UserInfo LoginUser { get; set; }
      
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            base.OnActionExecuted(filterContext);

            var items = filterContext.RouteData.Values;

            if (IsCheckUserLogin)
            {
                //校验用户是否已经登陆
                if (filterContext.HttpContext.Session["loginUser"] == null)
                {
                    filterContext.HttpContext.Response.Redirect("/UserLogin/Index");
                }
                else
                {
                    LoginUser = filterContext.HttpContext.Session["loginUser"] as UserInfo;
                }
            }

            
        }
    }
}