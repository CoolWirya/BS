using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.Reflection;
using ClassLibrary;
using Word = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;
using System.Data;


namespace OfficeWord
{
    public enum JDocumentState
    {
        New,
        Update,
        ReadOnly
    }

    public class JOfficeWord : JSystem
    {
        Object oMissing = System.Reflection.Missing.Value;
        object TempFileName;
        public JDocumentState State;
        
        #region Properties

        public int Code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DocumentContent { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DocumentText { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastModify { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Creator { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int Changer { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ClassName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ObjectCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private int _wordWnd = 0;

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

        #endregion

        #region "API usage declarations"

        [DllImport("user32.dll")]
        public static extern int FindWindow(string strclassName, string strWindowName);

        [DllImport("user32.dll")]
        static extern int SetParent(int hWndChild, int hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        static extern bool SetWindowPos(
            int hWnd,               // handle to window
            int hWndInsertAfter,    // placement-order handle
            int X,                  // horizontal position
            int Y,                  // vertical position
            int cx,                 // width
            int cy,                 // height
            uint uFlags             // window-positioning options
            );

        [DllImport("user32.dll", EntryPoint = "MoveWindow")]
        static extern bool MoveWindow(
            int hWnd,
            int X,
            int Y,
            int nWidth,
            int nHeight,
            bool bRepaint
            );

        [DllImport("user32.dll", EntryPoint = "DrawMenuBar")]
        static extern Int32 DrawMenuBar(
            Int32 hWnd
            );

        [DllImport("user32.dll", EntryPoint = "GetMenuItemCount")]
        static extern Int32 GetMenuItemCount(
            Int32 hMenu
            );

        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        static extern Int32 GetSystemMenu(
            Int32 hWnd,
            bool bRevert
            );

        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        static extern Int32 RemoveMenu(
            Int32 hMenu,
            Int32 nPosition,
            Int32 wFlags
            );


        private const int MF_BYPOSITION = 0x400;
        private const int MF_REMOVE = 0x1000;


        const int SWP_DRAWFRAME = 0x20;
        const int SWP_NOMOVE = 0x2;
        const int SWP_NOSIZE = 0x1;
        const int SWP_NOZORDER = 0x4;

        #endregion
        /// <summary>
        /// مشخص میکند که فیل را ذخیره و کد را بر گرداند یا محتوا را 
        /// </summary>
        public bool Save
        {
            get { return _Save; }
            set { _Save = value; }
        }

        private bool _NewFile = true;
        private bool _OverWrite = false;
        private bool _Save = false;

        public JOfficeWord()
        {

        }

        public void ShowDialog()
        {
        }

        public Document Open(string pFileName, bool PWithEvents)
        {
            System.IO.StreamReader fs = new System.IO.StreamReader(pFileName);
            DocumentContent = fs.ReadToEnd();
            fs.Close();
            _NewFile = true;
            return Show(null, PWithEvents);
        }

        public void Open(int pCode, bool PWithEvents)
        {
            Open(pCode, false, null, PWithEvents,false);
        }

        public Word.Document Open(int pCode, bool pOverWrite,System.Windows.Forms.Control pUserControl, bool PWithEvents, bool pReadOnly)
        {
            ReadOnly = pReadOnly;
            ArchivedDocuments.JArchiveDataBase DB = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                DB.setQuery("SELECT * FROM Word WHERE Code=" + pCode.ToString() + " ORDER BY CreateDate DESC");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    _NewFile = false;
                    _OverWrite = pOverWrite;

                    JTable.SetToClassProperty(this, DB.DataReader);
                    return Show(pUserControl, PWithEvents);
                }
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void GetData(int pCode)
        {
            ArchivedDocuments.JArchiveDataBase DB = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                DB.setQuery("SELECT * FROM Word WHERE Code=" + pCode.ToString() + " ORDER BY CreateDate DESC");
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void GetData(string pClassName, int ObjectCode)
        {
            GetData(pClassName, ObjectCode, null);
        }

        public void GetData(string pClassName, int ObjectCode,ArchivedDocuments.JArchiveDataBase pDB)
        {
            ArchivedDocuments.JArchiveDataBase DB;
            if (pDB == null)
                DB = new ArchivedDocuments.JArchiveDataBase();
            else
                DB = pDB;
            try
            {
                DB.setQuery("SELECT * FROM Word WHERE Classname=" + ArchivedDocuments.JArchiveDataBase.Quote(pClassName) + " AND ObjectCode=" + ObjectCode.ToString() + " ORDER BY CreateDate DESC");
                //System.Data.DataTable table = DB.Query_DataTable();
                //if (table.Rows.Count > 0)
                //{
                //    JTable.SetToClassProperty(this,);
                //}
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                }
            }
            finally
            {
                DB.Dispose();
            }
        }

        public System.Data.DataTable GetAllChange(string pClassName, int pObjectCode)
        {
            ArchivedDocuments.JArchiveDataBase db = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                db.setQuery(@"SELECT W.Code,W.Changer,W.Classname,W.CreateDate,W.Creator,dbo.MiladiTOShamsi(W.LastModify) AS LastModify
                ,W.ObjectCode FROM Word W
                Where 
                W.ClassName = "+ArchivedDocuments.JArchiveDataBase.Quote(pClassName)+@" AND 
                W.ObjectCode = "+pObjectCode.ToString()+@"
                ORDER BY LastModify");
                return db.Query_DataTable();
            }
            finally
            {
                db.DisConnect();
            }
            return null;
        }


        public Word.Document New(System.Windows.Forms.Control pUserControl, bool PWithEvents)
        {
            Code = 0;
            DocumentContent = "";
            _NewFile = true;
            Word.Document Doc = Show(pUserControl, PWithEvents);
            State = JDocumentState.New;
            return Doc;
        }
        /// <summary>
        /// ایجاد فایل جدید از روی محتوای فایل الگو
        /// </summary>
        /// <param name="PatternXml">فایل الگو xml</param>
        /// <param name="pSave">دخیره در بانک</param>
        public Word.Document New(string PatternXml, bool pSave, System.Windows.Forms.Control pUserControl, bool PWithEvents)
        {
            _Save = pSave;
            Code = 0;
            DocumentContent = PatternXml;
            _NewFile = true;
            Word.Document Doc = Show(pUserControl,PWithEvents);
            State = JDocumentState.New;
            return Doc;
        }
        /// <summary>
        /// انتخاب فایل جدید از روی محتوای فایل موجود
        /// </summary>
        /// <param name="pDocumentContent">XML</param>
        /// <param name="pDocumentText">TXET ONLY</param>
        /// <param name="pSave">دخیره در بانک</param>
        public void NewFromExistingFile(ArchivedDocuments.JArchiveDataBase pDB, string pClassName, int pObjectCode, string pDocumentContent, string pDocumentText, bool pSave)
        {
            _Save = pSave;
            Code = 0;
            _NewFile = true;
            Insert(pDB, pClassName, pObjectCode, pDocumentContent, pDocumentText);
            State = JDocumentState.New;
        }

        public int Insert(ArchivedDocuments.JArchiveDataBase pDB, string pClassName, int pObjectCode, string pContent, string pDocumentText)
        {
            return Insert(pDB, pClassName, pObjectCode, pContent, pDocumentText, _NewFile, true);
        }

        public int Insert(ArchivedDocuments.JArchiveDataBase PDB,string pClassName, int pObjectCode, string pContent, string pDocumentText, bool pInsert,bool pSave)
        {
            if (pClassName.Length == 0 || pObjectCode == 0)
                return 0;
            if (!pInsert)
            {
                GetData(pClassName, pObjectCode);
            }

            ClassName = pClassName;
            ObjectCode = pObjectCode;
            DocumentContent = pContent;
            DocumentText = pDocumentText;

            _Save = pSave;

            if (!_Save)
                return 0;
            ArchivedDocuments.JArchiveDataBase DB;
            if (PDB == null)
                DB = new ArchivedDocuments.JArchiveDataBase();
            else
            DB = PDB;

            try
            {
                DocumentContent = pContent;
                DB.Params.Clear();
                if (pInsert || Code == 0)
                {
                    DB.setQuery(@"
                        DECLARE @Code INT " +
                        ArchivedDocuments.JArchiveDataBase.GetInsertSQL("Word") +

                        @"INSERT INTO Word(Code, DocumentContent,DocumentText, CreateDate, LastModify, Creator, Changer, classname, objectcode)
                                    VALUES(@Code,@DocumentContent,@DocumentText,getdate(),getdate(),@Creator,@Changer,@Classname,@Objectcode)
                        SELECT @Code");
                    DB.Params.Add("@DocumentContent", pContent);
                    DB.Params.Add("@Creator", JMainFrame.CurrentPostCode);
                    DB.Params.Add("@DocumentText", pDocumentText);
                    DB.Params.Add("@Changer", 0);
                    DB.Params.Add("@ClassName", pClassName);
                    DB.Params.Add("@ObjectCode", pObjectCode);
                }
                else
                {
                    DB.setQuery(@"UPDATE Word SET DocumentContent=@DocumentContent,DocumentText=@DocumentText,
                                LastModify=getdate(), Changer=@Changer
                                , classname = @Classname, objectcode =@Objectcode 
                                ,CreateDate=getdate()
                                WHERE Code=@Code 
                                SELECT @Code");
                    DB.Params.Add("@Code", Code);
                    DB.Params.Add("@CreateDate", CreateDateTime);
                    DB.Params.Add("@DocumentContent", pContent);
                    DB.Params.Add("@Changer", JMainFrame.CurrentPostCode);
                    DB.Params.Add("@DocumentText", pDocumentText);
                    DB.Params.Add("@ClassName", pClassName);
                    DB.Params.Add("@ObjectCode", pObjectCode);
                }
                int rCode = 0;
                try
                {
                    rCode = Convert.ToInt32(DB.Query_ExecutSacler());
                }
                catch
                {

                }
                if (rCode > 0)
                {
                    Code = rCode;
                }
                return rCode;
            }
            finally
            {
                if (PDB == null)
                    DB.Dispose();
            }
        }
        public void Update(ArchivedDocuments.JArchiveDataBase pDB, string pClassName, int pObjectCode, string pDocumentContent, string pDocumentText)
        {
            this.Insert(pDB, pClassName, pObjectCode, pDocumentContent, pDocumentText, false, true);
        }
        /// <summary>
        /// حذف تمام ورژنهای فایل ورد
        /// </summary>
        public bool Delete()
        {
            ArchivedDocuments.JArchiveDataBase DB = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                return Delete(DB);
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool Delete(ArchivedDocuments.JArchiveDataBase pDB)
        {
            return Delete(pDB,false);
        }
        /// <summary>
        /// حذف آخرین ورژن
        /// </summary>
        /// <param name="LastVersion"></param>
        public bool Delete(ArchivedDocuments.JArchiveDataBase pDB, bool LastVersion)
        {

            ArchivedDocuments.JArchiveDataBase DB;
            if (pDB == null)
                DB = new ArchivedDocuments.JArchiveDataBase();
            else
                DB = pDB;
                try
            {
                //string DelCommand = @"DELETE Word  WHERE Code=@Code ";
                string DelCommand = @"DELETE Word  WHERE ClassName = @ClassName AND ObjectCode = @ObjectCode";
                //if (LastVersion)
                //{
                //    DelCommand += " AND LastModify=(SELECT Max(LastModify) FROM Word WHERE Code=@Code)";
                //}
                DB.Params.Add("@ClassName", ClassName);
                DB.Params.Add("@ObjectCode", ObjectCode);
                DB.setQuery(DelCommand);
                DB.Query_Execute();
                return true;
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;

            }
            finally
            {
                //pDB.Dispose();
            }
        }
      
        /// <summary>
        /// حذف بر اساس تاریخ ویرایش فایل
        /// </summary>
        /// <param name="LastModify"></param>
        public void Delete(DateTime LastModify)
        {
            ArchivedDocuments.JArchiveDataBase DB = new ArchivedDocuments.JArchiveDataBase();
            try
            {
                string DelCommand = @"DELETE Word  WHERE Code=@Code ";
                if (LastModify != DateTime.MinValue)
                {
                    DelCommand += " AND LastModify=@LastModify";
                    DB.Params.Add("@LastModify", LastModify);
                }
                DB.setQuery(DelCommand);
                DB.Params.Add("@Code", Code);
                DB.Query_Execute();
            }
            finally
            {
                DB.Dispose();
            }
        }

        public Word.Application oWord;
        string docname = "";

        private Word.Document Show(System.Windows.Forms.Control pParentControl, bool PWithEvents)
        {
            return Show(pParentControl, PWithEvents, "");
        }


        private Word.Document Show(System.Windows.Forms.Control pParentControl, bool PWithEvents, string pFileName)
        {

            try
            {
                if (pParentControl != null)
                {
                    pParentControl.Resize += new System.EventHandler(this.OnResize);
                    if (oWord == null)
                        oWord = new Word.Application();
                    if (_wordWnd == 0) _wordWnd = FindWindow("Opusapp", null);
                    if (_wordWnd != 0)
                    {
                        SetParent(_wordWnd, pParentControl.Handle.ToInt32());
                    }
                }
                Word.Document oDoc;
                string UniqCode = "ERPOFFiceWORD" + new Random().Next(10000000).ToString();
                if ((!_NewFile && Code > 0) || (_NewFile && DocumentContent != ""))
                {
                    object Cfile = new JConfig().TempPath + "\\temptempword" + UniqCode + ".xml";
                    object Confirm = false;
                    object isReadOnly = ReadOnly;

                    System.IO.StreamWriter fs = new System.IO.StreamWriter((string)Cfile);
                    fs.Write(DocumentContent);
                    fs.Close();

                    try
                    {
                        oDoc = oWord.Documents.OpenOld(ref Cfile, ref Confirm, ref isReadOnly, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                    }
                    catch
                    {
                        oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing); // Clean document
                    }


                }
                else
                {
                    oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing); // Clean document
                }

                if (ReadOnly)
                {
                    object Password = (string)"1234567890";
                    oDoc.Protect(WdProtectionType.wdAllowOnlyReading, ref oMissing, ref Password, ref oMissing, ref oMissing);
                }

                oDoc._CodeName = UniqCode;
                docname = oDoc._CodeName;
                if(PWithEvents)
                {
                oWord.DocumentBeforeClose +=
                    new Word.ApplicationEvents4_DocumentBeforeCloseEventHandler(
                    oWord_DocumentBeforeClose);
                oWord.DocumentBeforeSave +=
                    new Word.ApplicationEvents4_DocumentBeforeSaveEventHandler(
                    oWord_DocumentBeforeSave);
                oWord.DocumentChange +=
                    new Word.ApplicationEvents4_DocumentChangeEventHandler(
                    oWord_DocumentChange);
                oWord.WindowBeforeDoubleClick +=
                    new Word.ApplicationEvents4_WindowBeforeDoubleClickEventHandler(
                    oWord_WindowBeforeDoubleClick);
                oWord.WindowBeforeRightClick +=
                    new Word.ApplicationEvents4_WindowBeforeRightClickEventHandler(
                    oWord_WindowBeforeRightClick);
                }

                if (pParentControl !=null && _wordWnd > 0)
                {
                    try
                    {
                        oWord.Visible = true;
                        SetWindowPos(_wordWnd, pParentControl.Handle.ToInt32(), 0, 0, pParentControl.Bounds.Width, pParentControl.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);
                    }
                    catch
                    {
                    }

                }
                return oDoc;

            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }

        }

        // The event handlers.

        private void oWord_DocumentBeforeClose(Word.Document doc, ref bool Cancel)
        {
            if (doc._CodeName != docname)
                return;
        }

        private void oWord_DocumentBeforeSave(Word.Document doc, ref bool SaveAsUI, ref bool Cancel)
        {
            if (doc._CodeName != docname) 
                return;
            if (BeforSave != null)
                BeforSave.BeginInvoke(this, null, null, null);
            Cancel = true;
            SaveAsUI = false;
            object True = true;
            object False = false;
            try
            {
                DocumentText = doc.Content.Text;        
                Insert(null,ClassName,ObjectCode,doc.Content.get_XML(false).ToString(), DocumentText);
            }
            finally
            {
                doc.Application.Quit(ref False, ref oMissing, ref oMissing);
                JFiles.DeleteFile((string)TempFileName);
            }           

        }

        private void oWord_DocumentChange()
        {

        }

        private void oWord_WindowBeforeDoubleClick(Word.Selection sel, ref bool Cancel)
        {
            if (sel.Document._CodeName != docname) 
                return;
        }

        private void oWord_WindowBeforeRightClick(Word.Selection sel, ref bool Cancel)
        {
            if (sel.Document._CodeName != docname)
                return;
        }

        private void OnResize(System.Windows.Forms.Control pParent)
        {
            //The original one that I used is shown below. Shows the complete window, but its buttons (min, max, restore) are disabled
            //// MoveWindow(wordWnd,0,0,this.Bounds.Width,this.Bounds.Height,true);


            ///Change below
            ///The following one is better, if it works for you. We donot need the title bar any way. Based on a suggestion.
            int borderWidth = System.Windows.Forms.SystemInformation.Border3DSize.Width;
            int borderHeight = System.Windows.Forms.SystemInformation.Border3DSize.Height;
            int captionHeight = System.Windows.Forms.SystemInformation.CaptionHeight;
            int statusHeight = System.Windows.Forms.SystemInformation.ToolWindowCaptionHeight;
            MoveWindow(
                _wordWnd,
                0,
                0,
                pParent.Bounds.Width + 4 * borderWidth,
                pParent.Bounds.Height,
                true);

        }

        private void OnResize(object sender, System.EventArgs e)
        {
            OnResize((System.Windows.Forms.Control)sender);
        }
        
        /// <summary>
        /// رویداد قبل از ثبت برای کلاس
        /// </summary>
        public event EventHandler BeforSave;

        /// <summary>
        /// پیدا کردن تگ های معادل بین فایل متنی و xml
        /// </summary>
        /// <param name="pXml"></param>
        /// <param name="pText"></param>
        /// <returns></returns>
        public static System.Data.DataTable TagXml(int pFileCode,string pXml, string pText)
        {
            System.Data.DataTable dt = new System.Data.DataTable();                
            JTextXml tmpJTextXml = new JTextXml();
            try
            {
                dt.Columns.Add("Tag");
                dt.Columns.Add("Xml");
                string StrA = "<";
                string StrB = "";
                int indexB = 0;
                int in1 = 0;
                int in2 = 0;
                for (int i = 0; i < pText.Length - 1; i++)
                {
                    if (pText[i] == '<')
                    {
                        for (int j = 1; j < pText.Length - 1; j++)
                        {
                            try
                            {
                                if (pText.Length < i + j) break;
                                if (pText[i + j] == '<')
                                {
                                    //break;
                                }
                                else
                                {
                                    StrA = StrA + pText[i + j];
                                    if (pText[i + j] == '>')
                                    {
                                        StrA = "<" + StrA;
                                        in1 = pXml.IndexOf("&lt;", indexB);
                                        in2 = pXml.IndexOf("&gt;", indexB);
                                        //StrB = pXml.Substring(in2, in1 - in2 + 4);
                                        StrB = pXml.Substring(in1, in2 - in1 + 4);
                                        indexB = in2 + 4;
                                        dt.Rows.Add(StrA, StrB);

                                        break;
                                    }
                                }
                            }
                            catch(Exception ex)
                            {
                                JSystem.Except.AddException(ex);
                                break;
                            }

                        }
                    }
                    StrA = "";
                    StrB = "";
                }

                JTextXmls.Delete(pFileCode);
                foreach (DataRow dr in dt.Rows)
                {
                    tmpJTextXml.FileCode = pFileCode;
                    tmpJTextXml.Tag = dr["Tag"].ToString();
                    tmpJTextXml.Xml = dr["Xml"].ToString();
                    tmpJTextXml.Insert();
                }
                return dt;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                dt.Dispose();
                //tmpJTextXml.Dispose();
            }
        }

        public string ReplaceXml(System.Data.DataTable pDt, string pXml, int pFileCode)
        {
            JTextXml tmpJTextXml = new JTextXml();
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {

                pXml = JGeneral.ConvertToPersian(pXml);
                for (int i = 0; i < pDt.Columns.Count; i++)
                {
                    dt = JTextXml.Find(pFileCode, "<" + JLanguages._Text(pDt.Columns[i].ColumnName.ToString()) + ">", "");
                    if ((dt != null) && (dt.Rows.Count > 0))
                        foreach (DataRow _dr in dt.Rows)
                        {
                            string STR1 = _dr["Xml"].ToString();
                            string STR2 = pDt.Rows[0][pDt.Columns[i].ColumnName.ToString()].ToString();

                            STR1 = JGeneral.ConvertToPersian(STR1);
                            STR2 = JGeneral.ConvertToPersian(STR2);

                            pXml = pXml.Replace(STR1, STR2);
                        }
                }
                return pXml;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return "";
            }
            finally
            {
                dt.Dispose();
                //tmpJTextXml.Dispose();
            }
        }
    }
}
