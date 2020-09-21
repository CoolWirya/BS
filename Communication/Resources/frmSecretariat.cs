using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;

namespace Communication
{
    public partial class JfrmSecretariat : Globals.JBaseForm
    {
        private JCSecretariat _JSec;
        private Globals.JUser[] users;
        DataTable _dtPerson;
        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="jclass"></param>
        public JfrmSecretariat(JCSecretariat jclass)
        {
            InitializeComponent();
            _InitialazeForm();
            string where;

            if (jclass != null)
                where = "[Code] <>" + jclass.Code /*+ " AND [ParentCode]<>" + jclass.pCode*/;
            else
                where = "";

            if (jclass != null)
            {
                _JSec = jclass;
                txtSecretariatName.Text = _JSec.Name;
                for (int i = 0; i < cdbOrganiztionChartPerson.cmbTitles.Items.Count; i++)
                {
                    if (((System.Data.DataRowView)(cdbOrganiztionChartPerson.cmbTitles.Items[i])).Row["code"].ToString() == jclass.Manager_user_post_code.ToString())
                    {
                        cdbOrganiztionChartPerson.cmbTitles.SelectedItem = cdbOrganiztionChartPerson.cmbTitles.Items[i];
                    }
                }
                cmbStorageLetterNo.SelectedValue = jclass.Strg_Code;
                txtPrifix.Text = jclass.Prifix;
                txtSuffix.Text = jclass.Suffix;
            }

        }

        private void GetPattern()
        {
            try
            {
                _dtPerson = JsecretariatUsers.GetData(_JSec.Code);
                jdgvPersons.DataSource = _dtPerson;                
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void Savebutton_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (txtSecretariatName.Text.Trim() == "")
                {
                    JMessages.Message(JLanguages._Text("Please Enter Secretariat Name"), "Error", JMessageType.Error);
                    txtSecretariatName.Focus();
                    return;
                }

                if (cdbOrganiztionChartPerson.cmbTitles.SelectedValue == null || Convert.ToInt32(cdbOrganiztionChartPerson.cmbTitles.SelectedValue) == -1)
                {
                    JMessages.Message(JLanguages._Text("Please Select Manager of Secretariat"), JLanguages._Text("Error"), JMessageType.Error);
                    cdbOrganiztionChartPerson.cmbTitles.Focus();
                    return;
                }

                if (cmbStorageLetterNo.SelectedValue == null)
                {
                    JMessages.Message(JLanguages._Text("Please Select Storage for Secretariat"), "Error", JMessageType.Error);
                    cmbStorageLetterNo.Focus();
                    return;
                }

                if (State == JFormState.Insert)
                {
                    JCSecretariat tmpJSecretariat = new JCSecretariat();
                    //tmpJSecretariat.Nodes = _JSec.Nodes;
                    tmpJSecretariat.Name = txtSecretariatName.Text.Trim();
                    tmpJSecretariat.Manager_user_post_code = int.Parse(((System.Data.DataRowView)(cdbOrganiztionChartPerson.cmbTitles.SelectedItem)).Row["code"].ToString());
                    tmpJSecretariat.Strg_Code = int.Parse(cmbStorageLetterNo.SelectedValue.ToString());
                    tmpJSecretariat.Prifix = txtPrifix.Text;
                    tmpJSecretariat.Suffix = txtSuffix.Text;
                    tmpJSecretariat.Insert(_dtPerson);
                    Close();
                }
                else if (State == JFormState.Update)
                {
                    _JSec.Name = txtSecretariatName.Text.Trim();
                    _JSec.Manager_user_post_code = int.Parse(((System.Data.DataRowView)(cdbOrganiztionChartPerson.cmbTitles.SelectedItem)).Row["code"].ToString());
                    _JSec.Strg_Code = int.Parse(cmbStorageLetterNo.SelectedValue.ToString());
                    _JSec.Prifix = txtPrifix.Text;
                    _JSec.Suffix = txtSuffix.Text;
                    _JSec.Update(_dtPerson);                    
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch
            {

            }
        }

        private void btnShowOrganazationChart_Click(object sender, EventArgs e)
        {           
            Employment.JEfrmOrganizatinChart Org = new  Employment.JEfrmOrganizatinChart();
            Org.ViewMode = true;
            if (Org.ShowDialog() == DialogResult.OK)
            {
                cdbOrganiztionChartPerson.TitleFieldName = "full_title";
                cdbOrganiztionChartPerson.AccessCodeFieldName = "accesscode";
                cdbOrganiztionChartPerson.CodeFieldName = "code";
                //cdbOrganiztionChartPerson.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, 5);
                cdbOrganiztionChartPerson.SetComboBox();
                cdbOrganiztionChartPerson.SetValue(Org.SelectedItem["accesscode"]);
            }

        }

        #region Functions
        private void _InitialazeForm()
        {
            this.NextControlOnPressEnter = false;

            cdbOrganiztionChartPerson.TitleFieldName = "full_title";
            cdbOrganiztionChartPerson.AccessCodeFieldName = "accesscode";
            cdbOrganiztionChartPerson.CodeFieldName = "code";
            //cdbOrganiztionChartPerson.dataTable = (new Employment.JEOrganizationChart()).GetOrganizationCharts(0, 5);
            cdbOrganiztionChartPerson.SetComboBox();

            cmbStorageLetterNo.DisplayMember = "name";
            cmbStorageLetterNo.ValueMember = "code";
            //cmbStorageLetterNo.DataSource = (new JCStorageLetterNos()).GetStorageLetterNo();
            txtSecretariatName.Focus();

        }
        #endregion Functions

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
            this.Dispose();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {

                Employment.JEfrmOrganizatinChart Org = new Employment.JEfrmOrganizatinChart();
                Org.ViewMode = true;
                if (Org.ShowDialog() == DialogResult.OK)
                {
                    if (Org.SelectedItem != null)
                    {
                        if ((((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PCode=" + Org.SelectedItem["Code"].ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0)))
                        {
                            DataRow dr = _dtPerson.NewRow();
                            dr["PCode"] = Org.SelectedItem["code"];
                            dr["Name"] = Org.SelectedItem["Title"];
                            _dtPerson.Rows.Add(dr);
                            jdgvPersons.DataSource = _dtPerson;
                        }
                        else
                            JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                    }
                }
                Org.Dispose();

                //ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(JPersonTypes.RealPerson,
                //     JTableNamesClassLibrary.PersonTable + ".Code IN (SELECT PCode From empcontract WHERE state = 1) ");
                //p.ShowDialog();
                //if (p.SelectedPerson != null)
                //{                   
                //    if ((((_dtPerson.Rows.Count > 0) && (_dtPerson.Select("PCode=" + p.SelectedPerson.Code.ToString()).Length < 1)) || (_dtPerson.Rows.Count == 0)))
                //    {
                //        DataRow dr = _dtPerson.NewRow();
                //        dr["PCode"] = p.SelectedPerson.Code;
                //        dr["Name"] = p.SelectedPerson.Name;
                //        _dtPerson.Rows.Add(dr);
                //        jdgvPersons.DataSource = _dtPerson;                       
                //    }
                //    else
                //        JMessages.Message("Person is Repeated ", "", JMessageType.Information);
                //    //}
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            try
            {
                if (jdgvPersons.CurrentRow != null)
                {
                    jdgvPersons.Rows.Remove(jdgvPersons.CurrentRow);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JfrmSecretariat_Load(object sender, EventArgs e)
        {
            GetPattern();
        }
    }
}
