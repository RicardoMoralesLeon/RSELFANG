using DigitalWare.Apps.Utilities.Gn.DAO;
using RSELFANG.TO;
using SevenFramework.DataBase;
using SevenFramework.DataBase.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnTerce
    {
        public static Gn_Terce GetGnTerce(int emp_codi, string ter_coda)
        {
            List<SQLParams> sQLParams = new List<SQLParams>()
            {
                new SQLParams("EMP_CODI",emp_codi),
                new SQLParams("TER_CODA",ter_coda)
            };
            string sql = DBHelper.SelectQueryString<Gn_Terce>(sQLParams);
            return new DbConnection().Get<Gn_Terce>(sql, sQLParams);
        }


        public Gn_Terce GetGnTerceByUser(int emp_codi, string usu_codi)
        {
            StringBuilder sql = new StringBuilder();

            if (new DAO_Gn_Acrol().getClienUseXbrl() != 0)
            {
                sql.Append("   SELECT GN_TERCE.TER_CODA,                       ");
                sql.Append("   GN_TERCE.TER_NOCO                               ");
                sql.Append("   FROM   GN_USUAR                                 ");
                sql.Append("   INNER JOIN GN_TERCE                             ");
                sql.Append("   ON GN_USUAR.EMP_CODI = GN_TERCE.EMP_CODI        ");
                sql.Append("   AND GN_USUAR.TER_CODI = GN_TERCE.TER_CODI       ");
                sql.Append("   WHERE GN_TERCE.EMP_CODI = @EMP_CODI             ");
                sql.Append("   AND USU_CODI =@USU_CODI                         ");
            }
            else
            {
                sql.Append(" SELECT GN_TERCE.TER_CODA, ");
                sql.Append(" GN_TERCE.TER_NOCO ");
                sql.Append(" FROM   GN_ACROL ");
                sql.Append(" INNER JOIN GN_DACRO ON GN_ACROL.ACR_CONT = GN_DACRO.ACR_CONT ");
                sql.Append(" INNER JOIN GN_TERCE ON GN_TERCE.TER_CODA = GN_ACROL.TER_CODA ");
                sql.Append(" AND GN_TERCE.EMP_CODI = GN_DACRO.EMP_CODI ");
                sql.Append(" WHERE GN_TERCE.EMP_CODI = @EMP_CODI ");
                sql.Append(" AND GN_ACROL.TER_CODA = @USU_CODI");
            }

            List<SQLParams> sqParams = new List<SQLParams>();
            sqParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqParams.Add(new SQLParams("USU_CODI", usu_codi));
            return new DbConnection().Get<Gn_Terce>(sql.ToString(), sqParams);
        }
    }
}