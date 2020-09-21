using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using RealEstate;

namespace Parking
{
    public partial class DefShift : Globals.JBaseForm
    {
        private JBaseShift Def;

        public DefShift()
        {
            InitializeComponent();
            FillComboBox();
        }
        public DefShift(JBaseShift BaseShift,int Market)
        {
            InitializeComponent();
            FillComboBox();
            CmbMarketDefShift.SelectedValue =Convert.ToInt32( Market);
            Def = BaseShift;

            if (Def.Code == 0)
            {
                State = JFormState.Insert;
            }
            else
            {
                State = JFormState.Update;
                Display();
            }
        }

        private void Display()
        {
            txthourin.Text = Def.StatrtTime[0].ToString() + Def.StatrtTime[1].ToString();
            TxtMinin.Text = Def.StatrtTime[3].ToString() + Def.StatrtTime[4].ToString();
            TxtHourOut.Text = Def.EndTime[0].ToString() + Def.EndTime[1].ToString();
            TxtMinout.Text = Def.StatrtTime[3].ToString() + Def.StatrtTime[4].ToString();
            txtName.Text = Def.Name;
            chkClose.Checked = Def.Isclose;
            CmbMarketDefShift.SelectedValue = Convert.ToInt32(Def.Market);
        }

        private void DefShift_Load(object sender, EventArgs e)
        {
            CmbMarketDefShift.Enabled = false;
        }

        private void FillComboBox()
        {
            // پر كردن نام مجتمع / بازارها
            DataTable Markets = jMarkets.GetDataTable(0);
            CmbMarketDefShift.DisplayMember = estMarket.Title.ToString();
            CmbMarketDefShift.ValueMember = estMarket.Code.ToString();
            CmbMarketDefShift.DataSource = Markets;
            CmbMarketDefShift.SelectedItem = 1;
        }

        private Boolean Validate()
        {
            if (txtName.Text == "")
            {
                JMessages.Warning("نام به شكل صحيح وارد نشده است", "توجه");
                txtName.Focus();
                return false;
            }
            if (txthourin.Text == "")
            {
                JMessages.Warning("ساعت شروع وارد نشده است", "توجه");
                txthourin.Focus();
                return false;
            }
            if (TxtMinin.Text == "")
            {
                JMessages.Warning("دقيقه شروع وارد نشده است", "توجه");
                TxtMinin.Focus();
                return false;
            }
            if (TxtHourOut.Text == "")
            {
                JMessages.Warning("ساعت پايان وارد نشده است", "توجه");
                TxtHourOut.Focus();
                return false;
            }
            if (TxtMinout.Text == "")
            {
                JMessages.Warning("دقيقه پايان وارد نشده است", "توجه");
                TxtMinout.Focus();
                return false;
            }
            if (Convert.ToInt32(CmbMarketDefShift.SelectedValue) == -1 || Convert.ToInt32(CmbMarketDefShift.SelectedValue) == 0)
            {
                JMessages.Warning("نيك بازار را انتخاب كنيد", "توجه");
                CmbMarketDefShift.Focus();
                return false;
            }
            if (Def.GetTime())
            {
                JMessages.Warning("زمانهاي انتخاب شده قبلا براي شيفت در اين مجتمع تعريف شده است", "توجه");
                return false;
            }
            return true;
        }

        private void Save()
        {
            Def.EndTime = TxtHourOut.Text.Trim() + ":" + TxtMinout.Text.Trim();
            Def.StatrtTime = txthourin.Text.Trim() + ":" + TxtMinin.Text.Trim();
            Def.Name = txtName.Text;
            Def.Market = Convert.ToInt32(CmbMarketDefShift.SelectedValue);
            Def.Isclose = chkClose.Checked;
          if (Validate() == false) return;
            //  Def.Code = txtCode.IntValue;
         
            if (State == JFormState.Insert)
            {
                int _Code = Def.Insert();

                if (_Code != 0)
                {
                    State = JFormState.Update;
                    Def.GetData(_Code);
                    Display();
                    JMessages.Information("اطلاعات ثبت شد", "توجه");
                }
                else
                {
                    JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                }
            }
            else
            {
                if (Def.Update())
                {
                    Display();
                    JMessages.Information("اطلاعات ثبت شد", "توجه");
                }
                else
                {
                    JMessages.Warning("در اجراي عمليات مشكلي بروز كرده است", "توجه");
                }
            }

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        
    }
}
