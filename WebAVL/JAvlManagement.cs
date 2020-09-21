using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAVL
{
    public class JAvlManagement
    {

        public const string _ConstClassName = "WebAVL.JAvlManagement";
        public List<WebClassLibrary.JNode> GetNodes()
        {
            List<WebClassLibrary.JNode> nodes = new List<WebClassLibrary.JNode>();

            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._RegisterDevice", null, new List<object>() { }) }, "لیست دستگاه", _ConstClassName + "._RegisterDevice", WebClassLibrary.JDomains.Images.AvlManagementImages.gps_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ObjectShow", null, new List<object>() { }) }, "لیست متحرک ها", _ConstClassName + "._ObjectShow", WebClassLibrary.JDomains.Images.AvlManagementImages.Map_Marker_Marker_Outside_Pink_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._inviteothers", null, new List<object>() { }) }, "دعوت دیگران", _ConstClassName + "._inviteothers", WebClassLibrary.JDomains.Images.AvlManagementImages.Map_Marker_Marker_Outside_Pink_icon, null));
            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._sendMessage", null, new List<object>() { }) }, "ارسال پیام", _ConstClassName + "._sendMessage", WebClassLibrary.JDomains.Images.AvlManagementImages.Map_Marker_Marker_Outside_Pink_icon, null));

            nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._AddDeviceToGroup", null, new List<object>() { }) }, "اضافه کردن دستگاه به گروه", _ConstClassName + "._AddDeviceToGroup", WebClassLibrary.JDomains.Images.AvlManagementImages.Map_Marker_Marker_Outside_Pink_icon, null));
            //  nodes.Add(new WebClassLibrary.JNode(new List<WebClassLibrary.JActionsInfo>() { new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ObjectState", null, new List<object>() { }) }, "وضعیت متحرک ها", _ConstClassName + "._ObjectState", WebClassLibrary.JDomains.Images.MenuImages.Item, null));

            return nodes;
        }

        public string _AddDeviceToGroup()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_inviteothers"
                           , "~/WebAVL/Forms/addDeviceToGroup.ascx"
                           , "اضافه به گروه"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

    public string _sendMessage()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_inviteothers"
                           , "~/WebAVL/Forms/sendMessage.ascx"
                           , "ارسال پیام"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
    public string _inviteothers()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_inviteothers"
                           , "~/WebAVL/Forms/inviteUC.ascx"
                           , "دعوت دیگران"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }
        public string _ObjectState()
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_ObjectState"
                           , "~/WebAVL/Forms/ObjectState.ascx"
                           , "وضعیت متحرک ها"
                           , null
                           , WebClassLibrary.WindowTarget.NewWindow
                           , true, true, true, 600, 350, true);
        }

        public string _RegisterSubuser()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_RegisterSubuser");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_RegisterSubuserNORMAL";
            string query = @"SELECT * FROM [organizationchart] WHERE [parentcode]={0}";
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JAvlManagement._isMarketer"))
            {
                query = @"SELECT * FROM organizationchart";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_RegisterSubuser";
            }
            jGridView.SQL = query;


            jGridView.Title = "ثبت کاربر";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._RegisterNewSubuser", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            jGridView.Actions.Add(new WebClassLibrary.JActionsInfo("GridItemDblClick", WebClassLibrary.JDomains.JActionEvents.GridItemDblClick, _ConstClassName + "._SetUserObjects", null, null));
            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }
        public string _SetUserObjects(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_SetUserObjects"
                , "~/WebAVL/Forms/SubUserObjectsUpdate.ascx"
                , "متحرک های کاربر"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WebClassLibrary.WindowTarget.NewWindow
                , true, true, true, 430, 250, true);
        }
        public string _RegisterNewSubuser(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_RegisterNewSubuser"
                , "~/WebAVL/Forms/ReisterSubuserUpdate.ascx"
                , "ثبت کاربر جدید"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WebClassLibrary.WindowTarget.NewWindow
                , true, true, true, 430, 250, true);
        }

        public string _RegisterDevice()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_RegisterDevice");
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_RegisterDeviceNORMAL";
            string query = @"SELECT [Code]
              ,[IMEI]
              ,[Name]+N'('+isnull((select top 1  AVLObjectList.Label from AVLObjectList where code in ( select Objectcode from AVLDeviceObjectHistory where DeviceCode=AVLDevice.Code)),N'نامشخص')+N')' Name
              ,[LastSendDate]
              ,[lastSpeed]
              ,(select adm.Model from AVLDeviceModel adm where Code=DeviceType) DeviceType
              ,[LastLat]
              ,[LastLng]
              ,[RegisterDateTime] FROM AVLDevice WHERE  Code in (
(select ad.Code from AVLDevice ad left join AVLCash c on ad.personCode=c.userCode where c.paid>0 and ad.Code in(
SELECT jd.childDeviceCode FROM[AVLDB].[dbo].[AVLDevice] d right join 
AVLJoinDevice jd on d.Code=jd.parentDeviceCode where d.personCode in( select personCode from AVLDevice where personCode={0}))
))";

            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JAvlManagement._isMarketer"))
            {
                query += " OR 1=1";
            }
            jGridView.SQL = query;


            jGridView.Title = "Device";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Delete", "Delete", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceDelete", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Delete));
            jGridView.Toolbar.AddButton("RestKey", "RestKey", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ResetKey", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Menu_Delete));
            //    jGridView.Toolbar.AddButton("SpecifyDeviceForObject", "تخصیص به متحرک", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpecifyObjectForDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Acitvate", "فعال کردن", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ActivateObject", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Toolbar.AddButton("Deactivate", "غیرفعال کردن", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeactivateObject", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _NewDevice(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_NewDevice"
                , "~/WebAVL/Forms/DeviceUpdate.ascx"
                , "دستگاه"
                , null
                , WebClassLibrary.WindowTarget.NewWindow
                , true, true, true, 700, 450, true);
        }
        public string _DeviceUpdate(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_DeviceUpdate"
                , "~/WebAVL/Forms/DeviceUpdate.ascx"
                , "دستگاه"
                , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                , WebClassLibrary.WindowTarget.NewWindow
                , true, true, true, 730, 450, true);
        }

        public string _DeviceDelete(string code)
        {
            AVL.RegisterDevice.JRegisterDevice RD = new AVL.RegisterDevice.JRegisterDevice(int.Parse(code));
            RD.Delete();
            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');", "ConfirmDialog");
            return "";
        }

        public string _ResetKey(string code)
        {
            AVL.RegisterDevice.JRegisterDevice RD = new AVL.RegisterDevice.JRegisterDevice(int.Parse(code));
            if (RD == null || RD.Code == 0)
                return "";
            RD.keyPass = "";
            RD.Update(false);
            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');", "ConfirmDialog");
            return "";
        }

        public string _SpecifyObjectForDevice(string code)
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SpecifyObjectForDevice");

            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "تخصیص دستگاه", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpecifyDeviceForObject", null, new List<object>() { code }) });
            ////jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "Edit", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ObjectUpdate", null, null) });


            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SpecifyObjectForDeviceNORMAL";
            string query =
                @"SELECT [Code],[ObjectCode],[Label],[Type] FROM AVLObjectList WHERE personCode={0}";
            //+ WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT [Code],[ObjectCode],[Label],[Type] FROM AVLObjectList";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SpecifyObjectForDevice";
            }
            jGridView.SQL = query;

            jGridView.Title = "متحرک";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("SpecifyDeviceForObject", "تخصیص دستگاه", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpecifyDeviceForObject", null, new List<object>() { code }), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            //jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._ObjectUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }

        public void _SpecifyDeviceForObject(string DeviceCode, string ObjectCode)
        {
            AVL.RegisterDevice.JRegisterDevice o = new AVL.RegisterDevice.JRegisterDevice(int.Parse(DeviceCode));
            AVL.ObjectList.JObjectList ol = new AVL.ObjectList.JObjectList(int.Parse(ObjectCode), WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            o.ObjectCode = ol.Code;

            if (o.Update(true))
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');GetRadWindow().close();", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق.');", "ConfirmDialog");
            WebClassLibrary.JWebManager.CloseWindow();
        }

        public string _ObjectShow()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));

            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "تخصیص دستگاه", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpecifyDevice", null, null) });


            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_ObjectShowNORMAL";
            string query =
                @"SELECT [Code]
      ,[RegisterDateTime]
      ,[Type]
      ,[Label]
      ,[personCode]
      FROM AVLObjectList WHERE personCode={0}";
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin || ClassLibrary.JPermission.CheckPermission("WebAVL.JAvlManagement._isMarketer"))
            {
                query += " OR 1=1";
                //query = @"SELECT * FROM AVLObjectList ";
                //jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_ObjectShow";
            }
            jGridView.SQL = query;

            jGridView.Title = "متحرک";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
           // jGridView.Toolbar.AddButton("SpecifyDevice", "تخصیص دستگاه", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._SpecifyDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
         
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }

        public string _ActivateObject(string Code)
        {
            AVL.RegisterDevice.JRegisterDevice ol = new AVL.RegisterDevice.JRegisterDevice(int.Parse(Code));
            if (!ol.isPaid)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('فاکتور این دستگاه را پرداخت نکرده اید.بعد از پرداخت دستگاه فعال خواهد شد.');", "ConfirmDialog");
                return "";
            }
            ol.active = true;
            if (ol.Update(true, false))
            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');", "ConfirmDialog");
            return "";
        }

        public string _DeactivateObject(string Code)
        {
            AVL.RegisterDevice.JRegisterDevice ol = new AVL.RegisterDevice.JRegisterDevice(int.Parse(Code));
            ol.active = false;
            if(ol.Update(true,false))
            WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');", "ConfirmDialog");
            return "";
        }
        public string _SpecifyDevice(string AVLObjectItemObjectCode)
        {

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_") + "_SpecifyDevice");

            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
            //jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "تخصیص دستگاه", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._UpdateSelectedDevice", null, new List<object>() { AVLObjectItemObjectCode }) });
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SpecifyDeviceNORMAL";
            string query =
                @"SELECT [Code]
      ,[IMEI]
      ,[RegisterDateTime]
      ,[personCode]
      ,[speed]
      ,[Factory]
      ,[Model]
      ,[OSVersion]
      ,[Name] FROM AVLDevice WHERE personCode={0}";
            // +WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT * FROM AVLDevice ";
                jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_SpecifyDevice";
            }
            jGridView.SQL = query;

            jGridView.Title = "لیست دستگاه ها";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            jGridView.Toolbar.AddButton("UpdateSelectedDevice", "تخصیص دستگاه", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._UpdateSelectedDevice", null, new List<object>() { AVLObjectItemObjectCode }), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);

        }


        public void _UpdateSelectedDevice(string AVLObjectItemObjectCode, string code)
        {
            AVL.RegisterDevice.JRegisterDevice o = new AVL.RegisterDevice.JRegisterDevice(int.Parse(code));
            AVL.ObjectList.JObjectList ol = new AVL.ObjectList.JObjectList(int.Parse(AVLObjectItemObjectCode), WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode);
            o.ObjectCode = ol.Code;

            if (o.Update(true))
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات با موفقیت انجام شد.');GetRadWindow().close();", "ConfirmDialog");
            else
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات نا موفق.');", "ConfirmDialog");
            WebClassLibrary.JWebManager.CloseWindow();
        }

    }
}