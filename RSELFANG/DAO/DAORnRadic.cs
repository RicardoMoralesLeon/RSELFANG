using System.Collections.Generic;
using System.Data;
using System.Text;
using Ophelia;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;

namespace RSELFANG.DAO
{
    public class DAORnRadic
    {        
        public List<ArTiapo> getListArTiapo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIA_CONT, TIA_CODI, TIA_NOMB  ");
            sql.Append(" FROM AR_TIAPO ");
            List<SQLParams> sqlparams = new List<SQLParams>();            
            return new DbConnection().GetList<ArTiapo>(sql.ToString(), sqlparams);
        }

        public List<ArApovo> getListArApovo()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TA.TIA_CONT,TA.TIA_CODI,TA.TIA_NOMB,TD.TIP_CODI,TD.TIP_NOMB, ");
            sql.Append(" AP.EMP_CODI, AP.APO_CONT,AP.APO_CODA,AP.APO_RAZS, AP.APO_ESTD");
            sql.Append(" FROM AR_APOVO AP ");
            sql.Append(" INNER JOIN AR_TIAPO TA ON TA.EMP_CODI = AP.EMP_CODI ");
            sql.Append(" AND TA.TIA_CONT = AP.TIA_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO TD ON TD.TIP_CODI = AP.TIP_CODI ");
            sql.Append(" ORDER BY AP.APO_CODA,TA.TIA_NOMB ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            return new DbConnection().GetList<ArApovo>(sql.ToString(), sqlparams);
        }

