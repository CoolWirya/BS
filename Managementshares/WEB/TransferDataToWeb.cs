using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using System.Security.Cryptography;
using System.IO;
using System.Security;
using System.Runtime.InteropServices;

namespace ManagementShares
{
    public partial class JTransferDataToWeb : Globals.JBaseForm
    {
        public JTransferDataToWeb()
        {
            InitializeComponent();
        }

        private string ExecSQLSaham(string pSQl)
        {
            JDataBase Db = JGlobal.MainFrame.GetSharesDB();
            try
            {
                Db.setQuery(pSQl);
                if (Db.Query_ExecutSacler() != null)
                    return Db.Query_ExecutSacler().ToString();
                else
                    return "";
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        private DataTable GetDataChange()
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery("Select * from  ChangeDataSaham");
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        private void DeleteDataChange(int pCode,string pTableName)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            try
            {
                Db.setQuery("Delete from ChangeDataSaham Where Code= " + pCode + " And TableName='" + pTableName+"'");
                Db.Query_ExecutSacler();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                Db.Dispose();
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            JSahamPerson Saham = new JSahamPerson();
            DataTable DtChangeSaham = GetDataChange();
            string Query = "";
            bool Flag = true;
            JWebUserChanges tmpWebUserChanges = new JWebUserChanges();
            if (DtChangeSaham != null)
            {
                progressBar1.Maximum = DtChangeSaham.Columns.Count;
                for (int i = 0; i < DtChangeSaham.Rows.Count; i++)
                {
                    progressBar1.Value = i;

                    UsersSite(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), JSahamPerson.ExecScalar("select Name from Sepad.OtherPerson Where Code=" + DtChangeSaham.Rows[i]["Code"].ToString()), JSahamPerson.ExecScalar("select ShSh from Sepad.OtherPerson Where Code=" + DtChangeSaham.Rows[i]["Code"].ToString()));
                    if (DtChangeSaham.Rows[i]["TableName"].ToString() == "OtherPerson")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = OtherPerson(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = OtherPerson(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    else if (DtChangeSaham.Rows[i]["TableName"].ToString() == "Sheet")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = Sheet(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = Sheet(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    else if (DtChangeSaham.Rows[i]["TableName"].ToString() == "Vokala")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = Vokala(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = Vokala(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    else if (DtChangeSaham.Rows[i]["TableName"].ToString() == "Cities")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = Cities(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = Cities(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    else if (DtChangeSaham.Rows[i]["TableName"].ToString() == "sahampayment")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = sahampayment(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = sahampayment(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    else if (DtChangeSaham.Rows[i]["TableName"].ToString() == "VarPropertyPerson")
                    {
                        if (DtChangeSaham.Rows[i]["Event"].ToString() != "Delete")
                            Flag = VarPropertyPerson(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), false);
                        else
                            Flag = VarPropertyPerson(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), true);
                    }
                    if (Flag)
                        //if (tmpWebUserChanges.ExecSQL(Query))
                       DeleteDataChange(Convert.ToInt32(DtChangeSaham.Rows[i]["Code"]), DtChangeSaham.Rows[i]["TableName"].ToString());
                }
            }
        }
        /// <summary>
        /// اشخاص
        /// </summary>
        /// <returns></returns>
        private bool OtherPerson(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"
                Select Isnull(CAST(Code as varchar(10))
+'"",""'+   Case Name When '' then '0' else Name end 
+'"",""'+   Case Fam When '' then '0' else Fam end 
+'"",""'+   Case FatherName When '' then '0' else FatherName end 
+'"",""'+   Case ShSh When '' then '0' else ShSh end 
+'"",""'+   Case ShMeli When '' then '0' else ShMeli end 
+'"",""'+   CAST( Sader as varchar(10))
+'"",""'+   Case BthDate  When '' then '0' else BthDate  end 
+'"",""'+   CAST( Sex as varchar(10))
+'"",""'+   CAST( Maried  as varchar(10)) 
+'"",""'+   CAST( Child as varchar(10))
+'"",""'+   CAST( Suport as varchar(10)) 
+'"",""'+   Case MAddress  When '' then '0' else MAddress  end 
+'"",""'+   Case MTell  When '' then '0' else MTell  end 
+'"",""'+   CAST( MCity as varchar(10)) 
+'"",""'+   Case PostCode  When '' then '0' else PostCode  end 
+'"",""'+   Case OAddress  When '' then '0' else OAddress  end 
+'"",""'+   Case OTell  When '' then '0' else OTell  end 
+'"",""'+   CAST( OCity as varchar(10)) 
+'"",""'+   Case Mobile  When '' then '0' else Mobile  end 
+'"",""'+   CAST(  Block as varchar(10)) 
+'"",""'+   CAST(  Die as varchar(10)),'') from Sepad.OtherPerson Where Code=" + id) + "\"";
            tmp.ExecSQL(" DELETE FROM zarrinde_sepad.jos_saham_persons WHERE jos_saham_persons.code ='" + id + "'");
            //tmp.ExecSQL("DELETE FROM jos_saham_persons WHERE  id=\"" + id + "\"");//edited = 0 And
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"INSERT INTO jos_saham_persons (`code`, `name`, `fam`, `father_name`, `sh_sh`, `sh_meli`, `sader`, `bth_day`, `sex`, `maried`, `child`, 
						 `Suport`, `m_address`, `m_tell`, `m_city`, `post_code`, `o_address`, `o_tell`, `o_city`, `mobile`, `block`, `death` ) VALUES
					(" + DataSaham + ")"))
                    return true;
            return false;
        }
        /// <summary>
        /// برگه
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pFlagDel"></param>
        /// <returns></returns>
        private bool Sheet(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"              
Select  Cast(Code as varchar(10))
+'"",""'+  Cast(PCode as varchar(10))  
+'"",""'+  Cast(Status as varchar(10)) 
+'"",""'+  Cast(DeActive as varchar(10)) 
+'"",""'+  Cast(SumSahm as varchar(10))  
+'"",""'+  Cast(Az as varchar(10))  
+'"",""'+  Cast(Ela as varchar(10)) 
+'"",""'+  isnull(Cast(Vakil as varchar(10)), '')  from Sepad.Sheet
   Where Code=" + id) + "\"";
            tmp.ExecSQL("DELETE FROM jos_saham_sheets WHERE code=" + id);
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"INSERT INTO jos_saham_sheets (`code`, `pcode`, `status`, `deactive`, `sum_saham`, `az`, `ela`, `vakil`) VALUES	
					(" + DataSaham + ")"))
                    return true;
            return false;
        }

        /// <summary>
        /// وکلا
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pFlagDel"></param>
        /// <returns></returns>
        private bool Vokala(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"
Select Cast( Code as varchar(10))          
+'"",""'+  Cast(VCode as varchar(10))
+'"",""'+  Cast(VBDate as varchar(10))
+'"",""'+  Cast(VEDate as varchar(10))
+'"",""'+  Cast(DeActive as varchar(10)) 
    from Sepad.Vokala Where Code=" + id) + "\"";
            tmp.ExecSQL("DELETE FROM jos_saham_vokala WHERE code=" + id);
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"
INSERT INTO jos_saham_vokala (`code` ,`vcode` ,`vb_date` ,`ve_date` ,`deactive`) VALUES
					(" + DataSaham + ")"))
                    return true;
            return false;
        }
        /// <summary>
        /// شهرها
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pFlagDel"></param>
        /// <returns></returns>
        private bool Cities(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"
Select Cast(Code as varchar(10)) 
+'"",""'+ City   
    from General.Cities Where Code=" + id) + "\"";
            tmp.ExecSQL("DELETE FROM jos_saham_cities WHERE code=" + id);
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"INSERT INTO jos_saham_cities (`code`, `city`) VALUES
					(" + DataSaham + ")"))
                    return true;
            return false;
        }
        /// <summary>
        /// سود سهام
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pFlagDel"></param>
        /// <returns></returns>
        private bool sahampayment(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"
  Select Cast( Code as varchar(10))          
+'"",""'+  CAST((Select finyear  from ERP_Sepad.dbo.sahamcourse where code  = coursecode)   as nvarchar(10))
+'"",""'+  paydate 
+'"",""'+  CAST(SUM(paycost) as nvarchar(10))
    from ERP_Sepad.dbo.sahampayment Where Code=" + id + " group by pcode ,coursecode , paydate") + "\"";
            tmp.ExecSQL("DELETE FROM jos_saham_payments WHERE edited = 0 And id=" + id);
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"
INSERT INTO jos_saham_payments (`code` ,`vcode` ,`vb_date` ,`ve_date` ,`deactive`) VALUES
					(" + DataSaham + ")"))
                    return true;
            return false;
        }

        /// <summary>
        /// ویژگی ها
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pFlagDel"></param>
        /// <returns></returns>
        private bool VarPropertyPerson(int id, bool pFlagDel)
        {
            JWebUserChanges tmp = new JWebUserChanges();
            string DataSaham = "\"" + ExecSQLSaham(@"
 Select Distinct  CAST(OP.Code as nvarchar(10))         
+'"",""'+  CAST(isNull((Select Data From General.VarPropertyPerson Where PCode = VP.PCode and VPCode = 1 ) , 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select Data From General.VarPropertyPerson Where PCode = VP.PCode and VPCode = 2 ), 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select Data From General.VarPropertyPerson Where PCode = VP.PCode and VPCode = 5 ) , 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(6,7,18) ) , 0) as nvarchar(20)) 
+'"",""'+  CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(1,2,3,4,5) ) , 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(8) ) , 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(9) ) , 0) as nvarchar(20))
+'"",""'+  CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(11,12,13,14,15,17) ) , 0) as nvarchar(20))
     From General.VarPropertyPerson VP Right join Sepad.OtherPerson OP on VP.PCode = OP.Code Where Code=" + id) + "\"";
            tmp.ExecSQL("DELETE FROM jos_saham_person_properties WHERE edited = 0 And code=" + id);
            if (!(pFlagDel))
                if (tmp.ExecSQL(@"INSERT INTO jos_saham_person_properties (`code`, `personnel_code`, `percent`, `fax`, `status`, `reason`, `janbaz`, `azadeh`, `education` ) VALUES
                        (" + DataSaham + ")"))
                    return true;
            return false;
        }

        /// <summary>
        /// کاربران
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private bool UsersSite(int id, string pName, string pSH)
        {
            try
            {
                //byte[] resultArray;
                JWebUserChanges tmp = new JWebUserChanges();
                int idmax = Convert.ToInt32(tmp.ExecSQLD(@"Select Max(id) From jos_users ").Rows[0][0].ToString());
                string Password;
                if (id > idmax)
                {
                    Password = GenRandomPassword();                    
                    string encrypt = MD5(pSH + Password);
                    Password = encrypt + ":" + Password;
                    tmp.ExecSQL(@"INSERT INTO jos_users (`id`,`name`, `username`, `password`, `email`, `usertype`, `block`, `gid`) VALUES
(""\" + id + "\",\"" + pName + "\",\"" + id + "\",\"" + Password + "\",\" u@sepad.org \", \"Registered \", \" 0 \", \" 18 \")");

                    tmp.ExecSQL(@"INSERT INTO jos_core_acl_aro (`section_value`, `value`) VALUES
						('users', '" + id + "')");

                    idmax = Convert.ToInt32(tmp.ExecSQLD(@"Select Max(Id) From jos_core_acl_aro ").Rows[0][0].ToString());

                    tmp.ExecSQL(@"INSERT INTO jos_core_acl_groups_aro_map (`group_id`, `aro_id`) VALUES('18', '" + idmax + "')");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static string MD5(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        // generate --- salt --
		private string GenRandomPassword()
		{
            Random tmpRand = new Random(25);
            string Pass="";
			string salt = "abcdefghijklmnopqrstuvwxyz";		
			for (int i = 0; i < 32; i ++)             
                Pass = Pass + salt[tmpRand.Next(0,25)];		
			return Pass;
		}

    }
}
