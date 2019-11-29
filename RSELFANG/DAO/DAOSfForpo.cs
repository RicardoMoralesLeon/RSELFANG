using RSELFANG.TO;
using SevenFramework.DataBase;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOSfForpo
    {
        public string GetSfParam(int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT PAR_FEAB ");
            sql.Append(" FROM SF_PARAM  ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");            
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);
            return ds.Tables[0].Rows[0]["PAR_FEAB"].ToString();
        }

        public List<SfModvi> GetModVi(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_MODVI.MOD_CONT,SF_MODVI.MOD_NOMB ");
            sql.Append(" FROM SF_MODVI,SF_TCONV ");
            sql.Append(" WHERE SF_MODVI.EMP_CODI = SF_TCONV.EMP_CODI ");
            sql.Append(" AND SF_MODVI.TCO_CONT = SF_TCONV.TCO_CONT ");
            sql.Append(" AND SF_MODVI.EMP_CODI = @EMP_CODI ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SfModvi>(sql.ToString(), sqlparams);
        }
    }
}