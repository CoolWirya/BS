using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JDriversUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
             int.TryParse(Request["Code"], out Code);
             if (!IsPostBack)
             {
                 ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = 0;
                 ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "select Code,RfidNumber Title from cards where pcode <> 11000003";
                 _SetForm();
             }
        }

        public void _SetForm()
        {
            if(Code > 0)
            {
                Employment.JEmployeeInfo EmpEmployee = new Employment.JEmployeeInfo();
                EmpEmployee.Code = Code;
                EmpEmployee.GetData(Code);
                ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode = Convert.ToInt32(EmpEmployee.pCode);
                txtPersonNumber.Text = EmpEmployee.PersonNumber.ToString();
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code = EmpEmployee.PersonCart;
                ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).SQL = "select Code,RfidNumber Title from cards where pcode <> 11000003";
            }
        }

        public bool Save()
        {
            Employment.JEmployeeInfo EmpEmployee = new Employment.JEmployeeInfo();
            EmpEmployee.Code = Code;
            EmpEmployee.pCode = ((WebControllers.MainControls.JSearchPersonControl)JSearchPersonControl).PersonCode;
            EmpEmployee.PersonNumber = Convert.ToInt32(txtPersonNumber.Text);
            EmpEmployee.PersonCart = ((WebControllers.MainControls.JCustomListSelectorControl)JCustomListSelectorControlDevice).Code;
            if(Code > 0)
            {
                return EmpEmployee.Update(true);
            }
            else
            {
                return EmpEmployee.Insert(true) > 0 ? true : false;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت انجام است');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            Employment.JEmployeeInfo EmpEmployee = new Employment.JEmployeeInfo();
            EmpEmployee.Code = Code;
            if(EmpEmployee.Delete(true))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت انجام است');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
    }
}