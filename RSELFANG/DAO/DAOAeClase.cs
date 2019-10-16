using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOAeClase
    {
        public TOAeClase GetAeClase(int emp_codi, string cla_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("   SELECT AE_CLASE.EMP_CODI,                           ");
            sql.Append("   AE_CLASE.CLA_POCL,                                  ");
            sql.Append("   AE_CLASE.CLA_TICA,                                  ");
            sql.Append("   AE_CLASE.CLA_FCHR,                                  ");
            sql.Append("   AE_CLASE.CLA_DESC                                   ");
            sql.Append("   FROM   AE_CLASE                                   ");                    
            sql.Append("  WHERE  AE_CLASE.EMP_CODI=@EMP_CODI");        
            sql.Append("   AND CLA_CODI = @CLA_CODI                   ");
          
            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("CLA_CODI", cla_codi));
            return new DbConnection().Get<TOAeClase>(sql.ToString(), sqParams);
        }
    }
}