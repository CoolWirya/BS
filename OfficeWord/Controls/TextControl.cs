using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace OfficeWord
{
    public partial class TextControl : UserControl
    {
        /// <summary>
        /// کد فایل ذخیره شده در OfficeWord
        /// </summary>
        //private int _FileCode = 0;
        public int FileCode
        {
            get
            {
                return objWinWordControl.FileCode;
            }
            set
            {
                objWinWordControl.FileCode = value;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private DataTable _datatable;
        public DataTable datatable
        {
            get
            {
                return _datatable;
            }
            set
            {
                if (_datatable != value)
                {
                    _datatable = value;
                    Fillcombo();
                }
            }
        }

        public string XMLContent
        {
            get
            {
                return objWinWordControl.stringContent;
            }
        }

        public string TextContent
        {
            get
            {
                return objWinWordControl.document.Content.Text;
            }
        }

        public TextControl()
            : this(null, 0)
        {

        }

        public TextControl(DataTable pDt, int pFileCode)
        {
            InitializeComponent();
            //FileCode = pFileCode;
            if (pDt != null)
            {
                _datatable = pDt;
                Fillcombo();
            }
            if (pFileCode > 0)
            {
                objWinWordControl.FileCode = pFileCode;
                objWinWordControl.LoadDocument();
            }
        }

        public TextControl(DataTable pDt, string pClassName, int pObjectCode)
        {
            InitializeComponent();
            if (pDt != null)
            {
                _datatable = pDt;
                Fillcombo();
            }
            if (pClassName.Length > 0 && pObjectCode > 0)
            {
                objWinWordControl.GetData(pClassName, pObjectCode);
                //FileCode = objWinWordControl.FileCode;
                objWinWordControl.LoadDocument();
            }
        }

        public void AddTable(DataTable pDt)
        {
            if (pDt == null) return;
            for (int i = 0; i < pDt.Columns.Count ; i++)
            {
                {
                    cmbFields.Items.Add(JLanguages._Text(pDt.Columns[i].ColumnName));
                }
            }
        }

        public void CLoseControl()
        {
            objWinWordControl.CloseControl();
        }

        public void Fillcombo()
        {
            cmbFields.DisplayMember = "Text";
            cmbFields.ValueMember = "Name";
            cmbFields.DataSource = _datatable;
            //for (int i = 0; i < _datatable.Rows.Count; i++)
            //    cmbFields.Items.Add(_datatable.Rows[i][0].ToString());
        }

        public void ClearCombo()
        {
            if (_datatable != null)
            {
                _datatable.Rows.Clear();
                cmbFields.DataSource = _datatable;
            }
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFields.Text != "")
                {
                    //if (((System.Data.DataRowView)(cmbFields.SelectedItem)).Row.ItemArray[1].ToString() == "")
                        objWinWordControl.document.Application.Selection.Text = " <" + cmbFields.Text.ToString() + "> ";
                    //else
                    //    objWinWordControl.document.Application.Selection.Text = " <" + ((System.Data.DataRowView)(cmbFields.SelectedItem)).Row.ItemArray[1].ToString() + "> ";
                        //objWinWordControl.document.Application.Selection.FormattedText.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdYellow;
                        objWinWordControl.document.Application.Selection.FormattedText.Bold = 1;
                }
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                //return null;
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
          for (int i = 1; i < objWinWordControl.document.Words.Count; i++)
          {
                if (objWinWordControl.document.Words[i].Text == "<")
                {
                    if ((i + 2) <= objWinWordControl.document.Words.Count)
                        if (cmbFields.Text.ToString() == objWinWordControl.document.Words[i + 1].Text)
                        {
                            objWinWordControl.document.Words[i + 1].Text = "";
                            //objWinWordControl.document.Words.Item(i + 1).Text = "";
                            objWinWordControl.document.Words[i].Text = "";
                        }
                }
            }
        }

        private string DataDT(string str)
        {
            for (int i = 0; i < _datatable.Columns.Count; i++)
                if (_datatable.Columns[i].Caption == str)
                    return _datatable.Rows[0][str].ToString();
           return "";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            objWinWordControl.Print();
        }

        public bool Save(ArchivedDocuments.JArchiveDataBase DB, string pClassName, int pObjectCode)
        {
            ArchivedDocuments.JArchiveDataBase PDB;
            if (DB == null)
                PDB = new ArchivedDocuments.JArchiveDataBase();
            else
                PDB = DB;
            try
            {
                if (objWinWordControl.SaveInOfficeWord(PDB, pClassName, pObjectCode, false))
                {
                    //_FileCode = objWinWordControl.FileCode;
                    return true;
                }
                return false;
            }
            finally
            {
                if (DB == null)
                    PDB.Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if(Save())
            //    JMessages.Information("Please  Enter Correct Data", "Information");
            //else
            //    JMessages.Information("Please  Enter Correct Data", "Information");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    #endregion

        public void Load()
        {
            Load(objWinWordControl.FileCode);
        }

        public void Load(int pFileCode)
        {
            //_FileCode = pFileCode;
            objWinWordControl.FileCode = pFileCode;
            objWinWordControl.LoadDocument();
        }

        public void Load(string pClassName, int pObjectCode)
        {
            objWinWordControl.GetData(pClassName, pObjectCode);
            FileCode = objWinWordControl.FileCode;
            objWinWordControl.LoadDocument();
        }

        private void TextControl_Load(object sender, EventArgs e)
        {
            Fillcombo();
        }

        public void Close()
        {
            try
            {
                if (objWinWordControl != null)
                    objWinWordControl.CloseControl();
            }
            catch
            {
            }
        }

    }

}
