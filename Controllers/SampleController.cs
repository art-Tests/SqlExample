using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SqlExample.Models;
using SqlExample.Services;

namespace SqlExample.Controllers
{
    public class SampleController : Controller
    {
        private readonly OrderService _orderService = OrderFactory.GetService();
        private readonly OrderSqlHelper _orderHelper = OrderFactory.GetSqlHelper();

        public ActionResult Index()
        {
            var model = new List<NorthWindOrder>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchCondition sc)
        {
            var model = _orderService.QueryByCondition(_orderHelper, sc);
            ViewBag.SqlCmd = _orderService.SqlCmd;
            return View(model);
        }
    }
}