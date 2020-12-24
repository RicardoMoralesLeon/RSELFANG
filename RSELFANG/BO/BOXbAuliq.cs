using Digitalware.Apps.Utilities.Fa.DAO;
using Digitalware.Apps.Utilities.In.DAO;
using DigitalWare.Apps.Utilities.Gn.DAO;
using DigitalWare.Apps.Utilities.Xb.BO;
using DigitalWare.Apps.Utilities.Xb.DAO;
using DigitalWare.Apps.Utilities.Xb.TO;
using Ophelia.Seven;
using Ophelia.Seven.Reportes;
using RSELFANG.DAO;
using RSELFANG.Models;
using SevenFramework.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;

namespace RSELFANG.BO
{
    public class BOXbAuliq
    {



        public TOTransaction<List<TOXbAuliq>> GetAutLiq(short emp_codi, string cli_coda, DateTime par_fech, int ite_ctse)
        {
            try
            {
                DAOCaCxcob dAOCaCxcob = new DAOCaCxcob();
                //obtengo cliente
                var cliente = DAOFaClien.GetFaClien(emp_codi, cli_coda);
                //consulto todos los históricos RIFINC, REGADS, XBRL
                var historicos = new DAO_Xb_Exbrl().GetHistoricoInformacion(emp_codi, cliente.cli_codi);
                //consulto parámetos de cartera
                var ParametrosCartera = new DAO_Xb_Pceca().GetXbPeca(emp_codi);
                List<TOXbAuliq> liquidacionLista = new List<TOXbAuliq>();
                //Consulto todas las cuentas por cobrar del cliente asociadas a los tipos de operacion (contribución, intereses, o multas y sanciones
                var cuentasExistentes = dAOCaCxcob.GetAuliquidacion(emp_codi, cliente.cli_codi);
                //Obtengo el grupo de información financiera al que pertenece el cliente
                var GrupoInformacionFinanciera = new DAO_Fa_Inacl().GetFaInacl(emp_codi, cliente.cli_codi);
                var xbpceca = new DAO_Xb_Pceca().GetXbPeca(emp_codi);

                if (cuentasExistentes != null && cuentasExistentes.Any())
                {
                    if (cuentasExistentes != null && cuentasExistentes.Any())
                    {
                        foreach (TOXbAuliq autliq in cuentasExistentes.FindAll(p => p.ite_ctse == ite_ctse))
                        {
                            //var listFadina = new DAO_Fa_Dina().GetFaDdina(emp_codi, cliente.cli_codi, autliq.dcl_codd);
                            //if (listFadina == null)
                            //    throw new Exception(string.Format("No se encontró tipo de servicio para el detalle de cliente {0}", autliq.dcl_codd));
                            //  var fadina = listFadina.FirstOrDefault();
                            try
                            {
                                //Cálculos para multas y sanciones
                                if (autliq.top_codi == ParametrosCartera.top_core)
                                {
                                    DateTime fechaVencimiento;
                                    var CxcInteresesPendientes = new DAOCaCpcob().GetCaCpCobConAbonos(emp_codi, autliq.cxc_cont);
                                    // TODO:Calcular los intereses en base a la fecha máxima de pago. Si ya hay cxc de intereses con abonos parciales la fecha inicial para calculo de intereses debe ser la ultima fecha de pago de esas cxc con intereses, campo CXC_FUPA
                                    //TODO// cA 


                                    if (CxcInteresesPendientes != null && CxcInteresesPendientes.Any())
                                    {
                                        autliq.cxc_inan = CxcInteresesPendientes.Sum(c => c.cxc_sald);
                                        fechaVencimiento = CxcInteresesPendientes.FirstOrDefault().cxc_fupa;
                                    }
                                    else
                                        fechaVencimiento = autliq.cxc_feve.Date;

                                    DateTime fechaPago = par_fech;
                                    int numDias = (fechaPago - fechaVencimiento).Days;
                                    if (numDias < 0)
                                        throw new Exception(string.Format("Se encontró autoliquidación para el {0}, verifique.", fechaVencimiento.ToString("dd/MM/yyyy")));
                                    int diasGracia = ParametrosCartera.pce_digr;
                                    int cantidadDiasNoLaborales = new DAOGnDiasn().CantidadDiasNoLaborales(autliq.cxc_feve, diasGracia);
                                    decimal saldoCapital = autliq.cxc_sald;
                                    decimal interes = ParametrosCartera.pce_intm / 360;

                                    if (DateTime.Now.Year == autliq.rcx_vige)
                                        if (fechaPago <= fechaVencimiento.AddDays(diasGracia + cantidadDiasNoLaborales))
                                            interes = 0;

                                    autliq.cxc_inmo = interes * numDias * saldoCapital / 100;

                                    autliq.dpa_tari = xbpceca.pce_intm;
                                    autliq.par_fech = par_fech;


                                    //if (autliq.cxc_inmo > 0)
                                    //{
                                    //    autliq.liq_apro = true;
                                    //    break;
                                    //}
                                }

                                else
                                {

                                    var ParametrosContribucion = new DAO_Xb_Dparc().GetXbParcoAnoPagar(emp_codi, GrupoInformacionFinanciera.Ite_Ctgo, autliq.rcx_vige);
                                    if (ParametrosContribucion == null)
                                        throw new Exception(string.Format("No se encontró parámetros de contribución para el año {0}", autliq.rcx_vige));
                                    var DetalleParametrosContribucion = new DAO_Xb_Dparc().GetXbDparc(emp_codi, ParametrosContribucion.par_anop, GrupoInformacionFinanciera.Ite_Ctgo, ite_ctse);
                                    if (DetalleParametrosContribucion == null)
                                        throw new Exception(string.Format("No se encontró parámetros de contribución para el año {0} y {1}", autliq.rcx_vige, ite_ctse));
                                    if (DetalleParametrosContribucion.Where(c => c.ite_ctts == autliq.ite_ctse).FirstOrDefault() == null)
                                        throw new Exception(String.Format("No se encontró detalle de parámetros de contribución para el año {0} y servicio {1}", autliq.rcx_vige, autliq.cts_nomb));
                                    autliq.dpa_tari = DetalleParametrosContribucion.Where(c => c.ite_ctts == autliq.ite_ctse).FirstOrDefault().dpa_tari;
                                    if (ParametrosContribucion != null && ParametrosContribucion.par_fec1 < DateTime.Now.Date && ParametrosContribucion.par_fec2 != null)
                                        autliq.par_fech = ParametrosContribucion.par_fec2.Value;
                                    else
                                        autliq.par_fech = ParametrosContribucion.par_fec1;

                                    if (autliq.rcx_vige > 2016)
                                    {
                                        string BaseGravType = string.Empty;
                                        if (DetalleParametrosContribucion.FirstOrDefault().par_rega.ToUpper() == "S")
                                            BaseGravType = "REGADS";
                                        if (DetalleParametrosContribucion.FirstOrDefault().par_rifi.ToUpper() == "S")
                                            BaseGravType = "RIFINC";
                                        if (string.IsNullOrEmpty(BaseGravType))
                                            BaseGravType = "FORM";

                                        switch (BaseGravType)
                                        {
                                            case "REGADS":
                                                int regCont = new DAO_Xb_Regad().getRegCont(emp_codi, (int)ParametrosContribucion.par_anop, decimal.Parse(cliente.cli_codi.ToString()), (int)ParametrosContribucion.par_anop);
                                                if (regCont == 0)
                                                    throw new Exception(string.Format("No se encontró informe regads cargado para el cliente {0} y año {1}", cliente.cli_coda, (int)ParametrosContribucion.par_anop));
                                                autliq.cxc_bgrav = new DAO_Xb_Dgape().getTotalReportado(emp_codi, regCont);
                                                //TODO:Se valida la fecha de vencimiento de la cxc que se va a generar

                                                //Tomar base de SXBREGAD
                                                break;
                                            case "RIFINC":
                                                int rinCont = new DAO_Xb_Rinif().GetRintCont(emp_codi, cliente.cli_coda, "A", (int)ParametrosContribucion.par_anop);
                                                if (rinCont == 0)
                                                    throw new Exception(string.Format("No se encontró informe rifinc cargado para el cliente {0} y año {1}", cliente.cli_coda, (int)ParametrosContribucion.par_anop));
                                                autliq.cxc_bgrav = new DAO_Xb_Rinif().getTotalReportado(emp_codi, rinCont);
                                                // Tomar base de SXBRIFINC
                                                break;
                                            case "FORM":
                                                var exbrl = new DAO_Xb_Exbrl().ConsultarXbEXbrlPorEstado(emp_codi, long.Parse(cliente.cli_codi.ToString()), (int)ParametrosContribucion.par_anop, new string[] { "A" });
                                                if (exbrl == null)
                                                    throw new Exception(string.Format("No se encontró un formulario XBRL aprobado para cliente {0} y año {1}", cliente.cli_coda, (int)ParametrosContribucion.par_anop));
                                                if (string.IsNullOrEmpty(DetalleParametrosContribucion.FirstOrDefault().dde_codi))
                                                    throw new Exception("El grupo de información financiera no tiene detalles asociados en parámetros de contribución");

                                                var xbConce = new DAO_Xb_Conce().ConsultarXbConce(emp_codi, exbrl.hxb_cont, DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi);
                                                if (xbConce == null)
                                                    throw new Exception(String.Format("No se encontró el concepto {0} en el formulario XBRL {1}", DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi));

                                                var xbDConc = new DAO_Xb_Dconc().ConsultarXbDConce(exbrl.hxb_cont, emp_codi, DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi, (int)ParametrosContribucion.par_anop);
                                                if (xbConce[0].con_valo == "" || xbConce[0].con_valo == null)
                                                {



                                                    if (xbDConc == null)
                                                        throw new Exception(String.Format("No se encontró el concepto {0} en el formulario XBRL {1}", DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi));

                                                    if (xbDConc[0].dco_valo == "" || xbDConc[0].dco_valo == null)
                                                    {
                                                        autliq.cxc_bgrav = 0;
                                                    }
                                                    else
                                                    {

                                                        if (xbDConc[0].dco_valo.Contains(","))
                                                            throw new Exception(String.Format("El valor no puede contener el simbolo (,)"));

                                                        xbDConc[0].dco_valo = xbDConc[0].dco_valo.Replace(".", "");
                                                        autliq.cxc_bgrav = decimal.Parse(xbDConc[0].dco_valo);

                                                    }

                                                }
                                                else
                                                {

                                                    autliq.cxc_bgrav = decimal.Parse(xbConce[0].con_valo);

                                                }

                                                break;
                                        }
                                    }
                                    //TODO:Si es una cxc de contribución, preguntar si tiene cxc de interes asociadas con abonos
                                    if (autliq.top_codi == ParametrosCartera.top_coco)
                                    {
                                        //TODO: Si tiene ninguna cxc con abonos, entonces contar los intereses desde la fecha en que pagó la última cxc de intereses
                                        var CxcInteresesPendientes = new DAOCaCpcob().GetCaCpCobConAbonos(emp_codi, autliq.cxc_cont);
                                        // TODO:Calcular los intereses en base a la fecha máxima de pago. Si ya hay cxc de intereses con abonos parciales la fecha inicial para calculo de intereses debe ser la ultima fecha de pago de esas cxc con intereses, campo CXC_FUPA
                                        //TODO// cA 
                                        if (CxcInteresesPendientes != null && CxcInteresesPendientes.Any())
                                        {
                                            if (CxcInteresesPendientes.FirstOrDefault().cxc_fupa > autliq.par_fech)
                                                autliq.par_fech = autliq.cxc_fupa;
                                            autliq.cxc_inan = CxcInteresesPendientes.Sum(c => c.cxc_sald);
                                        }


                                        if (autliq.cxc_sald < autliq.cxc_tota)
                                        {
                                            autliq.par_fech = autliq.cxc_fupa;
                                        }

                                        //Suma los saldos de todas las cuentas por cobrar con intereses

                                        //int DiasTotalesLiquidar = (par_fech - autliq.par_fech).Days;
                                        if (par_fech > autliq.par_fech)
                                        {
                                            autliq.cxc_inmo = new BO_Autliq().CalcularIntereses(autliq.par_fech, par_fech, autliq.cxc_sald, emp_codi);
                                            autliq.par_fech = par_fech;
                                        }

                                    }
                                }

                            }
                            catch (Exception ex)
                            {
                                autliq.error = ex.Message;
                                autliq.liq_lock = true;

                            }
                            finally
                            {
                                if (autliq.cxc_sald > 0)
                                    liquidacionLista.Add(autliq);
                            }

                        };
                    }
                }
                //TODO: Crear las cxc calculadas
                if (historicos != null && historicos.Any())
                {
                    foreach (Xb_Exbrl historico in historicos)
                    {
                        TOXbAuliq tOXbAuliqCxcContribucion = new TOXbAuliq();
                        try
                        {
                            //var fadina = new DAO_Fa_Dina().ConsultarFaDdina(emp_codi, cliente.cli_codi).FirstOrDefault();

                            var itemService = DAO_Gn_Items.GetGnItems(ite_ctse, 0, "").FirstOrDefault();
                            tOXbAuliqCxcContribucion.ite_ctse = itemService.ite_cont;
                            tOXbAuliqCxcContribucion.cts_nomb = itemService.ite_nomb;
                            tOXbAuliqCxcContribucion.top_codi = xbpceca.top_coco;
                            tOXbAuliqCxcContribucion.top_nomb = DAOGnToper.GetGnToper(emp_codi, xbpceca.top_coco).top_nomb;




                            tOXbAuliqCxcContribucion.emp_codi = emp_codi;
                            var ParametrosContribucion = new DAO_Xb_Dparc().GetXbParco(emp_codi, GrupoInformacionFinanciera.Ite_Ctgo, (int)historico.exb_anop);
                            var DetalleParametrosContribucion = new DAO_Xb_Dparc().GetXbDparc(emp_codi, (int)historico.exb_anop, GrupoInformacionFinanciera.Ite_Ctgo, ite_ctse);
                            if (DetalleParametrosContribucion == null)
                                throw new Exception(string.Format("No se encontraron parametros de contribución para el año {0} y grupo de información financiera {1}", historico.exb_anop, GrupoInformacionFinanciera.ite_nomb));
                            tOXbAuliqCxcContribucion.rcx_vige = ParametrosContribucion.par_anof;
                            if (cuentasExistentes != null && cuentasExistentes.Find(p => p.rcx_vige == ParametrosContribucion.par_anof && p.top_codi == xbpceca.top_coco) != null)
                                throw new Exception(string.Format("Ya existe cuenta por cobrar para año {0}", ParametrosContribucion.par_anof));
                            //verifico que tampoco tenga cuentas al día 
                            var cuentasAldia = dAOCaCxcob.GetAuliquidacion(emp_codi, cliente.cli_codi, false);
                            if (cuentasAldia != null)
                            {
                                if (cuentasAldia.Find(c => c.rcx_vige == ParametrosContribucion.par_anof) != null)
                                    throw new Exception(string.Format("Ya existe cuenta al día para año {0}", ParametrosContribucion.par_anof));
                            }

                            string BaseGravType = string.Empty;
                            if (DetalleParametrosContribucion.FirstOrDefault().par_rega.ToUpper() == "S")
                                BaseGravType = "REGADS";
                            if (DetalleParametrosContribucion.FirstOrDefault().par_rifi.ToUpper() == "S")
                                BaseGravType = "RIFINC";
                            if (string.IsNullOrEmpty(BaseGravType))
                                BaseGravType = "FORM";
                            //Si no encuentra cxc de contribución para cada vigencia
                            if (cuentasExistentes == null || cuentasExistentes.Find(f => f.rcx_vige == ParametrosContribucion.par_anof && f.top_codi == ParametrosCartera.top_como) == null)
                            {
                                tOXbAuliqCxcContribucion.top_codi = int.Parse(ParametrosCartera.top_coco.ToString());
                                tOXbAuliqCxcContribucion.cxc_desc = string.Format("Contribución {0}", ParametrosContribucion.par_anof);
                                if (ParametrosContribucion != null && ParametrosContribucion.par_fec1 < DateTime.Now.Date && ParametrosContribucion.par_fec2 != null)
                                    tOXbAuliqCxcContribucion.par_fech = ParametrosContribucion.par_fec2.Value;
                                else
                                    tOXbAuliqCxcContribucion.par_fech = ParametrosContribucion.par_fec1;
                                switch (BaseGravType)
                                {
                                    case "REGADS":
                                        int regCont = new DAO_Xb_Regad().getRegCont(emp_codi, (int)historico.exb_anop, decimal.Parse(cliente.cli_codi.ToString()), (int)historico.exb_anop);
                                        if (regCont == 0)
                                            throw new Exception(string.Format("No se encontró informe regads cargado para el cliente {0} y año {1}", cliente.cli_coda, historico.exb_anop));
                                        tOXbAuliqCxcContribucion.cxc_sald = new DAO_Xb_Dgape().getTotalReportado(emp_codi, regCont);

                                        //TODO:Se valida la fecha de vencimiento de la cxc que se va a generar

                                        //Tomar base de SXBREGAD
                                        break;
                                    case "RIFINC":
                                        int rinCont = new DAO_Xb_Rinif().GetRintCont(emp_codi, cliente.cli_coda, "A", (int)historico.exb_anop);
                                        if (rinCont == 0)
                                            throw new Exception(string.Format("No se encontró informe rifinc cargado para el cliente {0} y año {1}", cliente.cli_coda, historico.exb_anop));
                                        tOXbAuliqCxcContribucion.cxc_sald = new DAO_Xb_Rinif().getTotalReportado(emp_codi, rinCont);
                                        // Tomar base de SXBRIFINC
                                        break;
                                    case "FORM":
                                        var exbrl = new DAO_Xb_Exbrl().ConsultarXbEXbrlPorEstado(emp_codi, long.Parse(cliente.cli_codi.ToString()), (int)historico.exb_anop, new string[] { "A" });
                                        if (exbrl == null)
                                            throw new Exception(string.Format("No se encontró un formulario XBRL aprobado para cliente {0} y año {1}", cliente.cli_coda, historico.exb_anop));
                                        if (string.IsNullOrEmpty(DetalleParametrosContribucion.FirstOrDefault().dde_codi))
                                            throw new Exception("El grupo de información financiera no tiene detalles asociados en parámetros de contribución");

                                        var xbConce = new DAO_Xb_Conce().ConsultarXbConce(emp_codi, exbrl.hxb_cont, DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi);
                                        if (xbConce == null)
                                            throw new Exception(String.Format("No se encontró el concepto {0} en el formulario XBRL {1}", DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi));

                                        var xbDConc = new DAO_Xb_Dconc().ConsultarXbDConce(exbrl.hxb_cont, emp_codi, DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi, (int)historico.exb_anop);
                                        if (xbConce[0].con_valo == "" || xbConce[0].con_valo == null)
                                        {



                                            if (xbDConc == null)
                                                throw new Exception(String.Format("No se encontró el concepto {0} en el formulario XBRL {1}", DetalleParametrosContribucion.FirstOrDefault().dde_codi, DetalleParametrosContribucion.FirstOrDefault().def_codi));

                                            if (xbDConc[0].dco_valo == "" || xbDConc[0].dco_valo == null)
                                            {
                                                tOXbAuliqCxcContribucion.cxc_sald = 0;
                                            }
                                            else
                                            {

                                                if (xbDConc[0].dco_valo.Contains(","))
                                                    throw new Exception(String.Format("El valor no puede contener el simbolo (,)"));

                                                xbDConc[0].dco_valo = xbDConc[0].dco_valo.Replace(".", "");
                                                tOXbAuliqCxcContribucion.cxc_sald = decimal.Parse(xbDConc[0].dco_valo);

                                            }

                                        }
                                        else
                                        {

                                            tOXbAuliqCxcContribucion.cxc_sald = decimal.Parse(xbConce[0].con_valo);

                                        }

                                        break;
                                }
                                tOXbAuliqCxcContribucion.cxc_bgrav = tOXbAuliqCxcContribucion.cxc_sald;
                                tOXbAuliqCxcContribucion.dpa_tari = DetalleParametrosContribucion.Where(t => t.ite_ctts == ite_ctse).FirstOrDefault().dpa_tari;
                                tOXbAuliqCxcContribucion.cxc_sald = (decimal.Parse(DetalleParametrosContribucion.Where(t => t.ite_ctts == ite_ctse).FirstOrDefault().dpa_tari.ToString()) * tOXbAuliqCxcContribucion.cxc_sald) / 100;
                                tOXbAuliqCxcContribucion.cxc_tota = tOXbAuliqCxcContribucion.cxc_sald;
                                tOXbAuliqCxcContribucion.cxc_inmo = 0;
                                tOXbAuliqCxcContribucion.cxc_feve = tOXbAuliqCxcContribucion.par_fech;



                                //TODO:CREAR LA CXC DE INTERESES INMEDIATAMENTE SI YA SE PASÓ LA FECHA MÁXIMA EN LA QUE DEBE PAGAR EL VIGILADO
                                if (par_fech > tOXbAuliqCxcContribucion.par_fech)
                                {
                                    tOXbAuliqCxcContribucion.cxc_inmo = new BO_Autliq().CalcularIntereses(tOXbAuliqCxcContribucion.par_fech, par_fech, tOXbAuliqCxcContribucion.cxc_sald, emp_codi);
                                    //Si la fecha seleccionada por el usuario es mayor a par_fech (máxima fecha de pago sin intereses) entonces el par_fech de la cuenta es la fecha seleccionada por el usuario
                                    tOXbAuliqCxcContribucion.par_fech = par_fech;
                                }




                            }
                        }
                        catch (Exception ex)
                        {

                            tOXbAuliqCxcContribucion.error = ex.Message;
                            tOXbAuliqCxcContribucion.liq_lock = true;

                        }
                        finally
                        {
                            if (tOXbAuliqCxcContribucion.error.IndexOf("Ya existe") < 0)
                                liquidacionLista.Add(tOXbAuliqCxcContribucion);
                        }


                    }
                }

                if (liquidacionLista != null && liquidacionLista.Any())
                {
                    liquidacionLista = liquidacionLista.OrderBy(t => t.rcx_vige).ToList();
                }

                return new TOTransaction<List<TOXbAuliq>>() { ObjTransaction = liquidacionLista, Retorno = 0, TxtError = "" };
            }
            catch (Exception ex)
            {

                return new TOTransaction<List<TOXbAuliq>>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }
        }

