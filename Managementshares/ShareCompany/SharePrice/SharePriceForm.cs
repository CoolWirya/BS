using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares
{
    public partial class JSharePriceForm : JBaseForm
    {
        int _CompanyCode;
        public JSharePriceForm(int pCompanyCode)
        {
            InitializeComponent();
            _CompanyCode=pCompanyCode;
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            try
            {
                JSharePrice tmpDoc = new JSharePrice();
                tmpDoc.ChangeDate = txtDate.Date;
                tmpDoc.Price = txtPrice.MoneyValue;
                tmpDoc.CompanyCode = _CompanyCode;
                if (State == JFormState.Insert)
                {
                    tmpDoc.Code = tmpDoc.insert();
                    if (tmpDoc.Code > 0)
                    {
                        dgvList.DataSource = JSharePrice.GetDataTable(0, _CompanyCode);
                        JMessages.Message("Insert Successfuly", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message("Insert Not Successfuly", "", JMessageType.Error);
                }
                else
                {
                    if (tmpDoc.Update(_CompanyCode))
                    {
                        JMessages.Message("Update Successfuly", "", JMessageType.Information);
                    }
                    else
                        JMessages.Message("Update Not Successfuly", "", JMessageType.Error);
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvList.CurrentRow != null)
                {
                    JSharePrice tmpDoc = new JSharePrice();
                    tmpDoc.GetData(Convert.ToInt32(dgvList.CurrentRow.Cells["Code"].Value));
                    tmpDoc.Delete();
                    dgvList.DataSource = JSharePrice.GetDataTable(0, _CompanyCode);
                }
                else
                    JMessages.Error(" لطفا سطری را انتخاب کنید ", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JSharePriceForm_Load(object sender, EventArgs e)
        {
            dgvList.DataSource = JSharePrice.GetDataTable(0, _CompanyCode);
        }
    }
}
