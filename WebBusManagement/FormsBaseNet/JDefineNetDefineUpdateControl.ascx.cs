using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebBaseNet.EventNet;
using ClassLibrary;
using WebBaseNet.BaseNet;


namespace WebBusManagement.FormsBaseNet
{
    public partial class JDefineNetDefineUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
                LoadGroup();
                LoadPlace();
                if (Code > 0)
                {
                    WebBaseNet.BaseNet.JDefineNet DN = new JDefineNet(Code);
                    cmbGroup.SelectedValue = DN.GroupCode.ToString();
                    txtDefineName.Text = DN.DefineName;
                    txtDefineValue.Text = DN.DefineValue.ToString();
                    cmbDefineType.SelectedValue = DN.DefineType.ToString();
                    cmbPlace.SelectedValue = DN.PlaceCode.ToString();
                }
            }

        }
        public bool Save()
        {
            WebBaseNet.BaseNet.JDefineNet DN = new JDefineNet();
            if (Code > 0)
                DN.GetData(Code);
            DN.GroupCode = int.Parse(cmbGroup.SelectedItem.Value);
            DN.DefineName = txtDefineName.Text;
            DN.DefineValue = int.Parse(txtDefineValue.Text);
            DN.DefineType = int.Parse(cmbDefineType.SelectedItem.Value);
            DN.PlaceCode = int.Parse(cmbPlace.SelectedItem.Value);
            if (Code != 0)
                return DN.Update();
            else
            {
                Code = DN.Insert();
                return Code > 0;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Save())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
        }

        public void LoadGroup()
        {
            DataTable dt = ClassLibrary.JSubBaseDefines.GetDataTable(ClassLibrary.JBaseDefine.GroupNetType);
            cmbGroup.DataSource = dt;
            cmbGroup.DataTextField = "Name";
            cmbGroup.DataValueField = "Code";
            cmbGroup.DataBind();
        }

        public void LoadPlace()
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery(@"SELECT a.[Code],a.[Name] FROM [dbo].[AUTBusEventPlace] a");
                DataTable dt = db.Query_DataTable();
                cmbPlace.DataSource = dt;
                cmbPlace.DataTextField = "Name";
                cmbPlace.DataValueField = "Code";
                cmbPlace.DataBind();
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}


      
      
    
     