using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ManagementShares
{
    public class JSQLViews : ClassLibrary.JSQLViews
    {
        /// <summary>
        /// جدول برگه سهم
        /// </summary>

        public static string OtherPerson = @" SELECT    [Code] AS PCode ,[Name]  ,[Fam]  ,[FatherName]  ,[ShSh]  ,[ShMeli]  ,[Sader]  ,[BthDate]
                      ,[Sex]  ,[Maried]  ,[Child]  ,[Suport]  ,[MAddress]  ,[MTell]  ,[MCity]  ,[PostCode]
                      ,[OAddress]  ,[OTell]  ,[OCity]  ,[Mobile]  ,[Block]  ,[Die]  , Name+' '+Fam AS NameFam FROM " + ClassLibrary.JGlobal.MainFrame.GetConfig().DatabaseSaham + "." + ClassLibrary.JGlobal.MainFrame.GetConfig().PersonSahamTableName;

        /// <summary>
        /// الحاق جداول اشخاص و برگه های سهم
        /// </summary>
//        public static string PersonSheet = @" SELECT OP.[PCode] ,  [Name]  ,[Fam] 
//    	,OP.[FatherName] ,OP.[ShSh] ,OP.[ShMeli] ,OP.[Sader] ,OP.[BthDate] ,OP.[Sex] ,OP.[Maried] ,OP.[Child] ,OP.[Suport] ,OP.[MAddress]
//	    ,OP.[MTell] ,OP.[MCity] ,OP.[PostCode] ,OP.[OAddress] ,OP.[OTell] ,OP.[OCity] ,OP.[Mobile] ,OP.[Block] ,OP.[Die] " +
//        ", Sheets.Code SheetNo , Sheets.Az, Sheets.Ela , Sheets.Ela - Sheets.Az +1 AS SumSahm, DeActive "+
//          "  FROM (" + OtherPerson + @" ) AS OP
//	        INNER JOIN (" + JSheet.Query + ") AS Sheets ON OP.PCode = Sheets.PCode ";
    }
}