using RSELFANG.BO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class SucacerController : ApiController
    {
        [HttpGet]
        [Route("api/sucacer/printCertificado")]
        public TOTransaction<string> printCertificado(string ter_coda, int emp_codi, string reporte)
        {
            try
            {
                BoSucacer bo = new BoSucacer();
                emp_codi = new tools.General().GetEmpCodi(emp_codi);
                return bo.printReport(ter_coda, emp_codi, reporte);
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = "No es posible generar el certificado" };
            }        
        }

        [HttpGet]
        [Route("api/sucacer/printCertificadoNoAfiliado")]
        public TOTransaction<string> printCertificado(string tna_docu, string tna_nomb,int emp_codi)
        {
            try
            {
                BoSucacer bo = new BoSucacer();
                emp_codi = new tools.General().GetEmpCodi(emp_codi);
                return bo.printReport("", emp_codi, "SSuCacNA",tna_docu, tna_nomb);
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = "No es posible generar el certificado" };
            }
        }

        [HttpGet]
        [Route("api/sucacer/getInfoBeneficiarios")]
        public TOTransaction<List<ToSuperca>> getInfoBeneficiarios(string ter_coda, int emp_codi)
        {
            try
            {
                BoSucacer bo = new BoSucacer();
                emp_codi = new tools.General().GetEmpCodi(emp_codi);
                return bo.getInfoBeneficiarios(emp_codi, ter_coda);
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ToSuperca>>() { objTransaction = null, retorno = 1, txtRetorno = "No es posible generar el certificado" };
            }
        }

    }
}
