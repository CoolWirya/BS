using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace SmartCard
{
    public partial class JCardsForm : JBaseForm
    {
        int _Code;

        public JCardsForm()
        {
            InitializeComponent();
            jPropertyValueUserControl1.ClassName = "SmartCard.JCardsType";
            cmbCardType.Items.AddRange(JMainFrame.EnumToListBox(Type.GetType("SmartCard.JCardTypeEnum")));
        }

        public JCardsForm(int pCode)
        {
            InitializeComponent();
            cmbCardType.Items.AddRange(JMainFrame.EnumToListBox(Type.GetType("SmartCard.JCardTypeEnum")));
            jPropertyValueUserControl1.ClassName = "SmartCard.JCardsType";
            if (pCode > 0)
            {
                jPropertyValueUserControl1.ValueObjectCode = _Code;
                _Code = pCode;
                SetValue();
            }
        }

        private void _Load()
        {
            
        }

        private void SetValue()
        {
            JCards tmpCard = new JCards(_Code);
            txtRFID.Text = tmpCard.RfidNumber.ToString();
            txtDesc.Text = tmpCard.Description;
            foreach (JKeyValue cardType in cmbCardType.Items)
            {
                if ((int)cardType.Value == tmpCard.CardType)
                {
                    cmbCardType.SelectedItem = cardType;
                    break;
                }
            }
            chkStatus.Checked = tmpCard.Status;
            cmbPassengerCardType.Text = tmpCard.PassengerCardType.ToString();

            TxtCardCode.Text = tmpCard.CardCode.ToString();
            jucPerson1.SelectedCode = tmpCard.pCode;
            jucPerson1.Enabled = false;
            jPropertyValueUserControl1.ValueObjectCode = _Code;
        }
        private bool Validate()
        {
            if (txtRFID.Text == "")
            {
                JMessages.Error("لطفاً شماره RFID کارت را وارد کنید.", "");
                return false;
            }
            if (cmbPassengerCardType.SelectedIndex == -1)
            {
                JMessages.Error("لطفا نوع کارت مسافر را از لیست انتخاب کنید.", "");
                return false;
            }
            if (cmbCardType.SelectedIndex == -1)
            {
                JMessages.Error("لطفا نوع شخص را از لیست انتخاب کنید.", "");
                return false;
            }
            return true;

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validate())
                    return;
                JCards tmpCard = new JCards(_Code);
                tmpCard.RfidNumber = txtRFID.IntValue;
                tmpCard.Description = txtDesc.Text;
                tmpCard.CardType = (int)((JKeyValue)cmbCardType.SelectedItem).Value;
                tmpCard.Status = chkStatus.Checked;
                if (cmbPassengerCardType.SelectedIndex > -1)
                    tmpCard.PassengerCardType = Convert.ToInt16(cmbPassengerCardType.Text);
                tmpCard.CardCode = TxtCardCode.IntValue;
                if (jucPerson1.SelectedCode > 0)
                    tmpCard.pCode = jucPerson1.SelectedCode;

                if (_Code > 0)
                {
                    if (tmpCard.Update())
                    {
                        JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                        jPropertyValueUserControl1.Save();
                    }
                    else
                        JMessages.Information(" خطا در ویرایش ", "");
                }
                else
                {
                    _Code = tmpCard.Insert();
                    if (_Code > 0)
                    {
                        jPropertyValueUserControl1.ValueObjectCode = _Code;
                        jPropertyValueUserControl1.Save();
                        Close();
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear()
        {
            txtRFID.Text = "";
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Retry;
        }

        private void cmbCardType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int _CardType = (int)((JKeyValue)cmbCardType.SelectedItem).Value;
            jPropertyValueUserControl1.ObjectCode = _CardType;
            jPropertyValueUserControl1.ClassName = "SmartCard.JCardsType";
            jPropertyValueUserControl1.ValueObjectCode = _Code;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JCardsTypeForm form = new JCardsTypeForm(0);
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
