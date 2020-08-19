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

        public TOTransaction<sfforpo> InsertSfForpo(SfForpo sffovis)
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
                LEntrada.Add(sffovis.InfoAportante.emp_codi);
                LEntrada.Add(sffovis.InfoAportante.mod_cont);
                LEntrada.Add(sffovis.InfoAportante.rad_nume);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.tip_codi);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.afi_docu);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.for_cond);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.ite_codi_oc);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.ite_codi_tp);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.for_sala);
                LEntrada.Add(sffovis.InfoAportante.InfoAportante.for_tdat);
                
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
                    msgError = insertarDetallePostulante(sffovis.InfoAportante.emp_codi, result.for_cont, sffovis);

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
                deletePropo(sffovis.InfoAportante.emp_codi, result.for_cont);
            }

            return salida;
        }

        private string insertarDetallePostulante(int emp_codi, int for_cont, SfForpo sffovis)
        {
            string msgError = "";

            try
            {
                msgError = InsertSfDfoih(emp_codi, for_cont, sffovis.InfoHogar);

                if (msgError == "")
                {
                    msgError = InsertSfDfomh(emp_codi, for_cont, sffovis.InfoAportante.InfoConyuge, "C");  // -->> insertar información del conyuge

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

                        msgError = InsertSfDfore(emp_codi, for_cont, sffovis.Infodfore, sffovis.Infoddfor);
                    }
                }

            }
            catch (Exception err)
            {
                msgError= err.Message;
            }

            return msgError;
        }

        private string InsertSfDfoih(int emp_codi, int _for_cont, InfoHogar sfdfoih)
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
                LEntrada.Add(sfdfomh.afi_cond);
                LEntrada.Add(sfdfomh.apo_razs);
                LEntrada.Add(sfdfomh.for_sala);
                LEntrada.Add(sfdfomh.ite_codi_tp);
                LEntrada.Add(sfdfomh.ite_pare);
                LEntrada.Add(sfdfomh.ite_codi_oc);

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
                    LEntrada.Add(perca.ite_codi_oc);

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

        private string InsertSfDfore(int emp_codi, int _for_cont, List<SfDfore> sfdfore, List<SfDdfor> sfddfor)
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
                            error= InsertSfDdfor(emp_codi, for_cont, dfo_cont, dfore.con_codi, sfddfor);
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

        private string InsertSfDdfor(int emp_codi, int _for_cont, int dfo_cont, int con_codi ,List<SfDdfor> sfddfor)
        {          
            int for_cont = _for_cont;

            try
            {
                string txtError = "";               
                var sfdfforFil = sfddfor.Where(s => s.con_codi == con_codi).ToList();

                foreach (SfDdfor ddfor in sfdfforFil)
                {
                    object objSalida;
                    List<object> LEntrada = new List<object>();
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
            catch (Exception err)
            {
                deletePropo(emp_codi, for_cont);
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

      


    }
}