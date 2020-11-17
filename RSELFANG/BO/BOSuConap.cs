using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Configuration;
using System.Text;

namespace RSELFANG.BO
{
    public class BOSuConap
    {
        public TOTransaction<toArApovoInfo> getInfoArApovo(int emp_codi, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                toArApovoInfo result = new toArApovoInfo();
                result = daosuconap.getArApovoInfo(emp_codi, apo_coda);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {   
                    result.apo_fcha = string.IsNullOrEmpty(result.apo_fcha) ? "" : Convert.ToDateTime(result.apo_fcha).ToString("dd/MM/yyyy");
                    result.arsucurinfo = daosuconap.getArSucurInfo(emp_codi, result.apo_cont);                   
                }

                return new TOTransaction<toArApovoInfo>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<toArApovoInfo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<tofiliatrab> getInfoAfilitrab(int emp_codi, int tip_codi, string afi_docu, int apo_cont)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                tofiliatrab result = new tofiliatrab();
                result = daosuconap.getInfoAfilitrab(emp_codi, tip_codi, afi_docu, apo_cont);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    result.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", result.afi_nom1, " ", result.afi_nom2, " ", result.afi_ape1, " ", result.afi_ape2);
                    result.afi_fecn = string.IsNullOrEmpty(result.afi_fecn) ? "" : Convert.ToDateTime(result.afi_fecn).ToString("dd/MM/yyyy");
                    
                    result.superca = daosuconap.getInfoSupercaTrab(emp_codi, result.afi_cont);

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

        public TOTransaction<List<toRnRadic>> getInfoAfilNovedad(int emp_codi, string apo_coda, DateTime rad_feci, DateTime rad_fecf)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoAfilNovedad(emp_codi, apo_coda, rad_feci, rad_fecf);

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

        public TOTransaction<List<toRnRadic>> getAfilNovedadTrabLoad(int emp_codi, int tip_codi, string afi_docu, string rad_feci, string rad_fecf, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getAfilNovedadTrabLoad(emp_codi, tip_codi,afi_docu, apo_coda, rad_feci, rad_fecf);

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


        public TOTransaction<List<toArDpil>> getInfoAportes(int emp_codi, string afi_docu, int rpi_peri, int rpi_perf, string apo_coda, int tip_codi)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoAportes(emp_codi, afi_docu, rpi_peri, rpi_perf, apo_coda, tip_codi);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (toArDpil dpil in result)
                    {
                        dpil.rpi_fchp = string.IsNullOrEmpty(dpil.rpi_fchp) ? "" : Convert.ToDateTime(dpil.rpi_fchp).ToString("dd/MM/yyyy");
                        dpil.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", dpil.afi_nom1, " ", dpil.afi_nom2, " ", dpil.afi_ape1, " ", dpil.afi_ape2);

                    }
                }

                return new TOTransaction<List<toArDpil>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<toArDpil>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<ToSuHgicm>> getInfoSubsidios(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu, int tip_codi, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoSubsidios(emp_codi, hgi_peri, hgi_perf, tip_codi, afi_docu, apo_coda);

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

        public TOTransaction<List<toArDpil>> getInfoAportesEmpresa(int emp_codi, int rpi_peri, int rpi_perf, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoAportesEmpresa(emp_codi,rpi_peri, rpi_perf, apo_coda);

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

        public TOTransaction<List<toArDpil>> getInfoAportesFiscal(int emp_codi, int rpi_peri, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoAportesFiscal(emp_codi, rpi_peri, apo_coda);

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

        public TOTransaction<List<toRnRadic>> getInfoDevoluciones(int emp_codi, string apo_coda, DateTime rad_feci, DateTime rad_fecf)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoDevoluciones(emp_codi, apo_coda, rad_feci, rad_fecf);

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

        public TOTransaction<ArRdevo> getInfoDevoDetalle(int emp_codi, int rad_cont)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoDevoDetalle(emp_codi,rad_cont);

                if (result == null)
                    throw new Exception("La devolución se encuentra en trámite.");
               
                return new TOTransaction<ArRdevo>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<ArRdevo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<ToSuHgicm>> getInfoSubsidiosEmpresa(int emp_codi, int hgi_peri, int hgi_perf, string apo_coda)
        {
            DAOSuConap daosuconap = new DAOSuConap();

            try
            {
                var result = daosuconap.getInfoSubsidiosEmpresa(emp_codi, hgi_peri, hgi_perf, apo_coda);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (ToSuHgicm hgi in result)
                    {
                        hgi.hgi_fech = string.IsNullOrEmpty(hgi.hgi_fech) ? "" : Convert.ToDateTime(hgi.hgi_fech).ToString("dd/MM/yyyy");                       
                    }
                }

                return new TOTransaction<List<ToSuHgicm>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ToSuHgicm>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReportAportes(int emp_codi, int tip_codi, string afi_docu, int rad_feci, int rad_fecf, string apo_coda)
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

                reporte = "SSuCoapo";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                //Params.Add(hgi_peri.ToString());
                //Params.Add(hgi_perf.ToString());
                //sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                //sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + hgi_peri);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + hgi_perf);
                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReportSubsidio(int emp_codi, int hgi_peri, int hgi_perf, string afi_docu, int tip_codi, string apo_coda)
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

                reporte = "SSuCosub";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                //Params.Add(hgi_peri.ToString());
                //Params.Add(hgi_perf.ToString());
                //sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                //sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + hgi_peri);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + hgi_perf);
                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReportAportesEmpresa(int emp_codi, int rad_feci, int rad_fecf, string apo_coda)
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

                reporte = "SSuCoape";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                //Params.Add(hgi_peri.ToString());
                //Params.Add(hgi_perf.ToString());
                //sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                //sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + hgi_peri);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + hgi_perf);
                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReportAportesFiscal(int emp_codi, int rpi_peri, string apo_coda)
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

                reporte = "SSuCoapf";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                //Params.Add(hgi_peri.ToString());
                //Params.Add(hgi_perf.ToString());
                //sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                //sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + hgi_peri);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + hgi_perf);
                url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                return new TOTransaction<string>() { objTransaction = url, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReportSubsidioEmpresa(int emp_codi, int hgi_peri, int hgi_perf, string apo_coda)
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

                reporte = "SSuCosue";
                List<string> Params = new List<string>();
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(hgi_peri.ToString());
                Params.Add(hgi_perf.ToString());
                //sf.Append("{SU_AFILI.AFI_DOCU}='" + afi_docu + "'");
                //sf.Append(" AND {SU_AFILI.EMP_CODI}=" + emp_codi);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}>=" + hgi_peri);
                //sf.Append(" AND {AR_RPILA.RPI_PERI}<=" + hgi_perf);
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