using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class OrderShipCityCleanUp : ICleanUpSql
    {
        private readonly SearchCondition _sc;

        public OrderShipCityCleanUp(SearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            return _sc.IsSearchShipCity
                ? sqlCmd.Replace("--[@shipCity]--", string.Empty)
                : sqlCmd;
        }
    }
}