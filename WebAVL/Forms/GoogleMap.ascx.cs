using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
	public partial class GoogleMap : System.Web.UI.UserControl
	{
		int code = 1;

        private Control createGrid()
		{
            
			string query = @"SELECT d.[Code]
						  ,d.[LastSendDate] 
						  ,d.[Name]
						  , (select     max(speed) from AVLCoordinate  where  DeviceSendDateTime BETWEEN DATEADD(day,-1,getdate()) AND getdate() and DeviceCode=d.Code ) as MaxSpeed
						  ,d.[IMEI]
						  ,d.[lastSpeed]
						  ,d.[RegisterDateTime]
						   FROM AVLJoinDevice jd 
 join AVLDevice  d2 on jd.parentDeviceCode=d2.Code
inner join AVLDevice d on d.Code=jd.childDeviceCode
 WHERE  d2.personCode={0}
 group by d.Code,d.[LastSendDate],d.[Name],d.[IMEI],d.[lastSpeed],d.[RegisterDateTime]";
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JWebAVL._isMarketer"))
            {
                query = @"SELECT [Code]
					  ,[LastSendDate]
					  ,[Name]
						  , (select     max(speed) from AVLCoordinate  where  DeviceSendDateTime BETWEEN DATEADD(day,-1,getdate()) AND getdate() and DeviceCode=Code ) as MaxSpeed
					
					  ,[IMEI]
					  ,[lastSpeed]
					  ,[RegisterDateTime] FROM AVLDevice  ";
            }

			WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("AVL_ObjectList");
			jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
			jGridView.ClassName = "WebAVL_Forms_GoogleMap_createGridNORMAL";
			jGridView.SQL = query;

			jGridView.Title = "متحرک";

			jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
			jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, "WebAVL.Forms.GoogleMap._ShowObject", null, null));

			jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();

			//jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
			jGridView.PageSize = 10;
			jGridView.Buttons = "refresh,excel,print,record_print";
			jGridView.PageOrderByField = "LastSendDate desc";
            jGridView.AutRefreshInterval = 60*1000;

			jGridView.Bind();

			return jGridView;
		}


		public string _ShowObject(string code)
		{
			if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null &&
				WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"].ToString() == code)
				WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = "";
			else
				WebClassLibrary.SessionManager.Current.Session.Add("OnlineMapCenter", code);
			return "";
		}

		protected void Page_Load(object sender, EventArgs e)
		{
			/*
			 * 
			 * To show different icon for each object(related to its type - car , person ... -)
			 * needs a method named GetIcon
			 * 
			 */
			if (WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] != null)
				WebClassLibrary.SessionManager.Current.Session["FirstLoadMad"] = null;
			if (WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] != null)
				WebClassLibrary.SessionManager.Current.Session["OnlineMapCenter"] = null;
            WebClassLibrary.SessionManager.Current.Session["SesionObjects"] = null;
            WebClassLibrary.SessionManager.Current.Session["Series"] = null;
            if (!Page.IsPostBack)
			{
                //togglepanel.Controls.Add(createGrid());
                pnldevices.Controls.Add(createGrid());
				code = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;// int.Parse(Request["code"].ToString());
			}
		}

        public string TodayOnlineIcon
        {
            get
            {
                return "/WebAVL/Icons/PersonMarker_red.png";
            }
        }
        public string PastOnlineIcon
        {
            get
            {
                return "/WebAVL/Icons/PersonMarker.png";
            }
        }

        protected void lsbDefaltObjects_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		protected void Button1_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx?f=d");
		}
	}
}
