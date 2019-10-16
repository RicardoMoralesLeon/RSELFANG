using RSELFANG.BO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class EcCotizController : ApiController
    {
        BOEcCotiz bo = new BOEcCotiz();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/EcCotiz
        public TOTransaction<List<TOEcCotiz>> Get(string ter_coda, string usu_codi, int fec_fini, int fec_ffin)
        {
            return bo.GetEcCotiz(ter_coda, usu_codi, fec_fini, fec_ffin);
        }

    
    }
}
