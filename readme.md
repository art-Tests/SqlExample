# SQL 字串處理的測試

表單送出到後端，後端通常都會組 SQL 再去撈資料，在本專案中先將完整的搜尋條件都寫上，再透過判斷前端傳過來的條件，決定 SQL 語法的 Where 條件是否啟用

作法參考[這篇](http://tomex.dabutek.com/2014/08/sql.html)文章
資料庫：[Script](./data/Northwind_Crete_sql_script.txt)

## Connection String

```
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=northwind;Persist Security Info=True;User ID=web;Password=web
```

## Memo

搜尋條件的 Dto 物件，有建立屬性用來直接判斷是否需要處理該項搜尋條件

```csharp
public class SearchCondition
{
    public bool IsSearchShipCity => !string.IsNullOrEmpty(ShipCity);
    public bool IsSearchEmployeeId => EmployeeId > 0;
    public bool IsSearchOrderDate => OrderDateStart != null && OrderDateEnd != null;

    public int EmployeeId { get; set; }
    public string ShipCity { get; set; }
    public DateTime? OrderDateStart { get; set; }
    public DateTime? OrderDateEnd { get; set; }
}
```

透過 Service 取得資料，而在 Service 之內則是透過 Helper 依據條件取得 Sql Script

未來若是條件有增加，需要調整的程式

1. 實作新的類別繼承 ICleanUpSql 介面
1. Helper 要去處理預設的 SQL Script，並且將上個步驟的類別加入到 Condition List 之內

## 備註

感覺有好處也有壞處

### 好處

1. 修改、擴充比較不會動到原有的程式碼
1. 可以將 SQL 從程式碼中複製出來直接貼到 SSMS 測試

### 缺點

1. 類別會整個大爆炸，對於路徑規劃要稍微考量一下
1. 關於 Helper、Service 還有 Factory 的實作，應該可以再優化，現在這樣感覺其實也不是很正規
