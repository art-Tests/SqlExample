using System.Collections.Generic;
using SqlExample.Controllers;
using SqlExample.Models;

namespace SqlExample.ViewModels.Fugo
{
    public class IndexViewModel
    {
        public string Title { get; set; }
        public string SqlCmd { get; set; }
        public FugoSearchCondition Condition { get; set; }
    }
}