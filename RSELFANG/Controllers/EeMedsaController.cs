using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class EeMedsaController : ApiController
    {
        [Route("api/EeMedsa/InfoServicio")]
        public TOTransaction<List<EeMedsa>> Get(int ser_cont)
        {
            BOEeMedsa bo = new BOEeMedsa();           
            return bo.GetInfo(ser_cont);
        }

        [Route("api/EeMedsa/InfoSatisfaccion")]
        public TOTransaction<List<EeSaSec>> Get(int ser_cont,int emp_codi)
        {
            BOEeMedsa bo = new BOEeMedsa();
            return bo.GetInfoSatisfaccion();
        }

        [Route("api/EeMedsa/InfoDetalleSatis")]
        public TOTransaction<List<EeDeSec>> Get(int sec_cont, bool opc1 = false)
        {
            BOEeMedsa bo = new BOEeMedsa();
            return bo.GetInfoDetalleSatisfaccion();
        }

        [Route("api/EeMedsa/InfoOportunidad")]
        public TOTransaction<List<EeSaSer>> Get(int ser_cont,int emp_codi, int rem_cont)
        {
            BOEeMedsa bo = new BOEeMedsa();
            return bo.GetInfoOportunidad(ser_cont);
        }
    }
}
