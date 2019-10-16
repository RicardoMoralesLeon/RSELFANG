using DigitalWare.Apps.Utilities.Gn.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DigitalWare.Apps.Utilities.Gn.DAO;

namespace RSELFANG.BO
{
    public class BOGnEmpre
    {
        public TO.TOTransaction<List<Gn_Empre>> GetGnEmpre(string usu_codi)
        {
            List<Gn_Empre> alowedCompanies = new List<Gn_Empre>();
            try
            {
                alowedCompanies = new DAO_Gn_Empre().GetGnEmpre(usu_codi);
                if (alowedCompanies == null)
                    throw new Exception("No se encontraron empresas");
                return new TO.TOTransaction<List<Gn_Empre>>() { objTransaction = alowedCompanies, retorno = 0 };

            }
            catch (Exception ex)
            {
                return new TO.TOTransaction<List<Gn_Empre>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
               
            }
        }
    }
}