        public TOTransaction SetAutliq(Xb_AutliqP autoliquidacion)
        {
            List<KeyValuePair<int, int>> CxcGeneradas = new List<KeyValuePair<int, int>>();
            var xbpceca = new DAO_Xb_Pceca().GetXbPeca(autoliquidacion.emp_codi);
            try
            {
                //int cxc_cont_origen = 0;
                string usuario = System.Configuration.ConfigurationManager.AppSettings
                  .Get("usuario");
                string password = System.Configuration.ConfigurationManager.AppSettings
                    .Get("password");
                string alias = System.Configuration.ConfigurationManager.AppSettings
                    .Get("alias");

                SCaCxCob.ISCaCxCobDMR scacxcob = new SCaCxCob.SCaCxCobDMR();
                string txterror = "";
                object[] varEntr = { usuario, Encrypta.EncriptarClave(password), alias, "SCaCxCob", "", "", "", "", "", "N" };
                object varSali;
                if (scacxcob.ProgramLogin(varEntr, out varSali, out txterror) != 0)
                    throw new Exception("Error al ingresar a SEVEN-ERP, " + txterror);
                var gnParam = new DAO_Gn_Param().GetGnParam(autoliquidacion.emp_codi);
                if (gnParam == null)
                    throw new Exception("No se encontró parámetros generales");
                var cliente = DAOFaClien.GetFaClien(autoliquidacion.emp_codi, autoliquidacion.cli_coda);
                var GrupoInformacionFinanciera = new DAO_Fa_Inacl().GetFaInacl(autoliquidacion.emp_codi, cliente.cli_codi);
                foreach (TOXbAuliq cuenta in autoliquidacion.cuentas)
                {
                    var ddina = new DAO_Fa_Dina().ConsultarFaDdina(autoliquidacion.emp_codi, cliente.cli_codi).Where(f => f.ite_ctse == cuenta.ite_ctse).FirstOrDefault();
                    var parco = new DAO_Xb_Dparc().GetXbParcoAnoPagar(autoliquidacion.emp_codi, GrupoInformacionFinanciera.Ite_Ctgo, cuenta.rcx_vige);
                    if (parco == null && cuenta.top_codi != xbpceca.top_core)
                        throw new Exception("No se encontró fecha máxima de pago.");

                    //Si el cxc_cont es 0 quiere decir que es nueva contribución 
                    if (cuenta.cxc_cont == 0 && cuenta.top_codi == xbpceca.top_coco)
                    {
                        DateTime fechaMaxinaSinInteres = new DateTime();
                        //var ParametrosContribucion = new DAO_Xb_Dparc().GetXbParco(autoliquidacion.emp_codi, GrupoInformacionFinanciera.Ite_Ctgo, cuenta.rcx_vige);
                        if (parco != null && parco.par_fec1 < DateTime.Now.Date && parco.par_fec2 != null)
                            fechaMaxinaSinInteres = parco.par_fec2.Value;
                        else
                            fechaMaxinaSinInteres = parco.par_fec1;
                        //Si no tiene nada pendiente genera la cxc
                        var toper = DAOGnToper.GetGnToper(autoliquidacion.emp_codi, cuenta.top_codi);
                        if (toper == null)
                            throw new Exception("No se encontró tipo de operación con código " + xbpceca.top_coco);
                        var ctope = new DAOGnCtope().ConsultarGnCTope(autoliquidacion.emp_codi, xbpceca.top_coco);
                        if (ctope == null)
                            throw new Exception("No se encontró cuenta para el tipo de operación con código " + xbpceca.top_coco);
                        var arbolSucursal = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_suco);
                        if (arbolSucursal == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_suco);
                        var arbolCcosto = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_ceco);
                        if (arbolCcosto == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_ceco);
                        var arbolAreaNegocio = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_arco);
                        if (arbolAreaNegocio == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_arco);
                        var arbolProyecto = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_prco);
                        if (arbolProyecto == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_prco);

