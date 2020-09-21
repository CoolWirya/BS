using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JNewAgentForm : JBaseForm

    {
        JShareAgent agent = null;
        private int CompanyCode;
        
        public JNewAgentForm(int pCode , int pCompanyCode)
        {
            InitializeComponent();
            CompanyCode = pCompanyCode;
            agent = new JShareAgent(pCode,pCompanyCode);
            if (pCode > 0)
            {
                ShowData();
            }
        }
        private void ShowData()
        {
            if (agent != null)
            {
                txtEndDate.Date = agent.EndDate;
                txtStartDate.Date = agent.StartDate;
                person1.SelectedCode = agent.PCode;
                rbFormal.Checked = agent.IsFormal;
                rbNotFormal.Checked = !agent.IsFormal;
                person1.ReadOnly = true;
                lbShareCount.Text = agent.GetShareCount().ToString();
                lbPersonCount.Text = agent.GetPersonCount().ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool Save()
        {
            agent.PCode = Convert.ToInt32(person1.SelectedCode);
            agent.StartDate = txtStartDate.Date;
            agent.Status = JAgentStatus.Enable.GetHashCode();
            agent.EndDate = txtEndDate.Date;
            agent.IsFormal = rbFormal.Checked;
            agent.CompanyCode = CompanyCode;
            if (agent.Code == 0)
            {
                if (JShareAgent.CheckExist(person1.SelectedCode, CompanyCode))
                {
                    JMessages.Error("این شخص قبلا به عنوان وکیل انتخاب شده است.", "");
                    return false;
                }
                return agent.Insert() > 0;
            }
            else
                return agent.Update();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (person1.SelectedCode == 0)
            {
                JMessages.Error("لطفا شخص را انتخاب کنید.", "");
                return;
            }
           
            if (Save())
                DialogResult = DialogResult.OK;
            else
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است.", "خطا");
        }
    }
}
