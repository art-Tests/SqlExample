using SqlExample.Services.SqlHelper;

namespace SqlExample.Services.Factory
{
    internal class OrderFactory
    {
        public static OrderService GetService()
        {
            return new OrderService();
        }

        public static ISqlHelper GetSqlHelper(int type)
        {
            switch (type)
            {
                case 1: return new OrderSqlHelper();
                case 2: return new OrderSqlHelper2();
                default: return new OrderSqlHelper();
            }
        }
    }
}