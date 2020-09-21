using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Parking
{
    public partial class JConfigHardwareForm : Globals.JBaseForm
    {
        private JConfigHardware _JConfigHardware;

        public JConfigHardwareForm(JConfigHardware ConfigHardware)
        {
            InitializeComponent();
            _FillComboBox();
            _JConfigHardware = ConfigHardware;
            DisplayData();

        }

        public JConfigHardwareForm(int code)
        {
            InitializeComponent();
            _FillComboBox();
            _JConfigHardware = new JConfigHardware();
        }

        public bool DisplayData()
        {
            try
            {
                cmbCommunicationProtocol.SelectedValue = (Convert.ToInt32(_JConfigHardware.CommunicationProtocol));
                cmbModelDevice.SelectedValue = Convert.ToInt32(_JConfigHardware.ModelDevice);
                txtNoProtocol.Text = _JConfigHardware.NoProtocol.ToString();
                cmbTypeDevice.SelectedValue = (Convert.ToInt32(_JConfigHardware.TypeDevice));
                cmbTypeDvr.SelectedValue = (Convert.ToInt32(_JConfigHardware.TypeDvr));
                txtAddressSavePic.Text = _JConfigHardware.AddressSavePic;
                cmbComplex.SelectedValue = (Convert.ToInt32(_JConfigHardware.complex));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void _FillComboBox()
        {
            try
            {
                JSubBaseDefine nullDeff = new JSubBaseDefine(0);
                nullDeff.Code = -1;
                nullDeff.Name = "-----------";

                // پر كردن نام مجتمع / بازارها
                cmbComplex.DisplayMember = RealEstate.estMarket.Title.ToString();
                cmbComplex.ValueMember = RealEstate.estMarket.Code.ToString();
                cmbComplex.DataSource = RealEstate.jMarkets.GetDataTable(0);


               
               
                

              
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

         /// <summary>
        /// ذخیره
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private bool Validation_Save()
        {

            #region Validation

            if (Convert.ToInt32(cmbComplex.SelectedValue) == 0 || Convert.ToInt32(cmbComplex.SelectedValue) == -1)
            {
                string msg = "هیچ مجتمع یا بازاری انتخاب نگردیده است";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (Convert.ToInt32(cmbTypeDevice.SelectedValue) == 0 || Convert.ToInt32(cmbTypeDevice.SelectedValue) == -1)
            {
                string msg = "لطفا نوع دستگاه را مشخص نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (Convert.ToInt32(cmbModelDevice.SelectedValue) == 0 || Convert.ToInt32(cmbModelDevice.SelectedValue) == -1)
            {
                string msg = "لطفا مدل دستگاه را انتخاب نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (Convert.ToInt32(cmbCommunicationProtocol.SelectedValue) == 0 || Convert.ToInt32(cmbCommunicationProtocol.SelectedValue) == -1)
            {
                string msg = "لطفا پروتکل ارتباطی را وارد نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if ( txtNoProtocol.Text.Trim()=="" )
            {
                string msg = "لطفا شماره پورت جورد نظر را وارد نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (Convert.ToInt32(cmbTypeDvr.SelectedValue) == 0 || Convert.ToInt32(cmbTypeDvr.SelectedValue) == -1)
            {
                string msg = "لطفا نوع دستگاه دی وی ار نصب شده در مجتمع/بازار را وارد نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            if (txtAddressSavePic.Text.Trim() == "" || txtAddressSavePic.Text.Trim() =="c:\\")
            {
                string msg = "لطفا محل ذخیره تصویر را مشخص نمائید";
                JMessages.Error(msg, "Error");
                return false;
            }

            #endregion

            #region Set Value

            _JConfigHardware.CommunicationProtocol = (Convert.ToInt32(cmbCommunicationProtocol.SelectedValue));
            _JConfigHardware.ModelDevice = Convert.ToInt32(cmbModelDevice.SelectedValue);
            _JConfigHardware.NoProtocol = txtNoProtocol.IntValue;
            _JConfigHardware.TypeDevice = (Convert.ToInt32(cmbTypeDevice.SelectedValue));
            _JConfigHardware.TypeDvr = (Convert.ToInt32(cmbTypeDvr.SelectedValue));
            _JConfigHardware.AddressSavePic = txtAddressSavePic.Text;
            _JConfigHardware.complex = (Convert.ToInt32(cmbComplex.SelectedValue));

            #endregion

            #region save

            //---------ویرایش------------
            if (State == JFormState.Update)
            {
                if (_JConfigHardware.Update())
                {
                    JMessages.Message("UpdateSuccessfuly ", "", JMessageType.Information);
                    return true;
                }
                else
                {
                    JMessages.Message("Update Not Successfuly ", "", JMessageType.Information);
                    return false;
                }
            }
            else
            {
                //---------درج------------
                if (_JConfigHardware.Insert() > 0)
                {
                    JMessages.Message("Insert Successfuly ", "", JMessageType.Information);
                    State = JFormState.Update;
                    return true;
                }
                else
                {
                    JMessages.Message("Insert Not Successfuly ", "", JMessageType.Information);
                    return false;
                }
            }

        #endregion 

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (Validation_Save())
            {
                btnAdd.Enabled = false;
                Close();
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DefineComputerSetGate DFCG = new DefineComputerSetGate();
            DFCG.ShowDialog();
        }
    }
}
