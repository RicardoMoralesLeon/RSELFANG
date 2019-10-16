using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;

namespace RSELFANG.DAO
{
    public class DAOGnBarri
    {
        public List<GnBarri> GetGnBarri(int pai_codi, int reg_codi, int dep_codi, int mun_codi, int loc_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT BAR_NOMB, BAR_CODI");
            sql.Append(" FROM GN_BARRI WHERE PAI_CODI=@PAI_CODI ");
            sql.Append(" AND REG_CODI=@REG_CODI ");
            sql.Append(" AND DEP_CODI=@DEP_CODI ");
            sql.Append(" AND MUN_CODI=@MUN_CODI ");
            sql.Append(" AND LOC_CODI=@LOC_CODI ");
            List<Parameter> sqlParams = new List<Parameter>();
            sqlParams.Add(new Parameter("PAI_CODI", pai_codi));
            sqlParams.Add(new Parameter("REG_CODI", reg_codi));
            sqlParams.Add(new Parameter("DEP_CODI", dep_codi));
            sqlParams.Add(new Parameter("MUN_CODI", mun_codi));
            sqlParams.Add(new Parameter("LOC_CODI", loc_codi));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            List<GnBarri> data = conection.ReadList(pTOContext, sql.ToString(), Make, sqlParams.ToArray());
            return data;
        }

        private static Func<IDataReader, GnBarri> Make = reader => new GnBarri
        {
            bar_codi = reader["BAR_CODI"].AsString(),
            bar_nomb = reader["BAR_NOMB"].AsString()
        };
    }
}