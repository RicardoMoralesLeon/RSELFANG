using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOWfRflup
    {

        public DataTable GetInfoFlujo(string pro_codi, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT WF_RFLUP.AUD_ESTA,                               ");
            sql.Append("  WF_RFLUP.AUD_USUA,                                      ");
            sql.Append("  WF_RFLUP.AUD_UFAC,                                      ");
            sql.Append("  WF_RFLUP.EMP_CODI,                                      ");
            sql.Append("  WF_RFLUP.FLU_CONT,                                      ");
            sql.Append("  WF_RFLUP.PRO_CODI,                                      ");
            sql.Append("  WF_RFLUP.RFL_ETSE,                                      ");
            sql.Append("  WF_RFLUP.FRM_CODI,                                      ");
            sql.Append("  WF_FLUJO.FLU_NOMB,                                      ");
            sql.Append("  GN_PROGR.PRO_NOMB,                                      ");
            sql.Append("  WF_FRMAS.FRM_NOMB                                       ");
            sql.Append("  FROM   WF_RFLUP,                                        ");
            sql.Append("  WF_FLUJO,                                               ");
            sql.Append("  GN_PROGR,                                               ");
            sql.Append("  WF_FRMAS                                                ");
            sql.Append("  WHERE  WF_RFLUP.EMP_CODI = WF_FLUJO.EMP_CODI            ");
            sql.Append("  AND WF_RFLUP.FLU_CONT = WF_FLUJO.FLU_CONT               ");
            sql.Append("  AND WF_RFLUP.PRO_CODI = GN_PROGR.PRO_CODI               ");
            sql.Append("  AND WF_RFLUP.FRM_CODI = WF_FRMAS.FRM_CODI               ");
            sql.Append("  AND WF_RFLUP.PRO_CODI =  @PRO_CODI                      ");
            sql.Append("  AND WF_RFLUP.EMP_CODI = @EMP_CODI                             ");

            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("PRO_CODI", pro_codi));



            var result = new DbConnection().GetDataSet(sql.ToString(), sQLParams);
            if (result.Tables.Count > 0)
            {
                return result.Tables[0];
            }
            else
            {
                return null;
            }
        }

    }
}