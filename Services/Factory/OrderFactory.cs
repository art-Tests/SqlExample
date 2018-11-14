using System;
using SqlExample.Enum;
using SqlExample.Models;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Services.Factory
{
    internal class OrderFactory
    {
        public static OrderService GetService()
        {
            return new OrderService();
        }

        public static BaseSqlHelper GetSqlHelper(OrderHelperType type)
        {
            var instanceType = StrategyHelper.GetStrategyType(type);
            var strategy = (BaseSqlHelper)(Activator.CreateInstance(instanceType));
            return strategy;
        }
    }
}