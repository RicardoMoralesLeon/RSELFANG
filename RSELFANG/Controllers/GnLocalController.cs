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
    public class GnLocalController : ApiController
    {
        /// <summary>
        /// Retorna todos las localidades existentes
        /// </summary>
        /// <returns></returns>
        public List<GnLocal> Get(int pai_codi, int reg_codi, int dep_codi, int mun_codi)
        {
            BOGnLocal bo = new BOGnLocal();
            return bo.GetGnLocal(pai_codi, reg_codi, dep_codi, mun_codi);
        }
    }
}
