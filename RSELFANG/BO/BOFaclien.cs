using Digitalware.Apps.Utilities.Fa.TO;
using RSELFANG.DAO;
using RSELFANG.TO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOFaclien
    {


        public SevenFramework.TO.TOTransaction<FaClien> GetFaclien(short emp_codi, string cli_coda)
        {
            try
            {
                var client = DAOFaClien.GetFaClien(emp_codi, cli_coda);
                if (client == null)
                    throw new Exception(string.Format("Cliente {0} no encontrado.", client));
                return new SevenFramework.TO.TOTransaction<FaClien>() { ObjTransaction = client, Retorno = 0, TxtError = "" };

            }
            catch (Exception ex)
            {
                return new SevenFramework.TO.TOTransaction<FaClien>() { ObjTransaction = null, TxtError = ex.Message };
            }
        }
    }
}