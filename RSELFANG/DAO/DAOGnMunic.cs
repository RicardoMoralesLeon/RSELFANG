using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RSELFANG.TO;

namespace RSELFANG.DAO
{
    public class DAOGnMunic
    {
        public List<GnMunic> GetGnMunic(int pai_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT MUN_NOMB, MUN_CODI , REG_CODI,DEP_CODI ");
            sql.Append(" FROM GN_MUNIC WHERE PAI_CODI=@PAI_CODI ");
            List<Parameter> sqlParams = new List<Parameter>();
            sqlParams.Add(new Parameter("PAI_CODI", pai_codi));
           
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            List<GnMunic> data = conection.ReadList(pTOContext, sql.ToString(), Make,sqlParams.ToArray());
            return data;
        }

        private static Func<IDataReader, GnMunic> Make = reader => new GnMunic
        {
            mun_codi = reader["MUN_CODI"] + "-" + reader["REG_CODI"].AsString(),
            mun_nomb = reader["MUN_NOMB"].AsString(),
            dep_codi = reader["DEP_CODI"].AsInt(),
        };

        public List<GnMunic> GetGnMunic(int pai_codi, int reg_codi, int dep_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT MUN_NOMB, MUN_CODI , REG_CODI,DEP_CODI ");
            sql.Append(" FROM GN_MUNIC WHERE PAI_CODI=@PAI_CODI ");
            sql.Append(" AND REG_CODI=@REG_CODI ");
            sql.Append(" AND DEP_CODI=@DEP_CODI ");
            List<Parameter> sqlParams = new List<Parameter>();
            sqlParams.Add(new Parameter("PAI_CODI", pai_codi));
            sqlParams.Add(new Parameter("REG_CODI", reg_codi));
            sqlParams.Add(new Parameter("DEP_CODI", dep_codi));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            List<GnMunic> data = conection.ReadList(pTOContext, sql.ToString(), Maker, sqlParams.ToArray());
            return data;
        }

        private static Func<IDataReader, GnMunic> Maker = reader => new GnMunic
        {
            mun_codi = reader["MUN_CODI"].AsString(),
            mun_nomb = reader["MUN_NOMB"].AsString()            
        };
    }
}