using RSELFANG.BO;
using RSELFANG.TO;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class ArcaceaController : ApiController
    {
        [HttpGet]
        [Route("api/arcacea/printCertificado")]
        public TOTransaction<string> printCertificado(string ter_coda, int emp_codi, string periodo, string reporte)
        {
            BoArcacea bo = new BoArcacea();

            if (reporte == "SArCacDF")
            {

                return bo.printDesafiliacion(ter_coda, emp_codi);

                //if (bo.validInfoResol(ter_coda, emp_codi))
                //    return bo.printDesafiliacion(ter_coda, emp_codi);
                //else
                //    return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = "No es posible generar el certificado con el numero de identificación: " + ter_coda };

            }
            else if (reporte == "SArCacAF")
            {
                return bo.printAfiliacion(ter_coda, emp_codi, periodo);
            }
            else if (reporte == "SArCacPE")
            {
                return bo.printPensionado(ter_coda, emp_codi, periodo);
            }
            else if (reporte == "SArCacIN")
            {
                return bo.printIndependiente(ter_coda, emp_codi, periodo);
            }
            else
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = "No es posible generar el certificado" };
            }
        }       
    }
}
