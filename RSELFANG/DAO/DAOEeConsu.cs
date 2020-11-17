using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOEeConsu
    {
        public List<FaClien> GetFaClien(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append("  SELECT fc.EMP_CODI,                                  ");
            sql.Append("  fc.CLI_CODA,                                         ");
            sql.Append("  fd.ARB_CSUC,                                         ");
            sql.Append("  ga.ARB_NOMB,                                          ");
            sql.Append("  fc.TIP_CODI,                                         ");
            sql.Append("  gt.TIP_NOMB,                                         ");
            sql.Append("  fc.CLI_NOMB,                                         ");
            sql.Append("  fc.CLI_APEL,                                         ");
            sql.Append("  fd.DCL_NTEL,                                         ");
            sql.Append("  fd.DCL_MAIL,                                         ");
            sql.Append("  fd.DCL_DIRE,                                         ");
            sql.Append("  fd.PAI_CODI,                                         ");
            sql.Append("  fd.DEP_CODI,                                         ");
            sql.Append("  gd.REG_CODI,                                         ");
            sql.Append("  fd.MUN_CODI ,                                         ");
            sql.Append("  gi.TIP_ABRE  ,                                          ");
            sql.Append("  fc.CLI_NOCO  ,                                          ");
            sql.Append("  fc.CLI_CODI,                                            ");
            sql.Append("  gm.MUN_NOMB ,");
            sql.Append("  gd.DEP_NOMB ");
            sql.Append("  FROM   FA_CLIEN fc                                   ");
            sql.Append("  INNER JOIN FA_DCLIE fd                               ");
            sql.Append("       ON fc.EMP_CODI = fd.EMP_CODI                    ");
            sql.Append("       AND fc.CLI_CODI = FD.CLI_CODI                   ");
            sql.Append("  INNER JOIN GN_TIPDO gt                               ");
            sql.Append("       ON fc.TIP_CODI = gt.TIP_CODI                    ");
            sql.Append("  INNER JOIN GN_PAISE gp                               ");
            sql.Append("       ON fd.PAI_CODI = gp.PAI_CODI                    ");
            sql.Append("  INNER JOIN GN_DEPAR gd                               ");
            sql.Append("       ON fd.PAI_CODI = fd.PAI_CODI                    ");
            sql.Append("       AND fd.DEP_CODI = gd.DEP_CODI                   ");
            sql.Append("  INNER JOIN GN_MUNIC gm                               ");
            sql.Append("       ON fd.PAI_CODI = gm.PAI_CODI                    ");
            sql.Append("       AND fd.DEP_CODI = gm.DEP_CODI                   ");
            sql.Append("       AND FD.MUN_CODI = GM.MUN_CODI                   ");
            sql.Append("  INNER JOIN GN_ARBOL ga         ");
            sql.Append("  ON fd.ARB_SUCU = ga.ARB_CONT   ");
            sql.Append("  INNER JOIN GN_TIPDO gi ON fc.TIP_CODI = gi.TIP_CODI   ");
            sql.Append("  AND ga.EMP_CODI = fd.EMP_CODI  ");
            sql.Append("  AND ga.TAR_CODI = 2            ");
            sql.Append("  WHERE fd.EMP_CODI = @EMP_CODI                        ");            
            sql.Append("  AND fd.DCL_CODD = 1                                  ");

            List<SQLParams> sQLParams = new List<SQLParams>()
            {
                new SQLParams("EMP_CODI",emp_codi)
            };

            return new DbConnection().GetList<FaClien>(sql.ToString(), sQLParams);
        }

        public List<EeConsu> GetInfoEereles(int emp_codi, DateTime fini, DateTime ffin, int ite_cont, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqParams = new List<SQLParams>();            
            sql.Append(" SELECT DISTINCT REM_CONT, REM_FECH,ITE_CONT, ITE_CODI, ITE_NOMB, FA_CLIEN.CLI_CODA, FA_CLIEN.CLI_NOCO, EE_REMES.EMP_CODI ");
            sql.Append(" FROM EE_REMES ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = ITE_SERV ");
            sql.Append(" INNER JOIN FA_CLIEN ON FA_CLIEN.CLI_CODA = EE_REMES.CLI_CODA ");
            sql.Append(" AND FA_CLIEN.EMP_CODI = EE_REMES.EMP_CODI ");
            sql.Append(" WHERE EE_REMES.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND FA_CLIEN.CLI_ESTA = 'A' ");
            sql.Append(" AND CONVERT(DATE, EE_REMES.REM_FECH) >= @REM_FECI ");
            sql.Append(" AND CONVERT(DATE, EE_REMES.REM_FECH) <= @REM_FECF ");

            if (ite_cont != 0)
            {
                sql.Append(" AND ITE_CONT = @ITE_SERV ");
                sqParams.Add(new SQLParams("ITE_SERV", ite_cont));
            }

            if (!String.IsNullOrEmpty(cli_coda))
            {
                sql.Append(" AND FA_CLIEN.CLI_CODA = @CLI_CODA ");
                sqParams.Add(new SQLParams("CLI_CODA", cli_coda));
            }            

            sql.Append(" ORDER BY REM_CONT ");

            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("REM_FECI", fini));
            sqParams.Add(new SQLParams("REM_FECF", ffin));

            return new DbConnection().GetList<EeConsu>(sql.ToString(), sqParams);
        }
    }
}