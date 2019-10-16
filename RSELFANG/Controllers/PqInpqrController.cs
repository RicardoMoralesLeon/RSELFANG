using RSELFANG.BO;
using RSELFANG.TO;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class PqInpqrController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        // GET: api/PqInpqr
        public TOTransaction<PqInpqr> Get(int inp_cont, string inp_pass,int emp_codi = 0)
        {
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            BOPqInpqr boPqr = new BOPqInpqr();
            return boPqr.GetInfoPqrGenerated(inp_cont, inp_pass,emp_codi);
        }           

        /// <summary>
        /// Inserta una nueva PQR en seven - erp
        /// </summary>
        /// <param name="pqr"></param>
        /// <returns></returns>
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<PqInpqrSalida> Post(PqInpqr pqr)
        {
            BOPqInpqr bo = new BOPqInpqr();
            return bo.PostPqr(pqr);
        }       
    }
}
