using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;
namespace ShareProfit
{
    public partial class JDocumentForm : ClassLibrary.JBaseForm
    {
        private JSDocument _Document;
        public JDocumentForm()
        {
            InitializeComponent();
            _Document = new JSDocument();
            LoadData();
        }

        public JDocumentForm(int pCode)
        {
            InitializeComponent();
            _Document = new JSDocument(pCode);
            //_Document = JSDocument.FindDocument(pCode);
            if (_Document.DocNo != null)
            {
                LoadData();
                ShowData();
                State = JFormState.Update;
            }
        }
        public void LoadData()
        {
            JCourses courses = new JCourses();
            courses.GetLists("");

            foreach (JCourse course in courses.Items)
            {
                cmbCourse.Items.Add(course);
                if (course.Code == _Document.CourseCode)
                    cmbCourse.SelectedItem = course;
            }
            JSahamMaliCashes cahses = new JSahamMaliCashes();
            //foreach (JSubBaseDefine BS in cahses.Items)
            //{
            //    cmbPayLoc.Items.Add(BS);
            //    if (BS.Code == _Document.PayLoc)
            //        cmbPayLoc.SelectedItem = BS;
            //}
            cahses.SetComboBox(cmbPayLoc, _Document.PayLoc);

            cmbDefaultPayDate.DataSource  = ClassLibrary.Domains.JRealEstate.JDefaultPayDate.GetData();
            cmbDefaultPayDate.DisplayMember = "FarsiName";
            cmbDefaultPayDate.ValueMember = "value";
            cmbDefaultPayDate.SelectedValue = ClassLibrary.Domains.JRealEstate.JDefaultPayDate.DocumentDate;
            //cmbDefaultPayDate.Items.AddRange(ClassLibrary.JMainFrame.EnumToListBox(Type.GetType("ShareProfit.JDefaultPayDate")));
            //if (cmbDefaultPayDate.Items.Count > 0)
            //    cmbDefaultPayDate.SelectedIndex = 0;
        }

        private void ShowData()
        {
            try
            {

                txtDocDate.Text = _Document.DocDate;
                txtDocDesc.Text = _Document.DocDesc;
                txtDocNo.Text = _Document.DocNo;
                txtDocCost.Text = _Document.DocCost.ToString();
                //cmbCourse.SelectedItem = _Document.Course;
                //cmbPayLoc.SelectedItem = _Document.PayLoc;
                //btnSave.Enabled = false;
                chShowDeactive.Checked = _Document.ShowDeactiveSheet;
                cmbDefaultPayDate.SelectedValue = _Document.DefaultPayDate;
            }
            catch (Exception ex)
            {
            }
            //for (int i = 0; i < cmbDefaultPayDate.Items.Count; i++)
            //    if (_Document.DefaultPayDate.GetHashCode() == Convert.ToInt32(((ClassLibrary.JKeyValue)cmbDefaultPayDate.Items[i]).Value))
            //        cmbDefaultPayDate.SelectedItem = cmbDefaultPayDate.Items[i];
            ////    {
            ////        ((ClassLibrary.JKeyValue)chklistSubject.Items[i]).Value = Convert.ToInt32(dr["SubjectCode"]);
            ////        chklistSubject.SetItemChecked(i, true);
            ////    }
            ////}
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //JSDocument oldDocument = new JSDocument();
            //if (State == JFormState.Update)
              //  JSDocument.SetEqual(_Document, ref oldDocument);
            try
            {
                JCourse selCourse = new JCourse();
                selCourse = (JCourse)cmbCourse.SelectedItem;
                //JSubBaseDefine cash = new JSubBaseDefine(0);
                int cash = Convert.ToInt32(cmbPayLoc.SelectedValue);
                if (cash != null)
                {
                    _Document.PayLoc = cash;
                    _Document.CourseCode = selCourse.Code;
                    _Document.DocNo = txtDocNo.Text;
                    _Document.DocDesc = txtDocDesc.Text;
                    _Document.DocDate = txtDocDate.Text;
                    _Document.DocCost = txtDocCost.DecimalValue;
                    _Document.ShowDeactiveSheet = chShowDeactive.Checked;
                    _Document.DefaultPayDate = Convert.ToInt32(cmbDefaultPayDate.SelectedValue);
                }
                else
                    return;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return;
            }
            if (State == JFormState.Insert)
            {
                int dCode = _Document.insert();
                if (dCode > 0)
                {
                    State = JFormState.Update;
                    if (dCode == 0) return;
                }
            }
            if (State == JFormState.Update)
            {
                if (!_Document.Update())
                    return;
            }
            btnSave.Enabled = false;
        }

        private void txtDocNo_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = true;
        }

        private void txtDocNo_Leave(object sender, EventArgs e)
        {
            //if (txtDocNo.Text.Trim() == "")
            //    return;
            //JSDocument document = new JSDocument();
            //document = JSDocument.FindDocument(txtDocNo.Text);
            //if (document.DocNo != null)
            //{
            //    _Document = document;
            //    ShowData();
            //    State = JFormState.Update;
            //}
        }

        private void JDocumentForm_Load(object sender, EventArgs e)
        {

        }
    }
}
