using System;
using ProjectManagement;
using pm = ProjectManagement.Item;

namespace WebProjectManagement.Forms
{
    public partial class ItemUpdate : System.Web.UI.UserControl
    {
        int ParentCode, ItemCode, ProjectCode;
        decimal totalParentSubItemPercentage,totalProjectSubItemPercentage;
        protected void Page_Load(object sender, EventArgs e)
        {

            int.TryParse(Request["ParentCode"], out ParentCode);
            int.TryParse(Request["ItemCode"], out ItemCode);
            int.TryParse(Request["ProjectCode"], out ProjectCode);

            if (!CheckPercentages() && ItemCode < 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('نمی توان آیتم جدیدی اضافه کرد.');", "ConfirmDialog");
                WebClassLibrary.JWebManager.RunClientScript("CloseDialog(null);", "closedialoge");
                return;
            }

            _SetForm();
        }

        private bool CheckPercentages()
        {
            if (ParentCode < 0 )// Main item
                return ((totalProjectSubItemPercentage=new ProjectManagement.Project.JProject(ProjectCode).GetTotalSubItemsPercentage() )< 100);
            if(ParentCode>0)// Items
                return ((totalParentSubItemPercentage=new ProjectManagement.Item.JItem(ParentCode).GetTotalSubItemsPercentage()) < 100);

            return true;
        }

        private void _SetForm()
        {
            ProjectManagement.MixedObjects.ItemAndProjectDetails i;
            if (ItemCode > 0 || ParentCode > 0)
                i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(ItemCode > 0 ? ItemCode : ParentCode,ProjectCode);
            else
                i = new ProjectManagement.MixedObjects.ItemAndProjectDetails(-1, ProjectCode);
            if(ItemCode<0 && ParentCode < 0)//add main item
            {
                FillControls(i.TotalSubItemPercentage-100 ,
                   "",
                   "",
                   i.Project.Name,
                   "0",
                   "", 0);
            }
            else if (ItemCode < 0)//Add new item 
                FillControls(i.TotalSubItemPercentage,
                   "",
                   i.Item.Name,
                   i.Project.Name,
                   "0",
                   "", 0);
            else if (ItemCode > 0 && ParentCode > 0)//Edit item
                FillControls(totalParentSubItemPercentage - i.Item.WeightPercentage,
                    i.Item.Name,
                    (i.ParentItem != null && ParentCode == i.ParentItem.Code) ? i.ParentItem.Name.ToString() : "-",
                    i.Project.Name,
                    i.Item.WeightPercentage.ToString(),
                    i.Item.ItemDescription, i.Item.WeightPercentage);
            else if (ItemCode > 0 && ParentCode < 0)//Edit Main item
                FillControls(totalProjectSubItemPercentage - i.Item.WeightPercentage,
                    i.Item.Name,
                    (i.ParentItem != null && ParentCode == i.ParentItem.Code) ? i.ParentItem.Name.ToString() : "-",
                    i.Project.Name,
                    i.Item.WeightPercentage.ToString(),
                    i.Item.ItemDescription, i.Item.WeightPercentage);
            else
                FillControls(i.TotalSubItemPercentage,
                    i.Item.Name,
                    (i.ParentItem != null && ParentCode == i.ParentItem.Code) ? i.ParentItem.Name.ToString() : "-",
                    i.Project.Name,
                    i.Item.WeightPercentage.ToString(),
                    i.Item.ItemDescription, 0);

        }

        private void FillControls(decimal totalSubItemPercentage,string name,string parentname,string projectname,string weight,string description,decimal currentedPercentage)
        {
            txtWeight.Text = totalSubItemPercentage.ToString();
            txtName.Text = name;
            txtParentNodes.Text = parentname;
            txtProjectName.Text = projectname;
            txtWeight.Text = weight;
            txtDescription.Text = description;
        }
    }
}