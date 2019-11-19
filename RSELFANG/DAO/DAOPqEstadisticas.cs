using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOPqEstadisticas
    {
        public List<InfoPqEstad> getInfoXSeccional(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT GN_ARBOL.ARB_NOMB DAT_NOMB, COUNT(ITE_CONT) CANTIDAD,  ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_TPQR ");
            sql.Append(" INNER JOIN GN_ARBOL ON GN_ARBOL.ARB_CONT = PQ_INPQR.ARB_SUCU ");
            sql.Append(" AND GN_ARBOL.EMP_CODI = PQ_INPQR.EMP_CODI ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");
            sql.Append(" AND TAR_CODI = 2 AND ARB_MOVI = 'S' ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND ARB_SUCU = @ARB_SUCU ");

            sql.Append(" GROUP BY GN_ARBOL.ARB_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ARB_SUCU", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXFormRecib(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT UPPER(GN_ITEMS.ITE_NOMB) DAT_NOMB, COUNT(ITE_CONT) CANTIDAD, ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_FREC ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND GN_ITEMS.ITE_CONT = @ITE_CONT ");

            sql.Append(" GROUP BY GN_ITEMS.ITE_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ITE_CONT", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXTipodePqr(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT UPPER(GN_ITEMS.ITE_NOMB) DAT_NOMB, COUNT(ITE_CONT) CANTIDAD, ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_TPQR ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");

             if (filter != null && filter != "undefined")
                sql.Append(" AND GN_ITEMS.ITE_CONT = @ITE_CONT ");

            sql.Append(" GROUP BY GN_ITEMS.ITE_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ITE_CONT", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXAreaResp(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT UPPER(GN_ARBOL.ARB_NOMB) DAT_NOMB, COUNT(ITE_CONT) CANTIDAD,   ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_TPQR ");
            sql.Append(" INNER JOIN GN_ARBOL ON GN_ARBOL.ARB_CONT = PQ_INPQR.ARB_CECR ");
            sql.Append(" AND GN_ARBOL.EMP_CODI = PQ_INPQR.EMP_CODI ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");
            sql.Append(" AND TAR_CODI = 3 AND ARB_MOVI = 'S' ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND GN_ARBOL.ARB_CONT = @ITE_CONT ");

            sql.Append(" GROUP BY GN_ARBOL.ARB_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");
            
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ITE_CONT", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXTipificac(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT UPPER(GN_ITEMS.ITE_NOMB) DAT_NOMB, COUNT(ITE_CONT) CANTIDAD, ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_TIPI ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND GN_ITEMS.ITE_CONT = @ITE_CONT ");

            sql.Append(" GROUP BY GN_ITEMS.ITE_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ITE_CONT", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXSubTipifi(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT UPPER(GN_ITEMS.ITE_NOMB) DAT_NOMB, COUNT(ITE_CONT) CANTIDAD, ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(ITE_CONT) * 100.0) / (SUM(COUNT(ITE_CONT)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_STIP ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND GN_ITEMS.ITE_CONT = @ITE_CONT ");

            sql.Append(" GROUP BY GN_ITEMS.ITE_NOMB ");
            sql.Append(" ORDER BY COUNT(ITE_CONT) DESC ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("ITE_CONT", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

        public List<InfoPqEstad> getInfoXGruPerten(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            
            sql.Append(" SELECT UPPER(PQ_DPARA.DPA_GRUP) DAT_NOMB, COUNT(PQ_INPQR.DPA_CODI) CANTIDAD,  ");
            sql.Append(" CONVERT(DECIMAL(10, 1), (COUNT(PQ_INPQR.DPA_CODI) * 100.0) / (SUM(COUNT(PQ_INPQR.DPA_CODI)) OVER())) PORCENTAJE ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" INNER JOIN PQ_DPARA ON PQ_DPARA.DPA_CODI = PQ_INPQR.DPA_CODI ");
            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) >= @INP_FECI ");
            sql.Append(" AND CONVERT(DATE, INP_FECH) <= @INP_FECF ");

            if (filter != null && filter != "undefined")
                sql.Append(" AND PQ_INPQR.DPA_CODI = @DPA_CODI ");

            sql.Append(" GROUP BY PQ_DPARA.DPA_GRUP ");
            sql.Append(" ORDER BY  COUNT(PQ_INPQR.DPA_CODI) DESC ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            if (filter != null || filter != "undefined")
                sqlparams.Add(new SQLParams("DPA_CODI", filter));

            return new DbConnection().GetList<InfoPqEstad>(sql.ToString(), sqlparams);
        }

    }
}