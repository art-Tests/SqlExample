using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SqlExample.Models;
using SqlExample.Services.Factory;
using SqlExample.ViewModels.Fugo;

namespace SqlExample.Controllers
{
    public class FugoController : Controller
    {
        public IActionResult Index()
        {
            var vm = new IndexViewModel
            {
                Title = "PUMA",
                SqlCmd = " I got puma!",
                Condition = new FugoSearchCondition()
            };
            ViewBag.Vm = JsonConvert.SerializeObject(vm);

            return View();
        }

        [HttpPost]
        public IActionResult Index(FugoSearchCondition sc)
        {
            var helper = FugoFactory.GetSqlHelper(sc.HelperType);
            var vm = new IndexViewModel
            {
                Title = helper.GetName(),
                SqlCmd = helper.GetSqlCmd(sc),
                Condition = sc
            };
            ViewBag.Vm = JsonConvert.SerializeObject(vm);

            return View();
        }
    }
}