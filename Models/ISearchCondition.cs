namespace SqlExample.Models
{
    public interface ISearchCondition
    {
        string GetValueByFieldName(string fieldName);
    }
}