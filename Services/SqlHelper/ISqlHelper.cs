using SqlExample.Models;

namespace SqlExample.Services.SqlHelper
{
    public interface ISqlHelper
    {
        string GetSqlCmd(FugoSearchCondition sc);

        string GetSqlCmd(SearchCondition sc);

        string GetName();
    }
}