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
        int CurrentMetierCode;
        int CurrentOrgansCode;
        int _code;
        public JEPostForm()
            : this(0)
        {
            State = JFormState.Insert;
        }

        public JEPostForm(int pCode)
        {
            InitializeComponent();
            _code = pCode;
            JEPost Post = new JEPost(pCode);
            CurrentMetierCode = Post.MetierCode;
            CurrentOrgansCode = Post.UnitCode;
            State = JFormState.Update;
            LoadData();
        }
        private void LoadData()
        {
            JESubBaseDefines subDefs = new JESubBaseDefines(JEBaseDefine.MetierCode);
            foreach (JSubBaseDefine subDef in subDefs.Items)
            {
                cmbMetier.Items.Add(subDef);
                if (subDef.Code == CurrentMetierCode)
                    cmbMetier.SelectedItem = subDef;
            }
            
            JESubBaseDefines organs = new JESubBaseDefines(JEBaseDefine.OrganizationUnitCode);
            foreach (JSubBaseDefine organ in organs.Items)
            {
                cmbOrgans.Items.Add(organ);
                if (organ.Code == CurrentOrgansCode)
                    cmbOrgans.SelectedItem = organ;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (State == JFormState.Insert)
            {
                JEPost post = new JEPost();
                post.MetierCode = ((JSubBaseDefine)cmbMetier.SelectedItem).Code;
                post.UnitCode = ((JSubBaseDefine)cmbOrgans.SelectedItem).Code;
                post.State = JPostState.Active;
                if (post.Insert() > 0)
                {
                    DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            if (State == JFormState.Update)
            {
                JEPost post = new JEPost();
                post.Code = _code;
                post.MetierCode = ((JSubBaseDefine)cmbMetier.SelectedItem).Code;
                post.UnitCode = ((JSubBaseDefine)cmbOrgans.SelectedItem).Code;
                post.State = JPostState.Active;
                if (post.Update())
                    btnOK.Enabled = false;
                this.Close();

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        
    }
}
