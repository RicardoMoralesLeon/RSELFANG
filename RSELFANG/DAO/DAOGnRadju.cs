using Digitalware.Apps.Utilities.TO.Gn_Adju;
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
    public class DAOGnRadju
    {
        public int? InsertarGnRadju(TO.TOGnRadju radju)
        {         
            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();
            sql.Append(" INSERT INTO GN_RADJU ");
            sql.Append(" (AUD_ESTA,AUD_USUA,AUD_UFAC,EMP_CODI,RAD_CONT,PRO_CODI,RAD_LLAV ,RAD_TABL )");
            sql.Append(" VALUES(@AUD_ESTA,@AUD_USUA,@AUD_UFAC,@EMP_CODI,@RAD_CONT ,@PRO_CODI,@RAD_LLAV ,@RAD_TABL) ");          
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@AUD_ESTA ", "A"));
            parametros.Add(new Parameter("@AUD_USUA", "Seven"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@EMP_CODI", radju.emp_codi)); //pendiente          
            parametros.Add(new Parameter("@RAD_TABL", "PQ_INPQR"));
            parametros.Add(new Parameter("@PRO_CODI", "SPQINPQR"));
            parametros.Add(new Parameter("@RAD_LLAV", radju.rad_llav));
            parametros.Add(new Parameter("@RAD_CONT", radju.rad_cont));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public List<TOGnRadju> GetRadju(int emp_codi , string pro_codi , string rad_llav)
        {
            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT * ");
            sql.Append(" FROM   GN_RADJU ");
            sql.Append(" WHERE  EMP_CODI   = @EMP_CODI AND PRO_CODI  = @PRO_CODI  AND RAD_LLAV  = @RAD_LLAV ");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI ",emp_codi));
            parametros.Add(new Parameter("@PRO_CODI", pro_codi));
            parametros.Add(new Parameter("@RAD_LLAV", rad_llav));           
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.ReadList(pTOContext, sql.ToString(), Make, parametros.ToArray());
        }
        private static Func<IDataReader, TOGnRadju> Make = reader => new TOGnRadju
        {
            Emp_Codi = reader["EMP_CODI"].AsInt(),
            Pro_Codi = reader["PRO_CODI"].AsString(),
            Rad_Llav = reader["RAD_LLAV"].AsString(),
            Rad_Cont = reader["RAD_CONT"].AsInt()
        };
    }
}