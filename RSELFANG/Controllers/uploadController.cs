using RSELFANG.BO;
using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class uploadController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]
       
       
        public TOTransaction Post()
        {
            BOGnRadju boRadju = new BOGnRadju();
            var httpRequest = HttpContext.Current.Request;
            int emp_codi = 0;          
                int inp_cont = 0;
                try
                {
                if (httpRequest.Files.Count == 0)
                    throw new Exception("No se recibió ningún adjunto. Contacte con su administrador del sistema");


                    foreach (string file in httpRequest.Files)
                    {                       
                        var postedFile = httpRequest.Files[file];

                        emp_codi = int.Parse(httpRequest.Form["EMP_CODI"]);
                        emp_codi = new tools.General().GetEmpCodi(emp_codi);
                      
                        inp_cont = int.Parse(httpRequest.Form["INP_CONT"]);
                        PqInpqr pqr = new DAOPqInpqr().getPqInPqr(inp_cont, emp_codi).FirstOrDefault();
                        if (pqr == null)
                            throw new Exception("Registro no encontrado");
                                // var filePath = HttpContext.Current.Server.MapPath("~/Upload/" + postedFile.FileName);
                        string key = string.Concat(emp_codi, inp_cont);
                        //Sube archivo a documentos
                        var saveAttchment =   boRadju.insertGnRadju((short) emp_codi, key, "PQ_INPQR", "SPQINPQR",inp_cont, postedFile,"S");
                        if (!saveAttchment.Item1)
                            throw new Exception(string.Format("Error insertando adjunto en documentos {0}", saveAttchment.Item2));
                        
                        //Sube archivo a workflow
                         saveAttchment = boRadju.insertGnRadju((short)emp_codi, key, "PQ_INPQR", "SPQINPQR", pqr.cas_cont, postedFile,"W");
                        if (!saveAttchment.Item1)
                            throw new Exception(string.Format("Error insertando adjunto en flujo {0}", saveAttchment.Item2));
                    }
                }
                catch(Exception ex)
                {
                    DAOPqInpqr daoPqr = new DAOPqInpqr();
                    daoPqr.deletePqr(inp_cont);
                    return new TOTransaction() { retorno = 1, txtRetorno = ex.Message};
                }
           
           
            return new TOTransaction() { retorno = 0, txtRetorno = "" };

        }


    }
}
