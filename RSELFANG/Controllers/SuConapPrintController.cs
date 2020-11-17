using System.Web.Http;
using RSELFANG.BO;
using RSELFANG.TO;


namespace RSELFANG.Controllers
{
    public class SuConapPrintController : ApiController
    {
        [Route("api/SuConap/printReportAportes")]
        public TOTransaction<string> Get(int emp_codi, int tip_codi, string afi_docu, int rad_feci, int rad_fecf, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReportAportes(emp_codi, tip_codi, afi_docu, rad_feci,rad_fecf,apo_coda);
        }

        [Route("api/SuConap/printReportSubsidio")]
        public TOTransaction<string> Get(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu, int tip_codi, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReportSubsidio(emp_codi, hgi_peri, hgi_perf, afi_docu, tip_codi, apo_coda);
        }

        [Route("api/SuConap/printReportAportesEmpresa")]
        public TOTransaction<string> Get(int emp_codi, int rad_feci, int rad_fecf, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReportAportesEmpresa(emp_codi, rad_feci, rad_fecf, apo_coda);
        }

        [Route("api/SuConap/printReportAportesFiscal")]
        public TOTransaction<string> Get(int emp_codi, int rpi_peri, string apo_coda)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReportAportesFiscal(emp_codi, rpi_peri, apo_coda);
        }

        [Route("api/SuConap/printReportSubsidioEmpresa")]
        public TOTransaction<string> Get(int emp_codi, int hgi_peri, int hgi_perf, string apo_coda, bool opt = true)
        {
            BOSuConap bo = new BOSuConap();
            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            return bo.printReportSubsidioEmpresa(emp_codi, hgi_peri, hgi_perf, apo_coda);
        }
    }
}
