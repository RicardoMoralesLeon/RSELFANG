using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using Digitalware.Apps.Utilities.TO;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAOGnAdjFi
    {
        public string usu_codi { get; set; }
        public int emp_codi { get; set; }
        public DAOGnAdjFi()
        {
            emp_codi = ConfigurationManager.AppSettings["emp_codi"].AsInt();
            usu_codi = ConfigurationManager.AppSettings["usu_codi"].AsString();
        }
        public List<TO.TOGnAdjFi> GetAdjFi(int emp_codi, int rad_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT GN_ADJUN.ADJ_CONT, RAD_LLAV,  ADJ_NOMB,  ADJ_FILE ");
            sql.Append(" FROM GN_RADJU ");
            sql.Append(" INNER JOIN GN_ADJUN ON GN_ADJUN.RAD_CONT = GN_RADJU.RAD_CONT AND GN_ADJUN.EMP_CODI = GN_RADJU.EMP_CODI ");
            sql.Append(" INNER JOIN GN_ADJFI ON GN_ADJFI.RAD_CONT = GN_RADJU.RAD_CONT AND GN_ADJFI.ADJ_CONT = GN_ADJUN.ADJ_CONT ");
            sql.Append(" WHERE GN_RADJU.RAD_CONT = @RAD_CONT ");
            sql.Append(" AND GN_RADJU.EMP_CODI = @EMP_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RAD_CONT", rad_cont));
            return new DbConnection().GetList<TO.TOGnAdjFi >(sql.ToString(), sqlparams);
        }

        public int insertGnAdjfi(TOGnAdjFi adjfi)
        {
            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO GN_ADJFI( ");
            sql.Append(" EMP_CODI,RAD_CONT,ADJ_CONT,ADJ_FILE,AUD_ESTA,AUD_USUA,AUD_UFAC)");
            sql.Append(" VALUES( ");
            sql.Append(" @EMP_CODI,@RAD_CONT,@ADJ_CONT,@ADJ_FILE,@AUD_ESTA,@AUD_USUA,@AUD_UFAC) ");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI",emp_codi));
            parametros.Add(new Parameter("@RAD_CONT", adjfi.rad_cont));
            parametros.Add(new Parameter("@ADJ_CONT", adjfi.adj_cont));
            parametros.Add(new Parameter("@ADJ_FILE",  adjfi.adj_file)); //pendiente          
            parametros.Add(new Parameter("@AUD_ESTA", "A"));
            parametros.Add(new Parameter("@AUD_USUA", usu_codi));
            parametros.Add(new Parameter("@AUD_UFAC", DateTime.Now));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }
        private static Func<IDataReader, TOGnAdjFi> Make = reader => new TOGnAdjFi
        {
            adj_cont = reader["ADJ_CONT"].AsInt(),
            rad_cont = reader["RAD_CONT"].AsInt(), 
            adj_file = reader["ADJ_FILE"].AsByte()
        };
    }
}
