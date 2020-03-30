using RSELFANG.TO;
using SevenFramework.DataBase;
using System.Collections.Generic;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOGnNomdi
    {
        public List<GnNomdi> GetGnNomdi()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT NOM_NOMB, NOM_CODI, NOM_EDTN, NOM_MUSA ");
            sql.Append(" FROM GN_NOMDI ");
            sql.Append(" ORDER BY NOM_NOMB ");
            List <SQLParams> sqParams = new List<SQLParams>();            
            return new DbConnection().GetList<GnNomdi>(sql.ToString(), sqParams);
        }
    }
}