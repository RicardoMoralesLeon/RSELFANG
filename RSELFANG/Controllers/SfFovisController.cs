using RSELFANG.TO;
using RSELFANG.BO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfFovisController : ApiController
    {
        [Route("api/Fovis/SfForpoSaveInfo")]
        public TOTransaction<sfforpo> Post(SfForpo sffovis)
        {
            BOSfFovis bo = new BOSfFovis();
            sffovis.InfoAportante.emp_codi = new tools.General().GetEmpCodi(sffovis.InfoAportante.emp_codi);
            return bo.InsertSfForpo(sffovis);
        }

    }
}
