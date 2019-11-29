using RSELFANG.Models;
using SevenFramework.DataBase;
using SevenFramework.DataBase.Utils;
using SevenFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnCtope
    {

        public TOGnCtope ConsultarGnCTope(short emp_codi, short top_codi)
        {
            try
            {
                List<SQLParams> sqlPrms = new List<SQLParams>()
                {
                    new SQLParams("EMP_CODI", emp_codi),
                    new SQLParams("TOP_CODI", top_codi)
                };
                string sql = DBHelper.SelectQueryString<TOGnCtope>(sqlPrms);
                return new DbConnection().Get<TOGnCtope>(sql.ToString(), sqlPrms);
            }
            catch (Exception ex)
            {
                ExceptionManager.Throw(this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
    }
}