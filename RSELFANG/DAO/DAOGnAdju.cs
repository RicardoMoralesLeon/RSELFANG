using Digitalware.Apps.Utilities.TO;
using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOGnAdju
    {        
        public int? insertGnAdju(TOGnAdjun adjun)
        {
            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO GN_ADJUN ");
            sql.Append(" (EMP_CODI,RAD_CONT,ADJ_CONT,ADJ_NOMB,AUD_ESTA,AUD_USUA,AUD_UFAC,ADJ_TIPO) ");
            sql.Append(" VALUES (@EMP_CODI,@RAD_CONT,@ADJ_CONT,@ADJ_NOMB,@AUD_ESTA,@AUD_USUA,@AUD_UFAC,@ADJ_TIPO) ");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI ", adjun.Emp_Codi));
            parametros.Add(new Parameter("@RAD_CONT", adjun.Rad_Cont));
            parametros.Add(new Parameter("@ADJ_CONT", adjun.Adj_Cont));
            parametros.Add(new Parameter("@ADJ_NOMB", adjun.Adj_Nomb)); //pendiente          
            parametros.Add(new Parameter("@AUD_ESTA", "A"));
            parametros.Add(new Parameter("@AUD_USUA", adjun.Aud_Usua));
            parametros.Add(new Parameter("@AUD_UFAC", DateTime.Now));
            parametros.Add(new Parameter("@ADJ_TIPO", adjun.Adj_Tipo));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }
        public List<TOGnAdjun> GetAdjun(int emp_codi, int rad_cont)
        {
            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM   GN_ADJUN ");
            sql.Append(" WHERE  EMP_CODI  = @EMP_CODI  AND RAD_CONT     = @RAD_CONT");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI ", emp_codi));
            parametros.Add(new Parameter("@RAD_CONT", rad_cont));          
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.ReadList(pTOContext, sql.ToString(), Make, parametros.ToArray());
        }
        private static Func<IDataReader, TOGnAdjun> Make = reader => new TOGnAdjun
        {
            Emp_Codi = reader["EMP_CODI"].AsInt(),         
            Rad_Cont = reader["RAD_CONT"].AsInt(),
            Adj_Cont =reader["ADJ_CONT"].AsInt(),
            Adj_Nomb= reader["ADJ_NOMB"].ToString()
        };
    }
}