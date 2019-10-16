using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using RSELFANG.BO;
using System.IO;

namespace RSELFANG.DAO
{
    public class DAORevPr
    {
        public int InseCTREVPR(CtPropo propo)
        {

            DateTime date = DateTime.Now;
            StringBuilder sql = new StringBuilder();

            sql.Append(" INSERT INTO CT_REVPR( ");
            sql.Append(" AUD_ESTA, AUD_UFAC, AUD_USUA, EMP_CODI, REV_CONT, PRO_CODI, PRO_DIVE, TIP_CODI,");
            sql.Append(" PRO_NOMB, PRO_APEL, PRO_NOCO, PRO_FECC, CAM_CONT, PRO_INDS, PRO_DIRE, PRO_NTEL,");
            sql.Append(" PRO_NFAX, PRO_MAIL, PRO_NACI, PRO_NROE, PRO_NOTE, PRO_FESC, PRO_NROC, PRO_FECI,");
            sql.Append(" PRO_RMER, PRO_NMER, PRO_VLRC, PRO_VLRA, PRO_VLRP, PRO_VLRK, PRO_VLRD, PRO_NOMR,");
            sql.Append(" PRO_NROR, PRO_TIPR, PRO_EXPE, PRO_EXGR, ITE_CONT, PRO_NIVA,");
            sql.Append(" PRO_PWEB, PRO_DIRN, PRO_CLAP, PRO_PAIS, PRO_REGI, PRO_DEPA, PRO_MUNI, PRO_LOCA,");
            sql.Append(" PRO_PAIR, PRO_REGR, PRO_DEPR, PRO_MUNR, PRO_LOCR, PRO_INGR, PRO_GAST, PRO_UTIL,");
            sql.Append(" PRO_ACTC, PRO_VLRI, PRO_PASC, PRO_PERC, REV_ESTA, REV_APDA, PRO_CLAD, PRO_CLAF, PRO_RIVA)");
            sql.Append(" VALUES(");
            sql.Append(" @AUD_ESTA, @AUD_UFAC, @AUD_USUA, @EMP_CODI, @REV_CONT, @PRO_CODI, @PRO_DIVE, @TIP_CODI,");
            sql.Append(" @PRO_NOMB, @PRO_APEL, @PRO_NOCO, @PRO_FECC, @CAM_CONT, @PRO_INDS, @PRO_DIRE, @PRO_NTEL,");
            sql.Append(" @PRO_NFAX, @PRO_MAIL, @PRO_NACI, @PRO_NROE, @PRO_NOTE, @PRO_FESC, @PRO_NROC, @PRO_FECI,");
            sql.Append(" @PRO_RMER, @PRO_NMER, @PRO_VLRC, @PRO_VLRA, @PRO_VLRP, @PRO_VLRK, @PRO_VLRD, @PRO_NOMR,");
            sql.Append(" @PRO_NROR, @PRO_TIPR, @PRO_EXPE, @PRO_EXGR, @ITE_CONT, @PRO_NIVA,");
            sql.Append(" @PRO_PWEB, @PRO_DIRN, @PRO_CLAP, @PRO_PAIS, @PRO_REGI, @PRO_DEPA, @PRO_MUNI, @PRO_LOCA,");
            sql.Append(" @PRO_PAIR, @PRO_REGR, @PRO_DEPR, @PRO_MUNR, @PRO_LOCR, @PRO_INGR, @PRO_GAST, @PRO_UTIL,");
            sql.Append(" @PRO_ACTC, @PRO_VLRI, @PRO_PASC, @PRO_PERC, @REV_ESTA, @REV_APDA, @PRO_CLAD, @PRO_CLAF, @PRO_RIVA)");

            List<Parameter> parametros = new List<Parameter>();

            parametros.Add(new Parameter("@AUD_ESTA", "A"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
            parametros.Add(new Parameter("@EMP_CODI", propo.emp_codi));
            parametros.Add(new Parameter("@REV_CONT", propo.rev_cont));
            parametros.Add(new Parameter("@PRO_CODI", propo.pro_codi));
            parametros.Add(new Parameter("@PRO_DIVE", propo.pro_dive));
            parametros.Add(new Parameter("@TIP_CODI", propo.tip_codi));
            parametros.Add(new Parameter("@PRO_NOMB", propo.pro_nomb));
            parametros.Add(new Parameter("@PRO_APEL", propo.pro_apel));
            parametros.Add(new Parameter("@PRO_NOCO", propo.pro_noco));
            parametros.Add(new Parameter("@PRO_FECC", date));
            parametros.Add(new Parameter("@CAM_CONT", propo.cam_cont));
            parametros.Add(new Parameter("@PRO_INDS", propo.pro_inds));
            parametros.Add(new Parameter("@PRO_DIRE", propo.pro_dire));
            parametros.Add(new Parameter("@PRO_NTEL", propo.pro_ntel));
            parametros.Add(new Parameter("@PRO_NFAX", propo.pro_nfax));
            parametros.Add(new Parameter("@PRO_MAIL", propo.pro_mail));
            parametros.Add(new Parameter("@PRO_NACI", propo.pro_naci));
            parametros.Add(new Parameter("@PRO_NROE", propo.pro_nroe));
            parametros.Add(new Parameter("@PRO_NOTE", propo.pro_note));
            parametros.Add(new Parameter("@PRO_FESC", propo.pro_fesc));
            parametros.Add(new Parameter("@PRO_NROC", propo.pro_nroc));
            parametros.Add(new Parameter("@PRO_FECI", propo.pro_feci));
            parametros.Add(new Parameter("@PRO_RMER", propo.pro_rmer));
            parametros.Add(new Parameter("@PRO_NMER", propo.pro_nmer));
            parametros.Add(new Parameter("@PRO_VLRC", propo.pro_vlrc));
            parametros.Add(new Parameter("@PRO_VLRA", propo.pro_vlra));
            parametros.Add(new Parameter("@PRO_VLRP", propo.pro_vlrp));
            parametros.Add(new Parameter("@PRO_VLRK", propo.pro_vlrk));
            parametros.Add(new Parameter("@PRO_VLRD", propo.pro_vlrd));
            parametros.Add(new Parameter("@PRO_NOMR", propo.pro_nomr));
            parametros.Add(new Parameter("@PRO_NROR", propo.pro_nror));
            parametros.Add(new Parameter("@PRO_TIPR", propo.pro_tipr));
            parametros.Add(new Parameter("@PRO_EXPE", propo.pro_expe));
            parametros.Add(new Parameter("@PRO_EXGR", propo.pro_exgr));
            parametros.Add(new Parameter("@ITE_CONT", propo.ite_cont));
            parametros.Add(new Parameter("@PRO_NIVA", propo.pro_niva));
            parametros.Add(new Parameter("@PRO_PWEB", propo.pro_pweb));
            parametros.Add(new Parameter("@PRO_DIRN", propo.pro_dirn));
            parametros.Add(new Parameter("@PRO_CLAP", propo.pro_clap));
            parametros.Add(new Parameter("@PRO_PAIS", propo.pro_pais));
            parametros.Add(new Parameter("@PRO_REGI", propo.pro_regi));
            parametros.Add(new Parameter("@PRO_DEPA", propo.pro_depa));
            parametros.Add(new Parameter("@PRO_MUNI", propo.pro_muni));
            parametros.Add(new Parameter("@PRO_LOCA", propo.pro_loca));
            parametros.Add(new Parameter("@PRO_PAIR", propo.pro_pair));
            parametros.Add(new Parameter("@PRO_REGR", propo.pro_regr));
            parametros.Add(new Parameter("@PRO_DEPR", propo.pro_depr));
            parametros.Add(new Parameter("@PRO_MUNR", propo.pro_munr));
            parametros.Add(new Parameter("@PRO_LOCR", propo.pro_locr));
            parametros.Add(new Parameter("@PRO_INGR", propo.pro_ingr));
            parametros.Add(new Parameter("@PRO_GAST", propo.pro_gast));
            parametros.Add(new Parameter("@PRO_UTIL", propo.pro_util));
            parametros.Add(new Parameter("@PRO_ACTC", propo.pro_actc));
            parametros.Add(new Parameter("@PRO_VLRI", propo.pro_vlri));
            parametros.Add(new Parameter("@PRO_PASC", propo.pro_pasc));
            parametros.Add(new Parameter("@PRO_PERC", propo.pro_perc));
            parametros.Add(new Parameter("@REV_ESTA", propo.rev_esta));
            parametros.Add(new Parameter("@REV_APDA", propo.rev_apda));
            parametros.Add(new Parameter("@PRO_CLAD", propo.pro_clad));
            parametros.Add(new Parameter("@PRO_CLAF", propo.pro_claf));
            parametros.Add(new Parameter("@PRO_RIVA", propo.pro_riva));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int GetCont(string table, string campo, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("SELECT MAX({0}) + 1 FROM {1} WHERE EMP_CODI= {2}", campo, table, emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString());
            if (result.ToString() == "")
                return 1;
            return result.AsInt();
        }

        public int InseCTREVTD(myObject revtd)
        {
            DateTime date = DateTime.Now;

            foreach (CtRevtd item in revtd.detail)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CT_REVTD(EMP_CODI, AUD_USUA, AUD_ESTA, AUD_UFAC, ITE_CONT, REV_CONT, DTR_ACEP) ");
                sql.Append(" VALUES(@EMP_CODI, @AUD_USUA, @AUD_ESTA, @AUD_UFAC, @ITE_CONT, @REV_CONT, @DTR_ACEP) ");
                List<Parameter> parametros = new List<Parameter>();
                parametros.Add(new Parameter("@EMP_CODI", revtd.emp_codi));
                parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
                parametros.Add(new Parameter("@AUD_ESTA", "A"));
                parametros.Add(new Parameter("@AUD_UFAC", date));
                parametros.Add(new Parameter("@ITE_CONT", item.ite_cont));
                parametros.Add(new Parameter("@REV_CONT", revtd.rev_cont));

                if (item.ite_chkd)
                {
                    parametros.Add(new Parameter("@DTR_ACEP", "S"));
                }
                else
                {
                    parametros.Add(new Parameter("@DTR_ACEP", "N"));
                }

                OTOContext pTOContext = new OTOContext();
                var conection = DBFactory.GetDB(pTOContext);
                conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
            }

            return 0;
        }

        public int InseCTREVAC(int emp_codi, int rev_cont, List<GnArbol> ctacxpr)
        {
            DateTime date = DateTime.Now;

            foreach (GnArbol item in ctacxpr)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO CT_REVAC (AUD_ESTA, AUD_UFAC, AUD_USUA, EMP_CODI, ARB_CONT, REV_CONT) ");
                sql.Append(" VALUES(@AUD_ESTA, @AUD_UFAC, @AUD_USUA, @EMP_CODI, @ARB_CONT, @REV_CONT) ");
                List<Parameter> parametros = new List<Parameter>();
                parametros.Add(new Parameter("@AUD_ESTA", "A"));
                parametros.Add(new Parameter("@AUD_UFAC", date));
                parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
                parametros.Add(new Parameter("@EMP_CODI", emp_codi));
                parametros.Add(new Parameter("@ARB_CONT", item.arb_cont));
                parametros.Add(new Parameter("@REV_CONT", rev_cont));
                OTOContext pTOContext = new OTOContext();
                var conection = DBFactory.GetDB(pTOContext);
                conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
            }

            return 0;
        }

        public int InseCTREVDO(int emp_codi, int rev_cont, List<CtDocpr> ctrevdo)
        {
            DateTime date = DateTime.Now;
            int docNreg = 0;

            foreach (CtDocpr doc in ctrevdo)
            {
                docNreg += 1;

                StringBuilder sql = new StringBuilder();
                int doc_cont = GetCont("CT_REVDO", "DOC_CONT", emp_codi);
                sql.Append(" INSERT INTO CT_REVDO(AUD_ESTA, AUD_USUA, AUD_UFAC, EMP_CODI, DOC_CONT, REV_CONT, PRO_NREG, PRO_DDOC, PRO_FENT, PRO_FVEN, PRO_OBSE, REV_APRO) ");
                sql.Append(" VALUES(@AUD_ESTA, @AUD_USUA, @AUD_UFAC, @EMP_CODI, @DOC_CONT, @REV_CONT, @PRO_NREG, @PRO_DDOC, @PRO_FENT, @PRO_FVEN, @PRO_OBSE, @REV_APRO) ");
                List<Parameter> parametros = new List<Parameter>();
                parametros.Add(new Parameter("@AUD_ESTA", "A"));
                parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
                parametros.Add(new Parameter("@AUD_UFAC", date));
                parametros.Add(new Parameter("@EMP_CODI", emp_codi));
                parametros.Add(new Parameter("@DOC_CONT", doc_cont));
                parametros.Add(new Parameter("@REV_CONT", rev_cont));
                parametros.Add(new Parameter("@PRO_NREG", docNreg));
                parametros.Add(new Parameter("@PRO_DDOC", doc.pro_ddoc));
                parametros.Add(new Parameter("@PRO_FENT", doc.pro_fent));
                parametros.Add(new Parameter("@PRO_FVEN", doc.pro_fven));
                parametros.Add(new Parameter("@PRO_OBSE", doc.pro_obse));
                parametros.Add(new Parameter("@REV_APRO", doc.rev_apro));

                OTOContext pTOContext = new OTOContext();
                var conection = DBFactory.GetDB(pTOContext);
                conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());

                GuardarArchivo(doc_cont, emp_codi, doc.pro_adju, doc.fil_name);
            }

            return 0;
        }

