using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;
using Communication;
using Globals;

namespace Automation
{
    public partial class JSendType : Globals.JBaseForm
    {
        private int _Refer_Code;
        public JSendType(int pRefer_Code)
        {
            InitializeComponent();
            _Refer_Code=pRefer_Code;
            //----------------- انواع ارسال برای گیرنده سازمان خارج از لیست-----------------
            cmbSendTypeExternal.DisplayMember = "name";
            cmbSendTypeExternal.ValueMember = "value";
            cmbSendTypeExternal.DataSource = ClassLibrary.Domains.JCommunication.JSendType.GetData();
            cmbSendTypeExternal.SelectedValue = ClassLibrary.Domains.JCommunication.JSendType.Email;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            JARefer tmpRefer=new JARefer();
            tmpRefer.GetData(_Refer_Code);
            JAExternalRefer tmp = new JAExternalRefer();
            tmp.ConfirmReceiver = false;
            tmp.Send_Type = Convert.ToInt32(cmbSendTypeExternal.SelectedValue);
            tmp.Refer_Code=_Refer_Code;
            tmp.receiver_external_code=tmpRefer.receiver_External_code;
            tmp.receiver_full_title=tmpRefer.receiver_full_title;
            tmp.Description=txtDesc.Text;
            if(tmp.Insert()>0)
                JMessages.Message("Register Successfully ", "Register", JMessageType.Information);
            else
                JMessages.Message("Register Not Successfully ", "Register", JMessageType.Information);

        }

        private void JSendType_Load(object sender, EventArgs e)
        {

        }

        private void cmbSendTypeExternal_SelectedIndexChanged(object sender, EventArgs e)
        {
            JARefer tmpRefer = new JARefer();
            tmpRefer.GetData(_Refer_Code);
            if (tmpRefer.receiver_External_code != 0)
            {
                JOrganization tmporg=new JOrganization(tmpRefer.receiver_External_code);
                if(Convert.ToInt32(cmbSendTypeExternal.SelectedValue) == ClassLibrary.Domains.JCommunication.JSendType.Fax)
                    txtDesc.Text = tmporg.Address.Fax;
                else if  (Convert.ToInt32(cmbSendTypeExternal.SelectedValue) == ClassLibrary.Domains.JCommunication.JSendType.Email)
                    txtDesc.Text = tmporg.Address.Email;
                else if  (Convert.ToInt32(cmbSendTypeExternal.SelectedValue) == ClassLibrary.Domains.JCommunication.JSendType.Server)
                    txtDesc.Text = tmporg.ConnectionString;
                else 
                    txtDesc.Text = tmporg.Address.Address;
            }
        }
    }
}
