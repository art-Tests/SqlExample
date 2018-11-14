using SqlExample.Models;

namespace SqlExample.Services.SqlHelper
{
    public abstract class BaseSqlHelper : ISqlHelper
    {
        public abstract string GetSqlCmd(ISearchCondition sc);
        public string GetName() => GetType().Name;
    }
}