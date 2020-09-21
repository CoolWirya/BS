using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using WebClassLibrary;
using WebControllers.MainControls.Date;

namespace WebAutomation.WebCommunication
{
    public partial class JLetterSearchControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public bool FullLetterSearchPermission()
        {
            if (JPermission.CheckPermission("Communication.Letter.FullLetterSearchPermission", false))
                return true;
            return false;
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string where = "( 1=1 ";
            if (LetterNoTextBox.Text.Trim() != ""  || SenderTextBox.Text=="" || SubjectTextBox.Text!="" || ReceiverTextBox.Text=="" || LetterTextTextBox.Text=="" || SearchInReferCheckBox.Checked==false  ) where += //"AND [letter_no] like N'%" + LetterNoTextBox.Text + "%' ";
            "AND ([letter_no] like N'%" + LetterNoTextBox.Text + "%' " +
                " OR [incoming_no] like N'%" + LetterNoTextBox.Text + "%') ";
            if (SubjectTextBox.Text.Trim() != "" || LetterNoTextBox.Text == "" || SenderTextBox.Text == ""  || ReceiverTextBox.Text == "" || LetterTextTextBox.Text == "" || SearchInReferCheckBox.Checked == false) where += "AND [subject] like N'%" + SubjectTextBox.Text + "%' ";
            if (LetterTextTextBox.Text.Trim() != "" || LetterNoTextBox.Text == "" || SenderTextBox.Text == "" || SubjectTextBox.Text != "" || ReceiverTextBox.Text == "" || SearchInReferCheckBox.Checked == false) where += "AND [NormalLetterText] like N'%" + LetterTextTextBox.Text + "%' ";
            if (SenderTextBox.Text.Trim() != "" || LetterNoTextBox.Text == "" || SubjectTextBox.Text != "" || ReceiverTextBox.Text == "" || LetterTextTextBox.Text == "" || SearchInReferCheckBox.Checked == false) where += "AND [sender_full_title] like N'%" + SenderTextBox.Text + "%' ";
            if (ReceiverTextBox.Text.Trim() != "" || LetterNoTextBox.Text == "" || SenderTextBox.Text == "" || SubjectTextBox.Text != "" || LetterTextTextBox.Text == "" || SearchInReferCheckBox.Checked == false) where += "AND [receiver_full_title] like N'%" + ReceiverTextBox.Text + "%' ";
            if (!string.IsNullOrWhiteSpace((FromDateJDateControl as JDateControl).GetFarsiDate()) && !string.IsNullOrWhiteSpace((ToDateJDateControl as JDateControl).GetFarsiDate()))
                where += "AND ([SignDate1] > '" + (FromDateJDateControl as JDateControl).GetFarsiDate() + "' AND [SignDate1] < '" + (ToDateJDateControl as JDateControl).GetFarsiDate() + "') ";
            else if (!string.IsNullOrWhiteSpace((FromDateJDateControl as JDateControl).GetFarsiDate()))
                where += "AND [SignDate1] = '" + (FromDateJDateControl as JDateControl).GetFarsiDate() + "' ";
            where += ") ";
            if (FullLetterSearchPermission() == false)
                where += " AND ([register_post_code] = " + ClassLibrary.JMainFrame.CurrentPostCode + @" OR Code In (select Objects.ObjectCode from Refer
                                                                                            inner join Objects on Objects.Code = Refer.object_code
                                                                                             where (
																							 Objects.ClassName = 'Communication.JCImportedLetter' or
																							 Objects.ClassName = 'Communication.JCExportedLetter' or
																							 Objects.ClassName = 'Communication.JCLetter')
                                                                                            And (Refer.sender_post_code = " + ClassLibrary.JMainFrame.CurrentPostCode + " OR Refer.receiver_post_code = " + ClassLibrary.JMainFrame.CurrentPostCode + ")@SEARCH_QUERY)) ";
            if (SearchInReferCheckBox.Checked == false || (SenderTextBox.Text == "" && ReceiverTextBox.Text == ""))
                where = where.Replace("@SEARCH_QUERY", "");
            else if (SearchInReferCheckBox.Checked)
            {
                string query = "";
                query = "AND Refer.[receiver_full_title] like N'%" + ReceiverTextBox.Text + "%' AND Refer.[sender_full_title] like N'%" + SenderTextBox.Text + "%'";
                where = where.Replace("@SEARCH_QUERY", query);
            }

            JDataBase db = new JDataBase();
            //db.setQuery();
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("WebAutomation_JCommunication");
            jGridView.SQL = @"select [Code]
      ,CASE [letter_type] WHEN 1 THEN N'وارده' ELSE N'داخلی' END [letter_type]
      ,[letter_status]
      ,[subject]
      ,(Select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as DATE)) [register_date_time]
      ,[letter_no]
      ,[incoming_no]
      ,(Select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as DATE)) [incoming_date]
      ,[incoming_signature_person]
      ,[sender_full_title]
      ,[receiver_full_title]
      ,[register_user_full_title]
	  ,[isSigned1] [isSigned]
	  ,[SignDate1] [SignDate]
	   from (SELECT *
      ,CASE [isSigned] WHEN 1 THEN N'امضا شده' ELSE N'' END [isSigned1]
      ,(Select Fa_Date from StaticDates where En_Date = CAST([SignDate] as DATE)) [SignDate1]
  FROM [Letters] ) t  Where " + where;
            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 10;
            jGridView.HiddenColumns = "Code";
            jGridView.Title = "Letters";
            jGridView.Buttons = "excel";
            //jGridView.PageOrderByField = " letter_status t";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("نمایش", "نمایش", new JActionsInfo("Click", JDomains.JActionEvents.MouseClick, "WebAutomation.JCommunication.WebCommunicationUpdate", null, null), JDomains.Images.GetFullPath(JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.ClassName = JAutomation._ConstClassName;
            jGridView.Actions = new List<JActionsInfo>();
            jGridView.Actions.Add(new JActionsInfo("GridItemDblClick", JDomains.JActionEvents.GridItemDblClick, "WebAutomation.JCommunication.WebCommunicationUpdate", null, null));
            ((WebControllers.MainControls.Grid.JGridViewControl)JGridViewControl).GridView = jGridView;
            ((WebControllers.MainControls.Grid.JGridViewControl)JGridViewControl).LoadGrid(true);
        }
    }
}