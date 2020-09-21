using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Finance;

namespace RealEstate
{ 

    public partial class JSecAmalkard
    {

       
      
      private  JAsset Asset { get; set; }
       private JAllPerson Person { get; set; }
        public JSecAmalkard(int AssetCode)
        {


            Asset = new JAsset(AssetCode);
            Person = new JAllPerson(0);
           
        }
        public JSecAmalkard(int PersonCode,Boolean Tr)
        {

            Asset = new JAsset(0);
            Person= new JAllPerson(PersonCode);
            

        }
        public int CodeUnitBuild { get; set; }
        public void Show()
        {
            AmalkardFrm frm = new AmalkardFrm(Asset.ObjectCode);
           
            frm.ShowDialog();
        }
        public System.Data.DataTable GetAmalkard(Boolean CurrentNotActive)
        {
            
                   JDataBase Jdb = new JDataBase();
            try
            {

                if (CurrentNotActive == true)
                {
                    Jdb.setQuery("SELECT     dbo.SecService.Code, dbo.vContracts.Asset, dbo.subdefine.name," + JDataBase.SQLMiladiToShamsi("dbo.SecService.DateK", "DateKhadamat") + ", dbo.clsAllPerson.Name AS ServicePerson, " +
                      "dbo.SecService.Hint AS Description,dbo.SecService.ContractCode,dbo.clsAllPerson.Code As PersonCode " +
"FROM         dbo.SecService INNER JOIN dbo.subdefine ON dbo.SecService.TypeK = dbo.subdefine.Code INNER JOIN dbo.clsAllPerson ON dbo.SecService.PersonCode = dbo.clsAllPerson.Code INNER JOIN dbo.vContracts ON dbo.SecService.ContractCode = dbo.vContracts.Code Where dbo.vContracts.FinanceCode=" + Asset.Code.ToString()+" OR dbo.clsAllPerson.Code="+Person.Code);
                   
                }
                else
                {
                    Jdb.setQuery("SELECT     dbo.SecService.Code, dbo.vContracts.Asset, dbo.subdefine.name," + JDataBase.SQLMiladiToShamsi("dbo.SecService.DateK", "DateKhadamat") + ", dbo.clsAllPerson.Name AS ServicePerson, " +
                      "dbo.SecService.Hint AS Description,dbo.SecService.ContractCode,dbo.clsAllPerson.Code As PersonCode " +
"FROM         dbo.SecService INNER JOIN dbo.subdefine ON dbo.SecService.TypeK = dbo.subdefine.Code INNER JOIN dbo.clsAllPerson ON dbo.SecService.PersonCode = dbo.clsAllPerson.Code INNER JOIN dbo.vContracts ON dbo.SecService.ContractCode = dbo.vContracts.Code Where (dbo.vContracts.FinanceCode=" + Asset.Code.ToString() +" OR dbo.clsAllPerson.Code="+Person.Code+ ") AND dbo.vContracts.Status=1");

                }
                return Jdb.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                Jdb.Dispose();
            }
        }
        public System.Data.DataTable GetSecforms(Boolean CurrentNotActive,int Type)
        {

            JDataBase Jdb = new JDataBase();
            try
            {

                if (CurrentNotActive == true)
                {
                    Jdb.setQuery("SELECT      dbo.SecForm.Code,dbo.vContracts.Asset,dbo.SecForm.LetterNumber, " + JDataBase.SQLMiladiToShamsi("dbo.SecForm.DateC", "Date") + "," + JDataBase.SQLMiladiToShamsi("dbo.SecForm.DateCreate", "DateCreate") + ", dbo.subdefine.name As Subject, dbo.SecForm.Discription, " +
                      "dbo.clsAllPerson.Name AS Motkhalef, dbo.users.username As Usercreator,dbo.SecForm.ContractCode,dbo.clsAllPerson.Code As PersonCode " +
"FROM         dbo.SecForm INNER JOIN  dbo.subdefine ON dbo.SecForm.Subject = dbo.subdefine.Code INNER JOIN " +
                      "dbo.clsAllPerson ON dbo.SecForm.PersonCode = dbo.clsAllPerson.Code INNER JOIN " +
                      "dbo.users ON dbo.SecForm.UserCreate = dbo.users.code INNER JOIN dbo.vContracts ON dbo.SecForm.ContractCode = dbo.vContracts.Code Where (dbo.vContracts.FinanceCode=" + Asset.Code.ToString() + " OR dbo.clsAllPerson.Code="+Person.Code+ ") And dbo.SecForm.TypeC=" + Type.ToString());

                }
                else
                {
                    Jdb.setQuery("SELECT      dbo.SecForm.Code,dbo.vContracts.Asset,dbo.SecForm.LetterNumber, " + JDataBase.SQLMiladiToShamsi("dbo.SecForm.DateC", "Date") + "," + JDataBase.SQLMiladiToShamsi("dbo.SecForm.DateCreate", "DateCreate") + ", dbo.subdefine.name As Subject, dbo.SecForm.Discription, " +
                      "dbo.clsAllPerson.Name AS Motkhalef, dbo.users.username As Usercreator,dbo.SecForm.ContractCode,dbo.clsAllPerson.Code As PersonCode " +
"FROM         dbo.SecForm INNER JOIN  dbo.subdefine ON dbo.SecForm.Subject = dbo.subdefine.Code INNER JOIN " +
                      "dbo.clsAllPerson ON dbo.SecForm.PersonCode = dbo.clsAllPerson.Code INNER JOIN " +
                      "dbo.users ON dbo.SecForm.UserCreate = dbo.users.code INNER JOIN dbo.vContracts ON dbo.SecForm.ContractCode = dbo.vContracts.Code Where (dbo.vContracts.FinanceCode=" + Asset.Code.ToString()+" OR dbo.clsAllPerson.Code="+Person.Code+ ") AND dbo.vContracts.Status=1 " + " And dbo.SecForm.TypeC=" + Type.ToString());

                }
                return Jdb.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                Jdb.Dispose();
            }
        }

    }
}
