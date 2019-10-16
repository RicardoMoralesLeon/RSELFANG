using System;
using System.Collections.Generic;
using RSELFANG.TO;
using RSELFANG.DAO;
using System.Configuration;
using RSELFANG.tools;
using System.Web;
using Digitalware.Apps.Utilities;
using Digitalware.Apps.Utilities.TO;
using Digitalware.Apps.Utilities.TO.Gn_Adju;
using DigitalWare.Apps.Utilities.Wf.BO;
using DigitalWare.Apps.Utilities.Wf.TO;
using System.Linq;
using System.IO;
using System.Net;
using Microsoft.Win32;
using Ophelia.Proteccion;
using System.Text;

namespace RSELFANG.BO
{
    public class BOCtConsu
    {
        string usuario = ConfigurationManager.AppSettings["usuario"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string alias = ConfigurationManager.AppSettings["alias"].ToString();
        string email = "";


        public BOCtConsu()
        {

        }

        public BOCtConsu(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();
            email = daoCtConsu.getSendMailTo(emp_codi, rev_cont);
        }

        public TOTransaction<List<TORevPr>> GetInfoDataCtConsu(int emp_codi, string rev_esta, string pro_codi = "", string pro_nomb = "")
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();

            try
            {
                List<TORevPr> result = new List<TORevPr>();
                result = daoCtConsu.getctconsu(emp_codi, rev_esta, pro_codi, pro_nomb);               
               if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
            
                return new TOTransaction<List<TORevPr>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<TORevPr>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropo> GetInfoCtPropo(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();

            try
            {
                CtPropo result = new CtPropo();
                result = daoCtConsu.getctpropo(emp_codi, rev_cont);               

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");

                return new TOTransaction<CtPropo>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<GnArbol>> GetInfoCtAcxpr(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();

            try
            {
                List<GnArbol> result = new List<GnArbol>();
                result = daoCtConsu.getctacxpr(emp_codi, rev_cont);
                
                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");

                return new TOTransaction<List<GnArbol>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<GnArbol>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction<List<CtRevtd>> GetInfoCtrevtd(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();

            try
            {
                List<CtRevtd> result = new List<CtRevtd>();
                result = daoCtConsu.getctrevtd(emp_codi, rev_cont);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");

                return new TOTransaction<List<CtRevtd>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<CtRevtd>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<CtRevdo>> GetInfoVigencia(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();
            DAOGnInsta daoInsta = new DAOGnInsta();

            try
            {
                List<CtRevdo> result = new List<CtRevdo>();
                GnInsta insta = daoInsta.GetGnInsta();
                                            
                
                if (insta.par_adju == "B")
                {
                    result = daoCtConsu.GetCtRevDoBD(emp_codi, rev_cont);

                    foreach (CtRevdo file in result)
                    {
                        downLoadFileFromDb(file.rad_llav, "SCTREVDO", "CT_REVDO", emp_codi, file.adj_nomb, file.adj_file);
                    }
                }
                else
                {
                    result = daoCtConsu.GetCtRevDo(emp_codi, rev_cont);

                    foreach (CtRevdo file in result)
                    {
                        downLoadFile(file.rad_llav, "SCTREVDO", "CT_REVDO", emp_codi, file.adj_nomb);
                    }
                }                

                return new TOTransaction<List<CtRevdo>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<CtRevdo>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        private void downLoadFile(string consecutivo, string pro_codi, string tableName, int emp_codi, string adj_nomb)
        {            
            DAOGnRadju daoRadju = new DAOGnRadju();
            DAOGnAdju daoAdju = new DAOGnAdju();
            List<Digitalware.Apps.Utilities.TO.TOGnAdjun> adjun = new List<Digitalware.Apps.Utilities.TO.TOGnAdjun>();

            string download = HttpContext.Current.Server.MapPath("~/download/");
            string alias = ConfigurationManager.AppSettings["alias"];
            string ftp = ConfigurationManager.AppSettings["servidorFTP"];

            List<Digitalware.Apps.Utilities.TO.TOGnAdjun> ficherosDescargados = new List<Digitalware.Apps.Utilities.TO.TOGnAdjun>();

            try
            {
                List<Digitalware.Apps.Utilities.TO.Gn_Adju.TOGnRadju> radju = daoRadju.GetRadju(emp_codi, pro_codi,  consecutivo);

                if (radju == null || !radju.Any())
                    throw new Exception("No hay adjuntos");

                int rad_cont = radju.FirstOrDefault().Rad_Cont;
                adjun = daoAdju.GetAdjun(emp_codi, rad_cont);

                if (adjun.Count == 0)
                    throw new Exception("No hay adjuntos");

                foreach (Digitalware.Apps.Utilities.TO.TOGnAdjun adjunto in adjun)
                {
                    string directoryDefault = string.Format("ftp://{0}/Seven/docs/{1}/{1}_{2}_{3}_{4}", ftp.ToString(), tableName, emp_codi.ToString(), rad_cont, adjunto.Adj_Cont);
                    List<DirectoryItem> filesExist = FTPManager.GetDirectoryInformation(directoryDefault);
                    if (filesExist != null && filesExist.Count > 0)
                    {
                        DownloadFile(directoryDefault, download + adj_nomb);

                        string data = System.IO.File.ReadAllText(download + adj_nomb);
                        using (FileStream stream = System.IO.File.Create(download + adj_nomb))
                        {
                            byte[] todecode_byte = Convert.FromBase64String(data);
                            stream.Write(todecode_byte, 0, todecode_byte.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        
        public static string DownloadFile(string FtpUrl, string tempDirPath)
        {
            string ResponseDescription = "";
            
            string downloadUrl = FtpUrl;  //String.Format("{0}/{1}", FtpUrl, FileNameToDownload);
            FtpWebRequest req = (FtpWebRequest)FtpWebRequest.Create(downloadUrl);
            req.Method = WebRequestMethods.Ftp.DownloadFile;
            req.Credentials = new NetworkCredential(FTPManager.UserFtp,FTPManager.PassFtp);
            req.UseBinary = true;
            req.Proxy = null;
            try
            {
                FtpWebResponse response = (FtpWebResponse)req.GetResponse();
                Stream stream = response.GetResponseStream();
                byte[] buffer = new byte[2048];

                FileStream fs = new FileStream(tempDirPath, FileMode.Create);
                int ReadCount = stream.Read(buffer, 0, buffer.Length);
                while (ReadCount > 0)
                {
                    fs.Write(buffer, 0, ReadCount);
                    ReadCount = stream.Read(buffer, 0, buffer.Length);
                }

                ResponseDescription = response.StatusDescription;
                fs.Close();
                stream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return ResponseDescription;
        }

        private void downLoadFileFromDb(string consecutivo, string pro_codi, string tableName, int emp_codi, string adj_nomb, byte[] adj_file)
        {
            try
            {
                string download = HttpContext.Current.Server.MapPath("~/download/");
                string utfString = Encoding.UTF8.GetString(adj_file, 0, adj_file.Length);

                using (FileStream stream = System.IO.File.Create(download + adj_nomb))
                {
                    byte[] todecode_byte = Convert.FromBase64String(utfString);
                    stream.Write(todecode_byte, 0, todecode_byte.Length);
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public TOTransaction setInfoVigencia(int emp_codi, int rev_cont, int doc_cont, bool chkApro)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();

            try
            {                
                daoCtConsu.setCtRevdo(emp_codi, rev_cont, doc_cont, chkApro);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction setStatePropo(int emp_codi, int rev_cont)
        {
            DAOCtConsu daoCtConsu = new DAOCtConsu();
            DAOGnInsta daoInsta = new DAOGnInsta();
            mailHandler mailHandler = new mailHandler();

            try
            {
                daoCtConsu.setCtpropo(emp_codi, rev_cont, "R");

                string subject = ConfigurationManager.AppSettings["asuntoRechazo"].ToString();
                string body = ConfigurationManager.AppSettings["cuerpoRechazo"].ToString();
                Mail mail = mailHandler.generateMailCtPropo(email, subject, body);
                GnInsta insta = daoInsta.GetGnInsta();
                mailHandler.sendMail(mail, insta);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction setInfoCtPropo(int emp_codi, int rev_cont)
        {
            SCtPropo.SCtPropoDMR ws = new SCtPropo.SCtPropoDMR();            
            ws.loginAlias(usuario, password, alias);
            DAOCtConsu daoCtConsu = new DAOCtConsu();
            DAOGnInsta daoInsta = new DAOGnInsta();
            mailHandler mailHandler = new mailHandler();
            CtPropo propo = new CtPropo();
            
            try
            {
                int procont = 0;
                ws.emp_codi = emp_codi;
                ws.GenerarProCont();

                string subject = ConfigurationManager.AppSettings["asuntoAprobacion"].ToString();
                string body = ConfigurationManager.AppSettings["cuerpoAprobacion"].ToString();                

                if (ws.txtError != null)
                    throw new Exception(ws.txtError);
                else
                    procont = Convert.ToInt32(ws.pro_cont);

                daoCtConsu.insertCtPropo(rev_cont, procont, emp_codi);
                daoCtConsu.insertCtDtrda(rev_cont, procont, emp_codi);
                daoCtConsu.insertCtAcxpr(rev_cont, procont, emp_codi);
                daoCtConsu.insertCtDocpr(rev_cont, procont, emp_codi);
                daoCtConsu.setCtpropo(emp_codi, rev_cont, "A");
                propo = daoCtConsu.getctpropo(emp_codi, rev_cont);

                Mail mail = mailHandler.generateMailCtPropo(propo.pro_mail,subject,body);
                GnInsta insta = daoInsta.GetGnInsta();
                mailHandler.sendMail(mail, insta);

                ws.loginAlias(usuario, password, alias);              
                ws.emp_codi = propo.emp_codi;
                ws.pro_coal = propo.pro_codi;
                ws.pro_dive = propo.pro_dive;
                ws.tip_codi = propo.tip_codi;
                ws.pro_nomb = propo.pro_nomb;
                ws.pro_apel = propo.pro_apel;
                ws.pro_clap = propo.pro_clap;
                ws.pro_nroe = propo.pro_nroe;
                ws.pro_fesc = propo.pro_fesc;
                ws.pro_nomr = propo.pro_nomr;
                ws.pro_nror = propo.pro_nror;
                ws.pvr_clad = propo.pro_clad; //clasificacion DIAN
                ws.pvr_riva = propo.pro_riva; // Regimen IVA
                ws.pvd_clad = propo.pro_claf; // clasificacion                
                ws.pro_ntel = propo.pro_ntel;
                ws.pro_mail = propo.pro_mail;
                ws.pro_nfax = propo.pro_nfax;
                ws.pro_pais = propo.pro_pais;
                ws.pro_regi = propo.pro_regi;
                ws.pro_depa = propo.pro_depa;
                ws.pro_muni = propo.pro_muni;
                ws.InsertarProveedor();


                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}