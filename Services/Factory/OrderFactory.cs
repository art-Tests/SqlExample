using SqlExample.Services.SqlHelper;

namespace SqlExample.Services.Factory
{
    internal class OrderFactory
    {
        public static OrderService GetService()
        {
            return new OrderService();
        }

        public static ISqlHelper GetSqlHelper(string type)
        {
            switch (type)
            {
                case "OrderSqlHelper": return new OrderSqlHelper();
                case "OrderSqlHelper2": return new OrderSqlHelper2();
                default: return new OrderSqlHelper();
            }
        }
    }
}