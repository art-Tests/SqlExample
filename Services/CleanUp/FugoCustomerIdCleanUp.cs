using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class FugoCustomerIdCleanUp : ICleanUpSql
    {
        private readonly FugoSearchCondition _sc;

        public FugoCustomerIdCleanUp(FugoSearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            return (!string.IsNullOrEmpty(_sc.CustomerId))
                ? sqlCmd.Replace("--[@customerId]--", string.Empty)
                .Replace("@CustomerId", _sc.CustomerId)
                : sqlCmd;
        }
    }
}