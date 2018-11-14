using System;

namespace SqlExample.Models
{
    public abstract class BaseSearchCondition : ISearchCondition
    {
        public string GetValueByFieldName(string fieldName)
        {
            var ts = GetType();
            var o = ts.GetProperty(fieldName).GetValue(this, null);
            var value = Convert.ToString(o);
            return string.IsNullOrEmpty(value) ? null : value;
        }
    }
}