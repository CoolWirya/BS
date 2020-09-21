using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ArchivedDocuments
{
    public partial class JArchiveForm : Globals.JBaseForm
    {
        public JArchiveForm(DataRow pFiles)
        {
            InitializeComponent();
            DataTable _DT = pFiles.Table.Clone();
//            _DT.Rows.CopyTo(new DataRow[] { pFiles });
            
        }

        public JArchiveForm(DataTable pFiles)
        {
            InitializeComponent();
            Files = pFiles;
        }
        public int[] ArchivedCodes;
        /// <summary>
        /// لیست فایلها جهت آرشیو
        /// </summary>
        public DataTable Files
        {
            get;
            set;
        }
       
        private void _SetComboBox()
        {
        }
        /// <summary>
        /// پر کردن لیست ویو
        /// </summary>
        private void _LoadFilesInListView()
        {
        }

        private bool _ArchiveFiles()
        {
            int SubjectCode = txtSubjectCode.IntValue;
            int PlaceCode = txtPlaceCode.IntValue;
            try
            {
                foreach (DataRow file in Files.Rows)
                {
                    file["SubjectCode"] = SubjectCode;
                    file["PlaceCode"] = PlaceCode;
                    file["ArchiveDesc"] = txtDescription;
                }
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
            }
        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (txtSubjectCode.Text == "")
            {
                string[] param = { "@Value" };
                string[] value = { "SubjectArchive" };
                string msg = "PleaseEnter";
                JMessages.Error(JLanguages._Text(msg, param, value), "Error");
                return;
            } 
            _ArchiveFiles();
            this.Dispose();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {            
            _LoadFilesInListView();
        }

        private void btnSearchPlace_Click(object sender, EventArgs e)
        {
            JPlacesForm placeForm = new JPlacesForm();
            if (placeForm.ShowDialog() == DialogResult.OK)
            {
                txtPlaceCode.Text = ((JCustomTreeNode)placeForm.SelectedItem).Code.ToString();
                txtPlaceName.Text = ((JCustomTreeNode)placeForm.SelectedItem).ToString();
            }
        }

        private void btnSearchSubject_Click(object sender, EventArgs e)
        {
            JSubjectForm subject = new JSubjectForm();
            if (subject.ShowDialog() == DialogResult.OK)
            {
                txtSubjectCode.Text = ((JCustomTreeNode)subject.SelectedItem).Code.ToString();
                txtSubjectName.Text = ((JCustomTreeNode)subject.SelectedItem).ToString();
            }
        }
    }
}

