using SqlExample.Services.SqlHelper;

namespace SqlExample.Services.Factory
{
    internal class FugoFactory
    {
        public static ISqlHelper GetSqlHelper(string type)
        {
            switch (type)
            {
                case "FugoSqlHelper": return new FugoSqlHelper();
                // case "FugoSqlHelper2": return new FugoSqlHelper2();
                default: return new FugoSqlHelper();
            }
        }
    }
}