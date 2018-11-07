using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderDateCleanUp : ICleanUpSql
    {
        private readonly SearchCondition _sc;

        public OrderDateCleanUp(SearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            return (_sc.IsSearchOrderDate)
                ? sqlCmd.Replace("--[@orderDateStart]--", string.Empty)
                    .Replace("--[@orderDateEnd]--", string.Empty)
                : sqlCmd;
        }
    }
}