        public List<RnGrura> getListRnGrura(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RN_GRURA.GRU_CONT ,RN_GRURA.GRU_CODI, RN_GRURA.GRU_NOMB ");
            sql.Append(" FROM RN_GRURA ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<RnGrura>(sql.ToString(), sqlparams);
        }

        public List<RnCraco> getListRnCraco(int gru_cont, int emp_codi, string acr_apor, string acr_afil)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RN_CRACO.CRA_CONT, RN_CRACO.CRA_CODI, RN_CRACO.CRA_NOMB, ");
            sql.Append(" GN_ITEMS.ITE_CODI, GN_ITEMS.ITE_NOMB,RN_CRACO.CRA_DEST, RN_CRACO.CRA_CLAR, RN_CRACO.CRA_PRIM,CRA_AFIW ");
            sql.Append(" FROM RN_DGRUR, RN_CRACO, RN_GRURA, GN_ITEMS ");
            sql.Append(" WHERE RN_DGRUR.EMP_CODI = RN_CRACO.EMP_CODI ");
            sql.Append(" AND RN_DGRUR.CRA_CONT = RN_CRACO.CRA_CONT ");
            sql.Append(" AND RN_CRACO.ITE_CONT = GN_ITEMS.ITE_CONT ");
            sql.Append(" AND RN_DGRUR.EMP_CODI = RN_GRURA.EMP_CODI ");
            sql.Append(" AND RN_DGRUR.GRU_CONT = RN_GRURA.GRU_CONT ");
            sql.Append(" AND RN_CRACO.CRA_ESTA = 'A' ");
            sql.Append(" AND RN_CRACO.CRA_TIPR IN('W','A') ");
            sql.Append(" AND RN_GRURA.GRU_CONT = @GRU_CONT ");

            if(acr_apor == "S" && acr_afil == "S")
                sql.Append(" AND RN_CRACO.CRA_DEST IN('P','A','S','F','M') ");
            else if (acr_apor == "S")
                sql.Append(" AND RN_CRACO.CRA_DEST IN('P','A') ");
            else if (acr_afil == "S")
                sql.Append(" AND RN_CRACO.CRA_DEST IN('S','F','M') ");

            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("GRU_CONT", gru_cont));
            return new DbConnection().GetList<RnCraco>(sql.ToString(), sqlparams);
        }
                
        public List<SuMpare> getListSumPare(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();            
            sql.Append(" SELECT SU_MPARE.MPA_CONT, SU_MPARE.MPA_CODI, SU_MPARE.MPA_NOMB ");
            sql.Append(" FROM SU_MPARE ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SuMpare>(sql.ToString(), sqlparams);
        }

        public List<SuAfili> getListSuAfili(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_TRAYE.AFI_CONT, SU_AFILI.TIP_CODI, GN_TIPDO.TIP_NOMB,  SU_AFILI.AFI_DOCU, ");
            sql.Append(" SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, ");
            sql.Append(" SU_AFILI.AFI_FECN, SU_AFILI.AFI_TELE, SU_TRAYE.TRA_ESTA, SU_TRAYE.APO_CONT, ");
            sql.Append(" AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS, AR_APOVO.TIP_CODI TIP_CODA, ");
            sql.Append(" AR_APOVO.TIA_CONT, AR_APOVO.APO_ESTD, SU_TRAYE.TRA_FCHI,SU_TRAYE.TRA_PRIN, SU_TRAYE.TRA_FCHR, ");
            sql.Append(" AR_TIAPO.TIA_CODI,SU_TRAYE.TRA_CONT, AR_APOVO.APO_ORIG ");
            sql.Append(" FROM SU_AFILI, GN_TIPDO, SU_TRAYE ");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI AND AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT ");
            sql.Append(" INNER JOIN AR_TIAPO ON AR_APOVO.EMP_CODI = AR_TIAPO.EMP_CODI AND AR_APOVO.TIA_CONT = AR_TIAPO.TIA_CONT ");
            sql.Append(" WHERE SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" AND SU_TRAYE.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" ORDER BY SU_AFILI.AFI_APE1,SU_AFILI.AFI_APE2,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2, SU_TRAYE.TRA_FCHI DESC, SU_TRAYE.TRA_ESTA ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SuAfili>(sql.ToString(), sqlparams);
        }

        public SuAfili getInfoAdicionalAfili(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_TRAYE.AFI_CONT, SU_AFILI.TIP_CODI, GN_TIPDO.TIP_NOMB,  SU_AFILI.AFI_DOCU, ");
            sql.Append(" SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, ");
            sql.Append(" SU_AFILI.AFI_FECN, SU_AFILI.AFI_TELE, SU_TRAYE.TRA_ESTA, SU_TRAYE.APO_CONT, ");
            sql.Append(" AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS, AR_APOVO.TIP_CODI TIP_CODA, GN_TIPDO2.TIP_NOMB TIP_NOMA, ");
            sql.Append(" AR_APOVO.TIA_CONT, AR_APOVO.APO_ESTD, SU_TRAYE.TRA_FCHI,SU_TRAYE.TRA_PRIN, SU_TRAYE.TRA_FCHR, ");
            sql.Append(" AR_TIAPO.TIA_CODI,TIA_NOMB,SU_TRAYE.TRA_CONT, DSU_TELE , AFI_MAIL, AFI_DIRE, ");
            sql.Append(" SU_AFILI.PAI_CODI,GN_PAISE.PAI_NOMB, ");
            sql.Append(" SU_AFILI.REG_CODI,GN_REGIO.REG_NOMB, ");
            sql.Append(" SU_AFILI.DEP_CODI,GN_DEPAR.DEP_NOMB, ");
            sql.Append(" SU_AFILI.MUN_CODI,GN_MUNIC.MUN_NOMB, ");
            sql.Append(" SU_AFILI.LOC_CODI,GN_LOCAL.LOC_NOMB, ");
            sql.Append(" SU_AFILI.BAR_CODI,GN_BARRI.BAR_NOMB ");
            sql.Append(" FROM SU_AFILI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append(" INNER JOIN SU_TRAYE ON SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI AND AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT ");
            sql.Append(" INNER JOIN AR_TIAPO ON AR_APOVO.EMP_CODI = AR_TIAPO.EMP_CODI AND AR_APOVO.TIA_CONT = AR_TIAPO.TIA_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO GN_TIPDO2 ON GN_TIPDO2.TIP_CODI = AR_APOVO.TIP_CODI ");
            sql.Append(" INNER JOIN AR_DSUCU ON AR_DSUCU.APO_CONT = AR_APOVO.APO_CONT AND AR_DSUCU.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append(" INNER JOIN GN_PAISE ON GN_PAISE.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_REGIO ON GN_REGIO.REG_CODI = SU_AFILI.REG_CODI AND GN_REGIO.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_DEPAR ON GN_DEPAR.DEP_CODI = SU_AFILI.DEP_CODI AND GN_DEPAR.REG_CODI = SU_AFILI.REG_CODI ");
            sql.Append(" AND GN_DEPAR.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_MUNIC ON GN_MUNIC.MUN_CODI = SU_AFILI.MUN_CODI AND GN_MUNIC.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" AND GN_MUNIC.REG_CODI = SU_AFILI.REG_CODI AND GN_MUNIC.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_LOCAL ON GN_LOCAL.LOC_CODI = SU_AFILI.LOC_CODI AND GN_LOCAL.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" AND GN_LOCAL.REG_CODI = SU_AFILI.REG_CODI AND GN_LOCAL.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_BARRI ON GN_BARRI.BAR_CODI = SU_AFILI.BAR_CODI AND GN_BARRI.LOC_CODI = SU_AFILI.LOC_CODI ");
            sql.Append(" AND GN_BARRI.DEP_CODI = SU_AFILI.DEP_CODI AND GN_BARRI.REG_CODI = SU_AFILI.REG_CODI ");
            sql.Append(" AND GN_BARRI.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" WHERE  SU_AFILI.AFI_CONT = @AFI_CONT AND SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" AND SU_TRAYE.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" AND SU_AFILI.EMP_CODI = @EMP_CODI ");
            sql.Append(" ORDER BY SU_AFILI.AFI_APE1,SU_AFILI.AFI_APE2,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2, SU_TRAYE.TRA_FCHI DESC, ");
            sql.Append(" SU_TRAYE.TRA_ESTA ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().Get<SuAfili>(sql.ToString(), sqlparams);
        }

        public string getDigflag(string dig_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DIG_VALO ");
            sql.Append(" FROM GN_DIGFL ");
            sql.Append(" where DIG_CODI = @DIG_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("DIG_CODI", dig_codi));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);
            return ds.Tables[0].Rows[0]["DIG_VALO"].ToString();
        }

        public string getInfoFudCe(int emp_codi, string usu_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            string cen_codi = "";
            sql.Append(" SELECT RN_CENSE.CEN_CODI ");
            sql.Append(" FROM GN_TERCE, RN_FUDCE,RN_CENSE ");
            sql.Append(" WHERE RN_FUDCE.EMP_CODI = GN_TERCE.EMP_CODI ");
            sql.Append(" AND RN_FUDCE.TER_CODI = GN_TERCE.TER_CODI ");
            sql.Append(" AND RN_CENSE.EMP_CODI = RN_FUDCE.EMP_CODI ");
            sql.Append(" AND RN_CENSE.CEN_CONT = RN_FUDCE.CEN_CONT ");
            sql.Append("     AND RN_FUDCE.TER_CODI IN( ");
            sql.Append("     SELECT TER_CODI FROM GN_USUAR ");
            sql.Append("     WHERE USU_CODI = @USU_CODI ");
            sql.Append("     AND EMP_CODI = @EMP_CODI) ");
            sql.Append(" AND GN_TERCE.TER_ACTI = 'A' ");
            sql.Append(" ORDER BY RN_FUDCE.FUD_CONT DESC ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("USU_CODI", usu_codi));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count > 0)
            {
                cen_codi = ds.Tables[0].Rows[0]["CEN_CODI"].ToString();
            }

            return cen_codi;
        }

        public List<Rnradtd> getInforevtd()
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();            
            sql.Append(" SELECT ITE_CONT, ITE_CODI, ITE_NOMB, 0 ITE_CHKD ");
            sql.Append(" FROM GN_ITEMS ");
            sql.Append(" WHERE ITE_ACTI = 'S' ");
            sql.Append(" AND TIT_CONT = 342 ");
            sql.Append(" ORDER BY ITE_CODI ");
            return new DbConnection().GetList<Rnradtd>(sql.ToString(), sqlparams);
        }

        public int updateTratamiento(Rnradtd radtd, int emp_codi, int rad_cont)
        {
            StringBuilder sql = new StringBuilder();

            sql.Append(" UPDATE RN_TRARD");
            sql.Append(" SET TRA_ACEP = @TRA_ACEP");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI");
            sql.Append(" AND RAD_CONT = @RAD_CONT");
            sql.Append(" AND ITE_CONT = @ITE_CONT");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@RAD_CONT", rad_cont));
            parametros.Add(new Parameter("@ITE_CONT", radtd.ite_cont));

            if (radtd.ite_chkd)
                parametros.Add(new Parameter("@TRA_ACEP", "S"));
            else
                parametros.Add(new Parameter("@TRA_ACEP", "N"));

            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            return conection.Update(pTOContext, sql.ToString(), parametros.ToArray());
        }

        public List<RnDdocu> getInfoDocumentos(int cra_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT GN_ITEMS.ITE_CONT,GN_ITEMS.ITE_CODI,GN_ITEMS.ITE_NOMB, 0 DDO_ESIS , 0 DDO_RECB, '' DDO_OBSE ");
            sql.Append(" FROM GN_ITEMS,GN_TITEM,RN_DRDOC,RN_RDOCL,RN_CRACO ");
            sql.Append(" WHERE GN_ITEMS.TIT_CONT = GN_TITEM.TIT_CONT ");
            sql.Append(" AND GN_ITEMS.TIT_CONT = 332 ");
            sql.Append(" AND RN_DRDOC.ITE_DOCU = GN_ITEMS.ITE_CONT ");
            sql.Append(" AND RN_DRDOC.EMP_CODI = RN_RDOCL.EMP_CODI ");
            sql.Append(" AND RN_DRDOC.RDO_CONT = RN_RDOCL.RDO_CONT ");
            sql.Append(" AND RN_RDOCL.EMP_CODI = RN_CRACO.EMP_CODI ");
            sql.Append(" AND RN_RDOCL.CRA_CONT = RN_CRACO.CRA_CONT ");
            sql.Append(" AND RN_CRACO.CRA_CODI = @CRA_CODI ");
            sqlparams.Add(new SQLParams("CRA_CODI", cra_codi));
            return new DbConnection().GetList<RnDdocu>(sql.ToString(), sqlparams);
        }

        public string getNumeroRadicado(int rad_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT RAD_NUME ");
            sql.Append(" FROM RN_RADIC ");
            sql.Append(" WHERE RAD_CONT = @RAD_CONT ");
            sqlparams.Add(new SQLParams("RAD_CONT", rad_cont));
            return new DbConnection().GetDataSet(sql.ToString(), sqlparams).Tables[0].Rows[0]["RAD_NUME"].ToString();
        }

        public string isAport(string ter_coda, int emp_codi, string campo)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT " + campo);
            sql.Append(" FROM GN_ACROL ");
            sql.Append(" INNER JOIN GN_DACRO ON GN_DACRO.ACR_CONT = GN_ACROL.ACR_CONT ");
            sql.Append(" AND GN_DACRO.ACR_CONT = GN_ACROL.ACR_CONT ");
            sql.Append(" WHERE GN_ACROL.TER_CODA = @TER_CODA ");
            sql.Append(" AND GN_DACRO.EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("TER_CODA", ter_coda));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            var result = new DbConnection().ExecuteScalar(sql.ToString(), sqlparams);
            if (result == null)
                return "";
            return (string)result;
        }
    }
}