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

        [Route("api/Fovis/SfForpoUpdateAllInfo")]
        public TOTransaction<sfforpo> Post(SfFovis sffovis, bool upt = true)
        {
            BOSfFovis bo = new BOSfFovis();           
            return bo.updateAllSfForpo(sffovis);
        }

        //[Route("api/Fovis/SfForpoUpdateAInfo")]
        //public TOTransaction<sfforpo> Post(SfFovis sffovis, string a = "")
        //{
        //    BOSfFovis bo = new BOSfFovis();
        //    // sffovis.InfoAportante.emp_codi = new tools.General().GetEmpCodi(sffovis.InfoAportante.emp_codi);
        //    return bo.updateSfForpo(sffovis);
        //}
    }
}
