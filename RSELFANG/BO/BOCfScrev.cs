using Digitalware.Apps.Utilities.Cf.Models;
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
            try
            {

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


                SCfScrev.SCfScrevDMR com = new SCfScrev.SCfScrevDMR();
                com.InsertarCfScrev(credito.emp_codI, credito.top_codi, 0, credito.scr_fech, "",)


                var result = new DAO_Cf_Screv().SetCfScrev(credito);
                return new TOTransaction() { Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction() { Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}