using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.BO
{
    public class BOCfConct
    {
        public TOTransaction<TOCfConct> GetInfoCfConct(string ter_coda, int emp_codi)
        {
            DAOCfConct daoCfConct = new DAOCfConct();
            TOCfConct result = new TOCfConct();

            try
            {   
                result = daoCfConct.GetInfoCfConct(ter_coda,emp_codi);

                if (result == null)
                {
                    result = daoCfConct.GetInfoFechSald(ter_coda, emp_codi);
                    result.dim_fech = string.IsNullOrEmpty(result.dim_fech) ? "" : Convert.ToDateTime(result.dim_fech).ToString("dd/MM/yyyy");
                }                  
                else
                {
                    result.dim_fech = string.IsNullOrEmpty(result.dim_fech) ? "" : Convert.ToDateTime(result.dim_fech).ToString("dd/MM/yyyy");
                }

                return new TOTransaction<TOCfConct>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<TOCfConct>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<ToSuDimco>> GetInfoSuDimco(string ter_coda, int emp_codi, DateTime dim_feci, DateTime dim_fecf)
        {
            DAOCfConct daoCfConct = new DAOCfConct();

            try
            {
                List<ToSuDimco> result = new List<ToSuDimco>();
                result = daoCfConct.GetInfoSuDimco(ter_coda, emp_codi, dim_feci, dim_fecf);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    //result.dim_fech = string.IsNullOrEmpty(result.dim_fech) ? "" : Convert.ToDateTime(result.dim_fech).ToString("dd/MM/yyyy");
                }

                return new TOTransaction<List<ToSuDimco>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ToSuDimco>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> BuildPrintLink(TOCfConct CfConct)
        {
            try
            {
                string usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                StringBuilder sf = new StringBuilder();
              

                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                string reporte = "";
               
                reporte = "SSuConct";
                List<string> Params = new List<string>();
                Params.Add(CfConct.emp_codi.ToString());
                Params.Add(CfConct.emp_nomb);
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(DateTime.Parse(CfConct.dim_feci).ToString("dd/MM/yyyy"));
                Params.Add(DateTime.Parse(CfConct.dim_fecf).ToString("dd/MM/yyyy"));
                Params.Add( "$ " + String.Format("{0:0,0.0}", CfConct.bon_sald));

                if (CfConct.dim_fech != "")
                    Params.Add(DateTime.Parse(CfConct.dim_fech).ToString("dd/MM/yyyy"));
                else
                    Params.Add(""); // DateTime.Now.ToString("dd/MM/yyyy"));

                sf.Append("{Comando.TER_CODA}='" + CfConct.ter_coda + "'");                
                sf.Append(" AND {Comando.EMP_CODI}=" + CfConct.emp_codi);
                sf.Append(" AND {Comando.DIM_FECH}>= date(" + DateTime.Parse(CfConct.dim_feci).Year + ", " 
                                                            + DateTime.Parse(CfConct.dim_feci).Month + ", " 
                                                            + DateTime.Parse(CfConct.dim_feci).Day +  ")");
                sf.Append(" AND {Comando.DIM_FECH}< date(" + DateTime.Parse(CfConct.dim_fecf).Year + ", "
                                                           + DateTime.Parse(CfConct.dim_fecf).Month + ", "
                                                           + DateTime.Parse(CfConct.dim_fecf).Day + ")");
                sf.Append(" AND {Comando.AST_ESTA}='A'");
                sf.Append(" AND {Comando.IMC_ESTA}='A'");

                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public string GetURLReporte(string reporte, List<string> parametros, string sf, string urlreport)
        {
            string servidor = urlreport;
            string formatofecha = ConfigurationManager.AppSettings["formatoFecha"].ToString();

            string urlreporte = servidor;

            urlreporte += "?" + "nombrerpt=" + reporte;
            int i = 0;

            foreach (var item in parametros)
            {
                urlreporte += "&promptex" + i + "=" + item.ToString().Replace(" ","%20");
                i++;
            }

            urlreporte += "&sf=" + sf.Replace(" ", "%20");
            return urlreporte;
        }
    }
}