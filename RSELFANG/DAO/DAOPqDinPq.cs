using System.Collections.Generic;
using System.Text;
using Ophelia;
using RSELFANG.TO;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAOPqDinPq
    {
        public List<PqDinPq> getpqDinPq(int inp_cont,int emp_codi, bool envm = true)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * FROM PQ_DINPQ  ");
            sql.Append(" WHERE INP_CONT=@INP_CONT AND EMP_CODI = @EMP_CODI");

            if (envm)
            {
                sql.Append(" AND DIN_ENVM= 'S'");
            }

            OTOContext PToContext = new OTOContext();
            List<SQLParams> parameters = new List<SQLParams>();
            parameters.Add(new SQLParams("INP_CONT", inp_cont));
            parameters.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<PqDinPq>(sql.ToString(), parameters);
        }
       
    }
}