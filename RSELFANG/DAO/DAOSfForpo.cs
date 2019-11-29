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
    }
}