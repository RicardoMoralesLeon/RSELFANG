using RSELFANG.DAO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace RSELFANG.BO
{
    public class BOEcCotiz
    {

        DAOSeCcotiz daoCotiz = new DAOSeCcotiz();
        DAOSoSbene daoBene = new DAOSoSbene();
        DAOEcDespa daoDespa = new DAOEcDespa();
        DAOAeClase daoClase = new DAOAeClase();
        DAOEcDphij daoPhij = new DAOEcDphij();
        DAOEcDetan daoDetan = new DAOEcDetan();
        DAOLiqCons daoLiq = new DAOLiqCons();
        DAOEcLisev daoLisev = new DAOEcLisev();
        string emp_codi;
        public BOEcCotiz()
        {
            emp_codi = ConfigurationManager.AppSettings["emp_codi"];
        }

        public TOTransaction<List<TOEcCotiz>> GetEcCotiz(string ter_coda, string usu_codi, int fec_fini, int fec_fina)
        {
            try
            {
                if (string.IsNullOrEmpty(emp_codi))
                    throw new Exception("Código de empresa no definido en api");
                TOSoSbene beneficiario = new TOSoSbene();
                beneficiario = daoBene.GetSoSbene(int.Parse(emp_codi), ter_coda);
                if (beneficiario == null)
                    throw new Exception(string.Format("No se encontró beneficiario asociado al usuario {0}", usu_codi));
                List<TOEcCotiz> cotizaciones = new List<TOEcCotiz>();
                cotizaciones = daoCotiz.GetSeCcotiz(int.Parse(emp_codi), ter_coda, beneficiario.sbe_cont, fec_fini, fec_fina);
                if (cotizaciones == null || cotizaciones.Count == 0)
                    throw new Exception("No se encontraron cotizaciones");

                foreach (TOEcCotiz cotizacion in cotizaciones)
                {
                    cotizacion.detalle = daoDespa.GetEcDespa(int.Parse(emp_codi), cotizacion.cot_cont);
                    if (cotizacion.detalle != null && cotizacion.detalle.Count > 0)
                    {
                        foreach (TOEcDespa detalle in cotizacion.detalle)
                        {
                            TOAeClase clase = new TOAeClase();
                            clase = daoClase.GetAeClase(int.Parse(emp_codi), detalle.cla_codi);
                            detalle.clase = clase;
                            var productos = daoPhij.GetEcDphij(int.Parse(emp_codi), cotizacion.cot_cont, detalle.des_cont);
                            detalle.productos = productos;
                        };
                        cotizacion.anticipos = daoDetan.GetEcDetan(int.Parse(emp_codi), cotizacion.cot_cont);
                        cotizacion.liquidacion = daoLiq.GetLiqCons(int.Parse(emp_codi), cotizacion.cot_cont);
                        cotizacion.invitados = daoLisev.GetEcLisev(int.Parse(emp_codi), cotizacion.eve_cont);
                    }
                };

                return new TOTransaction<List<TOEcCotiz>>() { ObjTransaction = cotizaciones, TxtError = "", Retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<TOEcCotiz>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}