﻿using Ophelia;
using Ophelia.Comun;
using Ophelia.DataBase;
using RSELFANG.TO;
using SevenFramework.DataBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;

namespace RSELFANG.DAO
{
    public class DAOEeReles
    {
        public DataSet getEeReles(int rel_cont, int rem_cont, int inp_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT *   ");
            sql.Append(" FROM (  ");
            sql.Append(" SELECT REL.EMP_CODI,REL.REL_CONT,REL_NOMB,SEC_NOMB,DRE_ORDE,DRS_PREG,DRS_CLAS,EEN.SEC_CONT,DRS_ORDE,");
            sql.Append(" 0 DDP_CONT,0 DRP_CONT,'' DPP_OPCI,0 DSP_ORDE , EEN.RSE_CONT, SEE.DRS_CONT, DRE_SECC  , RES_VALO, RES_CONT");
            sql.Append(" FROM   EE_RELES REL  ");
            sql.Append("     INNER JOIN EE_DRELE ELE  ");
            sql.Append("             ON  REL.EMP_CODI = ELE.EMP_CODI  ");
            sql.Append("             AND REL.REL_CONT = ELE.REL_CONT  ");
            sql.Append("     INNER JOIN EE_SECCE CCE			   	  ");
            sql.Append("             ON  ELE.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("             AND CCE.SEC_CONT = ELE.DRE_SECC  ");
            sql.Append("     LEFT JOIN EE_RSEEN EEN				   	  ");
            sql.Append("             ON  EEN.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("             AND EEN.SEC_CONT = CCE.SEC_CONT  ");
            sql.Append("     INNER JOIN EE_DRSEE SEE			   	  ");
            sql.Append("             ON  SEE.EMP_CODI = EEN.EMP_CODI  ");
            sql.Append("             AND SEE.RSE_CONT = EEN.RSE_CONT  ");
            sql.Append(" 	LEFT JOIN EE_RESEN ON EE_RESEN.REL_CONT= ELE.REL_CONT");
            sql.Append(" 	AND EE_RESEN.RSE_CONT = EEN.RSE_CONT");
            sql.Append(" 	AND EE_RESEN.DRS_CONT = SEE.DRS_CONT");

            if(inp_cont == 0)
                sql.Append(" 	AND REM_CONT = @REM_CONT ");
            else
                sql.Append(" 	AND INP_CONT = @INP_CONT ");

            sql.Append(" WHERE  ELE.REL_CONT = @REL_CONT");
            sql.Append(" UNION  ");
            sql.Append(" SELECT REL.EMP_CODI,REL.REL_CONT,REL_NOMB,SEC_NOMB,DRE_ORDE,DPR_PREG DRS_PREG,DPR_CLAS DRS_CLAS,RCS.SEC_CONT,DRS_ORDE,");
            sql.Append(" PRC.DDP_CONT,PRC.DRP_CONT,PRC.DPP_OPCI,PRC.DPP_ORDE DSP_ORDE,  0 RSE_CONT , 0 DRS_CONT, DRE_SECC, RES_VALO, RES_CONT  ");
            sql.Append(" FROM   EE_RELES REL  ");
            sql.Append("     INNER JOIN EE_DRELE ELE  ");
            sql.Append("             ON  REL.EMP_CODI = ELE.EMP_CODI  ");
            sql.Append("             AND REL.REL_CONT = ELE.REL_CONT  ");
            sql.Append("     INNER JOIN EE_SECCE CCE			   	  ");
            sql.Append("             ON  ELE.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("             AND CCE.SEC_CONT = ELE.DRE_SECC  ");
            sql.Append("   	LEFT JOIN EE_DPRCS RCS  				  ");
            sql.Append("   		ON  RCS.EMP_CODI = CCE.EMP_CODI  	  ");
            sql.Append("   		AND RCS.SEC_CONT = CCE.SEC_CONT  	  ");
            sql.Append("   	INNER JOIN EE_DDPRC PRC  				  ");
            sql.Append("   		ON  PRC.EMP_CODI = RCS.EMP_CODI  	  ");
            sql.Append("   		AND PRC.DRP_CONT = RCS.DRP_CONT 	  ");
            sql.Append(" LEFT JOIN EE_RESEM ON EE_RESEM.REL_CONT= ELE.REL_CONT");
            sql.Append(" 	AND EE_RESEM.DRP_CONT = PRC.DRP_CONT");
            sql.Append(" 	AND EE_RESEM.DDP_CONT = PRC.DDP_CONT");

            if (inp_cont == 0)
                sql.Append(" 	AND REM_CONT = @REM_CONT ");
            else
                sql.Append(" 	AND INP_CONT = @INP_CONT ");

            sql.Append(" WHERE  ELE.REL_CONT = @REL_CONT");
            sql.Append(" ) A LEFT JOIN AE_PARAM ON AE_PARAM.EMP_CODI = A.EMP_CODI WHERE A.DRS_CLAS IN ('A','M','P','U')  ");
            sql.Append(" ORDER BY DRE_ORDE   ");
            sqlparams.Add(new SQLParams("REL_CONT", rel_cont));
            sqlparams.Add(new SQLParams("REM_CONT", rem_cont));
            sqlparams.Add(new SQLParams("INP_CONT", inp_cont));
            return new DbConnection().GetDataSet(sql.ToString(), sqlparams);
        }

        public int getNumEeReles(int rel_cont)
        {
            DataSet ds = new DataSet();
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT COUNT(*) NUM_PREG FROM ( ");
            sql.Append(" SELECT REL.* ");
            sql.Append(" FROM   EE_RELES REL  ");
            sql.Append(" INNER JOIN EE_DRELE ELE  ");
            sql.Append("     ON  REL.EMP_CODI = ELE.EMP_CODI  ");
            sql.Append("     AND REL.REL_CONT = ELE.REL_CONT  ");
            sql.Append(" INNER JOIN EE_SECCE CCE			   ");
            sql.Append("     ON  ELE.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("     AND CCE.SEC_CONT = ELE.DRE_SECC  ");
            sql.Append(" INNER JOIN EE_RSEEN EEN			 ");
            sql.Append("     ON  EEN.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("     AND EEN.SEC_CONT = CCE.SEC_CONT  ");
            sql.Append(" INNER JOIN EE_DRSEE SEE			   ");
            sql.Append("     ON  SEE.EMP_CODI = EEN.EMP_CODI  ");
            sql.Append("     AND SEE.RSE_CONT = EEN.RSE_CONT  ");
            sql.Append(" 		WHERE  ELE.REL_CONT =  @REL_CONT ");
            sql.Append(" UNION ALL ");
            sql.Append(" SELECT REL.* ");
            sql.Append(" FROM   EE_RELES REL  ");
            sql.Append("        INNER JOIN EE_DRELE ELE  ");
            sql.Append("             ON  REL.EMP_CODI = ELE.EMP_CODI  ");
            sql.Append("             AND REL.REL_CONT = ELE.REL_CONT  ");
            sql.Append("        INNER JOIN EE_SECCE CCE	 ");
            sql.Append("             ON  ELE.EMP_CODI = CCE.EMP_CODI ");
            sql.Append("             AND CCE.SEC_CONT = ELE.DRE_SECC  ");
            sql.Append("  	   INNER JOIN EE_DPRCS RCS  ");
            sql.Append("  		   ON  RCS.EMP_CODI = CCE.EMP_CODI  ");
            sql.Append("  		   AND RCS.SEC_CONT = CCE.SEC_CONT  ");
            sql.Append(" 		    WHERE  ELE.REL_CONT =  @REL_CONT  ");
            sql.Append("  	) A ");
            sqlparams.Add(new SQLParams("REL_CONT", rel_cont));
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);
            return int.Parse(ds.Tables[0].Rows[0]["NUM_PREG"].ToString());
        }

        public int GetCont(int emp_codi, string table)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(string.Format("SELECT MAX(RES_CONT) + 1 FROM " + table + " WHERE EMP_CODI= " + emp_codi));
            OTOContext pTOContext = new OTOContext();
            var conection = DBFactory.GetDB(pTOContext);
            var result = conection.GetScalar(pTOContext, sql.ToString());
            if (result.ToString() == "")
                return 1;
            return result.AsInt();
        }

        public int insertEeresen(List<EeResen> eeresen)
        {
           int emp_codi = int.Parse(ConfigurationManager.AppSettings["emp_codi"]);

            foreach (EeResen param in eeresen)
            {                
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO EE_RESEN( ");
                sql.Append(" EMP_CODI, ");
                sql.Append(" AUD_USUA, ");
                sql.Append(" AUD_ESTA, ");
                sql.Append(" AUD_UFAC, ");
                sql.Append(" RES_CONT, ");
                sql.Append(" INP_CONT, ");
                sql.Append(" REL_CONT, ");
                sql.Append(" RSE_CONT, ");
                sql.Append(" DRS_CONT, ");
                sql.Append(" RES_VALO, ");
                sql.Append(" REM_CONT) ");
                sql.Append(" VALUES( ");
                sql.Append(" @EMP_CODI, ");
                sql.Append(" @AUD_USUA, ");
                sql.Append(" @AUD_ESTA, ");
                sql.Append(" @AUD_UFAC, ");
                sql.Append(" @RES_CONT, ");
                sql.Append(" @INP_CONT, ");
                sql.Append(" @REL_CONT, ");
                sql.Append(" @RSE_CONT, ");
                sql.Append(" @DRS_CONT, ");
                sql.Append(" @RES_VALO, ");
                sql.Append(" @REM_CONT ");
                sql.Append(" ) ");

                List<SQLParams> sqlparams = new List<SQLParams>();
                sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlparams.Add(new SQLParams("AUD_USUA", "SEVEN"));
                sqlparams.Add(new SQLParams("AUD_ESTA", "A"));
                sqlparams.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                sqlparams.Add(new SQLParams("RES_CONT", GetCont(emp_codi, "EE_RESEN")));
                sqlparams.Add(new SQLParams("INP_CONT", param.inp_cont));
                sqlparams.Add(new SQLParams("REL_CONT", param.rel_cont));
                sqlparams.Add(new SQLParams("RSE_CONT", param.rse_cont));
                sqlparams.Add(new SQLParams("DRS_CONT", param.drs_cont));
                sqlparams.Add(new SQLParams("RES_VALO", param.res_valo));
                sqlparams.Add(new SQLParams("REM_CONT", param.rem_cont));

                new DbConnection().Insert(sql.ToString(), false,sqlparams);
            }

            return 0;
        }

        public int insertEeresem(List<EeResem> eeresem)
        {
            int emp_codi = int.Parse(ConfigurationManager.AppSettings["emp_codi"]);

            foreach (EeResem param in eeresem)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" INSERT INTO EE_RESEM( ");
                sql.Append(" EMP_CODI, ");
                sql.Append(" AUD_USUA, ");
                sql.Append(" AUD_ESTA, ");
                sql.Append(" AUD_UFAC, ");
                sql.Append(" RES_CONT, ");
                sql.Append(" INP_CONT, ");
                sql.Append(" REL_CONT, ");                
                sql.Append(" DRP_CONT, ");
                sql.Append(" DDP_CONT, ");
                sql.Append(" RES_VALO, ");
                sql.Append(" REM_CONT) ");
                sql.Append(" VALUES( ");
                sql.Append(" @EMP_CODI, ");
                sql.Append(" @AUD_USUA, ");
                sql.Append(" @AUD_ESTA, ");
                sql.Append(" @AUD_UFAC, ");
                sql.Append(" @RES_CONT, ");
                sql.Append(" @INP_CONT, ");
                sql.Append(" @REL_CONT, ");
                sql.Append(" @DRP_CONT, ");
                sql.Append(" @DDP_CONT, ");
                sql.Append(" @RES_VALO, ");
                sql.Append(" @REM_CONT ");
                sql.Append(" ) ");

                List<SQLParams> sqlparams = new List<SQLParams>();
                sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlparams.Add(new SQLParams("AUD_USUA", "SEVEN"));
                sqlparams.Add(new SQLParams("AUD_ESTA", "A"));
                sqlparams.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                sqlparams.Add(new SQLParams("RES_CONT", GetCont(emp_codi, "EE_RESEM")));
                sqlparams.Add(new SQLParams("INP_CONT", param.inp_cont));
                sqlparams.Add(new SQLParams("REL_CONT", param.rel_cont));
                sqlparams.Add(new SQLParams("DRP_CONT", param.drp_cont));
                sqlparams.Add(new SQLParams("DDP_CONT", param.ddp_cont));
                sqlparams.Add(new SQLParams("RES_VALO", param.res_valo));
                sqlparams.Add(new SQLParams("REM_CONT", param.rem_cont));

                new DbConnection().Insert(sql.ToString(), false, sqlparams);
            }

            return 0;
        }

        public TOPqParam GetEerelesServ(int rel_serv, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            DataSet ds = new DataSet();
            sql.Append(" SELECT MAX(REL_CONT) REL_CONT ");
            sql.Append(" FROM EE_RELES ");
            sql.Append(" WHERE REL_SERV = @REL_SERV ");
            sql.Append(" AND EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("REL_SERV", rel_serv));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return  new DbConnection().Get<TOPqParam>(sql.ToString(), sqlparams);            
        }

        public bool infoValidEereles(int rem_cont,int rel_serv, int inp_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            DataSet ds = new DataSet();

            if (inp_cont != 0)
            {
                sql.Append(" SELECT * ");
                sql.Append(" FROM EE_RESEN");                
                sql.Append(" WHERE EE_RESEN.INP_CONT = @INP_CONT");                
                sql.Append(" UNION");
                sql.Append(" SELECT * ");
                sql.Append(" FROM EE_RESEM");
                sql.Append(" WHERE EE_RESEM.INP_CONT = @INP_CONT");
            }
            else
            {
                sql.Append(" SELECT * ");
                sql.Append(" FROM EE_RESEN");
                sql.Append(" INNER JOIN EE_REMES ON EE_REMES.REM_CONT = EE_RESEN.REM_CONT");
                sql.Append(" WHERE EE_REMES.REM_CONT = @REM_CONT");
                sql.Append(" AND ITE_SERV = @REL_SERV");
                sql.Append(" UNION");
                sql.Append(" SELECT *");
                sql.Append(" FROM EE_RESEM");
                sql.Append(" INNER JOIN EE_REMES ON EE_REMES.REM_CONT = EE_RESEM.REM_CONT");
                sql.Append(" WHERE EE_REMES.REM_CONT = @REM_CONT");
                sql.Append(" AND ITE_SERV = @REL_SERV");
            }

            sqlparams.Add(new SQLParams("REM_CONT", rem_cont));
            sqlparams.Add(new SQLParams("INP_CONT", inp_cont));
            sqlparams.Add(new SQLParams("REL_SERV", rel_serv));            
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }           
        }

        public bool infoValidEerelesPQ(int inp_cont)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            DataSet ds = new DataSet();
            sql.Append(" SELECT * ");
            sql.Append(" FROM EE_RESEN");      ;
            sql.Append(" WHERE EE_RESEN.INP_CONT = @INP_CONT");           
            sql.Append(" UNION");
            sql.Append(" SELECT * ");
            sql.Append(" FROM EE_RESEM"); ;
            sql.Append(" WHERE EE_RESEM.INP_CONT = @INP_CONT");
            sqlparams.Add(new SQLParams("INP_CONT", inp_cont));            
            ds = new DbConnection().GetDataSet(sql.ToString(), sqlparams);

            if (ds.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public List<EeResen> getInfoEeresen(int rem_cont, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT INP_CONT, REL_CONT, RSE_CONT, DRS_CONT, RES_VALO, REM_CONT ");
            sql.Append(" FROM EE_RESEN ");
            sql.Append(" WHERE REM_CONT = @REM_CONT ");
            sql.Append(" AND EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("REM_CONT", rem_cont));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<EeResen>(sql.ToString(), sqlparams);
        }

        public List<EeResem> getInfoEeresem(int rem_cont, int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            List<SQLParams> sqlparams = new List<SQLParams>();
            sql.Append(" SELECT INP_CONT, REL_CONT, DRP_CONT,DDP_CONT,RES_VALO, REM_CONT ");
            sql.Append(" FROM EE_RESEM ");
            sql.Append(" WHERE REM_CONT = @REM_CONT ");
            sql.Append(" AND EMP_CODI = @EMP_CODI ");
            sqlparams.Add(new SQLParams("REM_CONT", rem_cont));
            sqlparams.Add(new SQLParams("EMP_CODI", emp_codi));
            return new DbConnection().GetList<EeResem>(sql.ToString(), sqlparams);
        }

    }
}