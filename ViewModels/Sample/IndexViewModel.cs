using System.Collections.Generic;
using SqlExample.Models;

namespace SqlExample.ViewModels.Sample
{
    public class IndexViewModel
    {
        public string HelperName { get; set; }
        public SearchCondition Condition { get; set; }
        public IEnumerable<NorthWindOrder> Data { get; set; }
        public string SqlCmd { get; set; }
    }
}