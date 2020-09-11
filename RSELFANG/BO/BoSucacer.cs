using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RSELFANG.BO
{
    public class BoSucacer
    {
        public TOTransaction<string> printReport(string ter_coda, int emp_codi, string reporte, string tna_docu="", string tna_nomb ="")
        {
            try
            {
                string usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                string sf = "";

                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                
                List<string> Params = new List<string>();
                Params.Add(emp_codi.ToString());
                Params.Add("DIGITAL WARE 102");
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(DateTime.Now.ToString("dd/MM/yyyy"));
                
                if (reporte == "SSuCacAA")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacAA(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");

                    int apo_cont = afi_info.apo_cont;
                    int afi_cont = afi_info.afi_cont;

                    sf = getAfiliadoActivo(apo_cont, afi_cont, emp_codi);
                }
                else if (reporte == "SSuCacDT")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacDT(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");
                                       
                    int afi_cont = afi_info.afi_cont;

                    sf = getADesfiliadoTraye( afi_cont, emp_codi);
                }
                else if (reporte == "SSuCacAT")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacAT(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");

                    int afi_cont = afi_info.afi_cont;

                    sf = getAfiliadoTraye(afi_cont, emp_codi);
                }
                else if (reporte == "SSuCacTD")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacTD(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");

                    int afi_cont = afi_info.afi_cont;
                    sf = getTrabajadorDesafiliado(afi_cont, emp_codi);
                }
                else if (reporte == "SSuCacDH")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacDH(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");

                    int afi_cont = afi_info.afi_cont;
                    int apo_cont = afi_info.apo_cont;
                    sf = getHistoricorDesafiliado(apo_cont,afi_cont, emp_codi);
                }
                else if (reporte == "SSuCaCBE")
                {
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCaCBE(ter_coda, emp_codi);

                    if (afi_info == null)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");

                    int afi_cont = afi_info.afi_cont;
                    int apo_cont = afi_info.apo_cont;
                    sf = getBeneficiarios(apo_cont, afi_cont, emp_codi);
                }
                else if (reporte == "SSuCacNA")
                {                                                         
                    DAOSucacer daosucacer = new DAOSucacer();
                    ToSucacer afi_info = new ToSucacer();
                    afi_info = daosucacer.GetInfoSSuCacNA(tna_docu, emp_codi);

                    if (afi_info != null)
                    {
                        int afi_cont = afi_info.afi_cont;
                        afi_info = new ToSucacer();
                        afi_info = daosucacer.GetInfoSutrayeSSuCacNA(afi_cont, emp_codi);

                        if (afi_info != null)
                            throw new Exception("Se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");
                    }
                                        
                    int prc_cont = 0;
                    prc_cont = daosucacer.setInfoTnAfi(emp_codi, tna_docu, tna_nomb);

                    if (prc_cont == 0)
                        throw new Exception("No se encuentra información correspondiente a la Identificación consultada. Verifique por favor.");
                                       
                    sf = getNoAfiliado(prc_cont, emp_codi);
                }

                url = GetURLReporte(reporte, Params, sf, urlReporte);
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

        public string getAfiliadoActivo(int apo_cont, int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} = 'A' ");
            sf.Append(" AND {SU_TRAYE.APO_CONT} = " + apo_cont);
            sf.Append(" AND {SU_TRAYE.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);
            sf.Append(" AND (ISNULL({SU_TRAYE.TRA_FCHR}) OR {SU_TRAYE.TRA_FCHR} >= " + date + ")");
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public string getADesfiliadoTraye(int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} = 'D' ");
            sf.Append(" AND {SU_TRAYE.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);
            sf.Append(" AND {SU_TRAYE.TRA_FCHR} <= " + date);
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public string getAfiliadoTraye(int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} IN ['A','D','F'] ");            
            sf.Append(" AND {SU_TRAYE.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);            
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public string getTrabajadorDesafiliado(int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} = 'D' ");
            sf.Append(" AND {SU_TRAYE.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);
            sf.Append(" AND {SU_TRAYE.TRA_FCHR} <= " + date);
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public string getHistoricorDesafiliado(int apo_cont, int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} = 'D' ");
            sf.Append(" AND {SU_TRAYE.APO_CONT} = " + apo_cont);
            sf.Append(" AND {SU_TRAYE.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);
            sf.Append(" AND {SU_TRAYE.TRA_FCHR} <= " + date);
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }
                
        public string getBeneficiarios(int apo_cont, int afi_cont, int emp_codi)
        {
            string date = "Date(" + DateTime.Now.Year + "," + DateTime.Now.Month + "," + DateTime.Now.Day + ")";
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TRAYE.TRA_ESTA} = 'A' ");
            sf.Append(" AND {SU_PERCA.PER_ESTA} = 'A' ");            
            sf.Append(" AND {SU_AFILI_PCAR.AFI_CONT} = " + afi_cont);
            sf.Append(" AND {SU_TRAYE.TRA_FCHI} <= " + date);
            sf.Append(" AND (ISNULL({SU_TRAYE.TRA_FCHR}) OR {SU_TRAYE.TRA_FCHR} >= " + date + ")");
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public string getNoAfiliado(int prc_cont, int emp_codi)
        {           
            StringBuilder sf = new StringBuilder();
            sf.Append("{SU_TNAFI.PRC_CONT} = " + prc_cont);
            sf.Append(" AND {GN_EMPRE.EMP_CODI} = " + emp_codi);
            return sf.ToString();
        }

        public TOTransaction<List<ToSuperca>> getInfoBeneficiarios(int emp_codi, string ter_coda)
        {
            try
            {
                DAOSucacer dao = new DAOSucacer();
                List<ToSuperca> result = new List<ToSuperca>();
                result = dao.getInfoBeneficiarios(emp_codi,ter_coda);
                return new TOTransaction<List<ToSuperca>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ToSuperca>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}