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

namespace Legal
{
	/// <summary>
	/// WinWordControl allows you to load doc-Files to your
	/// own application without any loss, because it uses 
	/// the real WinWord.
	/// </summary>
	public class WinWordControl : System.Windows.Forms.UserControl
	{


		#region "API usage declarations"

		[DllImport("user32.dll")]
		public static extern int FindWindow(string strclassName, string strWindowName);

		[DllImport("user32.dll")]
		static extern int SetParent( int hWndChild, int hWndNewParent);

		[DllImport("user32.dll", EntryPoint="SetWindowPos")]
		static extern bool SetWindowPos(
			int hWnd,               // handle to window
			int hWndInsertAfter,    // placement-order handle
			int X,                  // horizontal position
			int Y,                  // vertical position
			int cx,                 // width
			int cy,                 // height
			uint uFlags             // window-positioning options
			);
		
		[DllImport("user32.dll", EntryPoint="MoveWindow")]
		static extern bool MoveWindow(
			int hWnd, 
			int X, 
			int Y, 
			int nWidth, 
			int nHeight, 
			bool bRepaint
			);

		[DllImport("user32.dll", EntryPoint="DrawMenuBar")]
		static extern Int32 DrawMenuBar(
			Int32 hWnd
			);

		[DllImport("user32.dll", EntryPoint="GetMenuItemCount")]
		static extern Int32 GetMenuItemCount(
			Int32 hMenu
			);

		[DllImport("user32.dll", EntryPoint="GetSystemMenu")]
		static extern Int32 GetSystemMenu(
			Int32 hWnd,
			bool bRevert
			);

		[DllImport("user32.dll", EntryPoint="RemoveMenu")]
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

				

		/* I was testing wheater i could fix some exploid bugs or not.
		 * I left this stuff in here for people who need to know how to 
		 * interface the Win32-API

		[StructLayout(LayoutKind.Sequential)]
			public struct RECT 
		{
			public int left;
			public int top;
			public int right;
			public int bottom;
		}
		
		[DllImport("user32.dll")]
		public static extern int GetWindowRect(int hwnd, ref RECT rc);
		
		[DllImport("user32.dll")]
		public static extern IntPtr PostMessage(
			int hWnd, 
			int msg, 
			int wParam, 
			int lParam
		);
		*/


		/// <summary>
		/// Change. Made the following variables public.
		/// </summary>

        public Microsoft.Office.Interop.Word.Document document;
        public Microsoft.Office.Interop.Word.ApplicationClass wd = null;
		public  int wordWnd				= 0;

        private string _filename = null;
        public string filename
        {
            get
            {
                return _filename;
            }
            set
            {
                if (_filename != value)
                {
                    _filename = value;
                    _stringContent = "";
                    _FileCode = 0;
                    LoadDocument();
                }
            }
        }
        private bool deactivateevents = false;

