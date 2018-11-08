# Solution 1 : OrderSqlHelper.cs

![](./data/sol1.png)

1. 先將完整的 SQL 寫出來，在條件式前方加上註解字串
1. 透過 model binding 取得的搜尋物件 dto，逐項判斷，若需參照該條件則透過 replace 語法將該部分註解清除

## 好處

1. 修改、擴充比較不會動到原有的程式碼
1. 可以將 SQL 從程式碼中複製出來直接貼到 SSMS 測試

## 缺點

1. 類別會整個大爆炸，對於路徑規劃要稍微考量一下
1. 關於 Helper、Service 還有 Factory 的實作，應該可以再優化，現在這樣感覺其實也不是很正規

## Memo

```sql
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
```
