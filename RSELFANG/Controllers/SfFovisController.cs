using RSELFANG.TO;
using RSELFANG.BO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfFovisController : ApiController
    {
        [Route("api/Fovis/SfForpoSaveInfo")]
        public TOTransaction<sfforpo> Post(SfFovis sffovis)
        {
            BOSfFovis bo = new BOSfFovis();           
            return bo.InsertSfForpo(sffovis);
        }

        [Route("api/Fovis/SfForpoUpdateInfo")]
        public TOTransaction<sfforpo> Post(SfFovis sffovis, bool upt = true)
        {
            BOSfFovis bo = new BOSfFovis();           
            return bo.updateSfForpo(sffovis);
        }

        [Route("api/Fovis/SfForpoUpdateInfoRecursos")]
        public TOTransaction<sfforpo> Post(SfFovis sffovis, bool upt = true, bool upt2 = true)
        {
            BOSfFovis bo = new BOSfFovis();
            return bo.updateSfForpoRecursos(sffovis, true);
        }
    }
}
