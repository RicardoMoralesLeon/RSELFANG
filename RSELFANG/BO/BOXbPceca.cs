using DigitalWare.Apps.Utilities.Xb.DAO;
using DigitalWare.Apps.Utilities.Xb.TO;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOXbPceca
    {

       public TOTransaction<Xb_Pceca> GetXbPeca(short emp_codi)
        {
            try
            {
                var result = new DAO_Xb_Pceca().GetXbPeca(emp_codi);
                if (result == null)
                    throw new Exception("No se encontraron parámetros de cartera");
                return new TOTransaction<Xb_Pceca>() { ObjTransaction = result, Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<Xb_Pceca>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }

        }
    }
}