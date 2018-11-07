namespace SqlExample.Services
{
    internal class OrderFactory
    {
        public static OrderService GetService()
        {
            return new OrderService();
        }

        public static OrderSqlHelper GetSqlHelper()
        {
            return new OrderSqlHelper();
        }
    }
}