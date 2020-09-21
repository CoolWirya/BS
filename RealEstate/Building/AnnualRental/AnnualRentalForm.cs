using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace RealEstate
{
    public partial class JAnnualRentalForm : JBaseForm
    {
        int _BuildingCode;
        public JAnnualRentalForm(int pBuildingCode)
        {
            InitializeComponent();
            _BuildingCode = pBuildingCode;
        }

        private void FillGrid()
        {
            jdgvList.DataSource = JAnnualRental.GetDataTable(_BuildingCode);
            jdgvList.Columns["Code"].Visible = false;
            jdgvList.Columns["buildingCode"].Visible = false;
        }

        private void btnSabt_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStartDate.Date >= txtEndDate.Date)
                {
                    JMessages.Error(" تاریخ را درست وارد کنید ", "");
                    return;
                }
                JAnnualRental tmpJAnnualRental = new JAnnualRental();
                tmpJAnnualRental.BuildingCode = _BuildingCode;
                tmpJAnnualRental.StartDate = txtStartDate.Date;
                tmpJAnnualRental.EndDate = txtEndDate.Date;
                tmpJAnnualRental.Price = Convert.ToDecimal(txtPrice.Text);
                tmpJAnnualRental.Description = txtDesc.Text;
                if (tmpJAnnualRental.Insert() > 0)
                {
                    JMessages.Message(" با موفقیت ثبت شد","", JMessageType.Information);
                    FillGrid();
                }
                else
                    JMessages.Error("خطا", "");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JAnnualRentalForm_Load(object sender, EventArgs e)
        {
            try
            {
                FillGrid();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (jdgvList.gridEX1.CurrentRow == null) return;
            JAnnualRental tmpJAnnualRental = new JAnnualRental();
            if (tmpJAnnualRental.delete(Convert.ToInt32(jdgvList.gridEX1.CurrentRow.Cells["BuildingCode"].Value), JDateTime.GregorianDate(jdgvList.gridEX1.CurrentRow.Cells["StartDate"].Value.ToString())))
                JMessages.Message("با موفقیت ثبت شد", "", JMessageType.Information);
            else
                JMessages.Error("خطا", "");
        }
    }
}
