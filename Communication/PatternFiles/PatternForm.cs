using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
using OfficeWord;

namespace Communication
{
    public partial class JPatternForm : JBaseForm
    {
        JPatternFile _pattern;
        public JPatternForm(int pCode)
        {
            InitializeComponent();
            //textControl1.datatable = JCLetterRegisters.GetDataTable(0, 0);
            if (pCode > 0)
            {
                _pattern = new JPatternFile(pCode);
                this.State = JFormState.Update;
                _Code = pCode;
                txtTitle.Text = _pattern.Name;
                textControl1.Load("Communication.JPatternFile", pCode);
            }
            else
                textControl1.Load(0);
            textControl1.AddTable(JCLetterRegisterInternals.GetDataTablePattern(-1));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        int _Code;

        private bool Save()
        {
            JDataBase DB = new JDataBase();
            try
            {
                if (txtTitle.Text.Trim() == "")
                {
                    JMessages.Error("لطفا عنوان را وارد کنید", "");
                    txtTitle.Focus();
                    return false;
                }
                DB.beginTransaction("Document Define");
                JPatternFile  ptrnFile  = new JPatternFile();
                ptrnFile.Name = txtTitle.Text;
                ptrnFile.Type = 0;
                ptrnFile.User_Code = JMainFrame.CurrentUserCode;
                
                if (State == JFormState.Insert)
                {
                    _Code = ptrnFile.Insert();
                    if (_Code > 0)
                    {
                        if (!textControl1.Save(DB, "Communication.JPatternFile", _Code))
                        {
                            DB.Rollback("Document Define");
                            return false;
                        }
                        State = JFormState.Update;
                        DB.Commit();
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
                    ptrnFile.Code = _Code;
                    if (ptrnFile.Update())
                    {
                        if (!textControl1.Save(DB, "Communication.JPatternFile", _Code))
                        {
                            DB.Rollback("Document Define");
                            return false;
                        }
                        State = JFormState.Update;
                        DB.Commit();
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
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                //   btnSave.Enabled = false;
                JMessages.Information("فایل الگو ثبت شد", "");
            else
                JMessages.Error("عملیات ثبت با مشکل مواجه شده است", "");
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

    }
}
