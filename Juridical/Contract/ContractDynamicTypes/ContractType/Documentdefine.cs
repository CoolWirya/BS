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
    public partial class JdocumentdefineForm : JBaseContractForm
    {
        public JdocumentdefineForm(int pDynamicType)
            : this(pDynamicType, 0)
        {
            this.State = JStateContractForm.Insert;
        }

        private int _Code;
        private int _DynamicCode;
    #region Methods

        public JdocumentdefineForm(int pDynamicType, int pCode)
        {
            InitializeComponent();
            _DynamicCode = pDynamicType;
            FillCombo();
            if (pCode > 0)
            {
                this.State = JStateContractForm.Update;
                _Code = pCode;
                 textControl1.Load("Legal.JContractdefine", pCode);
            }
            else
            {
                textControl1.Load(pCode); //"Legal.JContractdefine",
            }
        }

        private void FillCombo()
        {
            //cmbSubject.DisplayMember = "Title";
            //cmbSubject.ValueMember = "Code";
            //cmbSubject.DataSource  = JContractDynamicTypes.GetDataTable(0);

            ///فیلدهای متن قرارداد
            textControl1.ClearCombo();
            btnSave.Enabled = true;
            DataTable dt = new DataTable();
            JContractDynamicType dynamicType = new JContractDynamicType(_DynamicCode);
            cmbSubject.Text = dynamicType.Title;
            JAction SaveAction = new JAction("FieldList", dynamicType.ClassName + ".FieldList", new object[] { dynamicType.PrtClassName, dynamicType.PrtObjectCode }, null);
            dt = (DataTable)SaveAction.run();

            JGeneralContract GD = new JGeneralContract(_DynamicCode);

            DataTable dt1 = new DataTable();
            dt1 = GD.ContractForms.SavePrviewColumn();
            if (dt != null)
                dt1.Merge(dt);
            textControl1.datatable = dt1;
        }

        public void setForm()
        {
            JContractdefine tmp = new JContractdefine(_Code);
            //cmbSubject.SelectedValue = tmp.ContractType;
            txtTitle.Text = tmp.Title;
        }

        public bool Save()
        {
            JDataBase DB = new JDataBase();
            try
            {
                if (txtTitle.Text.Trim() == "")
                {
                    JMessages.Error("لطفا عنوان متن را وارد کنید", "");
                    txtTitle.Focus();
                    return false;
                }
                DB.beginTransaction("Document Define");
                JContractdefine tmp = new JContractdefine();
                tmp.Title = txtTitle.Text;
                tmp.ContractType = Convert.ToInt32(_DynamicCode);
                if (State != JStateContractForm.Update)
                {
                    _Code = tmp.Insert(DB);
                    if (_Code > 0)
                    {
                        ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
                        adb.beginTransaction("");
                        DB.ADDRelation(adb);
                        if (!textControl1.Save(adb, "Legal.JContractdefine", _Code))
                        {
                            DB.Rollback("Document Define");
                            return false;
                        }

                        State = JStateContractForm.Update;
                        DB.Commit();

                        //Hassanzadeh
                        if (textControl1.FileCode > 0)
                            OfficeWord.JOfficeWord.TagXml(textControl1.FileCode,
                                textControl1.XMLContent, textControl1.TextContent);


                        return true;
                    }
                    else
                    {
                        DB.Rollback("Document Define");
                        return false;
                    }
                }
                else
                {
                    tmp.Code = _Code;
                    if (tmp.Update(DB))
                    {
                        ArchivedDocuments.JArchiveDataBase adb = new ArchivedDocuments.JArchiveDataBase();
                        adb.beginTransaction("");
                        DB.ADDRelation(adb);
                        
                        if (!textControl1.Save(adb, "Legal.JContractdefine", _Code))
                        {
                            DB.Rollback("Document Define");
                            return false;
                        }
                        State = JStateContractForm.Update;
                        DB.Commit();

                        if (textControl1.FileCode > 0)
                            OfficeWord.JOfficeWord.TagXml(textControl1.FileCode,
                                textControl1.XMLContent, textControl1.TextContent);
                        return true;
                    }
                    else
                    {
                        DB.Rollback("Document Define");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                DB.Rollback("Document Define");
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

    #endregion

    #region Events
       
        private void btnSaveClose_Click(object sender, EventArgs e)
        {
            if (Save())
                Close();
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                if (Save())
            {
                btnSave.Enabled = false;
                this.State = JStateContractForm.Update;                    
            }
            else
                JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (btnSave.Enabled == true)
            {
                if (JMessages.Question("DoYouWantToSaveChanges", "Information") == DialogResult.OK)
                    if (Save())
                        this.Close();
                    else
                        JMessages.Message("Process Not Successfuly ", "", JMessageType.Information);
                else
                    this.Close();
            }
            else
                this.Close();
        }

        //private void btnFile_Click(object sender, EventArgs e)
        //{
        //    JTextContractForm p = new JTextContractForm();
        //    p.ShowDialog();
        //    OfficeWord.JOfficeWord tmp = new OfficeWord.JOfficeWord();
        //    //FileCode = tmp.Insert(doc.Content.get_XML(false).ToString(), DocumentText);
        //}

        private void cmbSubject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textControl1.ClearCombo();

            //btnSave.Enabled = true;
            //DataTable dt=new DataTable();
            //JContractDynamicType dynamicType = new JContractDynamicType(Convert.ToInt32(cmbSubject.SelectedValue));
            //JAction SaveAction = new JAction("FieldList", ((System.Data.DataRowView)(cmbSubject.SelectedItem)).Row["ClassName"] + ".FieldList", new object[] { dynamicType.PrtClassName, dynamicType.PrtObjectCode }, null);
            //dt = (DataTable)SaveAction.run();
            
            //JGeneralContract GD = new JGeneralContract((int)((System.Data.DataRowView)(cmbSubject.SelectedItem)).Row.ItemArray[0]);

            //DataTable dt1 = new DataTable();
            //dt1 = GD.ContractForms.SavePrviewColumn();
            //dt1.Merge(dt);
            //textControl1.datatable = dt1;
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void ContractFiletextBox_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }
        #endregion

        private void JdocumentdefineForm_Load(object sender, EventArgs e)
        {
            //FillCombo();
            if (this.State == JStateContractForm.Update)
                setForm();            
        }

        private void JdocumentdefineForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            textControl1.CLoseControl();
            textControl1.Dispose();
        }

    }
}
