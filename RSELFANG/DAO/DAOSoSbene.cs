using RSELFANG.Models;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOSoSbene
    {
        /// <summary>
        /// Consulta la información de un beneficiario en seven- erp
        /// </summary>
        /// <param name="emp_codi">Código de empresa</param>
        /// <param name="sbe_codi">Identificación del beneficiario</param>
        /// <returns></returns>
        public TOSoSbene GetSoSbene(int emp_codi, string sbe_codi)
        {
            StringBuilder sql = new StringBuilder();
 
            sql.Append(" SELECT * FROM SO_SBENE WHERE SBE_CODI=@SBE_CODI AND EMP_CODI=@EMP_CODI ");
            List <SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("SBE_CODI", sbe_codi));
            return new DbConnection().Get<TOSoSbene>(sql.ToString(), sqParams);
        }
    }
}