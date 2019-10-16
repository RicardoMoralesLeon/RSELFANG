using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOSoConve
    {
        public TOSoConve getSoConve(int cot_cont,int emp_codi)
        {
            StringBuilder sql = new StringBuilder();                       
            sql.Append(" SELECT * FROM SO_CONVE WHERE CON_CONT= @COT_CONT AND EMP_CODI=@EMP_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("COT_CONT", cot_cont));          
            return new DbConnection().Get<TOSoConve>(sql.ToString(), sqlparams);




        }
    }
}