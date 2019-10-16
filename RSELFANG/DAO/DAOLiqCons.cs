using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOLiqCons
    {
        public List<TOLiqCons> GetLiqCons(int emp_codi, int cot_cont)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("    SELECT EMP_CODI,                ");
            sql.Append("    COT_CONT,                       ");
            sql.Append("    LIQ_CONS,                       ");
            sql.Append("    LIQ_CODI,                       ");
            sql.Append("    LIQ_NOMB,                       ");
            sql.Append("    LIQ_VALO,                       ");
            sql.Append("    LIQ_BASE,                       ");
            sql.Append("    TIM_CODI,                       ");
            sql.Append("    LIQ_SIGN,                       ");
            sql.Append("    AUD_ESTA,                       ");
            sql.Append("    AUD_USUA,                       ");
            sql.Append("    AUD_UFAC,                       ");
            sql.Append("    LIQ_CLAS,                       ");
            sql.Append("    LIQ_SECU                        ");
            sql.Append("    FROM EC_DVCOT                   ");
            sql.Append("    WHERE LIQ_CONS > 0              ");
            sql.Append("    AND EMP_CODI = @EMP_CODI        ");
            sql.Append("    AND COT_CONT = @COT_CONT        ");
            sql.Append("    ORDER BY  LIQ_CONS   ");
            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("COT_CONT", cot_cont));
            return new DbConnection().GetList<TOLiqCons>(sql.ToString(), sqParams);
        }
    }
}