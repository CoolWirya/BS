using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebBaseNet.FormsBaseNet   
{
    public partial class JBaseNetDefineUpdateControl : System.Web.UI.UserControl 
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //LoadBus();
            }
            else
            {
                //btnSave_Click(null, null);
               // LoadBus();
            }
        }

        //public void LoadBus()
        //{
        //    DataTable dt = BusManagment.Bus.JBuses.GetAllBusesOnly();
        //    cmbBus.DataSource = dt;
        //    cmbBus.DataTextField = "BUSNumber";
        //    cmbBus.DataValueField = "Code";
        //    cmbBus.DataBind();
            
        //}


//        public void GetReport(int BusCode = 0)
//        {
//            WebControllers.MainControls.Grid.JGridView jGridView = RadGridReport; //("WebBusMaintenance_JBusFailureIMEIReportControl");
//            jGridView.ClassName = "WebBusManagement_FormsBaseNet_JBusNetDefineUpdateControl_" + BusCode.ToString();

//            jGridView.SQL = @"Select * from BaseNet";

////                select Query.code, case when a.Status is null then N'ارسال نشده' else cast(a.Status as nvarchar) end Status, a.InsertDate from AUTConsoleQueryAuto Query
////                left join 
////                (
////                    select QueryCode, Status, 
////                    case when Status = 2 then InsertDate else null end InsertDate
////                    from AUTConsoleQuerySendStatus BusQuery
////                    inner join AUTBus bus on bus.BUSNumber = BusQuery.BusNumber
////
////                    where bus.Code = " + BusCode + @"
////                ) a on Query.code = a.QueryCode
////                left join AUTBus bus on bus.code = Query.BusCode
////                where Query.BusCode = " + BusCode + @" or (isnull(Query.BusCode, 0) = 0 and (isnull(Query.LineNumber, -1) = -1 or Query.LineNumber = bus.LastLineNumber) )
////                group by Query.code, a.Status, a.InsertDate";

                                         
                 
// //where 1 = 1   " + WhereStrAnd + @"
//// group by QueryCode"


//            jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
//            jGridView.PageSize = 50;
//            jGridView.PageOrderByField = " code";
//            jGridView.Title = "JBusNetDefineUpdateControl";
//            jGridView.Bind();

//        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //GetReport(Convert.ToInt32(cmbBus.SelectedValue));
        }
    }
}