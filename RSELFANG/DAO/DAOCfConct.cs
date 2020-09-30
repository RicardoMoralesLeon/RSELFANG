using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOCfConct
    {
        public TOCfConct GetInfoCfConct(string ter_coda, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT TOP 1  FORMAT((SUM(SU_BONOC.BON_VALO) - SUM(SU_BONOC.BON_PAGO)), '#,0.00') BON_SALD, MAX(DIM_FECH) DIM_FECH ");
            sql.Append("  FROM SU_IMCOD ");
            sql.Append("  JOIN SU_DIMCO ON SU_IMCOD.EMP_CODI = SU_DIMCO.EMP_CODI AND SU_IMCOD.IMC_CONT = SU_DIMCO.IMC_CONT ");
            sql.Append(" JOIN SU_DPUPA ON SU_DIMCO.EMP_CODI = SU_DPUPA.EMP_CODI AND ");
            sql.Append(" CASE WHEN SU_IMCOD.IMC_OPRE = 'S' THEN SU_DIMCO.DIM_CODE ELSE SU_DIMCO.DIM_PUPA END = SU_DPUPA.DPU_COPP ");
            sql.Append(" JOIN PO_PVDOR ON SU_DPUPA.EMP_CODI = PO_PVDOR.EMP_CODI AND SU_DPUPA.PVD_CODI = PO_PVDOR.PVD_CODI ");
            sql.Append(" JOIN SU_ASTAR ON SU_DIMCO.EMP_CODI = SU_ASTAR.EMP_CODI AND SU_DIMCO.RED_TARJ = SU_ASTAR.RED_TARJ ");
            sql.Append(" JOIN GN_TERCE ON SU_ASTAR.EMP_CODI = GN_TERCE.EMP_CODI AND SU_ASTAR.TER_TITU = GN_TERCE.TER_CODI ");
            sql.Append(" JOIN SU_BONOC ON GN_TERCE.EMP_CODI = SU_BONOC.EMP_CODI AND GN_TERCE.TER_CODI = SU_BONOC.TER_CODI ");
            sql.Append(" WHERE SU_BONOC.BON_ESOG = 'G'");
            sql.Append("   AND SU_BONOC.BON_ESTA = 'A' ");
            sql.Append("   AND SU_BONOC.BON_PAGO < SU_BONOC.BON_VALO ");
            sql.Append("   AND SU_ASTAR.AST_ESTA = 'A' ");
            sql.Append("   AND GN_TERCE.TER_CODA = @TER_CODA ");
            sql.Append("   AND SU_IMCOD.EMP_CODI = @EMP_CODI ");
            sql.Append(" GROUP BY GN_TERCE.TER_CODI, GN_TERCE.TER_CODA, GN_TERCE.TER_NOCO, ");
            sql.Append(" SU_ASTAR.RED_TARJ, SU_ASTAR.AST_ESTA, SU_ASTAR.AST_UTRD,SU_DIMCO.DIM_CONT,SU_IMCOD.IMC_CONT ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<TOCfConct>(sql.ToString(), sqlparams);
        }

        public TOCfConct GetInfoFechSald(string ter_coda, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT  '0' BON_SALD , MAX(DIM_FECH) DIM_FECH   ");
            sql.Append(" FROM SU_IMCOD ");
            sql.Append(" LEFT JOIN SU_DIMCO ON SU_IMCOD.EMP_CODI = SU_DIMCO.EMP_CODI AND SU_IMCOD.IMC_CONT = SU_DIMCO.IMC_CONT ");
            sql.Append(" LEFT JOIN SU_DPUPA ON SU_DIMCO.EMP_CODI = SU_DPUPA.EMP_CODI AND ");
            sql.Append(" CASE WHEN SU_IMCOD.IMC_OPRE = 'S' THEN SU_DIMCO.DIM_CODE ELSE SU_DIMCO.DIM_PUPA END = SU_DPUPA.DPU_COPP ");
            sql.Append(" LEFT JOIN PO_PVDOR ON SU_DPUPA.EMP_CODI = PO_PVDOR.EMP_CODI AND SU_DPUPA.PVD_CODI = PO_PVDOR.PVD_CODI ");
            sql.Append(" LEFT JOIN SU_ASTAR ON SU_DIMCO.EMP_CODI = SU_ASTAR.EMP_CODI AND SU_DIMCO.RED_TARJ = SU_ASTAR.RED_TARJ ");
            sql.Append(" LEFT JOIN GN_TERCE ON SU_ASTAR.EMP_CODI = GN_TERCE.EMP_CODI AND SU_ASTAR.TER_TITU = GN_TERCE.TER_CODI ");
            sql.Append(" LEFT JOIN SU_BONOC ON GN_TERCE.EMP_CODI = SU_BONOC.EMP_CODI AND GN_TERCE.TER_CODI = SU_BONOC.TER_CODI ");
            sql.Append(" WHERE SU_ASTAR.AST_ESTA = 'A' ");
            sql.Append("   AND GN_TERCE.TER_CODA = @TER_CODA ");
            sql.Append("   AND SU_ASTAR.AST_ESTA = 'A' ");
            sql.Append("   AND SU_IMCOD.EMP_CODI =  @EMP_CODI ");
            sql.Append(" GROUP BY GN_TERCE.TER_CODI, GN_TERCE.TER_CODA, GN_TERCE.TER_NOCO, ");
            sql.Append(" SU_ASTAR.RED_TARJ, SU_ASTAR.AST_ESTA, SU_ASTAR.AST_UTRD ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<TOCfConct>(sql.ToString(), sqlparams);
        }

        public List<ToSuDimco> GetInfoSuDimco(string ter_coda, int emp_codi, DateTime dim_feci, DateTime dim_fecf)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT SU_DIMCO.DIM_FECH,SU_DIMCO.DIM_HOAU, SU_DIMCO.DIM_DTRA, FORMAT(SU_DIMCO.DIM_VTRA,'#,0.00') DIM_VTRA, ");
            sql.Append(" CASE WHEN SU_DPUPA.EMP_CODI IS NULL THEN CAST(GN_EMPRE.EMP_NITE AS VARCHAR(13)) ELSE PO_PVDOR.PVD_CODA END PVD_CODA,  ");
            sql.Append(" CASE WHEN SU_DPUPA.EMP_CODI IS NULL THEN GN_EMPRE.EMP_NOMB ELSE PO_PVDOR.PVR_NOCO END PVR_NOCO, SU_DPUPA.DPU_COPP,SU_DPUPA.DPU_NOPP,  ");
            sql.Append(" SU_DIMCO.DIM_CTRL,SU_DIMCO.DIM_NURE, SU_IMCOD.IMC_OPRE,SU_DIMCO.DIM_DREA ");
            sql.Append(" FROM SU_IMCOD ");
            sql.Append(" INNER JOIN SU_DIMCO ON SU_IMCOD.EMP_CODI = SU_DIMCO.EMP_CODI ");
            sql.Append(" AND SU_IMCOD.IMC_CONT = SU_DIMCO.IMC_CONT ");
            sql.Append(" INNER JOIN SU_ASTAR ON SU_DIMCO.EMP_CODI = SU_ASTAR.EMP_CODI ");
            sql.Append(" AND SU_DIMCO.RED_TARJ = SU_ASTAR.RED_TARJ ");
            sql.Append(" INNER JOIN GN_TERCE ON SU_ASTAR.EMP_CODI = GN_TERCE.EMP_CODI ");
            sql.Append(" AND SU_ASTAR.TER_TITU = GN_TERCE.TER_CODI ");
            sql.Append(" INNER JOIN GN_EMPRE ON SU_IMCOD.EMP_CODI = GN_EMPRE.EMP_CODI ");
            sql.Append(" LEFT OUTER JOIN SU_DPUPA ON SU_DPUPA.EMP_CODI = SU_DIMCO.EMP_CODI ");
            sql.Append(" AND SU_DPUPA.DPU_COPP = CASE WHEN SU_IMCOD.IMC_OPRE = 'S' THEN SU_DIMCO.DIM_CODE ELSE SU_DIMCO.DIM_PUPA END ");
            sql.Append(" LEFT OUTER JOIN PO_PVDOR         ON SU_DPUPA.EMP_CODI = PO_PVDOR.EMP_CODI ");
            sql.Append(" AND SU_DPUPA.PVD_CODI = PO_PVDOR.PVD_CODI ");
            sql.Append(" WHERE SU_ASTAR.AST_ESTA = 'A' ");
            sql.Append(" AND GN_TERCE.TER_CODA = @TER_CODA ");
            sql.Append(" AND SU_IMCOD.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SU_DIMCO.DIM_FECH >= @DIM_FECI ");
            sql.Append(" AND SU_DIMCO.DIM_FECH < @DIM_FECF ");
            sql.Append(" AND SU_IMCOD.IMC_ESTA = 'A' ");
            sql.Append(" ORDER BY SU_DIMCO.DIM_FECH DESC  ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("DIM_FECI", dim_feci));
            sqlparams.Add(new SQLParams("DIM_FECF", dim_fecf));
            return new DbConnection().GetList<ToSuDimco>(sql.ToString(), sqlparams);
        }
    }
}