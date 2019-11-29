using RSELFANG.BO;
using RSELFANG.TO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfForpoController : ApiController
    {
        [Route("api/Fovis/SfForpoInitInfo")]
        public TOTransaction<SfFovis> Get(int emp_codi)
        {
            BOSfForpo bo = new BOSfForpo();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInitialDataSf(emp_codi);
        }
    }
}
