using RSELFANG.BO;
using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RSELFANG.Controllers
{
    public class uploadAttachmentController : ApiController
    {
        [Route("api/uploadAttachment/subirArchivoAdjunto")]
        public TOTransaction Post()
        {
            BOGnRadju boRadju = new BOGnRadju();
            var httpRequest = HttpContext.Current.Request;

            int emp_codi = 0;
            int var_cont = 0;
            string tabla = "";
            string programa = "";

            try
            {
                if (httpRequest.Files.Count == 0)
                    throw new Exception("No se recibió ningún adjunto. Contacte con su administrador del sistema");
                
                foreach (string file in httpRequest.Files)
                {
                    var postedFile = httpRequest.Files[file];

                    emp_codi = int.Parse(httpRequest.Form["EMP_CODI"]);
                    emp_codi = new tools.General().GetEmpCodi(emp_codi);

                    var_cont = int.Parse(httpRequest.Form["VAR_CONT"]);
                    tabla = httpRequest.Form["VAR_TABL"];
                    programa = httpRequest.Form["VAR_PROG"];

                    string key = string.Concat(emp_codi, var_cont);                    
                    var saveAttchment = boRadju.insertGnRadju((short)emp_codi, key, tabla, programa, var_cont, postedFile, "S");
                    if (!saveAttchment.Item1)
                        throw new Exception(string.Format("Error insertando adjunto en documentos {0}", saveAttchment.Item2));                                       
                }
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }

            return new TOTransaction() { retorno = 0, txtRetorno = "" };

        }
    }
}
