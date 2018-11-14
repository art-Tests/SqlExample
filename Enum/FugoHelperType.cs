using SqlExample.Filter;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Enum
{
    public enum FugoHelperType
    {
        [SqlHelperStrategy(typeof(FugoSqlHelper))]
        FugoSqlHelper = 1
    }
}