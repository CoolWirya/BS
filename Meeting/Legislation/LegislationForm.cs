using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Meeting
{
    public partial class JLegislationForm : ClassLibrary.JBaseForm
    {
        private int _Code;
        public JLegislation tmpLeg;
        public string _GroupName;
        public int _CommissionCode;

        public JLegislationForm()
        {
            InitializeComponent();
            tmpLeg = new JLegislation();
        }

        public JLegislationForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
            tmpLeg = new JLegislation();
        }

        private void SetForm()
        {
            //tmpLeg.GetData(_Code);
            cmbGroup.SelectedValue = tmpLeg.LegislationGroup;
            txtName.Text = tmpLeg.Legislation;
            cmbStatus.SelectedValue = tmpLeg.Flow;
            txtDesc.Text = tmpLeg.Description;
            txtDate.Date = tmpLeg.FlowDate;
            txtPerson.Text = tmpLeg.PersonFlow;
            cmbStatus.SelectedValue = tmpLeg.Flow;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbGroup.SelectedItem == null)
                JMessages.Error("گروه مصوبه را انتخاب کنید", "error");
            else
            {
                tmpLeg.LegislationGroup = (int)cmbGroup.SelectedValue;
                tmpLeg.Legislation = txtName.Text;
                if (cmbStatus.SelectedItem != null)
                    tmpLeg.Flow = Convert.ToInt32(cmbStatus.SelectedValue);
                tmpLeg.Description = txtDesc.Text;
                tmpLeg.FlowDate = txtDate.Date;
                tmpLeg.PersonFlow = txtPerson.Text;
                _GroupName = cmbGroup.Text;
                DialogResult = DialogResult.OK;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JLegislationForm_Load(object sender, EventArgs e)
        {
            //  ---------------------- Set ComboBox Privacy --------------------------
            cmbStatus.DisplayMember = "FarsiName";
            cmbStatus.ValueMember = "value";
            cmbStatus.DataSource = ClassLibrary.Domains.JGlobal.JStatus.GetData();
            cmbStatus.SelectedValue = ClassLibrary.Domains.JGlobal.JStatus.Action;

            DataTable dtCommission = new DataTable();
            dtCommission = JLegCommission.GetDataTable(_CommissionCode);
            DataRow dr = dtCommission.NewRow();
            dr["LegislationGroup"] = -1;
            dr["name"] = "-----------";
            dtCommission.Rows.Add(dr);
            cmbGroup.DisplayMember = "Name";
            cmbGroup.ValueMember = "LegislationGroup";
            cmbGroup.DataSource = dtCommission;
            //JSubBaseDefines LegGroup = new JSubBaseDefines(JBaseDefine.LegislationGroupType);
            //LegGroup.SetComboBox(cmbGroup, tmpLeg.LegislationGroup);            
            
            SetForm();        
        }
    }
}
