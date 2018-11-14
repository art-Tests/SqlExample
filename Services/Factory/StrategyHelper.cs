using System;
using System.Reflection;
using SqlExample.Filter;

namespace SqlExample.Services.Factory
{
    internal class StrategyHelper
    {
        public static Type GetStrategyType<T>(T helperType)
        {
            FieldInfo data = typeof(T).GetField(helperType.ToString());
            Attribute attribute = Attribute.GetCustomAttribute(data, typeof(SqlHelperStrategyAttribute));
            var valueattribute = (SqlHelperStrategyAttribute)attribute;
            return valueattribute.HelperType;
        }
    }
}