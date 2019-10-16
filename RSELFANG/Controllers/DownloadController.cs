﻿using Digitalware.Apps.Utilities;
using Digitalware.Apps.Utilities.TO;
using Digitalware.Apps.Utilities.TO.Gn_Adju;
using DigitalWare.Apps.Utilities.Wf.BO;
using DigitalWare.Apps.Utilities.Wf.TO;
using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace RSELFANG.Controllers
{
    public class DownloadController : ApiController
    {
        // GET: api/Download
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public TOTransaction<List<Wf_Cdocu>> Get(int consecutivo,string pro_codi,string tableName,int emp_codi)
        {

            emp_codi = new tools.General().GetEmpCodi(emp_codi);
            DAOGnRadju daoRadju = new DAOGnRadju();
            DAOGnAdju daoAdju = new DAOGnAdju();
            List<Digitalware.Apps.Utilities.TO.TOGnAdjun> adjun = new List<Digitalware.Apps.Utilities.TO.TOGnAdjun>();
            string download = HttpContext.Current.Server.MapPath("../download/");          
            string alias = ConfigurationManager.AppSettings["alias"];
            string ftp = ConfigurationManager.AppSettings["servidorFTP"];
            List<Digitalware.Apps.Utilities.TO.TOGnAdjun> ficherosDescargados = new List<Digitalware.Apps.Utilities.TO.TOGnAdjun>();
            try
            {                                             
                if (alias == null)
                    throw new Exception("Parámetro alias no definido");
                if (ftp == null)
                    throw new Exception("Parámetro servidorFTP no definido");
                string userftp = FTPManager.UserFtp;
                string passFtp = FTPManager.PassFtp;

                  BOWfCdocu documents = new BOWfCdocu();
                 var result =   documents.DownloadWfCdocu(consecutivo, emp_codi);
                if (result.Retorno == 1)
                    throw new Exception(result.TxtError);
                
                //List<Digitalware.Apps.Utilities.TO.Gn_Adju.TOGnRadju> radju = daoRadju.GetRadju(emp_codi, pro_codi, String.Concat(emp_codi.ToString(), consecutivo));
                //if (radju == null || !radju.Any())
                //    throw new Exception("No hay adjuntos");
                //int rad_cont = radju.FirstOrDefault().Rad_Cont;
                //adjun = daoAdju.GetAdjun(emp_codi, rad_cont);
                //if (adjun.Count == 0)
                //    throw new Exception("No hay adjuntos");
                //foreach(Digitalware.Apps.Utilities.TO.TOGnAdjun adjunto in adjun)
                //{
                //    string directoryDefault = string.Format("ftp://{0}/Seven/docs/{1}/{1}_{2}_{3}_{4}", ftp.ToString(), tableName, emp_codi.ToString(), rad_cont,adjunto.Adj_Cont);
                //    List<DirectoryItem> filesExist = FTPManager.GetDirectoryInformation(directoryDefault);
                //    if (filesExist!=null && filesExist.Count> 0)
                //    {
                //        foreach (DirectoryItem directories in filesExist)
                //        {

                //            byte[] file =FTPManager.DownloadFtp(download, "", adjunto.Adj_Nomb, directoryDefault);
                //            ficherosDescargados.Add(adjunto);
                //        }
                //    }
                //}
                return new TOTransaction<List<Wf_Cdocu>>() { objTransaction=result.ObjTransaction, retorno = 0, txtRetorno = "" };
            }
            catch(Exception ex)
            {
                return new TOTransaction<List<Wf_Cdocu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message};
            }
               
            }


   


        // POST: api/Download
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Download/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Download/5
        public void Delete(int id)
        {
        }
    }
}
