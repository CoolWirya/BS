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
    public partial class JTextContractForm : JBaseContractForm
    {
        DataTable pDt = new DataTable();
        
        public JTextContractForm()
        {            
            InitializeComponent();
            FillList();
        }

        public JTextContractForm(DataTable pDt,string pContent)
        {
            InitializeComponent();
            FillList();
            //if(pContent != "")
            //    objTextWordControl.
        }

        private void FillList()
        {
            pDt.Columns.Add("Code");
            pDt.Columns.Add("Name");
            DataRow dr = pDt.NewRow();
            dr["Code"] = "1";
            dr["Name"] = "Ali";
            pDt.Rows.Add(dr);
            //for (int i = 0; i < pDt.Columns.Count; i++)
            //{
            //    cmbSubject.Items.Add(pDt.Columns[i].Caption);
            //}
        }

        private void JTextContractForm_Load(object sender, EventArgs e)
        {
            objTextWordControl.datatable = pDt;
            //objTextWordControl t = new objTextWordControl(pDt, "");
            //objWinWordControl.LoadDocument("C:\\Users\\hassanzadeh\\Desktop\\Sample Word2\\WordInDotNet_src\\Sample.dot");
            //objWinWordControl.document.Application.NewWindow();
            	
            //if(wd == null) wd = new Word.ApplicationClass();
            //    wd.CommandBars.AdaptiveMenus = false;
            //    wd.DocumentBeforeClose += new Word.ApplicationEvents2_DocumentBeforeCloseEventHandler(OnClose);
            //    wd.NewDocument += new Word.ApplicationEvents2_NewDocumentEventHandler(OnNewDoc);
				//wd.DocumentOpen+= new Word.ApplicationEvents2_DocumentOpenEventHandler(OnOpenDoc);
				//wd.ApplicationEvents2_Event_Quit += new Word.ApplicationEvents2_QuitEventHandler(OnQuit);
				
        }

        private void btnClientName_Click(object sender, EventArgs e)
        {
            //objWinWordControl.document.Application.Selection.Text = " <" + lvFiels.SelectedItems[0].ToString() + "> ";
            //objWinWordControl.document.Application.Selection.FormattedText.HighlightColorIndex = Word.WdColorIndex.wdYellow;
            
            //Word.Document wd = objWinWordControl.document;
            //wd.Sections.
            //objWinWordControl.document.sele
            //wa.Selection.TypeText(BookMarkText);
            // "<" + lvFiels.SelectedItems[0].Text + ">";
        }

    }
}
