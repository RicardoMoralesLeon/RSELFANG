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
    public class BOSoCoxcn
       
    {
        string emp_codi = ConfigurationManager.AppSettings["emp_codi"];
        public BOSoCoxcn()
        {

        }
        public TOTransaction<List<TOSoCocxn>> getsocoxcn(string soc_codi,DateTime cox_fech)
        {
            DAOSoCoxcn dao = new DAOSoCoxcn();
            DAOSoDscfp daoD = new DAOSoDscfp();
            DAOSoConve daoConve = new DAOSoConve();
            List<TOSoCocxn> result = new List<TOSoCocxn>();
            try
            {
                if (string.IsNullOrEmpty(emp_codi))
                    throw new Exception("Código de empresa no parametrizado en api");
                var productosConvenios = dao.getsocoxcn(soc_codi,int.Parse( emp_codi), cox_fech);
                if (productosConvenios != null && productosConvenios.Any())
                {
                    //DateTime fini = new DateTime()
                    //result.AddRange(productosConvenios);
                    foreach (TOSoCocxn product in productosConvenios)
                    {
                        if (product.cox_mfin > 0)
                        {
                            int days = DateTime.DaysInMonth(product.cox_afin, product.cox_mfin);
                            DateTime fini = new DateTime(product.cox_aini, product.cox_mini, 1);
                            DateTime fina = new DateTime(product.cox_afin, product.cox_mfin, days);
                            if (fina >= cox_fech && fini <=cox_fech)
                                result.Add(product);
                        }
                        else
                        {
                            TOSoConve soconve = daoConve.getSoConve(product.con_cont, int.Parse(emp_codi));
                            if (soconve.con_fecv >= cox_fech)
                            {
                                product.cox_afin = soconve.con_fecv.Year;
                                product.cox_mfin = soconve.con_fecv.Month;
                                result.Add(product);
                            }
                               
                        }
                    }
                }
                   

                List<TOSoDscfp> productosFacturacion = new List<TOSoDscfp>();

                productosFacturacion = daoD.getsodscfp(soc_codi, int.Parse(emp_codi));
                if (productosFacturacion != null && productosFacturacion.Any())
                {
                    //elimina los registros sin periodo configurado
                    productosFacturacion = productosFacturacion.Where(p => p.dsc_peri.ToString().Length ==6 && p.dsc_perf.ToString().Length == 6).ToList();

                    if (productosFacturacion!=null && productosFacturacion.Any())
                    {
                        foreach(TOSoDscfp producto in productosFacturacion)
                        {
                            int daysI = DateTime.DaysInMonth(int.Parse(producto.dsc_peri.ToString().Substring(0, 4)), int.Parse(producto.dsc_peri.ToString().Substring(4, 2)));
                            int dasyF = DateTime.DaysInMonth(int.Parse(producto.dsc_perf.ToString().Substring(0, 4)), int.Parse(producto.dsc_perf.ToString().Substring(4, 2)));
                            DateTime per_inic = new DateTime(int.Parse(producto.dsc_peri.ToString().Substring(0, 4)), int.Parse(producto.dsc_peri.ToString().Substring(4, 2)), 1);
                            DateTime per_fini = new DateTime(int.Parse(producto.dsc_perf.ToString().Substring(0, 4)), int.Parse(producto.dsc_perf.ToString().Substring(4, 2)),dasyF);

                            if (per_inic<=cox_fech && per_fini >=cox_fech)
                                result.Add(new TOSoCocxn()
                                {
                                    cox_aini = per_inic.Year,
                                    cox_mini = per_inic.Month,
                                    cox_afin = per_fini.Year,
                                    cox_mfin = per_fini.Month,
                                    dco_plac = "",
                                    pro_codi = producto.pro_codi,
                                    pro_nomb = producto.pro_nomb,
                                    sbe_nomb = producto.sbe_nomb,
                                    pro_valo = producto.pro_valo,
                                    pro_fpag = producto.pro_fpag,

                                });
                                
                        }
                    }
                }
                if (result == null || !result.Any())
                    throw new Exception("No se encontraron productos vigentes.");
                return new TOTransaction<List<TOSoCocxn>>() { ObjTransaction = result, TxtError = "", Retorno = 0 };
            }
            catch(Exception ex)
            {
                return new TOTransaction<List<TOSoCocxn>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }
    }
}