using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using Employment;
using Communication;
using Globals;

namespace Automation
{
    public partial class frmEmpriseRefer : Globals.JBaseForm
    {

        private int _Code;

        public frmEmpriseRefer()
        {
            InitializeComponent();
        }

        private void frmEmpriseRefer_Load(object sender, EventArgs e)
        {
            FillGrid();
        }

        private void FillGrid()
        {            
            JAEmprise tmp = new JAEmprise();
            GvEmprise.DataSource = tmp.GetDataByCode(0);            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            JAEmprise tmp = new JAEmprise();
            tmp.Description = txtDesc.Text;
            tmp.User_post_code = JMainFrame.CurrentPostCode;
            if (tmp.Insert() > 0)
            {
                JMessages.Message("Register Successfully ", "", JMessageType.Information);
                FillGrid();
            }
            else
                JMessages.Message("Register Not Successfully ", "", JMessageType.Error);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            JAEmprise tmp = new JAEmprise();
            tmp.Code = _Code;
            tmp.Description = txtDesc.Text;
            tmp.User_post_code = JMainFrame.CurrentPostCode;
            if (_Code != 0)
                if (tmp.Update())
                {
                    JMessages.Message("Update Successfully ", "", JMessageType.Information);
                    FillGrid();
                }
                else
                    JMessages.Message("Update Not Successfully ", "", JMessageType.Error);
            else
                JMessages.Message("Please Selected Item ", "", JMessageType.Error);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            JAEmprise tmp = new JAEmprise();
            if (_Code != 0)
                if (tmp.Delete(_Code))
                {
                    JMessages.Message("Delete Successfully ", "", JMessageType.Information);
                    FillGrid();
                }
                else
                    JMessages.Message("Delete Not Successfully ", "", JMessageType.Error);
            else
                JMessages.Message("Please Selected Item ", "", JMessageType.Error);
        }

        private void GvEmprise_SelectionChanged(object sender, EventArgs e)
        {
            int i = GvEmprise.CurrentRow.Index;
            if (i < GvEmprise.Rows.Count-1)
            {
                txtDesc.Text = GvEmprise.Rows[i].Cells[1].Value.ToString();
                _Code = Convert.ToInt32(GvEmprise.Rows[i].Cells[0].Value);
            }
        }
    }
}
