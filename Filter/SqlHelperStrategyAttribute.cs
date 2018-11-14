using System;

namespace SqlExample.Filter
{
    internal class SqlHelperStrategyAttribute : Attribute
    {
        internal Type HelperType { get; }

        public SqlHelperStrategyAttribute(Type helperType)
        {
            HelperType = helperType;
        }
    }
}