using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BOEeConsu
    {
        public TOTransaction<List<FaClien>> GetInfoClientes(int emp_codi)
        {
            DAOEeConsu daoeeconsu = new DAOEeConsu();
            List<FaClien> lstFaClien = new List<FaClien>();

            try
            {
                lstFaClien = daoeeconsu.GetFaClien(emp_codi);
                return new TOTransaction<List<FaClien>>() { objTransaction = lstFaClien, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<FaClien>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeConsu>> GetInfoEereles(int emp_codi, DateTime fini, DateTime ffin, int ite_cont, string cli_coda)
        {
            DAOEeConsu daoeeconsu = new DAOEeConsu();
            List<EeConsu> eeconsu = new List<EeConsu>();

            try
            {
                eeconsu = daoeeconsu.GetInfoEereles(emp_codi, fini, ffin, ite_cont, cli_coda);
                return new TOTransaction<List<EeConsu>>() { objTransaction = eeconsu, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeConsu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}