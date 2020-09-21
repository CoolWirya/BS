using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClassLibrary;
using Automation;
using System.Runtime.Serialization;

namespace WebAutomation
{
    [Serializable]
    public class JARefer
    {

        #region Constructor
        public JARefer()
        {
        }
        #endregion

        public JARefer(SerializationInfo info, StreamingContext ctxt)
        {

        }
        //Serialization function.
        public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
        {

        }

        public static string GetInbox()
        {
            return WebAutomation.JARefer.GetInbox(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode, null, 0);
        }

        public static string GetInbox(int pPost_Code, string[] NotIn, int IN)
        {
            string Where = "";
            if (JMainFrame.Successor)
                Where = " And " + JPermission.getObjectSql("Automation.JARefers.GetReferInInbox", "cast(HashBytes('MD5',LOWER(ClassName)+CAST(DynamicClassCode as varchar)) as int)");
            string _SQL = @"SELECT top 100 percent R.Code,o.objectcode, (select Letter_No from letters l where l.code = O.objectcode ) Letter_No, ClassName,
                    CASE ISNULL(view_date_time, 0) 
                        WHEN '1900-01-01 00:00:00.000' THEN CAST('<img src=''" + WebClassLibrary.JDomains.Images.ControlImages.MailNewUnread + @"''/>' as varchar(100)) 
                        ELSE CAST('<img src=''" + WebClassLibrary.JDomains.Images.ControlImages.MailRead + @"''/>' as varchar(100))
                        END as 'خوانده شده',
                    CASE WHEN O.ClassName = 'Communication.JCLetter' THEN (Select N'نامه داخلی: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCImportedLetter' THEN (Select N'نامه وارده: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'Communication.JCExportedLetter' THEN (Select N'نامه صادره: '  + (l.[subject] COLLATE DATABASE_DEFAULT) as Title From Letters l Where l.Code = O.ObjectCode)
                    WHEN O.ClassName = 'WebOilManagement.JWebFailure' THEN (Select N'فرم خرابی: '  + CAST(o.ObjectCode AS NVARCHAR(20)) as Title)
                    ELSE O.Title END [Title],
                    View_date_Time,
                    (Select Fa_Date from StaticDates where En_Date = Cast(R.Send_Date_time as date))+ '<br/>' +CONVERT(varchar,convert(time(0),send_date_time)) AS 'Send_Date_time',
                    R.sender_full_title as 'Refer_full_title',
                    case urgency
                        when 1 Then 'عادی'
                        when 2 Then 'سریع'
                        when 3 Then 'خیلی سریع'
                        end 'فوریت'
                    FROM " + JTableNamesAutomation.Refer + " R INNER JOIN " +
                            JTableNamesAutomation.Objects + " O "
                + " ON R." + ClassLibrary.Refer.object_code + "= O.Code WHERE R." + ClassLibrary.Refer.receiver_post_code + "=" + pPost_Code
                + " AND " + ClassLibrary.Refer.status + "=" + (int)ClassLibrary.Domains.JAutomation.JReferStatus.Current
                + Where;
            if (IN == 0)
                _SQL += " AND R.Code NOT IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + JAFolderTypeEnum.Inbox.GetHashCode().ToString() + ") AND PostCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode.ToString() + ")";
            else
                _SQL += " AND R.Code IN( SELECT referCode FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + JAFolderTypeEnum.Inbox.GetHashCode().ToString() + ") AND PostCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode.ToString() + "AND ReferFolders.ReferFolderCode =" + IN.ToString() + ")";
            if (NotIn != null && NotIn.Length > 0)
            {
                _SQL += " AND R.Code Not IN (" + String.Join(",", NotIn) + ") ";
            }
            _SQL += @" AND 
					R.Code Not IN (SELECT rs.parent_code From Refer rs
							INNER JOIN Objects O  ON rs.object_code= O.Code WHERE
					
							 rs.parent_code IS NOT NULL
					 )  ";

            //_SQL = _SQL + "ORDER BY Send_Date_time DESC ";
            return _SQL;
        }

        public static string GetOutbox()
        {
            return WebAutomation.JARefer.GetOutbox(WebClassLibrary.SessionManager.Current.MainFrame.CurrentPostCode, 0, null, 0);
        }

