using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ManagementShares
{
    public class JSahamPerson : JSystem
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Fam { get; set; }
        public string FatherName { get; set; }
        public string ShSh { get; set; }
        public string ShMeli { get; set; }
        public int Sader { get; set; }
        public string BthDate { get; set; }
        public bool Sex { get; set; }
        public bool Maried { get; set; }
        public int Child { get; set; }
        public int Suport { get; set; }
        public string MAddress { get; set; }
        public string MTell { get; set; }
        public int MCity { get; set; }
        public string PostCode { get; set; }
        public string OAddress { get; set; }
        public string OTell { get; set; }
        public string OCity { get; set; }
        public string Mobile { get; set; }
        public bool Block { get; set; }
        public bool Die { get; set; }
        public ShareHolder.JPropertiesStatic[] PropertiesStatic;
        public ShareHolder.JPropertiesVar[] PropertiesVar;

        public JSahamPerson()
        {
            PropertiesStatic = new ManagementShares.ShareHolder.JPropertiesStatic[0];
            PropertiesVar = new ManagementShares.ShareHolder.JPropertiesVar[0];
        }

        public bool Update()
        {
            //JDataBase db = JGlobal.MainFrame.GetSharesDB();
            JDataBase db = new JDataBase();
            try
            {
                string Sql = "";
                Sql=@"Update clsperson Set 
                ShSh = '" + ShSh + @"',
                ShMeli = '" + ShMeli + @"'                
                WHERE [Code] = " + Code.ToString();

                Sql=Sql + @" Update clsPersonAddress Set 
                Address = '" + MAddress + @"',
                Tel = '" + MTell + @"',
                City = " + MCity + @",                
                Mobile = '" + Mobile + @"'                
                WHERE AddressType=1 And PCode = " + Code.ToString();

                Sql=Sql + @" Update clsPersonAddress Set 
                Address = '" + OAddress + @"',
                Tel = '" + OTell + @"',
                City = " + OCity + @",
                Mobile = '" + Mobile + @"'                
                WHERE AddressType=2 And PCode = " + Code.ToString();

                db.setQuery(Sql);

//                db.setQuery("Update " + JTableNamesShares.OtherPerson + @" Set 
//                Name = '" + Name + @"',
//                Fam = '" + Fam + @"',
//                FatherName = '" + FatherName + @"',
//                ShSh = '" + ShSh + @"',
//                ShMeli = '" + ShMeli + @"',
//                Sader = '" + Sader + @"',
//                BthDate = '" + BthDate + @"',
//                Sex = " + Sex + @",
//                Maried = " + Maried + @",
//                Child = " + Child + @",
//                Suport = " + Suport + @",
//                MAddress = '" + MAddress + @"',
//                MTell = '" + MTell + @"',
//                MCity = " + MCity + @",
//                PostCode = " + PostCode + @",
//                OAddress = '" + OAddress + @"',
//                OTell = '" + OTell + @"',
//                OCity = " + OCity + @",
//                Mobile = '" + Mobile + @"',
//                Block = " + Block + @",
//                Die = " + Die + @"
//                WHERE [Code] = " + Code.ToString());
                
                if (db.Query_Execute() >= 0)
                {
                    //JWebUserChanges tmpJWebUserChanges = new JWebUserChanges();
                    //if(tmpJWebUserChanges.Update(Code))
                        return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT * FROM " + JTableNamesShares.OtherPerson + " WHERE [Code] = " + pCode.ToString());
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public DataTable GetDataTable(int pCode)
        {
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery(@"SELECT  
  a.Code,
  a.Name,
  a.Fam as 'Fam',
  a.FatherName as 'FatherName',
  a.ShSh as 'ShSh',
  a.ShMeli as 'ShMeli',
  a.Sader,
  a.BthDate as 'BthDate',
  a.Sex,  
--case a.Sex 
--when 0 then 'مرد'
--when 1 then 'زن'
--end 'جنسیت',
a.Maried,
--case a.Maried 
--when 0 then 'بلی'
--when 1 then 'خیر'
--end 'متاهل',
  a.Child,
  a.Suport,
--case a.Suport 
--when 0 then 'بلی'
--when 1 then 'خیر'
--end 'سرپرست خانواده',
  a.MAddress as 'Maddress',
  a.MTell as 'mTell',
  a.MCity as 'mCity',
  a.PostCode as 'PostCode',
  a.OAddress as 'OAddress',
  a.OTell as 'OTell',
  a.OCity as 'OCity',
  a.Mobile,  
  a.Block,
--case a.Block 
--when 0 then 'بلوکه نشده'
--when 1 then 'بلوکه شده'
--end 'وضعیت شخص',
  a.Die as 'Die'
" + ShareHolder.JPropertiesVar.GetSQL("a") + @"
" + ShareHolder.JPropertiesStatic.GetSQL("a") + @"
 FROM " + JTableNamesShares.OtherPerson + " a WHERE [Code] = " + pCode.ToString());
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static DataTable GetNames()
        { 
            JDataBase db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                db.setQuery("SELECT Code, Name+' '+Fam+' - ش ش:' + ShSh+' ف: '+FatherName NameFam FROM " + JTableNamesShares.OtherPerson);
                return db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool UpdateProperty()
        {
            foreach (ShareHolder.JPropertiesStatic PS in PropertiesStatic)
            {
                PS.Insert();
            }
            foreach (ShareHolder.JPropertiesVar PV in PropertiesVar)
            {
                PV.Insert();
            }
            return true;
        }

        public void AddPersonStatic(int pPrptTitleCode, int pPrsnCode, int pPrptCode)
        {
            Array.Resize(ref PropertiesStatic, PropertiesStatic.Length + 1);
            PropertiesStatic[PropertiesStatic.Length - 1] = new ManagementShares.ShareHolder.JPropertiesStatic();
            PropertiesStatic[PropertiesStatic.Length - 1].PrptTitleCode = pPrptTitleCode;
            PropertiesStatic[PropertiesStatic.Length - 1].PrsnCode = pPrsnCode;
            PropertiesStatic[PropertiesStatic.Length - 1].PrptCode = pPrptCode;
        }

        public void AddPersonVar(int pPCode, int pVPCode, string pData)
        {
            Array.Resize(ref PropertiesVar, PropertiesVar.Length + 1);
            PropertiesVar[PropertiesVar.Length - 1] = new ManagementShares.ShareHolder.JPropertiesVar();
            PropertiesVar[PropertiesVar.Length - 1].PCode = pPCode;
            PropertiesVar[PropertiesVar.Length - 1].VPCode = pVPCode;
            PropertiesVar[PropertiesVar.Length - 1].Data = pData;
        }
    }
}
