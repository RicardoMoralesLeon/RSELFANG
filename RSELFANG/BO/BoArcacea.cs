using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RSELFANG.BO
{
    public class BoArcacea
    {
        public bool validInfoResol(string ter_coda, int emp_codi)
        {
            try
            {
                DAOArcacea dao = new DAOArcacea();
                return dao.GetInfoArResol(ter_coda, emp_codi);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool validInfoAfiliacion(string ter_coda, int emp_codi, string periodo)
        {
            try
            {
                DAOArcacea dao = new DAOArcacea();
                string PeriInic = "";
                string PeriFina = "";

                if (int.Parse(periodo.Substring(0, 2)) - 1 == 0)
                    PeriInic = (int.Parse(periodo.Substring(3, 4)) - 1).ToString() + "12";

                else
                    PeriInic = periodo.Substring(3, 4) + (int.Parse(periodo.Substring(0, 2)) - 1).ToString();

                PeriFina = periodo.Substring(3, 4) + periodo.Substring(0, 2);
                return dao.GetInfoAfiliado(ter_coda, emp_codi, PeriInic, PeriFina);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public TOTransaction<string> printAfiliacion(string ter_coda, int emp_codi, string periodo)
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

                string PeriInic = "";
                string PeriFina = "";

                if (int.Parse(periodo.Substring(0, 2)) - 1 == 0)                
                    PeriInic = (int.Parse(periodo.Substring(3, 4)) - 1).ToString() + "12";
                
                else                
                    PeriInic = periodo.Substring(3, 4) + (int.Parse(periodo.Substring(0, 2)) - 1).ToString();                                

                PeriFina = periodo.Substring(3, 4) + periodo.Substring(0, 2);

                reporte = "SArCacAF";
                List<string> Params = new List<string>();
                Params.Add(emp_codi.ToString());
                Params.Add("");
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(PeriInic);
                Params.Add(PeriFina);
                sf.Append("{AR_APOVO.APO_CODA} = '" + ter_coda + "' ");
                sf.Append(" AND {AR_APOVO.APO_ESTD} = 'A' ");
                sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);

                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printPensionado(string ter_coda, int emp_codi, string periodo)
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

                string PeriInic = "";
                string PeriFina = "";

                if (int.Parse(periodo.Substring(0, 2)) - 1 == 0)
                    PeriInic = (int.Parse(periodo.Substring(3, 4)) - 1).ToString() + "12";

                else
                    PeriInic = periodo.Substring(3, 4) + (int.Parse(periodo.Substring(0, 2)) - 1).ToString();

                PeriFina = periodo.Substring(3, 4) + periodo.Substring(0, 2);

                reporte = "SArCacPE";
                List<string> Params = new List<string>();
                Params.Add(emp_codi.ToString());
                Params.Add("");
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(PeriInic);
                Params.Add(PeriFina);
                sf.Append("{AR_APOVO.APO_CODA} = '" + ter_coda + "'");
                sf.Append(" AND {AR_RPILA.RPI_DEPO} = 'N' ");
                sf.Append(" AND {AR_RPILA.RPI_ESTC} = 'C' ");
                sf.Append(" AND {AR_RPILA.RPI_ESTA} = 'A' ");
                sf.Append(" AND {AR_APOVO.APO_ESTD} = 'A' ");
                sf.Append(" AND {AR_RPILA.RPI_PERI} >= {?PeriodoAnterior}");
                sf.Append(" AND {AR_RPILA.RPI_PERI} <= {?Periodo}");               
                sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);

                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printIndependiente(string ter_coda, int emp_codi, string periodo)
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

                string PeriInic = "";
                string PeriFina = "";

                if (int.Parse(periodo.Substring(0, 2)) - 1 == 0)
                    PeriInic = (int.Parse(periodo.Substring(3, 4)) - 1).ToString() + "12";

                else
                    PeriInic = periodo.Substring(3, 4) + (int.Parse(periodo.Substring(0, 2)) - 1).ToString();

                PeriFina = periodo.Substring(3, 4) + periodo.Substring(0, 2);

                reporte = "SArCacIN";
                List<string> Params = new List<string>();
                Params.Add(emp_codi.ToString());
                Params.Add("");
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(PeriInic);
                Params.Add(PeriFina);
                sf.Append("{AR_APOVO.APO_CODA} = '" + ter_coda + "' ");
                sf.Append(" AND {AR_APOVO.APO_ESTD} = 'A' ");
                sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);

                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printDesafiliacion(string ter_coda, int emp_codi)
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

                reporte = "SArCacDF";
                List<string> Params = new List<string>();
                Params.Add(emp_codi.ToString());
                Params.Add("");
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");                
                Params.Add(DateTime.Now.Year.ToString());

                sf.Append("{AR_RESOL.RES_ESTA} = 'A' ");
                sf.Append(" AND {AR_RESOL.RES_TIRE} = 'D' ");
                sf.Append(" AND YEAR({AR_APOVO.APO_FCRE}) <= " + DateTime.Now.Year.ToString());
                sf.Append(" AND {AR_APOVO.APO_CODA} = '" + ter_coda + "'");
                sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
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
                urlreporte += "&promptex" + i + "=" + item.ToString().Replace(" ", "%20");
                i++;
            }

            urlreporte += "&sf=" + sf.Replace(" ", "%20");
            return urlreporte;
        }
    }
}