        private string _stringContent = "";
        public string stringContent
        {
            get
            {
                return _stringContent;
            }
            set
            {
                if (_stringContent != value)
                {
                    _stringContent = value;
                    _filename = "";
                    _FileCode = 0;
                    LoadDocument();
                }
            }
        }
        /// <summary>
        /// کد فایل ذخیره شده در OfficeWord
        /// </summary>
        private int _FileCode;
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
                    _filename = "";
                    _stringContent = "";
                    LoadFromOfficeWord();
                }
            }
        }
        /// <summary>
		/// needed designer variable
		/// </summary>
		private System.ComponentModel.Container components = null;

		public WinWordControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// cleanup Ressources
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			CloseControl();
			if( disposing )
			{
				if( components != null )
					components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary>
		/// !do not alter this code! It's designer code
		/// </summary>
		private void InitializeComponent()
		{
            this.SuspendLayout();
            // 
            // WinWordControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Name = "WinWordControl";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(438, 334);
            this.Resize += new System.EventHandler(this.OnResize);
            this.ResumeLayout(false);

		}
		#endregion


		/// <summary>
		/// Preactivation
		/// It's usefull, if you need more speed in the main Program
		/// so you can preload Word.
		/// </summary>
		public void PreActivate()
		{
            if (!DesignMode)
                if (wd == null) wd = new Microsoft.Office.Interop.Word.ApplicationClass();
		}


		/// <summary>
		/// Close the current Document in the control --> you can 
		/// load a new one with LoadDocument
		/// </summary>
		public void CloseControl()
		{
			/*
			* this code is to reopen Word.
			*/
		
			try
			{
				deactivateevents = true;
				object dummy=null;
				object dummy2=(object)false;
				document.Close(ref dummy, ref dummy, ref dummy);
				// Change the line below.
				wd.Quit(ref dummy2, ref dummy, ref dummy);
				deactivateevents = false;
			}
			catch(Exception ex)
			{
				String strErr = ex.Message;
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
			if(!deactivateevents)
			{
				cancel=true;
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
			if(!deactivateevents  && !DesignMode)
			{
				deactivateevents=true;
				object dummy = null;
				doc.Close(ref dummy,ref dummy,ref dummy);
				deactivateevents=false;
			}
		}

		/// <summary>
		/// catches Word's quit event
		/// normally it should not fire, but just to be shure
		/// safely release the internal Word Instance 
		/// </summary>
		private void OnQuit()
		{
			//wd=null;
		}


		/// <summary>
		/// Loads a document into the control
		/// </summary>
		/// <param name="t_filename">path to the file (every type word can handle)</param>
        public void LoadDocument()
        {
            if (!DesignMode) return;

            deactivateevents = true;

            if (wd == null) wd = new Microsoft.Office.Interop.Word.ApplicationClass();
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

            if (wordWnd == 0) wordWnd = FindWindow("Opusapp", null);
            if (wordWnd != 0)
            {
                SetParent(wordWnd, this.Handle.ToInt32());

                object fileName = filename;
                object newTemplate = false;
                object docType = 0;
                object readOnly = true;
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
                        document = wd.Documents.Add(ref fileName, ref newTemplate, ref docType, ref isVisible);
                        if (stringContent.Length > 0)
                        {
                            object oMissing = System.Reflection.Missing.Value;
                            ((Microsoft.Office.Interop.Word.DocumentClass)(document)).Content.InsertXML(stringContent, ref oMissing);
                        }
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
                    wd.ActiveWindow.ActivePane.View.Type = Microsoft.Office.Interop.Word.WdViewType.wdWebView;
                    //wd.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;//wdWebView; // .wdNormalView;
                }
                catch
                {

                }
                try
                {
                    wd.Visible = true;
                    wd.Activate();

                    SetWindowPos(wordWnd, this.Handle.ToInt32(), 0, 0, this.Bounds.Width, this.Bounds.Height, SWP_NOZORDER | SWP_NOMOVE | SWP_DRAWFRAME | SWP_NOSIZE);

                    //Call onresize--I dont want to write the same lines twice
                    OnResize();
                }
                catch
                {
                    MessageBox.Show("Error: do not load the document into the control until the parent window is shown!");
                }

                /// We want to remove the system menu also. The title bar is not visible, but we want to avoid accidental minimize, maximize, etc ..by disabling the system menu(Alt+Space)
                try
                {
                    int hMenu = GetSystemMenu(wordWnd, false);
                    if (hMenu > 0)
                    {
                        int menuItemCount = GetMenuItemCount(hMenu);
                        RemoveMenu(hMenu, menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 2, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 3, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 4, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 5, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 6, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 7, MF_REMOVE | MF_BYPOSITION);
                        RemoveMenu(hMenu, menuItemCount - 8, MF_REMOVE | MF_BYPOSITION);
                        DrawMenuBar(wordWnd);
                    }
                }
                catch { };



                this.Parent.Focus();

            }
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
		private void OnResize()
		{
			//The original one that I used is shown below. Shows the complete window, but its buttons (min, max, restore) are disabled
			//// MoveWindow(wordWnd,0,0,this.Bounds.Width,this.Bounds.Height,true);


			///Change below
			///The following one is better, if it works for you. We donot need the title bar any way. Based on a suggestion.
			int borderWidth = SystemInformation.Border3DSize.Width;
			int borderHeight = SystemInformation.Border3DSize.Height;
			int captionHeight = SystemInformation.CaptionHeight;
			int statusHeight = SystemInformation.ToolWindowCaptionHeight;
			MoveWindow(
				wordWnd, 
				-2*borderWidth,
				-2*borderHeight - captionHeight, 
				this.Bounds.Width + 4*borderWidth, 
				this.Bounds.Height + captionHeight + 4*borderHeight + statusHeight,
				true);

		}

		private void OnResize(object sender, System.EventArgs e)
		{
			OnResize();
		}


		/// Required. 
		/// Without this, the command bar buttons that have been disabled 
		/// will remain disabled permanently (does not occur at every machine or every time)
		public  void RestoreCommandBars()
		{
		}

        private bool LoadFromOfficeWord()
        {

            if (_FileCode != 0)
            {
                OfficeWord.JOfficeWord tmp = new OfficeWord.JOfficeWord();
                tmp.GetData(_FileCode);
                stringContent = tmp.DocumentContent;
                return true;
            }
            return false;
        }

        public bool SaveInOfficeWord()
        {
            OfficeWord.JOfficeWord Office = new OfficeWord.JOfficeWord();
            _FileCode = Office.Insert(document.Content.get_XML(false), document.Content.Text, FileCode == 0, false);
            return _FileCode > 0;
        }
    }
	public class DocumentInstanceException : Exception
	{}
	
	public class ValidDocumentException : Exception
	{}

	public class WordInstanceException : Exception
	{}


}
