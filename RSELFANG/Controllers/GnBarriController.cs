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
    public class GnBarriController : ApiController
    {
        /// <summary>
        /// Retorna todos los barrios existentes
        /// </summary>
        /// <returns></returns>
        public List<GnBarri> Get(int pai_codi, int reg_codi, int dep_codi, int mun_codi, int loc_codi)
        {
            BOGnBarri bo = new BOGnBarri();
            return bo.GetGnBarri(pai_codi, reg_codi, dep_codi, mun_codi, loc_codi);
        }
    }
}
