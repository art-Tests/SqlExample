using System.Linq;
using System.Reflection;
using SqlExample.Enum;

namespace SqlExample.Models
{
    public class SearchCondition : BaseSearchCondition
    {
        public string EmployeeId { get; set; } = "3";
        public string ShipCity { get; set; } = "Lyon";
        public string OrderDateStart { get; set; } = "1996-07-05";
        public string OrderDateEnd { get; set; } = "1996-07-10";

        public OrderHelperType HelperType { get; set; } = OrderHelperType.OrderSqlHelper2;
    }
}