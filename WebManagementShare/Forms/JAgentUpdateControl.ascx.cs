using ManagementShares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebManagementShare.Forms
{
    public partial class JAgentUpdateControl : System.Web.UI.UserControl
    {
        JShareAgent agent = null;
        int CompanyCode;
        protected void Page_Load(object sender, EventArgs e)
        {
            int Code;
            int.TryParse(Request["Code"], out Code);
            int.TryParse(Request["CompanyCode"], out CompanyCode);
            agent = new JShareAgent(Code, CompanyCode);
            if (Code > 0)
            {
                ShowData();
            }
        }
        private void ShowData()
        {
            if (agent != null)
            {
                ((WebControllers.MainControls.Date.JDateControl)txtEndDate).SetDate(agent.EndDate);
                ((WebControllers.MainControls.Date.JDateControl)txtStartDate).SetDate(agent.StartDate);
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = agent.PCode;
                cmbEmploymentStatus.SelectedValue = agent.IsFormal ? "Formal" : "NotFormal";
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).isReadOnly = true;
                lblShareCount.Text = agent.GetShareCount().ToString();
                lblPersonCount.Text = agent.GetPersonCount().ToString();
            }
        }
        private bool Save()
        {
            agent.PCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            agent.StartDate = ((WebControllers.MainControls.Date.JDateControl)txtStartDate).Date;
            agent.Status = JAgentStatus.Enable.GetHashCode();
            agent.EndDate = ((WebControllers.MainControls.Date.JDateControl)txtEndDate).Date;
            agent.IsFormal = cmbEmploymentStatus.SelectedValue == "Formal" ? true : false;
            agent.CompanyCode = CompanyCode;
            if (agent.Code == 0)
            {
                if (JShareAgent.CheckExist(((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode))
                {
                    WebClassLibrary.JWebManager.RunClientScript("alert('این شخص قبلا به عنوان وکیل انتخاب شده است.');", "ConfirmDialog");
                    return false;
                }
                return agent.Insert() > 0;
            }
            else
                return agent.Update();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا شخص را انتخاب کنید.');", "ConfirmDialog");
                return;
            }

            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات ثبت با مشکل مواجه شده است');", "ConfirmDialog");
        }
    }
}