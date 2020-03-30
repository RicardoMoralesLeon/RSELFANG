using RSELFANG.DAO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
