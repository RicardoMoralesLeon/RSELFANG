using System.Collections.Generic;
using System.Data;
using System.Text;
using RSELFANG.TO;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAOCtPropo
    {
        public List<TOCtCamar> GetCtCamar(int emp_codi)
        {            
            StringBuilder sql = new StringBuilder();                 
            sql.Append(" SELECT CAM_CONT, CAM_CODI, CAM_NOMB ");
            sql.Append(" FROM CT_CAMAR ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CAM_CODI<> '0' ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));        
            return new DbConnection().GetList<TOCtCamar>(sql.ToString(), sqlparams);
        }

        public string GetPolitica(int emp_codi)
        {
            DataSet ds = new DataSet();
            string par = "";
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT PAR_PTDA  ");
            sql.Append(" FROM GN_PARAM ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");            
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));            
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count > 0)
                par = ds.Tables[0].Rows[0]["PAR_PTDA"].ToString();

            return par;
        }

        public string GetInfoProv(int emp_codi)
        {
            DataSet ds = new DataSet();
            string par = "";
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT PAR_CRPR  ");
            sql.Append(" FROM CT_PARAM ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count > 0)
                par = ds.Tables[0].Rows[0]["PAR_CRPR"].ToString();

            return par;
        }       
    }
}