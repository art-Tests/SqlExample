using SqlExample.Models;

namespace SqlExample.Services.SqlHelper
{
    public interface ISqlHelper
    {
        string GetSqlCmd(SearchCondition sc);

        string GetName();
    }
}