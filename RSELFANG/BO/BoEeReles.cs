using RSELFANG.DAO;
using RSELFANG.TO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace RSELFANG.BO
{
    public class BoEeReles
    {
        public TOTransaction<EeReles> GetInfoDataEeReles(int rel_cont, int rem_cont,int rel_serv)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                bool enc = daoEeReles.infoValidEereles(rem_cont, rel_serv);

                DataSet result = new DataSet();
                EeReles objReles = new EeReles();
                int countPreg = 0;
                result = daoEeReles.getEeReles(rel_cont, rem_cont);

                if (result.Tables[0].Rows.Count == 0)
                    throw new Exception("No se encontró parametrización para la encuesta especificada.");

                string redEnc = ConfigurationManager.AppSettings["redEnc"];

                if (string.IsNullOrEmpty(redEnc))
                    redEnc = "S";

                objReles.red_encu = redEnc;
                objReles.rel_cont = Int32.Parse(result.Tables[0].Rows[0]["REL_CONT"].ToString());
                objReles.rel_nomb = result.Tables[0].Rows[0]["REL_NOMB"].ToString();
                objReles.par_rein = result.Tables[0].Rows[0]["PAR_REIN"].ToString();

                foreach (DataRow dr in result.Tables[0].Rows)
                {
                    EeDrele objDrele = new EeDrele();

                    objDrele.sec_nomb = dr["SEC_NOMB"].ToString();
                    objDrele.dre_secc = Convert.ToInt32(dr["DRE_SECC"].ToString());

                    if (!objReles.Secciones.Exists(x => x.sec_nomb == objDrele.sec_nomb))
                    {
                        objReles.Secciones.Add(objDrele);
                    }

                    foreach (DataRow drr in result.Tables[0].Rows)
                    {
                        EeDrsee objDrsee = new EeDrsee();
                        objDrsee.drs_preg = drr["DRS_PREG"].ToString();
                        objDrsee.drs_clas = drr["DRS_CLAS"].ToString();
                        objDrsee.sec_cont = Convert.ToInt32(drr["SEC_CONT"].ToString());
                        objDrsee.drs_orde = Convert.ToInt32(drr["DRS_ORDE"].ToString());
                        objDrsee.rse_cont = Convert.ToInt32(drr["RSE_CONT"].ToString());
                        objDrsee.drs_cont = Convert.ToInt32(drr["DRS_CONT"].ToString());
                        objDrsee.drp_cont = Convert.ToInt32(drr["DRP_CONT"].ToString());
                        objDrsee.res_valo = drr["RES_VALO"].ToString();

                        if (enc == false)
                        {
                            if (!objDrele.Preguntas.Exists(x => x.drs_preg == objDrsee.drs_preg) && objDrele.dre_secc.Equals(objDrsee.sec_cont))
                                objDrele.Preguntas.Add(objDrsee);
                        }
                        else
                        {
                            if (!objDrele.Preguntas.Exists(x => x.drs_preg == objDrsee.drs_preg) && objDrele.dre_secc.Equals(objDrsee.sec_cont) && objDrsee.res_valo != "")
                                objDrele.Preguntas.Add(objDrsee);
                        }

                        foreach (DataRow drrr in result.Tables[0].Rows)
                        {
                            if (drrr["DRS_CLAS"].ToString() == "M")
                            {
                                EeDdprc objDdprc = new EeDdprc();
                                objDdprc.ddp_cont = Convert.ToInt32(drrr["DDP_CONT"].ToString());
                                objDdprc.drp_cont = Convert.ToInt32(drrr["DRP_CONT"].ToString());
                                objDdprc.ddp_opci = drrr["DPP_OPCI"].ToString();
                                objDdprc.dsp_orde = Convert.ToInt32(drrr["DSP_ORDE"].ToString());
                              
                                if (!objDrsee.Respuestas.Exists(x => x.ddp_opci == objDdprc.ddp_opci) && objDrele.dre_secc.Equals(objDrsee.sec_cont)
                                    && !objDrsee.Respuestas.Exists(x => x.ddp_cont == objDdprc.ddp_cont) && objDdprc.drp_cont.Equals(objDrsee.drp_cont))
                                    objDrsee.Respuestas.Add(objDdprc);
                            }
                        }
                    }
                }


                for (int i = 0; i < objReles.Secciones.Count; i++)
                {
                    countPreg += objReles.Secciones[i].Preguntas.Count;
                }
               
                objReles.num_preg = countPreg;
                return new TOTransaction<EeReles>() { objTransaction = objReles, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<EeReles>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<PqInpqr> GetInfoDataPqr(int emp_codi, int inp_cont)
        {
            DAOPqDinPq daoDinpq = new DAOPqDinPq();
            DAOPqInpqr DAOPqr = new DAOPqInpqr();

            try
            {
                List<PqInpqr> pqrList = DAOPqr.getPqInPqrEncuestas(inp_cont, emp_codi);
                PqInpqr pqr = pqrList.FirstOrDefault();

                if (pqr == null)
                    throw new Exception("No se encontraron datos con los parámetros especificados");

                pqr.seguimientos = daoDinpq.getpqDinPq(inp_cont, emp_codi);
                return new TOTransaction<PqInpqr>() { objTransaction = pqr, retorno = 0, txtRetorno = "" };

            }
            catch (Exception ex)
            {
                return new TOTransaction<PqInpqr>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<TOPqParam> GetInfoPqParam(int emp_codi)
        {
            DAOPqParam daoPqParam = new DAOPqParam();
            try
            {
                TOPqParam pqrList = daoPqParam.GetMailParam(emp_codi);
                return new TOTransaction<TOPqParam>() { objTransaction = pqrList, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<TOPqParam>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction setInfoResen(List<EeResen> eeresen)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                daoEeReles.insertEeresen(eeresen);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction setInfoResem(List<EeResem> eeresem)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                daoEeReles.insertEeresem(eeresem);
                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }



        public TOTransaction<TOPqParam> GetInfoEerelesService(int rel_serv, int emp_codi)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                TOPqParam pqrList = daoEeReles.GetEerelesServ(rel_serv, emp_codi);
                return new TOTransaction<TOPqParam>() { objTransaction = pqrList, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<TOPqParam>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction GetInfoValidEeReles(int rem_cont, int rel_serv)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                bool enc = daoEeReles.infoValidEereles(rem_cont, rel_serv);

                if (enc)
                    throw new Exception("La encuesta ya fue diligenciada");

                return new TOTransaction() { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction() { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeResen>> getInfoEeresen(int rem_cont, int emp_codi)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                var infoResen = daoEeReles.getInfoEeresen(rem_cont, emp_codi);                
                return new TOTransaction<List<EeResen>> { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeResen>> { retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<List<EeResem>> getInfoEeresem(int rem_cont, int emp_codi)
        {
            DAOEeReles daoEeReles = new DAOEeReles();

            try
            {
                var infoResem = daoEeReles.getInfoEeresem(rem_cont, emp_codi);
                return new TOTransaction<List<EeResem>> { retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<List<EeResem>> { retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}