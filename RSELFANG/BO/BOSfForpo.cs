using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;

namespace RSELFANG.BO
{
    public class BOSfForpo
    {
        public TOTransaction<SfFovis> GetInitialDataSf(int emp_codi)
        {   
            DAOSfForpo daoSfForpo = new DAOSfForpo();
            
            try
            {
                SfFovis fovis = new SfFovis();
                fovis.par_feab = daoSfForpo.GetSfParam(emp_codi);
                return new TOTransaction<SfFovis>() { objTransaction = fovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SfFovisInfo>> GetInfoModalidad(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfFovisInfo> sfmodvi = new List<SfFovisInfo>();
                sfmodvi = daoSfForpo.GetModVi(emp_codi);
                return new TOTransaction<List<SfFovisInfo>>() { objTransaction = sfmodvi, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfFovisInfo>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
                
        public TOTransaction<List<SfRadic>> GetInfoRadicado(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfRadic> sfradic = new List<SfRadic>();
                sfradic = daoSfForpo.GetInfoRadi(emp_codi);
                return new TOTransaction<List<SfRadic>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfRadic>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SfPostu>> GetInfoIdPostulante(int emp_codi)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfPostu> sfradic = new List<SfPostu>();
                sfradic = daoSfForpo.GetInfoIdPostulante(emp_codi);                                
                return new TOTransaction<List<SfPostu>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfPostu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<SfFovis> GetInfoPostulante(int emp_codi, int afi_cont, bool validTope)
        {
            SfFovis sffovis = new SfFovis();
            DAOSfForpo daoSfForpo = new DAOSfForpo();
            Gnmasal InfoGnMasal = new Gnmasal();
            InfoAportante suconyu = new InfoAportante();
            InfoEmpresa InfoEmpre = new InfoEmpresa();
            
            try
            {
                InfoAportante sfafili = new InfoAportante();
                sfafili = daoSfForpo.getInfoAportante(emp_codi, afi_cont);                
                sfafili.for_cond = "";

                InfoGnMasal = daoSfForpo.GetInfoMasal(DateTime.Now.Year);
                sfafili.afi_ipil = daoSfForpo.getSalarioPostul(emp_codi, afi_cont);

                if (validTope)
                {
                    if (sfafili.afi_ipil > InfoGnMasal.mas_vrsm)
                    {
                        throw new Exception("El postulante superal el tope salarial");
                    }
                }
            
                if (afi_cont != 0)
                {
                    suconyu = daoSfForpo.getInfoConyu(emp_codi, afi_cont);
                    InfoEmpre = daoSfForpo.getInfoEmpre(emp_codi, afi_cont);
                }

                sffovis.InfoAportante = sfafili;
                sffovis.InfoConyuge = suconyu;
                sffovis.InfoGnmasal = InfoGnMasal;
                sffovis.InfoEmpresa = InfoEmpre;
                return new TOTransaction<SfFovis>() { objTransaction = sffovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction<sfforpo> GetValidInfoPostulante(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                sfforpo sfforpo = new sfforpo();
                sfforpo = daoSfForpo.GetValidInfoPostulante(emp_codi, afi_cont);
                return new TOTransaction<sfforpo>() { objTransaction = sfforpo, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<sfforpo>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
                
        public TOTransaction<SfFovis> GetInfoAportante(int emp_codi, int rad_nume, int for_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();
            SfFovis sffovis = new SfFovis();
            rnradic rnradic = new rnradic();
            InfoAportante suafili = new InfoAportante();
            InfoAportante suconyu = new InfoAportante();
            List<InfoNovedades> novedad = new List<InfoNovedades>();
            List<InfoTrayectoria> trayect = new List<InfoTrayectoria>();
            List<InfoSuPerca> superca = new List<InfoSuPerca>();
            List<InfoOtrosMiembros> otrosM = new List<InfoOtrosMiembros>();
            sfdmodv InfoModvi = new sfdmodv();
            Gnmasal InfoGnMasal = new Gnmasal();
            InfoEmpresa InfoEmpre = new InfoEmpresa();

            try
            {
                rnradic = daoSfForpo.GetInfoRnRadi(emp_codi, rad_nume);

                if (rnradic != null)
                {
                    int for_nume = 0;
                    for_nume = daoSfForpo.GetInfoForpo(emp_codi, rnradic.afi_cont);

                    if(for_nume != 0)
                    {
                        throw new Exception("El afiliado tiene registros de postulación en estado diferente a Rechazado o Retiro voluntario. Formulario Número: " + for_nume);
                    }
                    
                    InfoGnMasal = daoSfForpo.GetInfoMasal(DateTime.Now.Year);
                    sffovis.drp_salab = daoSfForpo.getSalarioPostul(emp_codi, rnradic.afi_cont);

                    //if (sffovis.drp_salab > InfoGnMasal.mas_vrsm)
                    //{
                    //    throw new Exception("El postulante superal el tope salarial");
                    //}

                    suafili = daoSfForpo.getInfoAportante(emp_codi, rnradic.afi_cont);

                    if (suafili != null)
                    {
                        suafili.rad_nume = rad_nume;
                        sffovis.rad_nume = rad_nume;
                        sffovis.InfoAportante = suafili;                        

                        if (sffovis.mod_cont != null)
                            InfoModvi = daoSfForpo.getInfoModvi(emp_codi, sffovis.mod_cont);

                        InfoEmpre = daoSfForpo.getInfoEmpre(emp_codi, suafili.afi_cont);
                    }

                    if (for_cont != 0)
                    {
                        suconyu = daoSfForpo.getInfoConyugeFromForpo(emp_codi, for_cont);
                        novedad = daoSfForpo.getInfoNovedades(emp_codi, for_cont);
                        trayect = daoSfForpo.getInfoTrayectorias(emp_codi, for_cont);
                        superca = daoSfForpo.getInfoSuPerca(emp_codi, for_cont);
                        otrosM = daoSfForpo.getInfoMiembros(emp_codi, for_cont);
                    }
                    else
                    {
                        if (suafili.afi_cont != 0)
                        {
                            suconyu = daoSfForpo.getInfoConyu(emp_codi, suafili.afi_cont);
                            InfoEmpre = daoSfForpo.getInfoEmpre(emp_codi, suafili.afi_cont);
                        }
                    }

                    sffovis.InfoConyuge = suconyu;                  
                    sffovis.InfoModvi = InfoModvi;
                    sffovis.InfoGnmasal = InfoGnMasal;
                    sffovis.InfoEmpresa = InfoEmpre;
                }                

                return new TOTransaction<SfFovis>() { objTransaction = sffovis, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<SfFovis>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<GnItems>> GetGnItems(int tit_cont)
        {
            DAOGnItems daoItems = new DAOGnItems();
            List<GnItems> ListItems = new List<GnItems>();

            try
            {
                ListItems = daoItems.GetGnItemsLupa(tit_cont, "");
                return new TOTransaction<List<GnItems>>() { objTransaction = ListItems, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<GnItems>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoConyuge(int emp_codi, int afi_cont)
        {
            InfoAportante suconyu = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                suconyu = daoSfForpo.getInfoConyu(emp_codi, afi_cont);
                return new TOTransaction<InfoAportante>() { objTransaction = suconyu, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<SfPostu>> GetInfoIdConyuge(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfPostu> sfradic = new List<SfPostu>();
                sfradic = daoSfForpo.GetInfoIdConyuge(emp_codi, afi_cont);
                return new TOTransaction<List<SfPostu>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfPostu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
        
        public TOTransaction<List<SfPostu>> GetInfoIdPerca(int emp_codi, int afi_cont)
        {
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                List<SfPostu> sfradic = new List<SfPostu>();
                sfradic = daoSfForpo.GetInfoIdPerca(emp_codi, afi_cont);
                return new TOTransaction<List<SfPostu>>() { objTransaction = sfradic, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<SfPostu>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoPerca(int emp_codi, int afi_trab, int afi_cont, string afi_docu)
        {
            InfoAportante superca = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                superca = daoSfForpo.getInfoPerca(emp_codi, afi_trab, afi_cont, afi_docu);
                return new TOTransaction<InfoAportante>() { objTransaction = superca, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<InfoAportante> GetInfoOtrosM(int emp_codi, int afi_trab, int afi_cont, string afi_docu)
        {
            InfoAportante otrosM = new InfoAportante();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                otrosM = daoSfForpo.getInfoAportante(emp_codi, afi_cont);
                return new TOTransaction<InfoAportante>() { objTransaction = otrosM, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<InfoAportante>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
                
        public TOTransaction<sfdmodv> GetInfoIngresos(int emp_codi, int mod_cont, double for_sala)
        {
            sfdmodv modvi = new sfdmodv();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                modvi = daoSfForpo.GetInfoIngresos(emp_codi, mod_cont, for_sala);
                return new TOTransaction<sfdmodv>() { objTransaction = modvi, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<sfdmodv>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<sfconec>> GetInfoConceptos(int emp_codi, string con_tipo)
        {
            List<sfconec> dfore = new List<sfconec>();
            DAOSfForpo daoSfForpo = new DAOSfForpo();

            try
            {
                dfore = daoSfForpo.GetInfoConceptos(emp_codi, con_tipo);
                return new TOTransaction<List<sfconec>>() { objTransaction = dfore, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<sfconec>>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}