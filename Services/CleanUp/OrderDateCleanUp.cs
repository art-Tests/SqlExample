using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderDateCleanUp : ICleanUpSql
    {
        private readonly ISearchCondition _sc;

        public OrderDateCleanUp(ISearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            var start = _sc.GetValueByFieldName("OrderDateStart");
            var end = _sc.GetValueByFieldName("OrderDateEnd");

            return !string.IsNullOrEmpty(start) && !string.IsNullOrEmpty(end)
                ? sqlCmd.Replace("--[@orderDateStart]--", string.Empty)
                    .Replace("--[@orderDateEnd]--", string.Empty)
                : sqlCmd;
        }
    }
}