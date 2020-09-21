using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class JStopReport : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
            }
            else
            {
                ((WebControllers.MainControls.Date.JDateControl)dcDate).SetDate(DateTime.Now);
            }
        }

     

        protected void btnSave_Click(object sender, EventArgs e)
        {
           WebAVL.Controls.Search.JSearchDevice sd=((WebAVL.Controls.Search.JSearchDevice)searchDevice);
            string imei =sd.IMEI;
            if (String.IsNullOrEmpty(imei))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(imei);
            if (device==null || device.Code<1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            
            string Query = (@"
                select *,(LAG(LastSpeed,1,0) over(order by DeviceSendDateTime)) sss,case when  (LAG(LastSpeed,1,0) over(order by DeviceSendDateTime))+1<>LastSpeed then 1 else 0 end GroupNumber,0 Counter into #Temp from
                (
                    select *,ROW_NUMBER() over(partition by case when Speed <2 then 0 else 1 end  order by DeviceSendDateTime) LastSpeed 
                    from AVLCoordinate where DeviceCode={0} and DeviceSendDateTime between '{1}' and '{2} 23:59:59'
                ) as a
     ");
            Query = string.Format(Query, device.Code, // cmbDevice.SelectedValue,
                ((WebControllers.MainControls.Date.JDateControl)dcDate).GetDate().ToString("yyyy-MM-dd"),
                ((WebControllers.MainControls.Date.JDateControl)dcDate).GetDate().ToString("yyyy-MM-dd"));
        ////  DB.setQuery(Query);
       //   DB.Query_Execute();

            Query+= (@"
                declare @Index int
                set @Index=1
                Update #Temp set @Index=GroupNumber+@Index , Counter=@Index

    <#PreviusSQL#>
            ");
     //   DB.setQuery(Query);
      //   DB.Query_Execute();

            Query += (@"
            select 
                Min(Code) Code,
                Counter,
	            case when max(Speed) < 2 then N'توقف' else N'حرکت' END Comment,
	            Min(DeviceSendDateTime) StartDate,
	            max(DeviceSendDateTime) EndDate,
	            DATEDIFF(minute,min(DeviceSendDateTime),Max(DeviceSendDateTime)) Minute,
	            min(Speed) minSpeed,
	            max(Speed) maxSpeed
                from #Temp 
                group by Counter 
                having DATEDIFF(minute,min(DeviceSendDateTime),	Max(DeviceSendDateTime))>0 and MAX(speed)<2
            ");

            RadGridReport.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            RadGridReport.PageSize = 50;
            RadGridReport.HiddenColumns = "Code";
            RadGridReport.Title = "StopReport";
            RadGridReport.Buttons = "excel,print,record_print";
            RadGridReport.SQL = Query;
            RadGridReport.ClassName = "WebAVL.Forms.JStopReport";
            RadGridReport.ObjectCode = 0;
            RadGridReport.Actions = new List<WebClassLibrary.JActionsInfo>();
            RadGridReport.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebAVL.JWebAVL" + "._ShowMarkerOnMap", null, null));

            if (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0"] !=null)
            {
                try
                {
                    (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0"] as ClassLibrary.JDataBase).Dispose();
                }
                catch
                {
                }
            }
            WebClassLibrary.SessionManager.Current.Session.Add("WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.JStopReport.0" + ".DB", DB);
           // RadGridReport.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            //RadGridReport.DataBind();
          RadGridReport.Bind();
        }
    }
}