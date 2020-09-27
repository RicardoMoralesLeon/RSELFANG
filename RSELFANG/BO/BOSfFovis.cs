using Ophelia.Seven;
using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;

namespace RSELFANG.BO
{
    public class BOSfFovis
    {
        string usuario = ConfigurationManager.AppSettings["usuario"].ToString();
        string password = ConfigurationManager.AppSettings["password"].ToString();
        string alias = ConfigurationManager.AppSettings["alias"].ToString();
        SSfForpo.SSfForpoDMR ws = new SSfForpo.SSfForpoDMR();

        public TOTransaction<sfforpo> InsertSfForpo(SfFovis sffovis)
        {
            sfforpo result = new sfforpo();
          
            TOTransaction<sfforpo> salida = new TOTransaction<sfforpo>();
            string msgError="";

            try
            {
                string txtError = "";
                object varSali;
                object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SSFFORPO", "", "", "", "", "", "N", "S", "" };
                int ret = ws.ProgramLogin(varEntr, out varSali, out txtError);

                if (ret != 0)
                    throw new Exception("Se produjo un error al autenticar el programa: SSFFORPO.");

                object objSalida;
                List<object> LEntrada = new List<object>();
                LEntrada.Add(sffovis.emp_codi);
                LEntrada.Add(sffovis.mod_cont);
                LEntrada.Add(0); // Número Radicado, Si no hay radicado se envia cero
                LEntrada.Add(sffovis.postulante.tip_codi);
                LEntrada.Add(sffovis.postulante.afi_docu);
                LEntrada.Add(sffovis.postulante.for_cond);
                LEntrada.Add(sffovis.postulante.ite_codi);
                LEntrada.Add(0); // Item Tipo Postulante
                LEntrada.Add(sffovis.postulante.for_sala);
                LEntrada.Add(sffovis.for_tdat);

                if (ws.InsertarSFFORPO(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                {
                    salida.retorno = 1;
                    salida.txtRetorno = txtError;
                }
                else
                {
                    var retorno = (object[])objSalida;
                    result.for_cont = int.Parse(retorno[0].ToString());
                    result.for_nume = int.Parse(retorno[1].ToString());
                    msgError = insertarDetallePostulante(sffovis.emp_codi, result.for_cont, sffovis);

                    if (msgError != "")
                        throw new Exception(msgError);

                    salida.retorno = 0;
                    salida.txtRetorno = "Registro guardado exitosamente, # Formulario: " + result.for_nume;
                }
            }
            catch (Exception err)
            {
                salida.retorno = 1;
                salida.txtRetorno = err.Message;
                deletePropo(sffovis.emp_codi, result.for_cont);
            }

            return salida;
        }

        private string insertarDetallePostulante(int emp_codi, int for_cont, SfFovis sffovis)
        {
            string msgError = "";

            try
            {
                if(sffovis.infoHogar.mod_cspm == "S")
                {
                    msgError = InsertSfDfoih(emp_codi, for_cont, sffovis.infoHogar);
                }                

                if (msgError == "")
                {
                   msgError = InsertSfDfomh(emp_codi, for_cont, sffovis.conyuge, "C");  // -->> insertar información del conyuge

                    if (msgError == "")
                    {
                        if (sffovis.InfoSfDfomhP != null)
                        {
                            msgError = InsertSfDfomh(emp_codi, for_cont, sffovis.InfoSfDfomhP, "P");  // -->> insertar información personas a cargo
                        }

                        if (msgError == "")
                        {
                            if (sffovis.InfoSfDfomhO != null)
                            {
                                msgError = InsertSfDfomh(emp_codi, for_cont, sffovis.InfoSfDfomhO, "O");  // -->> insertar información otros Miembros
                            }
                        }

                        msgError = InsertSfDfore(emp_codi, for_cont, sffovis.InfodforeA);

                        if (msgError == "")
                        {
                            msgError = InsertSfDfore(emp_codi, for_cont, sffovis.InfodforeR);
                        }
                    }
                }

            }
            catch (Exception err)
            {
                msgError= err.Message;
            }

            return msgError;
        }

        private string InsertSfDfoih(int emp_codi, int _for_cont, InfoDfoih sfdfoih)
        {   
            int for_cont = _for_cont;

            try
            {
                string txtError = "";
                object objSalida;

                List<object> LEntrada = new List<object>();
                LEntrada.Add(emp_codi);
                LEntrada.Add(for_cont);
                LEntrada.Add(sfdfoih.pai_codi);
                LEntrada.Add(sfdfoih.reg_codi);
                LEntrada.Add(sfdfoih.dep_codi);
                LEntrada.Add(sfdfoih.mun_codi);
                LEntrada.Add(sfdfoih.loc_codi);
                LEntrada.Add(sfdfoih.bar_codi);
                LEntrada.Add(sfdfoih.dfo_dire);
                LEntrada.Add(sfdfoih.dfo_tele);
                LEntrada.Add(sfdfoih.dfo_vsol);
                LEntrada.Add(sfdfoih.dfo_vpre);
                LEntrada.Add(sfdfoih.dfo_vlot);
                LEntrada.Add(sfdfoih.dfo_vtvi);
                LEntrada.Add(sfdfoih.dfo_fesc);
                LEntrada.Add(sfdfoih.dfo_matr);
                LEntrada.Add(sfdfoih.dfo_escr);
                LEntrada.Add(sfdfoih.dfo_lurb);
                LEntrada.Add(sfdfoih.dfo_nitc);
                LEntrada.Add(sfdfoih.dfo_nomc);
                LEntrada.Add(sfdfoih.dfo_nomp);

                if (ws.InsertarSFDFOIH(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                {
                    throw new Exception(txtError);
                }
            }
            catch (Exception err)
            {                
                return err.Message;                
            }

            return "";
        }

        private string InsertSfDfomh(int emp_codi, int _for_cont, InfoAportante sfdfomh, string dfo_tipo)
        {          
            int for_cont = _for_cont;

            try
            {
                string txtError = "";                       

                if (sfdfomh.afi_docu == null)
                    return "";

                object objSalida;
                List<object> LEntrada = new List<object>();
                LEntrada.Add(emp_codi);
                LEntrada.Add(for_cont);
                LEntrada.Add(dfo_tipo);
                LEntrada.Add(sfdfomh.afi_docu);
                LEntrada.Add(sfdfomh.afi_nom1);
                LEntrada.Add(sfdfomh.afi_nom2);
                LEntrada.Add(sfdfomh.afi_ape1);
                LEntrada.Add(sfdfomh.afi_ape2);
                LEntrada.Add(DateTime.Parse(sfdfomh.afi_fecn));
                LEntrada.Add(sfdfomh.afi_esci);
                LEntrada.Add(sfdfomh.afi_gene);
                LEntrada.Add(sfdfomh.for_cond);
                LEntrada.Add(sfdfomh.apo_razs);
                LEntrada.Add(sfdfomh.for_sala);
                LEntrada.Add(sfdfomh.ite_codi_tp);
                LEntrada.Add(sfdfomh.ite_pare);
                LEntrada.Add(sfdfomh.ite_codi); // ocupacion

                if (ws.InsertarSFDFOMH(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                {
                    throw new Exception(txtError);
                }
            }
            catch (Exception err)
            {                
                return err.Message;
            }

            return "";
        }

        private string InsertSfDfomh(int emp_codi, int _for_cont, List<InfoAportante> sfdfomh, string dfo_tipo)
        {
          
            int for_cont = _for_cont;

            try
            {
                string txtError = "";
               
                foreach (InfoAportante perca in sfdfomh)
                {
                    object objSalida;
                    List<object> LEntrada = new List<object>();
                    LEntrada.Add(emp_codi);
                    LEntrada.Add(for_cont);
                    LEntrada.Add(dfo_tipo);
                    LEntrada.Add(perca.afi_docu);
                    LEntrada.Add(perca.afi_nom1);
                    LEntrada.Add(perca.afi_nom2);
                    LEntrada.Add(perca.afi_ape1);
                    LEntrada.Add(perca.afi_ape2);
                    LEntrada.Add(DateTime.Parse(perca.afi_fecn));
                    LEntrada.Add(perca.afi_esci);
                    LEntrada.Add(perca.afi_gene);
                    LEntrada.Add(perca.afi_cond);
                    LEntrada.Add(perca.apo_razs);
                    LEntrada.Add(perca.for_sala);
                    LEntrada.Add(perca.ite_codi_tp);
                    LEntrada.Add(perca.ite_pare);
                    LEntrada.Add(perca.ite_codi);

                    if (ws.InsertarSFDFOMH(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                    {
                        throw new Exception(txtError);
                    }
                }

            }
            catch (Exception err)
            {                
                return err.Message;
            }

            return "";
        }

        private string InsertSfDfore(int emp_codi, int _for_cont, List<SfDfore> sfdfore)
        {
        
            int for_cont = _for_cont;
            string error = "";

            try
            {
                string txtError = "";
              
                foreach (SfDfore dfore in sfdfore)
                {
                    object objSalida;
                    List<object> LEntrada = new List<object>();
                    LEntrada.Add(emp_codi);
                    LEntrada.Add(for_cont);
                    LEntrada.Add(dfore.con_codi);
                    LEntrada.Add(dfore.dfo_sald);

                    if (ws.InsertarSFDFORE(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                    {
                        throw new Exception(txtError);
                    }
                    else
                    {
                        int dfo_cont = 0;
                        var retorno = (object[])objSalida;
                        dfo_cont = int.Parse(retorno[0].ToString());

                        if (dfo_cont != 0)
                        {
                            foreach (SfDdfor ddfor in dfore.Infoddfor)
                            {                               
                                LEntrada = new List<object>();
                                LEntrada.Add(emp_codi);
                                LEntrada.Add(for_cont);
                                LEntrada.Add(dfo_cont);
                                LEntrada.Add(ddfor.ddf_entc);
                                LEntrada.Add(ddfor.ddf_entd);
                                LEntrada.Add(ddfor.ddf_numc);
                                LEntrada.Add(ddfor.ddf_feca);
                                LEntrada.Add(ddfor.ddf_feci);
                                LEntrada.Add(ddfor.ddf_fecc);

                                if (ws.InsertarSFDDFOR(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                                {
                                    throw new Exception(txtError);
                                }
                            }
                        }
                    }

                    if (error != "")
                        throw new Exception(error);
                }

            }
            catch (Exception err)
            {
                return err.Message;
            }

            return "";
        }       

        public TOTransaction<CtRevDoSalida> deletePropo(int emp_codi, int for_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                daoSfForpo.deletePostulante(emp_codi, for_cont);
                return new TOTransaction<CtRevDoSalida>() { objTransaction = new CtRevDoSalida() { doc_cont = 0, msg = "" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevDoSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<sfforpo> updateAllSfForpo(SfFovis sffovis)
        {
            sfforpo result = new sfforpo();
            TOTransaction<sfforpo> salida = new TOTransaction<sfforpo>();
            
            try
            {
                object varSali;
                string txtError;
                object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SSFFORPO", "", "", "", "", "", "N", "S", "" };
                int retorno = ws.ProgramLogin(varEntr, out varSali, out txtError);
                              
                List<object> lentrada = new List<object>();
                object p_salida = new object();

                lentrada.Add("ActualizarSfForpo");
                lentrada.Add(sffovis.emp_codi);
                lentrada.Add(sffovis.for_cont);
                lentrada.Add(DateTime.Now); // lDtFor_fech 
                lentrada.Add(sffovis.for_esta);
                lentrada.Add(DateTime.Now); // lDtFor_fvig 
                lentrada.Add(DateTime.Now); // lDtFor_fpro 
                lentrada.Add(sffovis.mod_cont);
                lentrada.Add(sffovis.postulante.for_cond);
                lentrada.Add(sffovis.postulante.afi_cont);
                lentrada.Add(sffovis.for_insf);
                lentrada.Add(0);
                lentrada.Add(DateTime.Now); // lDtFor_fasi 
                lentrada.Add(sffovis.postulante.ite_tipp);
                lentrada.Add(sffovis.postulante.ite_ocup);
                lentrada.Add(sffovis.postulante.for_sala);
                lentrada.Add(sffovis.postulante.for_ipil);
                lentrada.Add(sffovis.for_tdat);
                lentrada.Add(0); // lInFor_post 
                lentrada.Add(sffovis.postulante.for_ting);
                lentrada.Add(sffovis.postulante.for_nmie);
                lentrada.Add(sffovis.postulante.for_tapr);
                lentrada.Add("");  // lStFor_obse

                if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                    throw new Exception("Error Actualizando Solicitud :" + txtError);
               
                if (txtError == null)
                {
                    lentrada = new List<object>();
                    p_salida = new object();

                    lentrada.Add("ActualizarSfDfomh");
                    lentrada.Add(sffovis.emp_codi);
                    lentrada.Add(sffovis.for_cont);
                    lentrada.Add(sffovis.conyuge.dfo_cont);
                    lentrada.Add(sffovis.conyuge.afi_cont);
                    lentrada.Add("C");
                    lentrada.Add(sffovis.conyuge.afi_docu);
                    lentrada.Add(sffovis.conyuge.afi_nom1);
                    lentrada.Add(sffovis.conyuge.afi_nom2);
                    lentrada.Add(sffovis.conyuge.afi_ape1);
                    lentrada.Add(sffovis.conyuge.afi_ape2);
                    lentrada.Add(sffovis.conyuge.afi_gene);
                    lentrada.Add(sffovis.conyuge.afi_fecn);
                    lentrada.Add(sffovis.conyuge.ite_pare); 
                    lentrada.Add(sffovis.conyuge.afi_esci);
                    lentrada.Add(sffovis.conyuge.for_cond);
                    lentrada.Add(sffovis.conyuge.apo_cont);
                    lentrada.Add(sffovis.conyuge.ite_tipp);
                    lentrada.Add(sffovis.conyuge.ite_ocup);
                    lentrada.Add(sffovis.conyuge.for_sala);
                    lentrada.Add(sffovis.conyuge.for_ipil);
                    lentrada.Add(sffovis.conyuge.apo_razs);
                    lentrada.Add(sffovis.conyuge.ite_pare);
                    lentrada.Add(sffovis.conyuge.tip_codi);
                    
                    if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                        throw new Exception("Error Actualizando Solicitud :" + txtError);
                }
            }
            catch (Exception err)
            {
                salida.retorno = 1;
                salida.txtRetorno = err.Message;               
            }

            return salida;
        }


    }
}