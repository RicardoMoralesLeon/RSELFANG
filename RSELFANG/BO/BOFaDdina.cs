using Digitalware.Apps.Utilities.Fa.DAO;
using Digitalware.Apps.Utilities.Fa.TO;
using RSELFANG.DAO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOFaDdina
    {
        public TOTransaction<List<Fa_Dina>> GetFaDdina(short emp_codi,string cli_coda)
        {
            try
            {
                var clien = DAOFaClien.GetFaClien(emp_codi, cli_coda);
                var ddina = new DAO_Fa_Dina().ConsultarFaDdina(emp_codi, clien.cli_codi);
                if (ddina == null)
                    throw new Exception(string.Format("No se encontró información adicional para el cliente {0}",cli_coda));
                return new TOTransaction<List<Fa_Dina>>() { ObjTransaction = ddina, Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Fa_Dina>>() { ObjTransaction = null, TxtError = ex.Message, Retorno = 1 };
            }
        }


        public TOTransaction<List<Fa_Dina>> GetFaDina(short emp_codi, string cli_coda)
        {
            try
            {
                var clien = DAOFaClien.GetFaClien(emp_codi, cli_coda);
                var ddina = new DAO_Fa_Dina().GetFaDdina(emp_codi, clien.cli_codi);
                if (ddina == null)
                    throw new Exception(string.Format("No se encontró información adicional para el cliente {0}", cli_coda));
                return new TOTransaction<List<Fa_Dina>>() { ObjTransaction = ddina, Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Fa_Dina>>() { ObjTransaction = null, TxtError = ex.Message, Retorno = 1 };
            }
        }
    }
}