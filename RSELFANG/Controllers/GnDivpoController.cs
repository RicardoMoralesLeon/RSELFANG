using DigitalWare.Apps.Utilities.Gn.BO;
using DigitalWare.Apps.Utilities.Gn.TO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class GnDivpoController : ApiController
    {

        [HttpGet]
        [Route("api/GnDivpo")]

        public TOTransaction<List<Gn_Divpo>> GetGnDivpo()
        {

            return new BOGnDivpo().GetGnDivpo();
        }
    }
}
