using System.Collections.Generic;
using SqlExample.Models;
using SqlExample.Services.CleanUp;

namespace SqlExample.Services.SqlHelper
{
    public class OrderSqlHelper : BaseSqlHelper
    {
        public override string GetSqlCmd(ISearchCondition sc)
        {
            var sqlCmd = @"
--declare @employeeId int = 3;
--declare @orderDateStart datetime = '1996-07-05';
--declare @orderDateEnd datetime = '1996-07-10';
--declare @shipCity nvarchar(15) = 'Lyon';

SELECT
    [OrderID],[CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia]
    ,[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]
  FROM [dbo].[Orders] (nolock) as t
 Where 1=1
   --[@employeeId]--     and t.EmployeeID = @employeeId
   --[@shipCity]--       and t.ShipCity = @shipCity
   --[@orderDateStart]-- and t.OrderDate >= @orderDateStart
   --[@orderDateEnd]--   and t.OrderDate <= @orderDateEnd
";

            foreach (var condition in GetConditionList(sc))
            {
                sqlCmd = condition.CleanUpSql(sqlCmd);
            }
            return sqlCmd;
        }

        private IEnumerable<ICleanUpSql> GetConditionList(ISearchCondition sc)
        {
            yield return new OrderShipCityCleanUp(sc);
            yield return new OrderEmployeeIdCleanUp(sc);
            yield return new OrderDateCleanUp(sc);
        }
    }
}