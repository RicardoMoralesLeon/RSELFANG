using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using RSELFANG.TO;

namespace RSELFANG.DAO
{
    public class DAOGnItems
    {
        public List<GnItem>GetGnItems(int tit_cont,string ite_codi)
        {
            List<Parameter> parametros = new List<Parameter>();
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT * FROM GN_ITEMS WHERE TIT_CONT=@tit_cont AND ITE_ACTI='S' ");          
            OTOContext pTOContext = new OTOContext();
            List<Parameter> paramters = new List<Parameter>();
            paramters.Add(new Parameter("@tit_cont", tit_cont));
            if (ite_codi != "")
            {
                sql.Append(" and ITE_CODI = @ITE_CODI");
                paramters.Add(new Parameter("@ITE_CODI", ite_codi));
            }
            var conection = DBFactory.GetDB(pTOContext);
            List<GnItem> data = conection.ReadList(pTOContext, sql.ToString(), Make,paramters.ToArray());
            return data;

        }
        public Func<IDataReader, GnItem> Make = reader => new GnItem
        {
            ite_codi = reader["ITE_CODI"].AsString(),
            ite_nomb = reader["ITE_NOMB"].AsString(),
            ite_cont = reader["ITE_CONT"].AsInt()
        };

        public List<GnItem> GetGnItemsFromTipi(int tit_cont, int ite_cont)
        {
            List<Parameter> parametros = new List<Parameter>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DISTINCT GN_ITEMS.ITE_CONT,GN_ITEMS.ITE_CODI,GN_ITEMS.ITE_NOMB ");
            sql.Append(" FROM GN_ITEMS ");
            sql.Append(" INNER JOIN PQ_RTPTF ON GN_ITEMS.ITE_CONT = PQ_RTPTF.ITE_TIPI ");
            sql.Append(" AND GN_ITEMS.TIT_CONT = @TIT_CONT AND PQ_RTPTF.ITE_TPQR = @ITE_TPQR ");
            OTOContext pTOContext = new OTOContext();
            List<Parameter> paramters = new List<Parameter>();
            paramters.Add(new Parameter("@TIT_CONT", tit_cont));
            paramters.Add(new Parameter("@ITE_TPQR", ite_cont));           
            var conection = DBFactory.GetDB(pTOContext);
            List<GnItem> data = conection.ReadList(pTOContext, sql.ToString(), Maker, paramters.ToArray());
            return data;
        }
        public Func<IDataReader, GnItem> Maker = reader => new GnItem
        {
            ite_codi = reader["ITE_CODI"].AsString(),
            ite_nomb = reader["ITE_NOMB"].AsString(),
            ite_cont = reader["ITE_CONT"].AsInt()
        };
    }
}