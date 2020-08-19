using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOSfConsu
    {
        public TOTransaction<Suafili> GetInfoDataSfConsu(int emp_codi, int tip_codi, string afi_docu)
        {
            DAOSfConsu daoCfConsu = new DAOSfConsu();

            try
            {
                Suafili result = new Suafili();
                result = daoCfConsu.getsfconsu(emp_codi, tip_codi, afi_docu);

                if (result == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");
                else
                {
                    result.afi_nom1 = string.Format("{0}{1}{2}", result.afi_nom1, " ", result.afi_nom2);
                    result.afi_ape1 = string.Format("{0}{1}{2}", result.afi_ape1, " ", result.afi_ape2);
                    result.sfforpo = daoCfConsu.getsfforpo(emp_codi, result.afi_cont);

                    foreach (Sfforpo forpo in result.sfforpo)
                    {
                        forpo.for_fasi = string.IsNullOrEmpty(forpo.for_fasi) ? "" : Convert.ToDateTime(forpo.for_fasi).ToString("dd/MM/yyyy");
                        forpo.for_fech = string.IsNullOrEmpty(forpo.for_fech) ? "" : Convert.ToDateTime(forpo.for_fech).ToString("dd/MM/yyyy");
                    }
                }

                return new TOTransaction<Suafili>() { objTransaction = result, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<Suafili>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}