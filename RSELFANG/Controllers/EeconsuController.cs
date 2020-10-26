using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class EeconsuController : ApiController
    {
        [Route("api/Eeconsu/loadClientes")]
        public TOTransaction<List<FaClien>> Get(int emp_codi)
        {
            BOEeConsu bo = new BOEeConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoClientes(emp_codi);
        }

        [Route("api/Eeconsu/loadInfoEereles")]
        public TOTransaction<List<EeConsu>> Get(int emp_codi, DateTime fini, DateTime ffin,int ite_cont, string cli_coda)
        {
            BOEeConsu bo = new BOEeConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoEereles(emp_codi, fini, ffin, ite_cont, cli_coda);
        }
    }
}
