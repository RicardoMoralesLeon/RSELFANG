using RSELFANG.Models;
using SevenFramework.DataBase;
using SevenFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnDiasn
    {

        public int CantidadDiasNoLaborales(DateTime feve, int diasGracia)
        {
            try
            {               
                List<SQLParams> sqlPrms = new List<SQLParams>()
                {
                    new SQLParams("feve", feve),
                    new SQLParams("diasGracia", diasGracia)
                };
                StringBuilder sql = new StringBuilder();              
                sql.AppendLine(" SELECT COUNT(1) AS CCA_CONT FROM GN_DIASN                                     ");
                sql.AppendLine(" WHERE DIA_NOTR >= @feve                                           ");
                sql.AppendLine(" AND DIA_NOTR  <= DATEADD(DAY, @diasGracia + (SELECT COUNT(1) FROM GN_DIASN  ");
                sql.AppendLine("     WHERE DIA_NOTR >= @feve                                       ");
                sql.AppendLine("     AND DIA_NOTR  <= DATEADD(DAY, @diasGracia, @feve)), @feve)              ");
                var obj = new DbConnection().Get<Gn_Diasn>(sql.ToString(), sqlPrms);
                if (obj == null)
                    return 0;
                else
                    return obj.CCA_CONT;
            }
            catch (Exception ex)
            {
                ExceptionManager.Throw(this.GetType().ToString(), System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return 0;
            }
        }
    }
}