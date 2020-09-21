using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ManagementShares.Assemblies.ShareAssemblies
{
    public partial class ShareAssembliesForm : JBaseForm
    {
        JShareholdersAssembly ShareholdersAssembly;
        public ShareAssembliesForm(int pCCode , int pCode)
        {
            InitializeComponent();
            GetData(pCCode,pCode);
        }

        public ShareAssembliesForm(int pCCode, int pPCode, int pShare)
        {
            InitializeComponent();
            CreateHolder(pCCode, pPCode, pShare);
        }

        private void CreateHolder(int pCCode, int pPCode, int pShare)
        {
            ShareholdersAssembly = new JShareholdersAssembly(0);
            if (ShareholdersAssembly.Code > 0)
            {
                txtPCode.Text = pPCode.ToString();
                txtShare.Text = pShare.ToString();

                txtPCode.ReadOnly = true;
                txtShare.ReadOnly = true;
            }
            else
            {
                ShareholdersAssembly.CCode = pCCode;
            }
        }

        private void GetData(int pCCode, int pCode)
        {
            ShareholdersAssembly = new JShareholdersAssembly(pCode);
            if (ShareholdersAssembly.Code > 0)
            {
                txtId.Text = ShareholdersAssembly.id.ToString();
                txtPCode.Text = ShareholdersAssembly.pCode.ToString();
                txtShare.Text = ShareholdersAssembly.Share.ToString();
            }
            else
            {
                ShareholdersAssembly.CCode = pCCode;
            }
        }

        private bool SetData()
        {
            try
            {
                ShareholdersAssembly.id = int.Parse(txtId.Text);
                ShareholdersAssembly.pCode = int.Parse(txtPCode.Text);
                ShareholdersAssembly.Share = int.Parse(txtShare.Text);
                return true;
            }
            catch (Exception ex)
            {
            }
            finally
            {
            }
            return false;
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            if (SetData())
            {
                if (State == JFormState.Insert)
                {
                }
                else
                    if
                        (State == JFormState.Update)
                    {
                    }
            }
        }

        private void Closebutton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
