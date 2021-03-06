﻿using RSELFANG.TO;
using System;
using System.Collections.Generic;
using RSELFANG.DAO;
using System.Configuration;

namespace RSELFANG.BO
{
    public class BoEeRemes
    {
        
        public TOTransaction<Eeremes> GetInfoFaclien(int emp_codi, string cli_coda)
        {
            DAOEeRemes dao = new DAOEeRemes();

            try
            {
                string redEnc = ConfigurationManager.AppSettings["redEnc"];

                if (string.IsNullOrEmpty(redEnc))
                    redEnc = "S";

                Eeremes result = new Eeremes();

                if (redEnc == "S")
                {
                    result = dao.GetInfoFaclien(emp_codi, cli_coda);
                }
                else
                {
                    result = dao.GetInfoTerce(emp_codi, cli_coda);

                    if (result == null)
                    {
                        result = dao.GetInfoRpauni(emp_codi, cli_coda);

                        if (result == null)
                        {
                            result = dao.GetInfoDetin(emp_codi, cli_coda);

                            if (result == null)
                            {
                                result = dao.GetInfoInvit(emp_codi, cli_coda);

                                if (result == null)
                                {
                                    result = dao.GetInfoLisev(emp_codi, cli_coda);

                                    if (result == null)
                                    {
                                        result = dao.GetInfoAsise(emp_codi, cli_coda);
                                    }
                                }
                            }
                        }
                    }
                }                               

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
                int emp_codi = int.Parse(ConfigurationManager.AppSettings["emp_codi"]);
                int rem_cont = daoEeRemes.insertEeremes(eereenc, emp_codi);

                if (rem_cont == -1)
                    throw new Exception("Se produjo un error, comuniquese con el administrador");

                return new TOTransaction() { retorno = 0, txtRetorno = rem_cont.ToString() };
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

        public TOTransaction GetInfoValidEnc(string cli_coda, int ite_serv, int emp_codi)
        {
            DAOEeRemes dao = new DAOEeRemes();

            try
            {
                string redEnc = ConfigurationManager.AppSettings["redEnc"];

                if (string.IsNullOrEmpty(redEnc))
                    redEnc = "S";

                int rem_cont=0;
                rem_cont = dao.GetInfoValidEnc(cli_coda, ite_serv, emp_codi, redEnc);

                if (rem_cont != 0)
                    throw new Exception("La encuesta ya fue realizada.");

                return new TOTransaction() { retorno = 0 ,txtRetorno = ""};
            }
            catch (Exception ex)
            {
                return new TOTransaction() {  retorno = 1 , txtRetorno = ex.Message };
            }
        }

        public TOTransaction GetInfoValidEncPqr(int inp_cont, int emp_codi)
        {
            DAOEeRemes dao = new DAOEeRemes();

            try
            {
                int rem_cont = 0;
               // rem_cont = dao.GetInfoValidEnc(cli_coda, ite_serv, emp_codi);

                if (rem_cont != 0)
                    throw new Exception("La encuesta ya fue realizada.");

                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<EeRemPa> GetInfoParam()
        {
            try
            {
                EeRemPa eerempa = new EeRemPa();

                string redEnc = ConfigurationManager.AppSettings["redEnc"];

                if (string.IsNullOrEmpty(redEnc))
                    redEnc = "S";

                string titEnc = ConfigurationManager.AppSettings["titRemes"];

                if (string.IsNullOrEmpty(titEnc))
                    titEnc = "";

                eerempa.red_encu = redEnc;
                eerempa.tit_reme = titEnc;

                return new TOTransaction<EeRemPa>() { objTransaction = eerempa, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<EeRemPa>() { objTransaction = null, retorno = 1, txtRetorno = ex.ToString() };
            }
        }
    }
}