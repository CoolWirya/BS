using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
 public  class jcontractpersonsearch
    {
     public static System.Data.DataTable GetActivePerson(string Txt,string MarketCode)
     {
         JDataBase jdb = new JDataBase();
     
         try
         {


             jdb.setQuery("Select " +
"(select Mobile from clsPersonAddress Where AddressType=1 And PCode=(Select top 1 PersonCode from LegPersonContract Where ContractSubjectCode=LegSubjectContract.Code And Type=9)) Mobile, " +
"(select Name from clsallPerson Where Code=(Select top 1 PersonCode from LegPersonContract Where ContractSubjectCode=LegSubjectContract.Code And Type=9)) Name ,(SELECT     Title         FROM          dbo.legContractDynamicTypes            WHERE      (Type = Code)) AS title, " +
"(select plaque from estUnitBuild Where Code=(Select  dbo.finAsset.ObjectCode from finAsset Where finAsset.Code=LegSubjectContract.FinanceCode )) Unitbuild " +

"from LegSubjectContract Where Status=1 And " +
"Type IN (SELECT Code From LegContractType WHERE ContractType IN " +
 "                       (Select Code From legContractDynamicTypes WHERE AssetTransferType = 2)) " +
"And FinanceCode not in " +
"(Select FinanceCode from LegSubjectContract Where Status=1 And " +
"Type IN (SELECT Code From LegContractType WHERE ContractType IN " +
"                        (Select Code From legContractDynamicTypes WHERE AssetTransferType = 3))) " +
"And     FinanceCode in  " +
"(select FA.Code from  " +
"finAsset FA " +
"inner join finAssetShare FAS on FA.Code=FAS.ACode And FAS.Status=1 " +
"inner join finAssetTransfer FAT on FAT.Code=FAS.TCode And FAT.OwnershipType=2 And FAT.ClassName='Legal.JSubjectContract'  " +
"inner join estUnitBuild UB on UB.Code=FAS.ACode where UB.plaque in ('0'" + Txt + ") And UB.Marketcode  in('0'" + MarketCode + ")) " +
"union all " +
"Select (select  Mobile  from clsPersonAddress Where AddressType=1 And PCode=(Select top 1 PersonCode from LegPersonContract Where ContractSubjectCode=LegSubjectContract.Code And Type=9)) Mobile , " +
"(select Name from clsallPerson Where Code=(Select top 1 PersonCode from LegPersonContract Where ContractSubjectCode=LegSubjectContract.Code And Type=9)) Name ,(SELECT     Title         FROM          dbo.legContractDynamicTypes            WHERE      (Type = Code)) AS title, " +
"(select plaque from estUnitBuild Where Code=(Select  dbo.finAsset.ObjectCode from finAsset Where finAsset.Code=LegSubjectContract.FinanceCode )) Unitbuild " +
"from LegSubjectContract Where Status=1 And " +
"Type IN (SELECT Code From LegContractType WHERE ContractType IN " +
"(Select Code From legContractDynamicTypes WHERE AssetTransferType = 3)) " +
"And     FinanceCode in " +
"(select FA.Code from " +
"finAsset FA " +
"inner join finAssetShare FAS on FA.Code=FAS.ACode And FAS.Status=1 " +
"inner join finAssetTransfer FAT on FAT.Code=FAS.TCode And FAT.OwnershipType=2 And FAT.ClassName='Legal.JSubjectContract' " +
"inner join estUnitBuild UB on UB.Code=FAS.ACode where  UB.plaque in ('0'" + Txt + ") And UB.Marketcode  in('0'" + MarketCode + ")) ");
             System.Data.DataTable DtMobile = jdb.Query_DataTable();
              return DtMobile;
         }
         catch
         {
             return null;
         }
         finally
         {
             jdb.Dispose();
         }
     }
     public static System.Data.DataTable QueryAssetPerson(string _query, Boolean AssetAdd, Boolean AddPerson,Boolean LinerPerson)
     {
         try
         {
             string PersonQuery = "";
             string MainPersondata = "";
             string MainpersonJoin = "";
             string QueryAssetJoin = " ";
             string QueryAsset = "";
            string QueryAssetEnviroment="";
            string QueryAssetjoinEnviroment = "";
             string svalue = "RealEstate.JUnitBuild";
             if (AddPerson == true)
             {
                 PersonQuery = ",VPersonContract.PersonTel,VPersonContract.PersonMobile,VPersonContract.PersonAddress";
             }
             if (AssetAdd == true)
             {


                 switch (svalue)
                 {
                     case "RealEstate.JUnitBuild":
                         QueryAsset = " ,dbo.estUnitBuild.Plaque,dbo.estMarketFloors.Name AS Address,dbo.estUnitBuild.Area, dbo.estUnitBuild.Balcon,(SELECT     STUFF ((SELECT     ' | ' + et.Tel " +
   "FROM          estUnitBuildTels et INNER JOIN   estUnitBuild eb ON et.UnitBuildCode = eb.Code   WHERE      eb.Code = dbo.estUnitBuild.Code FOR XML PATH('')), 1, 2, '')) As BuildTel";

                         QueryAssetEnviroment = ",dbo.ReEnviromentTable.NameEnviroment,dbo.estMarketFloors.Name AS Address,dbo.ReEnviromentTable.Area, '' AS Balcon " +
  ",'' As BuildTel, ";

                         break;
                     case "RealEstate.JEnviroment":
                         break;
                 }
             }

             QueryAssetJoin = @"  
inner join dbo.finAsset FAS ON FAS.Code = SC.FinanceCode
inner JOIN dbo.estUnitBuild ON FAS.ObjectCode = dbo.estUnitBuild.Code   AND FAS.ClassName='RealEstate.JUnitBuild'
INNER JOIN dbo.estMarketFloors ON dbo.estUnitBuild.FloorCode = dbo.estMarketFloors.Code ";
             QueryAssetjoinEnviroment=@" 
inner join dbo.finAsset FAS ON FAS.Code = SC.FinanceCode
inner join dbo.ReEnviromentTable ON FAS.ObjectCode = dbo.ReEnviromentTable.Code AND FAS.ClassName='RealEstate.JEnviroment'
INNER JOIN dbo.estMarketFloors ON dbo.ReEnviromentTable.CodeFloor = dbo.estMarketFloors.Code  ";
             if (LinerPerson == false)
             {
                 MainPersondata = " ,VPersonContract.Name As Tarfin,VPersonContract.MemberContract,VPersonContract.PersonCode ";
                 MainpersonJoin = " INNER JOIN dbo.VPersonContract ON SC.Code = dbo.VPersonContract.ContractSubjectCode ";
             }
             JDataBase db = new JDataBase();

             db.setQuery(@"SELECT     SC.Code,SC.Number, 
(select ISNULL(STUFF((select ' # ' +isnull((select Name from clsAllPerson where Code=dbo.VPersonContract.Code),'') 
 from LegSubjectContract SC2 
INNER JOIN dbo.VPersonContract ON SC2.Code = dbo.VPersonContract.ContractSubjectCode  And  dbo.VPersonContract.PersonType=2 
 where SC.Code=SC2.code FOR XML PATH('')), 1, 1, '' ),'') AS 'طرف اول')'طرف اول', 
 (select ISNULL(STUFF((select ' # ' +isnull((select Name from clsAllPerson where Code=dbo.VPersonContract.Code),'') 
 from LegSubjectContract SC2 
INNER JOIN dbo.VPersonContract ON SC2.Code = dbo.VPersonContract.ContractSubjectCode  And  dbo.VPersonContract.PersonType=1 
 where SC.Code=SC2.code FOR XML PATH('')), 1, 1, '' ),'') AS 'طرف دوم')'طرف دوم', 

                
                ISNull(SC.ContractTitle,'نا معلوم')As ContractTitle " + MainPersondata + " " + PersonQuery + ", DT.Title,   (SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_3 WHERE     (En_Date = Cast(SC.StartDate as Date))) AS StartDate " +
                                                    ",(SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_2 WHERE     (En_Date = Cast(SC.EndDate as Date))) AS EndDate,  (SELECT     Comment FROM         dbo.finAsset WHERE     (Code = SC.FinanceCode)) AS Asset " + QueryAsset +
                                                    ",(SELECT     name FROM         dbo.subdefine WHERE     (Code = SC.Job)) AS Job, CASE Sc.Status WHEN 0 THEN '' WHEN 1 THEN N'جاری' WHEN 2 THEN N'اتمام' WHEN 3 THEN N'فسخ شده' WHEN 4 THEN N'غیر فعال' ELSE '' END AS StatusTitle,SC.FinanceCode " +
                                                    "FROM         dbo.LegSubjectContract AS SC INNER JOIN dbo.LegContractType AS LT ON SC.Type = LT.Code INNER JOIN dbo.legContractDynamicTypes AS DT ON DT.Code = LT.ContractType  " + MainpersonJoin + " " + QueryAssetJoin + " " + _query +
             //
            " union all "+

" SELECT     SC.Code,SC.Number, \r\n" +
"(select ISNULL(STUFF((select ' # ' +isnull((select Name from clsAllPerson where Code=dbo.VPersonContract.Code),'')  \r\n" +
  " from LegSubjectContract SC2 \r\n" +
"INNER JOIN dbo.VPersonContract ON SC2.Code = dbo.VPersonContract.ContractSubjectCode  And  dbo.VPersonContract.PersonType=2 \r\n" +
 "where SC.Code=SC2.code FOR XML PATH('')), 1, 1, '' ),'') AS 'طرف اول')'طرف اول', \r\n" +
 "(select ISNULL(STUFF((select ' # ' +isnull((select Name from clsAllPerson where Code=dbo.VPersonContract.Code),'')  \r\n" +
 "from  "+
 "LegSubjectContract SC2 \r\n" +
"INNER JOIN dbo.VPersonContract ON SC2.Code = dbo.VPersonContract.ContractSubjectCode  And  dbo.VPersonContract.PersonType=1 \r\n" +
 "where SC.Code=SC2.code FOR XML PATH('')), 1, 1, '' ),'') AS 'طرف دوم')'طرف دوم',                \r\n " +
"ISNull(SC.ContractTitle,'نا معلوم')As ContractTitle  \r\n" + MainPersondata + PersonQuery + ",DT.Title,  \r\n" +
  "(SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_3 WHERE     (En_Date = Cast(SC.StartDate as Date))) AS StartDate , \r\n" +
  "(SELECT     Fa_Date FROM         dbo.StaticDates AS StaticDates_2 WHERE     (En_Date = Cast(SC.EndDate as Date))) AS EndDate,   \r\n" +
  "(SELECT     Comment FROM         dbo.finAsset WHERE     (Code = SC.FinanceCode)) AS Asset   \r\n" +
  
   QueryAssetEnviroment+
   
  " (SELECT     name FROM         dbo.subdefine WHERE    "+
   "(Code = SC.Job)) AS Job "+
  ",CASE Sc.Status WHEN 0 THEN '' WHEN 1 THEN N'جاری' WHEN 2 THEN N'اتمام' WHEN 3 THEN N'فسخ شده' WHEN 4 THEN N'غیر فعال' ELSE '' END  "+
  "AS StatusTitle,SC.FinanceCode "+
    "FROM dbo.LegSubjectContract AS SC INNER JOIN dbo.LegContractType AS LT ON SC.Type = LT.Code INNER JOIN dbo.legContractDynamicTypes AS DT ON DT.Code = LT.ContractType " + MainpersonJoin + 
  QueryAssetjoinEnviroment+
 _query.Replace("dbo.estUnitBuild.MarketCode","dbo.ReEnviromentTable.Complex"));
 
             return db.Query_DataTable();
         }
         catch
         {

             return null;
         }
     }

    }
}
