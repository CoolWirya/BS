using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JDecisionSearchForm : ClassLibrary.JBaseForm
    {
        public int _Code;

        public JDecisionSearchForm()
        {
            InitializeComponent();
            chklistType.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("Legal.DecisionType")));
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (jdgvSearch.CurrentRow != null)
            {
                _Code = Convert.ToInt32(jdgvSearch.CurrentRow.Cells["Code"].Value);
                Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            JDecision tmp = new JDecision();
            int pAgainstCompany = 0, pConclusive =0, pType = 0;
            tmp.Date=txtDate.Date;
            tmp.number=txtNum.Text;
            if ((chkAgaints.Checked) && (!chkBenefit.Checked))
                tmp.AgainstCompany = JAgainstCompanyType.AgainstCompany;
            else if ((!chkAgaints.Checked) && (chkBenefit.Checked))
                tmp.AgainstCompany = JAgainstCompanyType.Benefit;
            else
                pAgainstCompany = -1;
            if((chkConclusive.Checked)&&(!chkNoCon.Checked))
                tmp.Conclusive = true;
            else if((!chkConclusive.Checked)&&(chkNoCon.Checked))
                tmp.Conclusive = false;
            else
                pConclusive = -1;
            if((chkRay.Checked)&&(!chkGharar.Checked))
                tmp.Type = true;
            else if((!chkRay.Checked)&&(chkGharar.Checked))
                tmp.Type = false;
            else
                pType = -1;
            tmp.DecisionDesc=txtDesc.Text.Trim();
            string str = "0";
            for (int i = 0; i < chklistType.Items.Count; i++)
            {
                if (chklistType.GetItemChecked(i))
                    str= str + "," + ((ClassLibrary.JKeyValue)chklistType.Items[i]).Value.ToString();
            }
            jdgvSearch.DataSource = tmp.Search(str, txtEndDate.Date, pAgainstCompany, pConclusive, pType);
        }

        private void jdgvSearch_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave_Click(null, null);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDate.Text="";
            txtEndDate.Text = "";
            txtNum.Text = "";
            txtDesc.Text = "";
            chkGharar.Checked = false;
            chkAgaints.Checked = false;
            chkBenefit.Checked = false;
            chkConclusive.Checked = false;
            chkNoCon.Checked = false;
            chkRay.Checked = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JDecision decision = new JDecision();
            decision.ShowDialog();
        }
    }
}
