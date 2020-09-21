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
    public partial class JDeadForm : JBaseForm
    {
        ///// <summary>
        ///// تاریخ فوت وارد شده
        ///// </summary>
        //public DateTime DeadDate;
        ///// <summary>
        ///// گواهی فوت
        ///// </summary>
        //public string DeadNo;
        ///// <summary>
        ///// تاریخ گواهی فوت
        ///// </summary>
        //public DateTime DeathCertificateDate;

        private JDeadPerson _DeadPerson;
        private JPerson _Person;
        /// <summary>
        /// سازنده فرم
        /// </summary>
        /// <param name="person"></param>
        private void _LoadForm()
        {
            if (_Person.Died)
            {
                _DeadPerson = _DeadPerson;
                txtDeadDate.Text = JDateTime.FarsiDate(_DeadPerson.DieDate);
                txtDeathCertificateDate.Text = JDateTime.FarsiDate(_DeadPerson.DeathCertificateDate);
                txtDeadNo.Text = _DeadPerson.DieNumber;
            }
            txtCode.Text = _Person.Code.ToString();
            lbFatherName.Text = _Person.FatherName;
            lbLastname.Text = _Person.Fam;
            lbName.Text = _Person.Name;
            lbSHMelli.Text = _Person.ShMeli;
            lbShSh.Text = _Person.ShSh;
            jArchiveList1.ClassName = _DeadPerson.GetType().FullName;
            jArchiveList1.ObjectCode = _Person.Code;
            jArchiveList1.SubjectCode =ArchivedDocuments.JConstantArchiveSubjects.OtherImagesArchiveCode.GetHashCode();
            jArchiveList1.PlaceCode = ArchivedDocuments.JConstantArchivePalces.GeneralArchive.GetHashCode();
        }

        public JDeadForm()
        {
            InitializeComponent();
        }
        public JDeadForm(int pPCode)
        {
            InitializeComponent();
            _DeadPerson = new JDeadPerson(pPCode);
            if (!_DeadPerson.GetData())
                State = JFormState.Insert;
            else
                State = JFormState.Update;
            _Person = new JPerson(pPCode);
            _LoadForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region Check Controls
            if (txtDeadDate.Date == DateTime.MinValue)
            {
                string[] parameters = { "@Value" };
                string[] values = { "Date" };
                string msg = JLanguages._Text("PleaseEnter", parameters, values);
                JMessages.Error(msg, "Error");
                txtDeadDate.Focus();
                return;
            }

            if (txtDeadDate.Date > JDateTime.Now())
            {
                JMessages.Error("InvalidDateValue", "Error");
                txtDeadDate.Focus();
                return;
            }

            if (txtDeadDate.Date > txtDeathCertificateDate.Date)
            {
                JMessages.Error("DeadDateIsBiggerThanCerDate", "Error");
                txtDeadDate.Focus();
                return;
            }
#endregion Check Controls
           
           _DeadPerson.DieDate = txtDeadDate.Date;
           _DeadPerson.DeathCertificateDate = txtDeathCertificateDate.Date;
           _DeadPerson.DieNumber = txtDeadNo.Text;
           if (State == JFormState.Insert)
           {
               _DeadPerson.Insert();
           }
           if (State == JFormState.Update)
           {
               _DeadPerson.Update();
           }

		   jArchiveList1.ArchiveList();
            DialogResult = DialogResult.OK;
            
        }

        private void numEdit2_Leave(object sender, EventArgs e)
        {
            //if (numEdit2.Text == "")
            //    return;
            //int code = Convert.ToInt32(numEdit2.Text);
            ////DataTable table = JPerson.SearchPerson(code);
            ////label13.Text = table.Columns["Name"];

            //JDataBase Db = new JDataBase();
            //Db.setQuery("select Name,Fam,FatherName,ShSh from clsPerson where(code=" + code + ")");
            //Db.Query_DataReader();
            //if (Db.DataReader.Read())
            //{
            //    label13.Text = Db.DataReader["Name"].ToString();
            //    label14.Text = Db.DataReader["Fam"].ToString();
            //    label15.Text = Db.DataReader["ShSh"].ToString();

            //}
            //else
            //{
            //    MessageBox.Show("این کد وجود ندارد.");
            //}
            //Db.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

      

       
    }
}
