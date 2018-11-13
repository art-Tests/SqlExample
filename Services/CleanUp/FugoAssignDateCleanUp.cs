using SqlExample.Models;

namespace SqlExample.Services.CleanUp
{
    internal class FugoAssignDateCleanUp : ICleanUpSql
    {
        private readonly FugoSearchCondition _sc;

        public FugoAssignDateCleanUp(FugoSearchCondition sc)
        {
            _sc = sc;
        }

        public string CleanUpSql(string sqlCmd)
        {
            return !string.IsNullOrEmpty(_sc.AssignDateStart)
                   && !string.IsNullOrEmpty(_sc.AssignDateEnd)
                ? sqlCmd.Replace("--[@assignDateStart]--", string.Empty)
                    .Replace("--[@assignDateEnd]--", string.Empty)
                    .Replace("@AssignDateStart", _sc.AssignDateStart)
                    .Replace("@AssignDateEnd", _sc.AssignDateEnd)
                : sqlCmd;
        }
    }
}