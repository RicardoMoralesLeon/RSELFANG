﻿using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class EeRelesController : ApiController
    {
        [Route("api/EeReles/EeRelesLoad")]
        public TOTransaction<EeReles> Get(int rel_cont, int rem_cont, int rel_serv = 0, int inp_cont= 0, string opt = "")
        {         
            BoEeReles bo = new BoEeReles();            
            return bo.GetInfoDataEeReles(rel_cont, rem_cont, rel_serv, inp_cont);
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

        [Route("api/EeReles/EeRelesValid")]
        public TOTransaction Get(int rem_cont, int rel_serv, bool p = false)
        {
            BoEeReles bo = new BoEeReles();
            return bo.GetInfoValidEeReles(rem_cont, rel_serv);
        }

        [Route("api/EeReles/EeRelesValidPQ")]
        public TOTransaction Get(int inp_cont, bool p = false)
        {
            BoEeReles bo = new BoEeReles();
            return bo.GetInfoValidEeRelesPQ(inp_cont);
        }
    }
}
