using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderEmployeeIdCleanUp : ICleanUpSql
    {
        private readonly ISearchCondition _sc;

        public OrderEmployeeIdCleanUp(ISearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            var value = _sc.GetValueByFieldName("EmployeeId");
            return !string.IsNullOrEmpty(value)
                ? sqlCmd.Replace("--[@employeeId]--", string.Empty)
                : sqlCmd;
        }
    }
}