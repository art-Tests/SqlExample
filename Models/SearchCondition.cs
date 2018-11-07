using System;

namespace SqlExample.Models
{
    /// <summary>
    /// ·j´M±ø¥ó
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
    }
}