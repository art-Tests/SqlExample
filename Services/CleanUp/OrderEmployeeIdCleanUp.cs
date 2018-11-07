using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderEmployeeIdCleanUp : ICleanUpSql
    {
        private readonly SearchCondition _sc;

        public OrderEmployeeIdCleanUp(SearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            return _sc.IsSearchEmployeeId
                ? sqlCmd.Replace("--[@employeeId]--", string.Empty)
                : sqlCmd;
        }
    }
}