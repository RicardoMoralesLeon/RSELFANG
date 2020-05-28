using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BoPqTrazabilidad
    {
        public TOTransaction<PqTrazab> GetInitialDataPq(int emp_codi)
        {
            BOGnItems boItems = new BOGnItems();
            BOGnArbol boArbol = new BOGnArbol();
            BOPqDpara boPerte = new BOPqDpara();
            BOGnDigfl boDigfl = new BOGnDigfl();
            
            try
            {
                PqTrazab result = new PqTrazab();

                List<GnArbol> seccional = boArbol.GetGbnArbol(2, emp_codi);
                List<GnItem> formRecib = boItems.GetGnItems(326);
                List<GnItem> tipoDePqr = boItems.GetGnItems(327);
                List<GnArbol> areaRespo = boArbol.GetGbnArbol(3, emp_codi);
                List<GnItem> tipificac = boItems.GetGnItems(330);
                List<GnItem> subtipifi = boItems.GetGnItems(331);
                List<TOGPerte> pqrGrpups = boPerte.GetPqDpara(emp_codi);
                GnFlag SPQ000003 = boDigfl.GetGnDigfl("SPQ000003");

                result.seccional = seccional;
                result.formRecib = formRecib;
                result.tipoDePqr = tipoDePqr;
                result.areaRespo = areaRespo;
                result.tipificac = tipificac;
                result.subtipifi = subtipifi;
                result.grupPerte = pqrGrpups;
                result.SPQ000003 = SPQ000003.dig_valo;

                return new TOTransaction<PqTrazab>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<PqTrazab>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<PqTrazabilidad>> GetInfoDataTraz(int emp_codi, DateTime fini, DateTime ffin, string filter)
        {
            DAOTrazabilidad dao = new DAOTrazabilidad();

            try
            {
                List<PqTrazabilidad> result = new List<PqTrazabilidad>();
                result = dao.getInfoPqTrazabilidad(emp_codi, fini, ffin, filter);
                return new TOTransaction<List<PqTrazabilidad>>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<PqTrazabilidad>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<PqTrazabilidadPqr> GetInfoDataPQR(int emp_codi, int inp_cont)
        {
            DAOTrazabilidad dao = new DAOTrazabilidad();
            DAOPqDinPq daoDinpq = new DAOPqDinPq();

            try
            {
                PqTrazabilidadPqr result = new PqTrazabilidadPqr();
                result = dao.getInfoTrazabilidadPqr(emp_codi, inp_cont);
                result.seguimientos = daoDinpq.getpqDinPq(inp_cont, emp_codi, false);
                return new TOTransaction<PqTrazabilidadPqr>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<PqTrazabilidadPqr>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}