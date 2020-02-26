using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnMunicController : ApiController
    {
        /// <summary>
        /// Retorna todos los municipios existentes
        /// </summary>
        /// <returns></returns>
        public List<GnMunic> Get(int pai_codi)
        {
            BOGnMunic bo = new BOGnMunic();
            return bo.GetAllGnMunic(pai_codi);
        }

        /// <summary>
        /// Retorna municipios
        /// </summary>
        /// <returns></returns>
        public List<GnMunic> Get(int pai_codi, int reg_codi, int dep_codi)
        {
            BOGnMunic bo = new BOGnMunic();
            return bo.GetGnMunic(pai_codi, reg_codi, dep_codi);
        }

    }
}
