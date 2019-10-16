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
    public class GnRegioController : ApiController
    {
        /// <summary>
        /// Retorna las regiones de un pais
        /// </summary>
        /// <returns></returns>
        public List<GnRegio> Get(int pai_codi)
        {
            BOGnRegio bo = new BOGnRegio();
            return bo.GetGnRegio(pai_codi);
        }
    }
}
