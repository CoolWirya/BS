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
    public partial class JLandForm : ClassLibrary.JBaseForm
    {
        JLand NewLand;

        public JLandForm()
        {
            InitializeComponent();
            NewLand = new JLand();
            ArchiveListLand.ClassName = NewLand.GetType().FullName;
        }

        public JLandForm(int pCode)
        {
            InitializeComponent();
            NewLand = new JLand(pCode);
            _ShowData();
            ArchiveListLand.ClassName = NewLand.GetType().FullName;
            ArchiveListLand.ObjectCode = pCode;
        }



        private void _ShowData()
        {
            labCode.Text = Convert.ToString(NewLand.Code);
            txtName.Text = NewLand.Name;
            txtPlaque.Text = NewLand.Plaque;
            txtSection.Text = NewLand.Section;
            numArea.Text = Convert.ToString(NewLand.Area);
        }

        private void JLandForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                    Close();
            }
        }

        private bool Save()
        {
            try
            {
                bool retBool = false;
                NewLand.Name = txtName.Text;
                NewLand.Area = numArea.FloatValue;
                NewLand.Plaque = txtPlaque.Text;
                NewLand.Section = txtSection.Text;
                if (this.State == ClassLibrary.JFormState.Insert)
                {
                    NewLand.Insert();
                    ArchiveListLand.ObjectCode = NewLand.Code;
                }
                else if (this.State == ClassLibrary.JFormState.Update)
                {
                    NewLand.Code = Convert.ToInt32(labCode.Text);
                    retBool = NewLand.Update();

                }
                if (retBool)
                {
                    ArchiveListLand.ArchiveList();
                    State = ClassLibrary.JFormState.Update;
                    labCode.Text = NewLand.Code.ToString();
                }
                btnApply.Enabled = false;
                return retBool;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (Save())
            {
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void txtPlaque_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void txtSection_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void numArea_TextChanged(object sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

        private void JLandForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btnApply.Enabled)
            {
                DialogResult result = ClassLibrary.JMessages.Confirm("DoYouWantTotSaveChanges?", "SaveChanges");
                if (result == DialogResult.Yes)
                {
                    btnSave.PerformClick();
                    Close();
                    return;
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else
                    e.Cancel = false;
            }

        }

        private void ArchiveListLand_AfterFileAdded(object Sender, EventArgs e)
        {
            btnApply.Enabled = true;
        }

       
    }
}
