# Solution 2 : OrderSqlHelper2.cs

![](./data/sol2.png)

1. 先將完整的 SQL 寫出來
1. 篩選條件的語法另外需加上表單傳送過來的預設值的判斷式，並透過邏輯語法處理

## 好處

1. 直接調整 SQL，無須另外撰寫依據條件來組 SQL 的類別
1. 可以將 SQL 從程式碼中複製出來直接貼到 SSMS 測試

## 缺點

1. 我個人是非常難以理解為甚麼 Where 條件要這樣寫...(感覺像是理則學的範疇)
1. 若透過 model binding，則 SQL 語法要增加的預設值的判別，注意是要抓 dto binding 的值

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
   and ((@employeeId = 0) or (t.EmployeeID = @employeeId))
   and ((isnull(@shipCity,'')='') or (t.ShipCity = @shipCity))
   and ((isnull(@orderDateStart,'')='') or (t.OrderDate >= @orderDateStart))
   and ((isnull(@orderDateEnd,'')='') or (t.OrderDate <= @orderDateEnd))
```
