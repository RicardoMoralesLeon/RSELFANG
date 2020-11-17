using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.Text;
using System.Linq;

namespace RSELFANG.BO
{
    public class BoSuconsu
    {
        public TOTransaction<tofiliatrab> getInfoAfilitrab(int emp_codi, string afi_docu)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {
                tofiliatrab result = new tofiliatrab();
                result = daosuconsu.getInfoAfilitrab(emp_codi, afi_docu);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    result.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", result.afi_nom1, " ", result.afi_nom2, " ", result.afi_ape1, " ", result.afi_ape2);
                    result.afi_fecn = string.IsNullOrEmpty(result.afi_fecn) ? "" : Convert.ToDateTime(result.afi_fecn).ToString("dd/MM/yyyy");

                    result.sutraye = daosuconsu.getInfoSutrayeTrab(emp_codi, result.afi_cont);

                    if (result.sutraye != null)
                    {
                        foreach (toSutraye traye in result.sutraye)
                        {
                            traye.tra_fchi = string.IsNullOrEmpty(traye.tra_fchi) ? "" : Convert.ToDateTime(traye.tra_fchi).ToString("dd/MM/yyyy");
                            traye.tra_fcha = string.IsNullOrEmpty(traye.tra_fcha) ? "" : Convert.ToDateTime(traye.tra_fcha).ToString("dd/MM/yyyy");
                        }
                    }

                    result.superca = daosuconsu.getInfoSupercaTrab(emp_codi, result.afi_cont);

                    if (result.superca != null)
                    {
                        foreach (toSuperca perca in result.superca)
                        {
                            perca.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", perca.afi_nom1, " ", perca.afi_nom2, " ", perca.afi_ape1, " ", perca.afi_ape2);
                            perca.afi_fecn = string.IsNullOrEmpty(perca.afi_fecn) ? "" : Convert.ToDateTime(perca.afi_fecn).ToString("dd/MM/yyyy");
                            perca.rad_fech = string.IsNullOrEmpty(perca.rad_fech) ? "" : Convert.ToDateTime(perca.rad_fech).ToString("dd/MM/yyyy");
                        }
                    }                   
                }

                return new TOTransaction<tofiliatrab>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<tofiliatrab>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<toRnRadic>> getInfoAfilNovedad(int emp_codi, int afi_cont, DateTime rad_feci, DateTime rad_fecf)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {               
                var result = daosuconsu.getInfoAfilNovedad(emp_codi, afi_cont, rad_feci, rad_fecf);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (toRnRadic radic in result)
                    {
                        radic.rad_fech = string.IsNullOrEmpty(radic.rad_fech) ? "" : Convert.ToDateTime(radic.rad_fech).ToString("dd/MM/yyyy");
                        radic.rad_fecc = string.IsNullOrEmpty(radic.rad_fecc) ? "" : Convert.ToDateTime(radic.rad_fecc).ToString("dd/MM/yyyy");
                    }                   
                }

                return new TOTransaction<List<toRnRadic>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<toRnRadic>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<toArDpil>> getInfoAportes(int emp_codi, int afi_cont, int rpi_peri, int rpi_perf, string apo_coda, string apo_razr)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {
                var result = daosuconsu.getInfoAportes(emp_codi, afi_cont, rpi_peri, rpi_perf, apo_coda, apo_razr);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (toArDpil dpil in result)
                    {
                        dpil.rpi_fchp = string.IsNullOrEmpty(dpil.rpi_fchp) ? "" : Convert.ToDateTime(dpil.rpi_fchp).ToString("dd/MM/yyyy");                        
                    }
                }

                return new TOTransaction<List<toArDpil>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<toArDpil>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<ToSuHgicm>> getInfoSubsidios(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {
                var result = daosuconsu.getInfoSubsidios(emp_codi, hgi_peri, hgi_perf, afi_docu);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (ToSuHgicm hgi in result)
                    {
                        hgi.hgi_fech = string.IsNullOrEmpty(hgi.hgi_fech) ? "" : Convert.ToDateTime(hgi.hgi_fech).ToString("dd/MM/yyyy");
                        hgi.afi_noco = hgi.afi_nom1 + ' ' + hgi.afi_nom2 + ' ' + hgi.afi_ape1 + ' ' + hgi.afi_ape2;
                    }
                }

                return new TOTransaction<List<ToSuHgicm>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ToSuHgicm>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> BuildPrintSSuConsu(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu)
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-CO");

                string usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                StringBuilder sf = new StringBuilder();
                
                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                string reporte = "";

                reporte = "SSuConsu";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);                
                Params.Add("dd/mm/yyyy");
                sf.Append("{Comando.AFI_DOCU}='" + afi_docu + "'");
                sf.Append(" AND {Comando.EMP_CODI}=" + emp_codi);
                sf.Append(" AND {Comando.HGI_PERP}>=" + hgi_peri);
                sf.Append(" AND {Comando.HGI_PERP}<=" + hgi_perf);
                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> BuildPrintSSuConap(int emp_codi, int rpi_peri, int rpi_perf, string afi_docu)
        {
            try
            {
                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-CO");

                string usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                StringBuilder sf = new StringBuilder();

                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                string reporte = "";

                reporte = "SSuConap";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(rpi_peri.ToString());
                Params.Add(rpi_perf.ToString());
                sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + rpi_peri);
                sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + rpi_perf);
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