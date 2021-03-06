/// Code was received from: http://www.codeproject.com/cs/miscctrl/winwordcontrol.asp
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using ClassLibrary;
using System.Diagnostics;

namespace OfficeWord
{
	/// <summary>
	/// WinWordControl allows you to load doc-Files to your
	/// own application without any loss, because it uses 
	/// the real WinWord.
	/// </summary>
    public class WinWordControl : System.Windows.Forms.UserControl
    {

        /// <summary>
        /// Change. Made the following variables public.
        /// </summary>

        public Microsoft.Office.Interop.Word.Document document;
        public Microsoft.Office.Interop.Word.Application wd = null;

        //public Statusstrip progressBar;

        private bool deactivateevents = false;

        public string Text
        {
            get
            {
                return document.Content.Text;
            }
        }
        public string stringContent
        {
            get
            {
                try
                {
                    return document.Content.get_XML(false);
                }
                catch
                {
                    return "";
                }
            }
            set
            {
                document.Content.InsertXML(value);
            }
        }
        /// <summary>
        /// کد فایل ذخیره شده در OfficeWord
        /// </summary>
        /// 

        public void ChangeToViewMode()
        {
            Microsoft.Office.Core.CommandBars cbs = null;
            cbs = document.CommandBars;
            foreach (Microsoft.Office.Core.CommandBar cb in cbs)
            {
                if (cb.Name == "Ribbon")
                {

                    if (cb.Height > 90)
                    {
                        document.Activate();
                        //to get focus on current workbook so that sendkeys will work
                         System.Windows.Forms.SendKeys.Send("^{F1}"); 
                   }

                }
            }
        }

