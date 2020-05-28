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
using System.Configuration;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAOPqInpqr
    {
        public string emp_codi = ConfigurationManager.AppSettings["emp_codi"].ToString();
        public int InseRSELFANG(PqInpqr pqr)
        {
     
                DateTime date = DateTime.Now;
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO PQ_INPQR( ");
                sql.Append(" AUD_ESTA,AUD_USUA,AUD_UFAC,EMP_CODI,INP_CONT,INP_NFOR,INP_FECH,INP_FEVE,INP_ESTA,INP_FCIE,ARB_SUCU,INP_TCLI,INP_NCAR,INP_NIDE, ");
                sql.Append(" INP_NOMB,INP_APEL,INP_NTEL,INP_MAIL,ITE_FREC,ITE_TPQR,ARB_CECO,ITE_SPRE,ITE_ANCU,INP_MPQR,ARB_CECA,ARB_CECR,ITE_TIPI,ITE_STIP,TER_CODI,ING_CONT,INV_CODI,INV_CONT,SOC_CONT,");
                sql.Append(" SBE_CONT,MAC_NUME,CAS_CONT,INP_TIDO,INP_DIRE,INP_NCEL,PAI_CODI,REG_CODI,DEP_CODI,MUN_CODI,INP_MRES,DPA_CODI,CON_CONT,ITE_STAD)VALUES ");
                sql.Append(" (@AUD_ESTA,@AUD_USUA,@AUD_UFAC,@EMP_CODI,@INP_CONT,@INP_NFOR,@INP_FECH,@INP_FEVE,@INP_ESTA,@INP_FCIE,@ARB_SUCU,@INP_TCLI,@INP_NCAR, ");
                sql.Append(" @INP_NIDE,@INP_NOMB,@INP_APEL,@INP_NTEL,@INP_MAIL,@ITE_FREC,@ITE_TPQR,@ARB_CECO,@ITE_SPRE,@ITE_ANCU,@INP_MPQR,@ARB_CECA,@ARB_CECR, ");
                sql.Append(" @ITE_TIPI,@ITE_STIP,@TER_CODI,@ING_CONT,@INV_CODI,@INV_CONT,@SOC_CONT,@SBE_CONT,@MAC_NUME,@CAS_CONT,@INP_TIDO,@INP_DIRE,@INP_NCEL, ");
                sql.Append(" @PAI_CODI,@REG_CODI,@DEP_CODI,@MUN_CODI,@INP_MRES,@INP_GPER,@CON_CONT,@ITE_STAD) ");
                List<Parameter> parametros = new List<Parameter>();
                parametros.Add(new Parameter("@AUD_ESTA ", "A"));
                parametros.Add(new Parameter("@AUD_USUA", "Seven"));
                parametros.Add(new Parameter("@AUD_UFAC", date));
                parametros.Add(new Parameter("@EMP_CODI", pqr.emp_codi)); //pendiente
                parametros.Add(new Parameter("@INP_NFOR", 0));
                parametros.Add(new Parameter("@INP_FECH", date));
                parametros.Add(new Parameter("@INP_FEVE", date));
                parametros.Add(new Parameter("@INP_ESTA", "A"));
                parametros.Add(new Parameter("@INP_FCIE", date));
                parametros.Add(new Parameter("@ARB_SUCU", pqr.arb_sucu));
                parametros.Add(new Parameter("@INP_TCLI", pqr.inp_tcli));
                parametros.Add(new Parameter("@INP_NCAR", "0"));
                parametros.Add(new Parameter("@INP_NIDE", pqr.inp_nide));
                parametros.Add(new Parameter("@INP_NOMB", pqr.inp_nomb));
                parametros.Add(new Parameter("@INP_APEL", pqr.inp_apel));
                parametros.Add(new Parameter("@INP_NTEL", pqr.inp_ntel));
                parametros.Add(new Parameter("@INP_CONT", pqr.inp_cont));
                parametros.Add(new Parameter("@INP_MAIL", pqr.inp_mail));
                parametros.Add(new Parameter("@ITE_FREC", pqr.ite_frec)); //Pendiente
                parametros.Add(new Parameter("@ITE_TPQR", pqr.ite_tpqr));
                parametros.Add(new Parameter("@ARB_CECO", 0));
                parametros.Add(new Parameter("@ITE_SPRE", 0));
                parametros.Add(new Parameter("@ITE_ANCU", 0));
                parametros.Add(new Parameter("@INP_MPQR", pqr.inp_mpqr));
                parametros.Add(new Parameter("@ARB_CECA", 0));
                parametros.Add(new Parameter("@ARB_CECR", pqr.arb_cecr));
                parametros.Add(new Parameter("@ITE_TIPI", pqr.ite_tipi));
                parametros.Add(new Parameter("@ITE_STIP", pqr.ite_stip));
                parametros.Add(new Parameter("@TER_CODI", pqr.ter_codi));
                parametros.Add(new Parameter("@ING_CONT", 0));
                parametros.Add(new Parameter("@INV_CODI", 0));
                parametros.Add(new Parameter("@INV_CONT", 0));
                parametros.Add(new Parameter("@SOC_CONT", 0));
                parametros.Add(new Parameter("@SBE_CONT", 0));
                parametros.Add(new Parameter("@MAC_NUME", 0));
                parametros.Add(new Parameter("@CAS_CONT", 0));
                parametros.Add(new Parameter("@INP_TIDO", pqr.inp_tido));
                parametros.Add(new Parameter("@INP_DIRE", pqr.inp_dire));
                parametros.Add(new Parameter("@INP_NCEL", pqr.inp_ncel));
                parametros.Add(new Parameter("@PAI_CODI", pqr.pai_codi));
                parametros.Add(new Parameter("@REG_CODI", pqr.reg_codi));
                parametros.Add(new Parameter("@DEP_CODI", pqr.dep_codi));
                parametros.Add(new Parameter("@MUN_CODI", pqr.mun_codi));
                parametros.Add(new Parameter("@INP_MRES", pqr.inp_mres));
                parametros.Add(new Parameter("@INP_GPER", pqr.inp_gper));
                parametros.Add(new Parameter("@CON_CONT", pqr.con_cont));
                parametros.Add(new Parameter("@ITE_STAD", 0));
            
                OTOContext pTOContext = new OTOContext();
                var conection = DBFactory.GetDB(pTOContext);
                return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
                                                
        }

        public int GetCont(string table, string campo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("SELECT MAX({0}) + 1 FROM {1} ", campo, table));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result =conection. GetScalar(pTOContext, sql.ToString());
            if (result.ToString() == "")
                return 1;
            return result.AsInt();
        }
        public string getIteFrec ()
        {
            string result;
            try
            {                
                StringBuilder sql = new StringBuilder();
                sql.Append(" SELECT ITE_CONT FROM GN_ITEMS WHERE TIT_CONT = 326 AND ITE_CODI = 0");
                OTOContext pTOContext = new OTOContext();
                var conection = DBFactory.GetDB(pTOContext);
                result = conection.GetScalar(pTOContext, sql.ToString()).ToString();
            }
            catch(Exception ex)
            {
                result = "0";
            }

            return result;
        }

       public List<PqInpqr> getPqInPqr(int inp_cont,int emp_codi=0)
        {            
            StringBuilder sql = new StringBuilder();
            List<Parameter> parameters = new List<Parameter>();
            sql.Append(" SELECT *,DIG_VALO FROM PQ_INPQR, GN_DIGFL WHERE INP_CONT = @INP_CONT AND DIG_CODI = 'SPQ000004' ");
            if (emp_codi > 0)
            {
                sql.Append("  AND EMP_CODI=@EMP_CODI");
                parameters.Add(new Parameter("@EMP_CODI", emp_codi));
            }
                     
            parameters.Add(new Parameter("@INP_CONT", inp_cont));
            
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var data = conection.ReadList(pTOContext, sql.ToString(), Make,parameters.ToArray());
            return data;
        }

        public List<PqInpqr> getPqInPqrEncuestas(int inp_cont, int emp_codi = 0)
        {
            StringBuilder sql = new StringBuilder();
            List<Parameter> parameters = new List<Parameter>();

            sql.Append(" SELECT case when ISNUMERIC(PQ_INPQR.INP_TIDO) = 1 then GN_TIPDO.TIP_NOMB else GN_TIPDO2.TIP_NOMB end INP_TIDO, PQ_INPQR.* ");
            sql.Append(" FROM PQ_INPQR ");
            sql.Append(" left join GN_TIPDO on convert(varchar, GN_TIPDO.TIP_CODI) = PQ_INPQR.INP_TIDO ");
            sql.Append(" left join GN_TIPDO GN_TIPDO2 on convert(varchar, GN_TIPDO2.TIP_ABRE) = PQ_INPQR.INP_TIDO ");
            sql.Append(" WHERE INP_CONT = @INP_CONT ");

            if (emp_codi > 0)
            {
                sql.Append("  AND EMP_CODI=@EMP_CODI");
                parameters.Add(new Parameter("@EMP_CODI", emp_codi));
            }

            parameters.Add(new Parameter("@INP_CONT", inp_cont));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var data = conection.ReadList(pTOContext, sql.ToString(), Make, parameters.ToArray());
            return data;
        }

        public  DataSet GetMailInformationDinamic (string query , int emp_codi,int inp_cont)
        {
            string[] sourceFilter = query.Split(',');
            
            StringBuilder sql = new StringBuilder();

            if (Array.IndexOf(sourceFilter, "S_TIPPQR") > 0)            
                query = query.Replace("S_TIPPQR", "GN_ITEMS.ITE_NOMB ITE_TPQR");            

            if (Array.IndexOf(sourceFilter, "S_TPFPQR") > 0)            
                query = query.Replace("S_TPFPQR", "GN_ITEMS2.ITE_NOMB ITE_TIPI");
            
            if (Array.IndexOf(sourceFilter, "S_STPPQR") > 0)            
                query = query.Replace("S_STPPQR", "GN_ITEMS3.ITE_NOMB ITE_STIP");            

            sql.Append(string.Format("SELECT {0} ", query));
            sql.Append("  FROM PQ_INPQR                                   ");
            sql.Append("  INNER JOIN GN_TERCE                             ");
            sql.Append("  ON  PQ_INPQR.EMP_CODI = GN_TERCE.EMP_CODI       ");
            sql.Append("  AND PQ_INPQR.TER_CODI = GN_TERCE.TER_CODI       ");
            sql.Append("  INNER JOIN GN_PAISE                             ");
            sql.Append("  ON  PQ_INPQR.PAI_CODI = GN_PAISE.PAI_CODI       ");
            sql.Append("  INNER JOIN GN_REGIO                             ");
            sql.Append("  ON  PQ_INPQR.PAI_CODI = GN_REGIO.PAI_CODI       ");
            sql.Append("  AND PQ_INPQR.REG_CODI = GN_REGIO.REG_CODI       ");
            sql.Append("  INNER JOIN GN_DEPAR                             ");
            sql.Append("  ON  PQ_INPQR.PAI_CODI = GN_DEPAR.PAI_CODI       ");
            sql.Append("  AND PQ_INPQR.REG_CODI = GN_DEPAR.REG_CODI       ");
            sql.Append("  AND PQ_INPQR.DEP_CODI = GN_DEPAR.DEP_CODI       ");
            sql.Append("  INNER JOIN GN_MUNIC                             ");
            sql.Append("  ON  PQ_INPQR.PAI_CODI = GN_MUNIC.PAI_CODI       ");
            sql.Append("  AND PQ_INPQR.REG_CODI = GN_MUNIC.REG_CODI       ");
            sql.Append("  AND PQ_INPQR.DEP_CODI = GN_MUNIC.DEP_CODI       ");
            sql.Append("  AND PQ_INPQR.MUN_CODI = GN_MUNIC.MUN_CODI       ");
            
            if (Array.IndexOf(sourceFilter, "S_TIPPQR") > 0)
            {                
                sql.Append (" INNER JOIN GN_ITEMS  ");
                sql.Append (" ON PQ_INPQR.ITE_TPQR = GN_ITEMS.ITE_CONT ");                
            }

            if (Array.IndexOf(sourceFilter, "S_TPFPQR") > 0)
            {             
                sql.Append (" INNER JOIN GN_ITEMS GN_ITEMS2 ");
                sql.Append (" ON PQ_INPQR.ITE_TIPI = GN_ITEMS2.ITE_CONT ");
            }
            if (Array.IndexOf(sourceFilter, "S_STPPQR") > 0)
            {             
                sql.Append (" INNER JOIN GN_ITEMS GN_ITEMS3  ");
                sql.Append (" ON PQ_INPQR.ITE_STIP = GN_ITEMS3.ITE_CONT ");
            }

            sql.Append("  WHERE PQ_INPQR.EMP_CODI =  @EMP_CODI            ");
            sql.Append("AND PQ_INPQR.INP_CONT =  @INP_CONT          ");
            List<SQLParams> sQLParams = new List<SQLParams>();
            sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
            sQLParams.Add(new SQLParams("INP_CONT", inp_cont));
            return new DbConnection().GetDataSet(sql.ToString(),sQLParams);           
        }

        public string GetRespModulo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("  SELECT TER_MAIL FROM PQ_PARAM, GN_TERCE ");
            sql.Append("  WHERE PQ_PARAM.EMP_CODI = GN_TERCE.EMP_CODI AND PQ_PARAM.TER_CODI = GN_TERCE.TER_CODI ");
            sql.Append("  AND PQ_PARAM.EMP_CODI= @EMP_CODI "); 
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@EMP_CODI", emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var data = conection.GetScalar(pTOContext, sql.ToString(), parameters.ToArray());
            return data.ToString();
        }

        public int updatePqr(int inp_cont, string cas_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" UPDATE PQ_INPQR SET CAS_CONT = @CAS_CONT WHERE INP_CONT = @INP_CONT ");
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("@INP_CONT", inp_cont));
            parameters.Add(new Parameter("@CAS_CONT", cas_cont));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var data = conection.Update(pTOContext, sql.ToString(), parameters.ToArray());
            return data;
        }
        public int deletePqr(int inp_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" DELETE FROM PQ_INPQR  WHERE INP_CONT = @INP_CONT AND EMP_CODI = @EMP_CODI ");
            List<Parameter> parameters = new List<Parameter>();
            parameters.Add(new Parameter("INP_CONT", inp_cont));
            parameters.Add(new Parameter("EMP_CODI", emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var data = conection.Update(pTOContext, sql.ToString(), parameters.ToArray());
            return data;
        }

        public Func<IDataReader, PqInpqr> Make = reader => new PqInpqr
        {
            inp_fech = reader["INP_FECH"].AsDateTime(),
            inp_mpqr = reader["INP_MPQR"].AsString(),
            inp_esta = reader["INP_ESTA"].AsString(),
            ite_tpqr = reader["ITE_TPQR"].AsInt(),
            inp_cont = reader["INP_CONT"].AsInt() ,
            inp_nide = reader["INP_NIDE"].AsString(),
            inp_nomb = reader["INP_NOMB"].AsString(),
            inp_apel = reader["INP_APEL"].AsString(),
            cas_cont = reader["CAS_CONT"].AsInt(),    
            emp_codi = reader["EMP_CODI"].AsInt(),
            inp_tido = reader["INP_TIDO"].AsString(),
            dig_valo = reader["DIG_VALO"].AsString()
        };
               
    }
}