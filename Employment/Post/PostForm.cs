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
    public partial class JEPostForm : JBaseForm
    {
        public JFormState formState;
        public JEPostForm()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            JESubBaseDefines subDefs = new JESubBaseDefines(JEBaseDefine.MetierCode);
            foreach (JSubBaseDefine subDef in subDefs.Items)
            {
                cmbMetier.Items.Add(subDef);
            }
            
            JESubBaseDefines organs = new JESubBaseDefines(JEBaseDefine.OrganizationUnitCode);
            foreach (JSubBaseDefine organ in organs.Items)
            {
                cmbOrgans.Items.Add(organ);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (formState == JFormState.Insert)
            {
                JEPost post = new JEPost();
                post.MetierCode = ((JSubBaseDefine)cmbMetier.SelectedItem).Code;
                post.UnitCode = ((JSubBaseDefine)cmbOrgans.SelectedItem).Code;
                post.State = JPostState.Active;
                post.Insert();
                DialogResult = DialogResult.OK;
            }
            if (formState == JFormState.Update)
            {
                JEPost post = new JEPost();
                post.MetierCode = ((JSubBaseDefine)cmbMetier.SelectedItem).Code;
                post.UnitCode = ((JSubBaseDefine)cmbOrgans.SelectedItem).Code;
                post.State = JPostState.Active;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
    }
}
