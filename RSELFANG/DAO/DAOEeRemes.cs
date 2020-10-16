using SevenFramework.DataBase;
using System.Collections.Generic;
using RSELFANG.TO;
using System.Text;
using System.Configuration;
using System;
using Ophelia;
using Ophelia.DataBase;
using Ophelia.Comun;

namespace RSELFANG.DAO
{
    public class DAOEeRemes
    {
        public Eeremes GetInfoFaclien(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE, TIP_NOMB, CLI_CODA, CLI_NOCO, TER_MAIL, TER_CELU, DATEDIFF(YEAR, TER_FENA, GETDATE()) CLI_EDAD, ");
            sql.Append(" CASE WHEN CLI_GENE = 'M' THEN 'Masculino' WHEN CLI_GENE = 'F' THEN 'Femenino' ELSE 'No Aplica' END CLI_GENE, ");
            sql.Append(" TER_NTEL, AFI_CATE, CASE WHEN AFI_ESTA = 'A' THEN 'Activo' WHEN AFI_ESTA = 'I' THEN 'Inactivo' WHEN AFI_ESTA='F' THEN 'Fallecido' ELSE '' END AFI_ESTA, ");
            sql.Append(" CONVERT(VARCHAR(50),GN_PARAM.PAR_PTDA) PAR_PTDA, CASE WHEN GN_TERCE.TER_AUDP = 'S' THEN 1 ELSE 0 END TER_AUDP ");
            sql.Append(" FROM FA_CLIEN ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = FA_CLIEN.TIP_CODI ");
            sql.Append(" INNER JOIN GN_TERCE ON GN_TERCE.TER_CODI = FA_CLIEN.TER_CODI ");
            sql.Append(" AND GN_TERCE.EMP_CODI = FA_CLIEN.EMP_CODI ");
            sql.Append(" LEFT JOIN SU_AFILI ON SU_AFILI.AFI_DOCU = FA_CLIEN.CLI_CODA ");
            sql.Append(" AND SU_AFILI.EMP_CODI = FA_CLIEN.EMP_CODI ");
            sql.Append(" INNER JOIN GN_PARAM ON GN_PARAM.EMP_CODI = FA_CLIEN.EMP_CODI ");
            sql.Append(" WHERE FA_CLIEN.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND FA_CLIEN.CLI_CODA = @CLI_CODA ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoTerce(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE,TIP_NOMB,TER_CODA CLI_CODA, TER_NOCO CLI_NOCO, TER_MAIL, TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" '' CLI_GENE,   ");
            sql.Append(" TER_NTEL, '' AFI_CATE,''AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM GN_TERCE ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = GN_TERCE.TIP_CODI   ");
            sql.Append(" WHERE GN_TERCE.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND GN_TERCE.TER_CODA = @CLI_CODA  ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoRpauni(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT '' TIP_ABRE,'' TIP_NOMB,RPA_CODI CLI_CODA, RPA_NOMB + ' ' + RPA_APEL CLI_NOCO, '' TER_MAIL, '' TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" '' CLI_GENE, '' TER_NTEL, '' AFI_CATE,'' AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM SO_RPAUI   ");
            sql.Append(" WHERE SO_RPAUI.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SO_RPAUI.RPA_CODI = @CLI_CODA   ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoDetin(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE, TIP_NOMB, DET_CODI CLI_CODA, DET_NOMB + ' ' + DET_APE1 + ' ' + DET_APE2 CLI_NOCO,  ");
            sql.Append("  DET_CORR TER_MAIL, DET_CELU TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" CASE WHEN DET_GENE='F' THEN 'Femenino'  WHEN DET_GENE='M' THEN 'Masculino' ELSE '' END CLI_GENE, '' TER_NTEL, '' AFI_CATE,'' AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM AE_DETIN ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = AE_DETIN.TIP_CODI   ");
            sql.Append(" WHERE AE_DETIN.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND AE_DETIN.DET_CODI = @CLI_CODA  ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoInvit(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT '' TIP_ABRE,'' TIP_NOMB,INV_CODI CLI_CODA,INV_NOMB + ' ' + INV_APEL CLI_NOCO, '' TER_MAIL, '' TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" '' CLI_GENE, '' TER_NTEL, '' AFI_CATE,'' AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM SO_INVIT ");
            sql.Append(" WHERE SO_INVIT.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SO_INVIT.INV_CODI = @CLI_CODA ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoLisev(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT '' TIP_ABRE,'' TIP_NOMB,DLI_IDIN CLI_CODA,DLI_NOCO CLI_NOCO, '' TER_MAIL, '' TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" '' CLI_GENE, '' TER_NTEL, '' AFI_CATE,'' AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM EC_LISEV ");
            sql.Append(" WHERE EC_LISEV.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND EC_LISEV.DLI_IDIN = @CLI_CODA   ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public Eeremes GetInfoAsise(int emp_codi, string cli_coda)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT '' TIP_ABRE,'' TIP_NOMB,ASI_CODI CLI_CODA,ASI_NOMB + ' ' + ASI_APEL CLI_NOCO, ASI_MAIL TER_MAIL, ASI_TELE TER_CELU,0 CLI_EDAD,  ");
            sql.Append(" '' CLI_GENE, '' TER_NTEL, '' AFI_CATE,'' AFI_ESTA,   ");
            sql.Append(" '' PAR_PTDA, 0 TER_AUDP   ");
            sql.Append(" FROM EE_ASISE ");
            sql.Append(" WHERE EE_ASISE.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND EE_ASISE.ASI_CODI = @CLI_CODA    ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
            return new DbConnection().Get<Eeremes>(sql.ToString(), sqlparams);
        }

        public int insertEeremes(EeReenc eereenc, int emp_codi)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("INSERT INTO EE_REMES(REM_CONT, CLI_CODA, ITE_SERV, ITE_MORE, EMP_CODI, AUD_USUA, AUD_ESTA, AUD_UFAC,REM_FECH)");
                sql.Append("VALUES(@REM_CONT, @CLI_CODA, @ITE_SERV, @ITE_MORE, @EMP_CODI, @AUD_USUA, @AUD_ESTA, @AUD_UFAC,@REM_FECH)");

                int rem_cont = GetCont(emp_codi, "EE_REMES");
                List<SQLParams> sqlparams = new List<SQLParams>();
                sqlparams.Add(new SQLParams("REM_CONT", rem_cont));
                sqlparams.Add(new SQLParams("CLI_CODA", eereenc.cli_coda));
                sqlparams.Add(new SQLParams("ITE_SERV", eereenc.ree_serv));
                sqlparams.Add(new SQLParams("ITE_MORE", eereenc.ree_more));
                sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlparams.Add(new SQLParams("AUD_USUA", "SEVEN"));
                sqlparams.Add(new SQLParams("AUD_ESTA", "A"));
                sqlparams.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                sqlparams.Add(new SQLParams("REM_FECH", DateTime.Now));
                new DbConnection().Insert(sql.ToString(), false, sqlparams);
                return rem_cont;
            }
            catch (Exception ex)
            {
                return -1;
            }           
        }

        public int GetCont(int emp_codi, string table)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("SELECT ISNULL(MAX(REM_CONT),0) + 1 REM_CONT FROM " + table + " WHERE EMP_CODI= " + emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString());
            if (result.ToString() == "")
                return 1;
            return result.AsInt();
        }

        public int updateTratamientoClient(int emp_codi, string cli_coda)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE FA_CLIEN ");
                sql.Append(" SET CLI_AUDP = CASE WHEN CLI_AUDP = 'N' THEN 'S' ELSE 'N' END ");
                sql.Append(" WHERE CLI_CODA = @CLI_CODA ");
                sql.Append(" AND EMP_CODI = @EMP_CODI ");
                List<SQLParams> sqlparams = new List<SQLParams>();
                sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
                sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
                //sqlparams.Add(new SQLParams("AUD_USUA", "SEVEN"));
                //sqlparams.Add(new SQLParams("AUD_ESTA", "A"));
                //sqlparams.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                new DbConnection().Update(sql.ToString(), sqlparams);
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public int updateTratamientoTerce(int emp_codi, string cli_coda)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" UPDATE A ");
                sql.Append(" SET A.TER_AUDP = B.CLI_AUDP ");
                sql.Append(" FROM GN_TERCE A ");
                sql.Append(" INNER JOIN FA_CLIEN B ON A.TER_CODI = B.TER_CODI ");
                sql.Append(" AND A.EMP_CODI = B.EMP_CODI ");
                sql.Append(" WHERE B.CLI_CODA = @CLI_CODA  ");
                sql.Append(" AND B.EMP_CODI = @EMP_CODI ");
                List<SQLParams> sqlparams = new List<SQLParams>();
                sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlparams.Add(new SQLParams("CLI_CODA", cli_coda));
                //sqlparams.Add(new SQLParams("AUD_USUA", "SEVEN"));
                //sqlparams.Add(new SQLParams("AUD_ESTA", "A"));
                //sqlparams.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                new DbConnection().Update(sql.ToString(), sqlparams);
                return 0;
            }
            catch (Exception ex)
            {
                return 1;
            }
        }

