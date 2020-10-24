using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace RSELFANG.BO
{
    public class BOSfForpo
    {  
        public TOTransaction<List<SfFovisInfo>> GetInfoModalidad(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfFovisInfo> sfmodvi = new List<SfFovisInfo>();
                sfmodvi = daoSfForpo.GetModVi(emp_codi);
                return new TOTransaction<List<SfFovisInfo>>() { objTransaction = sfmodvi, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfFovisInfo>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
                
        public TOTransaction<List<SfRadic>> GetInfoRadicado(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfRadic> sfradic = new List<SfRadic>();
                sfradic = daoSfForpo.GetInfoRadi(emp_codi);
                return new TOTransaction<List<SfRadic>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfRadic>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<SfPostu> GetInfoIdPostulante(int emp_codi, string afi_docu)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                SfPostu sfradic = new SfPostu();
                sfradic = daoSfForpo.GetInfoIdPostulante(emp_codi, afi_docu);                                
                return new TOTransaction<SfPostu>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfPostu>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        //public TOTransaction<SfFovis> GetInfoPostulante(int emp_codi, int afi_cont, bool validTope)
        //{
        //    SfFovis sffovis = new SfFovis();
        //    DAOSfForpo daoSfForpo = new DAOSfForpo();
        //    Gnmasal InfoGnMasal = new Gnmasal();
        //    InfoAportante suconyu = new InfoAportante();
        //    List<InfoEmpresa> InfoEmpre = new List<InfoEmpresa>();
            
        //    try
        //    {
        //        InfoAportante sfafili = new InfoAportante();
        //        sfafili = daoSfForpo.getInfoAportante(emp_codi, afi_cont);                
        //        sfafili.for_cond = "";

        //        InfoGnMasal = daoSfForpo.GetInfoMasal(DateTime.Now.Year);
        //        sfafili.for_ipil = daoSfForpo.getSalarioPostul(emp_codi, afi_cont);

        //        if(sfafili.for_ipil == 0)
        //            sfafili.for_ipil = daoSfForpo.getSalarioTraye(emp_codi, afi_cont);

        //        if (validTope)
        //        {
        //            if (sfafili.for_ipil > InfoGnMasal.mas_vrsm)
        //            {
        //                throw new Exception("El postulante superal el tope salarial");
        //            }
        //        }
            
        //        if (afi_cont != 0)
        //        {
        //            suconyu = daoSfForpo.getInfoConyu(emp_codi, afi_cont);
        //            var _InfoEmpre = daoSfForpo.getInfoEmpre(emp_codi, afi_cont);

        //            if (_InfoEmpre != null)
        //                InfoEmpre = _InfoEmpre;

        //            if(suconyu   == null)
        //                suconyu = new InfoAportante();
        //        }

        //        sffovis.postulante = sfafili;
        //        sffovis.conyuge = suconyu;
        //        sffovis.InfoGnmasal = InfoGnMasal;
        //        sffovis.InfoEmpresa = InfoEmpre;
        //        return new TOTransaction<SfFovis>() { objTransaction = sffovis, txtRetorno = "", retorno = 0 };
        //    }
        //    catch (Exception ex)
        //    {
        //        return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
        //    }
        //}
        
        public TOTransaction<sfforpo> GetValidInfoPostulante(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                sfforpo sfforpo = new sfforpo();
                sfforpo = daoSfForpo.GetValidInfoPostulante(emp_codi, afi_cont);

                if (sfforpo == null)
                {
                    sfforpo = new sfforpo();
                    sfforpo.for_esta = "";
                }
                
                return new TOTransaction<sfforpo>() { objTransaction = sfforpo, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<sfforpo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
           

        public TOTransaction<List<GnItems>> GetGnItems(int tit_cont)
        {
            DAOGnItems daoItems = new DAOGnItems();
            List<GnItems> ListItems = new List<GnItems>();

            try
            {
                ListItems = daoItems.GetGnItemsLupa(tit_cont, "");
                return new TOTransaction<List<GnItems>>() { objTransaction = ListItems, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<GnItems>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoConyuge(int emp_codi, int afi_cont)
        {
            InfoAportante suconyu = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                suconyu = daoSfForpo.getInfoConyu(emp_codi, afi_cont);
                return new TOTransaction<InfoAportante>() { objTransaction = suconyu, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SfPostu>> GetInfoIdConyuge(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfPostu> sfradic = new List<SfPostu>();
                sfradic = daoSfForpo.GetInfoIdConyuge(emp_codi, afi_cont);
                if (sfradic == null)
                    sfradic = new List<SfPostu>();
                return new TOTransaction<List<SfPostu>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfPostu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction<List<SfPostu>> GetInfoIdPerca(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfPostu> sfradic = new List<SfPostu>();
                sfradic = daoSfForpo.GetInfoIdPerca(emp_codi, afi_cont);
                if(sfradic==null)
                    sfradic = new List<SfPostu>();
                return new TOTransaction<List<SfPostu>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfPostu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoPerca(int emp_codi, int afi_trab, int afi_cont, string afi_docu)
        {
            InfoAportante superca = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                superca = daoSfForpo.getInfoPerca(emp_codi, afi_trab, afi_cont, afi_docu);
                return new TOTransaction<InfoAportante>() { objTransaction = superca, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoOtrosM(int emp_codi, int afi_trab, string afi_docu)
        {
            InfoAportante otrosM = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                SfPostu afiOtro = new SfPostu();
                afiOtro = daoSfForpo.GetInfoIdPostulante(emp_codi, afi_docu);

                if (afiOtro != null)
                    otrosM = daoSfForpo.getInfoAfiliSuPercaOtros(emp_codi, afiOtro.AFI_CONT);
                else
                {
                    otrosM = new InfoAportante();                   
                }

                return new TOTransaction<InfoAportante>() { objTransaction = otrosM, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
                
        public TOTransaction<InfoDfoih> GetInfoIngresos(int emp_codi, int mod_cont, double for_sala)
        {
            InfoDfoih modvi = new InfoDfoih();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                modvi = daoSfForpo.GetInfoIngresos(emp_codi, mod_cont, for_sala);
                return new TOTransaction<InfoDfoih>() { objTransaction = modvi, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoDfoih>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<sfconec>> GetInfoConceptos(int emp_codi, string con_tipo)
        {
            List<sfconec> dfore = new List<sfconec>();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                dfore = daoSfForpo.GetInfoConceptos(emp_codi, con_tipo);
                return new TOTransaction<List<sfconec>>() { objTransaction = dfore, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<sfconec>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> GetTratamiento(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                string par_ppdt = "";
                par_ppdt = daoSfForpo.GetTratamiento(emp_codi);
                return new TOTransaction<string>() { objTransaction = par_ppdt, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<Sfparam> GetSfParam(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {               
                var result = daoSfForpo.GetSfParam(emp_codi);
                return new TOTransaction<Sfparam>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<Sfparam>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<GnTipdo>> GetTipDocumento(int emp_codi)
        {
            DAOGnTipdo daoGnTipDo = new DAOGnTipdo();

            try
            {
                List<GnTipdo> GnTipdo = daoGnTipDo.getListGnTipdo();
                return new TOTransaction<List<GnTipdo>>() { objTransaction = GnTipdo, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<GnTipdo>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> GetNomenclatura()
        {
            DAOSfForpo daosfforpo = new DAOSfForpo();

            try
            {
                string SGN000008 = daosfforpo.getDigflag("SGN000008");
                return new TOTransaction<string>() { objTransaction = SGN000008, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<PoPvdor>>GetPoPvdor(int emp_codi)
        {
            DAOSfForpo daosfforpo = new DAOSfForpo();

            try
            {
                List<PoPvdor> Popvdor = daosfforpo.GetPoPvdor(emp_codi);
                return new TOTransaction<List<PoPvdor>>() { objTransaction = Popvdor, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<PoPvdor>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<SfFovis> GetInfoForpo(int emp_codi, int for_cont, int afi_cont)
        {            
            DAOSfForpo daoSfForpo = new DAOSfForpo();           
            SfFovis sffovis = new SfFovis();            
                                   
            try
            {
                sffovis = daoSfForpo.getInfoForpo(emp_codi, for_cont);

                if (sffovis.for_esta == "U" || sffovis.for_esta == "N" || sffovis.for_esta == "R" || sffovis.for_esta == "V")
                    sffovis.for_insf = "P";
                else
                    sffovis.for_insf = "A";

                sffovis.postulante = daoSfForpo.getInfoPostulanteForpo(emp_codi, for_cont);
                sffovis.conyuge = daoSfForpo.getInfoConyugeForpo(emp_codi, for_cont);
                sffovis.InfoSfDfomhP = daoSfForpo.getInfoForpoSuPerca(emp_codi, for_cont, "P");
                sffovis.InfoSfDfomhO = daoSfForpo.getInfoForpoSuPerca(emp_codi, for_cont, "O");
                sffovis.InfoGnmasal = daoSfForpo.GetInfoMasal(DateTime.Now.Year);
                sffovis.infoHogar = daoSfForpo.GetInfoHogar(emp_codi, for_cont);
                sffovis.InfoEmpresa = daoSfForpo.getInfoEmpre(emp_codi, afi_cont);
                sffovis.InfodforeA = daoSfForpo.getInfoDforeForpo(emp_codi, for_cont, "A");

                if (sffovis.InfodforeA == null)
                    sffovis.InfodforeA = new List<SfDfore>();

                foreach (SfDfore dfore in sffovis.InfodforeA)
                {
                    List<SfDdfor> ddfor = new List<SfDdfor>();
                    ddfor = daoSfForpo.getInfoDdforForpo(emp_codi, for_cont, dfore.dfo_cont);
                    
                    if (ddfor != null)
                        dfore.Infoddfor = ddfor;
                }

                sffovis.InfodforeR = daoSfForpo.getInfoDforeForpo(emp_codi, for_cont, "R");

                if (sffovis.InfodforeR == null)
                    sffovis.InfodforeR = new List<SfDfore>();

                foreach (SfDfore dfore in sffovis.InfodforeR)
                {
                    List<SfDdfor> ddfor = new List<SfDdfor>();
                    ddfor = daoSfForpo.getInfoDdforForpo(emp_codi, for_cont, dfore.dfo_cont);

                    if (ddfor != null)
                        dfore.Infoddfor = ddfor;
                }

                if (sffovis.infoHogar == null)
                    sffovis.infoHogar = new InfoDfoih();             

                if (sffovis.conyuge == null)
                    sffovis.conyuge  = new InfoAportante();

                if (sffovis.InfoSfDfomhP == null)
                    sffovis.InfoSfDfomhP = new List<InfoAportante>();

                if (sffovis.InfoSfDfomhO == null)
                    sffovis.InfoSfDfomhO = new List<InfoAportante>();

                return new TOTransaction<SfFovis>() { objTransaction = sffovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<SfFovis> GetInfoPostulante(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();
            SfFovis sffovis = new SfFovis();
            List<InfoEmpresa> InfoEmpre = new List<InfoEmpresa>();

            try
            {
                sffovis.for_insf = "P";
                sffovis.for_tdat = "N";
                sffovis.postulante = daoSfForpo.getInfoAportante(emp_codi, afi_cont);
                sffovis.conyuge = daoSfForpo.getInfoConyu(emp_codi, afi_cont);
                sffovis.InfoGnmasal = daoSfForpo.GetInfoMasal(DateTime.Now.Year);
                // sffovis.infoHogar = daoSfForpo.GetInfoHogar(emp_codi, afi_cont);
                sffovis.InfoEmpresa = daoSfForpo.getInfoEmpre(emp_codi, afi_cont);

                if (sffovis.conyuge == null)
                    sffovis.conyuge = new InfoAportante();

                if (sffovis.infoHogar == null)
                    sffovis.infoHogar = new InfoDfoih();

                if (sffovis.InfoSfDfomhP == null)
                    sffovis.InfoSfDfomhP = new List<InfoAportante>();

                if (sffovis.InfoSfDfomhO == null)
                    sffovis.InfoSfDfomhO = new List<InfoAportante>();

                if (sffovis.InfoSfDfomhP == null)
                    sffovis.InfoSfDfomhP = new List<InfoAportante>();

                if (sffovis.InfoSfDfomhO == null)
                    sffovis.InfoSfDfomhO = new List<InfoAportante>();

                if (sffovis.InfodforeA == null)
                    sffovis.InfodforeA = new List<SfDfore>();              

                if (sffovis.InfodforeR == null)
                    sffovis.InfodforeR = new List<SfDfore>();

                return new TOTransaction<SfFovis>() { objTransaction = sffovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<string> printReport(sfprint forpoPrint)
        {
            try
            {
                string usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                StringBuilder sf = new StringBuilder();
                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                
                List<string> Params = new List<string>();
                Params.Add(forpoPrint.emp_codi.ToString());
                Params.Add(forpoPrint.emp_nomb);
                Params.Add(usu_codi);
                Params.Add("dd/mm/yyyy");
                Params.Add(forpoPrint.dmo_rsmd.ToString()); // DESDE
                Params.Add(forpoPrint.dmo_rsmh.ToString()); // HASTA
                Params.Add(forpoPrint.dmo_fsvs.ToString()); // VALOR SFV
                Params.Add(forpoPrint.dfo_vsol.ToString()); // VALOR SUBSIDIO SOLICITADO

                sf.Append("{SF_FORPO.FOR_CONT} = " + forpoPrint.for_cont );
                sf.Append(" AND {AR_SUCUR.SUC_PRIC} = 'S' ");
                sf.Append(" AND {SF_FORPO.EMP_CODI} = " + forpoPrint.emp_codi );
                sf.Append(" AND {SF_FORPO.FOR_NUME} <> 0 ");

                url = GetURLReporte("SSfForpo", Params, sf.ToString(), urlReporte);
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
