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
    public class GnPaiseController : ApiController
    {
        /// <summary>
        /// Retorna la lista de países configurada en Seven erp
        /// </summary>
        /// <returns></returns>
        public List<GnPaise> Get()
        {
            BOGnPaise bo = new BOGnPaise();
            return bo.GetGnPaise();
        }

        
    }
}
