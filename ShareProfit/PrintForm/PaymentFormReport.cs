using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ShareProfit
{
    public partial class JPaymentFormReport : JBaseForm
    {
        public JPaymentFormReport()
        {
            InitializeComponent();
        }

        private void PaymentFormReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int[] courses = new int[0];
            if (!chAllCourses.Checked)
            {
                if (chListCourses.CheckedItems.Count == 0)
                {
                    JMessages.Error("PleaseSelectAtListOneCourse", "Error");
                    return;
                }
                int Count = 0;
                foreach (object checkedItem in chListCourses.CheckedItems)
                {
                    Array.Resize(ref courses, ++Count);
                    courses[Count - 1] = (checkedItem as JCourse).Code;
                }
            }
            //DataSet DSet = JPaymentReport.ReportFromTempTable(0, 0, 0, 0, 0, courses);
            DataSet DSet = JPaymentReport.ReportForm(0, 0, 0, 0, 0, courses);

            DataView dv = DSet.Tables[0].DefaultView;

            string CourseFilter = " CourseCode IN " + JDataBase.GetInSQLClause(courses);
            dv.RowFilter = CourseFilter;
            DataTable tmp = new DataTable();
            tmp = dv.ToTable();
            DataTable tableSum = DSet.Tables[1];
            JGridPrintForm gridForm = new JGridPrintForm();
            gridForm.grdReport.DataSource = tmp;
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.Format = "N0";
            gridForm.grdReport.Columns["payed"].DefaultCellStyle = style;
            gridForm.grdReport.Columns["AllProfit"].DefaultCellStyle = style;
            gridForm.grdReport.Columns["CourseCost"].DefaultCellStyle = style;
            gridForm.grdReport.Columns["Credit"].DefaultCellStyle = style;
            gridForm.lbSumSahmPayed.Text = tableSum.Rows[0]["SumManagementsharesCount"].ToString();
            gridForm.lbSumCostPayed.Text = JGeneral.MoneyStr(tableSum.Rows[0]["SumPayed"].ToString());
            gridForm.lbSumCostAllPayed.Text = JGeneral.MoneyStr(tableSum.Rows[0]["SumAllProfit"].ToString());
            gridForm.ShowDialog();

            
        }
        private void LoadData()
        {
            JCourses courses = new JCourses();
            courses.GetLists("");
            chListCourses.Items.Clear();
            foreach (JCourse course in courses.Items)
            {
                chListCourses.Items.Add(course);
            }
            JSDocuments documents = new JSDocuments();
            documents.GetLists("");
            JDataBase DB = JGlobal.MainFrame.GetSharesDB();
//            JDataBase DB = new JDataBase(ManagementShares.JManagementshares.DBConfig());
            try
            {
                //// پر کردن آیتم شهرها
                DB.setQuery(@"SELECT * FROM " + JGlobal.MainFrame.GetConfig().CitiesTableName);
                DataTable table = DB.Query_DataTable();
                cmbCity.AccessCodeFieldName = "Code";
                cmbCity.CodeFieldName = "Code";
                cmbCity.TitleFieldName = "City";
                cmbCity.dataTable = table;
                cmbCity.SetComboBox();
                //// پر کردن آیتم محل پرداخت
                DB = JGlobal.MainFrame.GetDBO();
                DB.setQuery(@"SELECT * FROM subdefine WHERE bcode = 6");
                table = DB.Query_DataTable();
                cmbPayLoc.AccessCodeFieldName = "code";
                cmbPayLoc.CodeFieldName = "code";
                cmbPayLoc.TitleFieldName = "name";
                cmbPayLoc.dataTable = table;
                cmbPayLoc.SetComboBox();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
        }

        private void chAllCourses_CheckedChanged(object sender, EventArgs e)
        {
            chListCourses.Enabled = !chAllCourses.Checked;

        }
    }
}
