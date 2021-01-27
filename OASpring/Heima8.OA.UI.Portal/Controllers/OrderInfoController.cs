using Heima8.OA.IBLL;
using Heima8.OA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Heima8.OA.UI.Portal.Controllers
{
    public class OrderInfoController : Controller
    {
        IOrderInfoService OrderInfoService { get; set; }
        // GET: OrderInfo
        public ActionResult Index()
        {
            ViewData.Model = OrderInfoService.GetEntities(u => true);
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(OrderInfo orderInfo)
        {
            if (ModelState.IsValid)
            {
                OrderInfoService.Add(orderInfo);
            }
            return RedirectToAction("Index");
        }
    }
}