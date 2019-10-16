using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOEcLisev
    {
        public List<TOEcLisev> GetEcLisev(int emp_codi, int eve_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("    SELECT EC_LISEV.AUD_ESTA,       ");
            sql.Append("    EC_LISEV.AUD_USUA,              ");
            sql.Append("    EC_LISEV.AUD_UFAC,              ");
            sql.Append("    EC_LISEV.EMP_CODI,              ");
            sql.Append("    EC_LISEV.EVE_CONT,              ");
            sql.Append("    EC_LISEV.DLI_CONT,              ");
            sql.Append("    EC_LISEV.DLI_IDIN,              ");
            sql.Append("    EC_LISEV.DLI_NOIN,              ");
            sql.Append("    EC_LISEV.DLI_APIN,              ");
            sql.Append("    EC_LISEV.DLI_NOCO,              ");
            sql.Append("    EC_LISEV.DLI_OBSE               ");
            sql.Append("    FROM   EC_LISEV                 ");
            sql.Append("    WHERE  EMP_CODI = @EMP_CODI     ");
            sql.Append("    AND EVE_CONT = @EVE_CONT        ");
            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("EVE_CONT", eve_cont));
            return new DbConnection().GetList<TOEcLisev>(sql.ToString(), sqParams);

        }
    }
}