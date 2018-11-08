# Solution 2 : OrderSqlHelper2.cs

![](./data/sol2.png)

1. 先將完整的 SQL 寫出來
1. 篩選條件的語法另外需加上表單傳送過來的預設值的判斷式，並透過邏輯語法處理

## 好處

1. 直接調整 SQL，無須另外撰寫依據條件來組 SQL 的類別
1. 可以將 SQL 從程式碼中複製出來直接貼到 SSMS 測試

## 缺點

1. 篩選條件一開始較難[理解](#explain)
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

## Explain

就以第一項篩選條件來解釋，假設目前系統資料庫內抓出來三筆資料，三筆的 employeeId 分別為 1,2,3

篩選條件共有兩個部分(表單預設值、篩選條件規則)

1. 第一個部分符合，則表示使用者未輸入該項條件，輸出該筆資料
1. 第二個部份符合，則表示使用者有輸入條件且符合，輸出該筆資料
1. 上述條件若都不符合，部輸出該筆資料