        private int _FileCode;
        private StatusStrip statusStrip1;
        private ToolStripProgressBar progressBar;
    
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
                }
            }
        }

        public string ClassName;
        public int ObjectCode;
        private Panel PanelMain;

        private bool _ReadOnly;

        public bool ReadOnly
        {
            get
            {
                return _ReadOnly;
            }
            set
            {
                _ReadOnly = value;
            }
        }
        #region security
        #endregion
        /// <summary>
        /// needed designer variable
        /// </summary>
        private System.ComponentModel.Container components = null;

        public WinWordControl()
        {
            InitializeComponent();
            progressBar = progressBar;
        }

        /// <summary>
        /// cleanup Ressources
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            CloseControl();
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code
        /// <summary>
        /// !do not alter this code! It's designer code
        /// </summary>
        private void InitializeComponent()
        {
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 132);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(148, 22);
            this.statusStrip1.TabIndex = 47;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressBar
            // 
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Visible = false;
            // 
            // PanelMain
            // 
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(148, 132);
            this.PanelMain.TabIndex = 48;
            this.PanelMain.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
            // 
            // WinWordControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.statusStrip1);
            this.Name = "WinWordControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(148, 154);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public void GetData()
        {
            if (ClassName.Length == 0 || ObjectCode == 0)
                throw new Exception();
            GetData(ClassName, ObjectCode);
        }

        public void GetData(string pClassname, int pObjectCode)
        {
            if (pClassname.Length == 0 || pObjectCode == 0)
                throw new Exception();
            JOfficeWord Office = new JOfficeWord();
            Office.GetData(pClassname, pObjectCode);

            ClassName = pClassname;
            ObjectCode = pObjectCode;

            _FileCode = Office.Code;
            Office.Dispose();
        }

        public void Compare(int pCode)
        {
            object missing = System.Reflection.Missing.Value;

            JOfficeWord Of = new JOfficeWord();
            Of.GetData(pCode);

            if (document != null)
            {
                string UniqCode = "ERPOFFiceWORD" + new Random().Next(10000000).ToString();
                
                object Cfile = new JConfig().TempPath + "\\temptempword" + UniqCode + ".xml";
                object Confirm = false;
                object isReadOnly = ReadOnly;

                System.IO.StreamWriter fs = new System.IO.StreamWriter((string)Cfile);
                fs.Write(Of.DocumentContent);
                fs.Close();

                document.Compare((string)Cfile, ref missing, ref missing, ref missing, ref missing, ref missing
                    , ref missing, ref missing);
            }
            Of.Dispose();
        }


        public void GetData(int pCode)
        {
            JOfficeWord Office = new JOfficeWord();
            Office.GetData(pCode);

            ClassName = Office.ClassName;
            ObjectCode = Office.ObjectCode;

            _FileCode = Office.Code;
            Office.Dispose();
        }
        
        /// <summary>
        /// Preactivation
        /// It's usefull, if you need more speed in the main Program
        /// so you can preload Word.
        /// </summary>
        public void PreActivate()
        {
            if (!DesignMode)
                if (wd == null) wd = new Microsoft.Office.Interop.Word.Application();
        }


        /// <summary>
        /// Close the current Document in the control --> you can 
        /// load a new one with LoadDocument
        /// </summary>
        public bool isClosed = false;
        public void CloseWord()
        {
            if (isClosed)
                return;
            try
            {
                isClosed = true;
                System.Threading.Thread.Sleep(500);
                deactivateevents = true;
                object dummy = null;
                if (wd != null && wd.Documents != null)
                {
                    try
                    {
                        JFile File = new JFile();
                        File.FileName = new JConfig().TempPath + "\\temptempword" + document._CodeName + ".xml";
                        File.Delete();
                    }
                    catch
                    {
                    }

                    wd.Documents.Close(ref dummy, ref dummy, ref dummy);

                }
                deactivateevents = false;
            }
            catch
            {
            }
        }

        public void CloseControl()
        {

            //isClosed = true;
            object dummy = null;
            object dummy2 = (object)false;
            try
            {
                CloseWord();
                deactivateevents = true;
                if (document != null)
                {
                    try
                    {
                        document.Close(ref dummy, ref dummy, ref dummy);
                        document = null;
                    }
                    catch
                    {
                        document = null;
                    }
                    try
                    {
                        if (wd != null)
                        {
                            wd.Quit(ref dummy2, ref dummy, ref dummy);
                            wd = null;
                        }
                    }
                    catch
                    {
                        wd = null;
                    }
                }
                // Change the line below.
                deactivateevents = false;
            }
            catch (Exception ex)
            {
                String strErr = ex.Message;
            }
            finally
            {
                try
                {
                }
                catch
                {
                }
            }
        }

        /// <summary>
        /// catches Word's close event 
        /// starts a Thread that send a ESC to the word window ;)
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="test"></param>
        private void OnClose(Microsoft.Office.Interop.Word.Document doc, ref bool cancel)
        {
            if (!deactivateevents)
            {
                CloseControl();
                cancel = true;
            }
        }

        /// <summary>
        /// catches Word's open event
        /// just close
        /// </summary>
        /// <param name="doc"></param>
        private void OnOpenDoc(Microsoft.Office.Interop.Word.Document doc)
        {
            
            if (!DesignMode)
                OnNewDoc(doc);
        }

        /// <summary>
        /// catches Word's newdocument event
        /// just close
        /// </summary>
        /// <param name="doc"></param>
        private void OnNewDoc(Microsoft.Office.Interop.Word.Document doc)
        {
            if (!deactivateevents && !DesignMode)
            {
                try
                {
                    if (doc != null && document != null)
                    {
                        Object oBookMark = "My_Custom_BookMark";
                        Object oTrue = true;
                        Object oFalse = false;
                        Object oMissing = System.Reflection.Missing.Value;
                        Object Start = 0;
                        Object End = 0;
                        document.Range(ref Start, ref End).InsertFile(doc.Path+"\\"+doc.Name, ref oMissing, ref oFalse, ref oFalse, ref oTrue);
                        
                        //oWordDoc.Bookmarks.get_Item(ref oBookMark).Range.InsertFile(oFilePath, ref oMissing, ref oFalse, ref oFalse, ref oFalse);

                    }
                }
                catch
                {
                }
                deactivateevents = true;
                object dummy = null;
                doc.Close(ref dummy, ref dummy, ref dummy);
                deactivateevents = false;
            }
        }

        /// <summary>
        /// catches Word's quit event
        /// normally it should not fire, but just to be shure
        /// safely release the internal Word Instance 
        /// </summary>
        private void OnQuit()
        {
            wd = null;
        }


        /// <summary>
        /// Loads a document into the control
        /// </summary>
        /// <param name="t_filename">path to the file (every type word can handle)</param>
        public void LoadDocument()
        {
            LoadDocument("");
        }
        public void LoadDocument(string pDefaultData)
        {
            if (DesignMode) return;

            deactivateevents = true;

            if (wd == null) wd = new Microsoft.Office.Interop.Word.Application();

            try
            {
                wd.DocumentBeforeClose += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(OnClose);
                wd.DocumentOpen += new Microsoft.Office.Interop.Word.ApplicationEvents4_DocumentOpenEventHandler(OnOpenDoc);

            }
            catch { }

            if (document != null)
            {
                try
                {
                    object dummy = null;
                    wd.Documents.Close(ref dummy, ref dummy, ref dummy);
                }
                catch { }
            }


            object newTemplate = false;
            object docType = 0;
            object isVisible = true;
            object missing = System.Reflection.Missing.Value;

            try
            {
                if (wd == null)
                {
                    throw new WordInstanceException();
                }

                if (wd.Documents == null)
                {
                    throw new DocumentInstanceException();
                }


                if (wd != null && wd.Documents != null)
                {
                    OfficeWord.JOfficeWord JWord = new JOfficeWord();
                    JWord.oWord = wd;
                    if (FileCode > 0)
                        document = JWord.Open(FileCode, false, this.PanelMain,false, ReadOnly);
                    else
                        document = JWord.New(pDefaultData, false, this.PanelMain,false);
                }

                if (document == null)
                {
                    throw new ValidDocumentException();
                }
            }
            catch
            {
            }

            try
            {
                wd.ActiveWindow.DisplayRightRuler = false;
                wd.ActiveWindow.DisplayScreenTips = false;
                wd.ActiveWindow.DisplayVerticalRuler = false;
                wd.ActiveWindow.DisplayRightRuler = false;
                wd.ActiveWindow.ActivePane.DisplayRulers = false;
                wd.ActiveWindow.WindowState = WdWindowState.wdWindowStateMaximize;
                wd.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdPrintView;
            }
            catch
            {

            }

            /// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)

            if (this.Parent != null)
                this.Parent.Focus();

            deactivateevents = false;
        }


        /// <summary>
        /// restores Word.
        /// If the program crashed somehow.
        /// Sometimes Word saves it's temporary settings :(
        /// </summary>
        public void RestoreWord()
        {

        }

        /// <summary>
        /// internal resize function
        /// utilizes the size of the surrounding control
        /// 
        /// optimzed for Word2000 but it works pretty good with WordXP too.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>


        /// Required. 
        /// Without this, the command bar buttons that have been disabled 
        /// will remain disabled permanently (does not occur at every machine or every time)
        public void RestoreCommandBars()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pDB"></param>
        /// <param name="pNewSave">در یک رکورد جدید ذخیره گردد</param>
        /// <returns></returns>
        public bool SaveInOfficeWord(ArchivedDocuments.JArchiveDataBase pDB, string pClassName, int pObjectCode, bool pNewSave)
        {
            try
            {
                if (document == null)
                    return true;
                OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
                _FileCode = Office.Insert(pDB, pClassName, pObjectCode, document.Content.get_XML(false), document.Content.Text, pNewSave, true);
                Office.Dispose();
                return _FileCode > 0;
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }

        public bool ReplaceWithDataTable(System.Data.DataTable pDT)
        {
            string str = document.Content.get_XML(false);
            try
            {
                //if (progressBar == null)
                  //  progressBar = new ProgressBar();
                progressBar.Visible = true;
                progressBar.Step = 1;
                progressBar.Maximum = pDT.Columns.Count;
                for (int i = 0; i < pDT.Columns.Count; i++)
                {
                    str = str.Replace("<" + JLanguages._Text(pDT.Columns[i].Caption) + ">", pDT.Rows[0][pDT.Columns[i].Caption].ToString());
                    progressBar.PerformStep();
                }
                return true;
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private void WinWordControl_ControlRemoved(object sender, ControlEventArgs e)
        {
        }

        public bool Reaplce(System.Data.DataTable pDT)
        {
            try
            {
                //Object oMissing = System.Reflection.Missing.Value;
                //Document DocTemp = wd.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //string _TempContent = document.Content.get_XML(false)

                
                
                progressBar.Visible = true;
                progressBar.Step = 1;
                progressBar.Maximum = pDT.Columns.Count;

                object missing = System.Reflection.Missing.Value;
                object replaceAll = Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll;

                document.Activate();
                foreach (Microsoft.Office.Interop.Word.Range tmpRange in document.StoryRanges)
                {
                    for (int i = 0; i < pDT.Columns.Count; i++)
                    {
                        tmpRange.Find.ClearFormatting();
                        tmpRange.Find.Text = "<" + JLanguages._Text(pDT.Columns[i].Caption) + ">";
                        if (pDT.Rows[0][pDT.Columns[i]].ToString().Length > 255)
                        {
                            //tmpRange.Find.MatchCase = true;
                            //tmpRange.Find.MatchWholeWord = true;
                            //tmpRange.Find.
                            string str = pDT.Rows[0][pDT.Columns[i]].ToString();
                            for (int j = 0; j <= ((pDT.Rows[0][pDT.Columns[i]].ToString().Length) / 240); j++)
                            {
                                if ((pDT.Rows[0][pDT.Columns[i]].ToString().Length) < (j * 240 + 240))
                                    tmpRange.Find.Replacement.Text = str.Substring(j * 240, (pDT.Rows[0][pDT.Columns[i]].ToString().Length) - (j * 240));
                                else
                                    tmpRange.Find.Replacement.Text = str.Substring(j * 240, 240) + "<abcd>";
                                tmpRange.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref missing, ref missing, ref missing, ref missing, ref missing,
                                ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                                tmpRange.Find.Text = "<abcd>";
                            }
                        }
                        else
                        {
                            //tmpRange.Find.MatchCase = true;
                            //tmpRange.Find.MatchWholeWord = true;
                            tmpRange.Find.Replacement.Text = pDT.Rows[0][pDT.Columns[i]].ToString();
                            tmpRange.Find.Execute(ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref missing, ref missing, ref missing, ref missing, ref missing,
                            ref replaceAll, ref missing, ref missing, ref missing, ref missing);
                        }
                    }
                    //progressBar.PerformStep();
                }
                //document.Content.Text = "";
                //document.Content.InsertXML(DocTemp.Content.get_XML(false), ref oMissing);
                return true;
            }
            catch (Exception ex)
            {
                //Except.AddException(ex);
                return false;
            }
            finally
            {
                progressBar.Visible = false;
            }
        }

        private void panel1_SizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (wd != null && wd.ActiveWindow != null)
                    wd.ActiveWindow.WindowState = WdWindowState.wdWindowStateMaximize;

            }
            catch
            {
            }
            finally
            {
            }
        }

        public void Print()
        {
            object missing = System.Reflection.Missing.Value;
            document.PrintOut(ref missing, ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,
                ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,ref missing,
                ref missing,ref missing);
        }

        public void PrintPrview()
        {
            document.PrintPreview();
        }

        public void InsertFooter(string pText)
        {
            document.Content.InsertAfter(pText);
        }

        public void InsertHeader(string pText)
        {
            document.Content.InsertBefore(pText);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="myImagePos">Set the position where the image will be placed</param>
        public void InsertImage(Object myImagePos, Bitmap pImage)
        {
            try
            {
                // Declaration of the variables
                Object myFalse = false;
                Object myTrue = true;

                // Set the position where the image will be placed

                Object myImageRange = document.Bookmarks.get_Item(ref myImagePos).Range;
                // Set the file of the picture

                string UniqCode = "ERPOFFiceWORD" + new Random().Next(10000000).ToString();
                string Cfile = new JConfig().TempPath + "temptempwordBarcode" + UniqCode + ".bmp";
                // Add the picture to the document
                System.IO.File.Delete(Cfile);
                pImage.Save(Cfile);

                document.InlineShapes.AddPicture(Cfile, ref myFalse, ref myTrue, ref myImageRange);

                System.IO.File.Delete(Cfile);
            }
            catch
            {
            }
            finally
            {
            }
        }

    }
	public class DocumentInstanceException : Exception
	{}
	
	public class ValidDocumentException : Exception
	{}

	public class WordInstanceException : Exception
	{}


}
