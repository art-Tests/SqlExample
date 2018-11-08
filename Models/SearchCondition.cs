using System;

namespace SqlExample.Models
{
    /// <summary>
    /// 搜尋條件
    /// </summary>
    public class SearchCondition
    {
        public bool IsSearchShipCity => !string.IsNullOrEmpty(ShipCity);
        public bool IsSearchEmployeeId => EmployeeId > 0;
        public bool IsSearchOrderDate => OrderDateStart != null && OrderDateEnd != null;

        public int EmployeeId { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDateStart { get; set; }
        public DateTime? OrderDateEnd { get; set; }

        /// <summary> 決定用哪個SQLHelper </summary>
        public int HelperType { get; set; }
    }
}