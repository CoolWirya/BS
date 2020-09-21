using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JFormulaForm : JBaseForm
    {
        int _CompanyCode;

        public JFormulaForm()
        {
            InitializeComponent();
        }

        public JFormulaForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode = pCompanyCode;
        }

        private void JFormulaForm_Load(object sender, EventArgs e)
        {
            JCalcTypes ActivityType = new JCalcTypes();
            ActivityType.SetComboBox(cmbCalcType, -1);
        }

        private void cmbCalcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCalcType.SelectedValue.ToString() != "System.Data.DataRowView")
            if (cmbCalcType.SelectedValue != null)
            {
                _ItemGoods = JFormula.GetDataTable(Convert.ToInt32(cmbCalcType.SelectedValue), _CompanyCode);
                jDataGrid1.DataSource = _ItemGoods;
                jDataGrid1.Columns["TitleCode"].Visible = false;
                jDataGrid1.Columns["Code"].Visible = false;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (jDataGrid1.CurrentRow != null)
                {
                    jDataGrid1.Rows.Remove(jDataGrid1.CurrentRow);
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        DataTable _ItemGoods;

        private void btnSabt_Click(object sender, EventArgs e)
        {
            JFormula tmpFormula = new JFormula();
            tmpFormula.Save(_CompanyCode, Convert.ToInt32(cmbCalcType.SelectedValue), _ItemGoods);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFieldType.Text == "")
                {
                    JMessages.Error(" این فیلد قبلا ثبت شده است ", "");
                    return;
                }
                if (((_ItemGoods != null) && (_ItemGoods.Select(" FeildName='" + cmbFieldType.Text + "'").Length == 0)))
                {
                    DataRow dr = _ItemGoods.NewRow();
                    dr["TitleCode"] = Convert.ToInt32(cmbCalcType.SelectedValue);
                    dr["FeildName"] = JLanguages._Farsi(cmbFieldType.Text);
                    dr["Sql"] = txtFormula.Text;
                    _ItemGoods.Rows.Add(dr);
                    jDataGrid1.DataSource = _ItemGoods;
                    jDataGrid1.Columns["TitleCode"].Visible = false;
                    jDataGrid1.Columns["Code"].Visible = false;
                }
                else
                {
                    JMessages.Error(" این فیلد قبلا ثبت شده است ", "");
                    cmbListField.Focus();
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                JMessages.Error(" خطا با مدیر سیستم تماس بگیرید ", "");
            }
        }

        private void btnAddFeild_Click(object sender, EventArgs e)
        {
            txtFormula.Text = txtFormula.Text + "[" + JLanguages._Farsi(cmbListField.Text) + "]";
        }
    }
}
