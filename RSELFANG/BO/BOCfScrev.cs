using Digitalware.Apps.Utilities.Cf.DAO;
using Digitalware.Apps.Utilities.Cf.Models;
using Digitalware.Apps.Utilities.Fa.DAO;
using DigitalWare.Apps.Utilities.Gn.DAO;
using RSELFANG.DAO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOCfScrev
    {
        public TOTransaction SetCfScrev(Cf_Screv credito)
        {

            var daoCodeu = new DAO_Cf_Codeu();
            try
            {


                if (credito.codeudores != null)
                {
                    foreach(Cf_Codeu codeudor in credito.codeudores)
                    {
                        if (codeudor.cod_cont == 0)
                        {
                            codeudor.cod_cont = daoCodeu.GetContCfCodeu(codeudor.emp_codi);
                           daoCodeu.SetCfCodeu(codeudor);
                        }
                        else
                        {
                            daoCodeu.Update(codeudor);
                        }
                       

                        if (codeudor.referencias != null && codeudor.referencias.Any())
                        {

                                foreach(Cf_Refen referecia  in codeudor.referencias)
                            {
                                referecia.cod_cont = codeudor.cod_cont;
                                //referecia.ref_cont = codeudor.referencias.IndexOf(referecia) + 1;
                                referecia.ref_noco = string.Format("{0} {1} {2} {3}", referecia.ref_nm1r, referecia.ref_nm2r, referecia.ref_ap1r, referecia.ref_ap2r);
                                new DAO_Cf_Refen().SetCfRefe(referecia);
                            }
                        }
                    }
                }

                SCfScrev.SCfScrevDMR com = new SCfScrev.SCfScrevDMR();
                string usuario = ConfigurationManager.AppSettings["usuario"];
                string password = ConfigurationManager.AppSettings["password"];
                string alias = ConfigurationManager.AppSettings["alias"];
                //SCfCodeu.SCfCodeuDMR comCodeudor = new SCfCodeu.SCfCodeuDMR();
                //comCodeudor.emp_codi = credito.emp_codi;
                //comCodeudor.InsertCfCodeu(;
                com.loginAlias(usuario, password, alias);
                credito.aud_usua = ConfigurationManager.AppSettings["usuario"] == null ? "Seven" : ConfigurationManager.AppSettings["usuario"];
                credito.aud_ufac = DateTime.Now;
                credito.aud_esta = "A";
                credito.dcl_codd = 1;
                credito.scr_anop = DateTime.Now.Year;
                credito.scr_mesp = DateTime.Now.Month;
                credito.scr_diap = DateTime.Now.Day;
                credito.scr_fech = DateTime.Now;
                credito.scr_nech = int.Parse(DateTime.Now.ToString("ddMMyyyy"));
                credito.scr_fevi = DateTime.Now;
                credito.scr_esta = "S";
                credito.dcl_codd = 1;
               
                com.scr_gerj = "M";
                com.scr_cara = "P";
                com.scr_gefc = "M";
                com.dcl_dire = credito.scr_dire;
                com.dcl_ntel = credito.scr_tele;
                com.dcl_nfax = credito.dcl_nfax;
                com.dcl_mail = credito.dcl_mail;


                string arb_csuc = new DAO_Gn_Arbol().GetGnArbol(credito.emp_codi, credito.arb_sucu).arb_codi;
              var x =  com.InsertarCfScrev(credito.emp_codi, credito.top_codi, 0, credito.scr_fech.ToString("dd-MM-yyyy"), arb_csuc,
                    new DAO_Fa_Clien().GetCliCoda(credito.emp_codi, credito.cli_codi), credito.dcl_codd,new DAO_Ca_Licre().GetCaLicre(credito.emp_codi,credito.lic_cont).lic_codi, 0, 0, credito.scr_ncuo, credito.scr_fech.ToString("dd-MM-yyyy"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, credito.scr_vsol, ".","0", "",
                    credito.scr_fpcu.ToString("dd-MM-yyyy"), "N", credito.scr_gene, DateTime.Now.ToString("dd-MM-yyyy"),credito.scr_trab, 0, 0, 0, "E", DateTime.Now.ToString("dd-MM-yyyy"), credito.scr_nent, credito.scr_diem, credito.scr_teem, "", credito.pai_codu, credito.dep_codu, credito.mun_codu, credito.scr_sala, "", "", 0, 0, 0, 0, "0", "", "",
                    0, 0, "", "", 0, "", credito.scr_care,"", "", "", "","","", DateTime.Now.ToString("dd-MM-yyyy"), "",credito.codeudores.FirstOrDefault().cod_dnum,"","","", DateTime.Now.ToString("dd-MM-yyyy"), "","");


                if (x != 0)
                    throw new Exception(com.TxtError);






                //var result = new DAO_Cf_Screv().SetCfScrev(credito);
                return new TOTransaction() { Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction() { Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}