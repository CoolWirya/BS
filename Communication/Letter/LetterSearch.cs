using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Communication.Letter
{
    public partial class LetterSearch : ClassLibrary.JBaseForm
    {
        public LetterSearch()
        {
            InitializeComponent();
            grdLetters.gridEX1.MouseDoubleClick += new MouseEventHandler(gridEX1_MouseDoubleClick);
        }

        void gridEX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            JCLetter jcLetter = new JCLetter(Convert.ToInt32(grdLetters.SelectedRow["Code"]));
            if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(jcLetter.Code, 0)).ShowDialog();
			else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
				(new JLetterForm(jcLetter.Code, 0)).ShowDialog();
			else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
				(new JExportedLetterForm(jcLetter.Code, 0)).ShowDialog();
		}

        private void btnSearch_Click(object sender, EventArgs e)
        {

            string where = "( 1=1 ";
            if (txtLetterNo.Text.Trim() != "") where += "AND ([letter_no] like N'%" + txtLetterNo.Text + "%' " +
                " OR [incoming_no] like N'%" + txtLetterNo.Text + "%') ";
            //if (txtLetterNo.Text.Trim() != "") where += "AND [incomming_no] like N'%" + txtLetterNo.Text + "%' ";
            if (txtSubject.Text.Trim() != "") where += "AND [subject] like N'%" + txtSubject.Text + "%' ";
            if (txtContent.Text.Trim() != "") where += "AND [NormalLetterText] like N'%" + txtContent.Text + "%' ";
            if (txtSender.Text.Trim() != "") where += "AND [sender_full_title] like N'%" + txtSender.Text + "%' ";
            if (txtReciever.Text.Trim() != "") where += "AND [receiver_full_title] like N'%" + txtReciever.Text + "%' ";
            if (dateStart.NotEmpty == true && dateEnd.NotEmpty == true)
                where += "AND ([SignDate] > '" + dateStart.Date + "' AND [SignDate] < '" + dateEnd.Date + "') ";
            else if (dateStart.NotEmpty == true)
                where += "AND [SignDate] = '" + dateStart.Date + "' ";
            where += ") ";
            if (FullLetterSearchPermission() == false)
                where += " AND ([register_post_code] = " + JMainFrame.CurrentPostCode + @" OR Code In (select Objects.ObjectCode from Refer
                                                                                            inner join Objects on Objects.Code = Refer.object_code
                                                                                             where (
																							 Objects.ClassName = 'Communication.JCImportedLetter' or
																							 Objects.ClassName = 'Communication.JCExportedLetter' or
																							 Objects.ClassName = 'Communication.JCLetter')
                                                                                            And (Refer.sender_post_code = " + JMainFrame.CurrentPostCode + " OR Refer.receiver_post_code = " + JMainFrame.CurrentPostCode + ")@SEARCH_QUERY)) ";
            if (chbRefers.Checked == false || (txtSender.Text == "" && txtReciever.Text == ""))
                where = where.Replace("@SEARCH_QUERY", "");
            else if (chbRefers.Checked)
            {
                string query = "";
                query = "AND Refer.[receiver_full_title] like N'%" + txtReciever.Text + "%' AND Refer.[sender_full_title] like N'%" + txtSender.Text + "%'";
                where = where.Replace("@SEARCH_QUERY", query);
            }

            JDataBase db = new JDataBase();
            db.setQuery(@"SELECT [Code]
      ,CASE [letter_type] WHEN 1 THEN N'وارده' ELSE 
			CASE [letter_type] WHEN 3 THEN N'داخلی' ELSE N'صادره' END 
		END [letter_type]
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
      ,CASE [isSigned] WHEN 1 THEN N'امضا شده' ELSE N'' END [isSigned]
      ,(Select Fa_Date from StaticDates where En_Date = CAST([SignDate] as DATE)) [SignDate]
  FROM [Letters] Where " + where);
            grdLetters.DataSource = db.Query_DataTable();
            db.Dispose();
        }

        public bool FullLetterSearchPermission()
        {
            if (JPermission.CheckPermission("Communication.Letter.FullLetterSearchPermission", false))
                return true;
            return false;
        }

        private void LetterSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