                        var produ = DAO_In_Produ.GetInProdu(autoliquidacion.emp_codi, "", xbpceca.pro_coco);
                        if (produ == null)
                            throw new Exception("No se encontró Producto con consecutivo " + xbpceca.pro_coco);

                        //generacion de cxc
                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.dcc_cont = 1;
                        scacxcob.fac_cont = 0;
                        scacxcob.top_codi = xbpceca.top_coco;
                        scacxcob.cxc_nume = 0;
                        scacxcob.act_cons = true;
                        scacxcob.cxc_fech = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cue_codi = ctope.cue_codi;
                        scacxcob.cli_codi = cliente.cli_codi;
                        scacxcob.cli_cont = cliente.cli_codi;
                        scacxcob.dcl_codd = 1;
                        scacxcob.arb_csuc = arbolSucursal.arb_codi;
                        scacxcob.mon_codi = gnParam.mon_codi;
                        scacxcob.cxc_feta = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cxc_tasa = 1;
                        scacxcob.cxc_tipo = "D";
                        scacxcob.cxc_feve = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd"));
                        scacxcob.cxc_gcte = 0;
                        scacxcob.cxc_gmor = 0;
                        scacxcob.cxc_inco = 0;
                        scacxcob.cxc_inmo = 0;
                        scacxcob.cxc_pago = 0;

