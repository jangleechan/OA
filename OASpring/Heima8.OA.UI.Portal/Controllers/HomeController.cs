using Heima8.OA.BLL;
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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            //if(Session["loginUser"] == null)
            //{
            //    return RedirectToAction("Index", "UserLogin");
            //}
            return View();
        }

        public ActionResult Console()
        {
           
            return View();
        }

        public ActionResult UserList()
        {
            return View();
        }


    }
}