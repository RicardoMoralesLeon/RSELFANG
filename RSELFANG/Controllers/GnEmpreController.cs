using DigitalWare.Apps.Utilities.Gn.TO;
using RSELFANG.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class GnEmpreController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TO.TOTransaction<List<Gn_Empre>> Get(string usu_codi)
        {
            return new BOGnEmpre().GetGnEmpre(usu_codi);
        }
    }
}
