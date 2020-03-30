using RSELFANG.BO;
using RSELFANG.TO;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class GnNomdiController : ApiController
    {
        [Route("api/GnNomdi/GetInfoNomdi")]
        public TOTransaction<List<GnNomdi>> Get(int emp_codi)
        {
            BOGnNomdi bo = new BOGnNomdi();
            return bo.GetGnNomdi();
        }
    }
}
