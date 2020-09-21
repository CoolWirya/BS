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
using WebClassLibrary;


namespace WebBusManagement.FormsBaseNet  
{
    public partial class JBusNetGroup : System.Web.UI.UserControl  
    {
         int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
             int.TryParse(Request["Code"], out Code);
            if (!IsPostBack)
            {
               

            }
          
            LoadGroupNetGrid();
          
        }
        public bool Save()
        {
            //BusManagment.WorkOrder.JHokmeKar HokmeKar = new BusManagment.WorkOrder.JHokmeKar();
            //HokmeKar.Code = Code;
            return true;
            //  if (Code > 0)
            // return HokmeKar.Update(true);
            //  else
            //return HokmeKar.Insert(true) > 0 ? true : false;
        }

        public void LoadGroupNetGrid() 
        {

            DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"select Code N'کد',Name N'نام گروه' from autnetgroup
                                                                           
	                                                                        WHERE Code = " + Code + @"
                                                                        )");
            RadGridReport.DataSource = Dt;
            RadGridReport.DataBind();
        }

        protected void BtnReport_Click(object sender, EventArgs e) 
        {

            try
            {
                if (txtnameGroup.Text == "")
                {
                    GetReport(0, Convert.ToString(txtnameGroup.Text));
                }
                else
                {
                    GetReport(0, Convert.ToString(txtnameGroup.Text));
                }
            }
            catch { }
           

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (Save())
            {
                //ClearForm();
                //WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                //WebClassLibrary.JWebManager.CloseAndRefresh();
            }
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");



            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            //WebBaseNet.BaseNet.JGroupNet en = new JGroupNet();
            //en.Name = txtnameGroup.Text;

            int EVCode = 0;
            int.TryParse(hidEditCode.Value, out EVCode);
            //en.Code = EVCode;

            if (EVCode <= 0)
            {
                //EVCode = en.Insert(true);
                if (EVCode > 0)
                {
                  //  ClearForm();
                    LoadGroupNetGrid();
                    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                }
                else
                    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
            else
            {
               // if (en.Update(true))
                //{
                //   // ClearForm();
                //    LoadGroupNetGrid();
                //    WebClassLibrary.JWebManager.RunClientScript("alert('تغییرات با موفقیت ثبت شد');", "ConfirmDialog");
                //}
                //else
                //    WebClassLibrary.JWebManager.RunClientScript("alert('خطا در انجام عملیات');", "ConfirmDialog");
            }
            //}
           
        }

        public void GetReport(int BusCode = 0,string name="")
        {
            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusFailureIMEIReportControl");
            jGridView.ClassName = "WebBusManagement_FormsBaseNet_JBusNetGroup_" + BusCode.ToString();

            jGridView.SQL = @"Select * from autnetgroup";

//              


            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
           
            jGridView.Buttons = "excel,print,record_print,refresh";
            jGridView.PageSize = 50;
            jGridView.PageOrderByField = " code";
            jGridView.Title = "JBusNetGroup";
            jGridView.Bind();

        }

       
        protected void BaseNetDefineTab_TabClick(object sender, Telerik.Web.UI.RadTabStripEventArgs e)
        {
            switch (e.Tab.PageViewID)
            {
                case "rpvLetterInfo":
                  

                    break;
                case "rpvArchive":

              
                    break;
                case "rpvRefer":

              
                    break;
                case "Delivery":

                 
                    break;

            }
        }
    }
}


      
      
    
     