# SQL 字串處理的測試

表單送出到後端，後端通常都會組 SQL 再去撈資料，在本專案中先將完整的搜尋條件都寫上，再透過判斷前端傳過來的條件，決定 SQL 語法的 Where 條件是否啟用

| #   | Solution                                                      | ref                                                     | Memo                   |
| --- | ------------------------------------------------------------- | ------------------------------------------------------- | ---------------------- |
| 1   | [OrderSqlHelper.cs](./Services/SqlHelper/OrderSqlHelper.cs)   | [Link](http://tomex.dabutek.com/2014/08/sql.html)       | [Memo](./data/sol1.md) |
| 2   | [OrderSqlHelper2.cs](./Services/SqlHelper/OrderSqlHelper2.cs) | [Link](https://dotblogs.com.tw/shadow/2011/06/16/28763) | [Memo](./data/sol2.md) |

目前看來式第二種方法比較好，維護應該會比較方便，但就是要多花一些時間理解

# Connection String

Test Database:[Script](./data/Northwind_Crete_sql_script.txt)

```
Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=northwind;Persist Security Info=True;User ID=web;Password=web
```
