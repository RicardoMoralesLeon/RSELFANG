using RSELFANG.TO;
using RSELFANG.DAO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BoSuconsu
    {
        public TOTransaction<tofiliatrab> getInfoAfilitrab(int emp_codi, string afi_docu)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {
                tofiliatrab result = new tofiliatrab();
                result = daosuconsu.getInfoAfilitrab(emp_codi, afi_docu);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    result.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", result.afi_nom1, " ", result.afi_nom2, " ", result.afi_ape1, " ", result.afi_ape2);
                    result.afi_fecn = string.IsNullOrEmpty(result.afi_fecn) ? "" : Convert.ToDateTime(result.afi_fecn).ToString("dd/MM/yyyy");

                    result.sutraye = daosuconsu.getInfoSutrayeTrab(emp_codi, result.afi_cont);

                    foreach (toSutraye traye in result.sutraye)
                    {
                        traye.tra_fchi = string.IsNullOrEmpty(traye.tra_fchi) ? "" : Convert.ToDateTime(traye.tra_fchi).ToString("dd/MM/yyyy");
                        traye.tra_fcha = string.IsNullOrEmpty(traye.tra_fcha) ? "" : Convert.ToDateTime(traye.tra_fcha).ToString("dd/MM/yyyy");
                    }

                    result.superca = daosuconsu.getInfoSupercaTrab(emp_codi, result.afi_cont);

                    foreach (toSuperca perca in result.superca)
                    {
                        perca.afi_noco = string.Format("{0}{1}{2}{3}{4}{5}{6}", perca.afi_nom1, " ", perca.afi_nom2, " ", perca.afi_ape1, " ", perca.afi_ape2);
                        perca.afi_fecn = string.IsNullOrEmpty(perca.afi_fecn) ? "" : Convert.ToDateTime(perca.afi_fecn).ToString("dd/MM/yyyy");
                        perca.rad_fech = string.IsNullOrEmpty(perca.rad_fech) ? "" : Convert.ToDateTime(perca.rad_fech).ToString("dd/MM/yyyy");
                    }
                }

                return new TOTransaction<tofiliatrab>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<tofiliatrab>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<toRnRadic>> getInfoAfilNovedad(int emp_codi, int afi_cont, DateTime rad_feci, DateTime rad_fecf)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {               
                var result = daosuconsu.getInfoAfilNovedad(emp_codi, afi_cont, rad_feci, rad_fecf);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (toRnRadic radic in result)
                    {
                        radic.rad_fech = string.IsNullOrEmpty(radic.rad_fech) ? "" : Convert.ToDateTime(radic.rad_fech).ToString("dd/MM/yyyy");
                        radic.rad_fecc = string.IsNullOrEmpty(radic.rad_fecc) ? "" : Convert.ToDateTime(radic.rad_fecc).ToString("dd/MM/yyyy");
                    }                   
                }

                return new TOTransaction<List<toRnRadic>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<toRnRadic>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<toArDpil>> getInfoAportes(int emp_codi, int afi_cont, int rpi_peri, int rpi_perf)
        {
            DAOSuConsu daosuconsu = new DAOSuConsu();

            try
            {
                var result = daosuconsu.getInfoAportes(emp_codi, afi_cont, rpi_peri, rpi_perf);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    foreach (toArDpil dpil in result)
                    {
                        dpil.rpi_fchp = string.IsNullOrEmpty(dpil.rpi_fchp) ? "" : Convert.ToDateTime(dpil.rpi_fchp).ToString("dd/MM/yyyy");                        
                    }
                }

                return new TOTransaction<List<toArDpil>>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<toArDpil>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}