using System;

namespace SqlExample.Models
{
    public class SearchCondition
    {
        public bool IsSearchShipCity => !string.IsNullOrEmpty(ShipCity);
        public bool IsSearchEmployeeId => EmployeeId > 0;
        public bool IsSearchOrderDate => OrderDateStart != null && OrderDateEnd != null;

        public int EmployeeId { get; set; } = 3;
        public string ShipCity { get; set; } = "Lyon";
        public string OrderDateStart { get; set; } = "1996-07-05";
        public string OrderDateEnd { get; set; } = "1996-07-10";

        public string HelperType { get; set; } = "OrderSqlHelper2";
    }
}