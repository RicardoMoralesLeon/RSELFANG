using RSELFANG.BO;
using RSELFANG.TO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SfConsuController : ApiController
    {
        [Route("api/sfconsu/SfConsuInfo")]
        public TOTransaction<Suafili> GetInfoSfForpo(int emp_codi,int tip_codi, string afi_docu )
        {
            BOSfConsu bo = new BOSfConsu();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.GetInfoDataSfConsu(emp_codi, tip_codi, afi_docu);
        }
    }
}
