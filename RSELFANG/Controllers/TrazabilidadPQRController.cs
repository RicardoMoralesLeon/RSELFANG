using RSELFANG.BO;
using RSELFANG.DAO;
using RSELFANG.Models;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class TrazabilidadPQRController : ApiController
    {
        [Route("api/TrazabilidadPQR/PqTrazInitInfo")]
        public TOTransaction<PqTrazab> Get(int emp_codi)
        {
            BoPqTrazabilidad bo = new BoPqTrazabilidad();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataPq(emp_codi);
        }

        [Route("api/TrazabilidadPQR/PqTrazLoadInfo")]
        public TOTransaction<List<PqTrazabilidad>> Get(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            BoPqTrazabilidad bo = new BoPqTrazabilidad();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoDataTraz(emp_codi, fini , ffin, filter);
        }

        [Route("api/TrazabilidadPQR/PqTrazLoadInfoPqr")]
        public TOTransaction<PqTrazabilidadPqr> Get(int emp_codi, int inp_cont)
        {
            BoPqTrazabilidad bo = new BoPqTrazabilidad();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoDataPQR(emp_codi, inp_cont);
        }
    }
}
