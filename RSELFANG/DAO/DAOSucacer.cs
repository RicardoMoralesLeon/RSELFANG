using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOSucacer
    {
        public ToSucacer GetInfoSSuCacAA(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT ");
            sql.Append("     SU_TRAYE.TRA_FECH, ");
            sql.Append("     AR_APOVO.APO_CONT, ");
            sql.Append("     SU_AFILI_TRAB.AFI_CONT ");
            sql.Append(" FROM ");
            sql.Append("     AR_APOVO, ");
            sql.Append("     SU_TRAYE, ");
            sql.Append("     SU_AFILI SU_AFILI_TRAB ");
            sql.Append(" WHERE ");
            sql.Append("     AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI AND ");
            sql.Append("     AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT AND ");
            sql.Append("     SU_TRAYE.EMP_CODI = SU_AFILI_TRAB.EMP_CODI AND ");
            sql.Append("     SU_TRAYE.AFI_CONT = SU_AFILI_TRAB.AFI_CONT AND ");
            sql.Append("     SU_TRAYE.EMP_CODI = @EMP_CODI  ");
            sql.Append("     AND SU_TRAYE.TRA_ESTA = 'A' ");
            sql.Append("     AND SU_AFILI_TRAB.AFI_DOCU = @TER_CODA ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public ToSucacer GetInfoSSuCacDT(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT SU_AFILI_TRAB.AFI_CONT ");
            sql.Append(" FROM SU_TRAYE, SU_AFILI SU_AFILI_TRAB ");
            sql.Append(" WHERE SU_TRAYE.EMP_CODI = SU_AFILI_TRAB.EMP_CODI AND ");
            sql.Append("       SU_TRAYE.AFI_CONT = SU_AFILI_TRAB.AFI_CONT ");
            sql.Append("       AND SU_AFILI_TRAB.AFI_DOCU = @TER_CODA ");
            sql.Append("       AND SU_AFILI_TRAB.EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public ToSucacer GetInfoSSuCacAT(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT ");
            sql.Append("     SU_AFILI_TRAB.AFI_CONT, SU_AFILI_TRAB.AFI_DOCU, SU_AFILI_TRAB.AFI_NOM1,  ");
            sql.Append("     SU_AFILI_TRAB.AFI_NOM2, SU_AFILI_TRAB.AFI_APE1, SU_AFILI_TRAB.AFI_APE2 ");
            sql.Append(" FROM ");
            sql.Append("     SU_TRAYE, ");
            sql.Append("     SU_AFILI SU_AFILI_TRAB ");
            sql.Append(" WHERE ");
            sql.Append("     SU_TRAYE.EMP_CODI = SU_AFILI_TRAB.EMP_CODI AND ");
            sql.Append("     SU_TRAYE.AFI_CONT = SU_AFILI_TRAB.AFI_CONT ");
            sql.Append(" 	AND SU_TRAYE.EMP_CODI = @EMP_CODI ");
            sql.Append(" 	AND SU_TRAYE.TRA_ESTA = 'A' ");
            sql.Append(" 	AND SU_AFILI_TRAB.AFI_ESTA = 'A'  ");
            sql.Append(" 	AND SU_AFILI_TRAB.AFI_DOCU = @TER_CODA ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public ToSucacer GetInfoSSuCacTD(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT ");
            sql.Append("     SU_AFILI_TRAB.AFI_CONT, SU_AFILI_TRAB.AFI_DOCU, SU_AFILI_TRAB.AFI_NOM1,  ");
            sql.Append("     SU_AFILI_TRAB.AFI_NOM2, SU_AFILI_TRAB.AFI_APE1, SU_AFILI_TRAB.AFI_APE2 ");
            sql.Append(" FROM ");
            sql.Append("     SU_TRAYE, ");
            sql.Append("     SU_AFILI SU_AFILI_TRAB ");
            sql.Append(" WHERE ");
            sql.Append("     SU_TRAYE.EMP_CODI = SU_AFILI_TRAB.EMP_CODI AND ");
            sql.Append("     SU_TRAYE.AFI_CONT = SU_AFILI_TRAB.AFI_CONT AND ");
            sql.Append(" 	SU_TRAYE.EMP_CODI = 102 AND SU_TRAYE.TRA_ESTA = 'D' ");
            sql.Append(" 	AND NOT EXISTS (SELECT TRA_ESTA  ");
            sql.Append(" 	FROM SU_TRAYE A ");
            sql.Append(" 	WHERE A.EMP_CODI = SU_AFILI_TRAB.EMP_CODI ");
            sql.Append(" 	AND A.AFI_CONT = SU_AFILI_TRAB.AFI_CONT ");
            sql.Append(" 	AND A.TRA_ESTA = 'A' )  ");
            sql.Append(" 	AND SU_AFILI_TRAB.AFI_DOCU = @TER_CODA ");
            sql.Append(" 	AND SU_AFILI_TRAB.EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public ToSucacer GetInfoSSuCacDH(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();

            sql.Append(" SELECT ");
            sql.Append("     AR_APOVO.APO_CONT, AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS,  ");
            sql.Append("     SU_AFILI_TRAB.AFI_CONT, SU_AFILI_TRAB.AFI_DOCU, SU_AFILI_TRAB.AFI_NOM1,  ");
            sql.Append("     SU_AFILI_TRAB.AFI_NOM2, SU_AFILI_TRAB.AFI_APE1, SU_AFILI_TRAB.AFI_APE2 ");
            sql.Append(" FROM ");
            sql.Append("     AR_APOVO, ");
            sql.Append("     SU_TRAYE, ");
            sql.Append("     SU_AFILI SU_AFILI_TRAB ");
            sql.Append(" WHERE ");
            sql.Append("     AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI AND ");
            sql.Append("     AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT AND ");
            sql.Append("     SU_TRAYE.EMP_CODI = SU_AFILI_TRAB.EMP_CODI AND ");
            sql.Append("     SU_TRAYE.AFI_CONT = SU_AFILI_TRAB.AFI_CONT AND  ");
            sql.Append(" 	SU_TRAYE.EMP_CODI = @EMP_CODI AND SU_TRAYE.TRA_ESTA = 'D'  ");
            sql.Append(" 	AND NOT EXISTS (SELECT TRA_ESTA FROM SU_TRAYE A  ");
            sql.Append(" 	WHERE A.EMP_CODI = SU_AFILI_TRAB.EMP_CODI   ");
            sql.Append(" 	AND A.AFI_CONT = SU_AFILI_TRAB.AFI_CONT   ");
            sql.Append(" 	AND A.TRA_ESTA = 'A' )  ");
            sql.Append(" 	AND SU_AFILI_TRAB.AFI_DOCU = @TER_CODA ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public ToSucacer GetInfoSSuCaCBE(string ter_coda, int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT ");
            sql.Append("     SU_AFILI.AFI_CONT, SU_AFILI.AFI_DOCU, SU_AFILI.AFI_NOM1,  ");
            sql.Append("     SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2 ");
            sql.Append(" FROM ");
            sql.Append("     SU_AFILI, ");
            sql.Append("     SU_PERCA ");
            sql.Append(" WHERE ");
            sql.Append("     SU_AFILI.EMP_CODI = SU_PERCA.EMP_CODI AND ");
            sql.Append("     SU_AFILI.AFI_CONT = SU_PERCA.AFI_CONT AND ");
            sql.Append(" 	SU_AFILI.EMP_CODI = @EMP_CODI  ");
            sql.Append(" 	AND SU_AFILI.AFI_ESTA = 'A'  ");
            sql.Append(" 	AND SU_PERCA.PER_ESTA = 'A'   ");
            sql.Append(" 	AND SU_AFILI.AFI_DOCU = @TER_CODA ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().Get<ToSucacer>(sql.ToString(), sqlparams);
        }

        public int setInfoTnAfi(int emp_codi, string tna_docu, string tna_nomb)
        {
            int prc_cont = GetCont("SU_TNAFI", "PRC_CONT", emp_codi);
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" INSERT INTO SU_TNAFI(PRC_CONT, EMP_CODI, TNA_DOCU, TNA_NOMB) ");
            sql.Append(" VALUES(@PRC_CONT, @EMP_CODI, @TNA_DOCU, @TNA_NOMB) ");
            sqlparams.Add(new SQLParams("PRC_CONT", prc_cont));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("TNA_DOCU", tna_docu));            
            sqlparams.Add(new SQLParams("TNA_NOMB", tna_nomb));
            var result = new DbConnection().Insert(sql.ToString(), false, sqlparams);
            return prc_cont;
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
    }
}