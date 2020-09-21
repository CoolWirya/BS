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
    public partial class JAmendmentForm : JBaseContractForm
    {
        public DataTable DataTableC = new DataTable();
        
        public JAmendmentForm()
        {
            InitializeComponent();
            SaveOrder = 20;
        }


        public JAmendmentForm(DataTable pDt)
        {
            InitializeComponent();
            DataTableC = pDt;
            SaveOrder = 20;
        }

        public JAmendmentForm MakeForm()
        {
            JAmendmentForm form = new JAmendmentForm();
            return form;
        }
        
        private void btnNext_Click(object sender, EventArgs e)
        {
            ContractForms.NextForm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ContractForms.BackForm();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
        }

        bool CreateText;
        private void AmendmentForm_Load(object sender, EventArgs e)
        {
            CreateText = false;
        }

        private void JAmendmentForm_VisibleChanged(object sender, EventArgs e)
        {
            try
            {
                
                if (Visible )
                {
                    if (State == JStateContractForm.View)
                    {
                        winWordControl1.GetData("Legal.JContractForms", ContractForms.Contract.Code);
                        winWordControl1.LoadDocument();
                    }
                    else
                    {
                        if (JMessages.Question("آیا میخواهید متن قرارداد ایجاد شود؟", "سوال") != DialogResult.Yes)
                        {
                            return;
                        }
                      
                        DataTableC = ContractForms.SavePreview();
                        if (DataTableC != null)
                        {
                            JContractdefine tmp = new JContractdefine(ContractForms.Contract.Type);
                            JContractDynamicType dynamicType = new JContractDynamicType(tmp.ContractType);

                            winWordControl1.GetData("Legal.JContractdefine", tmp.Code);
                            winWordControl1.LoadDocument();
                            winWordControl1.Reaplce(DataTableC);

                            // اطلاعات ریز اموال
                            Finance.JAsset tmpAsset = new Finance.JAsset(Convert.ToInt32(DataTableC.Rows[0]["FinanceCode"]));
                            DataTable dt = new DataTable();
                            JAction SaveAction = new JAction("FieldList", tmpAsset.ClassName + ".GetContractData", new object[] { tmpAsset.ObjectCode, dynamicType.PrtClassName, dynamicType.PrtObjectCode }, null);
                            dt = (DataTable)SaveAction.run();
                            if (dt != null)
                                winWordControl1.Reaplce(dt);
                        }
                        else
                        {
                            JMessages.Error("Error in Contract Data", "Error");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        public override bool SavePreview(DataTable pDt)
        {
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

        public override bool Save(ClassLibrary.JDataBase tempdb)
        {
            ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
            adb.beginTransaction("Transaction");
            tempdb.ADDRelation(adb);
            try
            {
                tempState = State;
                bool ret = winWordControl1.SaveInOfficeWord(adb, "Legal.JContractForms", ContractForms.Contract.Code, true);
                if (ret)
                {
                    if (winWordControl1.FileCode > 0)
                    {
                        ContractForms.Contract.FileCode = winWordControl1.FileCode;
                    }
                }
                return ret;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
        }

        private void JAmendmentForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            winWordControl1.CloseControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            ContractForms.Cancel();
        }
    }
}