        public void deletePropo(int emp_codi, int rev_cont)
        {
            deleteDocumentos(emp_codi,rev_cont, "CT_REVTD");
            deleteDocumentos(emp_codi,rev_cont, "CT_REVAC");
            deleteDocumentos(emp_codi,rev_cont, "CT_REVDO");
            deleteDocumentos(emp_codi,rev_cont, "CT_REVPR");
        }

        public void deleteDocumentos(int emp_codi, int rev_cont, string tabla)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM " + tabla + " WHERE EMP_CODI = @EMP_CODI AND REV_CONT= @REV_CONT ");    
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            conection.Delete(pTOContext, sql.ToString(), parametros.ToArray());
        }

        private void GuardarArchivo(int doc_cont, int emp_codi,string pro_adju, string fil_name)
        {
            BOGnRadju boRadju = new BOGnRadju();
            string key = string.Concat(emp_codi, doc_cont);
            string[] file = pro_adju.Split(',');
            byte[] pro_adjun = file[1].Select(Convert.ToByte).ToArray();
            var saveAttchment = boRadju.insertGnRadju((short)emp_codi, key, "CT_REVDO", "SCTREVDO", doc_cont, pro_adjun, fil_name , "S");
            if (!saveAttchment.Item1)
                throw new Exception(string.Format("Error insertando adjunto en documentos {0}", saveAttchment.Item2));
        }
    }
}