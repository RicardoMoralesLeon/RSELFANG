using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOArcacea
    {
        public bool GetInfoArResol(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT DISTINCT AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS, AR_APOVO.APO_CONT ");
            sql.Append("               FROM AR_RPILA INNER JOIN AR_APOVO ON AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append(" AND AR_RPILA.APO_CONT = AR_APOVO.APO_CONT, ");
            sql.Append("        AR_TIAPO ");
            sql.Append("  WHERE AR_RPILA.EMP_CODI = AR_TIAPO.EMP_CODI ");
            sql.Append("    AND AR_RPILA.TIA_CONT = AR_TIAPO.TIA_CONT ");
            sql.Append("    and AR_APOVO.EMP_CODI = @EMP_CODI AND AR_APOVO.APO_ESTD = 'D' ");
            sql.Append("    AND AR_APOVO.APO_FCRE IS NOT NULL  AND AR_TIAPO.TIA_REGM = 'O' ");
            sql.Append("    AND AR_APOVO.APO_CONT ");
            sql.Append("    IN( ");
            sql.Append("    SELECT DISTINCT APO_CONT ");
            sql.Append("    FROM AR_DRESO, AR_RESOL ");
            sql.Append("    WHERE AR_DRESO.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append("    AND AR_DRESO.APO_CONT = AR_APOVO.APO_CONT ");
            sql.Append("    AND AR_DRESO.EMP_CODI = AR_RESOL.EMP_CODI ");
            sql.Append("    AND AR_DRESO.RES_CONT = AR_RESOL.RES_CONT ");
            sql.Append("    AND AR_RESOL.RES_TIRE = 'D'");
            sql.Append("    AND AR_RESOL.RES_ESTA = 'A' ");
            sql.Append("  ) ");
            sql.Append("  AND AR_APOVO.APO_CODA = @TER_CODA");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));           
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true; 
        }

        public bool GetInfoAfiliado(string ter_coda, int emp_codi, string rpi_peri, string rpi_perf)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT DISTINCT AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS, AR_APOVO.APO_CONT ");
            sql.Append("      FROM AR_RPILA ");
            sql.Append("      INNER JOIN AR_APOVO ON AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append(" AND AR_RPILA.APO_CONT = AR_APOVO.APO_CONT, AR_TIAPO ");
            sql.Append("  WHERE AR_RPILA.EMP_CODI = AR_TIAPO.EMP_CODI ");
            sql.Append("    AND AR_RPILA.TIA_CONT = AR_TIAPO.TIA_CONT ");
            sql.Append("  AND AR_APOVO.EMP_CODI = @EMP_cODI AND AR_APOVO.APO_ESTD = 'A' ");
            sql.Append("  AND AR_TIAPO.TIA_REGM = 'O'  AND AR_APOVO.APO_CONT ");
            sql.Append("  IN(SELECT DISTINCT APO_CONT ");
            sql.Append("  FROM AR_DRESO, AR_RESOL ");
            sql.Append("  WHERE AR_DRESO.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append("  AND AR_DRESO.APO_CONT = AR_APOVO.APO_CONT ");
            sql.Append("  AND AR_DRESO.EMP_CODI = AR_RESOL.EMP_CODI ");
            sql.Append("  AND AR_DRESO.RES_CONT = AR_RESOL.RES_CONT ");
            sql.Append("  AND AR_RESOL.RES_TIRE = 'A' ");
            sql.Append("  AND AR_RESOL.RES_ESTA = 'A') ");
            sql.Append("  AND AR_RPILA.RPI_ESTC = 'C' ");
            sql.Append("  AND AR_RPILA.RPI_PERI = (SELECT MAX(RPI_PERI) ");
            sql.Append("  FROM AR_RPILA A ");
            sql.Append("  WHERE A.EMP_CODI = AR_RPILA.EMP_CODI ");
            sql.Append("  AND A.RPI_CONT = AR_RPILA.RPI_CONT ");
            sql.Append("  AND A.APO_CONT = AR_RPILA.APO_CONT) ");
            sql.Append("  AND AR_RPILA.RPI_PERI >= 202007 ");
            sql.Append("  AND AR_RPILA.RPI_PERI <= 202008 ");
            sql.Append("  AND AR_APOVO.APO_CODA = @TER_CODA ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RPI_PERI", rpi_peri));
            sqlparams.Add(new SQLParams("RPI_PERF", rpi_perf));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}