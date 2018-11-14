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

## 透過反射及策略模式取代工廠類別內的判斷式

重構原先的程式碼，加入 Base 類別

1. 建立 Enum，並在 Attribute 掛上對應的類別

   ```csharp
       public enum OrderHelperType
       {
           [SqlHelperStrategy(typeof(OrderSqlHelper))]
           OrderSqlHelper = 1,

           [SqlHelperStrategy(typeof(OrderSqlHelper2))]
           OrderSqlHelper2 = 2
       }
   ```

1. Attribute 建構是將類別注入後，設定到公開唯讀屬性

   ```csharp
       internal class SqlHelperStrategyAttribute : Attribute
       {
           internal Type HelperType { get; }

           public SqlHelperStrategyAttribute(Type helperType)
           {
               HelperType = helperType;
           }
       }
   ```

1. 新建 Helper 取得實際的實體
   ```csharp
   internal class StrategyHelper
       {
           public static Type GetStrategyType<T>(T helperType)
           {
               FieldInfo data = typeof(T).GetField(helperType.ToString());
               Attribute attribute = Attribute.GetCustomAttribute(data, typeof(SqlHelperStrategyAttribute));
               var valueattribute = (SqlHelperStrategyAttribute)attribute;
               return valueattribute.HelperType;
           }
       }
   ```
1. Factory 類別改寫
   ```csharp
   internal class FugoFactory
       {
           public static BaseSqlHelper GetSqlHelper(FugoHelperType type)
           {
               var instanceType = StrategyHelper.GetStrategyType(type);
               var strategy = (BaseSqlHelper)(Activator.CreateInstance(instanceType));
               return strategy;
           }
       }
   ```

## 初探 webpack

為了以後 Vue.js 的單檔組件化等自動化工作，先行嘗試 webpack，參考官方文件進行

```
npm init -y
npm install webpack webpack-cli --save-dev
```
