using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using RSELFANG.DAO;

using System.IO;
using RSELFANG.tools;
using Ophelia.Comun;
using Digitalware.Apps.Utilities;
using Digitalware.Apps.Utilities.TO;
using Digitalware.Apps.Utilities.TO.Gn_Adju;

namespace RSELFANG.BO
{
    public class BOGnRadju
    {
        DAOGnRadju DAORadju = new DAOGnRadju();
        DAOGnAdju DAOAdju = new DAOGnAdju();
        DAOGnInsta DAOInsta = new DAOGnInsta();
        DAOGnAdjFi DAOAdjfi = new DAOGnAdjFi();
        DAOGnConse DAOConse = new DAOGnConse();
        public int emp_codi { get; set; }        
        public string usu_codi { get; set; }
        public BOGnRadju()
        {
            //emp_codi = int.Parse(ConfigurationManager.AppSettings["emp_codi"].ToString());
            usu_codi = ConfigurationManager.AppSettings["usu_codi"].ToString();           
        }
        public Tuple<bool, string> insertGnRadju(short emp_codi,
            string key,
            string table,
            string pro_codi,  
            int inp_cont,
           List< HttpPostedFile> files,string type="S")
        {
            bool upload = false;
            try
            {

                foreach(HttpPostedFile file  in files)
                {
                    //string name = string.Concat(file.FileName.Split('_')[0], emp_codi ,Path.GetExtension(file.FileName));
                    DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju boAdjun = new DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju();
                    file.InputStream.Position = 0;
                   upload =  boAdjun.newGnAdjun(emp_codi, pro_codi, inp_cont, table, fileHandler.ReadFully(file.InputStream),file.FileName , usu_codi, type);                  
                }
                if (!upload)
                    return new Tuple<bool, string>(false, "El archivo no fue subido");
                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }


        }


        public Tuple<bool, string> insertGnRadju(short emp_codi,
           string key,
           string table,
           string pro_codi,
           int inp_cont,
          HttpPostedFile file, string type = "S")
        {
            bool upload = false;
            try
            {

              
                    //string name = string.Concat(file.FileName.Split('_')[0], emp_codi ,Path.GetExtension(file.FileName));
                    DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju boAdjun = new DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju();
                    file.InputStream.Position = 0;
                    upload = boAdjun.newGnAdjun(emp_codi, pro_codi, inp_cont, table, fileHandler.ReadFully(file.InputStream), file.FileName, usu_codi, type);
               
                if (!upload)
                    return new Tuple<bool, string>(false, "El archivo no fue subido");
                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }

        public Tuple<bool, string> insertGnRadju(short emp_codi,string key,string table,string pro_codi,int inp_cont,byte[] file,string fileName, string type = "S")
        {
            bool upload = false;
            try
            {              
                DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju boAdjun = new DigitalWare.Apps.Utilities.Gn.BO.BOGnRadju();                
                upload = boAdjun.newGnAdjun(emp_codi, pro_codi, inp_cont, table,file, fileName, usu_codi, type);

                if (!upload)
                    return new Tuple<bool, string>(false, "El archivo no fue subido");
                return new Tuple<bool, string>(true, "");
            }
            catch (Exception ex)
            {
                return new Tuple<bool, string>(false, ex.Message);
            }
        }
    }
}