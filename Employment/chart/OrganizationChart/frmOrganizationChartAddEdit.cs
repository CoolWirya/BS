using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace Employment
{
    public partial class JfrmOrganizationChartAddEdit : ClassLibrary.JBaseForm
    {
        public int ChartCode;
        public int ParentCode;
        public int Code;
        public int MetierCode;
        public int PostTitleCode;
        public JEOrganizationChart OrganizationChart;

        int _CompanyCode;
        public JfrmOrganizationChartAddEdit(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }
        /// <summary>
        /// تنظیمات اوایه فرم
        /// </summary>
        private void _InitializeForm()
        {

            _SetComboBoxs();
            if (State == JFormState.Insert)
            {
                btnAction.Text = JLanguages._Text("Insert");
            }
            else
            {
                cmbPost.SelectedValue = OrganizationChart.PostTitleCode;
                MetierCode = OrganizationChart.JobTitleCode;
                if (OrganizationChart.user_code > 0)
                {
                    cmbUsers.SelectedValue = OrganizationChart.user_code.ToString();
                }
                if (OrganizationChart.secretariat_code > 0)
                {
                    cmbsecretariat.SelectedValue = OrganizationChart.secretariat_code.ToString();
                }
                rdo_Is_Unit.Checked = OrganizationChart.is_unit;
                rdo_Is_Not_Unit.Checked = !OrganizationChart.is_unit;
                btnAction.Text = JLanguages._Text("Update");
            }

        }
        /// <summary>
        /// تنظیم لیست ها
        /// </summary>
        private void _SetComboBoxs()
        {
            DataTable dt = new DataTable();
            //---------------- set combobox Metier Topic ---------------
            dt = (new JPostTitle()).GetList();
            //dt = (new JMetiertopics()).GetList(JEBaseDefine.MetierCode);
            cmbPost.DisplayMember = "Title";
            cmbPost.ValueMember = "Code";
            cmbPost.DataSource = dt;

            //---------------- set combobox Posts  ---------------
            dt = (new JJobTitle()).GetList();
            //dt = (new JMetiertopics()).GetList(JEBaseDefine.MetierCode);
            cmbJobMetier.DisplayMember = "name";
            cmbJobMetier.ValueMember = "Code";
            cmbJobMetier.DataSource = dt;

            //---------------- set combobox Users  ---------------
            dt = (new Globals.JUsers()).GetUserList();
            DataRow dr;
            dr = dt.NewRow();
            dr["fullname"] = "-------";
            dr["code"] = 0;
            dt.Rows.InsertAt(dr, 0);
            cmbUsers.DisplayMember = "fullname";
            cmbUsers.ValueMember = "code";
            cmbUsers.DataSource = dt;

            //---------------- set combobox secretariat  ---------------
            Communication.JCSecretariat tmp = new Communication.JCSecretariat();
            dt = tmp.GetSecretariat(0, "code , name AS title");
            DataRow dr1;
            dr1 = dt.NewRow();
            dr1["title"] = "-------";
            dr1["code"] = 0;
            dt.Rows.InsertAt(dr1, 0);
            cmbsecretariat.DisplayMember = "title";
            cmbsecretariat.ValueMember = "code";
            cmbsecretariat.DataSource = dt;

        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_Validations())
                {
                    return;
                }

                if (State == JFormState.Insert)
                {
                    JEOrganizationChart orgChart = new JEOrganizationChart();
                    orgChart.parentcode = ParentCode;
                    orgChart.is_unit = rdo_Is_Unit.Checked;
                    orgChart.PostTitleCode = PostTitleCode;
                    orgChart.JobTitleCode = MetierCode;

                    if (cmbUsers.SelectedValue != null)
                    {
                        orgChart.user_code = Convert.ToInt32(cmbUsers.SelectedValue);
                    }
                    if (cmbsecretariat.SelectedValue != null)
                    {
                        orgChart.secretariat_code = Convert.ToInt32(cmbsecretariat.SelectedValue);
                    }

                    if (orgChart.InsertNode())
                    {
                        DialogResult = DialogResult.OK;
                        Code = orgChart.code;
                    }
                    else
                    {
                        JMessages.Message(JLanguages._Text("Rigerster New item fail"), JLanguages._Text("Error"), JMessageType.Error);
                    }

                }
                else if (State == JFormState.Update)
                {
                    JEOrganizationChart orgChart = new JEOrganizationChart(Code);
                    orgChart = OrganizationChart;
                    orgChart.is_unit = rdo_Is_Unit.Checked;
                    orgChart.PostTitleCode = PostTitleCode;
                    orgChart.JobTitleCode = MetierCode;
                    if (cmbUsers.SelectedValue != null)
                    {
                        orgChart.user_code = Convert.ToInt32(cmbUsers.SelectedValue);
                    }
                    if (cmbsecretariat.SelectedValue != null)
                    {
                        orgChart.secretariat_code = Convert.ToInt32(cmbsecretariat.SelectedValue);
                    }
                    if (orgChart.UpdateNode())
                    {
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            ClassLibrary.JFindPersonForm p = new ClassLibrary.JFindPersonForm(JPersonTypes.RealPerson, " clsPerson.Code in (select pCode from users) ");
            p.ShowDialog();
            if (p.SelectedPerson != null)
            {
                Globals.JUser tmpUser = new Globals.JUser();
                cmbUsers.SelectedValue = tmpUser.findPerson(p.SelectedPerson.Code);
            }
            //Globals.JUsersListForm frmUsers = new Globals.JUsersListForm("");
            //if (frmUsers.ShowDialog() == DialogResult.OK)
            //{
            //    //---------------- set combobox Users ---------------
            //    DataTable dt = new DataTable();
            //    dt = (new Globals.JUsers()).GetUserList();
            //    cmbUsers.DisplayMember = "fullname";
            //    cmbUsers.ValueMember = "code";
            //    cmbUsers.DataSource = dt;


            //}
        }

        private void btnMetierTopic_Click(object sender, EventArgs e)
        {
            JBaseDefineList frmMetierTopic = new JBaseDefineList((new JMetiertopics()));
            if (frmMetierTopic.ShowDialog() == DialogResult.OK)
            {
                DataTable dt = new DataTable();
                //---------------- set combobox Metier Topic ---------------
                /*dt = (new JMetiertopics()).GetList(JEBaseDefine.MetierCode);
                cmbMetierTopic.DisplayMember = "name";
                cmbMetierTopic.ValueMember = "code";
                cmbMetierTopic.DataSource = dt;
                cmbMetierTopic.SelectedValue = frmMetierTopic.SelectedItem.Code;*/
            }
        }

        private bool _Validations()
        {
            if (cmbPost.Text.Trim() == "")
            {
                cmbPost.Focus();
                JMessages.Message(JLanguages._Text("Please Enter Title of node"), JLanguages._Text("Error"), JMessageType.Error);
                return false;
            }
            // بررسی صحت عنوان شغلی
            /*if (cmbMetierTopic.SelectedValue == null || cmbMetierTopic.SelectedIndex == -1 || cmbMetierTopic.SelectedValue == null)
            {
                JMessages.Message(JLanguages._Text("please Select Metier Topic"), JLanguages._Text("Error"), JMessageType.Error);
                return false;
            }*/
            return true;
        }

        private void JfrmOrganizationChartAddEdit_Load(object sender, EventArgs e)
        {
            _InitializeForm();
            cmbUsers.Focus();
        }

        private void cmbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbUsers_SelectedValueChanged(object sender, EventArgs e)
            {
            try
            {
                if (cmbUsers.SelectedValue == null || (int)cmbUsers.SelectedValue == 0) return;
                int uCode = (int)cmbUsers.SelectedValue;
                Globals.JUser jUser = new Globals.JUser(uCode);
                JEmployeeInfo jEmployeeInfo = new JEmployeeInfo();

                jEmployeeInfo.Find("pCode = " + jUser.PCode);
                JEOrganizationChart jeorgchart = new JEOrganizationChart(Code);
                jeorgchart = OrganizationChart;
                if ((jeorgchart != null) && (jeorgchart.PostTitleCode > 0) )
                    cmbPost.SelectedValue = jeorgchart.PostTitleCode;
                else
                    cmbPost.SelectedValue = jEmployeeInfo.PostTitleCode;

                if ((jeorgchart != null) &&(jeorgchart.JobTitleCode > 0))
                    cmbJobMetier.SelectedValue = jeorgchart.JobTitleCode;
                else
                    cmbJobMetier.SelectedValue = jEmployeeInfo.JobTitleCode;

                MetierCode = (int)cmbJobMetier.SelectedValue;
                PostTitleCode = (int)cmbPost.SelectedValue;
                /*if (!String.IsNullOrEmpty(cmbPost.Text))
                    cmbPost.Enabled = true; // it was false before
                else
                    cmbPost.Enabled = true;
                if (!String.IsNullOrEmpty(cmbJobMetier.Text))
                    cmbJobMetier.Enabled = true; // it was false before
                else
                    cmbJobMetier.Enabled = true;*/
            }
            catch (Exception ex) { JSystem.Except.AddException(ex); }
            finally { }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbPost_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPost.SelectedValue == null)
                PostTitleCode = 0;
            else
                PostTitleCode = (int)cmbPost.SelectedValue;
        }

        private void cmbJobMetier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbJobMetier.SelectedValue == null)
                MetierCode = 0;
            else
                MetierCode = (int)cmbJobMetier.SelectedValue;
        }


    }
}
