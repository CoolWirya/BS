using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Globals;
namespace Automation
{
    public partial class JfrmReferSecretariat : Globals.JBaseForm
    {
        public JfrmReferSecretariat()
        {
            InitializeComponent();

            DataTable dt = new DataTable();
            //JPermissionDefineClass tmpJPermissionDefineClass=new JPermissionDefineClass();
            //dt = tmpJPermissionDefineClass.User_PermissionList(JMainFrame.CurrentUserCode, "ClassLibrary.JPermissionSetUserForm", "");
            
            DataView dv = new DataView(dt);
            dv.RowFilter = "parentcode = 0";           
            cmbSecretariat.DataSource = dv;
            cmbSecretariat.DisplayMember = "receiver_full_title";
            cmbSecretariat.ValueMember = "ID";
            //cmbSecretariat.SelectedValue = ClassLibrary.Domains.JGlobal.JPrivacy.Normal;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            //int receiver_code;
            //int receiver_post_code;
            //string receiver_full_title;
            //receiver_code=Convert.ToInt32(((System.Data.DataRow)(cmbSecretariat.SelectedItem)).ItemArray[9]);
            //receiver_post_code=Convert.ToInt32(((System.Data.DataRow)(cmbSecretariat.SelectedItem)).ItemArray[10]);
            //receiver_full_title = ((System.Data.DataRow)(cmbSecretariat.SelectedItem)).ItemArray[11].ToString();

           //JfrmLetterRegisterImport y=new JfrmLetterRegisterImport();
            //cmbReceiveType
            //if (_externalcode != 0)
            //{
            //    JAObject tmpObject = new JAObject();
            //    tmpObject.objecttype = _objecttype;
            //    tmpObject.action = _action;
            //    tmpObject.externalcode = _externalcode;
            //    tmpObject.sender_post_code = 1;
            //    tmpObject.sender_user_code = 1;
            //    tmpObject.sender_full_title = "";
            //    tmpObject.create_date_time = JDataBase.GetSqlDateTime();
            //    if (_objecttype == ClassLibrary.Domains.JAutomation.JObjectType.Letters)
            //    {
            //        tmpObject.title = JLanguages._Text("Letters");
            //    }
            //    else if (_objecttype == ClassLibrary.Domains.JAutomation.JObjectType.Employment)
            //    {
            //        tmpObject.title = JLanguages._Text("Employment");
            //    }
            //    tmpObject.description = "";
            //    _object_code = tmpObject.Insert();
            //}

            //JARefer tmprefer = new JARefer();
            //tmprefer.object_code = _object_code;
            //if (_parent_code != 0)
            //    tmprefer.parent_code = _parent_code;
            //tmprefer.task_code = 0;
            //tmprefer.refertype = Convert.ToInt32(dr["refertype"]);
            //tmprefer.sender_post_code = 1;
            //tmprefer.sender_code = 1;
            //tmprefer.sender_full_title = "";
            //tmprefer.send_date_time = JDataBase.GetSqlDateTime();
            //tmprefer.receiver_post_code = receiver_post_code;
            //tmprefer.receiver_code = receiver_code;
            //tmprefer.receiver_full_title = receiver_full_title;
            //tmprefer.status = ClassLibrary.Domains.JAutomation.JReferStatus.Current;
            //tmprefer.secret_level = Convert.ToInt32(dr["secret_level"]);
            //if (!String.IsNullOrEmpty(dr["response_date_time"].ToString()))
            //    tmprefer.response_date_time = Convert.ToDateTime(dr["response_date_time"]);
            ////tmprefer.view_date_time=null;
            //tmprefer.is_active = true;
            //if (!String.IsNullOrEmpty(dr["respite_date_time"].ToString()))
            //    tmprefer.respite_date_time = Convert.ToDateTime(dr["respite_date_time"]);
            //tmprefer.urgency = Convert.ToInt32(dr["urgency"]);
            //tmprefer.message = dr["massage"].ToString();
            //tmprefer.message_secret = dr["message_secret"].ToString();
            //tmprefer.response = dr["response"].ToString();
            //tmprefer.response_secret = dr["response_secret"].ToString();
            //tmprefer.description = dr["Description"].ToString();
            //tmprefer.Insert();

        }

        private void JfrmReferSecretariat_Load(object sender, EventArgs e)
        {

        }


    }
}
