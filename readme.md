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

設置 webpack 設定檔，因為採用 Vue，所以必備的套件也需要安裝，此處節錄 package.json 依賴套件

```javascript
  "devDependencies": {
    "babel-core": "^6.26.3",
    "babel-loader": "^7.1.5",
    "babel-preset-env": "^1.7.0",
    "css-loader": "^1.0.1",
    "vue-loader": "^15.4.2",
    "vue-template-compiler": "^2.5.17",
    "webpack": "^4.25.1",
    "webpack-cli": "^3.1.2"
  },
```

因為頁面有很多頁，所以進入點為多個，設定也要調整

```javascript
module.exports = {
  //... ...
  context: path.resolve(__dirname, "src"),
  entry: {
    Fugo: "./page/Fugo/app.js",
    Sample: "./page/Sample/app.js"
  },
  output: {
    filename: "[name].bundle.js",
    path: path.resolve(__dirname, "wwwroot/dist")
  }
  //... ...
};
```

在 html 內引用

```html
<script src="https://cdnjs.cloudflare.com/ajax/libs/vue/2.5.17/vue.js"></script>
<script src="~/dist/Sample.bundle.js"></script>
```

執行建置指令(設定指令於 npm script)

```
npm build:prod
npm build:dev
```
