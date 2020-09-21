using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using ManagementShares;

namespace ShareProfit
{
    public partial class JReportForm : Globals.JBaseForm
    {
        public JReportForm()
        {
            InitializeComponent();
            _FillComboBox();
        }

        private void _FillComboBox()
        {
            ///شهرها
            ManagementShares.JSahamCities cities = new ManagementShares.JSahamCities();
            cities.GetData();
            JSubBaseDefine nullDeff = new JSubBaseDefine(0);
            nullDeff.Code = 0;
            nullDeff.Name = "-----------";

            JSahamCity nullCity = new JSahamCity();
            nullCity.City = "-----------";
            nullCity.Code = 0;
            cmbCity.Items.Clear();
            cmbCity.Items.Add(nullCity);
            cmbCity.SelectedItem = nullCity;

            foreach (JSahamCity city in cities.CityItems)
            {
                cmbCity.Items.Add(city);
            }

            
            /// محلهای پرداخت سود
            JPaymentSources sources = new JPaymentSources();
            //cmbPaySource.Items.Clear();
            //cmbPaySource.Items.Add(nullDeff);
            //cmbPaySource.SelectedItem = nullDeff;
            //foreach (JSubBaseDefine source in sources.Items)
            //    cmbPaySource.Items.Add(source);
            sources.SetComboBox(cmbPaySource);
            ///دوره ها
            JCourses courses = new JCourses();
            courses.GetLists("");
            chListCourses.Items.Clear();
            foreach (JCourse course in courses.Items)
            {
                chListCourses.Items.Add(course);
            }

            cmbPName.DataSource = ManagementShares.JSahamPerson.GetNames();
            cmbPName.ValueMember = "Code";
            cmbPName.DisplayMember = "NameFam";
            txtPCode.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            #region Selected Courses
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
            #endregion Selected Courses

            bool NotCity = Convert.ToBoolean(cmbConditionCity.SelectedIndex);
            DataTable result = new DataTable();
            string strDate = "";
            if (rbPayed.Checked)
                result = JPaymentReport.MainReport(txtPCode.IntValue,"", "", 
                        ((JSahamCity)cmbCity.SelectedItem).Code, txtSheetNo.IntValue, courses, 1,
                        Convert.ToInt32(cmbPaySource.SelectedValue), txtShareNoAz.IntValue, txtShareNoEla.IntValue,
                        txtFromDate.Text, txtToDate.Text, NotCity, txtPayFromDate.Text, txtPayToDate.Text, txtShareCountFrom.IntValue, txtShareCountTo.IntValue, rbSheet.Checked,ref  strDate);

            else if (rbUnPayed.Checked)
                result = JPaymentReport.MainReport(txtPCode.IntValue, "", "", 
                    ((JSahamCity)cmbCity.SelectedItem).Code, txtSheetNo.IntValue, courses, 0, 
                    Convert.ToInt32(cmbPaySource.SelectedValue), txtShareNoAz.IntValue, txtShareNoEla.IntValue,
                    txtFromDate.Text, txtToDate.Text, NotCity, txtPayFromDate.Text, txtPayToDate.Text, txtShareCountFrom.IntValue, txtShareCountTo.IntValue, rbSheet.Checked,ref  strDate);

            else if (rbBoth.Checked)
                result = JPaymentReport.MainReport(txtPCode.IntValue, "", "", 
                    ((JSahamCity)cmbCity.SelectedItem).Code, txtSheetNo.IntValue, courses, -1,
                    Convert.ToInt32(cmbPaySource.SelectedValue), txtShareNoAz.IntValue, txtShareNoEla.IntValue,
                    txtFromDate.Text, txtToDate.Text, NotCity, txtPayFromDate.Text, txtPayToDate.Text, txtShareCountFrom.IntValue, txtShareCountTo.IntValue, rbSheet.Checked,ref  strDate);

            JGridPrintForm gridForm = new JGridPrintForm(result,strDate);
            gridForm.SheetDetails = rbSheet.Checked;
            gridForm.ShowDialog();
        }

        private void chAllCourses_CheckedChanged(object sender, EventArgs e)
        {
            chListCourses.Enabled = !chAllCourses.Checked;
        }

        private void cmbPName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Convert.ToInt32(e.KeyChar) == 1740)
                e.KeyChar = Convert.ToChar(1610);
            if (Convert.ToInt32(e.KeyChar) == 1603) // ک
                e.KeyChar = Convert.ToChar(1705);
        }

        private void cmbPName_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbPName.SelectedValue != null)
                txtPCode.Text = cmbPName.SelectedValue.ToString();
            else
                txtPCode.Text = "";
        }

        private void cmbPName_TextChanged(object sender, EventArgs e)
        {
            if (cmbPName.SelectedIndex == -1)
                txtPCode.Text = "";
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void JReportForm_Load(object sender, EventArgs e)
        {
            cmbConditionCity.SelectedIndex = 0;
        }

    }
}
