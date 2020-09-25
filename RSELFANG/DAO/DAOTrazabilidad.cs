using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOTrazabilidad
    {
        public List<PqTrazabilidad> getInfoPqTrazabilidad(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append("  SELECT PQ_INPQR.INP_CONT Numero_PQR, ");
            sql.Append("  CASE WHEN PQ_INPQR.CAS_CONT = 0 THEN NULL ELSE PQ_INPQR.CAS_CONT END Caso_Wf,  CONVERT(VARCHAR, CAS_FECI, 103) Fecha_Inicial, ");
            sql.Append("  CONVERT(VARCHAR, INP_FECH, 103) Fecha_Registro, ");
            sql.Append("  CASE WHEN PQ_INPQR.CAS_CONT = 0 THEN NULL ELSE CONVERT(VARCHAR, CAS_FLIM, 103) END Fecha_Limite, ");
            sql.Append("  CASE WHEN PQ_INPQR.CAS_CONT = 0 THEN NULL ELSE  CASE WHEN CAS_ESTA = 'I' THEN WF_CASOS.CAS_DIAR ELSE ");
            sql.Append("  DATEDIFF(DAY, WF_CASOS.CAS_FECI, GETDATE()) -  ");
            sql.Append("  ( ");
            sql.Append("     SELECT COUNT(*) ");
            sql.Append(" 	FROM GN_PARAM  ");
            sql.Append(" 	INNER JOIN GN_CCALE on GN_CCALE.CCA_CONT = GN_PARAM.CCA_CONT ");
            sql.Append(" 	INNER JOIN GN_DIASN on GN_DIASN.CCA_CONT = GN_CCALE.CCA_CONT ");
            sql.Append(" 	WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" 	AND CONVERT(DATE, DIA_NOTR) >= CAS_FECI ");
            sql.Append(" 	AND CONVERT(DATE, DIA_NOTR) <=  @INP_FECF ");
            sql.Append("  )  ");
            sql.Append("  END END Dias_Flujo, GN_ARBOL.ARB_NOMB Seccional,  ");
            sql.Append("  GN_ITEMS.ITE_NOMB Forma_Recibido, GN_ITEMSTPQR.ITE_NOMB Tipo_PQR,  GN_ARBOLCECR.ARB_NOMB Area_Responsable, UPPER(PQ_DPARA.DPA_GRUP) Grupo_Perteneciente,  ");
            sql.Append("  GN_ITEMSTIPI.ITE_NOMB Tipificacion, GN_ITEMSSTIP.ITE_NOMB SubTipificacion, ");
            sql.Append("  CASE WHEN INP_ESTA = 'E' THEN 'En trámite' WHEN INP_ESTA = 'A' THEN 'Abierta' WHEN INP_ESTA = 'C' THEN 'Cerrada' END Estado_PQR, ");
            sql.Append("  CASE WHEN PQ_INPQR.CAS_CONT = 0 THEN NULL ELSE CASE WHEN CAS_ESTA = 'A' THEN 'Activo' WHEN CAS_ESTA= 'I' THEN 'Finalizado' END END Estado_Wf ");
            sql.Append("  FROM PQ_INPQR ");
            sql.Append("  INNER JOIN WF_CASOS ON WF_CASOS.CAS_CONT =  PQ_INPQR.CAS_CONT ");
            sql.Append("  AND WF_CASOS.EMP_CODI = PQ_INPQR.EMP_CODI ");
            sql.Append("  INNER JOIN GN_ARBOL ON GN_ARBOL.ARB_CONT = PQ_INPQR.ARB_SUCU ");
            sql.Append("  AND GN_ARBOL.TAR_CODI = 2 AND GN_ARBOL.EMP_CODI = PQ_INPQR.EMP_CODI ");
            sql.Append("  INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_FREC ");
            sql.Append("  INNER JOIN GN_ITEMS GN_ITEMSTPQR ON GN_ITEMSTPQR.ITE_CONT = PQ_INPQR.ITE_TPQR ");
            sql.Append("  INNER JOIN GN_ARBOL GN_ARBOLCECR ON GN_ARBOLCECR.ARB_CONT = PQ_INPQR.ARB_CECR ");
            sql.Append("  AND GN_ARBOLCECR.TAR_CODI = 3 AND GN_ARBOLCECR.EMP_CODI = PQ_INPQR.EMP_CODI ");
            sql.Append("  INNER JOIN GN_ITEMS GN_ITEMSTIPI ON GN_ITEMSTIPI.ITE_CONT = PQ_INPQR.ITE_TIPI ");
            sql.Append("  INNER JOIN GN_ITEMS GN_ITEMSSTIP ON GN_ITEMSSTIP.ITE_CONT = PQ_INPQR.ITE_STIP ");
            sql.Append("  LEFT JOIN PQ_DPARA ON PQ_DPARA.DPA_CODI = PQ_INPQR.DPA_CODI ");

            sql.Append(" WHERE PQ_INPQR.EMP_CODI = @EMP_CODI");

            if (fini != ffin)
            {
                sql.Append(" AND CONVERT(DATE, WF_CASOS.CAS_FECI) >= @INP_FECI ");
                sql.Append(" AND CONVERT(DATE, WF_CASOS.CAS_FECI) <= @INP_FECF ");
            }

            sql.Append(" " + filter);
            sql.Append(" ORDER BY INP_CONT ");

            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));

            sqlparams.Add(new SQLParams("INP_FECI", fini));
            sqlparams.Add(new SQLParams("INP_FECF", ffin));

            return new DbConnection().GetList<PqTrazabilidad>(sql.ToString(), sqlparams);
        }

        public PqTrazabilidadPqr getInfoTrazabilidadPqr(int emp_codi, int inp_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT INP_NOMB, INP_APEL, INP_NIDE, INP_MAIL, GN_ITEMS.ITE_NOMB, GN_ARBOL.ARB_NOMB, PQ_DPARA.DPA_GRUP, INP_MPQR, ");
            sql.Append(" CASE WHEN INP_ESTA = 'A' THEN 'Abierta' WHEN INP_ESTA = 'E' THEN 'En trámite' ELSE 'Cerrada' END INP_ESTA");
            sql.Append(" FROM PQ_INPQR");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = PQ_INPQR.ITE_TPQR");
            sql.Append(" INNER JOIN GN_ARBOL ON GN_ARBOL.ARB_CONT = PQ_INPQR.ARB_CECR");
            sql.Append(" AND GN_ARBOL.EMP_CODI = PQ_INPQR.EMP_CODI");
            sql.Append(" LEFT JOIN PQ_DPARA ON PQ_DPARA.DPA_CODI = PQ_INPQR.DPA_CODI");
            sql.Append(" WHERE INP_CONT = @INP_CONT");
            sql.Append(" AND PQ_INPQR.EMP_CODI = @EMP_CODI");
            sqlparams.Add(new SQLParams("INP_CONT", inp_cont));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<PqTrazabilidadPqr>(sql.ToString(), sqlparams);
        }
    }
}