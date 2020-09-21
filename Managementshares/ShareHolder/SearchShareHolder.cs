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
    public partial class JSearchShareHolder :ClassLibrary.JBaseForm
    {
        //public DataRowView Results;
        /// <summary>
        /// کد شخص انتخاب شده
        /// </summary>
        public int SelectedCode;
        /// <summary>
        /// شماره برگه انتخاب شده
        /// </summary>
        public int SelectedSheetNo;
        public int Course;
        public JSearchShareHolder()
        {
            InitializeComponent();
            txtShareHolderNo.MaxLength = JShareHolder.MaxLength.ToString().Length;
        }
        public JSearchShareHolder(int pPCode)
        {
            InitializeComponent();
            txtShareHolderNo.MaxLength =  JShareHolder.MaxLength.ToString().Length;
            txtShareHolderNo.Text = pPCode.ToString();
        }
        ~JSearchShareHolder()
        {
            try
            {
                ((DataTable)grdPerson.DataSource).Dispose();
            }
            catch
            {
            }
        }

        //JShareHolders holders = new JShareHolders();

        private void btnSearch_Click(object sender, EventArgs e)
        {
            grdPerson.DataSource = JShareHolders.SearchOtherPerson(txtShareHolderNo.IntValue, txtName.Text, txtFam.Text, txtSheetNo.IntValue);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (grdPerson.CurrentRow!= null)
            {
                SelectedCode = (int)grdPerson.SelectedRows[0].Cells["PCode"].Value;
                SelectedSheetNo = (int)grdPerson.SelectedRows[0].Cells["SheetNo"].Value;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtShareHolderNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                grdPerson.Focus();
        }

        private void txtShareHolderNo_TextChanged(object sender, EventArgs e)
        {
            if (txtShareHolderNo.Text.Length == txtShareHolderNo.MaxLength)
                btnSearch.PerformClick();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSearch.PerformClick();
        }

        private void JSearchShareHolder_Shown(object sender, EventArgs e)
        {
            if (txtShareHolderNo.Text != "")
                btnSearch.PerformClick();

        }

        private void grdPerson_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            btnOK.PerformClick();
        }

        private void txtShareHolderNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (grdPerson.CurrentRow != null)
            {
                if (e.KeyData == Keys.Up)
                {
                    if (grdPerson.CurrentRow.Index - 1 >= 0)
                    {
                        grdPerson.Rows[grdPerson.CurrentRow.Index - 1].Selected = true;
                        grdPerson.CurrentCell = grdPerson[0, grdPerson.CurrentRow.Index - 1];
                    }
                }

                if (e.KeyData == Keys.Down)
                {
                    if (grdPerson.CurrentRow.Index + 1 < grdPerson.Rows.Count)
                    {
                        grdPerson.Rows[grdPerson.CurrentRow.Index + 1].Selected = true;
                        grdPerson.CurrentCell = grdPerson[0, grdPerson.CurrentRow.Index + 1];
                    }
                }
                if (e.KeyData == Keys.Enter)
                {
                    btnOK.PerformClick();
                }
            }
        }
    }
}
