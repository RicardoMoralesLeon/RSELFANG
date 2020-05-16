using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOEeMedsa
    {
        public TOTransaction<List<EeMedsa>> GetInfo(int ser_cont, DateTime fini, DateTime ffin)
        {
            DAOEeMedsa daoEeMedsa = new DAOEeMedsa();

            try
            {
                List<EeMedsa> result = new List<EeMedsa>();           
                result = daoEeMedsa.getInfoXServicio(ser_cont, fini, ffin);
                return new TOTransaction<List<EeMedsa>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeMedsa>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeSaSec>> GetInfoSatisfaccion()
        {
            DAOEeMedsa daoEeMedsa = new DAOEeMedsa();

            try
            {
                List<EeSaSec> result = new List<EeSaSec>();
                result = daoEeMedsa.getInfoSatisfaccion();
                return new TOTransaction<List<EeSaSec>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeSaSec>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeDeSec>> GetInfoDetalleSatisfaccion(int sec_cont)
        {
            DAOEeMedsa daoEeMedsa = new DAOEeMedsa();

            try
            {
                List<EeDeSec> result = new List<EeDeSec>();
                result = daoEeMedsa.getInfoDetalleSatis(sec_cont);
                return new TOTransaction<List<EeDeSec>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeDeSec>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeSaSer>> GetInfoOportunidad(int ser_cont)
        {
            DAOEeMedsa daoEeMedsa = new DAOEeMedsa();

            try
            {
                List<EeSaSer> result = new List<EeSaSer>();
                result = daoEeMedsa.getInfoOportunidad(ser_cont);
                return new TOTransaction<List<EeSaSer>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeSaSer>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}
