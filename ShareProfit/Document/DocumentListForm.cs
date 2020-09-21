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
    public partial class JDocumentListForm : JBaseForm
    {
        public JDocumentListForm()
        {
            InitializeComponent();
            FillGrid();
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JDocumentListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JDocumentForm form = new JDocumentForm();
            form.State = JFormState.Insert;
            form.ShowDialog();
            FillGrid();
        }
        private void FillGrid()
        {
            DataTable table = new DataTable();
            JSDocument doc = new JSDocument();
            table = doc.SelectAllDocs();
            dataGridView1.DataSource = table;
            dataGridView1.Columns["doccost"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["coursecode"].Visible = false;
            //dataGridView1.Columns["doccode"].Visible = false;
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                JMessages.Error("PleaseSelectARow", "Error");
                return;
            } 
            //JSDocument doc = JSDocument.FindDocument(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["doccode"].Value));
            //JCourse course = JCourse.FindCourse(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["coursecode"].Value));
            //JBaseDefine PayLoc = new JBaseDefine();
            //JPaymentForm form = new JPaymentForm(doc, course);
            //form.formState = JFormState.Insert;
            //form.ShowDialog();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            if (dataGridView1.SelectedRows.Count <= 0)
            {
                JMessages.Error("PleaseSelectARow", "Error");
                return;
            }
            JDocumentForm form = new JDocumentForm(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["doccode"].Value));
            form.ShowDialog();
            FillGrid();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string[] parameters = { "@Value" };
            string[] values = { "سند" };
            string msg = JLanguages._Text("AreYouSureYouWantToDelete", parameters, values);
            if (JMessages.Message(msg, "", JMessageType.Question) == DialogResult.Yes)
            {
                JSDocument doc = new JSDocument();
                doc.Code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["code"].Value);

                FillGrid();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            btnPay.PerformClick();
        }
    }
}
