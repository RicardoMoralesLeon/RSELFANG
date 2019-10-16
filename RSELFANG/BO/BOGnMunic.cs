using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOGnMunic
    {
        public List<GnMunic> GetAllGnMunic(int pai_codi)
        {
           
                DAOGnMunic dao = new DAOGnMunic();
                List<GnMunic> result = new List<GnMunic>();
                result = dao.GetGnMunic(pai_codi);
                if (result == null || !result.Any())
                    throw new Exception("No se encontraron municipios parametrizados en seven -erp");
            return result;
          
        }

        public List<GnMunic> GetGnMunic(int pai_codi, int reg_codi, int dep_codi)
        {

            DAOGnMunic dao = new DAOGnMunic();
            List<GnMunic> result = new List<GnMunic>();
            result = dao.GetGnMunic(pai_codi, reg_codi, dep_codi);
            if (result == null || !result.Any())
                throw new Exception("No se encontraron municipios parametrizados en seven -erp");
            return result;

        }
    }
}