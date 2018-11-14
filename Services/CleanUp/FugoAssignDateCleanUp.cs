using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class FugoAssignDateCleanUp : ICleanUpSql
    {
        private readonly ISearchCondition _sc;

        public FugoAssignDateCleanUp(ISearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            var start = _sc.GetValueByFieldName("AssignDateStart");
            var end = _sc.GetValueByFieldName("AssignDateEnd");

            return !string.IsNullOrEmpty(start)
                   && !string.IsNullOrEmpty(end)
                ? sqlCmd.Replace("--[@assignDateStart]--", string.Empty)
                    .Replace("--[@assignDateEnd]--", string.Empty)
                    .Replace("@AssignDateStart", start)
                    .Replace("@AssignDateEnd", end)
                : sqlCmd;
        }
    }
}