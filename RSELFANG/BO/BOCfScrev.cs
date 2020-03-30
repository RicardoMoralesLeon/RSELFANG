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
                                              
              var x =  com.InsertarCfScrev(credito.emp_codi, credito.top_codi, 0, credito.scr_fech.ToString(), "",
                    new DAO_Fa_Clien().GetCliCoda(credito.emp_codi, credito.cli_codi), 1,new DAO_Ca_Licre().GetCaLicre(credito.emp_codi,credito.lic_cont).lic_codi, 0, 0, credito.scr_ncuo, credito.scr_fech.ToString(), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, credito.scr_vsol, ".","0", "",
                    credito.scr_fpcu.ToString(), "", credito.scr_gene, null, "", 0, 0, 0, "", null, credito.scr_nent, credito.scr_diem, credito.scr_teem, "", credito.pai_codu, credito.dep_codu, credito.mun_codu, 0, "", "", 0, 0, 0, 0, "0", "", "",
                    0, 0, "", "", 0, "", credito.scr_care, "", "", "", "","","",null,"",credito.codeudores.FirstOrDefault().cod_dnum,"","","","","","");


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