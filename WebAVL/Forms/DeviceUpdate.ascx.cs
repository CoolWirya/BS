using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAVL.Forms
{
    public partial class DeviceUpdate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = "دستگاه";
            int Code = 0;
            int.TryParse(Request["Code"], out Code);

            if (Code > 0)
            {
                try
                {
                    AVL.RegisterDevice.JRegisterDevice device = new AVL.RegisterDevice.JRegisterDevice(Code);
                    if(device.Config.Length>0)
                    {
                        string[] sConf = device.Config.Split(new char[]{','});
                        SaCheckbox.Checked = sConf[0] == "1" ? true : false;
                        SuCheckbox.Checked = sConf[1] == "1" ? true : false;
                        MoCheckbox.Checked = sConf[2] == "1" ? true : false;
                        TuCheckbox.Checked = sConf[3] == "1" ? true : false;
                        WeCheckbox.Checked = sConf[4] == "1" ? true : false;
                        ThCheckbox.Checked = sConf[5] == "1" ? true : false;
                        FrCheckbox.Checked = sConf[6] == "1" ? true : false;
                        OfTextbox.Text = sConf[7];
                        toTextbox.Text = sConf[8];
                        rateTextbox.Text = sConf[9];
                        if (sConf.Length > 10)
                        {
                            RDOHigh.Checked = sConf[10] == "true" ? true : false;
                            RDOLow.Checked = sConf[11] == "true" ? true : false;
                        }

                    }



                    ((WebAVL.Forms.DeviceModelSearch)deviceModelSearch).Code = device.DeviceType.ToString();
                    txtIMEI.Text = device.IMEI.ToString();
                    //txtSpeed.Text = device.speed.ToString();
                    txtName.Text = device.Name;
                    ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
                    try {
                        DB.setQuery(@"select ADH.code,AO.Label,AO.Type,ADH.StartDate,ADH.EndDate from AVLDeviceObjectHistory ADH left join AVLObjectList AO
                                    on ADH.ObjectCode = AO.Code where ADH.DeviceCode = " + Code.ToString());
                        System.Data.DataTable dt = DB.Query_DataTable();
                        JGrid.DataSource = dt;
                    }

                        
                    finally
                    {
                        DB.Dispose();
                    }
                }
                catch { }
            }
            else
            {

                ((WebAVL.Forms.DeviceModelSearch)deviceModelSearch).Code = "2";
                ((WebAVL.Forms.JObjectListItemSearch)objectListSearch).Code = "0";
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            WebClassLibrary.JWebManager.CloseWindow();
        }
    }
}