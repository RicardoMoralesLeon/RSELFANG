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
                LEntrada.Add(sffovis.postulante.ite_tipp); // Item Tipo Postulante
                LEntrada.Add(sffovis.postulante.for_sala);
                LEntrada.Add(sffovis.for_tdat);

                if (ws.InsertarSFFORPO(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                {
                    throw new Exception(txtError);
                }
                else
                {
                    var retorno = (object[])objSalida;
                    result.for_cont = int.Parse(retorno[0].ToString());
                    result.for_nume = int.Parse(retorno[1].ToString());
                    msgError = insertarDetallePostulante(sffovis.emp_codi, result.for_cont, sffovis);

                    if (msgError != "")
                        throw new Exception(msgError);

                    salida.txtRetorno = "Registro guardado exitosamente, # Formulario: " + result.for_nume;
                    return new TOTransaction<sfforpo>() { retorno = 0, txtRetorno = salida.txtRetorno, objTransaction = result };
                }
            }
            catch (Exception err)
            {
                salida.retorno = 1;
                salida.txtRetorno = err.Message;
                deletePropo(sffovis.emp_codi, result.for_cont);
                return new TOTransaction<sfforpo> { retorno = 1, txtRetorno = err.Message };
            }            
        }

        private string insertarDetallePostulante(int emp_codi, int for_cont, SfFovis sffovis)
        {
            string msgError = "";

            try
            {
                if (sffovis.for_cont == 0)
                    sffovis.for_cont = for_cont;

                msgError = InsertSfDfoih(emp_codi, for_cont, sffovis.infoHogar);

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

                        if (msgError == "") // --> Insertar Informacion de recursos financieros
                        {
                            updateSfForpoRecursos(sffovis, false);
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
                LEntrada.Add(null);
                LEntrada.Add(null);
                LEntrada.Add(null);
                LEntrada.Add(null);
                LEntrada.Add(null);
                LEntrada.Add(null);
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
                LEntrada.Add(sfdfoih.dfo_nomp);
                LEntrada.Add(sfdfoih.pvd_codi); 

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

                if (string.IsNullOrEmpty(sfdfomh.afi_docu))
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
                LEntrada.Add(sfdfomh.ite_tipp);

                if (dfo_tipo == "O")
                {
                    LEntrada.Add(sfdfomh.ite_pare);
                    LEntrada.Add(0);
                }
                else if (dfo_tipo == "C")
                {
                    LEntrada.Add(0);
                    LEntrada.Add(0); 
                }
                else
                {
                    LEntrada.Add(0);
                    LEntrada.Add(sfdfomh.ite_pare);
                }

                LEntrada.Add(sfdfomh.ite_ocup); // ocupacion
                LEntrada.Add(sfdfomh.tip_codi);

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
                    LEntrada.Add(perca.afi_fecn);
                    LEntrada.Add(perca.afi_esci);
                    LEntrada.Add(perca.afi_gene);
                    LEntrada.Add(perca.for_cond);
                    LEntrada.Add(""); // apo_razs
                    LEntrada.Add(perca.for_sala);
                    LEntrada.Add(perca.ite_tipp); // tipo postulante cont

                    if (dfo_tipo == "O")
                    {
                        LEntrada.Add(perca.ite_pare);
                        LEntrada.Add(0);
                    }
                    else if (dfo_tipo == "C")
                    {
                        LEntrada.Add(0);
                        LEntrada.Add(0);
                    }
                    else
                    {
                        LEntrada.Add(0);
                        LEntrada.Add(perca.ite_pare);
                    }

                    LEntrada.Add(perca.ite_ocup);
                    LEntrada.Add(perca.tip_codi);

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

        public TOTransaction<sfforpo> updateSfForpo(SfFovis sffovis)
        {
            sfforpo result = new sfforpo();
            TOTransaction<sfforpo> salida = new TOTransaction<sfforpo>();
            string txtError = "";
            DAOSfForpo daosfforpo = new DAOSfForpo();

            try
            {
                txtError = ActualizarSfForpo(sffovis);

                if (txtError != null && txtError != "")
                    throw new Exception(txtError);

                bool validInsertConyuge = daosfforpo.validInsert("SF_DFOMH", sffovis.emp_codi, sffovis.for_cont, "AND DFO_TIPO = 'C'");
                
                if (validInsertConyuge)
                {
                    txtError = InsertSfDfomh(sffovis.emp_codi, sffovis.for_cont, sffovis.conyuge, "C");
                }
                else
                {
                    txtError = ActualizarSfDfomh(sffovis.conyuge, sffovis.emp_codi, sffovis.for_cont);
                }

                if (txtError != null && txtError != "")
                    throw new Exception(txtError);
                
                bool validInsertPerca = daosfforpo.validInsert("SF_DFOMH", sffovis.emp_codi, sffovis.for_cont, "AND DFO_TIPO = 'P'");

                if (validInsertConyuge)
                {
                    txtError = InsertSfDfomh(sffovis.emp_codi, sffovis.for_cont, sffovis.InfoSfDfomhP, "P");
                }
                else
                {
                    txtError = ActualizarSfDfomhP(sffovis.InfoSfDfomhP, sffovis.emp_codi, sffovis.for_cont);
                }

                if (txtError != null && txtError != "")
                    throw new Exception(txtError);

                bool validInsertPercaOtro = daosfforpo.validInsert("SF_DFOMH", sffovis.emp_codi, sffovis.for_cont, "AND DFO_TIPO = 'O'");

                if (validInsertPercaOtro)
                {
                    txtError = InsertSfDfomh(sffovis.emp_codi, sffovis.for_cont, sffovis.InfoSfDfomhO, "O");
                }
                else
                {
                    txtError = ActualizarSfDfomhO(sffovis.InfoSfDfomhO, sffovis.emp_codi, sffovis.for_cont);
                }

                if (txtError != null && txtError !="")
                    throw new Exception(txtError);

                bool validInsertInfoHogar = daosfforpo.validInsert("SF_DFOIH", sffovis.emp_codi, sffovis.for_cont);

                if (validInsertInfoHogar)
                {
                    txtError =  InsertSfDfoih(sffovis.emp_codi, sffovis.for_cont, sffovis.infoHogar);
                }
                else
                {
                    txtError = ActualizarSfDfoih(sffovis);
                }

                if (txtError != null && txtError != "")
                    throw new Exception(txtError);

                updateSfForpoRecursos(sffovis, false);
                          
                salida.retorno = 0;
                salida.txtRetorno = "";
            }
            catch (Exception err)
            {
                salida.retorno = 1;
                salida.txtRetorno = err.Message;               
            }

            return salida;
        }

        public string ActualizarSfForpo(SfFovis sffovis)
        {
            object varSali;
            string txtError;
            object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SSFFORPO", "", "", "", "", "", "N", "S", "" };
            int retorno = ws.ProgramLogin(varEntr, out varSali, out txtError);

            if (retorno != 0)
                throw new Exception("Se produjo un error al autenticar el programa: SSFFORPO.");

            List<object> lentrada = new List<object>();
            object p_salida = new object();

            lentrada.Add("ActualizarSfForpo");
            lentrada.Add(sffovis.emp_codi);
            lentrada.Add(sffovis.for_cont);            
            lentrada.Add(sffovis.for_esta);           
            lentrada.Add(sffovis.mod_cont);
            lentrada.Add(sffovis.postulante.for_cond);
            lentrada.Add(sffovis.postulante.afi_cont);
            lentrada.Add(sffovis.for_insf);            
            lentrada.Add(sffovis.postulante.ite_tipp);
            lentrada.Add(sffovis.postulante.ite_ocup);
            lentrada.Add(sffovis.postulante.for_sala);
            lentrada.Add(sffovis.postulante.for_ipil);
            lentrada.Add(sffovis.for_tdat);            
            lentrada.Add(sffovis.infoHogar.for_ting);
            lentrada.Add(sffovis.infoHogar.for_nmie);
            lentrada.Add(0); // for_tapr
            
            if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                throw new Exception("Error Actualizando Solicitud :" + txtError);

            return txtError;
        }

        public string ActualizarSfDfomh(InfoAportante conyuge,int emp_codi, int for_cont)
        {            
            string txtError;                       
            List<object> lentrada = new List<object>();
            object p_salida = new object();

            lentrada.Add("ActualizarSfDfomh");
            lentrada.Add(emp_codi);
            lentrada.Add(for_cont);
            lentrada.Add(conyuge.dfo_cont);
            lentrada.Add(conyuge.afi_cont);
            lentrada.Add("C");
            lentrada.Add(conyuge.afi_docu);
            lentrada.Add(conyuge.afi_nom1);
            lentrada.Add(conyuge.afi_nom2);
            lentrada.Add(conyuge.afi_ape1);
            lentrada.Add(conyuge.afi_ape2);
            lentrada.Add(conyuge.afi_gene);
            lentrada.Add(DateTime.Parse(conyuge.afi_fecn));
            lentrada.Add(conyuge.ite_pare);
            lentrada.Add(conyuge.afi_esci);
            lentrada.Add(conyuge.for_cond);
            lentrada.Add(conyuge.apo_cont);
            lentrada.Add(conyuge.ite_tipp);
            lentrada.Add(conyuge.ite_ocup);
            lentrada.Add(conyuge.for_sala);
            lentrada.Add(conyuge.for_ipil);
            lentrada.Add(conyuge.apo_razs);
            lentrada.Add(conyuge.ite_pare);
            lentrada.Add(conyuge.tip_codi);
            
            if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                throw new Exception("Error Actualizando Solicitud :" + txtError);

            return txtError;
        }

        public string ActualizarSfDfomhP(List<InfoAportante> Infoperca, int emp_codi, int for_cont)
        {
            string txtError = "";

            if (Infoperca.Count == 0)
                return null;

            foreach (InfoAportante perc in Infoperca)
            {
                if (perc.afi_gene == "Masculino")
                    perc.afi_gene = "M";
                else
                    perc.afi_gene = "F";

                List<object> lentrada = new List<object>();
                object p_salida = new object();

                lentrada.Add("ActualizarSfDfomh");
                lentrada.Add(emp_codi);
                lentrada.Add(for_cont);
                lentrada.Add(perc.dfo_cont);
                lentrada.Add(perc.afi_cont);
                lentrada.Add("P");
                lentrada.Add(perc.afi_docu);
                lentrada.Add(perc.afi_nom1);
                lentrada.Add(perc.afi_nom2);
                lentrada.Add(perc.afi_ape1);
                lentrada.Add(perc.afi_ape2);
                lentrada.Add(perc.afi_gene);
                lentrada.Add(DateTime.Parse(perc.afi_fecn));
                lentrada.Add(perc.ite_pare);
                lentrada.Add(perc.afi_esci);
                lentrada.Add(perc.for_cond);
                lentrada.Add(perc.apo_cont);
                lentrada.Add(perc.ite_tipp);
                lentrada.Add(perc.ite_ocup);
                lentrada.Add(perc.for_sala);
                lentrada.Add(perc.for_ipil);
                lentrada.Add(perc.apo_razs);
                lentrada.Add(perc.ite_pare);
                lentrada.Add(perc.tip_codi);
                
                if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                    throw new Exception("Error Actualizando Solicitud :" + txtError);
            }           

            return txtError;
        }

        public string ActualizarSfDfomhO(List<InfoAportante> InfoOtraperca, int emp_codi, int for_cont)
        {
            string txtError = "";

            if (InfoOtraperca.Count == 0)
                return null;

            foreach (InfoAportante perc in InfoOtraperca)
            {
                if (perc.afi_gene == "Masculino")
                    perc.afi_gene = "M";
                else
                    perc.afi_gene = "F";

                List<object> lentrada = new List<object>();
                object p_salida = new object();

                lentrada.Add("ActualizarSfDfomh");
                lentrada.Add(emp_codi);
                lentrada.Add(for_cont);
                lentrada.Add(perc.dfo_cont);
                lentrada.Add(perc.afi_cont);
                lentrada.Add("O");
                lentrada.Add(perc.afi_docu);
                lentrada.Add(perc.afi_nom1);
                lentrada.Add(perc.afi_nom2);
                lentrada.Add(perc.afi_ape1);
                lentrada.Add(perc.afi_ape2);
                lentrada.Add(perc.afi_gene);
                lentrada.Add(DateTime.Parse(perc.afi_fecn));
                lentrada.Add(perc.ite_pare);
                lentrada.Add(perc.afi_esci);
                lentrada.Add(perc.for_cond);
                lentrada.Add(perc.apo_cont);
                lentrada.Add(perc.ite_tipp);
                lentrada.Add(perc.ite_ocup);
                lentrada.Add(perc.for_sala);
                lentrada.Add(perc.for_ipil);
                lentrada.Add(perc.apo_razs);
                lentrada.Add(perc.ite_pare);
                lentrada.Add(perc.tip_codi);

                if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                    throw new Exception("Error Actualizando Solicitud :" + txtError);
            }

            return txtError;
        }

        public string ActualizarSfDfoih(SfFovis sffovis)
        {
            string txtError;
            List<object> lentrada = new List<object>();
            object p_salida = new object();

            lentrada.Add("ActualizarSfDfoih");
            lentrada.Add(sffovis.emp_codi);
            lentrada.Add(sffovis.for_cont);           
            lentrada.Add(sffovis.infoHogar.dfo_vsol);

            lentrada.Add(sffovis.postulante.afi_cont); // afi_cont
            lentrada.Add(sffovis.postulante.afi_dire); // direccion
            lentrada.Add(sffovis.postulante.afi_mail); // email
            lentrada.Add(sffovis.postulante.afi_tele); // telefono 1
            lentrada.Add(sffovis.infoHogar.dfo_tele);  // telefono 2

            lentrada.Add(sffovis.InfoEmpresa[0].apo_cont);
            lentrada.Add(sffovis.InfoEmpresa[0].pai_codi);
            lentrada.Add(sffovis.InfoEmpresa[0].reg_codi);
            lentrada.Add(sffovis.InfoEmpresa[0].dep_codi);
            lentrada.Add(sffovis.InfoEmpresa[0].mun_codi);
            lentrada.Add(sffovis.InfoEmpresa[0].dsu_dire);

            lentrada.Add(sffovis.infoHogar.dfo_vpre);
            lentrada.Add(sffovis.infoHogar.dfo_vlot);
            lentrada.Add(sffovis.infoHogar.dfo_fesc);
            lentrada.Add(sffovis.infoHogar.dfo_matr);
            lentrada.Add(sffovis.infoHogar.dfo_escr);
            lentrada.Add(sffovis.infoHogar.dfo_lurb);
            lentrada.Add(sffovis.infoHogar.dfo_vtvi);
            lentrada.Add(sffovis.infoHogar.dfo_nomp);
            lentrada.Add(sffovis.infoHogar.pvd_codi); // pvd_codi // contructora

            if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                throw new Exception("Error Actualizando Solicitud :" + txtError);

            return txtError;
        }
        
        public TOTransaction<sfforpo> updateSfForpoRecursos(SfFovis sffovis, bool login)
        {            
            TOTransaction<sfforpo> salida = new TOTransaction<sfforpo>();
            string txtError = "";
           
            try
            {
                if (login)
                {
                    object varSali;
                    object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SSFFORPO", "", "", "", "", "", "N", "S", "" };
                    int retorno = ws.ProgramLogin(varEntr, out varSali, out txtError);

                    if (retorno != 0)
                        throw new Exception("Se produjo un error al autenticar el programa: SSFFORPO.");
                }                             

                txtError = InsertSfDfore(sffovis.emp_codi, sffovis.for_cont, sffovis.InfodforeA, sffovis.for_esta);
                               
                if (txtError != null && txtError != "")
                    throw new Exception(txtError);

                txtError = InsertSfDfore(sffovis.emp_codi, sffovis.for_cont, sffovis.InfodforeR, sffovis.for_esta);

                if (txtError != null && txtError != "")
                    throw new Exception(txtError);

                salida.retorno = 0;
                salida.txtRetorno = "";
            }
            catch (Exception err)
            {
                salida.retorno = 1;
                salida.txtRetorno = err.Message;
            }

            return salida;
        }

        private string InsertSfDfore(int emp_codi, int for_cont, List<SfDfore> sfdfore, string for_esta)
        {  
            try
            {
                string txtError = "";

                foreach (SfDfore dfore in sfdfore)
                {
                    if (dfore.dfo_cont == 0)
                    {
                        object objSalida;
                        List<object> LEntrada = new List<object>();
                        LEntrada.Add(emp_codi);
                        LEntrada.Add(for_cont);
                        LEntrada.Add(dfore.con_codi);
                        LEntrada.Add(dfore.dfo_sald);
                        LEntrada.Add(for_esta);

                        if (ws.InsertarSFDFORE(LEntrada.ToArray(), out objSalida, out txtError) != 0)
                            throw new Exception(txtError);

                        var ret = (object[])objSalida;
                        dfore.dfo_cont = int.Parse(ret[0].ToString());
                    }
                    else
                    {
                        List<object> lentrada = new List<object>();
                        object p_salida = new object();                        
                        lentrada.Add("ActualizarSfDfore");
                        lentrada.Add(emp_codi);
                        lentrada.Add(for_cont);
                        lentrada.Add(dfore.dfo_cont);
                        lentrada.Add(dfore.dfo_tipo);
                        lentrada.Add(dfore.con_cont);
                        lentrada.Add(dfore.dfo_sald);
                        lentrada.Add(for_esta);

                        if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                             throw new Exception("Error Actualizando Solicitud :" + txtError);
                    }

                    foreach(SfDdfor ddfor in dfore.Infoddfor)
                    {
                        if (ddfor.ddf_cont == 0)
                        {
                            object objSalida;
                            List<object> LEntrada = new List<object>();
                            LEntrada = new List<object>();
                            LEntrada.Add(emp_codi);
                            LEntrada.Add(for_cont);
                            LEntrada.Add(dfore.dfo_cont);
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
                        else
                        {
                            List<object> lentrada = new List<object>();
                            object p_salida = new object();
                            lentrada.Add("ActualizarSfDdfor");
                            lentrada.Add(emp_codi);
                            lentrada.Add(for_cont);
                            lentrada.Add(ddfor.dfo_cont);
                            lentrada.Add(ddfor.ddf_cont);
                            lentrada.Add(ddfor.ddf_entc);
                            lentrada.Add(ddfor.ddf_entd);
                            lentrada.Add(ddfor.ddf_numc);
                            lentrada.Add(ddfor.ddf_feca);
                            lentrada.Add(ddfor.ddf_feci);
                            lentrada.Add(ddfor.ddf_fecc);

                            if (ws.Generic(26, lentrada.ToArray(), out p_salida, out txtError) != 0)
                                throw new Exception("Error Actualizando Solicitud :" + txtError);
                        }
                    }
                }               
            }            
            catch (Exception err)
            {
                return err.Message;
            }

            return "";
        }
    }
}
