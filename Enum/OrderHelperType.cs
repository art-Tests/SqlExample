using SqlExample.Filter;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Enum
{
    public enum OrderHelperType
    {
        [SqlHelperStrategy(typeof(OrderSqlHelper))]
        OrderSqlHelper = 1,

        [SqlHelperStrategy(typeof(OrderSqlHelper2))]
        OrderSqlHelper2 = 2
    }
}