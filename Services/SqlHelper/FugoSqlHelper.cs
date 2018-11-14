using System.Collections.Generic;
using SqlExample.Models;
using SqlExample.Services.CleanUp;

namespace SqlExample.Services.SqlHelper
{
    public class FugoSqlHelper : BaseSqlHelper
    {
        public override string GetSqlCmd(ISearchCondition sc)
        {
            var sqlCmd = @"
SELECT ""TBA_011"".""CUSTOMERID"", ""TBA_010"".""CAMPAIGNTAG"",
       sf_get_customername(""TBA_011"".""CUSTOMERID"") as customer,
       ""TBA_011"".""ASSIGNEDDATE"", ""TBA_011"".""AVAILABLEDATE"",
       ""TBA_011"".""LASTCONTACTDATE"", ""TBA_011"".""STATUS"",
       sf_get_username(""TBA_011"".""ASSIGNEDTO"") as assignedto,
       sf_get_username(""TBA_011"".""ASSIGNEDBY"") as assignedby,
       ""TBA_011"".""REMARK""
  FROM ""TBA_011"", ""TBA_010""
 WHERE (""TBA_011"".""CAMPAIGNLIST"" = ""TBA_010"".""CAMPAIGNLIST"")
   and ((""TBA_011"".""STATUS"" not in (1202, 1203)))  -- 1202:不接受外呼名單 / 1203:名單錯誤

   --[@customerId]--     and TBA_011.CustomerId = @CustomerId
   --[@assignDateStart]-- and TBA_011.ASSIGNEDDATE >= to_date('@AssignDateStart','yyyy/mm/dd')
   --[@assignDateEnd]--   and TBA_011.ASSIGNEDDATE <= to_date('@AssignDateEnd','yyyy/mm/dd')

 ORDER BY ""TBA_011"".""CUSTOMERID"" ASC, ""TBA_011"".""ORGCALLINGLIST"" ASC
";

            foreach (var condition in GetConditionList(sc))
            {
                sqlCmd = condition.CleanUpSql(sqlCmd);
            }
            return sqlCmd;
        }

        private IEnumerable<ICleanUpSql> GetConditionList(ISearchCondition sc)
        {
            yield return new FugoCustomerIdCleanUp(sc);
            yield return new FugoAssignDateCleanUp(sc);
        }
    }
}