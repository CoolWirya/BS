using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using ClassLibrary;

namespace ShareProfit
{
    public partial class JSPersonReportForm : JBaseForm
    {
        private DataSet _DSet;
        string SelectCommand = "";
        public JSPersonReportForm()
        {
            InitializeComponent();
            InitController(this);
            LoadData();
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
            chListDocs.Items.Clear();
            foreach (JSDocument document in documents.Items)
            {
                chListDocs.Items.Add(document);
            }
            ////// پر کردن آیتم شهرها
            //JDataBase DB = new JDataBase(Managementshares.JManagementshares.DBConfig());
            //DB.setQuery(@"SELECT * FROM " + JGlobal.MainFrame.GetConfig().CitiesTableName);
            //DataTable table = DB.Query_DataTable();
            //jCodingBox1.AccessCodeFieldName = "Code";
            //jCodingBox1.CodeFieldName = "Code";
            //jCodingBox1.TitleFieldName = "City";
            //jCodingBox1.dataTable = table;
            //jCodingBox1.SetComboBox();
        }

        private void chAllCourses_CheckedChanged(object sender, EventArgs e)
        {
            chListCourses.Enabled = !chAllCourses.Checked;
        }

        private void chAllDosc_CheckedChanged(object sender, EventArgs e)
        {
            chListDocs.Enabled = !chAllDosc.Checked;
            chGroup.Enabled = !chAllDosc.Checked;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JPaymentReport report = new JPaymentReport();
            int[] courses = new int[0];
            int Count = 0;
            if (!chAllCourses.Checked)
                foreach (object checkedItem in chListCourses.CheckedItems)
                {
                    Array.Resize(ref courses, ++Count);
                    courses[Count - 1] = (checkedItem as JCourse).Code;
                }
            Count = 0;
            int[] docs = new int[0];
            if (!chAllDosc.Checked)
                foreach (object checkedItem in chListDocs.CheckedItems)
                {
                    Array.Resize(ref docs, ++Count);
                    docs[Count - 1] = (checkedItem as JSDocument).Code;
                }
            JShowGrid gridForm = new JShowGrid();
            if (rbSearchOnCode.Checked)
            {
                int fromPCode = txtFromCode.IntValue;
                int toPCode = txtToCode.IntValue;
                _DSet = report.Payments(fromPCode, toPCode, courses, docs, ref SelectCommand);

                
                gridForm.dataGridView1.DataSource = _DSet.Tables[0];
                gridForm.lbSumPay.Text = report.SumPayment.ToString();
                gridForm.lbSumManagementsharesCount.Text = report.SumManagementsharesCount.ToString();
            }
            else if (rbSearchOnInfo.Checked)
            {
                JPersons persons = new JPersons();
                string SelectPerson = "";

                if (txtLastName.Text.Trim() != "")
                    if (txtManagementsharesHolderNo.Text.Trim() != "")
                        SelectPerson = SelectPerson + " AND LastName LIKE " + JDataBase.Quote("%" + txtLastName.Text.Trim() + "%");
                //if (txtName.Text.Trim() != "")
                //    SelectPerson = SelectPerson + " AND FirstName LIKE " + JDataBase.Quote("%" + txtName.Text + "%");
                //if (txtNationalCode.Text.Trim() != "")
                //    SelectPerson = SelectPerson + " AND shMelli = " + JDataBase.Quote(txtNationalCode.Text);
                if (txtManagementsharesHolderNo.Text.Trim() != "")
                    SelectPerson = SelectPerson + " AND A.pcode = " + txtManagementsharesHolderNo.Text;
                //if (jCodingBox1.SelectedCode > 0)
                  //  SelectPerson = SelectPerson + " AND Cities.Code = " + jCodingBox1.SelectedCode;
                _DSet = report.Payments(SelectPerson, courses, docs, ref SelectCommand);
                gridForm.dataGridView1.DataSource = _DSet.Tables[0];

                DataGridViewCellStyle style = new DataGridViewCellStyle();
                style.Format = "N0";
                gridForm.dataGridView1.Columns["sumPay"].DefaultCellStyle = style;

                gridForm.lbSumPay.Text = JGeneral.MoneyStr(report.SumPayment.ToString());
                gridForm.lbSumManagementsharesCount.Text = report.SumManagementsharesCount.ToString();
            }
            gridForm.ShowDialog();
        }

        private void rbSearchOnCode_CheckedChanged(object sender, EventArgs e)
        {
            txtFromCode.ReadOnly = !rbSearchOnCode.Checked;
            txtToCode.ReadOnly = !rbSearchOnCode.Checked;

            txtLastName.ReadOnly = rbSearchOnCode.Checked;
            //txtName.ReadOnly = rbSearchOnCode.Checked;
            //txtNationalCode.ReadOnly = rbSearchOnCode.Checked;
            txtManagementsharesHolderNo.ReadOnly = rbSearchOnCode.Checked;
//            jCodingBox1.ReadOnly = rbSearchOnCode.Checked;

            if (rbSearchOnCode.Checked)
                txtFromCode.Focus();
            if (rbSearchOnInfo.Checked)
                txtLastName.Focus();
        }

        private void chGroup_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < chListDocs.Items.Count; i++)
            {
                chListDocs.SetItemChecked(i, chGroup.Checked);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void JSPersonReportForm_Load(object sender, EventArgs e)
        {
            //jCodingBox1.ReadOnly = rbSearchOnCode.Checked;
        }

        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            //JPersons person = new JPersons();
            //string ResultText = "";
            //int ResultCode = person.Search(ref ResultText);
            //txtLastName.Text = ResultText;
            //txtManagementsharesHolderNo.Text = (JExternalTable.GetExternalCode(Convert.ToInt32(ResultCode.ToString()))).ToString();
            //txtManagementsharesHolderNo.Focus();
        }
   }
}
