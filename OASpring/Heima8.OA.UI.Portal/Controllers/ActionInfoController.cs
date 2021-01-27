using Heima8.OA.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Heima8.OA.UI.Portal.Controllers
{
    public class ActionInfoController : Controller
    {
        // GET: ActionInfo

        public IActionInfoService ActionInfoService { get; set; }
        public ActionResult Index()
        {
            //throw new Exception("dddddddddd");
            ViewData.Model = ActionInfoService.GetEntities(u => true).AsEnumerable();
            return View();
        }
    }
}