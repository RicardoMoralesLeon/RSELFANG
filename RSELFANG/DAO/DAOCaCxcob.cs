using Ophelia;
using RSELFANG.Models;
using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOCaCxcob
    {
        public List<ToCaCxcob> getcacxcob(int emp_codi, string cli_coda, DateTime cxc_fech)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT SUM(CXC_SALD) CXC_SALD,                                           ");
            sql.Append("SUM(CXC_TOTA) CXC_TOTA,                                                  ");
            sql.Append("CA_CXCOB.TIP_CODI,                                              ");
            sql.Append("IN_TIPRO.TIP_NOMB                                               ");
            sql.Append("FROM   CA_CXCOB                                                 ");
            sql.Append("INNER JOIN FA_CLIEN                                             ");
            sql.Append("ON CA_CXCOB.EMP_CODI = FA_CLIEN.EMP_CODI                        ");
            sql.Append("AND CA_CXCOB.CLI_CODI = FA_CLIEN.CLI_CODI                       ");
            sql.Append("INNER JOIN IN_TIPRO                                             ");
            sql.Append("ON  IN_TIPRO.EMP_CODI = CA_CXCOB.EMP_CODI                       ");
            sql.Append("AND IN_TIPRO.TIP_CODI = CA_CXCOB.TIP_CODI                       ");
            sql.Append("WHERE FA_CLIEN.CLI_CODA = @cli_coda                             ");
            sql.Append("AND CA_CXCOB.CXC_NECH <= @cxc_nech                              ");
            sql.Append("AND CA_CXCOB.CXC_SALD > 0   AND CA_CXCOB.EMP_CODI= @EMP_CODI    ");
            sql.Append(" AND CXC_ESTA <>'N'  ");
            sql.Append("GROUP BY                                                        ");
            sql.Append("CA_CXCOB.TIP_CODI,                                              ");
            sql.Append("IN_TIPRO.TIP_NOMB                                               ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("emp_codi", emp_codi));
            sqlparams.Add(new SQLParams("cli_coda", cli_coda));
            sqlparams.Add(new SQLParams("cxc_nech", cxc_fech.ToString("yyyyMMdd")));
            return new DbConnection().GetList<ToCaCxcob>(sql.ToString(), sqlparams);




        }

        public List<Xb_Auliq> GetAuliquidacion(short emp_codi, string cli_coda)
        {
            OException exception = new OException();
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("    SELECT DDI.ITE_CTSE, ITE.ITE_NOMB, DDI.DDI_VIGE, TOPE.TOP_CODI, TOPE.TOP_NOMB, CXC.CXC_DESC, CXC.CXC_TOTA,CXC.CXC_SALD  ");
                sql.Append("    FROM   CA_CXCOB CXC                                                                                                     ");
                sql.Append("    INNER JOIN FA_DDINA DDI                                                                                                 ");
                sql.Append("    ON CXC.EMP_CODI = DDI.EMP_CODI                                                                                          ");
                sql.Append("    AND CXC.CLI_CODI = DDI.CLI_CODI                                                                                         ");
                sql.Append("    AND CXC.CXC_ANOP = DDI.DDI_VIGE                                                                                         ");
                sql.Append("    INNER JOIN GN_TOPER TOPE                                                                                                ");
                sql.Append("    ON CXC.EMP_CODI = TOPE.EMP_CODI                                                                                         ");
                sql.Append("    AND CXC.TOP_CODI = TOPE.TOP_CODI                                                                                        ");
                sql.Append("    INNER JOIN GN_ITEMS ITE                                                                                                 ");
                sql.Append("    ON DDI.ITE_CTSE = ITE.ITE_CONT                                                                                          ");
                sql.Append("                                                                                                                            ");
                sql.Append("                                                                                                                            ");
                sql.Append("    --AND CXC.DCL_CODD = DDI.DCL_CODD                                                                                       ");
                sql.Append("    WHERE CXC.EMP_CODI =                                                                                                 ");
                sql.Append("    AND CXC.CLI_CODI = 88284896                                                                                             ");
                sql.Append("    AND CXC.TOP_CODI = (                                                                                                    ");
                sql.Append("    SELECT PCE.TOP_COCO                                                                                                     ");
                sql.Append("    FROM   XB_PCECA PCE                                                                                                     ");
                sql.Append("    WHERE PCE.EMP_CODI = 102                                                                                                ");
                sql.Append("    )                                                                                                                       ");
                sql.Append("    AND CXC.CXC_SALD > 0                                                                                                    ");
                List<SQLParams> sQLParams = new List<SQLParams>();
                sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sQLParams.Add(new SQLParams("CLI_CODA", cli_coda));
                return new DbConnection().GetList<Xb_Auliq>(sql.ToString(), sQLParams);
            }
            catch (Exception ex)
            {

                exception.Throw(this.GetType().Name, "GetAuliquidacion", ex);
                return null;
            }

        }
    }
}