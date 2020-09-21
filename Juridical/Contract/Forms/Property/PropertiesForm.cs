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
    public partial class JPropertiesForm : JBaseContractForm
    {
        public JPropertiesForm()
        {
            InitializeComponent();
            jPropertyValueUserControl1.ClassName = "Legal.JContractDynamicTypeForm";
            if (ContractForms != null)
            {
                jPropertyValueUserControl1.ObjectCode = ContractForms.Contract.ContractType.Code;
                if (ContractForms.Contract.Code > 0)
                    jPropertyValueUserControl1.ValueObjectCode = ContractForms.Contract.Code;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                if (CheckData())
                    if (ApplyData())
                        ContractForms.NextForm();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }

        public bool ApplyData()
        {
            if (State == JStateContractForm.View) return true;
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public JPropertiesForm MakeForm()
        {
            JPropertiesForm form = new JPropertiesForm();
            return form;
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
                if (jPropertyValueUserControl1.ObjectCode <= 0)
                {
                    jPropertyValueUserControl1.ObjectCode = ContractTypeCode;
                    if (ContractForms != null)
                        jPropertyValueUserControl1.ValueObjectCode = ContractForms.Contract.Code;
                }
                DataRow DR = jPropertyValueUserControl1.GetDataRowValue();
                if(DR != null)
                foreach (DataColumn DC in DR.Table.Columns)
                {
                    pDt.Columns.Add(DC.Caption);
                    if (pSetValue)
                    {
                        if (pOffline)
                            Fill_Data();

                        pDt.Rows[0][DC.Caption] = DR[DC.Caption];
                    }
                }
                return true;
            }
            catch
            {
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
            if (ContractForms.Contract.Code != jPropertyValueUserControl1.ValueObjectCode)
                jPropertyValueUserControl1.ValueObjectCode = ContractForms.Contract.Code;
            jPropertyValueUserControl1.Save(tempdb);
            return true;
        }

        private void Fill_Data()
        {                jPropertyValueUserControl1.ObjectCode = ContractForms.Contract.ContractType.Code;
                if (ContractForms.Contract.Code > 0)
                    jPropertyValueUserControl1.ValueObjectCode = ContractForms.Contract.Code;

        }

        private void JPropertiesForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible && ContractForms != null)
            {
                Fill_Data();
            }
        }

    }
}
