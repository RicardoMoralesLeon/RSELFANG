using RSELFANG.TO;
using RSELFANG.BO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class EeRemesController : ApiController
    {
        [Route("api/EeRemes/LoadInfoFaclien")]
        public TOTransaction<Eeremes> Get(int emp_codi, string cli_coda)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BoEeRemes bo = new BoEeRemes();
            return bo.GetInfoFaclien(emp_codi, cli_coda);
        }

        [Route("api/EeRemes/loadInfoRelesService")]
        public TOTransaction<TOPqParam> Get(int rel_serv, int emp_codi)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BoEeReles bo = new BoEeReles();
            return bo.GetInfoEerelesService(rel_serv, emp_codi);
        }

        [Route("api/EeRemes/EeRemesSaveInfo")]
        public TOTransaction Post(EeReenc eereenc)
        {
            BoEeRemes bo = new BoEeRemes();
            return bo.setInfoRemes(eereenc);
        }

        [Route("api/EeRemes/updateTratamiento")]
        public TOTransaction Get(string cli_coda)
        {
            int emp_codi = new tools.General().GetEmpCodi(0);
            BoEeRemes bo = new BoEeRemes();
            return bo.actualizarTratamiento(emp_codi, cli_coda);
        }

        [Route("api/EeRemes/loadValidInfoEnc")]
        public TOTransaction Get(string cli_coda, int ite_serv, int emp_codi = 0)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BoEeRemes bo = new BoEeRemes();
            return bo.GetInfoValidEnc(cli_coda, ite_serv, emp_codi);
        }

        [Route("api/EeRemes/loadValidInfoEncPqr")]
        public TOTransaction Get(int inp_cont,int emp_codi, bool valid = true)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BoEeRemes bo = new BoEeRemes();
            return bo.GetInfoValidEncPqr(inp_cont, emp_codi);
        }

        [Route("api/EeRemes/loadParamEncuesta")]
        public TOTransaction Get()
        {
            BoEeRemes bo = new BoEeRemes();
            return bo.GetInfoParam();
        }
    }
}
