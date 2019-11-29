using RSELFANG.Models;
using SevenFramework.DataBase;
using SevenFramework.DataBase.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnToper
    {
        public static ToGnToper GetGnToper(short emp_codi, int top_codi)
        {
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("TOP_CODI", top_codi));
            string sql = DBHelper.SelectQueryString<ToGnToper>(sQLParams);
            return new DbConnection().Get<ToGnToper>(sql, sQLParams);
        }

    }
}