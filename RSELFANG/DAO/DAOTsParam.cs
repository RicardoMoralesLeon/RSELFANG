using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOTsParam
    {
        public TOTsParam getTsParam(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT PAR_URSS FROM TS_PARAM WHERE EMP_CODI = @EMP_CODI ");           
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("emp_codi", emp_codi));           
            return new DbConnection().Get<TOTsParam>(sql.ToString(), sqlparams);
        }
    }
}