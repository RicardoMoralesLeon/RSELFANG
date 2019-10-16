using RSELFANG.DAO;
using RSELFANG.TO;
using RSELFANG.tools;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RSELFANG.BO
{
    public class BOCtPropo
    {
        public TOTransaction<CtRevPrSalida> PostPropo(CtPropo propo)
        {
            DAORevPr daoRevPr = new DAORevPr();
            DAOGnInsta daoInsta = new DAOGnInsta();
            mailHandler mailHandler = new mailHandler();

            try
            {
                propo.rev_cont = daoRevPr.GetCont("CT_REVPR", "REV_CONT", propo.emp_codi);
                daoRevPr.InseCTREVPR(propo);
                return new TOTransaction<CtRevPrSalida>() { objTransaction = new CtRevPrSalida() { rev_cont = propo.rev_cont, msg = "La transacción ha sido enviada de manera satisfactoria" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {                
                return new TOTransaction<CtRevPrSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }


        public TOTransaction<CtRevPrSalida> sendMailPropo(string mailTo)
        {
            DAORevPr daoRevPr = new DAORevPr();
            DAOGnInsta daoInsta = new DAOGnInsta();
            mailHandler mailHandler = new mailHandler();

            try
            {              
                string subject = ConfigurationManager.AppSettings["asuntoCreacion"].ToString();
                string body = ConfigurationManager.AppSettings["cuerpoCreacion"].ToString();
                Mail mail = mailHandler.generateMailCtPropo(mailTo, subject, body);
                GnInsta insta = daoInsta.GetGnInsta();
                mailHandler.sendMail(mail, insta);

                return new TOTransaction<CtRevPrSalida>() { objTransaction = new CtRevPrSalida() { msg = "El correo ha sido enviado de manera exitosa" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevPrSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtRevPrSalida> InsertActividades(int emp_codi, int rev_cont, List<GnArbol> ctacxpr)
        {
            DAORevPr daoRevPr = new DAORevPr();

            try
            {
                daoRevPr.InseCTREVAC(emp_codi, rev_cont, ctacxpr);
                return new TOTransaction<CtRevPrSalida>() { objTransaction = new CtRevPrSalida() { rev_cont = 0, msg = "" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevPrSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtRevDoSalida> InsertDocumentos(int emp_codi, int rev_cont, List<CtDocpr> ctdocpr)
        {
            DAORevPr daoRevPr = new DAORevPr();

            try
            {
                daoRevPr.InseCTREVDO(emp_codi, rev_cont, ctdocpr);
                return new TOTransaction<CtRevDoSalida>() { objTransaction = new CtRevDoSalida() { doc_cont = 0, msg = "" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevDoSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtRevDoSalida> deletePropo(int emp_codi, int rev_cont)
        {
            DAORevPr daoRevPr = new DAORevPr();

            try
            {
                daoRevPr.deletePropo(emp_codi, rev_cont);
                return new TOTransaction<CtRevDoSalida>() { objTransaction = new CtRevDoSalida() { doc_cont = 0, msg = "" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevDoSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }


        public TOTransaction<CtRevPrSalida> InsertTratDatos(myObject revtd)
        {
            DAORevPr daoRevPr = new DAORevPr();

            try
            {                
                daoRevPr.InseCTREVTD(revtd);
                return new TOTransaction<CtRevPrSalida>() { objTransaction = new CtRevPrSalida() { rev_cont = 0, msg = "" }, retorno = 0, txtRetorno = "" };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtRevPrSalida>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetInitialDataCtPropo(int emp_codi)
        {
            DAOGnTipdo daoGnTipDo = new DAOGnTipdo();
            DAOCtPropo daoCtPropo = new DAOCtPropo();
            BOGnItems boItems = new BOGnItems();
            BOGnPaise boPaise = new BOGnPaise();
            BOGnArbol boArbol = new BOGnArbol();
            DAOGnLogo daoLogo = new DAOGnLogo();

            try {

                CtPropoLoad result = new CtPropoLoad();

                List<GnTipdo> tipdoct = daoGnTipDo.getListGnTipdo();
                List<TOCtCamar> CtCamar = daoCtPropo.GetCtCamar(emp_codi);
                List<GnItem> tipCont = boItems.GetGnItems(98);
                List<GnPaise> GnPaise = boPaise.GetGnPaise();
                List<GnArbol> GnArbol = boArbol.GetGbnArbol(18, emp_codi);
                string parptda = daoCtPropo.GetPolitica(emp_codi);
                List<GnItem> CtDtrda = boItems.GetGnItems(342);
                string parcrpr = daoCtPropo.GetInfoProv(emp_codi);

                result.tipdoct = tipdoct;
                result.CtCamar = CtCamar;
                result.tipCont = tipCont;
                result.GnPaise = GnPaise;
                result.GnArbol = GnArbol;
                result.parptda = parptda;
                result.CtDtrda = CtDtrda;
                result.parcrpr = parcrpr;
                result.empImage = daoLogo.GetGnLogo(emp_codi).emp_logs;

                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetRegiones(int emp_codi, int pai_codi)
        {          
            BOGnRegio boRegio = new BOGnRegio();
           
            try
            {
                CtPropoLoad result = new CtPropoLoad();               
                List<GnRegio> GnRegio = boRegio.GetGnRegio(pai_codi);
                result.GnRegio = GnRegio;     
                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetDepartamentos(int emp_codi, int pai_codi, int reg_codi)
        {
            BOGnDepar boDepar = new BOGnDepar();

            try
            {
                CtPropoLoad result = new CtPropoLoad();
                List<GnDepar> GnDepar = boDepar.GetGnDepar(pai_codi, reg_codi);
                result.GnDepar = GnDepar;
                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetMunicipios(int emp_codi, int pai_codi, int reg_codi, int dep_codi)
        {
            BOGnMunic boMunic = new BOGnMunic();

            try
            {
                CtPropoLoad result = new CtPropoLoad();
                List<GnMunic> GnMunic = boMunic.GetGnMunic(pai_codi, reg_codi, dep_codi);                
                result.GnMunic = GnMunic;
                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetLocalidades(int emp_codi, int pai_codi, int reg_codi, int dep_codi, int mun_codi)
        {
            BOGnLocal boLocal = new BOGnLocal();

            try
            {
                CtPropoLoad result = new CtPropoLoad();
                List<GnLocal> GnLocal = boLocal.GetGnLocal(pai_codi, reg_codi, dep_codi,mun_codi);
                result.GnLocal = GnLocal;
                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }

        public TOTransaction<CtPropoLoad> GetBarrios(int emp_codi, int pai_codi, int reg_codi, int dep_codi, int mun_codi, int loc_codi)
        {
            BOGnBarri boBarrio = new BOGnBarri();

            try
            {
                CtPropoLoad result = new CtPropoLoad();
                List<GnBarri> GnBarri = boBarrio.GetGnBarri(pai_codi, reg_codi, dep_codi, mun_codi, loc_codi);
                result.GnBarri = GnBarri;
                return new TOTransaction<CtPropoLoad>() { objTransaction = result, txtRetorno = "", retorno = 0 };
            }
            catch (Exception ex)
            {
                return new TOTransaction<CtPropoLoad>() { objTransaction = null, retorno = 1, txtRetorno = ex.Message };
            }
        }
    }
}