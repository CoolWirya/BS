using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class MoveReport : System.Web.UI.UserControl
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

            WebAVL.Controls.Search.JSearchDevice sd = ((WebAVL.Controls.Search.JSearchDevice)searchDevice);
            string imei = sd.IMEI;
            if (String.IsNullOrEmpty(imei))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(imei);
            if (device == null || device.Code < 1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('لطفا یک دستگاه را انتخاب نمایید.');", "ConfirmDialog");
                return;
            }
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            string query = string.Format(@"select  Code,Speed,DeviceSendDateTime,lat,lng,
 (LAG(LastSpeed, 1, 0) over(order by DeviceSendDateTime)) sss,
 case when(LAG(LastSpeed, 1, 0) over(order by DeviceSendDateTime)) + 1 <> LastSpeed then 1 else 0 end GroupNumber,
 0 Counter
 , ROW_NUMBER() over(order by Code)  RowID into #Temp from
                (
                    select *, ROW_NUMBER() over(partition by case when Speed < 2 then 0 else 1 end  order by DeviceSendDateTime) LastSpeed
                    from AVLCoordinate where DeviceCode = {0} and DeviceSendDateTime between '{1}' and '{1} 23:59:59'
                ) as a

                declare @Index int
                set @Index = 1
                Update #Temp set @Index=GroupNumber+@Index , Counter=@Index
				
				 <#PreviusSQL#>
                select
                MAX(Code) Code,
                Counter,
	            case when max(Speed) < 2 then N'توقف' else N'حرکت' END Comment,
                Min(DeviceSendDateTime) StartDate,
                max(DeviceSendDateTime) EndDate,
                DATEDIFF(minute, min(DeviceSendDateTime), Max(DeviceSendDateTime)) Minute,
                min(Speed) minSpeed,
                max(Speed) maxSpeed,
                (select SUM(SQRT(POWER(cast((b.lat - a.lat) as float) * 111111.1, 2) + POWER(cast((b.lng - a.lng) as float) * 111111.1 * COS(b.lat), 2))) from #temp a inner join #Temp b  on a.RowID=b.RowID-1 and a.Counter=b.Counter  where a.Counter=#temp.Counter ) Meter
               from #Temp 
                group by Counter
                having DATEDIFF(minute, min(DeviceSendDateTime), Max(DeviceSendDateTime)) > 0 and MAX(speed) > 2", device.Code,
                ((WebControllers.MainControls.Date.JDateControl)dcDate).GetDate().ToString("yyyy-MM-dd"));
            RadGridReport.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            RadGridReport.PageSize = 50;
            RadGridReport.HiddenColumns = "Code";
            RadGridReport.Title = "MoveReport";
            RadGridReport.Buttons = "excel,print,record_print";
            RadGridReport.SQL = query;
            RadGridReport.ClassName = "WebAVL.Forms.MoveReport";
            RadGridReport.ObjectCode = 0;

            RadGridReport.Actions = new List<WebClassLibrary.JActionsInfo>();
            RadGridReport.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebAVL.JWebAVL" + "._ShowMarkerOnMap", null, null));

            if (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.MoveReport.0"] != null)
            {
                try
                {
                    (WebClassLibrary.SessionManager.Current.Session["WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.MoveReport.0"] as ClassLibrary.JDataBase).Dispose();
                }
                catch
                {
                }
            }
            WebClassLibrary.SessionManager.Current.Session.Add("WebClassLibrary.JWebDataBase.GetPagerData." + "WebAVL.Forms.MoveReport.0" + ".DB", DB);

            RadGridReport.Bind();
        }
    }
}