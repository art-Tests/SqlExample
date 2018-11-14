using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderShipCityCleanUp : ICleanUpSql
    {
        private readonly ISearchCondition _sc;

        public OrderShipCityCleanUp(ISearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            var value = _sc.GetValueByFieldName("ShipCity");

            return !string.IsNullOrEmpty(value)
                ? sqlCmd.Replace("--[@shipCity]--", string.Empty)
                : sqlCmd;
        }
    }
}