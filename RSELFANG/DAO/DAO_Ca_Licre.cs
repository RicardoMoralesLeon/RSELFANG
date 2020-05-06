using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAO_Ca_Licre
    {

        public Ca_Licre GetCaLicre(int emp_codi, int lic_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * FROM CA_LICRE  WHERE EMP_CODI=@EMP_CODI AND LIC_CONT=@LIC_CONT ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("LIC_CONT", lic_cont));
            return new DbConnection().Get<Ca_Licre>(sql.ToString(), sQLParams);

        }
    }
}