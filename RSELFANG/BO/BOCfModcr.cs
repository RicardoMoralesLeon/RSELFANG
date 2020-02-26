using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SevenFramework.Interfaces;
using Digitalware.Apps.Utilities.Cf.Models;
using Digitalware.Apps.Utilities.Cf.DAO;
using SevenFramework.TO;
using SevenFramework;
using System.Text;

namespace RSELFANG.BO
{
    public class BOCfModcr 
    {
        public TOTransaction Delete()
        {
            throw new NotImplementedException();
        }

        public TOTransaction<Cf_Modcr> Get()
        {
            throw new NotImplementedException();
        }

        public TOTransaction<List<Cf_Modcr>> GetList(int emp_codi)
        {
            try
            {
                var resullt = new DAO_Cf_Modcr().GetCfModcr(emp_codi);
                return new TOTransaction<List<Cf_Modcr>>() { ObjTransaction = resullt, Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<Cf_Modcr>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }

        public TOTransaction Update()
        {
            throw new NotImplementedException();
        }
    }
}