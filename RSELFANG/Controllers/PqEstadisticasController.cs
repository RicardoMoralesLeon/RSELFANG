using RSELFANG.TO;
using System;
using System.Collections.Generic;
using RSELFANG.BO;
using System.Web.Http;
using RSELFANG.Models;

namespace RSELFANG.Controllers
{
    public class PqEstadisticasController : ApiController
    {
        [Route("api/PqEstadisticas/Pqestad")]
        public TOTransaction<Pqestad> Get(int emp_codi)
        {
            BoPqEstadisticas bo = new BoPqEstadisticas();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataPqEstad(emp_codi);
        }

        [Route("api/PqEstadisticas/InfoPqestad")]
        public TOTransaction<List<InfoPqEstad>> Get(int emp_codi, DateTime fini, DateTime ffin, string type, string filter)
        {
            BoPqEstadisticas bo = new BoPqEstadisticas();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoPqEstadisticas(emp_codi, fini, ffin, type, filter);
        }
    }
}
