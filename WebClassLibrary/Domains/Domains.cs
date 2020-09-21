using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebClassLibrary
{
	[Serializable()]
	public class JDomains
	{
		[Serializable()]
		public static class JConsts
		{
			public static string SepEquals = "[J===]";
			public static string SepComma = "[J,,,]";
			public static string SepColon = "[J:::]";
			public static string SepEvents = "[J|||]";
		}
		[Serializable()]
		public class Images
		{
			public const string Root = "~/";
			public static string GetFullPath(string file)
			{
				return Root + file;
			}
			[Serializable()]
			public class MenuImages
			{
				public const string Folder = "images/MainMenu/menu_folder.png";
				public const string Item = "images/MainMenu/menu_item.png";
				public const string LogOut = "images/MainMenu/logout.png";
				public const string BusManagmentBus = "images/MainMenu/bus-icon.png";
				public const string BusManagmentBusLine = "images/MainMenu/BusLine-icon.png";
				public const string BusManagmentBusStation = "images/MainMenu/BusStation-icon.png";
				public const string BusManagmentMap = "images/MainMenu/Map-icon.png";
				public const string BusManagmentPerson = "images/MainMenu/Person-icon.png";
				public const string BusManagmentReport = "images/MainMenu/report-icon.png";
				public const string BusManagmentTicket = "images/MainMenu/ticket-icon.png";
				public const string BusManagmentZone = "images/MainMenu/zone-icon.png";
				public const string BusManagmentDefine = "images/MainMenu/define-icon.png";
				public const string BusManagmentTarrif = "images/MainMenu/Tarrif-icon.png";
				public const string BusManagmentFleet = "images/MainMenu/fleet-icon.png";
				public const string Setting = "~/WebControllers/MainControls/Configuration/Images/Settings.png";
			}
			[Serializable()]
			public class GridViewImages
			{
				public const string GridView_Refresh = "images/Controls/gridview_refresh.png";
				public const string GridView_Print = "images/Controls/gridview_print.png";
				public const string GridView_RecordPrint = "images/Controls/gridview_print_NX.png";
				public const string GridView_PDF = "images/Controls/gridview_pdf.png";
				public const string GridView_Excel = "images/Controls/gridview_excel.png";
				public const string GridView_Word = "images/Controls/gridview_word.png";
				public const string GridView_CSV = "images/Controls/gridview_csv.png";
				public const string GridView_FormManagers = "images/Controls/gridview_formmanagers.png";
				public const string GridView_Forms = "images/Controls/gridview_forms.png";
				public const string GridView_Help = "images/Controls/gridview_help.png";
                public const string GridView_RightClick = "images/Controls/gridview_help.png";
            }
			[Serializable()]
			public class ControlImages
			{
				public const string Toolbar_Add = "images/Controls/toolbar_add.png";
				public const string Toolbar_Delete = "images/Controls/toolbar_delete.png";
				public const string Toolbar_Edit = "images/Controls/toolbar_edit.png";
				public const string Toolbar_Button = "images/Controls/free_button.png";
				public const string Toolbar_Report = "images/Controls/toolbar_report.png";
				public const string Menu_Add = "images/Controls/menu_add.png";
				public const string Menu_Delete = "images/Controls/menu_delete.png";
				public const string Menu_Edit = "images/Controls/menu_edit.png";
				public const string Menu_Button = "images/Controls/free_menu.png";
				public const string Inbox = "images/Controls/inbox.png";
				public const string Outbox = "images/Controls/outbox.png";
				public const string MailRead = "images/Controls/read.png";
				public const string MailUnread = "images/Controls/unread.png";
				public const string MailNewUnread = "images/Controls/new_unread.png";
				public const string Open = "images/Controls/open.png";
                public const string NoPersonImage = "images/Controls/nopersonimage.png";
                public const string NoCar = "images/Controls/NoCar.png";
                public const string NoStation = "images/Controls/NoStation.png";
				public const string Calendar = "images/Controls/Calendar.gif";
			}

            [Serializable()]

            public class AvlManagementImages
            {
                public const string gps_icon = "images/icons/gps-icon.png";
                public const string Sales_report_icon = "images/icons/Sales-report-icon.png";
                public const string Car_icon = "images/icons/Car-icon.png";
                public const string app_map_icon = "images/icons/app-map-icon.png";
                public const string Map_Marker_Marker_Outside_Pink_icon = "images/icons/Map-Marker-Marker-Outside-Pink-icon.png";
                public const string Maps_icon = "images/icons/Maps-icon.png";
                public const string Person_Male_Light_icon = "images/icons/Person-Male-Light-icon.png";
                public const string Cash_register_icon = "images/icons/Cash-register-icon.png";
                public const string Home_icon = "images/icons/Home-icon.png";
                public const string modify_key_icon = "images/icons/modify-key-icon.png";
            }
        }
		[Serializable()]
		public enum JActionEvents
		{
			MouseClick,
			MouseDBClick,
			MouseRightClick,
			GridItemClick,
			GridItemDblClick,
			GridItemRightClick
		}
		[Serializable()]
		public enum JControls
		{
			None,
			JGridView,
			JUserControl,
			DataGridView
		}
		[Serializable()]
		public class JErrorUrl
		{
			public const string UserNotAuthenticated = "~/Error.aspx?err=1";
		}
	}
}
