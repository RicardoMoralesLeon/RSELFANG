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
    public class CaCxCobController : ApiController
    {
        // GET: api/CaCxCob
        BoCaCxcob bo = new BoCaCxcob();
        /// <summary>
        /// cOnsulta la cartera de un socio por tipo de producto
        /// </summary>
        /// <param name="cli_coda"></param>
        /// <param name="cxc_fech"></param>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<List<ToCaCxcob>> Get(string cli_coda, DateTime cxc_fech)
        {
            return bo.getcacxcob(cli_coda, cxc_fech);
        }       
    }
}
