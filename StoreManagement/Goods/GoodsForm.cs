using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace StoreManagement
{
    public partial class JGoodsForm : JBaseForm
    {
        int _Code;

        public JGoodsForm()
        {
            InitializeComponent();
        }

        public JGoodsForm(int pCode)
        {
            InitializeComponent();
            _Code = pCode;
        }

        private void Set_Form()
        {
            JGoods tmpGoods = new JGoods(_Code);
            txtDesc.Text = tmpGoods.Description;
            cmbGoodsType.SelectedValue = tmpGoods.GoodsType;
            cmbGroup.SelectedValue = tmpGoods.GroupCode;
            txtIranCode.Text = tmpGoods.IranCode.ToString();
            txtNameLatin.Text = tmpGoods.Latin_Name;
            txtMax.Text = tmpGoods.MaxQuantity.ToString();
            txtMin.Text = tmpGoods.MinQuantity.ToString();
            txtPrice.Text = tmpGoods.Price.ToString();
            cmbState.SelectedValue = tmpGoods.Status;
            cmbMeasure.SelectedValue = tmpGoods.Measure;
             txtName.Text=tmpGoods.Name;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData
                if (txtName.Text == "")
                {
                    JMessages.Error(" لطفا نام را وارد کنید ", "");
                    return;
                }
                if (Convert.ToInt32(cmbGroup.SelectedValue) == -1)
                {
                    JMessages.Error(" لطفا گروه را انتخاب کنید ", "");
                    return;
                }
                if (Convert.ToInt32(cmbGoodsType.SelectedValue) == -1)
                {
                    JMessages.Error(" لطفا نوع کالا را انتخاب کنید ", "");
                    return;
                }
                if (Convert.ToInt32(cmbState.SelectedValue) == -1)
                {
                    JMessages.Error(" لطفا وضعیت را وارد کنید ", "");
                    return;
                }
                #endregion

                JGoods tmpGoods = new JGoods();
                tmpGoods.Description = txtDesc.Text;
                tmpGoods.GoodsType = Convert.ToInt32(cmbGoodsType.SelectedValue);
                tmpGoods.GroupCode = Convert.ToInt32(cmbGroup.SelectedValue);
                tmpGoods.IranCode = Convert.ToInt32(txtIranCode.Text);
                tmpGoods.Latin_Name = txtNameLatin.Text;
                tmpGoods.MaxQuantity = Convert.ToInt32(txtMax.Text);
                tmpGoods.MinQuantity = Convert.ToInt32(txtMin.Text);
                tmpGoods.Price = Convert.ToDecimal(txtPrice.Text);
                tmpGoods.Status = Convert.ToInt32(cmbState.SelectedValue);
                tmpGoods.Measure = Convert.ToInt32(cmbMeasure.SelectedValue);
                tmpGoods.Name = txtName.Text;

                if (State == JFormState.Insert)
                {
                    tmpGoods.Create_Date_Time = DateTime.Now;
                    _Code = tmpGoods.Insert();
                    if (_Code > 0)
                        JMessages.Information(" درج با موفقیت انجام گردید ", "");
                    else
                        JMessages.Error(" خطا در درج ", "");
                }
                else if (State == JFormState.Update)
                {
                    tmpGoods.Code = _Code;
                    if (tmpGoods.Update())
                        JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                    else
                        JMessages.Information(" خطا در ویرایش ", "");
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JGoodsForm_Load(object sender, EventArgs e)
        {
            JGoodsGroups tmpGoodsGroup = new JGoodsGroups();            
            JGoodsTypes tmpGoodsType = new JGoodsTypes();

            JMeasureTypes tmpMeasureTypes = new JMeasureTypes();

            if (_Code > 0)
            {
                JGoods tmpGoods = new JGoods(_Code);
                tmpGoodsGroup.SetComboBox(cmbGroup, tmpGoods.GroupCode);
                tmpGoodsType.SetComboBox(cmbGoodsType, tmpGoods.GoodsType);
                tmpMeasureTypes.SetComboBox(cmbMeasure, tmpGoods.Measure);
                Set_Form();
            }
            else
            {
                tmpGoodsGroup.SetComboBox(cmbGroup, -1);
                tmpGoodsType.SetComboBox(cmbGoodsType, -1);
                tmpMeasureTypes.SetComboBox(cmbMeasure, -1);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            dgvGoods.DataSource = JGoodss.FindName(txtName.Text);
        }
    }
}
