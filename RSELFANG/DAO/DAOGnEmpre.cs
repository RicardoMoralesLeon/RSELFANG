using DigitalWare.Apps.Utilities.Gn.TO;
using SevenFramework.DataBase;
using SevenFramework.DataBase.Utils;
using System.Collections.Generic;

namespace RSELFANG.DAO
{
    public class DAOGnEmpre
    {
        public Gn_Empre GetGnEmpre(int emp_codi)
        {
            List<SQLParams> sQLParams = new List<SQLParams>()
            {
                new SQLParams("EMP_CODI",emp_codi)                
            };
            string sql = DBHelper.SelectQueryString<Gn_Empre>(sQLParams);
            return new DbConnection().Get<Gn_Empre>(sql, sQLParams);
        }
    }
}