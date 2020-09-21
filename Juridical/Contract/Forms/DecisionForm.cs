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
    public partial class JDecisionForm1 : JBaseContractForm
    {
        private int _DecisionCode = 0;

        public JDecisionForm1()
        {
            InitializeComponent();
        }

        public JDecisionForm1 MakeForm()
        {
            JDecisionForm1 form = new JDecisionForm1();
            return form;
        } 

        #region Methods

        public void Set_Form()
        {
            try
            {
                txtDesc.Text = ContractForms.Contract.DecisionDesc;
                txtNumber.Text = ContractForms.Contract.DecisionCode.ToString();
                LoadData(ContractForms.Contract.DecisionCode);

                if (State == JStateContractForm.View)
                {
                    txtDesc.ReadOnly = true;
                    btnSearch.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public bool CheckData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                return true;
                //if (txtNumber.Text != "")
                //    return true;
                //else
                //{
                //    JMessages.Information("Please  Enter Decision Code", "Information");
                //    return false;
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool ApplyData()
        {
            try
            {
                ContractForms.Contract.DecisionCode = _DecisionCode;
                ContractForms.Contract.DecisionDesc = txtDesc.Text.Trim();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public override bool SavePreview(DataTable pDt)
        {
            return SavePreview(pDt, true, false);
        }
        public override bool SavePreview(DataTable pDt, bool pSetValue)
        {
            return SavePreview(pDt, pSetValue, false);
        }

        public override bool SavePreview(DataTable pDt, bool pSetValue, bool pOffline)
        {
            try
            {
                pDt.Columns.Add("DecisionNumber");
                pDt.Columns.Add("DecisionDate");
                pDt.Columns.Add("DecisionDesc");
                if (pSetValue)
                {
                    if (pOffline)
                        Set_Form();

                    pDt.Rows[0]["DecisionNumber"] = txtNum.Text;
                    pDt.Rows[0]["DecisionDate"] = JGeneral.ReverseDate(JDateTime.FarsiDate(txtDate.Date));
                    pDt.Rows[0]["DecisionDesc"] = txtDesc.Text.ToString();
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public override bool SaveBack()
        {
            if (isSave)
            {
                isSave = false;
                State = tempState;
            }
            return true;
        }

        public override bool Save(JDataBase tempdb)
        {
            return true;
        }

        #endregion

        #region Events

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
                //else
                //    JMessages.Information("Please  Enter Correct Data", "Information");
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                   ContractForms.BackForm();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        #endregion

        private void LoadData(int pCode)
        {
            try
            {
                _DecisionCode = pCode;
                JDecision tmp = new JDecision(pCode);
                txtNumber.Text = tmp.Code.ToString();
                txtDate.Date = tmp.Date;
                txtNum.Text = tmp.number;
                jArchiveListDecision.ClassName = "Legal.Jdecision";
                jArchiveListDecision.SubjectCode = 0;
                jArchiveListDecision.PlaceCode = 0;
                jArchiveListDecision.ObjectCode = pCode;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                JDecisionSearchForm p = new JDecisionSearchForm();
                p.ShowDialog();
                if (p._Code != 0)
                    LoadData(p._Code);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void JDecisionForm1_Load(object sender, EventArgs e)
        {
            try
            {
                if ((ContractForms.Contract.Code != 0) && (State != JStateContractForm.Update))
                {
                    Set_Form();
                    State = JStateContractForm.Update;
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }


    }
}
