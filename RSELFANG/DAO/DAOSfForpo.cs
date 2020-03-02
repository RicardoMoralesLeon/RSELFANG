using Ophelia;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOSfForpo
    {
        public int GetInfoForpo(int emp_codi, int afi_cont)
        {
            int for_nume = 0;
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT FOR_NUME FROM SF_FORPO ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND AFI_CONT = @AFI_CONT ");
            sql.Append(" AND FOR_ESTA NOT IN('V','R') ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count > 0)
            {
                for_nume = int.Parse(ds.Tables[0].Rows[0]["FOR_NUME"].ToString());
            }

            return for_nume;
        }

        public string GetSfParam(int emp_codi)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT PAR_FEAB ");
            sql.Append(" FROM SF_PARAM  ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");            
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);
            return ds.Tables[0].Rows[0]["PAR_FEAB"].ToString();
        }

        public List<SfFovisInfo> GetModVi(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_MODVI.MOD_CONT,SF_MODVI.MOD_NOMB,SF_TCONV.TCO_CODI,SF_TCONV.TCO_NOMB, MOD_CSPM ");
            sql.Append(" FROM SF_MODVI,SF_TCONV ");
            sql.Append(" WHERE SF_MODVI.EMP_CODI = SF_TCONV.EMP_CODI ");
            sql.Append(" AND SF_MODVI.TCO_CONT = SF_TCONV.TCO_CONT ");
            sql.Append(" AND SF_MODVI.EMP_CODI = @EMP_CODI ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SfFovisInfo>(sql.ToString(), sqlparams);
        }

        public List<SfRadic> GetInfoRadi(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RN_RADIC.EMP_CODI,RN_RADIC.RAD_NUME,RN_RADIC.RAD_FECH,SU_AFILI.TIP_CODI, ");
            sql.Append("        SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1, ");
            sql.Append("        SU_AFILI.AFI_APE2, SF_FORPO.FOR_CONT ");
            sql.Append(" FROM RN_RADIC ");
            sql.Append(" INNER JOIN SU_AFILI ON RN_RADIC.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND RN_RADIC.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN RN_CRACO ON  RN_RADIC.EMP_CODI = RN_CRACO.EMP_CODI ");
            sql.Append(" AND RN_RADIC.CRA_CONT = RN_CRACO.CRA_CONT ");
            sql.Append(" LEFT JOIN SF_FORPO ON SF_FORPO.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" AND SF_FORPO.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" WHERE RN_RADIC.AFI_CONT > 0 ");
            sql.Append(" AND RN_RADIC.RAD_ESTA = 'R' ");
            sql.Append(" AND RN_CRACO.CRA_DEST = 'F' ");
            sql.Append(" AND RN_RADIC.EMP_CODI = @EMP_CODI ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SfRadic>(sql.ToString(), sqlparams);
        }

        public List<SfPostu> GetInfoIdPostulante(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.EMP_CODI,SU_AFILI.TIP_CODI,GN_TIPDO.TIP_NOMB, ");
            sql.Append("              SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1, ");
            sql.Append("        SU_AFILI.AFI_APE2,SU_AFILI.AFI_CONT ");
            sql.Append(" FROM SU_AFILI,GN_TIPDO ");
            sql.Append(" WHERE SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" AND SU_AFILI.EMP_CODI = @EMP_CODI  ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<SfPostu>(sql.ToString(), sqlparams);
        }

        public List<SfPostu> GetInfoIdConyuge(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.EMP_CODI,SU_AFILI.TIP_CODI,GN_TIPDO.TIP_NOMB, ");
            sql.Append("              SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1, ");
            sql.Append("        SU_AFILI.AFI_APE2,SU_AFILI.AFI_CONT ");
            sql.Append(" FROM SU_AFILI,GN_TIPDO ");
            sql.Append(" WHERE SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" AND SU_AFILI.EMP_CODI = @EMP_CODI AND EXISTS(SELECT 1 FROM SU_CONYU ");
            sql.Append("         WHERE SU_CONYU.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append("           AND SU_CONYU.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append("           AND SU_CONYU.CON_PERM = 'S' ");
            sql.Append("           AND SU_CONYU.EMP_CODI = @EMP_CODI ");
            sql.Append("           AND SU_CONYU.AFI_TRAB = @AFI_TRAB)  ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_TRAB", afi_cont));
            return new DbConnection().GetList<SfPostu>(sql.ToString(), sqlparams);
        }
                
        public List<SfPostu> GetInfoIdPerca(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.EMP_CODI,SU_AFILI.TIP_CODI,GN_TIPDO.TIP_NOMB, ");
            sql.Append("              SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1,SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1, ");
            sql.Append("        SU_AFILI.AFI_APE2,SU_AFILI.AFI_CONT ");
            sql.Append(" FROM SU_AFILI,GN_TIPDO ");
            sql.Append(" WHERE SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append("  AND SU_AFILI.EMP_CODI = @EMP_CODI AND EXISTS(SELECT 1 FROM SU_PERCA ");
            sql.Append("         WHERE SU_PERCA.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append("           AND SU_PERCA.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append("           AND SU_PERCA.EMP_CODI = @EMP_CODI ");
            sql.Append("           AND SU_PERCA.AFI_TRAB = @AFI_TRAB) AND SU_AFILI.TIP_CODI <> 0 ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_TRAB", afi_cont));
            return new DbConnection().GetList<SfPostu>(sql.ToString(), sqlparams);
        }

        public sfforpo GetValidInfoPostulante(int emp_codi, int afi_cont)
        {         
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT FOR_NUME FROM SF_FORPO ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append("   AND AFI_CONT = @AFI_CONT ");
            sql.Append("   AND FOR_CONT<>  1 ");
            sql.Append("   AND FOR_ESTA NOT IN('V','R') ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().Get<sfforpo>(sql.ToString(), sqlparams);
        }

        public InfoAportante getInfoAportante(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.TIP_CODI,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, ");
            sql.Append("        SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1,SU_AFILI.AFI_APE2, ");
            sql.Append("        CONVERT(VARCHAR,SU_AFILI.AFI_FECN,103) AFI_FECN, SU_AFILI.AFI_ESCI,SU_AFILI.AFI_CATE, ");
            sql.Append("        SU_AFILI.AFI_GENE,GN_TIPDO.TIP_NOMB,SU_AFILI.AFI_CONT, ");
            sql.Append("        SU_AFILI.AFI_COND,SU_AFILI.AFI_MAIL,SU_AFILI.AFI_TELE, ");
            sql.Append("        SU_AFILI.AFI_DIRE, DATEDIFF(YEAR,SU_AFILI.AFI_FECN,GETDATE()) AFI_EDAD, ");
            sql.Append("        SU_AFILI.PAI_CODI,GN_PAISE.PAI_NOMB,SU_AFILI.REG_CODI,GN_REGIO.REG_NOMB, ");
            sql.Append("        SU_AFILI.DEP_CODI,GN_DEPAR.DEP_NOMB,SU_AFILI.MUN_CODI,GN_MUNIC.MUN_NOMB, ");
            sql.Append("        SU_AFILI.LOC_CODI,GN_LOCAL.LOC_NOMB,GN_BARRI.BAR_CODI,GN_BARRI.BAR_NOMB,  ");
            sql.Append("        COALESCE(SU_CONYU.AFI_CONT, 0) AFI_CONY,COALESCE(GN_ITEMS.ITE_CODI, '0') ITE_CODI_OC, ");
            sql.Append("        GN_ITEMS.ITE_NOMB ITE_NOMB_OC");
            sql.Append("   FROM SU_AFILI ");
            sql.Append("       LEFT OUTER JOIN SU_CONYU ON ");
            sql.Append("          SU_AFILI.EMP_CODI = SU_CONYU.EMP_CODI ");
            sql.Append("      AND SU_AFILI.AFI_CONT = SU_CONYU.AFI_TRAB AND SU_CONYU.CON_PERM = 'S' ");
            sql.Append("     LEFT OUTER JOIN SU_TRAYE ON "); 
            sql.Append("          SU_AFILI.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append("      AND SU_AFILI.AFI_CONT = SU_TRAYE.AFI_CONT AND SU_TRAYE.TRA_PRIN = 'S' ");
            sql.Append("     LEFT OUTER JOIN GN_ITEMS ON ");
            sql.Append("          GN_ITEMS.ITE_CONT = SU_TRAYE.ITE_TIPV, ");
            sql.Append("  GN_TIPDO,GN_PAISE,GN_REGIO,GN_DEPAR,GN_MUNIC,GN_LOCAL,GN_BARRI ");
            sql.Append(" WHERE GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_PAISE.PAI_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_REGIO.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_REGIO.PAI_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_DEPAR.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_DEPAR.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_DEPAR.PAI_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_MUNIC.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_MUNIC.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_MUNIC.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_MUNIC.PAI_CODI ");
            sql.Append("   AND SU_AFILI.LOC_CODI = GN_LOCAL.LOC_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_LOCAL.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_LOCAL.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_LOCAL.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_LOCAL.PAI_CODI ");
            sql.Append("   AND SU_AFILI.LOC_CODI = GN_BARRI.LOC_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_BARRI.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_BARRI.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_BARRI.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_BARRI.PAI_CODI ");
            sql.Append("   AND SU_AFILI.BAR_CODI = GN_BARRI.BAR_CODI ");
            sql.Append("   AND SU_AFILI.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND SU_AFILI.AFI_CONT = @AFI_CONT ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().Get<InfoAportante>(sql.ToString(), sqlparams);
        }


        public InfoAportante getInfoConyugeFromForpo(int emp_codi, int for_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DFOMH.AUD_USUA,SF_DFOMH.AUD_UFAC,SF_DFOMH.EMP_CODI,SF_DFOMH.FOR_CONT,SF_DFOMH.DFO_CONT, SF_DFOMH.AFI_CONT, ");
            sql.Append(" SF_DFOMH.DFO_TIPO,SF_DFOMH.DFO_DOCU,SF_DFOMH.DFO_NOM1,SF_DFOMH.DFO_NOM2, SF_DFOMH.DFO_APE1,SF_DFOMH.DFO_APE2,SF_DFOMH.DFO_GENE, ");
            sql.Append(" SF_DFOMH.DFO_FECN,SF_DFOMH.MPA_CONT, SF_DFOMH.DFO_ESCI,SF_DFOMH.DFO_COND,SF_DFOMH.ITE_TIPP,SF_DFOMH.AUD_ESTA,SF_DFOMH.APO_RAZS, ");
            sql.Append(" SF_DFOMH.DFO_SALA,SF_DFOMH.DFO_IPIL,SU_MPARE.MPA_CODI, SF_DFOMH.ITE_OCUP, SF_DFOMH.APO_CONT,SU_MPARE.MPA_NOMB, ");
            sql.Append(" ITEMS_TP.ITE_CODI ITE_CODI_TP,ITEMS_TP.ITE_NOMB ITE_NOMB_TP,SF_DFOMH.ITE_PARE,ITEMS_PA.ITE_CODI ");
            sql.Append(" ITE_CODI_PA,ITEMS_PA.ITE_NOMB ITE_NOMB_PA, ITEMS_OC.ITE_CODI ITE_CODI_OC,ITEMS_OC.ITE_NOMB ITE_NOMB_OC ");
            sql.Append(" FROM SF_DFOMH ");
            sql.Append(" LEFT OUTER JOIN SU_MPARE ON SF_DFOMH.EMP_CODI = SU_MPARE.EMP_CODI AND SF_DFOMH.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_TP ON SF_DFOMH.ITE_TIPP =ITEMS_TP.ITE_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_PA ON SF_DFOMH.ITE_PARE = ITEMS_PA.ITE_CONT, GN_ITEMS ITEMS_OC ");
            sql.Append(" WHERE SF_DFOMH.EMP_CODI =  @EMP_CODI ");
            sql.Append(" AND SF_DFOMH.FOR_CONT =  @FOR_CONT ");
            sql.Append(" AND SF_DFOMH.DFO_TIPO =  'C' ");
            sql.Append(" AND SF_DFOMH.ITE_OCUP =  ITEMS_OC.ITE_CONT ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("FOR_CONT", for_cont));
            var result = new DbConnection().Get<InfoAportante>(sql.ToString(), sqlparams);
            return result == null ? new InfoAportante() : result;
        }

        public List<InfoNovedades> getInfoNovedades(int emp_codi, int for_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TOP_CODI, TOP_NOMB, RET_NUME, RET_FECH, RET_DESC, RET_ESTA, ROW_NUMBER () OVER(ORDER BY  RET_FECH)  CODIGO,PROGRAMA ");
            sql.Append(" FROM(SELECT GN_TOPER.TOP_CODI, GN_TOPER.TOP_NOMB, SF_RETVO.RET_NUME, SF_RETVO.RET_FECH, SF_RETVO.RET_DESC, SF_RETVO.RET_ESTA, 'SSFRETVO' PROGRAMA ");
            sql.Append(" FROM SF_RETVO, GN_TOPER ");
            sql.Append(" WHERE SF_RETVO.EMP_CODI = GN_TOPER.EMP_CODI AND SF_RETVO.TOP_CODI = GN_TOPER.TOP_CODI ");
            sql.Append(" AND SF_RETVO.EMP_CODI = @EMP_CODI  AND SF_RETVO.FOR_CONT = @FOR_CONT ");
            sql.Append(" UNION ALL SELECT GN_TOPER.TOP_CODI, GN_TOPER.TOP_NOMB, SF_PRORR.PRO_NUME, SF_PRORR.PRO_FECH, SF_PRORR.PRO_DESC, SF_PRORR.PRO_ESTA, 'SSFPRORR' PROGRAMA ");
            sql.Append(" FROM SF_PRORR, GN_TOPER ");
            sql.Append(" WHERE SF_PRORR.EMP_CODI = GN_TOPER.EMP_CODI AND SF_PRORR.TOP_CODI = GN_TOPER.TOP_CODI ");
            sql.Append(" AND SF_PRORR.EMP_CODI = @EMP_CODI  AND SF_PRORR.FOR_CONT = @FOR_CONT ");
            sql.Append(" UNION ALL SELECT GN_TOPER.TOP_CODI, GN_TOPER.TOP_NOMB, SF_SOCRM.SOC_NUME, SF_SOCRM.SOC_FECH, SF_SOCRM.SOC_DESC, SF_SOCRM.SOC_ESTA, 'SSFSOCRM' PROGRAMA ");
            sql.Append(" FROM SF_SOCRM, GN_TOPER, SF_CRMIN ");
            sql.Append(" WHERE SF_SOCRM.EMP_CODI = GN_TOPER.EMP_CODI AND SF_SOCRM.TOP_CODI = GN_TOPER.TOP_CODI AND SF_SOCRM.EMP_CODI = SF_CRMIN.EMP_CODI ");
            sql.Append(" AND SF_SOCRM.CRM_CONT = SF_CRMIN.CRM_CONT AND SF_CRMIN.EMP_CODI =  @EMP_CODI   AND SF_CRMIN.FOR_CONT = @FOR_CONT ");
            sql.Append(" UNION ALL SELECT GN_TOPER.TOP_CODI, GN_TOPER.TOP_NOMB, SF_CRMIN.CRM_NUME, SF_CRMIN.CRM_FECH, SF_CRMIN.CRM_DESC, SF_CRMIN.CRM_ESTA, 'SSFCRMIN' PROGRAMA ");
            sql.Append(" FROM SF_CRMIN, GN_TOPER ");
            sql.Append(" WHERE SF_CRMIN.EMP_CODI = GN_TOPER.EMP_CODI AND SF_CRMIN.TOP_CODI = GN_TOPER.TOP_CODI ");
            sql.Append(" AND SF_CRMIN.EMP_CODI = @EMP_CODI  AND SF_CRMIN.FOR_CONT = @FOR_CONT) T ");
            sql.Append(" ORDER BY RET_FECH ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("FOR_CONT", for_cont));
            return new DbConnection().GetList<InfoNovedades>(sql.ToString(), sqlparams);
        }

        public List<InfoTrayectoria> getInfoTrayectorias(int emp_codi, int for_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DFORD.AUD_ESTA,SF_DFORD.AUD_USUA,SF_DFORD.AUD_UFAC, ");
            sql.Append(" SF_DFORD.EMP_CODI,SF_DFORD.FOR_CONT,SF_DFORD.RAD_CONT, ");
            sql.Append(" SF_DFORD.DFO_FECH,RN_RADIC.RAD_NUME,RN_RADIC.RAD_FECH, ");
            sql.Append(" RN_CRACO.CRA_CODI,RN_CRACO.CRA_NOMB , ");
            sql.Append(" ROW_NUMBER() OVER(ORDER BY SF_DFORD.AUD_UFAC DESC) SECUENCIA ");
            sql.Append(" FROM SF_DFORD,RN_RADIC,RN_CRACO ");
            sql.Append(" WHERE SF_DFORD.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" AND SF_DFORD.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_CRACO.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" AND RN_CRACO.CRA_CONT = RN_RADIC.CRA_CONT ");
            sql.Append(" AND SF_DFORD.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SF_DFORD.FOR_CONT = @FOR_CONT ");
            sql.Append(" ORDER BY SF_DFORD.AUD_UFAC ASC ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("FOR_CONT", for_cont));
            return new DbConnection().GetList<InfoTrayectoria>(sql.ToString(), sqlparams);
        }

        public List<InfoSuPerca> getInfoSuPerca(int emp_codi, int for_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DFOMH.AUD_USUA,SF_DFOMH.AUD_UFAC,SF_DFOMH.EMP_CODI,SF_DFOMH.FOR_CONT,SF_DFOMH.DFO_CONT, ");
            sql.Append(" SF_DFOMH.AFI_CONT,SF_DFOMH.DFO_TIPO,SF_DFOMH.DFO_DOCU,SF_DFOMH.DFO_NOM1,SF_DFOMH.DFO_NOM2, ");
            sql.Append(" SF_DFOMH.DFO_APE1,SF_DFOMH.DFO_APE2,SF_DFOMH.DFO_GENE,SF_DFOMH.DFO_FECN,SF_DFOMH.MPA_CONT, ");
            sql.Append(" SF_DFOMH.DFO_ESCI,SF_DFOMH.DFO_COND,SF_DFOMH.ITE_TIPP,SF_DFOMH.AUD_ESTA,SF_DFOMH.APO_RAZS, ");
            sql.Append(" SF_DFOMH.DFO_SALA,SF_DFOMH.DFO_IPIL,SU_MPARE.MPA_CODI, SF_DFOMH.ITE_OCUP, SF_DFOMH.APO_CONT, ");
            sql.Append(" SU_MPARE.MPA_NOMB,ITEMS_TP.ITE_CODI ITE_CODI_TP, ITEMS_TP.ITE_NOMB ITE_NOMB_TP, ");
            sql.Append(" SF_DFOMH.ITE_PARE,ITEMS_PA.ITE_CODI ITE_CODI_PA, ITEMS_PA.ITE_NOMB ITE_NOMB_PA, ");
            sql.Append(" ITEMS_OC.ITE_CODI ITE_CODI_OC, ITEMS_OC.ITE_NOMB ITE_NOMB_OC ");
            sql.Append(" FROM SF_DFOMH ");
            sql.Append(" LEFT OUTER JOIN SU_MPARE ON SF_DFOMH.EMP_CODI = SU_MPARE.EMP_CODI AND SF_DFOMH.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_TP ON SF_DFOMH.ITE_TIPP = ITEMS_TP.ITE_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_PA ON SF_DFOMH.ITE_PARE = ITEMS_PA.ITE_CONT, GN_ITEMS ITEMS_OC ");
            sql.Append(" WHERE SF_DFOMH.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SF_DFOMH.FOR_CONT = @FOR_CONT ");
            sql.Append(" AND SF_DFOMH.DFO_TIPO = 'P' ");
            sql.Append(" AND SF_DFOMH.ITE_OCUP = ITEMS_OC.ITE_CONT ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("FOR_CONT", for_cont));
            return new DbConnection().GetList<InfoSuPerca>(sql.ToString(), sqlparams);
        }

        public List<InfoOtrosMiembros> getInfoMiembros(int emp_codi, int for_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DFOMH.AUD_USUA,SF_DFOMH.AUD_UFAC,SF_DFOMH.EMP_CODI,SF_DFOMH.FOR_CONT,SF_DFOMH.DFO_CONT, ");
            sql.Append(" SF_DFOMH.AFI_CONT,SF_DFOMH.DFO_TIPO,SF_DFOMH.DFO_DOCU,SF_DFOMH.DFO_NOM1,SF_DFOMH.DFO_NOM2, ");
            sql.Append(" SF_DFOMH.DFO_APE1,SF_DFOMH.DFO_APE2,SF_DFOMH.DFO_GENE,SF_DFOMH.DFO_FECN,SF_DFOMH.MPA_CONT, ");
            sql.Append(" SF_DFOMH.DFO_ESCI,SF_DFOMH.DFO_COND,SF_DFOMH.ITE_TIPP,SF_DFOMH.AUD_ESTA,SF_DFOMH.APO_RAZS, ");
            sql.Append(" SF_DFOMH.DFO_SALA,SF_DFOMH.DFO_IPIL,SU_MPARE.MPA_CODI, SF_DFOMH.ITE_OCUP, SF_DFOMH.APO_CONT, ");
            sql.Append(" SU_MPARE.MPA_NOMB,ITEMS_TP.ITE_CODI ITE_CODI_TP, ITEMS_TP.ITE_NOMB ITE_NOMB_TP, ");
            sql.Append(" SF_DFOMH.ITE_PARE,ITEMS_PA.ITE_CODI ITE_CODI_PA, ITEMS_PA.ITE_NOMB ITE_NOMB_PA, ");
            sql.Append(" ITEMS_OC.ITE_CODI ITE_CODI_OC, ITEMS_OC.ITE_NOMB ITE_NOMB_OC ");
            sql.Append(" FROM SF_DFOMH ");
            sql.Append(" LEFT OUTER JOIN SU_MPARE ON SF_DFOMH.EMP_CODI = SU_MPARE.EMP_CODI AND SF_DFOMH.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_TP ON SF_DFOMH.ITE_TIPP = ITEMS_TP.ITE_CONT ");
            sql.Append(" LEFT OUTER JOIN GN_ITEMS ITEMS_PA ON SF_DFOMH.ITE_PARE = ITEMS_PA.ITE_CONT, GN_ITEMS ITEMS_OC ");
            sql.Append(" WHERE SF_DFOMH.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SF_DFOMH.FOR_CONT = @FOR_CONT ");
            sql.Append(" AND SF_DFOMH.DFO_TIPO = 'O' ");
            sql.Append(" AND SF_DFOMH.ITE_OCUP = ITEMS_OC.ITE_CONT ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("FOR_CONT", for_cont));
            return new DbConnection().GetList<InfoOtrosMiembros>(sql.ToString(), sqlparams);
        }
        
        public sfdmodv getInfoModvi(int emp_codi, string mod_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DMODV.DMO_RSMD,SF_DMODV.DMO_RSMH,SF_DMODV.DMO_FSVS ");
            sql.Append(" FROM SF_MODVI,SF_DMODV ");
            sql.Append(" WHERE SF_MODVI.EMP_CODI = SF_DMODV.EMP_CODI ");
            sql.Append(" AND SF_MODVI.MOD_CONT = SF_DMODV.MOD_CONT ");
            sql.Append(" AND SF_MODVI.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SF_MODVI.MOD_CONT = @MOD_CONT ");
            sql.Append(" AND 1 BETWEEN SF_DMODV.DMO_RSMD AND SF_DMODV.DMO_RSMH ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("MOD_CONT", mod_cont));
            return new DbConnection().Get<sfdmodv>(sql.ToString(), sqlparams);
        }

        public double getSalarioPostul(int emp_codi, int afi_cont)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            double drp_salb = 0;

            sql.Append(" SELECT SUM(DRP_SALB) DRP_SALB FROM( ");
            sql.Append("  SELECT A.EMP_CODI, B.AFI_CONT, A.APO_CONT, MAX(B.DRP_SALB) DRP_SALB ");
            sql.Append("  FROM AR_RPILA A ");
            sql.Append("  INNER JOIN AR_DRPIL B ON A.EMP_CODI= B.EMP_CODI AND A.RPI_CONT= B.RPI_CONT ");
            sql.Append("  INNER JOIN SU_TRAYE C ON B.EMP_CODI= C.EMP_CODI AND B.AFI_CONT= C.AFI_CONT AND C.TRA_ESTA= 'A' AND A.APO_CONT= C.APO_CONT ");
            sql.Append("  INNER JOIN (SELECT A.EMP_CODI, B.AFI_CONT, A.APO_CONT, MAX(RPI_PERI) RPI_PERI ");
            sql.Append("              FROM AR_RPILA A ");
            sql.Append("              INNER JOIN AR_DRPIL B ON A.EMP_CODI= B.EMP_CODI AND A.RPI_CONT= B.RPI_CONT ");
            sql.Append("              INNER JOIN SU_TRAYE C ON B.EMP_CODI= C.EMP_CODI AND B.AFI_CONT= C.AFI_CONT AND C.TRA_ESTA= 'A' AND A.APO_CONT= C.APO_CONT ");
            sql.Append("              WHERE A.EMP_CODI= @EMP_CODI  AND B.AFI_CONT=  @AFI_CONT AND A.RPI_ESTA= 'A' ");
            sql.Append("              GROUP BY A.EMP_CODI, B.AFI_CONT, A.APO_CONT) RPILA_AR ON ");
            sql.Append("         RPILA_AR.EMP_CODI = A.EMP_CODI ");
            sql.Append("     AND RPILA_AR.AFI_CONT = B.AFI_CONT ");
            sql.Append("     AND RPILA_AR.APO_CONT = A.APO_CONT ");
            sql.Append("     AND RPILA_AR.RPI_PERI = A.RPI_PERI ");
            sql.Append("  WHERE A.EMP_CODI = @EMP_CODI  AND B.AFI_CONT = @AFI_CONT ");
            sql.Append("  GROUP BY A.EMP_CODI,B.AFI_CONT,A.APO_CONT) T ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count > 0)
                if (ds.Tables[0].Rows[0]["DRP_SALB"].ToString() != "")
                    drp_salb = double.Parse(ds.Tables[0].Rows[0]["DRP_SALB"].ToString());

            return drp_salb;
        }

        public rnradic GetInfoRnRadi(int emp_codi, int rad_nume)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RN_RADIC.RAD_CONT,SU_AFILI.AFI_DOCU,RN_RADIC.RAD_ESTA, ");
            sql.Append("        RN_CRACO.CRA_DEST,SU_AFILI.AFI_CONT ");
            sql.Append(" FROM RN_RADIC,SU_AFILI,RN_CRACO ");
            sql.Append(" WHERE RN_RADIC.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append("   AND RN_RADIC.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append("   AND RN_RADIC.EMP_CODI = RN_CRACO.EMP_CODI ");
            sql.Append("   AND RN_RADIC.CRA_CONT = RN_CRACO.CRA_CONT ");
            sql.Append("   AND RN_RADIC.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND RN_RADIC.RAD_NUME = @RAD_NUME ");
            sql.Append("   AND RN_RADIC.AFI_CONT > 0 ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RAD_NUME", rad_nume));
            return new DbConnection().Get<rnradic>(sql.ToString(), sqlparams);
        }

        public Gnmasal GetInfoMasal(int anio)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT MAS_VRSM, MAS_VRSI ");
            sql.Append(" FROM GN_MASAL ");
            sql.Append(" WHERE MAS_ANOP = @MAS_ANOP ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("MAS_ANOP", anio));            
            return new DbConnection().Get<Gnmasal>(sql.ToString(), sqlparams);
        }

        public InfoAportante getInfoConyu(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI_CONY.TIP_CODI,SU_AFILI_CONY.AFI_DOCU,SU_AFILI_CONY.AFI_NOM1, ");
            sql.Append("        SU_AFILI_CONY.AFI_NOM2,SU_AFILI_CONY.AFI_APE1,SU_AFILI_CONY.AFI_APE2, ");
            sql.Append("        CONVERT(VARCHAR,SU_AFILI_CONY.AFI_FECN,103) AFI_FECN,SU_AFILI_CONY.AFI_ESCI,SU_AFILI_CONY.AFI_CATE, ");
            sql.Append("        SU_AFILI_CONY.AFI_GENE,GN_TIPDO.TIP_NOMB,SU_AFILI_CONY.AFI_CONT, ");
            sql.Append("        SU_AFILI_CONY.AFI_COND,SU_AFILI_CONY.AFI_MAIL,SU_AFILI_CONY.AFI_TELE, ");
            sql.Append("        SU_AFILI_CONY.AFI_DIRE,DATEDIFF(YEAR,SU_AFILI_CONY.AFI_FECN,GETDATE()) AFI_EDAD, ");
            sql.Append("        SU_AFILI_CONY.PAI_CODI,GN_PAISE.PAI_NOMB,SU_AFILI_CONY.REG_CODI,GN_REGIO.REG_NOMB, ");
            sql.Append("        SU_AFILI_CONY.DEP_CODI,GN_DEPAR.DEP_NOMB,SU_AFILI_CONY.MUN_CODI,GN_MUNIC.MUN_NOMB, ");
            sql.Append("        SU_AFILI_CONY.LOC_CODI,GN_LOCAL.LOC_NOMB,GN_BARRI.BAR_CODI,GN_BARRI.BAR_NOMB,  ");
            sql.Append("        COALESCE(SU_CONYU.AFI_CONT, 0) AFI_CONY");
            sql.Append("   FROM SU_AFILI ");
            sql.Append("       LEFT OUTER JOIN SU_CONYU ON ");
            sql.Append("          SU_AFILI.EMP_CODI = SU_CONYU.EMP_CODI ");
            sql.Append("      AND SU_AFILI.AFI_CONT = SU_CONYU.AFI_TRAB AND SU_CONYU.CON_PERM = 'S' ");
            sql.Append("         LEFT OUTER JOIN SU_AFILI SU_AFILI_CONY ON ");
            sql.Append("          SU_AFILI_CONY.EMP_CODI = SU_CONYU.EMP_CODI  AND SU_AFILI_CONY.AFI_CONT = SU_CONYU.AFI_CONT ");
            sql.Append("     LEFT OUTER JOIN SU_TRAYE ON ");
            sql.Append("          SU_AFILI_CONY.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append("      AND SU_AFILI_CONY.AFI_CONT = SU_TRAYE.AFI_CONT AND SU_TRAYE.TRA_PRIN = 'S' ");
            sql.Append("     LEFT OUTER JOIN GN_ITEMS ON ");
            sql.Append("          GN_ITEMS.ITE_CONT = SU_TRAYE.ITE_TIPV, ");
            sql.Append("  GN_TIPDO,GN_PAISE,GN_REGIO,GN_DEPAR,GN_MUNIC,GN_LOCAL,GN_BARRI ");
            sql.Append(" WHERE GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_PAISE.PAI_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_REGIO.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_REGIO.PAI_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_DEPAR.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_DEPAR.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_DEPAR.PAI_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_MUNIC.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_MUNIC.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_MUNIC.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_MUNIC.PAI_CODI ");
            sql.Append("   AND SU_AFILI.LOC_CODI = GN_LOCAL.LOC_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_LOCAL.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_LOCAL.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_LOCAL.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_LOCAL.PAI_CODI ");
            sql.Append("   AND SU_AFILI.LOC_CODI = GN_BARRI.LOC_CODI ");
            sql.Append("   AND SU_AFILI.MUN_CODI = GN_BARRI.MUN_CODI ");
            sql.Append("   AND SU_AFILI.DEP_CODI = GN_BARRI.DEP_CODI ");
            sql.Append("   AND SU_AFILI.REG_CODI = GN_BARRI.REG_CODI ");
            sql.Append("   AND SU_AFILI.PAI_CODI = GN_BARRI.PAI_CODI ");
            sql.Append("   AND SU_AFILI.BAR_CODI = GN_BARRI.BAR_CODI ");
            sql.Append("   AND SU_AFILI.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND SU_AFILI.AFI_CONT = @AFI_CONT ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().Get<InfoAportante>(sql.ToString(), sqlparams);
        }

        public InfoEmpresa getInfoEmpre(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            
            sql.Append(" SELECT AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS,AR_TIAPO.TIA_CODI, ");
            sql.Append("        AR_TIAPO.TIA_NOMB,  ");
            sql.Append("        GN_MUNIC.DEP_CODI, GN_DEPAR.DEP_NOMB, ");
            sql.Append("        GN_MUNIC.MUN_CODI,GN_MUNIC.MUN_NOMB, ");
            sql.Append("        AR_DSUCU.DSU_DIRE ");
            sql.Append(" FROM SU_TRAYE, AR_APOVO, AR_TIAPO,AR_SUCUR,AR_DSUCU,GN_MUNIC, GN_DEPAR ");
            sql.Append(" WHERE SU_TRAYE.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append("   AND SU_TRAYE.APO_CONT = AR_APOVO.APO_CONT ");
            sql.Append("   AND AR_TIAPO.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append("   AND AR_TIAPO.TIA_CONT = AR_APOVO.TIA_CONT ");
            sql.Append("   AND SU_TRAYE.TRA_PRIN = 'S' ");
            sql.Append("   AND SU_TRAYE.TRA_ESTA = 'A' ");
            sql.Append("   AND SU_TRAYE.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND SU_TRAYE.AFI_CONT = @AFI_CONT ");
            sql.Append("   AND AR_SUCUR.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND AR_SUCUR.APO_CONT = AR_APOVO.APO_CONT ");
            sql.Append("   AND AR_SUCUR.SUC_PRIC = 'S' ");
            sql.Append("   AND AR_SUCUR.EMP_CODI = AR_DSUCU.EMP_CODI ");
            sql.Append("   AND AR_SUCUR.APO_CONT = AR_DSUCU.APO_CONT ");
            sql.Append("   AND AR_SUCUR.SUC_CONT = AR_DSUCU.SUC_CONT ");
            sql.Append("   AND GN_MUNIC.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append("   AND GN_MUNIC.REG_CODI = AR_DSUCU.REG_CODI ");
            sql.Append("   AND GN_MUNIC.DEP_CODI = AR_DSUCU.DEP_CODI ");
            sql.Append("   AND GN_MUNIC.MUN_CODI = AR_DSUCU.MUN_CODI ");
            sql.Append("   AND GN_DEPAR.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append("   AND GN_DEPAR.REG_CODI = AR_DSUCU.REG_CODI ");
            sql.Append("   AND GN_DEPAR.DEP_CODI = AR_DSUCU.DEP_CODI ");

            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().Get<InfoEmpresa>(sql.ToString(), sqlparams);
        }


        public InfoAportante getInfoPerca(int emp_codi, int afi_trab,int afi_cont, string afi_docu)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.TIP_CODI,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, ");
            sql.Append("         SU_AFILI.AFI_NOM2,SU_AFILI.AFI_APE1,SU_AFILI.AFI_APE2, ");
            sql.Append("         CONVERT(VARCHAR,SU_AFILI.AFI_FECN,103) AFI_FECN,SU_AFILI.AFI_ESCI,SU_AFILI.AFI_CATE, ");
            sql.Append("         SU_AFILI.AFI_GENE,GN_TIPDO.TIP_NOMB,SU_AFILI.AFI_CONT, ");
            sql.Append("         SU_AFILI.AFI_COND,SU_AFILI.AFI_MAIL,SU_AFILI.AFI_TELE, ");
            sql.Append("         SU_AFILI.AFI_DIRE,  DATEDIFF(YEAR, SU_AFILI.AFI_FECN, GETDATE()) AFI_EDAD, ");
            sql.Append("         SU_AFILI.PAI_CODI,GN_PAISE.PAI_NOMB,SU_AFILI.REG_CODI,GN_REGIO.REG_NOMB, ");
            sql.Append("         SU_AFILI.DEP_CODI,GN_DEPAR.DEP_NOMB,SU_AFILI.MUN_CODI,GN_MUNIC.MUN_NOMB, ");
            sql.Append("         SU_AFILI.LOC_CODI,GN_LOCAL.LOC_NOMB,GN_BARRI.BAR_CODI,GN_BARRI.BAR_NOMB, ");
            sql.Append("         COALESCE(SU_CONYU.AFI_CONT, 0) AFI_CONY,COALESCE(GN_ITEMS.ITE_CODI, '0') ITE_CODI_OC, GN_ITEMS.ITE_NOMB ITE_NOMB_OC, ");
            sql.Append("         SU_MPARE.MPA_CONT,SU_MPARE.MPA_NOMB,SU_MPARE.MPA_CODI ");
            sql.Append(" FROM SU_AFILI ");
            sql.Append("     LEFT OUTER JOIN SU_CONYU ON ");
            sql.Append("             SU_AFILI.EMP_CODI = SU_CONYU.EMP_CODI ");
            sql.Append("         AND SU_AFILI.AFI_CONT = SU_CONYU.AFI_TRAB AND SU_CONYU.CON_PERM = 'S' ");
            sql.Append("     LEFT OUTER JOIN SU_TRAYE ON ");
            sql.Append("             SU_AFILI.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append("         AND SU_AFILI.AFI_CONT = SU_TRAYE.AFI_CONT AND SU_TRAYE.TRA_PRIN = 'S' ");
            sql.Append("     LEFT OUTER JOIN GN_ITEMS ON ");
            sql.Append("             GN_ITEMS.ITE_CONT = SU_TRAYE.ITE_TIPV, ");
            sql.Append("     GN_TIPDO,GN_PAISE,GN_REGIO,GN_DEPAR,GN_MUNIC,GN_LOCAL,GN_BARRI ");
            sql.Append("     ,SU_PERCA,SU_MPARE ");
            sql.Append(" WHERE GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_PAISE.PAI_CODI ");
            sql.Append("     AND SU_AFILI.REG_CODI = GN_REGIO.REG_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_REGIO.PAI_CODI ");
            sql.Append("     AND SU_AFILI.DEP_CODI = GN_DEPAR.DEP_CODI ");
            sql.Append("     AND SU_AFILI.REG_CODI = GN_DEPAR.REG_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_DEPAR.PAI_CODI ");
            sql.Append("     AND SU_AFILI.MUN_CODI = GN_MUNIC.MUN_CODI ");
            sql.Append("     AND SU_AFILI.DEP_CODI = GN_MUNIC.DEP_CODI ");
            sql.Append("     AND SU_AFILI.REG_CODI = GN_MUNIC.REG_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_MUNIC.PAI_CODI ");
            sql.Append("     AND SU_AFILI.LOC_CODI = GN_LOCAL.LOC_CODI ");
            sql.Append("     AND SU_AFILI.MUN_CODI = GN_LOCAL.MUN_CODI ");
            sql.Append("     AND SU_AFILI.DEP_CODI = GN_LOCAL.DEP_CODI ");
            sql.Append("     AND SU_AFILI.REG_CODI = GN_LOCAL.REG_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_LOCAL.PAI_CODI ");
            sql.Append("     AND SU_AFILI.LOC_CODI = GN_BARRI.LOC_CODI ");
            sql.Append("     AND SU_AFILI.MUN_CODI = GN_BARRI.MUN_CODI ");
            sql.Append("     AND SU_AFILI.DEP_CODI = GN_BARRI.DEP_CODI ");
            sql.Append("     AND SU_AFILI.REG_CODI = GN_BARRI.REG_CODI ");
            sql.Append("     AND SU_AFILI.PAI_CODI = GN_BARRI.PAI_CODI ");
            sql.Append("     AND SU_AFILI.BAR_CODI = GN_BARRI.BAR_CODI ");
            sql.Append("     AND SU_AFILI.EMP_CODI = @EMP_CODI ");
            sql.Append("     AND SU_AFILI.AFI_DOCU = @AFI_DOCU ");
            sql.Append("     AND SU_PERCA.EMP_CODI = SU_MPARE.EMP_CODI ");
            sql.Append("     AND SU_PERCA.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append("     AND SU_PERCA.EMP_CODI = @EMP_CODI ");
            sql.Append("     AND SU_PERCA.AFI_TRAB = @AFI_TRAB ");
            sql.Append("     AND SU_PERCA.AFI_CONT = @AFI_CONT ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            sqlparams.Add(new SQLParams("AFI_TRAB", afi_trab));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            return new DbConnection().Get<InfoAportante>(sql.ToString(), sqlparams);
        }

        public sfdmodv GetInfoIngresos(int emp_codi, int mod_cont, double for_sala)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_DMODV.DMO_RSMD,SF_DMODV.DMO_RSMH,SF_DMODV.DMO_OPER,SF_DMODV.DMO_FSVS,SF_MODVI.MOD_CSPM ");
            sql.Append(" FROM SF_MODVI,SF_DMODV ");
            sql.Append(" WHERE SF_MODVI.EMP_CODI = SF_DMODV.EMP_CODI ");
            sql.Append("   AND SF_MODVI.MOD_CONT = SF_DMODV.MOD_CONT ");
            sql.Append("   AND SF_MODVI.EMP_CODI = @EMP_CODI ");
            sql.Append("   AND SF_MODVI.MOD_CONT = @MOD_CONT ");
            sql.Append("   AND @FOR_SALA BETWEEN SF_DMODV.DMO_RSMD AND SF_DMODV.DMO_RSMH ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("MOD_CONT", mod_cont));
            sqlparams.Add(new SQLParams("FOR_SALA", for_sala));
            return new DbConnection().Get<sfdmodv>(sql.ToString(), sqlparams);
        }

        public List<sfconec> GetInfoConceptos(int emp_codi, string con_tipo)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SF_CONEC.CON_CONT,SF_CONEC.CON_CODI,SF_CONEC.CON_NOMB, ");
            sql.Append("        SF_CONEC.CON_CALC,SF_CONEC.CAL_PORC,SF_CONEC.CON_ESTA,SF_CONEC.CON_TIPO ");
            sql.Append(" FROM SF_CONEC ");
            sql.Append(" WHERE EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CON_TIPO = @CON_TIPO ");
            sql.Append(" AND CON_ESTA = 'A' ");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("CON_TIPO", con_tipo));
            return new DbConnection().GetList<sfconec>(sql.ToString(), sqlparams);
        }

        public void deletePostulante(int emp_codi, int for_cont)
        {            
            deleteInfoPostulante(emp_codi, for_cont, "SF_DFOIH");
            deleteInfoPostulante(emp_codi, for_cont, "SF_DFOMH");
            deleteInfoPostulante(emp_codi, for_cont, "SF_DDFOR");
            deleteInfoPostulante(emp_codi, for_cont, "SF_DFORE");            
            deleteInfoPostulante(emp_codi, for_cont, "SF_FORPO");
        }

        public void deleteInfoPostulante(int emp_codi, int for_cont, string tabla)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("DELETE FROM " + tabla + " WHERE EMP_CODI = @EMP_CODI AND FOR_CONT= @FOR_CONT ");
            List<Parameter> parametros = new List<Parameter>();
            parametros.Add(new Parameter("@EMP_CODI", emp_codi));
            parametros.Add(new Parameter("@FOR_CONT", for_cont));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            conection.Delete(pTOContext, sql.ToString(), parametros.ToArray());
        }
    }
}