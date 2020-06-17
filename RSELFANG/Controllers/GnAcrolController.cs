using System.Collections.Generic;
using System.Web.Http;
using DigitalWare.Apps.Utilities.Gn.BO;
using DigitalWare.Apps.Utilities.Gn.TO;
using SevenFramework.TO;

namespace RSELFANG.Controllers
{
    public class GnAcrolController : ApiController
    {
        [Route("api/GnAcrol/AcrolLoad")]
        public TOTransaction<Gnmenu> Get(string reql, string filter ="")
        {
            BOGnMenca bo = new BOGnMenca();
            return bo.GetGnMenca(reql, filter);
        }
    }
}
