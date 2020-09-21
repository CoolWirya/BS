using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Communication.Letter
{
    public partial class LetterConvertor : Form
    {
        #region Methods
        /// <summary>
        /// Initilization
        /// </summary>
        public LetterConvertor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Converting Method From RTF to Html
        /// </summary>
        /// <param name="dt"> Letter Data Table</param>
        /// <param name="RowsCountEfected"> The Count Of Rows Are Efected</param>
        /// <param name="TotalRowsCount"> Total Rows Count Of Letter Table</param>
        /// <param name="ids"> The Id of not efected rows</param>
        /// <returns>The Count Of Rows Are Efected</returns>
        private int ConvertHtmlToRtf(DataTable dt, int RowsCountEfected, int TotalRowsCount, ref string ids)
        {
            JCLetter jcLetter;
            string id;
            int percent = 0;
            //string ids = string.Empty;
            foreach (DataRow dr in dt.Rows)
            {
                jcLetter = new JCLetter((int)dr["code"]);
                id = dr["code"].ToString();
                try
                {

                    //jcLetter.LetterText = ClassLibrary.RtfToHtmlConverter.ConvertRtfToHtml(jcLetter.LetterText).Replace("LTR", "RTL").Replace("Left", "Right").Replace("ltr", "rtl");

                    jcLetter.LetterText = ClassLibrary.RtfToHtmlConverter.ConvertRtfToHtml(jcLetter.LetterText);
                    if (jcLetter.Update())
                    {
                        RowsCountEfected++;
                        percent = (RowsCountEfected * 100) / TotalRowsCount;
                        PBLoading.Value = percent;
                       
                        lblPercent.Text = percent.ToString();
                        lblPercent.Update();
                    }
                }
                catch
                {
                    if (ids != string.Empty)
                        ids += "," + id;
                    else
                        ids += id;
                    continue;
                }
            }
            return RowsCountEfected;
            // messagebox.show(RowsCountEfected + " rows are efected from  " + totalrowscount + " rows ");
        }

        #endregion Methods

        #region Events

        /// <summary>
        /// Convert From RTF Format To HTMLS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConvert_Click(object sender, EventArgs e)
        {
            int RowsCountEfected = 0;
            int TotalRowsCount = 0;
            string noEfectedIds = string.Empty;
            JDataBase db = new JDataBase();
            db.setQuery(@"SELECT *
                                  FROM [Letters] Where LetterText  Like '%RTF%' ");
            DataTable dt = db.Query_DataTable();
            TotalRowsCount = dt.Rows.Count;

            if (RowsCountEfected < TotalRowsCount)
            {
                RowsCountEfected = ConvertHtmlToRtf(dt, RowsCountEfected, TotalRowsCount, ref noEfectedIds);
                if (RowsCountEfected < TotalRowsCount)
                {
                    DialogResult DS = MessageBox.Show(RowsCountEfected + " rows are efected from  " + TotalRowsCount
                        + " rows \r This rows is not efected : \r" + noEfectedIds);

                }
                else
                    MessageBox.Show(RowsCountEfected + " rows are efected from  " + TotalRowsCount + " rows \r All Done!");
            }
            else
                MessageBox.Show(RowsCountEfected + " rows are efected from  " + TotalRowsCount + " rows \r All Done!");

        }
        #endregion Events
    }
}
