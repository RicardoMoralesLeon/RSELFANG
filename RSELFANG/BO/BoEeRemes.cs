using RSELFANG.TO;
using System;
using System.Collections.Generic;
using RSELFANG.DAO;

namespace RSELFANG.BO
{
    public class BoEeRemes
    {
        
        public TOTransaction<Eeremes> GetInfoFaclien(int emp_codi, string cli_coda)
        {
            DAOEeRemes dao = new DAOEeRemes();

            try
            {
                Eeremes result = new Eeremes();
                result = dao.GetInfoFaclien(emp_codi, cli_coda);

                if (result == null)
                    throw new Exception("Documento no encontrado.");

                return new TOTransaction<Eeremes>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<Eeremes>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction setInfoRemes(EeReenc eereenc)
        {
            DAOEeRemes daoEeRemes = new DAOEeRemes();

            try
            {
                daoEeRemes.insertEeremes(eereenc);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction actualizarTratamiento(int emp_codi, string cli_coda)
        {
            DAOEeRemes daoEeRemes = new DAOEeRemes();

            try
            {
                daoEeRemes.updateTratamientoClient(emp_codi, cli_coda);
                daoEeRemes.updateTratamientoTerce(emp_codi, cli_coda);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}