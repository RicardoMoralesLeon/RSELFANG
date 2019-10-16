using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOGnRegi
    {
        public List<GnRegio> GetGnRegio(int pai_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT REG_CODI, REG_NOMB ");
            sql.Append(" FROM GN_REGIO WHERE PAI_CODI=@PAI_CODI ");
            List<Parameter> sqlParams = new List<Parameter>();
            sqlParams.Add(new Parameter("PAI_CODI", pai_codi));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            List<GnRegio> data = conection.ReadList(pTOContext, sql.ToString(), Make, sqlParams.ToArray());
            return data;
        }
        private static Func<IDataReader, GnRegio> Make = reader => new GnRegio
        {           
            reg_codi = reader["REG_CODI"].AsInt(),
            reg_nomb = reader["REG_NOMB"].AsString()
        };
    }
}