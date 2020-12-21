using RSELFANG.TO;
using System;
using RSELFANG.DAO;
using System.Collections.Generic;
using System.Configuration;
using Ophelia.Seven;

namespace RSELFANG.BO
{
    public class BoRnRadic
    {
        string usuario = ConfigurationManager.AppSettings["usuario"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string alias = ConfigurationManager.AppSettings["alias"].ToString();

        public TOTransaction<TORnRadic> GetInitialDataRnRadic(int emp_codi, string usu_codi = "")
        {
            DAORnRadic daoRadic = new DAORnRadic();
            BOGnPaise boPaise = new BOGnPaise();
            DAOGnTipdo daoGnTipDo = new DAOGnTipdo();
            List<string> GN_DIGFL = new List<string>();
            BOGnItems boItems = new BOGnItems();

            try
            {
                TORnRadic result = new TORnRadic();
                List<ArTiapo> ArTiapo = daoRadic.getListArTiapo();
                List<GnPaise> GnPaise = boPaise.GetGnPaise();
                List<GnTipdo> GnTipdo = daoGnTipDo.getListGnTipdo();
                List<GnTipdo> GnTipdE = daoGnTipDo.getListGnTipdo();

                string acr_apor = "";
                acr_apor = daoRadic.isAport(usu_codi, emp_codi, "ACR_APOR");

                List<ArApovo> ArApovo = new List<ArApovo>();

                if (acr_apor == "S")
                    ArApovo = daoRadic.getListArApovo(usu_codi);
                else
                   ArApovo = daoRadic.getListArApovo();

                List<RnGrura> RnGrura = daoRadic.getListRnGrura(emp_codi);
                List<SuMpare> SuMpare = daoRadic.getListSumPare(emp_codi);
                List<GnItem> gnprofe = boItems.GetGnItems(351);
                List<GnItem> gnconde = boItems.GetGnItems(339);
                List<GnItem> clastra = boItems.GetGnItems(334);
                List<GnItem> tipvinc = boItems.GetGnItems(338);
                List<GnItem> cartrab = boItems.GetGnItems(484);
                List<ArApovo> ArApovoAfil = daoRadic.getListArApovo(usu_codi);

                result.artiapo = ArTiapo;
                result.GnPaise = GnPaise;
                result.GnTipdo = GnTipdo;
                result.arapovo = ArApovo;
                result.rngrura = RnGrura;
                result.SuMpare = SuMpare;
                result.gnprofe = gnprofe;
                result.gnconde = gnconde;
                result.clastra = clastra;
                result.tipvinc = tipvinc;
                result.cartrab = cartrab;
                result.arapovoafil = ArApovoAfil;
                result.SRN000001 = daoRadic.getDigflag("SRN000001");
                result.SRN000002 = daoRadic.getDigflag("SRN000002");
                result.cen_codi = daoRadic.getInfoFudCe(emp_codi, usu_codi);
                return new TOTransaction<TORnRadic>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<TORnRadic>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SuAfili>> GetDataSuAfili(int emp_codi, string usu_codi = "")
        {
            DAORnRadic daoRadic = new DAORnRadic();
            
            try
            {             
                List<SuAfili> SuAfili = daoRadic.getListSuAfili(emp_codi);
                return new TOTransaction<List<SuAfili>>() { objTransaction = SuAfili, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SuAfili>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<SuAfili> getInfoAdicionalAfili(int emp_codi, int afi_cont)
        {
            DAORnRadic daoRadic = new DAORnRadic();
           
            try
            {
                SuAfili SuAfili = daoRadic.getInfoAdicionalAfili(emp_codi, afi_cont);
                return new TOTransaction<SuAfili>() { objTransaction = SuAfili, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SuAfili>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction<List<RnCraco>> GetClasificacion(int gru_cont, int emp_codi, string ter_coda)
        {
            DAORnRadic daoRadic = new DAORnRadic();

            try
            {
                string acr_apor = "";
                acr_apor = daoRadic.isAport(ter_coda, emp_codi, "ACR_APOR");

                string acr_afil = "";
                acr_afil = daoRadic.isAport(ter_coda, emp_codi, "ACR_AFIL");

                List<RnCraco> RnCraco = daoRadic.getListRnCraco(gru_cont, emp_codi, acr_apor, acr_afil);
                return new TOTransaction<List<RnCraco>>() { objTransaction = RnCraco, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<RnCraco>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<RnRadicSalida> InsertRnRadic(RnRadic rnradic)
        {
            try
            {
                DAORnRadic daoradic = new DAORnRadic();
                SRnRadic.SRnRadicDMR ws = new SRnRadic.SRnRadicDMR();
                SSuAfili.SSuAfiliDMR wa = new SSuAfili.SSuAfiliDMR();

                object varSali;
                string txtError;
                object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SRNRADIC", "", "", "", "", "", "N", "S", "" };
                int retorno = ws.ProgramLogin(varEntr, out varSali, out txtError);

                if (retorno != 0)
                    throw new Exception("Se produjo un error al autenticar el programa: SRNRADIC.");

                object[] varEntrS = { usuario, Encrypta.EncriptarClave(password), alias, "SSUAFILI", "", "", "", "", "", "N", "S", "" };
                int retornoS = wa.ProgramLogin(varEntr, out varSali, out txtError);

                if (retornoS != 0)
                    throw new Exception("Se produjo un error al autenticar el programa: SSUAFILI.");

                int rad_cont = 0;
                List<object> lentrada = new List<object>();
                object p_salida = new object();

                lentrada.Add("InsertarRnRadic");
                lentrada.Add(rnradic.emp_codi); // emp_codi
                lentrada.Add(rnradic.rad_nfol); // lrad_nfol
                lentrada.Add(rnradic.cen_codi); // lcen_codi
                lentrada.Add(rnradic.gru_codi); // lgru_codi
                lentrada.Add(rnradic.cra_codi); // lcra_codi
                lentrada.Add("0");              // lter_coda
                lentrada.Add(rnradic.rad_obse); // lrad_obse
                lentrada.Add(rnradic.tip_coda); // ltip_coda
                lentrada.Add(rnradic.apo_coda); // lapo_coda
                lentrada.Add(rnradic.apo_razs); // lapo_razs
                lentrada.Add(rnradic.tia_codi); // ltia_codi
                lentrada.Add(rnradic.dsu_tele); // lapo_tele
                lentrada.Add(rnradic.tip_codi); // ltip_codi

                lentrada.Add(rnradic.afi_docu == null ? "." : rnradic.afi_docu); // lafi_docu
                lentrada.Add(rnradic.afi_nom1 == null ? "." : rnradic.afi_nom1); // lafi_nom1
                lentrada.Add(rnradic.afi_nom2 == null ? "." : rnradic.afi_nom2); // lafi_nom2
                lentrada.Add(rnradic.afi_ape1 == null ? "." : rnradic.afi_ape1); // lafi_ape1
                lentrada.Add(rnradic.afi_ape2 == null ? "." : rnradic.afi_ape2); // lafi_ape2
                lentrada.Add(rnradic.afi_fecn.ToShortDateString() == "1/01/0001" ? DateTime.Now : rnradic.afi_fecn); // lafi_fecn
                lentrada.Add(rnradic.afi_tele == null ? "." : rnradic.afi_tele); // lafi_tele

                lentrada.Add(rnradic.rad_dire); // lrad_dire
                lentrada.Add(rnradic.rad_emai == null ? "." : rnradic.rad_emai); // lrad_emai
                lentrada.Add(rnradic.rad_pais); // lpai_codi
                lentrada.Add(rnradic.rad_regi); // lreg_codi
                lentrada.Add(rnradic.rad_depa); // ldep_codi
                lentrada.Add(rnradic.rad_muni); // lmun_codi
                lentrada.Add(rnradic.rad_loca); // lloc_codi
                lentrada.Add(rnradic.rad_barr); // lbar_codi
                lentrada.Add(rnradic.rad_tdat); // lrad_tdat

                if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                    throw new Exception("Error Insertando Radicación :" + txtError);

                var lsalida = (object[])p_salida;
                rad_cont = int.Parse(lsalida[0].ToString());
                
                foreach (RnDperc perc in rnradic.rndperc)
                {
                    int dpe_cont = 0;
                    lentrada = new List<object>();
                    p_salida = new object();

                    lentrada.Add("InsertarRnDperc");
                    lentrada.Add(rnradic.emp_codi); // emp_codi
                    lentrada.Add(rad_cont);         // rad_cont
                    lentrada.Add(0);                // ite_codi
                    lentrada.Add("N");               // ddo_esis
                    lentrada.Add("N");               // ddo_recb
                    lentrada.Add(".");               // ddo_obse
                    lentrada.Add(perc.dpe_docu);    // dpe_docu
                    lentrada.Add(perc.dpe_nom1);    // dpe_nom1
                    lentrada.Add(perc.dpe_nom2);    // dpe_nom2
                    lentrada.Add(perc.dpe_ape1);    // dpe_ape1
                    lentrada.Add(perc.dpe_ape2);    // dpe_ape2
                    lentrada.Add(perc.mpa_codi);    // mpa_codi
                    lentrada.Add("N");              // ddo_atnf
                    lentrada.Add(0);                // tip_codi
                    lentrada.Add("");               // dpe_cony
                    lentrada.Add("");               // dpe_trab

                    if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                        throw new Exception("Error Insertando grupo familiar :" + txtError);

                    var lsalidas = (object[])p_salida;
                    dpe_cont = int.Parse(lsalidas[0].ToString());

                    foreach (RnDdocu ddocu in perc.lst_ddoc)
                    {
                        lentrada = new List<object>();
                        p_salida = new object();

                        string ddo_esis = ddocu.ddo_esis ? "S" : "N";
                        string ddo_recb = ddocu.ddo_recb ? "S" : "N";

                        lentrada.Add("InsertarDocumentosWeb");
                        lentrada.Add(rnradic.emp_codi);  // emp_codi
                        lentrada.Add(rad_cont);          // rad_cont
                        lentrada.Add(ddocu.ite_cont);    // ite_cont
                        lentrada.Add(dpe_cont);          // dpe_cont
                        lentrada.Add(ddo_esis);          // ddo_esis
                        lentrada.Add(ddo_recb);          // ddo_recb
                        lentrada.Add(ddocu.ddo_obse);    // ddo_obse

                        if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                            throw new Exception("Error Insertando grupo familiar :" + txtError);

                    }
                }

                foreach (RnAfili afili in rnradic.rnafili)
                {
                    lentrada = new List<object>();
                    p_salida = new object();
                    lentrada.Add("InsertarAfiliadoWs");
                    lentrada.Add(rnradic.emp_codi);
                    lentrada.Add(rad_cont);
                    lentrada.Add(DateTime.Now);
                    lentrada.Add(afili.tip_codi);
                    lentrada.Add(afili.afi_docu);
                    lentrada.Add(afili.afi_feex);
                    lentrada.Add(DateTime.Now);
                    lentrada.Add(afili.afi_nom1);
                    lentrada.Add(afili.afi_nom2);
                    lentrada.Add(afili.afi_ape1);
                    lentrada.Add(afili.afi_ape2);
                    lentrada.Add(afili.afi_fecn);
                    lentrada.Add(afili.afi_esci);
                    lentrada.Add(afili.afi_cate);
                    lentrada.Add(afili.afi_gene);
                    lentrada.Add(afili.pro_cont);
                    lentrada.Add(afili.ite_cont);
                    lentrada.Add(afili.afi_cond);
                    lentrada.Add(afili.pai_codi);
                    lentrada.Add(afili.reg_codi);
                    lentrada.Add(afili.dep_codi);
                    lentrada.Add(afili.mun_codi);
                    lentrada.Add(afili.loc_codi);
                    lentrada.Add(afili.bar_codi);
                    lentrada.Add(afili.afi_dire);
                    lentrada.Add(afili.afi_mail);
                    lentrada.Add(afili.afi_twit);
                    lentrada.Add(afili.afi_wapp);
                    lentrada.Add(afili.afi_face);
                    lentrada.Add(afili.afi_tele);
                    lentrada.Add(afili.afi_celu);
                    lentrada.Add(afili.apo_cont);
                    lentrada.Add(afili.apo_coda);
                    lentrada.Add(afili.suc_cont);
                    lentrada.Add(DateTime.Now);
                    lentrada.Add("S");
                    lentrada.Add(afili.tra_salb);
                    lentrada.Add(afili.tia_cont); 
                    lentrada.Add(afili.ite_clat);
                    lentrada.Add(afili.ite_tipv);
                    lentrada.Add(afili.tra_ubla);
                    lentrada.Add(afili.car_codi);
                    
                    if (wa.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                        throw new Exception("Error En Afiliación Automática :" + txtError);
                }

                lentrada = new List<object>();
                p_salida = new object();

                lentrada.Add("AplicarRnRadic");
                lentrada.Add(rnradic.emp_codi);  // emp_codi
                lentrada.Add(rad_cont);          // rad_cont
         
                if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                    throw new Exception("Error Aplicando Radicación :" + txtError);

                if (txtError == null)
                {
                    if (rnradic.radtdat != null)
                    {
                        foreach (Rnradtd radtd in rnradic.radtdat)
                        {
                            daoradic.updateTratamiento(radtd, rnradic.emp_codi, rad_cont);
                        }
                    }
                }


                string radnume = daoradic.getNumeroRadicado(rad_cont);
                return new TOTransaction<RnRadicSalida>() { objTransaction = new RnRadicSalida() { rad_cont = rad_cont, msg = "", rad_nume = radnume }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<RnRadicSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<Rnradtd>> getInfoTratamiento()
        {
            DAORnRadic daoRadic = new DAORnRadic();

            try
            {
                List<Rnradtd> revtd = daoRadic.getInforevtd();
                return new TOTransaction<List<Rnradtd>>() { objTransaction = revtd, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<Rnradtd>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<RnDdocu>> getInfoDocumentos(int cra_codi)
        {
            DAORnRadic daoRadic = new DAORnRadic();

            try
            {
                List<RnDdocu> ddocu = daoRadic.getInfoDocumentos(cra_codi);
                return new TOTransaction<List<RnDdocu>>() { objTransaction = ddocu, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<RnDdocu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SuAfili>> GetInfoAfiliados(int emp_codi)
        {
            DAORnRadic daoRadic = new DAORnRadic();

            try
            {               
                List<SuAfili> SuAfili = daoRadic.getListSuAfili(emp_codi);                           
                return new TOTransaction<List<SuAfili>>() { objTransaction = SuAfili, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SuAfili>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<ArSucur>> GetInfoSucursal(int emp_codi, int apo_cont)
        {
            DAORnRadic daoRadic = new DAORnRadic();

            try
            {
                List<ArSucur> ArSucur = daoRadic.getListArSucur(emp_codi, apo_cont);
                return new TOTransaction<List<ArSucur>>() { objTransaction = ArSucur, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<ArSucur>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<ArApovo> GetInitialApovo(int emp_codi, string usu_codi)
        {
            DAORnRadic daoRadic = new DAORnRadic();
           
            try
            {              
                ArApovo ArApovo = daoRadic.getArApovo(emp_codi, usu_codi);                            
                return new TOTransaction<ArApovo>() { objTransaction = ArApovo, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<ArApovo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
        
}