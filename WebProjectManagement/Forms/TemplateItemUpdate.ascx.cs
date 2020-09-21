using System;
using ProjectManagement;

namespace WebProjectManagement.Forms
{
    public partial class TemplateItemUpdate : System.Web.UI.UserControl
    {
        int templateCode,code, ParentCode;
        ProjectManagement.TemplateItem.JTemplateItem i;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["TemplateCode"],out templateCode);
            int.TryParse(Request["ItemCode"], out code);
            int.TryParse(Request["ParentCode"], out ParentCode);

            if (code > 0)
                SetForm();
        }

        private void SetForm()
        {
            i= new ProjectManagement.TemplateItem.JTemplateItem(code);
            if(i.Code<1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('آیتم مورد نظر یافت نشد.');", "ConfirmDialog");
                return;
            }
            txtName.Text = i.Name;
            txtWeight.Text = i.WeightPercentage.ToString();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (txtWeight.Text.ContainsNonDigit())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('برای وزن فقط عدد باید وارد کرد.');", "ConfirmDialog");
                return;
            }
            System.Collections.Generic.List<ProjectManagement.TemplateItem.JTemplateItem> children = null;
              
            decimal possibleWieght,prevWeight=-1;
            if (i == null)
            {
                i = new ProjectManagement.TemplateItem.JTemplateItem();
                i.ParentItemCode = ParentCode;
                i.TemplateCode = templateCode;
            }
            else
            {
                if (i.WeightPercentage != txtWeight.Text.ToDecimal())
                {
                    children = new System.Collections.Generic.List<ProjectManagement.TemplateItem.JTemplateItem>();
                    System.Data.DataTable dt = ProjectManagement.TemplateItem.JTemplateItems.GetDataTable(i.TemplateCode, i.Code);
                    foreach (System.Data.DataRow dr in dt.Rows)
                        children.Add(ProjectManagement.TemplateItem.JTemplateItem.Create(dr));
                    prevWeight = i.WeightPercentage;
                }
            }
            ProjectManagement.TemplateItem.JTemplateItem parent = new ProjectManagement.TemplateItem.JTemplateItem(ParentCode);
            if (parent.Name == null || parent.WeightPercentage == 0)
            {
                ProjectManagement.Template.JTemplate p = new ProjectManagement.Template.JTemplate(i.TemplateCode);
                possibleWieght =p.TotalWeight - p.TotalFilledWeight;
                if (possibleWieght < 0) possibleWieght = 0;
            }
            else
                possibleWieght = parent.WeightPercentage - (parent.FindTotalSubItemWeight() - i.WeightPercentage);
            if ( (possibleWieght) < txtWeight.Text.ToDecimal())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('وزن باید کمتر از " + possibleWieght + " باشد .');", "ConfirmDialog");
                return;
            }
            i.Name = txtName.Text;
            i.WeightPercentage = txtWeight.Text.ToDecimal();
            bool succeed = false;
            if (code > 0) succeed = i.Update();
            else succeed = i.Insert() > 0;
            if (succeed)
            {
                if (prevWeight > -1)
                {
                    foreach (ProjectManagement.TemplateItem.JTemplateItem t in children)
                    {
                        t.WeightPercentage = i.WeightPercentage * t.WeightPercentage / prevWeight;
                        t.Update();
                    }
                }
                //    WebClassLibrary.JWebManager.RunClientScript("alert('آیتم ثبت شد.');", "ConfirmDialog");
                WebClassLibrary.JWebManager.RunClientScript("GetRadWindow().close();", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در عملیات.');", "ConfirmDialog");

        }
    }
}