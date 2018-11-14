using SqlExample.Enum;

namespace SqlExample.Models
{
    public class FugoSearchCondition : BaseSearchCondition
    {
        public string CustomerId { get; set; } = "28007239";
        public string AssignDateStart { get; set; } = "2014/11/20";
        public string AssignDateEnd { get; set; } = "2014/11/30";
        public FugoHelperType HelperType { get; set; } = FugoHelperType.FugoSqlHelper;
    }
}