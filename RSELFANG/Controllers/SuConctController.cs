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
    public class SuConctController : ApiController
    {
        [Route("api/suconct/SfLoadInitInfo")]
        public TOTransaction<TOCfConct> GetInfoCfConct(string ter_coda, int emp_codi)
        {
            BOCfConct bo = new BOCfConct();            
            return bo.GetInfoCfConct(ter_coda, emp_codi);
        }

        [Route("api/suconct/SfLoadSuDimco")]
        public TOTransaction<List<ToSuDimco>> GetInfoSuDimco(string ter_coda, int emp_codi, DateTime dim_feci, DateTime dim_fecf)
        {
            BOCfConct bo = new BOCfConct();
            return bo.GetInfoSuDimco(ter_coda, emp_codi, dim_feci ,dim_fecf);
        }

        [HttpPost]
        [Route("api/suconct/BuildPrintLink")]
        public TOTransaction<string> BuildPrintLink(TOCfConct CfConct)
        {
            BOCfConct bo = new BOCfConct();
            return bo.BuildPrintLink(CfConct);
        }
    }
}
