using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JNotaryLetterSearchForm : JBaseForm
    {
        #region Property

        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// کد محضر
        /// </summary>
        public int Notary_Code { get; set; }
        /// <summary>
        /// کد وکالت
        /// </summary>
        public int Advocacy_Code { get; set; }
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string LetterNumber { get; set; }
        /// <summary>
        /// تاریخ نامه
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #endregion

        public JNotaryLetterSearchForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JNotaryLetter tmp=new JNotaryLetter();
            tmp.Date = DateLetter.Date;
            tmp.Description = txtDesc.Text.Trim();
            tmp.LetterNumber = txtLetterNo.Text.Trim();
            //tmp.Subject = txtSubject.Text.Trim();
            //tmp.Advocacy_Code=;
            jdgvNotaryLetter.DataSource = tmp.Search(EndDate.Date);        
        }

        private void BtnConfirm_Click(object sender, EventArgs e)
        {
          Code = Convert.ToInt32(jdgvNotaryLetter.CurrentRow.Cells["Code"].Value);
          Notary_Code = Convert.ToInt32(jdgvNotaryLetter.CurrentRow.Cells["Notary_Code"].Value);
          //Advocacy_Code = Convert.ToInt32(jdgvNotaryLetter.CurrentRow.Cells["Advocacy_Code"].Value);
          LetterNumber = jdgvNotaryLetter.CurrentRow.Cells["LetterNumber"].Value.ToString();
          if ((jdgvNotaryLetter.CurrentRow.Cells["Date"].Value != null)&&(jdgvNotaryLetter.CurrentRow.Cells["Date"].Value.ToString() != ""))
            Date = Convert.ToDateTime(jdgvNotaryLetter.CurrentRow.Cells["Date"].Value);
          Subject = jdgvNotaryLetter.CurrentRow.Cells["Subject"].Value.ToString();
          Description = jdgvNotaryLetter.CurrentRow.Cells["Description"].Value.ToString();
          Close();
        }

        private void jdgvNotaryLetter_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            BtnConfirm_Click(null, null);
        }

      
    }
}
