using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAOCtConsu
    {
        public List<TORevPr> getctconsu(int emp_codi, string rev_esta, string pro_codi = "", string pro_nomb = "")
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT REV_CONT, PRO_CODI, PRO_NOMB, PRO_APEL, PRO_MAIL, EMP_CODI ");
            sql.Append(" FROM CT_REVPR ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REV_ESTA = @REV_ESTA ");

            if(pro_codi != null)
            {
                sql.Append(" AND PRO_CODI = @PRO_CODI ");
                sqlparams.Add(new SQLParams("PRO_CODI", pro_codi));
            }

            if (pro_nomb != null)
            {
                sql.Append(" AND PRO_NOMB = @PRO_NOMB ");
                sqlparams.Add(new SQLParams("PRO_NOMB", pro_nomb));
            }

            sql.Append("ORDER BY REV_CONT ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_ESTA", rev_esta));

            return new DbConnection().GetList<TORevPr>(sql.ToString(), sqlparams);
        }

        public CtPropo getctpropo(int emp_codi, int rev_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT * ");
            sql.Append(" FROM CT_REVPR ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REV_CONT = @REV_CONT ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_CONT", rev_cont));
            return new DbConnection().Get<CtPropo>(sql.ToString(), sqlparams);
        }

        public List<GnArbol> getctacxpr(int emp_codi, int rev_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT GN_ARBOL.ARB_CODI, GN_ARBOL.ARB_NOMB, GN_ARBOL.ARB_CONT ");
            sql.Append(" FROM CT_REVAC ");
            sql.Append(" INNER JOIN GN_ARBOL ON CT_REVAC.ARB_CONT = GN_ARBOL.ARB_CONT ");
            sql.Append(" AND CT_REVAC.EMP_CODI = GN_ARBOL.EMP_CODI ");
            sql.Append(" WHERE CT_REVAC.EMP_CODI = @EMP_CODI AND CT_REVAC.REV_CONT = @REV_CONT ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_CONT", rev_cont));
            return new DbConnection().GetList<GnArbol>(sql.ToString(), sqlparams);
        }

        public List<CtRevtd> getctrevtd(int emp_codi, int rev_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT GN_ITEMS.ITE_CODI, CT_REVTD.ITE_CONT, GN_ITEMS.ITE_NOMB, ");
            sql.Append(" CASE WHEN CT_REVTD.DTR_ACEP = 'S' THEN 1 ELSE 0 END ITE_CHKD ");
            sql.Append(" FROM CT_REVTD ");
            sql.Append(" INNER JOIN GN_ITEMS ON GN_ITEMS.ITE_CONT = CT_REVTD.ITE_CONT ");
            sql.Append(" WHERE CT_REVTD.EMP_CODI = @EMP_CODI AND CT_REVTD.REV_CONT = @REV_CONT ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_CONT", rev_cont));
            return new DbConnection().GetList<CtRevtd>(sql.ToString(), sqlparams);
        }

        public List<CtRevdo> GetCtRevDo(int emp_codi, int rev_cont)
        {            
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DISTINCT RAD_LLAV,DOC_CONT,PRO_NREG, PRO_DDOC, PRO_FENT, PRO_FVEN, PRO_OBSE, ADJ_NOMB,");
            sql.Append(" CASE WHEN REV_APRO = 'S' THEN 1 ELSE 0 END ITE_CHKD ");        
            sql.Append(" FROM CT_REVDO ");
            sql.Append(" INNER JOIN GN_RADJU ON GN_RADJU.RAD_LLAV = CONCAT(CT_REVDO.EMP_CODI, CT_REVDO.DOC_CONT) ");
            sql.Append(" INNER JOIN GN_ADJUN ON GN_ADJUN.RAD_CONT = GN_RADJU.RAD_CONT AND GN_ADJUN.EMP_CODI = GN_RADJU.EMP_CODI ");
            sql.Append(" WHERE GN_RADJU.RAD_TABL = 'CT_REVDO' ");
            sql.Append(" AND CT_REVDO.REV_CONT = @REV_CONT ");
            sql.Append(" AND CT_REVDO.EMP_CODI = @EMP_CODI ");            
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_CONT", rev_cont));
            return new DbConnection().GetList<CtRevdo>(sql.ToString(), sqlparams);
        }

        public List<CtRevdo> GetCtRevDoBD(int emp_codi, int rev_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RAD_LLAV,DOC_CONT,PRO_NREG, PRO_DDOC, PRO_FENT, PRO_FVEN, PRO_OBSE, ADJ_NOMB,");
            sql.Append(" CASE WHEN REV_APRO = 'S' THEN 1 ELSE 0 END ITE_CHKD, ADJ_FILE ");
            sql.Append(" FROM CT_REVDO ");
            sql.Append(" INNER JOIN GN_RADJU ON GN_RADJU.RAD_LLAV = CONCAT(CT_REVDO.EMP_CODI, CT_REVDO.DOC_CONT) ");
            sql.Append(" INNER JOIN GN_ADJUN ON GN_ADJUN.RAD_CONT = GN_RADJU.RAD_CONT AND GN_ADJUN.EMP_CODI = GN_RADJU.EMP_CODI ");
            sql.Append(" INNER JOIN GN_ADJFI ON GN_ADJFI.RAD_CONT = GN_RADJU.RAD_CONT AND GN_ADJFI.EMP_CODI = GN_RADJU.EMP_CODI ");
            sql.Append(" WHERE GN_RADJU.RAD_TABL = 'CT_REVDO' ");
            sql.Append(" AND CT_REVDO.REV_CONT = @REV_CONT ");
            sql.Append(" AND CT_REVDO.EMP_CODI = @EMP_CODI ");
            sql.Append(" ORDER BY PRO_NREG  ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("REV_CONT", rev_cont));
            return new DbConnection().GetList<CtRevdo>(sql.ToString(), sqlparams);
        }

        public int setCtRevdo(int emp_codi, int rev_cont, int doc_cont, bool chkApro)
        {
            StringBuilder sql = new StringBuilder();
            
            sql.Append(" UPDATE CT_REVDO");
            sql.Append(" SET REV_APRO = @REV_APRO");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI");
            sql.Append(" AND REV_CONT = @REV_CONT");
            sql.Append(" AND DOC_CONT = @DOC_CONT");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@DOC_CONT", doc_cont));
            
            if (chkApro)
                parametros.Add(new Parameter("@REV_APRO", "S"));
            else
                parametros.Add(new Parameter("@REV_APRO", "N"));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int setCtpropo(int emp_codi, int rev_cont, string state)
        {
            StringBuilder sql = new StringBuilder();
            DateTime date = DateTime.Now;

            sql.Append(" UPDATE CT_REVPR");
            sql.Append(" SET REV_ESTA = @REV_ESTA,");
            sql.Append(" AUD_ESTA = @AUD_ESTA, ");
            sql.Append(" AUD_UFAC = @AUD_UFAC, ");
            sql.Append(" AUD_USUA = @AUD_USUA  ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI");
            sql.Append(" AND REV_CONT = @REV_CONT");
            
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@AUD_ESTA", "M"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
            parametros.Add(new Parameter("@REV_ESTA", state));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int insertCtPropo(int rev_cont, int pro_cont, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            DateTime date = DateTime.Now;

            sql.Append(" INSERT INTO CT_PROPO( ");
            sql.Append(" AUD_ESTA, AUD_UFAC, AUD_USUA, EMP_CODI, PRO_CONT, PRO_CODI, PRO_DIVE, TIP_CODI, PRO_NOMB, PRO_APEL, ");
            sql.Append(" PRO_NOCO, PRO_FECC, CAM_CONT, PRO_INDS, PRO_DIRE, PRO_NTEL, PRO_NFAX, PRO_MAIL, PRO_NACI, PRO_NROE, ");
            sql.Append(" PRO_NOTE, PRO_FESC, PRO_NROC, PRO_FECI, PRO_RMER, PRO_NMER, PRO_VLRC, PRO_VLRA, PRO_VLRP, PRO_VLRK, ");
            sql.Append(" PRO_VLRD, PRO_NOMR, PRO_NROR, PRO_TIPR, PRO_EXPE, PRO_EXGR, ADJ_CONT, CAS_CONT, ITE_CONT, PRO_NIVA, ");
            sql.Append(" PRO_PWEB, PRO_DIRN, PRO_CLAP, PRO_PAIS, PRO_REGI, PRO_DEPA, PRO_MUNI, PRO_LOCA, PRO_PAIR, PRO_REGR, ");
            sql.Append(" PRO_DEPR, PRO_MUNR, PRO_LOCR, PRO_INGR, PRO_GAST, PRO_UTIL, PRO_ACTC, PRO_VLRI, PRO_PASC, PRO_PERC, ");
            sql.Append(" PRO_AUDP ");
            sql.Append(" ) ");
            sql.Append(" SELECT ");
            sql.Append(" @AUD_ESTA, @AUD_UFAC, @AUD_USUA, EMP_CODI,@PRO_CONT,PRO_CODI,PRO_DIVE,TIP_CODI,PRO_NOMB,PRO_APEL, ");
            sql.Append(" PRO_NOCO,PRO_FECC,CAM_CONT,PRO_INDS,PRO_DIRE,PRO_NTEL,PRO_NFAX,PRO_MAIL,PRO_NACI,PRO_NROE, ");
            sql.Append(" PRO_NOTE,PRO_FESC,PRO_NROC,PRO_FECI,PRO_RMER,PRO_NMER,PRO_VLRC,PRO_VLRA,PRO_VLRP,PRO_VLRK, ");
            sql.Append(" PRO_VLRD,PRO_NOMR,PRO_NROR,PRO_TIPR,PRO_EXPE,PRO_EXGR,0,0,ITE_CONT,PRO_NIVA, ");
            sql.Append(" PRO_PWEB,PRO_DIRN,PRO_CLAP,PRO_PAIS,PRO_REGI,PRO_DEPA,PRO_MUNI,PRO_LOCA,PRO_PAIR,PRO_REGR, ");
            sql.Append(" PRO_DEPR,PRO_MUNR,PRO_LOCR,PRO_INGR,PRO_GAST,PRO_UTIL,PRO_ACTC,PRO_VLRI,PRO_PASC,PRO_PERC, ");
            sql.Append(" REV_APDA ");
            sql.Append(" FROM CT_REVPR ");
            sql.Append(" WHERE REV_CONT = @REV_CONT ");
            sql.Append(" AND   EMP_CODI = @EMP_CODI");

            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@PRO_CONT", pro_cont));
            parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@AUD_ESTA", "A"));
            
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int insertCtDtrda(int rev_cont, int pro_cont, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            DateTime date = DateTime.Now;

            sql.Append(" INSERT INTO CT_DTRDA(EMP_CODI, AUD_USUA, AUD_ESTA, AUD_UFAC, ITE_CONT, PRO_CONT, DTR_ACEP) ");
            sql.Append(" SELECT EMP_CODI, @AUD_USUA, @AUD_ESTA, @AUD_UFAC, ITE_CONT, @PRO_CONT, DTR_ACEP ");
            sql.Append(" FROM CT_REVTD ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REV_CONT = @REV_CONT ");

            List <Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@PRO_CONT", pro_cont));
            parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@AUD_ESTA", "A"));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int insertCtAcxpr(int rev_cont, int pro_cont, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            DateTime date = DateTime.Now;

            sql.Append(" INSERT INTO CT_ACXPR(AUD_ESTA, AUD_UFAC, AUD_USUA, EMP_CODI, ARB_CONT, PRO_CONT) ");
            sql.Append(" SELECT @AUD_ESTA, @AUD_UFAC, @AUD_USUA, EMP_CODI, ARB_CONT, @PRO_CONT ");
            sql.Append(" FROM CT_REVAC ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REV_CONT = @REV_CONT ");

            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@PRO_CONT", pro_cont));
            parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
            parametros.Add(new Parameter("@AUD_UFAC", date));
            parametros.Add(new Parameter("@AUD_ESTA", "A"));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public int insertCtDocpr(int rev_cont, int pro_cont, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            DateTime date = DateTime.Now;
            DAOCtConsu daoCtconsu = new DAOCtConsu();

            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
                   
            sql.Append(" SELECT * ");
            sql.Append(" FROM CT_REVDO ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REV_CONT = @REV_CONT ");

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            ds = conection.GetDataSet(pTOContext, sql.ToString(), parametros.ToArray());

            if (ds.Tables[0].Rows.Count > 0)
            {
                parametros.Add(new Parameter("@PRO_CONT", pro_cont));
                parametros.Add(new Parameter("@AUD_USUA", "SEVEN"));
                parametros.Add(new Parameter("@AUD_UFAC", date));
                parametros.Add(new Parameter("@AUD_ESTA", "A"));

                foreach (DataRow rw in ds.Tables[0].Rows)
                {
                    int doc_cont = GetCont(emp_codi);
                    
                    sql = new StringBuilder();
                    sql.Append(" INSERT INTO CT_DOCPR(AUD_ESTA, AUD_USUA, AUD_UFAC, EMP_CODI, DOC_CONT, PRO_CONT, PRO_NREG, PRO_DDOC, PRO_FENT, PRO_FVEN, PRO_OBSE) ");
                    sql.Append(" SELECT @AUD_ESTA, @AUD_USUA, @AUD_UFAC, EMP_CODI," + doc_cont + " , @PRO_CONT, PRO_NREG, PRO_DDOC, PRO_FENT, PRO_FVEN, PRO_OBSE ");
                    sql.Append(" FROM CT_REVDO ");
                    sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
                    sql.Append(" AND REV_CONT = @REV_CONT ");
                    sql.Append(" AND DOC_CONT = " + rw["DOC_CONT"].ToString());

                    pTOContext = new OTOContext();
                    var connection = DBFactory.GetDB(pTOContext);
                    connection.Insert(pTOContext, sql.ToString(), parametros.ToArray());
                }
            }
            return 0;
        }

        public int GetCont(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("SELECT MAX(DOC_CONT) + 1 FROM CT_DOCPR WHERE EMP_CODI= " + emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString());
            if (result.ToString() == "")
                return 1;
            return result.AsInt();
        }

        public string getSendMailTo(int emp_codi, int rev_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT PRO_MAIL");
            sql.Append(" FROM CT_REVPR");
            sql.Append(" WHERE REV_CONT = @REV_CONT");
            sql.Append(" AND EMP_CODI = @EMP_CODI");

            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@REV_CONT", rev_cont));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString(), parametros.ToArray());
            return result.ToString();
        }
    }
}