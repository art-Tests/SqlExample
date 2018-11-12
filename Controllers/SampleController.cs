using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlExample.Models;
using SqlExample.Services;
using SqlExample.Services.Factory;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Controllers
{
    public class SampleController : Controller
    {
        private readonly OrderService _orderService = OrderFactory.GetService();

        public ActionResult Index()
        {
            ViewBag.Condition = JsonConvert.SerializeObject(new SearchCondition());

            var model = new List<NorthWindOrder>();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(SearchCondition sc)
        {
            var orderHelper = OrderFactory.GetSqlHelper(sc.HelperType);
            var model = _orderService.QueryByCondition(orderHelper, sc);
            ViewBag.HelperName = orderHelper.GetName();
            ViewBag.Condition = JsonConvert.SerializeObject(sc);
            ViewBag.Data = JsonConvert.SerializeObject(model);
            ViewBag.SqlCmd = _orderService.SqlCmd;
            return View();
        }
    }
}