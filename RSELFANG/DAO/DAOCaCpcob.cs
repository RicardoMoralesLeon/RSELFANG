using RSELFANG.Models;
using SevenFramework.DataBase;
using SevenFramework.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.DAO
{
    public class DAOCaCpcob
    {


        public List<TOCaCpcob> GetCaCpCobConAbonos(short emp_codi, int cxc_cont)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("  SELECT *                            ");
                sql.Append("  FROM   CA_CPCOB CPC                 ");
                sql.Append("  INNER JOIN CA_CXCOB CXC             ");
                sql.Append("  ON CPC.EMP_CODI = CXC.EMP_CODI      ");
                sql.Append("  AND CPC.CXC_DEST = CXC.CXC_CONT     ");
                sql.Append("  WHERE CPC.CXC_ORIG = @CXC_CONT      ");
                sql.Append("  AND CPC.EMP_CODI = @EMP_CODI        ");
                sql.Append("  AND CXC.CXC_SALD > 0  AND CXC.CXC_TOTA<>  CXC.CXC_SALD            ");
                sql.Append("  AND CXC.CXC_ESTA = 'A' ORDER BY CXC_FUPA DESC             ");
                List<SQLParams> sqlParams = new List<SQLParams>();
                sqlParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlParams.Add(new SQLParams("CXC_CONT", cxc_cont));
                return new DbConnection().GetList<TOCaCpcob>(sql.ToString(), sqlParams);
            }
            catch (Exception ex)
            {

                ExceptionManager.Throw(this.GetType().Name, "GetCaCpCob", ex);
                return null;
            }

        }

        public List<TOCaCpcob> GetCaCpCobSinAbonos(short emp_codi, int cxc_cont)
        {
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("  SELECT *                            ");
                sql.Append("  FROM   CA_CPCOB CPC                 ");
                sql.Append("  INNER JOIN CA_CXCOB CXC             ");
                sql.Append("  ON CPC.EMP_CODI = CXC.EMP_CODI      ");
                sql.Append("  AND CPC.CXC_DEST = CXC.CXC_CONT     ");
                sql.Append("  WHERE CPC.CXC_ORIG = @CXC_CONT      ");
                sql.Append("  AND CPC.EMP_CODI = @EMP_CODI        ");
                sql.Append("  AND CXC.CXC_SALD > 0  AND CXC.CXC_TOTA =  CXC.CXC_SALD            ");
                sql.Append("  AND CXC.CXC_ESTA = 'A' ORDER BY CXC_FUPA DESC             ");
                List<SQLParams> sqlParams = new List<SQLParams>();
                sqlParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sqlParams.Add(new SQLParams("CXC_CONT", cxc_cont));
                return new DbConnection().GetList<TOCaCpcob>(sql.ToString(), sqlParams);
            }
            catch (Exception ex)
            {

                ExceptionManager.Throw(this.GetType().Name, "GetCaCpCob", ex);
                return null;
            }

        }


        public int SetCaCpcob(Ca_Cpcob cacpcob, string usu_codi)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                sql.Append("  INSERT INTO CA_CPCOB    ");
                sql.Append("  (                       ");
                sql.Append("  AUD_ESTA,               ");
                sql.Append("  AUD_USUA,               ");
                sql.Append("  AUD_UFAC,               ");
                sql.Append("  EMP_CODI,               ");
                sql.Append("  CPC_CONT,               ");
                sql.Append("  CXC_ORIG,               ");
                sql.Append("  CXC_DEST,               ");
                sql.Append("  CPC_ESTA,               ");
                sql.Append("  CPC_VIGE,               ");
                sql.Append("  CLI_CODI,               ");
                sql.Append("  DCL_CODD,               ");
                sql.Append("  ITE_CTSE                ");
                sql.Append("  )                       ");
                sql.Append("  VALUES                  ");
                sql.Append("  (                       ");
                sql.Append("  'A',                    ");
                sql.Append("  @AUD_USUA,              ");
                sql.Append("  @AUD_UFAC,              ");
                sql.Append("  @EMP_CODI,              ");
                sql.Append("  @CPC_CONT,              ");
                sql.Append("  @CXC_ORIG,              ");
                sql.Append("  @CXC_DEST,              ");
                sql.Append("  @CPC_ESTA,              ");
                sql.Append("  @CPC_VIGE,              ");
                sql.Append("  @CLI_CODI,              ");
                sql.Append("  @DCL_CODD,              ");
                sql.Append("  @ITE_CTSE               ");
                sql.Append("  )                       ");
                List<SQLParams> parametros = new List<SQLParams>();
                parametros.Add(new SQLParams("AUD_USUA", usu_codi));
                parametros.Add(new SQLParams("AUD_UFAC", DateTime.Now));
                parametros.Add(new SQLParams("EMP_CODI", cacpcob.emp_codi));
                parametros.Add(new SQLParams("CPC_CONT", cacpcob.cpc_cont));
                parametros.Add(new SQLParams("CXC_ORIG", cacpcob.cxc_orig));
                parametros.Add(new SQLParams("CXC_DEST", cacpcob.cxc_dest));
                parametros.Add(new SQLParams("CPC_ESTA", "A"));
                parametros.Add(new SQLParams("CLI_CODI", cacpcob.cli_codi));
                parametros.Add(new SQLParams("DCL_CODD", cacpcob.dcl_codd));
                parametros.Add(new SQLParams("ITE_CTSE", cacpcob.ite_ctse));
                parametros.Add(new SQLParams("CPC_VIGE", cacpcob.cpc_vige));
                var result = new DbConnection().Insert(sql.ToString(), false, parametros);
                return result;
            }
            catch (Exception)
            {

                throw;
            }

        }

        public int getConseCaCpcob(int emp_codi)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                List<SQLParams> sQLParams = new List<SQLParams>();
                sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sql.Append("   SELECT COALESCE( MAX(CPC_CONT),0) FROM CA_CPCOB WHERE EMP_CODI = @EMP_CODI ");
                var result = new DbConnection().ExecuteScalar(sql.ToString(), sQLParams);
                if (result == null)
                    return 1;
                return (int)result + 1;
            }
            catch (Exception ex)
            {
                ExceptionManager.Throw(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return 0;
            }

        }


        public int DeleteCaCpcob(int emp_codi,int cxc_dest)
        {
            StringBuilder sql = new StringBuilder();
            try
            {
                List<SQLParams> sQLParams = new List<SQLParams>();
                sQLParams.Add(new SQLParams("EMP_CODI", emp_codi));
                sQLParams.Add(new SQLParams("CXC_DEST", cxc_dest));
                sql.Append(" DELETE FROM CA_CPCOB WHERE EMP_CODI=@EMP_CODI AND CXC_DEST=@CXC_DEST ");
                return  new DbConnection().Update(sql.ToString(), sQLParams);            
            }
            catch (Exception ex)
            {
                ExceptionManager.Throw(this.GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, ex);
                return 0;
            }

        }

    }
}