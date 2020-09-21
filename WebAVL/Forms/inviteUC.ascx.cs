using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class inviteUC : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Panel1.Controls.Add(createGrid());
        }


        private Control createGrid()
        {
           

            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView("AVL_ObjectList");
            jGridView.Parameters = new object[] { WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode };
            jGridView.ClassName = "joined_createGridNORMAL";
            string query = @"SELECT Name,IMEI,RegisterDateTime  AS registerDate FROM AVLDevice where marketerCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            if (WebClassLibrary.SessionManager.Current.MainFrame.IsAdmin)
            {
                query = @"SELECT Name,IMEI,RegisterDateTime AS registerDate ,marketerCode FROM AVLDevice";
                jGridView.ClassName = "joined_createGrid";
            }
            jGridView.SQL = query;
            
            jGridView.Title = "دستگاه های دعوت شده";

            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();
            
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
          //  jGridView.Toolbar.AddButton("NewPassword", "اختصاص کلمه عبور جدید", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, "WebAVL.Forms.inviteUC" + "._NewPassword", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));

            //jGridView.SQLType = (int)WebControllers.MainControls.Grid.SQLTypeEnum.Query;
            jGridView.PageSize = 50;
            jGridView.Buttons = "refresh,excel,print,record_print";
            jGridView.PageOrderByField = "registerDate desc";
            jGridView.AutRefreshInterval = 60 * 1000;

            jGridView.Bind();

            return jGridView;
        }

        public string _NewPassword(string code)
        {
            return WebClassLibrary.JWebManager.LoadClientControl("_newPassword"
                   , "~/WebAVL/Forms/resetUserPassword.ascx"
                   , "اختصاص کلمه عبور جدید"
                   , new List<Tuple<string, string>>() { new Tuple<string, string>("Code", code) }
                   , WebClassLibrary.WindowTarget.NewWindow
                   , true, true, true, 430, 250, true);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            AVL.RegisterDevice.JRegisterDevice invitedDevice = new AVL.RegisterDevice.JRegisterDevice(((WebAVL.Controls.Search.JSearchDevice)searchDevice).IMEI);
            if (invitedDevice.Code < 1)
                WebClassLibrary.JWebManager.RunClientScript("alert('این دستگاه ثبت نشده است. ابتدا باید برنامه بر روی دستگاه مورد دعوت نصب شود.');", "ConfirmDialog");

            if (invitedDevice.marketerCode != 0 && invitedDevice.marketerCode != WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('این فرد توسط فرد دیگری ثبت شده است.');", "ConfirmDialog");
                return;
            }


            invitedDevice.marketerCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
            Globals.JUser u = new Globals.JUser();
            //check username
            if (u.GetData(txtusername.Text))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('این نام کاربری قبلا ثبت شده است.');", "ConfirmDialog");
                return;
            }
            u.GetData(invitedDevice.personCode);
            u.username = txtusername.Text;
            u.password = txtpassword.Text;
            u.Update();
            if (invitedDevice.Update())
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('عملیات موفق.');", "ConfirmDialog");
            }
            Panel1.Controls.Clear();
            Panel1.Controls.Add(createGrid());
        }
    }
}