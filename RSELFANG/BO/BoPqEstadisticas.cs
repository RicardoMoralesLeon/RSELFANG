using RSELFANG.DAO;
using RSELFANG.Models;
using RSELFANG.TO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BoPqEstadisticas
    {
        public TOTransaction<Pqestad> GetInitialDataPqEstad(int emp_codi)
        {          
            BOGnItems boItems = new BOGnItems();          
            BOGnArbol boArbol = new BOGnArbol();
            BOPqDpara boPerte = new BOPqDpara();

            try
            {
                Pqestad result = new Pqestad();

                List<GnArbol> seccional = boArbol.GetGbnArbol(2, emp_codi);
                List<GnItem> formRecib = boItems.GetGnItems(326);                                
                List<GnItem> tipoDePqr = boItems.GetGnItems(327);
                List<GnArbol> areaRespo = boArbol.GetGbnArbol(3, emp_codi);
                List<GnItem> tipificac = boItems.GetGnItems(330);
                List<GnItem> subtipifi = boItems.GetGnItems(331);
                List<TOGPerte> pqrGrpups = boPerte.GetPqDpara(emp_codi);

                result.seccional = seccional;
                result.formRecib = formRecib;
                result.tipoDePqr = tipoDePqr;
                result.areaRespo = areaRespo;
                result.tipificac = tipificac;
                result.subtipifi = subtipifi;
                result.grupPerte = pqrGrpups;

                return new TOTransaction<Pqestad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<Pqestad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<InfoPqEstad>> GetInfoPqEstadisticas(int emp_codi, DateTime fini, DateTime ffin, string type, string filter)
        {
            DAOPqEstadisticas daoPqEstad = new DAOPqEstadisticas();

            try
            {
                List<InfoPqEstad> result = new List<InfoPqEstad>();

                if (type == "seccional")
                {
                    result = daoPqEstad.getInfoXSeccional(emp_codi, fini, ffin, filter);
                }
                else if (type == "formRecib")
                {
                    result = daoPqEstad.getInfoXFormRecib(emp_codi, fini, ffin, filter);
                }
                else if (type == "areaRespo")
                {
                    result = daoPqEstad.getInfoXAreaResp(emp_codi, fini, ffin, filter);
                }
                else if (type == "tipodePqr")
                {
                    result = daoPqEstad.getInfoXTipodePqr(emp_codi, fini, ffin, filter);
                }
                else if (type == "tipificac")
                {
                    result = daoPqEstad.getInfoXTipificac(emp_codi, fini, ffin, filter);
                }
                else if (type == "subtipifi")
                {
                    result = daoPqEstad.getInfoXSubTipifi(emp_codi, fini, ffin, filter);
                }
                else if (type == "grupoPert")
                {
                    result = daoPqEstad.getInfoXGruPerten(emp_codi, fini, ffin, filter);
                }

                return new TOTransaction<List<InfoPqEstad>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<InfoPqEstad>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}