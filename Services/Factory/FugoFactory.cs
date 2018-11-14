using System;
using SqlExample.Enum;
using SqlExample.Services.SqlHelper;

namespace SqlExample.Services.Factory
{
    internal class FugoFactory
    {
        public static BaseSqlHelper GetSqlHelper(FugoHelperType type)
        {
            var instanceType = StrategyHelper.GetStrategyType(type);
            var strategy = (BaseSqlHelper)(Activator.CreateInstance(instanceType));
            return strategy;
        }
    }
}