        public int GetInfoValidEnc(string cli_coda, int ite_serv, int emp_codi, string redEnc)
        {
            StringBuilder sql = new StringBuilder();
            List<Parameter> parametros = new List<Parameter>();
            sql.Append(" SELECT REM_CONT ");
            sql.Append(" FROM EE_REMES ");
            sql.Append(" WHERE CLI_CODA = @CLI_CODA ");
            sql.Append(" AND ITE_SERV = @ITE_SERV ");
            sql.Append(" AND EMP_CODI = @EMP_CODI ");
            sql.Append(" AND REM_CONT "); 
            sql.Append(" IN (   ");
            sql.Append("      SELECT REM_CONT FROM EE_RESEN WHERE EMP_CODI = @EMP_CODI ");
            sql.Append("      UNION ");
            sql.Append("      SELECT REM_CONT FROM EE_RESEM WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" ) ");

            if (redEnc == "N")
            {
                sql.Append(" AND CONVERT(VARCHAR,REM_FECH,103) = CONVERT(VARCHAR,GETDATE(),103) ");                
            }
                        
            parametros.Add(new Parameter("@CLI_CODA", cli_coda));
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@ITE_SERV", ite_serv));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString(), parametros.ToArray());
            if (result == null)
                return 0;
            return result.AsInt();
        }
    }
}

