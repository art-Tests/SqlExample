using System.Collections.Generic;
using Dapper;
using SqlExample.Models;

namespace SqlExample.Services
{
    internal class OrderService
    {
        /// <summary>
        /// 用來在View顯示實際SQL用
        /// </summary>
        public string SqlCmd { get; set; }

        public IEnumerable<NorthWindOrder> QueryByCondition(OrderSqlHelper helper, SearchCondition sc)
        {
            using (var conn = ConnectionFactory.GetConnection())
            {
                SqlCmd = helper.GetSqlCmd(sc);
                return conn.Query<NorthWindOrder>(SqlCmd, sc);
            }
        }
    }
}