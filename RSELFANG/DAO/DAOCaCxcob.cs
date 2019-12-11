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

        public List<TOXbAuliq> GetAuliquidacion(short emp_codi, long cli_codi)
        {
            OException exception = new OException();
            try
            {
                StringBuilder sql = new StringBuilder();

                sql.Append("SELECT RCX.ITE_CTSE,    CXC.EMP_CODI,                            ");
                sql.Append("ITE.ITE_CODI,                                       ");
                sql.Append("ITE.ITE_NOMB CTS_NOMB,                              ");
                sql.Append("RCX.RCX_VIGE,                                       ");
                sql.Append("TOPE.TOP_CODI,                                      ");
                sql.Append("TOPE.TOP_NOMB,                                      ");
                sql.Append("CXC.CXC_DESC,                                       ");
                sql.Append("CXC.CXC_TOTA,                                       ");
                sql.Append("CXC.CXC_SALD,                                       ");            
                sql.Append("CXC.CXC_CONT,                                       ");
                sql.Append("CXC.CXC_FEVE,                                         ");
                sql.Append("CXC.DCL_CODD,                                       ");
                sql.Append("CXC.CXC_FUPA                                       ");
                sql.Append("FROM   CA_CXCOB CXC                                 ");
                sql.Append("INNER JOIN CA_RCXCV RCX                             ");
                sql.Append("ON CXC.EMP_CODI = RCX.EMP_CODI                      ");
                sql.Append("AND CXC.CXC_CONT = RCX.CXC_CONT                     ");
                sql.Append("INNER JOIN GN_TOPER TOPE                            ");
                sql.Append("ON CXC.EMP_CODI = TOPE.EMP_CODI                     ");
                sql.Append("AND CXC.TOP_CODI = TOPE.TOP_CODI                    ");
                sql.Append("INNER JOIN GN_ITEMS ITE                             ");
                sql.Append("ON RCX.ITE_CTSE = ITE.ITE_CONT                      ");
                sql.Append("WHERE CXC.EMP_CODI = @EMP_CODI                            ");
                sql.Append("AND CXC.CLI_CODI = @CLI_CODI                        ");
                sql.Append("AND CXC.TOP_CODI = (SELECT PCE.TOP_COCO             ");
                sql.Append("                FROM   XB_PCECA PCE                 ");
                sql.Append("                WHERE PCE.EMP_CODI = @EMP_CODI)     ");
                //sql.Append("AND CXC.CXC_SALD > 0                                ");
                sql.Append("UNION                                               ");
                sql.Append("SELECT                                              ");
                sql.Append("CPC.ITE_CTSE,  CXC.EMP_CODI,                                         ");
                sql.Append("ITE.ITE_CODI,                                       ");
                sql.Append("ITE.ITE_NOMB CTS_NOMB,                              ");
                sql.Append("CPC.RVM_VIGE,                                       ");
                sql.Append("TOPE.TOP_CODI,                                      ");
                sql.Append("TOPE.TOP_NOMB,                                      ");
                sql.Append("CXC.CXC_DESC,                                       ");
                sql.Append("CXC.CXC_TOTA,                                       ");
                sql.Append("CXC.CXC_SALD,                                       ");            
                sql.Append("CXC.CXC_CONT,                                       ");
                sql.Append("CXC.CXC_FEVE,                                       ");
                sql.Append("CXC.DCL_CODD,                                        ");
                sql.Append("CXC.CXC_FUPA                                       ");
                sql.Append("FROM   CA_CXCOB CXC                                 ");
                sql.Append("INNER JOIN CA_RVMSA CPC                             ");
                sql.Append("ON CXC.EMP_CODI = CPC.EMP_CODI                      ");
                sql.Append("AND CXC.CXC_CONT = CPC.CXC_CONT                     ");
                sql.Append("INNER JOIN GN_TOPER TOPE                            ");
                sql.Append("ON CXC.EMP_CODI = TOPE.EMP_CODI                     ");
                sql.Append("AND CXC.TOP_CODI = TOPE.TOP_CODI                    ");
                sql.Append("INNER JOIN GN_ITEMS ITE                             ");
                sql.Append("ON CPC.ITE_CTSE = ITE.ITE_CONT                      ");
                sql.Append("WHERE CXC.EMP_CODI = @EMP_CODI                      ");
                sql.Append("AND CXC.CLI_CODI = @CLI_CODI                        ");
                sql.Append("AND CXC.TOP_CODI = (SELECT PCE.TOP_CORE             ");
                sql.Append("                FROM   XB_PCECA PCE                 ");
                sql.Append("                WHERE PCE.EMP_CODI = @EMP_CODI)     ");
                //sql.Append("AND CXC.CXC_SALD > 0                                ");


                List<SQLParams> sQLParams = new List<SQLParams>();
                sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sQLParams.Add(new SQLParams("CLI_CODI", cli_codi));
                return new DbConnection().GetList<TOXbAuliq>(sql.ToString(), sQLParams);
            }
            catch (Exception ex)
            {

                exception.Throw(this.GetType().Name, "GetAuliquidacion", ex);
                return null;
            }

        }


        public int? AnularCaCxcob(int emp_codi, int cxc_cont)
        {
            try
            {
                List<SQLParams> sqlPrms = new List<SQLParams>();
                sqlPrms.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlPrms.Add(new SQLParams("CXC_CONT", cxc_cont));
                string sql = "UPDATE CA_CXCOB SET CXC_ESTA = 'N' WHERE EMP_CODI = @EMP_CODI AND CXC_CONT = @CXC_CONT";
                return new DbConnection().Update(sql.ToString(), sqlPrms);
            }
            catch (Exception ex)
            {
                SevenFramework.Exceptions.ExceptionManager.Throw(this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return null;
            }
        }
    }
}