using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOSoDscfp
    {

        public List<TOSoDscfp> getsodscfp(string soc_codi, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            var db = new DbConnection();
            if (db._provider == "System.Data.SqlClient")
            {
                sql.Append("SELECT SO_DSCFP.DSC_PERI,                                       ");
                sql.Append("SO_DSCFP.DSC_PERF,                                              ");
                sql.Append("SO_SBENE.SBE_NOMB + ' ' + SO_SBENE.SBE_APEL 'SBE_NOMB',         ");
                sql.Append("IN_PRODU.PRO_CODI,                                              ");
                sql.Append("IN_PRODU.PRO_NOMB,                                              ");
                sql.Append("SO_CFACT.CFA_VALO 'PRO_VALO',                                   ");
                sql.Append("CASE(                                                           ");
                sql.Append("SELECT COUNT(*)                                                 ");
                sql.Append("FROM   SO_DTACR                                                 ");
                sql.Append("INNER JOIN SO_TACRE                                             ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_DTACR.EMP_CODI                       ");
                sql.Append("AND SO_TACRE.SOC_CONT = SO_DTACR.SOC_CONT                       ");
                sql.Append("INNER JOIN SO_SOCIO                                             ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_SOCIO.EMP_CODI                       ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_TACRE.SOC_CONT                       ");
                sql.Append("WHERE  PRO_CONT = SO_DSCFP.PRO_CONT                             ");
                sql.Append("AND SO_TACRE.EMP_CODI = @EMP_CODI                               ");
                sql.Append("AND SO_SOCIO.SOC_CODI = @SOC_CODI                               ");
                sql.Append("AND SO_DTACR.SBE_CONT = 1                                       ");
                sql.Append(")                                                               ");
                sql.Append("WHEN 0 THEN 'EFECTIVO'                                          ");
                sql.Append("ELSE(                                                           ");
                sql.Append("SELECT TOP(1) SO_TACRE.TAC_TITA + '-' + SO_TACRE.TAC_NUTA       ");
                sql.Append("FROM   SO_DTACR                                                 ");
                sql.Append("INNER JOIN SO_TACRE                                             ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_DTACR.EMP_CODI                       ");
                sql.Append("AND SO_TACRE.SOC_CONT = SO_DTACR.SOC_CONT                       ");
                sql.Append("INNER JOIN SO_SOCIO                                             ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_SOCIO.EMP_CODI                       ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_TACRE.SOC_CONT                       ");
                sql.Append("WHERE  PRO_CONT = SO_DSCFP.PRO_CONT                             ");
                sql.Append("AND SO_TACRE.EMP_CODI = @EMP_CODI                               ");
                sql.Append("AND SO_SOCIO.SOC_CODI = @SOC_CODI                               ");
                sql.Append("AND SO_DTACR.SBE_CONT = 1                                       ");
                sql.Append(")                                                               ");
                sql.Append("END AS 'PRO_FPAG'                                                ");
                sql.Append("FROM SO_DSCFP                                                   ");
                sql.Append("INNER JOIN IN_PRODU                                             ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = IN_PRODU.EMP_CODI                       ");
                sql.Append("AND SO_DSCFP.PRO_CONT = IN_PRODU.PRO_CONT                       ");
                sql.Append("INNER JOIN SO_SOCIO                                             ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = SO_SOCIO.EMP_CODI                       ");
                sql.Append("AND SO_DSCFP.SOC_CONT = SO_SOCIO.SOC_CONT                       ");
                sql.Append("INNER JOIN SO_SBENE                                             ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = SO_SBENE.EMP_CODI                       ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_SBENE.SOC_CONT                       ");
                sql.Append("INNER JOIN SO_CFACT                                             ");
                sql.Append("ON  SO_CFACT.EMP_CODI = SO_DSCFP.EMP_CODI                       ");
                sql.Append("AND SO_CFACT.PRO_CONT = SO_DSCFP.PRO_CONT                       ");
                sql.Append("WHERE SO_SOCIO.SOC_CODI = @SOC_CODI                             ");
                sql.Append("AND SO_DSCFP.EMP_CODI = @EMP_CODI                               ");
                sql.Append("AND SBE_CONT = 1                                                ");
            }
            else
            {
                sql.Append("SELECT SO_DSCFP.DSC_PERI,                   ");
                sql.Append("SO_DSCFP.DSC_PERF,                                          ");
                sql.Append("SO_SBENE.SBE_NOMB || ' ' || SO_SBENE.SBE_APEL SBE_NOMB,     ");
                sql.Append("IN_PRODU.PRO_CODI,                                          ");
                sql.Append("IN_PRODU.PRO_NOMB,                                          ");
                sql.Append("SO_CFACT.CFA_VALO PRO_VALO,                                 ");
                sql.Append("CASE                                                        ");
                sql.Append("TO_CHAR((SELECT COUNT(*)                                    ");
                sql.Append("FROM   SO_DTACR                                             ");
                sql.Append("INNER JOIN SO_TACRE                                         ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_DTACR.EMP_CODI                   ");
                sql.Append("AND SO_TACRE.SOC_CONT = SO_DTACR.SOC_CONT                   ");
                sql.Append("INNER JOIN SO_SOCIO                                         ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_SOCIO.EMP_CODI                   ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_TACRE.SOC_CONT                   ");
                sql.Append("WHERE  PRO_CONT = SO_DSCFP.PRO_CONT                         ");
                sql.Append("AND SO_TACRE.EMP_CODI = @EMP_CODI                           ");
                sql.Append("AND SO_SOCIO.SOC_CODI = @SOC_CODI                           ");
                sql.Append("AND SO_DTACR.SBE_CONT = 1))                                 ");
                sql.Append("WHEN '0' THEN 'EFECTIVO'                                    ");
                sql.Append("ELSE(                                                       ");
                sql.Append("SELECT  SO_TACRE.TAC_TITA || '-' || SO_TACRE.TAC_NUTA       ");
                sql.Append("FROM   SO_DTACR                                             ");
                sql.Append("INNER JOIN SO_TACRE                                         ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_DTACR.EMP_CODI                   ");
                sql.Append("AND SO_TACRE.SOC_CONT = SO_DTACR.SOC_CONT                   ");
                sql.Append("INNER JOIN SO_SOCIO                                         ");
                sql.Append("ON  SO_TACRE.EMP_CODI = SO_SOCIO.EMP_CODI                   ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_TACRE.SOC_CONT                   ");
                sql.Append("WHERE  PRO_CONT = SO_DSCFP.PRO_CONT                         ");
                sql.Append("AND SO_TACRE.EMP_CODI = @EMP_CODI                           ");
                sql.Append("AND SO_SOCIO.SOC_CODI = @SOC_CODI                           ");
                sql.Append("AND SO_DTACR.SBE_CONT = 1 AND ROWNUM = 1                    ");
                sql.Append(")                                                           ");
                sql.Append("END PRO_FPAG                                                ");
                sql.Append("FROM SO_DSCFP                                               ");
                sql.Append("INNER JOIN IN_PRODU                                         ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = IN_PRODU.EMP_CODI                   ");
                sql.Append("AND SO_DSCFP.PRO_CONT = IN_PRODU.PRO_CONT                   ");
                sql.Append("INNER JOIN SO_SOCIO                                         ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = SO_SOCIO.EMP_CODI                   ");
                sql.Append("AND SO_DSCFP.SOC_CONT = SO_SOCIO.SOC_CONT                   ");
                sql.Append("INNER JOIN SO_SBENE                                         ");
                sql.Append("ON  SO_DSCFP.EMP_CODI = SO_SBENE.EMP_CODI                   ");
                sql.Append("AND SO_SOCIO.SOC_CONT = SO_SBENE.SOC_CONT                   ");
                sql.Append("INNER JOIN SO_CFACT                                         ");
                sql.Append("ON  SO_CFACT.EMP_CODI = SO_DSCFP.EMP_CODI                   ");
                sql.Append("AND SO_CFACT.PRO_CONT = SO_DSCFP.PRO_CONT                   ");
                sql.Append("WHERE SO_SOCIO.SOC_CODI = @SOC_CODI                         ");
                sql.Append("AND SO_DSCFP.EMP_CODI = @EMP_CODI                           ");
                sql.Append("AND SBE_CONT = 1                                            ");
            }
            List<SQLParams> sqlParam = new List<SQLParams>();
            sqlParam.Add(new SQLParams("emp_codi", emp_codi));
            sqlParam.Add(new SQLParams("soc_codi", soc_codi));
            return new DbConnection().GetList<TOSoDscfp>(sql.ToString(), sqlParam);
        }
    }
}