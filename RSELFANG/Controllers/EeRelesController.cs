using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class EeRelesController : ApiController
    {
        [Route("api/EeReles/EeRelesLoad")]
        public TOTransaction<EeReles> Get(int rel_cont)
        {         
            BoEeReles bo = new BoEeReles();            
            return bo.GetInfoDataEeReles(rel_cont);
        }

        [Route("api/EeReles/LoadInfoPqr")]
        public TOTransaction<PqInpqr> Get(int emp_codi, int inp_cont)
        {
            BoEeReles bo = new BoEeReles();
            return bo.GetInfoDataPqr(emp_codi, inp_cont);
        }

        [Route("api/EeReles/LoadPqParam")]
        public TOTransaction<TOPqParam> Get(int emp_codi, int rel_cont = 0, int inp_cont = 0)
        {
            BoEeReles bo = new BoEeReles();
            return bo.GetInfoPqParam(emp_codi);
        }

        [Route("api/EeReles/insertEreles")]
        public TOTransaction Post(List<EeResen> Ereles)
        {
            BoEeReles bo = new BoEeReles();
            return bo.setInfoResen(Ereles);
        }

        [Route("api/EeReles/insertErelem")]
        public TOTransaction Post(List<EeResem> Ereles)
        {
            BoEeReles bo = new BoEeReles();
            return bo.setInfoResem(Ereles);
        }
    }
}
