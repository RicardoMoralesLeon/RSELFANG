
using System.Collections.Generic;
using System.Web.Http;
using RSELFANG.TO;
using RSELFANG.BO;

namespace RSELFANG.Controllers
{
    public class GnTipdoController : ApiController
    {
        /// <summary>
        /// Retorna todos los tipos de documento
        /// </summary>
        /// <returns></returns>
        public List<GnTipdo> Get()
        {
            BOGnTipdo bo = new BOGnTipdo();
            return bo.GetGnTipdo();
        }
    }
}
