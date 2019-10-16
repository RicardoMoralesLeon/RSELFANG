using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnLocal
    {
        public List<GnLocal> GetGnLocal(int pai_codi, int reg_codi, int dep_codi, int mun_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT LOC_NOMB, LOC_CODI");
            sql.Append(" FROM GN_LOCAL WHERE PAI_CODI=@PAI_CODI ");
            sql.Append(" AND REG_CODI=@REG_CODI ");
            sql.Append(" AND DEP_CODI=@DEP_CODI ");
            sql.Append(" AND MUN_CODI=@MUN_CODI ");
            List<Parameter> sqlParams = new List<Parameter>();
            sqlParams.Add(new Parameter("PAI_CODI", pai_codi));
            sqlParams.Add(new Parameter("REG_CODI", reg_codi));
            sqlParams.Add(new Parameter("DEP_CODI", dep_codi));
            sqlParams.Add(new Parameter("MUN_CODI", mun_codi));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            List<GnLocal> data = conection.ReadList(pTOContext, sql.ToString(), Make, sqlParams.ToArray());
            return data;
        }

        private static Func<IDataReader, GnLocal> Make = reader => new GnLocal
        {            
            loc_codi = reader["LOC_CODI"].AsString(),
            loc_nomb = reader["LOC_NOMB"].AsString()            
        };
    }
}