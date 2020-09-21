using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Bascol
{
    public partial class JTruckForm : JBaseForm
    {
        DataTable _dtTrucks;
        public JTruckForm()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                #region CheckData

                if (txtDate.Date == DateTime.MinValue)
                {
                    JMessages.Error(" تاریخ شروع را وارد کنید ", "");
                    txtDate.Focus();
                    return;
                }
                if (txtEnddate.Date == DateTime.MinValue)
                {
                    JMessages.Error(" تاریخ پایان را وارد کنید ", "");
                    txtEnddate.Focus();
                    return;
                }
                if (txtEnddate.Date < txtDate.Date)
                {
                    JMessages.Error(" تاریخ پایان کوچکتر از تاریخ شروع را است ", "");
                    txtEnddate.Focus();
                    return;
                }
                if (txtName.Text == "")
                {
                    JMessages.Error(" نام ماشین را وارد کنید ", "");
                    txtName.Focus();
                    return;
                }

                #endregion

                DataRow dr = _dtTrucks.NewRow();
                dr["StartDate"] = txtDate.Date;
                dr["EndDate"] = txtEnddate.Date;
                dr["Name"] = txtName.Text;
                dr["Price"] = txtPrice.Text;
                dr["Shortcut"] = txtShortcut.Text;
                _dtTrucks.Rows.Add(dr);
                Fill();
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                JMessages.Error(" ویرایش با موفقیت انجام نگردید ", "");
            }
        }

        private void JTruckForm_Load(object sender, EventArgs e)
        {
            try
            {
                _dtTrucks = JTrucks.GetDataTable(0);
                Fill();
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
            }
        }

        private void Fill()
        {
            jDataGrid1.DataSource = _dtTrucks;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //JConnectionForm con = new JConnectionForm();
            //con.ShowDialog();
            try
            {
                JTruck tmpTruck = new JTruck();
                if (tmpTruck.Update(_dtTrucks))
                    JMessages.Information(" ویرایش با موفقیت انجام گردید ", "");
                else
                    JMessages.Error(" ویرایش با موفقیت انجام نگردید ", "");
            }
            catch (Exception ex)
            {
                JBase.Except.AddException(ex);
                JMessages.Error(" ویرایش با موفقیت انجام نگردید ", "");
            }
        }

    }
}
