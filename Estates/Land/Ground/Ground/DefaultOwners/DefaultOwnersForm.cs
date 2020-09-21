using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Estates
{
    public partial class JDefaultOwnersForm : JBaseForm
    {
        JDefaultOwner owners = new JDefaultOwner();

        public JDefaultOwnersForm()
        {
            InitializeComponent();
        }

        //private void GetPattern()
        //{
        //    try
        //    {
        //        _dtBuyer = JDefaultOwner.GetAllData(0);
        //    }
        //    catch (Exception ex)
        //    {
        //        JSystem.Except.AddException(ex);
        //    }
        //}

        private void AddPrimaryOwners_Click(object sender, EventArgs e)
        {
            try
            {
                JFindPersonForm JFPF = new JFindPersonForm();
                JFPF.ShowDialog();
                if (JFPF.SelectedPerson != null)
                {
                    int PersonCode = JFPF.SelectedPerson.Code;
                    if (owners.FindDefaulOwner(PersonCode))
                    {
                        JMessages.Error("PersonExistsInList", "Error");
                        return;
                    }
                    else
                    {
                        DataRow dr = owners.DefaultOwners.NewRow();
                        dr["PCode"] = JFPF.SelectedPerson.Code;
                        dr["Name"] = JFPF.SelectedPerson.Name;
                        owners.DefaultOwners.Rows.Add(dr);
                        grdDefaultOwners.DataSource = owners.DefaultOwners;
                        btnok.Enabled = true;
                    }
                }
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private bool Save()
        {
            //JDefaultOwner tmp = new JDefaultOwner();
            if (!owners.Save())
                return false;
            return true;
        }

        private void btnok_Click(object sender, EventArgs e)
        {
            if (Save())
                btnok.Enabled = false;
        }

        private void DelPrimaryOwners_Click(object sender, EventArgs e)
        {
            try
            {
                if (grdDefaultOwners.CurrentRow != null)
                {
                    grdDefaultOwners.Rows.Remove(grdDefaultOwners.CurrentRow);
                    btnok.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JDefaultOwnersForm_Load(object sender, EventArgs e)
        {
            grdDefaultOwners.DataSource = owners.DefaultOwners;
         
            grdDefaultOwners.Columns["Code"].Visible = false;
            grdDefaultOwners.Columns["PCode"].ReadOnly = true;
            grdDefaultOwners.Columns["Name"].ReadOnly = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
