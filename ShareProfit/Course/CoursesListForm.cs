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
    public partial class JCoursesListForm : JBaseForm
    {
        public JCoursesListForm()
        {
            InitializeComponent();
            FillGrid();
        }
        private void FillGrid()
        {
            JCourses courses = new JCourses();
            dataGridView1.DataSource = courses.GetDataTable();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            JCourse course = new JCourse();
            course.Code = 0;
            JCourseForm form = new JCourseForm(course.Code);
            form.State = JFormState.Insert;
            form.ShowDialog();
            FillGrid();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
                return;
            JCourse course = new JCourse(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["code"].Value));
            //course = JCourse.FindCourse(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["code"].Value));
            if (course.FinYear != null)
            {
                JCourseForm form = new JCourseForm(course.Code);
                form.State = JFormState.Update;
                form.ShowDialog();
                FillGrid();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void JCoursesListForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            string[] parameters = { "@Value" };
            string[] values = { JLanguages._Text("Course") };
            string msg = JLanguages._Text("AreYouSureYouWantToDelete", parameters, values);
            if (JMessages.Message(msg, "", JMessageType.Question) == DialogResult.Yes)
            {
                JCourse course = new JCourse();
                course.Code = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["code"].Value);
                if (course.Delete() == -1)
                {
                    string[] parameters1 = { "@Value1", "@Value2" };
                    string[] values1 = { JLanguages._Text("Course"), JLanguages._Text("Document") };
                    msg = JLanguages._Text("ItemHasSomeSubItems", parameters1, values1);
                    JMessages.Message(msg, "", JMessageType.Error);
                    return;
                }
                FillGrid();
            }
        }
    }
}
