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
    public class DAOSuConsu
    {
        public tofiliatrab getInfoAfilitrab(int emp_codi, string usu_codi)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT AFI_CONT,AFI_NOM1,AFI_NOM2,AFI_APE1,AFI_APE2,AFI_DIRE,AFI_TELE,AFI_CELU, PAI_NOMB, ");
            sql.Append(" DEP_NOMB, MUN_NOMB, LOC_NOMB, BAR_NOMB, TIP_ABRE, AFI_DOCU, AFI_FECN ");
            sql.Append(" FROM SU_AFILI, GN_PAISE,GN_REGIO, GN_DEPAR, GN_MUNIC, GN_LOCAL, GN_BARRI, GN_TIPDO");
            sql.Append(" WHERE SU_AFILI.PAI_CODI = GN_PAISE.PAI_CODI AND SU_AFILI.REG_CODI = GN_REGIO.REG_CODI");
            sql.Append(" AND SU_AFILI.PAI_CODI = GN_REGIO.PAI_CODI AND SU_AFILI.DEP_CODI = GN_DEPAR.DEP_CODI");
            sql.Append(" AND SU_AFILI.REG_CODI = GN_DEPAR.REG_CODI AND SU_AFILI.PAI_CODI = GN_DEPAR.PAI_CODI");
            sql.Append(" AND SU_AFILI.MUN_CODI = GN_MUNIC.MUN_CODI AND SU_AFILI.DEP_CODI = GN_MUNIC.DEP_CODI");
            sql.Append(" AND SU_AFILI.REG_CODI = GN_MUNIC.REG_CODI AND SU_AFILI.PAI_CODI = GN_MUNIC.PAI_CODI");
            sql.Append(" AND SU_AFILI.LOC_CODI = GN_LOCAL.LOC_CODI AND SU_AFILI.MUN_CODI = GN_LOCAL.MUN_CODI");
            sql.Append(" AND SU_AFILI.DEP_CODI = GN_LOCAL.DEP_CODI AND SU_AFILI.REG_CODI = GN_LOCAL.REG_CODI");
            sql.Append(" AND SU_AFILI.PAI_CODI = GN_LOCAL.PAI_CODI AND SU_AFILI.LOC_CODI = GN_BARRI.LOC_CODI");
            sql.Append(" AND SU_AFILI.MUN_CODI = GN_BARRI.MUN_CODI AND SU_AFILI.DEP_CODI = GN_BARRI.DEP_CODI");
            sql.Append(" AND SU_AFILI.REG_CODI = GN_BARRI.REG_CODI AND SU_AFILI.PAI_CODI = GN_BARRI.PAI_CODI");
            sql.Append(" AND SU_AFILI.BAR_CODI = GN_BARRI.BAR_CODI");
            sql.Append(" AND GN_TIPDO.TIP_CODI = SU_AFILI.TIP_CODI");
            sql.Append(" AND AFI_DOCU = @AFI_DOCU");
            sql.Append(" AND EMP_CODI = @EMP_CODI");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", usu_codi));
            return new DbConnection().Get<tofiliatrab>(sql.ToString(), sqlparams);
        }

        public List<toSutraye> getInfoSutrayeTrab(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE,APO_CODA,APO_RAZS,TRA_FCHI,TRA_FCHA ");
            sql.Append(" FROM SU_TRAYE");
            sql.Append(" INNER JOIN AR_APOVO ON AR_APOVO.APO_CONT = SU_TRAYE.APO_CONT");
            sql.Append(" AND AR_APOVO.EMP_CODI = SU_TRAYE.EMP_CODI");
            sql.Append(" INNER JOIN GN_TIPDO ON GN_TIPDO.TIP_CODI = AR_APOVO.TIP_CODI");
            sql.Append(" WHERE TRA_ESTA = 'A'");
            sql.Append(" AND AFI_CONT = @AFI_CONT");
            sql.Append(" AND SU_TRAYE.EMP_CODI = @EMP_CODI");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().GetList<toSutraye>(sql.ToString(), sqlparams);
        }

        public List<toSuperca> getInfoSupercaTrab(int emp_codi, int afi_cont)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, MPA_NOMB, MAX(RAD_FECH) RAD_FECH");
            sql.Append(" FROM SU_PERCA");
            sql.Append(" INNER JOIN SU_MPARE ON SU_PERCA.EMP_CODI = SU_MPARE.EMP_CODI");
            sql.Append(" AND SU_PERCA.MPA_CONT = SU_MPARE.MPA_CONT ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_PERCA.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_PERCA.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO ON SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI");
            sql.Append(" LEFT JOIN SU_DPERA ON SU_DPERA.PER_CONT = SU_PERCA.PER_CONT");
            sql.Append(" AND SU_DPERA.EMP_CODI = SU_PERCA.EMP_CODI");
            sql.Append(" LEFT JOIN RN_RADIC ON RN_RADIC.RAD_CONT = SU_DPERA.RAD_CONT");
            sql.Append(" AND SU_DPERA.EMP_CODI = RN_RADIC.EMP_CODI");
            sql.Append(" WHERE SU_PERCA.EMP_CODI =  @EMP_CODI  ");
            sql.Append(" AND SU_PERCA.AFI_TRAB = @AFI_CONT");
            sql.Append(" AND SU_PERCA.PER_ESTA = 'A'");
            sql.Append(" GROUP BY TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, MPA_NOMB");
            sql.Append(" UNION");
            sql.Append(" SELECT TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN, 'CONYUGE' MPA_NOMB, MAX(RAD_FECH) RAD_FECH");
            sql.Append(" FROM SU_CONYU ");
            sql.Append(" INNER JOIN SU_AFILI ON SU_CONYU.EMP_CODI = SU_AFILI.EMP_CODI ");
            sql.Append(" AND SU_CONYU.AFI_CONT = SU_AFILI.AFI_CONT ");
            sql.Append(" INNER JOIN GN_TIPDO ON SU_AFILI.TIP_CODI = GN_TIPDO.TIP_CODI");
            sql.Append(" LEFT JOIN SU_DCORA ON SU_DCORA.CON_CONT = SU_CONYU.CON_CONT");
            sql.Append(" AND SU_DCORA.EMP_CODI = SU_CONYU.EMP_CODI");
            sql.Append(" LEFT JOIN RN_RADIC ON RN_RADIC.RAD_CONT = SU_DCORA.RAD_CONT");
            sql.Append(" AND SU_DCORA.EMP_CODI = RN_RADIC.EMP_CODI");
            sql.Append(" WHERE SU_CONYU.EMP_CODI =  @EMP_CODI");
            sql.Append(" AND SU_CONYU.AFI_TRAB =  @AFI_CONT");
            sql.Append(" AND SU_CONYU.CON_PERM = 'S'");
            sql.Append(" GROUP BY TIP_ABRE,SU_AFILI.AFI_DOCU,SU_AFILI.AFI_NOM1, SU_AFILI.AFI_NOM2, ");
            sql.Append(" SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2, SU_AFILI.AFI_FECN");
            List<SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            return new DbConnection().GetList<toSuperca>(sql.ToString(), sqlparams);
        }

        public List<toRnRadic> getInfoAfilNovedad(int emp_codi, int afi_cont, DateTime rad_feci, DateTime rad_fecf)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT RAD_NUME,RAD_FECH,CRA_NOMB, ");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA='R' AND IND_CONT IS NOT NULL THEN 'Indexado'");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NULL AND RN_RADIC.RAD_ESTA='R' AND IND_CONT IS NULL THEN 'Radicado'");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA='R' THEN 'Digitado'");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA='P' THEN 'Producto No Conforme' ");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA='C' THEN 'No Conformidad Solucionada'");
            sql.Append(" END RAD_ESTA,");
            sql.Append(" CASE WHEN RN_RADIC.RAD_FDIG IS NULL     AND RN_RADIC.RAD_ESTA='R' AND IND_CONT IS NULL THEN RN_RADIC.RAD_FECH");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NULL     AND RN_RADIC.RAD_ESTA='R' THEN RN_INDRA.IND_FECH ");
            sql.Append("         WHEN RN_RADIC.RAD_FDIG IS NOT NULL AND RN_RADIC.RAD_ESTA='R' THEN RN_RADIC.RAD_FDIG");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA='P' THEN PRO_FCHR");
            sql.Append("         WHEN RN_RADIC.RAD_ESTA='C' THEN PRO_FCHS");
            sql.Append(" END RAD_FECC");
            sql.Append(" FROM RN_RADIC");
            sql.Append(" INNER JOIN RN_CRACO ON RN_CRACO.CRA_CONT = RN_RADIC.CRA_CONT");
            sql.Append(" AND RN_CRACO.EMP_CODI = RN_RADIC.EMP_CODI");
            sql.Append(" LEFT JOIN RN_INDRA ON RN_INDRA.RAD_CONT = RN_RADIC.RAD_CONT");
            sql.Append(" AND RN_INDRA.EMP_CODI= RN_RADIC.EMP_CODI");
            sql.Append(" LEFT JOIN RN_PRONC ON RN_PRONC.RAD_CONT = RN_RADIC.RAD_CONT");
            sql.Append(" AND RN_PRONC.EMP_CODI= RN_RADIC.EMP_CODI");
            sql.Append(" WHERE RN_RADIC.AFI_CONT = @AFI_CONT");
            sql.Append(" AND RN_RADIC.EMP_CODI = @EMP_CODI");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) >= @RAD_FECI");
            sql.Append(" AND CONVERT(VARCHAR, RN_RADIC.RAD_FECH,103) <= @RAD_FECF");
            List <SQLParams> sqlparams = new List<SQLParams>();
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            sqlparams.Add(new SQLParams("RAD_FECI", rad_feci));
            sqlparams.Add(new SQLParams("RAD_FECF", rad_fecf));
            return new DbConnection().GetList<toRnRadic>(sql.ToString(), sqlparams);
        }

        public List<toArDpil> getInfoAportes(int emp_codi, int afi_cont, int rpi_peri, int rpi_perf, string apo_coda, string apo_razr)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();

            sql.Append(" SELECT *, DRI_SAPB - RPI_DEVO TOT_APOR ");
            sql.Append(" FROM ( ");
            sql.Append(" SELECT DISTINCT AR_RPILA.APO_CODA,AR_RPILA.APO_RAZS,AR_RPILA.RPI_PERI,  ");
            sql.Append(" AR_RPILA.RPI_NURA,AR_RPILA.RPI_FCHP,AR_RPILA.DRI_SAPB, ");
            sql.Append(" CASE WHEN AR_RDEVO.RDE_ESTA = 'T' THEN SUM(AR_DRDEV.DRD_APOR)  ");
            sql.Append(" 	 WHEN AR_RDEVO.RDE_ESTA = 'R' THEN SUM(AR_DRPIL.DRP_APOB - AR_DRDEV.DRD_APOR) ");
            sql.Append(" 	 ELSE 0 END RPI_DEVO ");
            sql.Append(" FROM  AR_APOVO  ");
            sql.Append(" INNER JOIN AR_RPILA ON AR_RPILA.APO_CONT = AR_APOVO.APO_CONT AND AR_RPILA.EMP_CODI = AR_APOVO.EMP_CODI  ");
            sql.Append(" INNER JOIN AR_DRPIL ON AR_DRPIL.RPI_CONT = AR_RPILA.RPI_CONT AND AR_DRPIL.EMP_CODI = AR_RPILA.EMP_CODI ");
            sql.Append(" LEFT JOIN AR_RDEVO ON AR_RDEVO.RPI_CONT = AR_RPILA.RPI_CONT ");
            sql.Append(" LEFT JOIN AR_DRDEV ON AR_DRDEV.RPI_CONT = AR_RPILA.RPI_CONT ");
            sql.Append(" AND AR_DRDEV.DRP_CONT = AR_DRPIL.DRP_CONT ");
            sql.Append(" WHERE RPI_ESTA = 'A' AND RPI_ESTC = 'C' ");
            sql.Append(" AND AR_DRPIL.AFI_CONT =  @AFI_CONT AND AR_DRPIL.EMP_CODI = @EMP_CODI ");
            sql.Append(" AND RPI_PERI >= @RPI_PERI AND RPI_PERI <= @RPI_PERF ");

            if (!String.IsNullOrEmpty(apo_coda))
            {
                sql.Append(" AND AR_RPILA.APO_CODA  = @APO_CODA");
                sqlparams.Add(new SQLParams("APO_CODA", apo_coda));
            }

            if (!String.IsNullOrEmpty(apo_razr))
            {
                sql.Append(" AND AR_RPILA.APO_RAZS LIKE '%" + apo_razr + "%'");
            }

            sql.Append(" GROUP BY  AR_RPILA.APO_CODA,AR_RPILA.APO_RAZS,AR_RPILA.RPI_PERI, ");
            sql.Append(" AR_RPILA.RPI_NURA,AR_RPILA.RPI_FCHP,AR_RPILA.DRI_SAPB,AR_RDEVO.RDE_ESTA ");
            sql.Append(" ) A ");
            sql.Append(" ORDER BY RPI_FCHP,APO_CODA, RPI_PERI ");
                             
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_CONT", afi_cont));
            sqlparams.Add(new SQLParams("RPI_PERI", rpi_peri));
            sqlparams.Add(new SQLParams("RPI_PERF", rpi_perf));
            return new DbConnection().GetList<toArDpil>(sql.ToString(), sqlparams);
        }

        public List<ToSuHgicm> getInfoSubsidios(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu)
        {
            List<SQLParams> sqlparams = new List<SQLParams>();
            StringBuilder sql = new StringBuilder();
            sql.Append(" SELECT HGI_PERP, HGI_FECH, HGI_VALG, SU_AFILI.AFI_DOCU, SU_AFILI.AFI_NOM1,");
            sql.Append(" SU_AFILI.AFI_NOM2, SU_AFILI.AFI_APE1, SU_AFILI.AFI_APE2 ");
            sql.Append(" FROM SU_HGICM");
            sql.Append(" INNER JOIN SU_AFILI ON SU_AFILI.AFI_CONT = SU_HGICM.AFI_PCAR");
            sql.Append(" INNER JOIN SU_AFILI SU_AFILI_TRAB ON SU_AFILI_TRAB.AFI_CONT = SU_HGICM.AFI_CONT");
            sql.Append(" AND SU_AFILI.EMP_CODI = SU_HGICM.EMP_CODI");
            sql.Append(" WHERE SU_HGICM.EMP_CODI = @EMP_CODI");
            sql.Append(" AND SU_AFILI_TRAB.AFI_DOCU = @AFI_DOCU ");
            sql.Append(" AND SU_HGICM.HGI_ESTA NOT IN('N', 'I')");
            sql.Append(" AND SU_HGICM.HGI_PERP >= @HGI_PERI ");
            sql.Append(" AND SU_HGICM.HGI_PERP <= @HGI_PERF ");
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            sqlparams.Add(new SQLParams("AFI_DOCU", afi_docu));
            sqlparams.Add(new SQLParams("HGI_PERI", hgi_peri));
            sqlparams.Add(new SQLParams("HGI_PERF", hgi_perf));
            return new DbConnection().GetList<ToSuHgicm>(sql.ToString(), sqlparams);
        }
    }
}