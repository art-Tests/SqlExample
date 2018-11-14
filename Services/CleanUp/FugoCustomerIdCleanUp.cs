using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class FugoCustomerIdCleanUp : ICleanUpSql
    {
        private readonly ISearchCondition _sc;

        public FugoCustomerIdCleanUp(ISearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            var value = _sc.GetValueByFieldName("CustomerId");
            return !string.IsNullOrEmpty(value)
                ? sqlCmd.Replace("--[@customerId]--", string.Empty)
                .Replace("@CustomerId", value)
                : sqlCmd;
        }
    }
}