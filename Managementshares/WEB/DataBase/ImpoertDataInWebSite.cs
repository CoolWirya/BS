using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares.DataBase
{
    public class JImpoertDataInWebSite
    {
        public JImpoertDataInWebSite()
        {
            System.Xml.XmlTextReader x = new System.Xml.XmlTextReader("XMLFileImportShareSQL.xml");
        }

        private void SQL()
        {
            string _SQL = @"
-------------- اشخاص
--Select (CHAR(13)+CHAR(10))  union all
Select CAST(Code as varchar(10))
+'"",""'+   Case Name When '' then '0' else Name end 
+'"",""'+   Case Fam When '' then '0' else Fam end 
+'"",""'+   Case FatherName When '' then '0' else FatherName end 
+'"",""'+   Case ShSh When '' then '0' else ShSh end 
+'"",""'+   Case ShMeli When '' then '0' else ShMeli end 
+'"",""'+ CAST( Sader as varchar(10))
+'"",""'+ Case BthDate  When '' then '0' else BthDate  end 
+'"",""'+ CAST( Sex as varchar(10))
+'"",""'+  CAST( Maried  as varchar(10)) 
+'"",""'+ CAST( Child as varchar(10))
+'"",""'+ CAST( Suport as varchar(10)) 
+'"",""'+ Case MAddress  When '' then '0' else MAddress  end 
+'"",""'+ Case MTell  When '' then '0' else MTell  end 
+'"",""'+ CAST( MCity as varchar(10)) 
+'"",""'+   Case PostCode  When '' then '0' else PostCode  end 
+'"",""'+   Case OAddress  When '' then '0' else OAddress  end 
+'"",""'+   Case OTell  When '' then '0' else OTell  end 
+'"",""'+ CAST( OCity as varchar(10)) 
+'"",""'+   Case Mobile  When '' then '0' else Mobile  end 
+'"",""'+  CAST(  Block as varchar(10)) 
+'"",""'+  CAST(  Die as varchar(10)) from Sepad.OtherPerson
--id 	code 	name 	fam 	father_name 	sh_sh 	sh_meli 	sader 	bth_day 	sex 	maried 	child 	Suport 	m_address 	m_tell 	m_city 	post_code 	o_address 	o_tell 	o_city 	mobile
";

            string _temp = "";
            string _Sep = "";
        ClassLibrary.JDataBase DB =  ClassLibrary.JGlobal.MainFrame.GetSharesDB();
        DB.setQuery(_SQL);
        System.Data.DataTable DT = DB.Query_DataTable();
        foreach (System.Data.DataRow DR in DT.Rows)
        {
            _temp += _Sep + DR[0].ToString();
            _Sep = ",";
        }


/*
------- برگه  
 Select (CHAR(13)+CHAR(10))  union all
Select Cast(Code as varchar(10))+'"",""'+
Cast(PCode as varchar(10))  +'"",""'+
Cast(Status as varchar(10)) +'"",""'+
Cast(DeActive as varchar(10)) +'"",""'+
Cast(SumSahm as varchar(10))  +'"",""'+
Cast(Az as varchar(10))  +'"",""'+
Cast(Ela as varchar(10)) +'"",""'+
Cast(Vakil as varchar(10))  from Sepad.Sheet 
--	code 	pcode 	status 	deactive 	sum_saham 	az 	ela 	vakil

--------- وکلا
Select (CHAR(13)+CHAR(10))  union all
Select Cast( Code as varchar(10))+'"",""'+
 Cast(VCode as varchar(10))+'"",""'+
 Cast(VBDate as varchar(10))+'"",""'+
 Cast(VEDate as varchar(10))+'"",""'+
 Cast(DeActive as varchar(10)) from Sepad.Vokala

---------- شهرها
Select (CHAR(13)+CHAR(10))  union all
Select  
Cast(Code as varchar(10)) +'"",""'+ City  from General.Cities

----------- کاربران
Select (CHAR(13)+CHAR(10))  union all
Select CAST(Code as nvarchar(10)) +'"",""'+    Name+' '+ Fam +'"",""'+   CAST ( Code as nvarchar(10))+'"",""'+    ShSh   from newsahamdatabase.Sepad.OtherPerson 

----------- سود سهام
Select (CHAR(13)+CHAR(10))  union all
Select CAST(pcode as nvarchar(10))+'"",""'+  
CAST((Select finyear  from ERP_Sepad.dbo.sahamcourse where code  = coursecode)   as nvarchar(10))
+'"",""'+    paydate +'"",""'+    CAST(SUM(paycost) as nvarchar(10))
  from ERP_Sepad.dbo. sahampayment group by pcode ,coursecode , paydate 
  --order by pcode , pyear , paid_date 

---- ویژگی ها
 -- Code, Pasdari, PercentJanbazi , Fax, Status-Pasdari, Reason (SharayetSahamdarshdan), Janbaz (Yes/-) , Azade (Yes, -), Education
 Select (CHAR(13)+CHAR(10))  union all
 Select Distinct  CAST(OP.Code as nvarchar(10))+'"",""'+
 CAST(isNull((Select Data From General .VarPropertyPerson Where PCode = VP.PCode and VPCode = 1 ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select Data From General .VarPropertyPerson Where PCode = VP.PCode and VPCode = 2 ), 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select Data From General .VarPropertyPerson Where PCode = VP.PCode and VPCode = 5 ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(6,7,18) ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(1,2,3,4,5) ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(8) ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(9) ) , 0) as nvarchar(20))
 +'"",""'+CAST(isNull((Select PrptCode  From General.PersonProperty  Where PrsnCode = VP.PCode and  PrptCode IN(11,12,13,14,15,17) ) , 0) as nvarchar(20))
  from General .VarPropertyPerson VP Right join Sepad.OtherPerson OP on VP.PCode = OP.Code
 */
        }
        private void CreateSQL()
        {
        }


    }
}
