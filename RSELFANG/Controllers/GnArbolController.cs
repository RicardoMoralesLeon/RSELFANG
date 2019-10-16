using RSELFANG.BO;
using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class GnArbolController : ApiController
    {
        /// <summary>
        /// Consulta arboles en seven erp
        /// </summary>
        /// <param name="tar_codi"></param>
        /// <param name="arb_codi"></param>
        /// <returns></returns>
         [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<List<GnArbol>>  Get(string tar_codi,string arb_codi,int emp_codi)
        {
            BOGnArbol bo = new BOGnArbol();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetGbnArbol(tar_codi, arb_codi,emp_codi);
        }

        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<GnArbol> Get(int con_cont,int emp_codi)
        {
            DAOCtContr dao = new DAOCtContr();
            GnArbol result = new GnArbol();
            try
            {
                var contrato = new DAOCtContr().GetCtCont(con_cont,emp_codi);
                if (contrato.con_tdis == "M")
                {
                    result = dao.GetCtDcontManual(con_cont,emp_codi);
                }
                else
                {
                    result = dao.GetCtDcont(con_cont,emp_codi);
                }
             
                return new TOTransaction<GnArbol>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch(Exception ex)
            {
                return new TOTransaction<GnArbol>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }           
        }
    }
}