                        scacxcob.val_sald = false;
                        scacxcob.cxc_sald = double.Parse(cuenta.cxc_sald.ToString());  //valor de la CXC
                        scacxcob.cxc_tota = double.Parse(cuenta.cxc_sald.ToString());  //valor de la CXC
                        scacxcob.cxc_fuin = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd"));
                        scacxcob.cxc_caus = "N";
                        scacxcob.imm_codi = "0";
                        scacxcob.aer_matr = "0";
                        scacxcob.tip_cale = "C";
                        scacxcob.cxc_clas = 0;
                        scacxcob.ven_codi = 0;
                        scacxcob.ven_cods = 0;
                        scacxcob.tip_codi = produ.FirstOrDefault().tip_codi;   //Tipo de producto
                        scacxcob.cxc_feci = autoliquidacion.par_fech;
                        scacxcob.cxc_fecf = autoliquidacion.par_fech;
                        scacxcob.cxc_cref = "";
                        scacxcob.cxc_fpag = autoliquidacion.par_fech;
                        scacxcob.cxc_desc = string.Format("Contribución {0}", parco.par_anop);
                        //scacxcob.cxc_fexi = p_cxc_fech;   //fecha
                        //scacxcob.cxc_cosa = "N";
                        scacxcob.cxc_fupa = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd")); //Numerica YYYYMMDD
                        var res = scacxcob.InsertarCaCxCob();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        cuenta.cxc_cont = scacxcob.cxc_cont;
                        int cxc_nume = scacxcob.cxc_nume;
                        //scacxcob = new SCaCxCob.SCaCxCobDMR();
                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.fac_cont = 0;
                        //scacxcob.cxc_cont = cxc_cont_origen;
                        scacxcob.arb_codc = arbolCcosto.arb_codi;   //codigo centro de costo
                        scacxcob.arb_codp = arbolProyecto.arb_codi;   //codigo proyecto
                        scacxcob.arb_coda = arbolAreaNegocio.arb_codi;  //codigo area
                        scacxcob.arb_csuc = arbolSucursal.arb_codi;    //codigo sucursal
                        scacxcob.dif_porc = 1;
                        res = scacxcob.InsertarFaDifac();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        res = scacxcob.Aplicar(autoliquidacion.emp_codi, cuenta.cxc_cont);

                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        //return salida;
                        CxcGeneradas.Add(new KeyValuePair<int, int>(scacxcob.cxc_cont, cuenta.top_codi));

