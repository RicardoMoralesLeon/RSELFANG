using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using SevenFramework.DataBase;
using RSELFANG.Models;
using SevenFramework.Exceptions;

namespace RSELFANG.DAO
{
    public class DAOCaRcxcv
    {
        public int SetCaRcxcv(Ca_Rcxcv carcxcv)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("  INSERT INTO CA_RCXCV   ");
                sql.Append("  (                      ");
                sql.Append("  EMP_CODI,              ");
                sql.Append("  CLI_CODI,              ");
                sql.Append("  DCL_CODD,              ");
                sql.Append("  ITE_CTSE,              ");
                sql.Append("  CXC_CONT,              ");
                sql.Append("  RCX_VIGE,              ");
                sql.Append("  AUD_UFAC,              ");
                sql.Append("  AUD_USUA,              ");
                sql.Append("  AUD_ESTA               ");
                sql.Append("  )                      ");
                sql.Append("  VALUES                 ");
                sql.Append("  (                      ");
                sql.Append("  @EMP_CODI,             ");
                sql.Append("  @CLI_CODI,             ");
                sql.Append("  @DCL_CODD,             ");
                sql.Append("  @ITE_CTSE,             ");
                sql.Append("  @CXC_CONT,             ");
                sql.Append("  @RCX_VIGE,             ");
                sql.Append("  @AUD_UFAC,             ");
                sql.Append("  @AUD_USUA,             ");
                sql.Append("  @AUD_ESTA              ");
                sql.Append("  )                        ");
                List<SQLParams> parametros = new List<SQLParams>();
                parametros.Add(new SQLParams("EMP_CODI ", carcxcv.emp_codi));
                parametros.Add(new SQLParams("CLI_CODI ", carcxcv.cli_codi));
                parametros.Add(new SQLParams("DCL_CODD ", carcxcv.dcl_codd));
                parametros.Add(new SQLParams("ITE_CTSE ", carcxcv.ite_ctse));
                parametros.Add(new SQLParams("CXC_CONT ", carcxcv.cxc_cont));
                parametros.Add(new SQLParams("RCX_VIGE ", carcxcv.rcx_vige));
                parametros.Add(new SQLParams("AUD_UFAC ", carcxcv.aud_ufac));
                parametros.Add(new SQLParams("AUD_USUA ", carcxcv.aud_usua));
                parametros.Add(new SQLParams("AUD_ESTA ", carcxcv.aud_esta));
                var result = new DbConnection().Insert(sql.ToString(), false, parametros);
                return result;
            }
            catch (Exception ex)
            {

                ExceptionManager.Throw(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return 0;
            }

        }


        public int DeleteCaRcxcv(short emp_codi,int cxc_cont)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                  sql.Append("  DELETE                          ");
                  sql.Append("  FROM   CA_RCXCV                 ");
                  sql.Append("  WHERE  EMP_CODI = @EMP_CODI     ");
                sql.Append("  AND CXC_CONT = @CXC_CONT        ");
                List<SQLParams> parametros = new List<SQLParams>();
                parametros.Add(new SQLParams("CXC_CONT ", cxc_cont));
                parametros.Add(new SQLParams("EMP_CODI ", emp_codi));               
                var result = new DbConnection().Insert(sql.ToString(), false, parametros);
                return result;
            }
            catch (Exception ex)
            {

                ExceptionManager.Throw(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return 0;
            }
        }


    }
}