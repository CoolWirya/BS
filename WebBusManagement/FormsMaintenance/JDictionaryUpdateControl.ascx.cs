using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JDictionaryUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            Int32.TryParse(Request["Code"], out Code);

            if (!IsPostBack)
                LoadWord();
        }

        void LoadWord() 
        {
            if (Code > 0)
            {
                BusManagment.Dictionary.JDictionary Dictionary = new BusManagment.Dictionary.JDictionary(Code);
                txtName.Text = Dictionary.Name;
                txtText.Text = Dictionary.Text;
                cmbLang.SelectedValue = Dictionary.Lang;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.RunClientScript("alert('ثبت با موفقیت انجام شد');", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('عبارت شما تکراری است');", "ConfirmDialog");
        }

        bool Save() 
        {
            if (Code > 0)
            {
                BusManagment.Dictionary.JDictionary Dictionary = new BusManagment.Dictionary.JDictionary(Code);
                Dictionary.Name = txtName.Text;
                Dictionary.Text = txtText.Text;
                Dictionary.Lang = cmbLang.SelectedValue;
                if (Dictionary.Update())
                    return true;
                else
                    return false;
            }
            else  //Code == 0
            {
                BusManagment.Dictionary.JDictionary Dictionary = new BusManagment.Dictionary.JDictionary();
                Dictionary.Name = txtName.Text;
                Dictionary.Text = txtText.Text;
                Dictionary.Lang = cmbLang.SelectedValue;
                if (Dictionary.Insert())
                    return true;
                else
                    return false;
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Delete())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        bool Delete()
        {
            if (Code > 0)
            {
                BusManagment.Dictionary.JDictionary Dictionary = new BusManagment.Dictionary.JDictionary(Code);
                if (Dictionary.Delete())
                    return true;
                else
                    return false;
            }
            else  //Code == 0
                return false;
        }
    }
}