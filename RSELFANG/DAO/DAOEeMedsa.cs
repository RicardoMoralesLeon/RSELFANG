using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOEeMedsa
    {
        public List<EeMedsa> getInfoXServicio(int ser_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();            
            sql.Append(" SELECT ITE_CODI, ITE_NOMB DAT_NOMB, COUNT(DISTINCT EE_RESEN.REM_CONT) CANTIDAD, ");
            sql.Append(" CONVERT(DECIMAL(10, 2), (COUNT(EE_REMES.REM_CONT) * 100.0) / (SUM(COUNT(EE_REMES.REM_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM EE_REMES ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = EE_REMES.ITE_SERV ");
            sql.Append(" INNER JOIN EE_RESEN ON EE_RESEN.REM_CONT = EE_REMES.REM_CONT ");

            if (ser_cont != 0)
            {
                sqlparams.Add(new SQLParams("SER_CONT", ser_cont));
                sql.Append(" WHERE GN_ITEMS.ITE_CONT = @SER_CONT");
            }
            
            sql.Append(" GROUP BY ITE_CODI, ITE_NOMB ");
            return new DbConnection().GetList<EeMedsa>(sql.ToString(), sqlparams);
        }

        public List<EeSaSec> getInfoSatisfaccion()
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT *, ");
            sql.Append(" CASE WHEN SATISFACCION < 40 THEN 'MALO' WHEN SATISFACCION BETWEEN 40 AND 79 THEN 'REGULAR' ");
            sql.Append("      WHEN SATISFACCION >= 80 THEN 'BUENO' END INTERPRETACION ");
            sql.Append(" FROM( ");
            sql.Append(" SELECT EE_SECCE.SEC_CODI, EE_SECCE.SEC_NOMB, COUNT(EE_DRSEE.DRS_CONT) FRECUENCIA, ");
            sql.Append(" SUM(CONVERT(FLOAT, RES_VALO)) / CONVERT(FLOAT, COUNT(EE_DRSEE.DRS_CONT))  CALIFICACION, ");
            sql.Append(" SUM(CONVERT(FLOAT, RES_VALO)) / CONVERT(FLOAT, COUNT(EE_DRSEE.DRS_CONT)) / 5 * 100 SATISFACCION ");            
            sql.Append(" FROM EE_RELES ");
            sql.Append(" INNER JOIN EE_DRELE ON EE_DRELE.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" INNER JOIN EE_RSEEN ON EE_RSEEN.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_DRSEE ON EE_DRSEE.RSE_CONT = EE_RSEEN.RSE_CONT ");
            sql.Append(" INNER JOIN EE_SECCE ON EE_SECCE.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_RESEN ON EE_RESEN.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" AND EE_RESEN.RSE_CONT = EE_DRSEE.RSE_CONT ");
            sql.Append(" AND EE_RESEN.DRS_CONT = EE_DRSEE.DRS_CONT ");
            sql.Append(" INNER JOIN EE_REMES ON EE_REMES.REM_CONT = EE_RESEN.REM_CONT ");
            sql.Append(" WHERE EE_DRSEE.DRS_CLAS = 'P' ");
            sql.Append(" GROUP BY  EE_SECCE.SEC_CODI, EE_SECCE.SEC_NOMB ");
            sql.Append(" ) A ");
            return new DbConnection().GetList<EeSaSec>(sql.ToString(), sqlparams);
        }

        public List<EeDeSec> getInfoDetalleSatis()
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT *, ");
            sql.Append(" CASE WHEN SATISFACCION < 40 THEN 'MALO' WHEN SATISFACCION BETWEEN 40 AND 79 THEN 'REGULAR' ");
            sql.Append("      WHEN SATISFACCION >= 80 THEN 'BUENO' END INTERPRETACION ");
            sql.Append(" FROM( ");
            sql.Append(" SELECT EE_DRSEE.DRS_CONT, EE_DRSEE.DRS_PREG, ");
            sql.Append(" COUNT(EE_DRSEE.DRS_CONT) FRECUENCIA, ");
            sql.Append(" SUM(CONVERT(DECIMAL, RES_VALO)) / CONVERT(DECIMAL, COUNT(EE_DRSEE.DRS_CONT))  CALIFICACION, ");
            sql.Append(" SUM(CONVERT(DECIMAL, RES_VALO)) / CONVERT(DECIMAL, COUNT(EE_DRSEE.DRS_CONT)) / 5 * 100 SATISFACCION ");
            sql.Append(" FROM EE_RELES ");
            sql.Append(" INNER JOIN EE_DRELE ON EE_DRELE.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" INNER JOIN EE_RSEEN ON EE_RSEEN.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_DRSEE ON EE_DRSEE.RSE_CONT = EE_RSEEN.RSE_CONT ");
            sql.Append(" INNER JOIN EE_SECCE ON EE_SECCE.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_RESEN ON EE_RESEN.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" AND EE_RESEN.RSE_CONT = EE_DRSEE.RSE_CONT ");
            sql.Append(" AND EE_RESEN.DRS_CONT = EE_DRSEE.DRS_CONT ");
            sql.Append(" INNER JOIN EE_REMES ON EE_REMES.REM_CONT = EE_RESEN.REM_CONT ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = EE_REMES.ITE_SERV ");
            sql.Append(" WHERE EE_DRSEE.DRS_CLAS = 'P' ");
            sql.Append(" GROUP BY  EE_DRSEE.DRS_CONT, EE_DRSEE.DRS_PREG ");
            sql.Append(" ) A ");
            return new DbConnection().GetList<EeDeSec>(sql.ToString(), sqlparams);
        }

        public List<EeSaSer> getInfoOportunidad(int ser_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT *, ");
            sql.Append(" CASE WHEN OPORTUNIDAD < 40 THEN 'MALO' WHEN OPORTUNIDAD BETWEEN 40 AND 79 THEN 'REGULAR' ");
            sql.Append("      WHEN OPORTUNIDAD >= 80 THEN 'BUENO' END INTERPRETACION ");
            sql.Append(" FROM( ");
            sql.Append(" SELECT GN_ITEMS.ITE_CODI SER_CODI, GN_ITEMS.ITE_NOMB SER_NOMB, COUNT(EE_DRSEE.DRS_CONT) FRECUENCIA, ");
            sql.Append(" CAST(SUM(CONVERT(FLOAT, RES_VALO)) / CONVERT(FLOAT, COUNT(EE_DRSEE.DRS_CONT)) AS NUMERIC(10,2))  CALIFICACION, ");
            sql.Append(" CAST(SUM(CONVERT(FLOAT, RES_VALO)) / CONVERT(FLOAT, COUNT(EE_DRSEE.DRS_CONT)) / 5 * 100 AS NUMERIC(10,2)) OPORTUNIDAD ");                   
            sql.Append(" FROM EE_RELES ");
            sql.Append(" INNER JOIN EE_DRELE ON EE_DRELE.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" INNER JOIN EE_RSEEN ON EE_RSEEN.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_DRSEE ON EE_DRSEE.RSE_CONT = EE_RSEEN.RSE_CONT ");
            sql.Append(" INNER JOIN EE_SECCE ON EE_SECCE.SEC_CONT = EE_DRELE.DRE_SECC ");
            sql.Append(" INNER JOIN EE_RESEN ON EE_RESEN.REL_CONT = EE_RELES.REL_CONT ");
            sql.Append(" AND EE_RESEN.RSE_CONT = EE_DRSEE.RSE_CONT ");
            sql.Append(" AND EE_RESEN.DRS_CONT = EE_DRSEE.DRS_CONT ");
            sql.Append(" INNER JOIN EE_REMES ON EE_REMES.REM_CONT = EE_RESEN.REM_CONT ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = EE_REMES.ITE_SERV ");
            sql.Append(" WHERE EE_DRSEE.DRS_CLAS = 'P' ");

            if (ser_cont != 0)
            {
                sqlparams.Add(new SQLParams("SER_CONT", ser_cont));
                sql.Append(" AND CAST(EE_REMES.ITE_SERV AS FLOAT) = @SER_CONT");
            }

            sql.Append(" GROUP BY  GN_ITEMS.ITE_CODI, GN_ITEMS.ITE_NOMB ");
            sql.Append(" ) A ");
            return new DbConnection().GetList<EeSaSer>(sql.ToString(), sqlparams);
        }
    }
}