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
    public class BOFaInacl
    {
        public TOTransaction<Fa_Inacl> GetFaInacl(short emp_codi, string cli_coda)
        {
            try
            {
                var client = DAOFaClien.GetFaClien(emp_codi, cli_coda);
                var result = new DAO_Fa_Inacl().GetFaInacl(emp_codi, client.cli_codi);
                if (result == null)
                    throw new Exception("No se encontró información del cliente en programa SFAINACL.Contacte con su administrador.");
                return new TOTransaction<Fa_Inacl>() { Retorno = 0, TxtError = "", ObjTransaction = result };
            }
            catch (Exception)
            {
                return new TOTransaction<Fa_Inacl>() { ObjTransaction = null, TxtError = "", Retorno = 1 };
            }
        }
    }
}