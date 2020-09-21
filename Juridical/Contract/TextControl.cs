using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OfficeWord;
using ClassLibrary;

namespace Legal
{
    public partial class TextControl : UserControl
    {
        /// <summary>
        /// کد فایل ذخیره شده در OfficeWord
        /// </summary>
        private int _FileCode = 0;
        public int FileCode
        {
            get
            {
                return _FileCode;
            }
            set
            {
                if (_FileCode != value)
                {
                    _FileCode = value;
                    Load();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public DataTable _dt { get; set; }

        public TextControl()
            : this(null, 0)
        {

        }

        public TextControl(DataTable pDt, int pFileCode)
        {
            InitializeComponent();
            _FileCode = pFileCode;
            if (pDt != null)
            {
                _dt = pDt;
                Fillcombo();
            }
        }

        public void FillData(DataTable pDt, int pFileCode)
        {
            _dt = pDt;
            _FileCode = pFileCode;
            Fillcombo();
        }
        
        public void Fillcombo()
        {
            //cmbFields.DisplayMember = "Name";
            //cmbFields.ValueMember = "Code";
            //cmbFields.DataSource = _dt;
            if (_dt != null)
                for (int i = 0; i < _dt.Columns.Count; i++)
                    cmbFields.Items.Add(_dt.Columns[i].Caption);
        }

        #region Events

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cmbFields.Text != "")
            {
                objWinWordControl.document.Application.Selection.Text = " <" + cmbFields.Text.ToString() + "> ";
                objWinWordControl.document.Application.Selection.FormattedText.HighlightColorIndex = Microsoft.Office.Interop.Word.WdColorIndex.wdYellow;
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
           for (int i = 0; i < _dt.Columns.Count; i++)
              if(_dt.Columns[i].Caption == str)
                  return _dt.Rows[0][str].ToString();
           return "";
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            objWinWordControl.document.PrintPreview();
            //for (int i = 1; i < objWinWordControl.document.Words.Count; i++)
            //{
            //    if (objWinWordControl.document.Words[i].Text == "<")
            //    {
            //        if ((i + 2) <= objWinWordControl.document.Words.Count)
            //        {
            //            string str = DataDT(objWinWordControl.document.Words[i + 1].Text);
            //            if (str != "")
            //            {
            //                objWinWordControl.document.Words[i + 1].Text = "";
            //                //objWinWordControl.document.Words.Item(i + 1).Text = "";
            //                objWinWordControl.document.Words[i].Text = " " + str + " ";// DataDT(objWinWordControl.document.Words.Item(i + 1).Text);
            //            }
            //        }
            //    }
            //}
        }

        public bool Save()
        {
            return objWinWordControl.SaveInOfficeWord();
            //JOfficeWord tmp = new JOfficeWord();
            //string DocumentText = objWinWordControl.document.Content.Text;
            //string DocumentXML = objWinWordControl.document.Content.get_XML(false).ToString();
            //tmp.Save = true;
            //_FileCode = tmp.Insert(DocumentXML, DocumentText);
            //if (_FileCode > 0)
            //    return true;
            //else
            //    return false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(Save())
                JMessages.Information("Please  Enter Correct Data", "Information");
            else
                JMessages.Information("Please  Enter Correct Data", "Information");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

    #endregion

        private void Load()
        {
            objWinWordControl.FileCode = _FileCode;
        }

        private void TextControl_Load(object sender, EventArgs e)
        {
            Fillcombo();
        }
    }
}