        public static string GetOutbox(int pPost_Code, int pCode, string[] NotIn, int IN)
        {

            string Where = "";
            if (JMainFrame.Successor)
                Where = " And " + JPermission.getObjectSql("Automation.JARefers.GetReferInInbox", "cast(HashBytes('MD5',LOWER(ClassName)+CAST(DynamicClassCode as varchar)) as int)");

            string _SQL = @"SELECT top 100 percent  
            R.Code code,
            O.Code OCode,
            (select Letter_No from letters l where l.code = O.objectcode ) Letter_No,
            O. ClassName, O.ObjectCode, O.DynamicClassCode,
            O.action,
            CASE WHEN (O.ClassName = 'Communication.JCLetter' OR O.ClassName = 'Communication.JCImportedLetter') THEN (Select (CASE l.letter_type WHEN 1 THEN N'نامه وارده: ' + (l.[subject] COLLATE DATABASE_DEFAULT) WHEN 3 THEN N'نامه داخلی: ' + (l.[subject] COLLATE DATABASE_DEFAULT) END) as Title From Letters l Where l.Code = O.ObjectCode) 
            ELSE O.Title END [Title],
            O.sender_full_title as 'از',            
            R.Receiver_full_title as 'به',
            (Select Fa_Date from StaticDates where En_Date = cast(R.Send_Date_time as date))+'---'+CONVERT(varchar,convert(time(0),send_date_time)) AS 'Send_Date_time',
            (Select Fa_Date from StaticDates where En_Date = Cast(R.respite_date_Time as date))+'---'+CONVERT(varchar,convert(time(0),respite_date_Time)) AS 'respite_date_Time',
            DescriptionObject,
            case [status]
            when 1 Then 'جاری'
            when 2 Then 'ارسال شده'
            when 3 Then 'ابطال شده'
            when 4 Then 'تمام شده'
            end 'status',
            case secret_level
            when 1 Then 'عادی'
            when 2 Then 'محرمانه'
            when 3 Then 'سری'
            end 'secret_level',
            case urgency
            when 1 Then 'عادی'
            when 2 Then 'سریع'
            when 3 Then 'خیلی سریع'
            end 'فوریت',
            (Select Fa_Date from StaticDates where En_Date = Cast(R.View_date_Time as date))+'---'+CONVERT(varchar,convert(time(0),respite_date_Time)) 'View_date_Time',
            case urgency
            when 0 Then 'غیرفعال'
            when 1 Then 'فعال'
            end 'Active',
            R.response,
            R.response_secret,
            R.description
            FROM " + ClassLibrary.JTableNamesAutomation.Refer + " R INNER JOIN " +
            ClassLibrary.JTableNamesAutomation.Objects + " O ON R." + ClassLibrary.Refer.object_code + "= O.Code ";

            if (pCode == 0)
            {
                _SQL += "WHERE R." + ClassLibrary.Refer.sender_post_code + "=" + pPost_Code;
            }
            else
                if (pCode > 0)
                {
                    _SQL += " WHERE R.Code = " + pCode.ToString();
                }


            if (NotIn != null && NotIn.Length > 0)
            {
                _SQL += " AND R.Code Not IN (" + String.Join(",", NotIn) + ")";
            }

            if (IN == 0)
                _SQL += " AND R.Code NOT IN( SELECT referCode FROM " + ClassLibrary.JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + Automation.JAFolderTypeEnum.SendItem.GetHashCode().ToString() + ") AND PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + ")";
            else
                _SQL += " AND R.Code IN( SELECT referCode FROM " + ClassLibrary.JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode in (select Code from Folders where FolderType=" + Automation.JAFolderTypeEnum.SendItem.GetHashCode().ToString() + ") AND PostCode=" + ClassLibrary.JMainFrame.CurrentPostCode.ToString() + " AND ReferFolders.ReferFolderCode =" + IN.ToString() + ")";

            _SQL += Where + "  ORDER  BY R.Send_Date_time DESC ";
            return _SQL;

        }

        public List<WebControllers.MainControls.Menu.JMenuItem> GetInboxMenu(Telerik.Web.UI.GridDataItem param = null)
        {
            List<WebControllers.MainControls.Menu.JMenuItem> menus = new List<WebControllers.MainControls.Menu.JMenuItem>();
            WebControllers.MainControls.Menu.JMenuItem menu = new WebControllers.MainControls.Menu.JMenuItem();
            menu.Text = "Open";
            menu.ImageUrl = WebClassLibrary.JDomains.Images.ControlImages.Open;
            //menu.
            return null;
        }

        public static string GetSpecialInbox(string SpecialTable, string Query, string ClassName)
        {
            Query = "select  [خوانده شده],Code,[Title],View_date_Time,Send_Date_time,[Refer_full_title],[فوریت],t.*  from  (" + Query + ") s"
            + " Left join ( "
            + SpecialTable
            + @" )t 
					 on (s.objectcode = t.Master_Code)";
            Query += " where s.ClassName = '" + ClassName + "' ";

            return Query;
        }

      
        public static string GetSpecialInbox(string Query, string ClassName)
        {
            Query = "select  Code,[Title], Letter_No,View_date_Time,Send_Date_time,[Refer_full_title]  from  (" + Query + ") s";
            if (ClassName != string.Empty)
                Query += " where s.ClassName = '" + ClassName + "' ";
            return Query;
        }

        public static string GetSpecialOutbox(string SpecialTable, string Query, string ClassName)
        {
            if (SpecialTable != string.Empty)
            {
                Query = "SELECT  Code,[Title], Letter_No, View_date_Time,Send_Date_time,[از],[به],[فوریت],t.*  FROM  (" + Query + ") s";
                Query += " Left join ( ";
                Query += SpecialTable;
                Query += @" )t 
					 on (s.objectcode = t.Master_Code)";
                Query += " WHERE s.ClassName = '" + ClassName + "' ";
            }
            else
            {
                Query = "SELECT  Code,[Title], Letter_No,View_date_Time,Send_Date_time,[از],[به],[فوریت]  FROM  (" + Query + ") s";
                if (ClassName != string.Empty)
                    Query += " WHERE s.ClassName = '" + ClassName + "' ";
            }
            return Query;

        }

    }
}