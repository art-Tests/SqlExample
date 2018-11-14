using SqlExample.Models;

namespace SqlExample.Services.SqlHelper
{
    internal class OrderSqlHelper2 : ISqlHelper
    {
        public string GetSqlCmd(ISearchCondition sc)
        {
            return @"
--declare @employeeId nvarchar(10) = '3';
--declare @orderDateStart datetime = '1996-07-05';
--declare @orderDateEnd datetime = '1996-07-10';
--declare @shipCity nvarchar(15) = 'Lyon';

SELECT
    [OrderID],[CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia]
    ,[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]
  FROM [dbo].[Orders] (nolock) as t
 Where 1=1
   and ((isnull(@employeeId,'')='') or (t.EmployeeID = @employeeId))
   and ((isnull(@shipCity,'')='') or (t.ShipCity = @shipCity))
   and ((isnull(@orderDateStart,'')='') or (t.OrderDate >= @orderDateStart))
   and ((isnull(@orderDateEnd,'')='') or (t.OrderDate <= @orderDateEnd))
";
        }

        public string GetName() => "OrderSqlHelper2";
    }
}