                        //Inserta en la tabla de relaciones contribución vigencia

                        new DAOCaRcxcv().SetCaRcxcv(
                            new Ca_Rcxcv()
                            {
                                aud_esta = "A",
                                aud_ufac = DateTime.Now,
                                aud_usua = autoliquidacion.usu_codi,
                                cli_codi = cliente.cli_codi,
                                cxc_cont = cuenta.cxc_cont,
                                dcl_codd = 1,
                                emp_codi = autoliquidacion.emp_codi,
                                ite_ctse = int.Parse(cuenta.ite_ctse.ToString()),
                                rcx_vige = cuenta.rcx_vige,
                            });
                    }


                    //TODO: Crear la cxc de intereses si la cxc de contribución es nueva
                    if (cuenta.cxc_inmo > 0 && cuenta.top_codi == xbpceca.top_coco)
                    {

                        var CxcInteresesPendientes = new DAOCaCpcob().GetCaCpCobSinAbonos(autoliquidacion.emp_codi, cuenta.cxc_cont);
                        //Se anulan las cuentas por cobrar por concepto de intereses que no tengan abonos
                        if (CxcInteresesPendientes != null && CxcInteresesPendientes.Any())
                        {
                            foreach (TOCaCpcob cacxcob in CxcInteresesPendientes)
                            {

                                int? resAnula = new DAOCaCxcob().AnularCaCxcob(autoliquidacion.emp_codi, cacxcob.cxc_dest);
                                if (resAnula == null)
                                    throw new Exception("No se pudo anular la cuenta por cobrar existente.");
                            }
                        }



                        var toperMO = DAOGnToper.GetGnToper(autoliquidacion.emp_codi, xbpceca.top_como);
                        if (toperMO == null)
                            throw new Exception("No se encontró tipo de operación con código " + xbpceca.top_como);
                        var ctopeMO = new DAOGnCtope().ConsultarGnCTope(autoliquidacion.emp_codi, xbpceca.top_como);
                        if (ctopeMO == null)
                            throw new Exception("No se encontró cuenta para el tipo de operación con código " + xbpceca.top_como);

                        var arbolSucursalMO = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_sumo);
                        if (arbolSucursalMO == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_sumo);
                        var arbolCcostoMO = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_cemo);
                        if (arbolCcostoMO == null)
                            throw new Exception("No se encontró centro de costos con consecutivo " + xbpceca.arb_cemo);
                        var arbolAreaNegocioMO = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_armo);
                        if (arbolAreaNegocioMO == null)
                            throw new Exception("No se encontró area de negocio con consecutivo " + xbpceca.arb_armo);
                        var arbolProyectoMO = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_prmo);
                        if (arbolProyectoMO == null)
                            throw new Exception("No se encontró proyecto con consecutivo " + xbpceca.arb_prmo);
                        //DateTime fechaMaximaPago = DateTime.Now;
                        var produMO = DAO_In_Produ.GetInProdu(autoliquidacion.emp_codi, "", xbpceca.pro_como); ;
                        if (produMO == null)
                            throw new Exception("No se encontró Producto con consecutivo " + xbpceca.pro_como);

                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.dcc_cont = 1;
                        scacxcob.fac_cont = 0;
                        scacxcob.top_codi = xbpceca.top_como;
                        scacxcob.cxc_nume = 0;
                        scacxcob.act_cons = true;
                        scacxcob.cxc_fech = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cue_codi = ctopeMO.cue_codi;
                        scacxcob.cli_codi = cliente.cli_codi;
                        scacxcob.cli_cont = cliente.cli_codi;
                        scacxcob.dcl_codd = ddina.dcl_codd;
                        scacxcob.arb_csuc = arbolSucursalMO.arb_codi;
                        scacxcob.mon_codi = gnParam.mon_codi;
                        scacxcob.cxc_feta = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cxc_tasa = 1;
                        scacxcob.cxc_desc = string.Format("Intereses Año Gravable {0}", parco.par_anof);
                        scacxcob.cxc_tipo = "D";
                        scacxcob.cxc_feve = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd"));
                        scacxcob.cxc_gcte = 0;
                        scacxcob.cxc_gmor = 0;
                        scacxcob.cxc_inco = 0;
                        scacxcob.cxc_inmo = 0;
                        scacxcob.cxc_pago = 0;
                        scacxcob.val_sald = false;
                        scacxcob.cxc_sald = double.Parse(cuenta.cxc_inmo.ToString());  //valor de la CXC
                        scacxcob.cxc_tota = double.Parse(cuenta.cxc_inmo.ToString());  //valor de la CXC
                        scacxcob.cxc_fuin = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd"));
                        scacxcob.cxc_caus = "S";
                        scacxcob.imm_codi = "0";
                        scacxcob.aer_matr = "0";
                        scacxcob.tip_cale = "C";
                        scacxcob.cxc_clas = 0;
                        scacxcob.ven_codi = 0;
                        scacxcob.ven_cods = 0;
                        scacxcob.tip_codi = produMO.FirstOrDefault().tip_codi;   //Tipo de producto
                        scacxcob.cxc_feci = Convert.ToDateTime(autoliquidacion.par_fech);   //fecha
                        scacxcob.cxc_fecf = Convert.ToDateTime(autoliquidacion.par_fech);   //fecha
                        scacxcob.cxc_cref = "";
                        scacxcob.cxc_fpag = Convert.ToDateTime(autoliquidacion.par_fech);   //fecha
                                                                                            //scacxcob.cxc_fexi = p_cxc_fech;   //fecha
                                                                                            //scacxcob.cxc_cosa = "N";
                        scacxcob.cxc_fupa = int.Parse(DateTime.Now.ToString("yyyyMMdd")); //Numerica YYYYMMDD
                        var res = scacxcob.InsertarCaCxCob();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        //scacxcob = new SCaCxCob.SCaCxCobDMR();
                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.fac_cont = 0;
                        scacxcob.arb_codc = arbolCcostoMO.arb_codi;   //codigo centro de costo
                        scacxcob.arb_codp = arbolProyectoMO.arb_codi;   //codigo proyecto
                        scacxcob.arb_coda = arbolAreaNegocioMO.arb_codi;  //codigo area
                        scacxcob.arb_csuc = arbolSucursalMO.arb_codi;    //codigo sucursal
                        scacxcob.dif_porc = 1;
                        res = scacxcob.InsertarFaDifac();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        res = scacxcob.Aplicar(autoliquidacion.emp_codi, scacxcob.cxc_cont);

                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        CxcGeneradas.Add(new KeyValuePair<int, int>(scacxcob.cxc_cont, cuenta.top_codi));

                        //Inserta en tabla de relación contribución intereses
                        Ca_Cpcob cacpcob = new Ca_Cpcob();
                        cacpcob.emp_codi = autoliquidacion.emp_codi;
                        cacpcob.cxc_orig = cuenta.cxc_cont;
                        cacpcob.cpc_cont = new DAOCaCpcob().getConseCaCpcob(autoliquidacion.emp_codi);
                        cacpcob.cxc_dest = scacxcob.cxc_cont;
                        new DAOCaCpcob().SetCaCpcob(cacpcob, autoliquidacion.usu_codi);
                    }
                    if (cuenta.cxc_inmo > 0 && cuenta.top_codi == xbpceca.top_core)
                    {


                        var CxcInteresesPendientes = new DAOCaCpcob().GetCaCpCobSinAbonos(autoliquidacion.emp_codi, cuenta.cxc_cont);
                        //Se anulan las cuentas por cobrar por concepto de intereses que no tengan abonos
                        if (CxcInteresesPendientes != null && CxcInteresesPendientes.Any())
                        {
                            foreach (TOCaCpcob cacxcob in CxcInteresesPendientes)
                            {

                                int? resAnula = new DAOCaCxcob().AnularCaCxcob(autoliquidacion.emp_codi, cacxcob.cxc_dest);
                                if (resAnula == null)
                                    throw new Exception("No se pudo anular la cuenta por cobrar existente.");
                            }
                        }


                        int? res = null;
                        int cxc_cont = 0;
                        int cxc_nume = 0;
                        int fechaInt = int.Parse(Convert.ToDateTime(autoliquidacion.par_fech).ToString("yyyyMMdd"));

                        var toper = DAOGnToper.GetGnToper(autoliquidacion.emp_codi, xbpceca.top_comi);
                        if (toper == null)
                            throw new Exception("No se encontró tipo de operación con código " + xbpceca.top_comi);
                        var ctope = new DAOGnCtope().ConsultarGnCTope(autoliquidacion.emp_codi, xbpceca.top_comi);
                        if (ctope == null)
                            throw new Exception("No se encontró cuenta para el tipo de operación con código " + xbpceca.top_comi);
                        var arbolSucursal = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_sumi);
                        if (arbolSucursal == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_sumi);
                        var arbolCcosto = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_cemi);
                        if (arbolCcosto == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_cemi);
                        var arbolAreaNegocio = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_armi);
                        if (arbolAreaNegocio == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_prmi);
                        var arbolProyecto = new DAO_Gn_Arbol().GetGnArbol(autoliquidacion.emp_codi, xbpceca.arb_prmi);
                        if (arbolProyecto == null)
                            throw new Exception("No se encontró sucursal con consecutivo " + xbpceca.arb_prmi);

                        var produ = DAO_In_Produ.GetInProdu(autoliquidacion.emp_codi, "", xbpceca.pro_comi);
                        if (produ == null)
                            throw new Exception("No se encontró Producto con consecutivo " + xbpceca.pro_comi);



                        DateTime fechaVencimiento = cuenta.cxc_feve.Date;
                        DateTime fechaPago = autoliquidacion.par_fech;

                        //generacion de cxc
                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.dcc_cont = 1;
                        scacxcob.fac_cont = 0;
                        scacxcob.top_codi = xbpceca.top_comi;
                        scacxcob.cxc_nume = 0;
                        scacxcob.act_cons = true;
                        scacxcob.cxc_fech = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cue_codi = ctope.cue_codi;
                        scacxcob.cli_codi = cliente.cli_codi;
                        scacxcob.cli_cont = cliente.cli_codi;
                        scacxcob.dcl_codd = ddina.dcl_codd;
                        scacxcob.arb_csuc = arbolSucursal.arb_codi;
                        scacxcob.mon_codi = gnParam.mon_codi;
                        scacxcob.cxc_feta = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
                        scacxcob.cxc_tasa = 1;
                        scacxcob.cxc_desc = string.Format("Intereses multas y sanciones vigencia {0}", cuenta.rcx_vige);
                        scacxcob.cxc_tipo = "D";
                        scacxcob.cxc_feve = fechaInt;
                        scacxcob.cxc_gcte = 0;
                        scacxcob.cxc_gmor = 0;
                        scacxcob.cxc_inco = 0;
                        scacxcob.cxc_inmo = 0;
                        scacxcob.cxc_pago = 0;
                        scacxcob.val_sald = false;
                        scacxcob.cxc_sald = double.Parse(cuenta.cxc_inmo.ToString());
                        scacxcob.cxc_tota = double.Parse(cuenta.cxc_inmo.ToString());
                        scacxcob.cxc_fuin = fechaInt;
                        scacxcob.cxc_caus = "S";
                        scacxcob.imm_codi = "0";
                        scacxcob.aer_matr = "0";
                        scacxcob.tip_cale = "C";
                        scacxcob.cxc_clas = 0;
                        scacxcob.ven_codi = 0;
                        scacxcob.ven_cods = 0;
                        scacxcob.tip_codi = produ.FirstOrDefault().tip_codi;
                        scacxcob.cxc_feci = Convert.ToDateTime(autoliquidacion.par_fech);   //fecha
                        scacxcob.cxc_fecf = Convert.ToDateTime(autoliquidacion.par_fech);   //;   //fecha
                        scacxcob.cxc_cref = "";
                        scacxcob.cxc_fpag = Convert.ToDateTime(autoliquidacion.par_fech);   //fecha
                                                                                            //scacxcob.cxc_fexi = p_cxc_fech;   //fecha
                                                                                            //scacxcob.cxc_cosa = "N";
                        scacxcob.cxc_fupa = int.Parse(autoliquidacion.par_fech.ToString("yyyyMMdd")); //Numerica YYYYMMDD
                        res = scacxcob.InsertarCaCxCob();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        //throw new Exception(scacxcob.TxtError);

                        cxc_cont = scacxcob.cxc_cont;
                        cxc_nume = scacxcob.cxc_nume;

                        scacxcob.emp_codi = autoliquidacion.emp_codi;
                        scacxcob.fac_cont = 0;
                        scacxcob.cxc_cont = cxc_cont;
                        scacxcob.arb_codc = arbolCcosto.arb_codi;   //codigo centro de costo
                        scacxcob.arb_codp = arbolProyecto.arb_codi;   //codigo proyecto
                        scacxcob.arb_coda = arbolAreaNegocio.arb_codi;  //codigo area
                        scacxcob.arb_csuc = arbolSucursal.arb_codi;    //codigo sucursal
                        scacxcob.dif_porc = 1;

                        res = scacxcob.InsertarFaDifac();
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        res = scacxcob.Aplicar(autoliquidacion.emp_codi, cxc_cont);
                        if (res == 1)
                            throw new Exception(scacxcob.TxtError);
                        //Inserta en la tabla de relación de intereses
                        CxcGeneradas.Add(new KeyValuePair<int, int>(scacxcob.cxc_cont, cuenta.top_codi));

                        //Inserta en tabla de relación contribución intereses
                        Ca_Cpcob cacpcob = new Ca_Cpcob();
                        cacpcob.emp_codi = autoliquidacion.emp_codi;
                        cacpcob.cxc_orig = cuenta.cxc_cont;
                        cacpcob.cpc_cont = new DAOCaCpcob().getConseCaCpcob(autoliquidacion.emp_codi);
                        cacpcob.cxc_dest = scacxcob.cxc_cont;
                        cacpcob.cpc_vige = cuenta.rcx_vige;
                        new DAOCaCpcob().SetCaCpcob(cacpcob, autoliquidacion.usu_codi);

                    }

                }
                //Retorna correcto                
                return new TOTransaction() { Retorno = 0, TxtError = "" };

            }
            catch (Exception ex)
            {
                if (CxcGeneradas.Count > 0)
                {

                    try
                    {
                        foreach (KeyValuePair<int, int> cuenta in CxcGeneradas)
                        {
                            int? resAnula = new DAOCaCxcob().AnularCaCxcob(autoliquidacion.emp_codi, cuenta.Key);
                            if (resAnula == null)
                                throw new Exception("No se pudo anular la cuenta por cobrar existente.");

                            if (cuenta.Value == xbpceca.top_coco)
                            {
                                var delete = new DAOCaRcxcv().DeleteCaRcxcv(autoliquidacion.emp_codi, cuenta.Key);
                            }
                            if (cuenta.Value == xbpceca.top_como)
                            {
                                var delete = new DAOCaCpcob().DeleteCaCpcob(autoliquidacion.emp_codi, cuenta.Key);
                            }

                        }
                    }
                    catch (Exception)
                    {


                    }

                }
                return new TOTransaction() { Retorno = 1, TxtError = ex.Message };

            }
        }

        public TOTransaction<string> BuildPrintLink(ToPrintLiq autoliquidacion)
        {
            try
            {

                var xbpceca = new DAO_Xb_Pceca().GetXbPeca(autoliquidacion.emp_codi);
                var client = DAOFaClien.GetFaClien(autoliquidacion.emp_codi, autoliquidacion.cli_coda);
                string reportPublic = ConfigurationManager.AppSettings["reportPublic"].ToString();
                string dinamicReport = ConfigurationManager.AppSettings["dinamicReport"].ToString();
                StringBuilder sf = new StringBuilder();
                GeneraUrl gurl = new GeneraUrl();
                string url = "";
                string urlReporte = ConfigurationManager.AppSettings["UrlReport"];
                string reporte = "";
                if (autoliquidacion.cxc_info.top_codi == xbpceca.top_coco)
                {

                    var fechaActual = DateTime.Now.ToString("yyyy-MM-dd");


                    reporte = "Bauliq";
                    List<string> Params = new List<string>();
                    Params.Add(autoliquidacion.emp_codi.ToString());
                    Params.Add(autoliquidacion.emp_nomb);
                    Params.Add(autoliquidacion.usu_codi);
                    Params.Add("dd-mm-yyyy");
                    Params.Add(autoliquidacion.cxc_info.rcx_vige.ToString());
                    Params.Add(autoliquidacion.cli_coda);
                    Params.Add(autoliquidacion.cli_noco);
                    Params.Add(autoliquidacion.cli_dire);
                    Params.Add(autoliquidacion.mun_nomb);
                    Params.Add(autoliquidacion.dep_nomb);
                    Params.Add(autoliquidacion.ite_nose);
                    Params.Add(autoliquidacion.ina_refe);
                    Params.Add(autoliquidacion.cxc_info.cxc_bgrav.ToString());
                    Params.Add(autoliquidacion.cxc_info.dpa_tari.ToString());
                    Params.Add(autoliquidacion.cxc_info.cxc_sald.ToString());
                    Params.Add(autoliquidacion.cxc_info.cxc_inmo.ToString());
                    Params.Add((autoliquidacion.cxc_info.cxc_sald + autoliquidacion.cxc_info.cxc_inmo + autoliquidacion.cxc_info.cxc_inan).ToString());
                    Params.Add(autoliquidacion.cxc_info.par_fech.ToString("dd/MM/yyyy"));
                    Params.Add(fechaActual);
                    Params.Add(DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString());
                    Params.Add(DateTime.Now.Date.ToString("yyyy-MM-dd"));
                    Params.Add("Pgn_Wxbauliq");
                    sf.Append(" {FA_CLIEN.EMP_CODI} = " + autoliquidacion.emp_codi);
                    sf.Append(" AND {FA_CLIEN.CLI_CODI} = " + client.cli_codi);
                    string encabezadoGuardado = ConfigurationManager.AppSettings["encabezadoIP"].ToString();
                    string ipInterna = HttpContext.Current.Request.UserHostAddress;
                    try
                    {
                        string encabezadoIp = "";
                        if (ipInterna.Split('.').Count() > 1)
                        {
                            encabezadoIp = ipInterna.Split('.')[0].ToString() + ipInterna.Split('.')[1].ToString();
                        }

                        if (encabezadoIp != encabezadoGuardado)
                            urlReporte = reportPublic;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(string.Format("Error convirtiendo IP:{0}", ex.Message));
                    }
                    url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);

                    return new TOTransaction<string>() { ObjTransaction = url, Retorno = 0, TxtError = "" };
                }

                else
                {
                    DateTime fechaPago = autoliquidacion.cxc_info.par_fech;
                    reporte = "WXblCmus";
                    List<string> Params = new List<string>();
                    Params.Add(client.cli_noco);
                    Params.Add(fechaPago.ToString("dd/MM/yyyy"));

                    Params.Add(autoliquidacion.cxc_info.top_codi.ToString());
                    sf.Append(" {GN_EMPRE.EMP_CODI} = " + autoliquidacion.emp_codi.ToString());
                    sf.Append(" AND {CA_CXCOB.TOP_CODI} = " + xbpceca.top_core.ToString());
                    sf.Append(" AND {CA_CXCOB.CLI_CODI} = " + client.cli_codi.ToString());
                    sf.Append(" AND {CA_CXCOB.CXC_ESTA} = 'A' ");
                    sf.Append(" AND {CA_CXCOB.CXC_CONT} = " + autoliquidacion.cxc_info.cxc_cont.ToString());
                    url = GetURLReporte(reporte, Params, sf.ToString(), urlReporte);
                    return new TOTransaction<string>() { ObjTransaction = url, Retorno = 0, TxtError = "" };
                }


            }
            catch (Exception ex)
            {
                return new TOTransaction<string>() { ObjTransaction = null, Retorno = 1, TxtError = ex.Message };
            }

        }

        public string GetURLReporte(string reporte, List<string> parametros, string sf, string urlreport)
        {
            string servidor = urlreport;
            string formatofecha = ConfigurationManager.AppSettings["formatoFecha"].ToString();

            string urlreporte = servidor;

            urlreporte += "?" + "nombrerpt=" + reporte;
            int i = 0;

            //empresa
            //nombre
            //usuario
            //formato

            foreach (var item in parametros)
            {
                urlreporte += "&promptex" + i + "=" + item.ToString();
                i++;
            }

            urlreporte += "&sf=" + sf;


            return urlreporte;
        }


    }

}




