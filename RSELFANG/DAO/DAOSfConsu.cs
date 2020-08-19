using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOSfConsu
    {

        public Suafili getsfconsu(int emp_codi, int tip_codi, string afi_doc)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT AFI_CONT, TIP_CODI, AFI_DOCU, AFI_NOM1, AFI_NOM2, AFI_APE1, AFI_APE2 ");
            sql.Append(" FROM SU_AFILI ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND TIP_CODI = @TIP_CODI ");
            sql.Append(" AND AFI_DOCU = @AFI_DOCU ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("TIP_CODI", tip_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_doc));
            return new DbConnection().Get<Suafili>(sql.ToString(), sqlparams);
        }

        public List<Sfforpo> getsfforpo(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT FOR_NUME,FOR_FECH, FOR_FASI, ");
            sql.Append(" CASE WHEN FOR_ESTA = 'I' THEN 'En trámite' ");
            sql.Append("      WHEN FOR_ESTA = 'A' THEN 'Activo' ");
            sql.Append("      WHEN FOR_ESTA = 'C' THEN 'Activo por verificar' ");
            sql.Append("      WHEN FOR_ESTA = 'N' THEN 'Inhabilitado' ");
            sql.Append("      WHEN FOR_ESTA = 'S' THEN 'Asignado' ");
            sql.Append("      WHEN FOR_ESTA = 'F' THEN 'Facturado' ");
            sql.Append("      WHEN FOR_ESTA = 'D' THEN 'Desembolsado' ");
            sql.Append("      WHEN FOR_ESTA = 'V' THEN 'Retiro Voluntario' ");
            sql.Append("      WHEN FOR_ESTA = 'R' THEN 'Rechazado' ");
            sql.Append(" END FOR_ESTA, ");
            sql.Append(" DFO_VSOL ");
            sql.Append(" FROM SF_FORPO ");
            sql.Append(" LEFT JOIN SF_DFOIH ON SF_DFOIH.FOR_CONT = SF_FORPO.FOR_CONT ");
            sql.Append(" AND SF_DFOIH.EMP_CODI = SF_FORPO.EMP_CODI ");
            sql.Append(" WHERE AFI_CONT = @AFI_CONT ");
            sql.Append(" AND SF_FORPO.EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));            
            return new DbConnection().GetList<Sfforpo>(sql.ToString(), sqlparams);
        }

        
    }
}