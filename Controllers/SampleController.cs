using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlExample.Models;
using SqlExample.Services;
using SqlExample.Services.Factory;
using SqlExample.Services.SqlHelper;
using SqlExample.ViewModels.Sample;

namespace SqlExample.Controllers
{
    public class SampleController : Controller
    {
        private readonly OrderService _orderService = OrderFactory.GetService();

        public ActionResult Index()
        {
            var vm = new IndexViewModel
            {
                HelperName = string.Empty,
                Condition = new SearchCondition(),
                Data = new List<NorthWindOrder>(),
                SqlCmd = _orderService.SqlCmd
            };
            ViewBag.Vm = JsonConvert.SerializeObject(vm);

            return View();
        }

        [HttpPost]
        public ActionResult Index(SearchCondition sc)
        {
            var orderHelper = OrderFactory.GetSqlHelper(sc.HelperType);
            var model = _orderService.QueryByCondition(orderHelper, sc);

            var vm = new IndexViewModel
            {
                HelperName = orderHelper.GetName(),
                Condition = sc,
                Data = model,
                SqlCmd = _orderService.SqlCmd
            };

            ViewBag.Vm = JsonConvert.SerializeObject(vm);
            return View();
        }
    }
}