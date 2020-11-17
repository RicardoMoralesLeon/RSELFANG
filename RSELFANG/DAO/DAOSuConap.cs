using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Ophelia;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;


namespace RSELFANG.DAO
{
    public class DAOSuConap
    {
        public toArApovoInfo getArApovoInfo(int emp_codi, string usu_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT GN_TIPDO.TIP_ABRE, AR_APOVO.APO_CODA, AR_APOVO.APO_RAZS, AR_APOVO.APO_FCHA, ");
            sql.Append(" GN_TIPDO_TER.TIP_ABRE TIP_ABRR, GN_TERCE.TER_CODA, GN_TERCE.TER_NOCO, APO_CONT ");
            sql.Append(" FROM AR_APOVO ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = AR_APOVO.TIP_CODI ");
            sql.Append(" LEFT JOIN GN_TERCE ON GN_TERCE.TER_CODI = AR_APOVO.TER_CODI ");
            sql.Append(" AND AR_APOVO.TER_CODI <> 0 ");
            sql.Append(" LEFT JOIN GN_TIPDO GN_TIPDO_TER ON GN_TIPDO_TER.TIP_CODI = GN_TERCE.TIP_CODI ");
            sql.Append(" WHERE AR_APOVO.APO_CODA = @APO_CODA ");
            sql.Append(" AND AR_APOVO.EMP_CODI = @EMP_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("APO_CODA", usu_codi));
            return new DbConnection().Get<toArApovoInfo>(sql.ToString(), sqlparams);
        }

        public List<toArSucurInfo> getArSucurInfo(int emp_codi, int apo_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT AR_TIPDI.TIP_DESC, AR_DSUCU.DSU_DIRE, GN_PAISE.PAI_NOMB, ");
            sql.Append(" GN_DEPAR.DEP_NOMB, GN_MUNIC.MUN_NOMB, GN_LOCAL.LOC_NOMB,GN_BARRI.BAR_NOMB, ");
            sql.Append(" AR_DSUCU.DSU_TELE, AR_DSUCU.DSU_CELU ");
            sql.Append(" FROM AR_SUCUR ");
            sql.Append(" INNER JOIN AR_DSUCU ON AR_DSUCU.SUC_CONT = AR_SUCUR.SUC_CONT ");
            sql.Append(" INNER JOIN AR_TIPDI ON AR_TIPDI.TIP_CODI = AR_DSUCU.TIP_CODI ");
            sql.Append(" AND AR_TIPDI.EMP_CODI = AR_DSUCU.EMP_CODI ");
            sql.Append(" INNER JOIN GN_PAISE ON GN_PAISE.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append(" INNER JOIN GN_DEPAR ON GN_DEPAR.DEP_CODI = AR_DSUCU.DEP_CODI ");
            sql.Append(" AND GN_DEPAR.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append(" INNER JOIN GN_MUNIC ON GN_MUNIC.MUN_CODI = AR_DSUCU.MUN_CODI ");
            sql.Append(" AND GN_MUNIC.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append(" AND GN_MUNIC.DEP_CODI = AR_DSUCU.DEP_CODI ");
            sql.Append(" INNER JOIN GN_LOCAL ON GN_LOCAL.LOC_CODI = AR_DSUCU.LOC_CODI ");
            sql.Append(" AND GN_LOCAL.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append(" AND GN_LOCAL.DEP_CODI = AR_DSUCU.DEP_CODI ");
            sql.Append(" AND GN_LOCAL.MUN_CODI = AR_DSUCU.MUN_CODI ");
            sql.Append(" INNER JOIN GN_BARRI ON GN_BARRI.BAR_CODI = AR_DSUCU.BAR_CODI ");
            sql.Append(" AND GN_BARRI.PAI_CODI = AR_DSUCU.PAI_CODI ");
            sql.Append(" AND GN_BARRI.DEP_CODI = AR_DSUCU.DEP_CODI ");
            sql.Append(" AND GN_BARRI.MUN_CODI = AR_DSUCU.MUN_CODI ");
            sql.Append(" AND GN_BARRI.LOC_CODI = AR_DSUCU.LOC_CODI ");
            sql.Append(" WHERE AR_SUCUR.APO_CONT = @APO_CONT ");
            sql.Append(" AND AR_SUCUR.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND AR_TIPDI.TIP_CLAS IN('L','C') ");
            sql.Append(" AND AR_SUCUR.SUC_PRIC = 'S' ");            
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("APO_CONT", apo_cont));
            return new DbConnection().GetList<toArSucurInfo>(sql.ToString(), sqlparams);
        }

        public tofiliatrab getInfoAfilitrab(int emp_codi, int tip_codi, string afi_docu, int apo_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SU_AFILI.TIP_CODI,GN_TIPDO.TIP_NOMB,SU_AFILI.AFI_CONT ,GN_TIPDO.TIP_ABRE, SU_AFILI.AFI_DOCU, SU_AFILI.AFI_NOM1, ");
            sql.Append(" SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, ");
            sql.Append(" SU_AFILI.AFI_FECN, SU_TRAYE.TRA_FCHI, SU_TRAYE.TRA_FCHA, SU_AFILI.AFI_DIRE,SU_AFILI.AFI_TELE, ");
            sql.Append(" GN_PAISE.PAI_NOMB, GN_DEPAR.DEP_NOMB, GN_MUNIC.MUN_NOMB, GN_LOCAL.LOC_NOMB,GN_BARRI.BAR_NOMB ");
            sql.Append(" FROM SU_AFILI ");
            sql.Append(" INNER JOIN SU_TRAYE ON SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" AND SU_TRAYE.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT ");
            sql.Append(" AND AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append(" INNER JOIN GN_PAISE ON GN_PAISE.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_DEPAR ON GN_DEPAR.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" AND GN_DEPAR.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" INNER JOIN GN_MUNIC ON GN_MUNIC.MUN_CODI = SU_AFILI.MUN_CODI ");
            sql.Append(" AND GN_MUNIC.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" AND GN_MUNIC.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" INNER JOIN GN_LOCAL ON GN_LOCAL.LOC_CODI = SU_AFILI.LOC_CODI ");
            sql.Append(" AND GN_LOCAL.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" AND GN_LOCAL.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" AND GN_LOCAL.MUN_CODI = SU_AFILI.MUN_CODI ");
            sql.Append(" INNER JOIN GN_BARRI ON GN_BARRI.BAR_CODI = SU_AFILI.BAR_CODI ");
            sql.Append(" AND GN_BARRI.PAI_CODI = SU_AFILI.PAI_CODI ");
            sql.Append(" AND GN_BARRI.DEP_CODI = SU_AFILI.DEP_CODI ");
            sql.Append(" AND GN_BARRI.MUN_CODI = SU_AFILI.MUN_CODI ");
            sql.Append(" AND GN_BARRI.LOC_CODI = SU_AFILI.LOC_CODI ");
            sql.Append(" WHERE AR_APOVO.APO_CONT = @APO_CONT ");
            sql.Append(" AND SU_AFILI.AFI_ESTA = 'A' ");
            sql.Append(" AND SU_AFILI.AFI_DOCU = @AFI_DOCU ");
            sql.Append(" AND SU_AFILI.TIP_CODI = @TIP_CODI ");
            sql.Append(" AND AR_APOVO.EMP_CODI = @EMP_CODI ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("TIP_CODI", tip_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            sqlparams.Add(new SQLParams("APO_CONT", apo_cont));
            return new DbConnection().Get<tofiliatrab>(sql.ToString(), sqlparams);
        }

        public List<toSuperca> getInfoSupercaTrab(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE, SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, "); 
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, MPA_NOMB, MAX(RAD_FECH) RAD_FECH ");
            sql.Append(" FROM SU_PERCA ");
            sql.Append(" INNER JOIN SU_MPARE ON SU_PERCA.EMP_CODI = SU_MPARE.EMP_CODI ");
            sql.Append(" AND SU_PERCA.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_PERCA.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_PERCA.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO ON SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" LEFT JOIN SU_DPERA ON SU_DPERA.PER_CONT = SU_PERCA.PER_CONT ");
            sql.Append(" AND SU_DPERA.EMP_CODI = SU_PERCA.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_RADIC ON RN_RADIC.RAD_CONT = SU_DPERA.RAD_CONT ");
            sql.Append(" AND SU_DPERA.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" WHERE SU_PERCA.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SU_PERCA.AFI_TRAB = @AFI_CONT ");
            sql.Append(" AND SU_PERCA.PER_ESTA = 'A' ");
            sql.Append(" GROUP BY TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2,   ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, MPA_NOMB ");
            sql.Append(" UNION ");
            sql.Append(" SELECT TIP_ABRE, SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2,   ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, 'CONYUGE' MPA_NOMB, MAX(RAD_FECH) RAD_FECH ");
            sql.Append(" FROM SU_CONYU ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_CONYU.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_CONYU.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO ON SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI ");
            sql.Append(" LEFT JOIN SU_DCORA ON SU_DCORA.CON_CONT = SU_CONYU.CON_CONT ");
            sql.Append(" AND SU_DCORA.EMP_CODI = SU_CONYU.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_RADIC ON RN_RADIC.RAD_CONT = SU_DCORA.RAD_CONT ");
            sql.Append(" AND SU_DCORA.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" WHERE SU_CONYU.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SU_CONYU.AFI_TRAB = @AFI_CONT ");
            sql.Append(" AND SU_CONYU.CON_PERM = 'S' ");
            sql.Append(" GROUP BY TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2,   ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().GetList<toSuperca>(sql.ToString(), sqlparams);
        }

        public List<toRnRadic> getInfoAfilNovedad(int emp_codi, string apo_coda, DateTime rad_feci, DateTime rad_fecf)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RAD_NUME, RAD_FECH, CRA_NOMB, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NOT NULL THEN 'Indexado' ");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN 'Radicado' ");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN 'Digitado' ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'P' THEN 'Producto No Conforme' ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'C' THEN 'No Conformidad Solucionada' ");
            sql.Append(" END RAD_ESTA, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN RN_RADIC.RAD_FECH ");
            sql.Append("     WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_INDRA.IND_FECH ");
            sql.Append("     WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_RADIC.RAD_FDIG ");
            sql.Append("     WHEN RN_RADIC.RAD_ESTA = 'P' THEN PRO_FCHR ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'C' THEN PRO_FCHS ");
            sql.Append(" END RAD_FECC ");
            sql.Append(" FROM RN_RADIC ");
            sql.Append(" INNER JOIN RN_CRACO ON RN_CRACO.CRA_CONT = RN_RADIC.CRA_CONT ");
            sql.Append(" AND RN_CRACO.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_INDRA ON RN_INDRA.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_INDRA.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_PRONC ON RN_PRONC.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_PRONC.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" WHERE RN_RADIC.APO_CODA = @APO_CODA ");
            sql.Append(" AND RN_RADIC.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) >= @RAD_FECI ");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) <= @RAD_FECF ");
            sql.Append(" AND RN_RADIC.RAD_ESTA NOT IN('I', 'A') ");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            sqlparams.Add(new SQLParams("RAD_FECI", rad_feci));
            sqlparams.Add(new SQLParams("RAD_FECF", rad_fecf));
            return new DbConnection().GetList<toRnRadic>(sql.ToString(), sqlparams);
        }

        public List<toRnRadic> getAfilNovedadTrabLoad(int emp_codi,int tip_codi, string afi_docu, string apo_coda, string rad_feci, string rad_fecf)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT GN_TIPDO.TIP_ABRE,RN_RADIC.AFI_DOCU, RAD_NUME,RAD_FECH,CRA_NOMB, "); 
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NOT NULL THEN 'Indexado' ");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN 'Radicado' ");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN 'Digitado' ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'P' THEN 'Producto No Conforme' ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'C' THEN 'No Conformidad Solucionada' ");
            sql.Append(" END RAD_ESTA, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN RN_RADIC.RAD_FECH ");
            sql.Append("       WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_INDRA.IND_FECH ");
            sql.Append("     WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_RADIC.RAD_FDIG ");
            sql.Append("       WHEN RN_RADIC.RAD_ESTA = 'P' THEN PRO_FCHR ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA = 'C' THEN PRO_FCHS ");
            sql.Append(" END RAD_FECC ");
            sql.Append(" FROM RN_RADIC ");
            sql.Append(" INNER JOIN RN_CRACO ON RN_CRACO.CRA_CONT = RN_RADIC.CRA_CONT ");
            sql.Append(" AND RN_CRACO.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_INDRA ON RN_INDRA.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_INDRA.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_PRONC ON RN_PRONC.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_PRONC.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_AFILI.AFI_DOCU = RN_RADIC.AFI_DOCU ");
            sql.Append(" AND SU_AFILI.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append(" WHERE RN_RADIC.APO_CODA = @APO_CODA ");
            sql.Append(" AND RN_RADIC.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND RN_RADIC.RAD_ESTA NOT IN('I', 'A') ");

            if (tip_codi != 0)
            {
                sql.Append(" AND GN_TIPDO.TIP_CODI = @TIP_CODI ");
                sqlparams.Add(new SQLParams("TIP_CODI", tip_codi));
            }

            if (!string.IsNullOrEmpty(afi_docu))
            {
                sql.Append(" AND RN_RADIC.AFI_DOCU = @AFI_DOCU ");
                sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            }

            if (!string.IsNullOrEmpty(rad_feci))
            {
                sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) >=  @RAD_FECI ");
                sqlparams.Add(new SQLParams("RAD_FECI",DateTime.Parse(rad_feci)));
            }

            if (!string.IsNullOrEmpty(rad_fecf))
            {
                sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) <=  @RAD_FECF ");
                sqlparams.Add(new SQLParams("RAD_FECF", DateTime.Parse(rad_fecf)));
            }
            
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));            
            return new DbConnection().GetList<toRnRadic>(sql.ToString(), sqlparams);
        }


        public List<toArDpil> getInfoAportes(int emp_codi, string afi_docu, int rpi_peri, int rpi_perf, string apo_coda, int tip_codi)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT AR_RPILA.RPI_PERI, AR_RPILA.RPI_NURA, AR_RPILA.RPI_FCHP, AR_DRPIL.DRP_APOB DRI_SAPB,");
            sql.Append(" AR_DRPIL.AFI_NOM1, AR_DRPIL.AFI_NOM2, AR_DRPIL.AFI_APE1, AR_DRPIL.AFI_APE2");
            sql.Append(" FROM  AR_APOVO ");
            sql.Append(" INNER JOIN AR_RPILA ON AR_RPILA.APO_CONT = AR_APOVO.APO_CONT AND AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append(" INNER JOIN AR_DRPIL ON AR_DRPIL.RPI_CONT = AR_RPILA.RPI_CONT AND AR_DRPIL.EMP_CODI = AR_RPILA.EMP_CODI ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_AFILI.AFI_DOCU = AR_DRPIL.AFI_DOCU AND SU_AFILI.EMP_CODI = AR_DRPIL.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = AR_DRPIL.TIP_CODI ");
            sql.Append(" WHERE RPI_ESTA = 'A' ");
            sql.Append(" AND RPI_ESTC = 'C' ");
            sql.Append(" AND AR_DRPIL.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND AR_DRPIL.TIP_CODI = @TIP_CODI ");
            sql.Append(" AND AR_DRPIL.AFI_DOCU = @AFI_DOCU ");
            sql.Append(" AND RPI_PERI >= @RPI_PERI ");
            sql.Append(" AND RPI_PERI <= @RPI_PERF ");           
            sql.Append(" AND AR_RPILA.APO_CODA = @APO_CODA ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("TIP_CODI", tip_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            sqlparams.Add(new SQLParams("RPI_PERI", rpi_peri));
            sqlparams.Add(new SQLParams("RPI_PERF", rpi_perf));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            return new DbConnection().GetList<toArDpil>(sql.ToString(), sqlparams);
        }

        public List<ToSuHgicm> getInfoSubsidios(int emp_codi, int hgi_peri, int hgi_perf, int tip_codi, string afi_docu, string apo_coda)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT SUM(HGI_VALG) HGI_VALG, HGI_PERP, HGI_FECH, GN_TIPDO.TIP_ABRE ,SU_AFILI.AFI_DOCU, SU_AFILI.AFI_NOM1, "); 
            sql.Append(" SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2 ");
            sql.Append(" FROM SU_HGICM ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_AFILI.AFI_CONT = SU_HGICM.AFI_CONT ");
            sql.Append(" AND SU_AFILI.EMP_CODI = SU_HGICM.EMP_CODI ");
            sql.Append(" INNER JOIN SU_TRAYE ON SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" AND SU_TRAYE.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT ");
            sql.Append(" AND AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append(" WHERE AR_APOVO.APO_CODA = @APO_CODA ");
            sql.Append(" AND SU_HGICM.HGI_ESTA NOT IN('N', 'I') ");
            sql.Append(" AND SU_HGICM.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SU_AFILI.AFI_DOCU = @AFI_DOCU ");
            sql.Append(" AND SU_AFILI.TIP_CODI = @TIP_CODI ");
            sql.Append(" AND SU_HGICM.HGI_PERP >= @HGI_PERI ");
            sql.Append(" AND SU_HGICM.HGI_PERP <= @HGI_PERF ");
            sql.Append(" GROUP BY HGI_PERP, HGI_FECH, GN_TIPDO.TIP_ABRE ,SU_AFILI.AFI_DOCU, SU_AFILI.AFI_NOM1,  ");
            sql.Append(" SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2 ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("TIP_CODI", tip_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            sqlparams.Add(new SQLParams("HGI_PERI", hgi_peri));
            sqlparams.Add(new SQLParams("HGI_PERF", hgi_perf));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            return new DbConnection().GetList<ToSuHgicm>(sql.ToString(), sqlparams);
        }

        public List<toArDpil> getInfoAportesEmpresa(int emp_codi, int rpi_peri, int rpi_perf, string apo_coda)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.RPI_PERI,A.RPI_FCHP,SUM(DRI_SAPB) DRI_SAPB,RPI_DEVO,RPI_MORA, SUM(DRI_SAPB) - SUM(RPI_DEVO) TOT_APOR  ");
	        sql.Append(" FROM ( ");
            sql.Append(" SELECT DISTINCT AR_RPILA.RPI_PERI, ");
            sql.Append(" AR_RPILA.RPI_FCHP,AR_RPILA.DRI_SAPB, ");
            sql.Append(" CASE WHEN AR_RDEVO.RDE_ESTA = 'T' THEN SUM(AR_DRDEV.DRD_APOR) ");
            sql.Append("    WHEN AR_RDEVO.RDE_ESTA = 'R' THEN SUM(AR_DRPIL.DRP_APOB - AR_DRDEV.DRD_APOR) ");
            sql.Append("    ELSE 0 END RPI_DEVO, ");
            sql.Append(" AR_RPILA.RPI_MORA  ");
            sql.Append(" FROM  AR_APOVO ");
            sql.Append(" INNER JOIN AR_RPILA ON AR_RPILA.APO_CONT = AR_APOVO.APO_CONT AND AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI ");
            sql.Append(" INNER JOIN AR_DRPIL ON AR_DRPIL.RPI_CONT = AR_RPILA.RPI_CONT AND AR_DRPIL.EMP_CODI = AR_RPILA.EMP_CODI ");
            sql.Append(" LEFT JOIN AR_RDEVO ON AR_RDEVO.RPI_CONT = AR_RPILA.RPI_CONT  ");
            sql.Append(" LEFT JOIN AR_DRDEV ON AR_DRDEV.RPI_CONT = AR_RPILA.RPI_CONT ");
            sql.Append(" AND AR_DRDEV.DRP_CONT = AR_DRPIL.DRP_CONT ");
            sql.Append(" WHERE RPI_ESTA = 'A' ");
            sql.Append(" AND RPI_ESTC = 'C' ");
            sql.Append(" AND AR_DRPIL.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND RPI_PERI >= @RPI_PERI ");
            sql.Append(" AND RPI_PERI <= @RPI_PERF ");
            sql.Append(" AND AR_RPILA.APO_CODA  = @APO_CODA ");
            sql.Append(" GROUP BY AR_RPILA.RPI_PERI, ");
            sql.Append(" AR_RPILA.RPI_FCHP,AR_RPILA.DRI_SAPB,AR_RDEVO.RDE_ESTA, AR_RPILA.RPI_MORA ");
            sql.Append(" ) A  ");
            sql.Append(" GROUP BY A.RPI_PERI,A.RPI_FCHP,RPI_DEVO,RPI_MORA ");
            sql.Append(" ORDER BY RPI_FCHP, RPI_PERI ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RPI_PERI", rpi_peri));
            sqlparams.Add(new SQLParams("RPI_PERF", rpi_perf));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            return new DbConnection().GetList<toArDpil>(sql.ToString(), sqlparams);
        }

        public List<toArDpil> getInfoAportesFiscal(int emp_codi, int rpi_peri, string apo_coda)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT A.RPI_PERI,A.DRI_SIBC,SUM(DRI_SAPB) DRI_SAPB,RPI_DEVO, SUM(DRI_SAPB) - SUM(RPI_DEVO) TOT_APOR "); 
	        sql.Append(" FROM (   ");
            sql.Append(" SELECT DISTINCT AR_RPILA.RPI_PERI, AR_RPILA.DRI_SAPB, AR_RPILA. DRI_SIBC,  ");
            sql.Append(" CASE WHEN AR_RDEVO.RDE_ESTA = 'T' THEN SUM(AR_DRDEV.DRD_APOR)    ");
            sql.Append("    WHEN AR_RDEVO.RDE_ESTA = 'R' THEN SUM(AR_DRPIL.DRP_APOB - AR_DRDEV.DRD_APOR)   ");
            sql.Append("    ELSE 0 END RPI_DEVO ");
            sql.Append(" FROM  AR_APOVO    ");
            sql.Append(" INNER JOIN AR_RPILA ON AR_RPILA.APO_CONT = AR_APOVO.APO_CONT AND AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI    ");
            sql.Append(" INNER JOIN AR_DRPIL ON AR_DRPIL.RPI_CONT = AR_RPILA.RPI_CONT AND AR_DRPIL.EMP_CODI = AR_RPILA.EMP_CODI   ");
            sql.Append(" LEFT JOIN AR_RDEVO ON AR_RDEVO.RPI_CONT = AR_RPILA.RPI_CONT   ");
            sql.Append(" LEFT JOIN AR_DRDEV ON AR_DRDEV.RPI_CONT = AR_RPILA.RPI_CONT   ");
            sql.Append(" AND AR_DRDEV.DRP_CONT = AR_DRPIL.DRP_CONT   ");
            sql.Append(" WHERE RPI_ESTA = 'A'  ");
            sql.Append(" AND RPI_ESTC = 'C'  	   ");
            sql.Append(" AND AR_DRPIL.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SUBSTRING(CAST(RPI_PERI AS varchar),1,4) = @RPI_PERI ");
            sql.Append(" AND AR_RPILA.APO_CODA  = @APO_CODA ");
            sql.Append(" GROUP BY AR_RPILA.RPI_PERI,   ");
            sql.Append(" AR_RPILA.DRI_SAPB,AR_RDEVO.RDE_ESTA,AR_RPILA. DRI_SIBC ");
            sql.Append(" ) A   ");
            sql.Append(" GROUP BY A.RPI_PERI,RPI_DEVO,A.DRI_SIBC ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RPI_PERI", rpi_peri));            
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            return new DbConnection().GetList<toArDpil>(sql.ToString(), sqlparams);
        }

        public List<toRnRadic> getInfoDevoluciones(int emp_codi, string apo_coda, DateTime rad_feci, DateTime rad_fecf)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RAD_NUME, RAD_FECH, CRA_NOMB, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NOT NULL THEN 'Indexado' ");
            sql.Append("           WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN 'Radicado' ");
            sql.Append("           WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN 'Digitado' ");
            sql.Append("           WHEN RN_RADIC.RAD_ESTA = 'P' THEN 'Producto No Conforme' ");
            sql.Append("           WHEN RN_RADIC.RAD_ESTA = 'C' THEN 'No Conformidad Solucionada' ");
            sql.Append(" END RAD_ESTA, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' AND IND_CONT IS NULL THEN RN_RADIC.RAD_FECH ");
            sql.Append("      WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_INDRA.IND_FECH ");
            sql.Append("      WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA = 'R' THEN RN_RADIC.RAD_FDIG ");
            sql.Append("      WHEN RN_RADIC.RAD_ESTA = 'P' THEN PRO_FCHR ");
            sql.Append("      WHEN RN_RADIC.RAD_ESTA = 'C' THEN PRO_FCHS ");
            sql.Append(" END RAD_FECC, RN_RADIC.RAD_CONT ");
            sql.Append(" FROM RN_RADIC ");
            sql.Append(" INNER JOIN RN_CRACO ON RN_CRACO.CRA_CONT = RN_RADIC.CRA_CONT ");
            sql.Append(" AND RN_CRACO.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_INDRA ON RN_INDRA.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_INDRA.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" LEFT JOIN RN_PRONC ON RN_PRONC.RAD_CONT = RN_RADIC.RAD_CONT ");
            sql.Append(" AND RN_PRONC.EMP_CODI = RN_RADIC.EMP_CODI ");
            sql.Append(" WHERE RN_RADIC.APO_CODA = @APO_CODA ");
            sql.Append(" AND RN_RADIC.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) >= @RAD_FECI ");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) <= @RAD_FECF ");
            sql.Append(" AND RN_RADIC.RAD_ESTA NOT IN('I', 'A') ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            sqlparams.Add(new SQLParams("RAD_FECI", rad_feci));
            sqlparams.Add(new SQLParams("RAD_FECF", rad_fecf));
            return new DbConnection().GetList<toRnRadic>(sql.ToString(), sqlparams);
        }

        public ArRdevo getInfoDevoDetalle(int emp_codi, int rad_cont)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT DISTINCT AR_RPILA.RPI_PERI,AR_RPILA.RPI_NURA, ");
            sql.Append(" CASE WHEN AR_RDEVO.RDE_TIPO = 'T' THEN 'Traslado' WHEN AR_RDEVO.RDE_TIPO = 'R' THEN 'Reintegro.' END RDE_TIPO, ");
            sql.Append(" GN_TERCE.TER_NOCO,GN_TERCE.TER_CODA, ");
            sql.Append(" CASE WHEN AR_RDEVO.RDE_TIPO = 'T' THEN SUM(AR_DRDEV.DRD_APOR +AR_RDEVO.RDE_MORR) ");
            sql.Append(" WHEN AR_RDEVO.RDE_TIPO = 'R' THEN SUM(AR_DRPIL.DRP_APOB -AR_DRDEV.DRD_APOR) +AR_RDEVO.RDE_MORR END RDE_DEVO ");
            sql.Append(" FROM AR_RDEVO ");
            sql.Append(" INNER JOIN AR_DRDEV ON AR_DRDEV.RDE_CONT = AR_RDEVO.RDE_CONT ");
            sql.Append(" AND AR_DRDEV.EMP_CODI = AR_RDEVO.EMP_CODI ");
            sql.Append(" INNER JOIN AR_RPILA ON AR_RPILA.RPI_CONT = AR_RDEVO.RPI_CONT ");
            sql.Append(" AND AR_RPILA.EMP_CODI = AR_RDEVO.EMP_CODI ");
            sql.Append(" INNER JOIN AR_DRPIL ON AR_RPILA.RPI_CONT = AR_DRPIL.RPI_CONT ");
            sql.Append(" AND AR_RPILA.EMP_CODI = AR_DRPIL.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TERCE ON GN_TERCE.TER_CODI = CASE WHEN AR_RDEVO.RDE_TIPO = 'T' THEN AR_RDEVO.TER_CODD ");
            sql.Append(" WHEN AR_RDEVO.RDE_TIPO = 'R' THEN AR_RDEVO.TER_CODS END ");
            sql.Append(" WHERE RAD_CONT = @RAD_CONT  AND RDE_ESTA = 'A' ");
            sql.Append(" AND AR_RDEVO.EMP_CODI = @EMP_CODI ");
            sql.Append(" GROUP BY  AR_RPILA.RPI_PERI,AR_RPILA.RPI_NURA,AR_RDEVO.RDE_TIPO,  ");
            sql.Append(" GN_TERCE.TER_NOCO,GN_TERCE.TER_CODA, AR_RDEVO.RDE_MORR ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("RAD_CONT", rad_cont));
            return new DbConnection().Get<ArRdevo>(sql.ToString(), sqlparams);
        }

        public List<ToSuHgicm> getInfoSubsidiosEmpresa(int emp_codi, int hgi_peri, int hgi_perf, string apo_coda)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT HGI_PERP, SUM(HGI_VALG) HGI_VALG, ");
            sql.Append(" CASE WHEN SU_HGICM.HGI_ESTA IN('A','P') THEN 'Pagado' END HGI_ESTA, HGI_FECH, ");
            sql.Append(" COUNT(SU_HGICM.AFI_CONT) HGI_NUTR, COUNT(SU_HGICM.AFI_PCAR) HGI_NUBE ");
            sql.Append(" FROM SU_HGICM ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_AFILI.AFI_CONT = SU_HGICM.AFI_CONT ");
            sql.Append(" AND SU_AFILI.EMP_CODI = SU_HGICM.EMP_CODI ");
            sql.Append(" INNER JOIN SU_TRAYE ON SU_TRAYE.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" AND SU_TRAYE.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT ");
            sql.Append(" AND AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI ");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI ");
            sql.Append(" WHERE AR_APOVO.APO_CODA = @APO_CODA ");
            sql.Append(" AND SU_HGICM.HGI_ESTA NOT IN('N', 'I') ");
            sql.Append(" AND SU_HGICM.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND SU_HGICM.HGI_PERP >= @HGI_PERI ");
            sql.Append(" AND SU_HGICM.HGI_PERP <= @HGI_PERF ");
            sql.Append(" GROUP BY HGI_PERP, HGI_FECH, GN_TIPDO.TIP_ABRE,HGI_ESTA ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("HGI_PERI", hgi_peri));
            sqlparams.Add(new SQLParams("HGI_PERF", hgi_perf));
            sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            return new DbConnection().GetList<ToSuHgicm>(sql.ToString(), sqlparams);
        }
    }  
}