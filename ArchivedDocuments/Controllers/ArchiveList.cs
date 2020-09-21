using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ArchivedDocuments
{
    public partial class JArchiveList : UserControl
    {
        public JArchiveList()
        {
            try
            {
                InitializeComponent();
                object t1Object = pictureBox1.Image;
                JSystem.AddObject(ref t1Object);

                object t2Object = pictureBox2.Image;
                JSystem.AddObject(ref t2Object);
            }
            catch { }
            finally { }
        }

        public static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        #region Private Properties

        private Panel[] ImagePanelList = new Panel[0];
        private int _OldTop = 0;
        private DataRow CurrentDataRow;

        int[] _listcode;
        DataTable _DataTable;
        enum FileActions
        {
            NoAction = 0,
            Insert = 1,
            Update = 2,
            Delete = 3,
        }
        //int[] DeleteCodes = new int[0];
        List<int> DeleteCodes = new List<int>();

        private bool getImagesList = false;
        #endregion

        #region Properties
        [
        Category("Archive"),
        Description("کد شی دیتابیس")
        ]
        /// <summary>
        /// نام کلاس
        /// </summary>
        private int _DataBaseObjectCode = 0;
        /// <summary>
        ///  نام کلاس
        /// </summary>
        public int DataBaseObjectCode
        {
            get
            {
                return _DataBaseObjectCode;
            }
            set
            {
                if (value != _DataBaseObjectCode)
                {
                    _DataBaseObjectCode = value;
                    //_LoadDataFromArchive();
                }
            }
        }
        [
        Category("Archive"),
        Description("نام کلاس دیتابیس")
        ]
        /// <summary>
        /// نام کلاس
        /// </summary>
        private string _DataBaseClassName = "";
        /// <summary>
        ///  نام کلاس
        /// </summary>
        public string DataBaseClassName
        {
            get
            {
                return _DataBaseClassName;
            }
            set
            {
                if (value != _DataBaseClassName)
                {
                    _DataBaseClassName = value;
                    //_LoadDataFromArchive();
                }
            }
        }
        [
        Category("Archive"),
        Description("نام کلاس")
        ]
        /// <summary>
        /// نام کلاس
        /// </summary>
        private string _ClassName = "";
        /// <summary>
        ///  نام کلاس
        /// </summary>
        public string ClassName
        {
            get
            {
                return _ClassName;
            }
            set
            {
                if (value != _ClassName)
                {
                    _ClassName = value;
                    //_LoadDataFromArchive();
                }
            }
        }
        [
      Category("Archive"),
      Description("نام کلاسها")
      ]
        /// <summary>
        /// نام کلاسها
        /// </summary>
        private string[] _ClassNames;
        /// <summary>
        ///  نام کلاسها  (استفاده نشده)
        /// </summary>
        public string[] ClassNames
        {
            get
            {
                return _ClassNames;
            }
            set
            {
                if (value != _ClassNames)
                {
                    _ClassNames = value;
                }
            }
        }

        /// <summary>
        /// کدهای شیء (استفاده نشده)
        /// </summary>
        private int[] _ObjectCodes;
        /// <summary>
        /// کدهای شیء (استفاده نشده)
        /// </summary>
        [
        Category("Archive"),
        Description("کدهای شیء")
        ]
        public int[] ObjectCodes
        {
            get
            {
                return _ObjectCodes;
            }
            set
            {
                if (value != _ObjectCodes)
                {
                    _ObjectCodes = value;
                    //_LoadDataFromArchive();
                }
            }
        }

        public int AutomationReferCode
        {
            set
            {
				if (ExtraObject == null)
					ExtraObject = new Dictionary<string, int[]>();
				else
					ExtraObject.Clear();
				
				Automation.JARefer R = new Automation.JARefer(value);
                DataTable dt = Automation.JARefers.GetRefersByObjectCode(R.object_code);
				if (dt.Rows.Count > 0)
				{
					ExtraObject.Add(new KeyValuePair<string, int[]>("Automation.Refer.frmRecieverSelector", JDataBase.DataTableToIntArray(dt, "Code")));
				}
            }
        }

        [
        Category("Archive"),
        Description("سایر کلاسها")
        ] /// <summary>
        /// سایر کلاسها و آبجکتها
        /// </summary>
        private IDictionary<string, int[]> _extraObject { get; set; }
        public IDictionary<string, int[]> ExtraObject
        {
            get
            {
                return _extraObject;
            }
            set
            {
                _extraObject = value;
            }
        }

        /// <summary>
        /// کد شیء
        /// </summary>
        private int _ObjectCode;
        /// <summary>
        /// کد شیء
        /// </summary>
        [
        Category("Archive"),
        Description("کد شیء")
        ]
        public int ObjectCode
        {
            get
            {
                return _ObjectCode;
            }
            set
            {
                if (value != _ObjectCode)
                {
                    _ObjectCode = value;
                    //_LoadDataFromArchive();
                }
            }
        }

        /// <summary>
        /// فعال بودن دکمه افزودن فایل
        /// </summary>
        [
        Category("Archive"),
        Description("فعال بودن دکمه افزودن فایل")
        ]
        public bool AllowUserAddFile
        {
            get
            {
                return btnAddFile.Enabled;
            }
            set
            {
                btnAddFile.Enabled = value;
            }
        }

        /// <summary>
        /// فعال بودن دکمه افزودن تصویر
        /// </summary>
        [
        Category("Archive"),
        Description("فعال بودن دکمه افزودن تصویر")
        ]
        public bool AllowUserAddImage
        {
            get
            {
                return btnAddImage.Enabled;
            }
            set
            {
                btnAddImage.Enabled = value;
            }
        }

        /// <summary>
        /// فعال بودن دکمه افزودن تصویر
        /// </summary>
        [
        Category("Archive"),
        Description("فعال بودن دکمه دوربین")
        ]
        public bool AllowUserCamera
        {
            get
            {
                return btnGetWebCam.Enabled;
            }
            set
            {
                btnGetWebCam.Enabled = value;
            }
        }

        /// <summary>
        /// فعال بودن دکمه افزودن فایل از آرشیو
        /// </summary>
        [
        Category("Archive"),
        Description("فعال بودن دکمه افزودن فایل از آرشیو")
        ]
        public bool AllowUserAddFromArchive
        {
            get
            {
                return btnArchive.Enabled;
            }
            set
            {
                btnArchive.Enabled = value;
            }
        }
        /// <summary>
        /// فعال بودن دکمه حذف
        /// </summary>
        [
        Category("Archive"),
        Description("فعال بودن دکمه حذف")
        ]
        public bool AllowUserDeleteFile
        {
            get
            {
                return btnDelete.Enabled;
            }
            set
            {
                btnDelete.Enabled = value;
            }
        }

        private bool _EnabledChange = true;
        public bool EnabledChange
        {
            get
            {
                return _EnabledChange;
            }
            set
            {
                _EnabledChange = value;
                AllowUserAddFile = _EnabledChange;
                AllowUserCamera = _EnabledChange;
                AllowUserAddImage = _EnabledChange;
                AllowUserDeleteFile = _EnabledChange;
                AllowUserAddFromArchive = _EnabledChange;


            }
        }

        /// <summary>
        /// کد محل بایگانی موضوعی
        /// </summary>
        [
        Category("Archive"),
        Description("کد محل بایگانی موضوعی")
        ]
        public int SubjectCode
        {
            get;
            set;
        }
        /// <summary>
        /// کد محل بایگانی فیزیکی
        /// </summary>
        [
        Category("Archive"),
        Description("کد محل بایگانی فیزیکی")
        ]
        public int PlaceCode
        {
            get;
            set;
        }
        /// <summary>
        /// تعداد فایلهای موجود در کنترل
        /// </summary>
        public int FileCount
        {
            get
            {
                return grdArchive.RowCount;
            }
        }
        #endregion Properties

        /// <summary>
        /// آرشیو کل لیست
        /// </summary>
        /// <returns></returns>
        public bool ArchiveList()
        {
            try
            {
                if (_DataTable == null)
                    return true;
                if (_DataTable.Rows.Count > 0)
                {
                    JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode, DataBaseClassName, DataBaseObjectCode);
                    try
                    {
                        //archive.BeginTran();
                        foreach (DataRow row in _DataTable.Rows)
                        {
                            try
                            {
                                if (row.RowState != DataRowState.Deleted && row[JArchiveFields.Action.ToString()] != null)
                                {
                                    /// در صورتی که فایل جدید به لیست اضافه شده
                                    if (row[JArchiveFields.Action.ToString()].ToString() == FileActions.Insert.ToString())
                                    {
                                        JFile file = (JFile)row[JArchiveFields.JFile.ToString()];
                                        archive.ArchiveDocument(file, this.ClassName, this.ObjectCode, row[JArchiveFields.ArchiveDesc.ToString()].ToString(), false);
                                    }
                                    /// در صورتی که توضیحات ویرایش شده
                                    //if (row[JArchiveFields.Action.ToString()].ToString() == FileActions.Update.ToString())
                                    if (row.RowState == DataRowState.Modified)
                                    {
                                        archive.UpdateDescription((int)row[JArchiveFields.Code.ToString()], row[JArchiveFields.ArchiveDesc.ToString()].ToString());
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                JSystem.Except.AddException(ex);
                                return false;
                            }
                        }
                    }
                    finally
                    {
                        archive.Dispose();
                    }


                    ///حذف آیتمهای حذف شده
                    DeleteAchive();
                    //foreach (int deleted in DeleteCodes)
                    //{
                    //    archive.DeleteArchive(deleted, false);
                    //}
                    /// در صورتی که فایلها آرشیو شدند، اکشنشان از اینزرت خارج شود
                    //if (archive.Commit())
                    {
                        foreach (DataRow row in _DataTable.Rows)
                        {
                            try
                            {
                                if (row.RowState != DataRowState.Deleted && row[JArchiveFields.Action.ToString()] != null)
                                {
                                    row[JArchiveFields.Action.ToString()] = FileActions.NoAction;
                                }
                            }
                            catch (Exception ex)
                            {
                                JSystem.Except.AddException(ex);
                            }
                        }
                        return true;
                    }
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

        /// <summary>
        ///  فقط سطرهای گرید را خالی میکند ولی از دیتابیس حذف نمیکند
        /// </summary>
        public void ClearList()
        {
            try
            {
                if (_DataTable != null)
                    _DataTable.Rows.Clear();

                pictureBox1.Image.Dispose();
                pictureBox2.Image.Dispose();

                pictureBox2.Image = null;
                pictureBox1.Image = null;
            }
            catch (Exception ex)
            {
            }

            //grdArchive.DataSource = null;
        }

        #region Private Functions

        public bool ThumbnailCallback()
        {
            return false;
        }

        private void ThumbLineClick(object sender, EventArgs e)
        {
            Image image = (Image)((PictureBox)(sender)).Tag;
            object tObject = image;
            JSystem.AddObject(ref tObject);

            Image.GetThumbnailImageAbort ImageAbort = new Image.GetThumbnailImageAbort(ThumbnailCallback);

            CurrentDataRow = (DataRow)image.Tag;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Height = image.Height;
            pictureBox1.Width = image.Width;
            pictureBox1.Image = image;//.GetThumbnailImage(panelBigImage.Width, image.Height * panelBigImage.Width / image.Width, ImageAbort, IntPtr.Zero);
        }

        private void SetPreviewImage(JFile pContent)
        {
            try
            {
                Image image = System.Drawing.Image.FromStream(pContent.Stream);
                object tObject = image;
                JSystem.AddObject(ref tObject);

                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                pictureBox2.Height = image.Height;
                pictureBox2.Width = image.Width;
                pictureBox2.Image = image;
            }
            catch
            {
                pictureBox1.Image = null;
            }
        }

        private void CreateThumbLine(JFile pContent, DataRow DR)
        {
            try
            {
                Panel P = new Panel();
                P.BorderStyle = BorderStyle.FixedSingle;
                ThumbLinepanel.Controls.Add(P);
                P.Parent = ThumbLinepanel;
                P.Width = ThumbLinepanel.Width - 50;
                P.Height = (int)(P.Width * 1.5);
                P.Left = 25;
                P.Top = _OldTop + 25;
                _OldTop = P.Top + P.Height;

                PictureBox PB = new PictureBox();
                P.Controls.Add(PB);
                PB.Parent = P;
                PB.Dock = DockStyle.Fill;
                Image image;
                if (pContent.Stream != null)
                {
                    image = System.Drawing.Image.FromStream(pContent.Stream);
                    object t1Object = image;
                    JSystem.AddObject(ref t1Object);
                    image.Tag = DR;
                    PB.Tag = image;
                    Image.GetThumbnailImageAbort ImageAbort = new Image.GetThumbnailImageAbort(ThumbnailCallback);
                    PB.Image = image.GetThumbnailImage(P.Width, P.Height, ImageAbort, IntPtr.Zero);
                    object t2Object = PB.Image;
                    JSystem.AddObject(ref t2Object);
                    PB.Click += new EventHandler(ThumbLineClick);


                    Array.Resize(ref ImagePanelList, ImagePanelList.Length + 1);
                    ImagePanelList[ImagePanelList.Length - 1] = P;
                }
            }
            catch
            {
            }
        }

        private void _LoadImagesFromArchive()
        {
            JFile content;
            if (_DataTable != null)
            {
                int OldTop = 0;
                foreach (DataRow DR in _DataTable.Rows)
                {
                    /// کد آرشیو انتخاب شده در گرید
                    int Code = DR["ArchiveCode"].GetHashCode();
                    JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
                    try
                    {
                        //// بازیابی محتوای آرشیو
                        content = archive._RetrieveContent(Code);

                        if (content != null && content.Extension.ToLower() == ".jpg")
                        {
                            CreateThumbLine(content, DR);
                        }
                    }
                    catch (Exception ex)
                    {
                        JSystem.Except.AddException(ex);
                    }
                    finally
                    {
                        archive.Dispose();
                    }

                }
            }
        }
        /// <summary>
        /// بازیابی لیست آرشیوها
        /// </summary>
        /// <returns></returns>
        private bool _LoadDataFromArchive()
        {
            JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
            try
            {
                if (ClassName == null)
                {
                    ClassName = "";
                    return false;
                }
                _DataTable = archive.Retrieve(this.ClassName, this.ObjectCode, ExtraObject);
                if (_DataTable.Rows.Count > 0)
                    CurrentDataRow = _DataTable.Rows[0];
                _DataTable.Columns.Add(JArchiveFields.Action.ToString());
                _DataTable.Columns.Add(JArchiveFields.JFile.ToString(), (new JFile()).GetType());
                grdArchive.DataSource = _DataTable;
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                archive.Dispose();
            }
        }

        /// <summary>
        /// آرشیو فایل
        /// </summary>
        /// <param name="pFile"></param>
        /// <returns></returns>
        private bool _ArchiveFile(JFile pFile)
        {
            JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode, DataBaseClassName, DataBaseObjectCode);
            try
            {
                if (archive.ArchiveDocument(pFile, this.ClassName, this.ObjectCode, "", false) > 0)
                {
                    _LoadDataFromArchive();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                archive.Dispose();
            }
        }
        #endregion Private Functions

        #region Events
        /// <summary>
        /// رویداد قبل از افزودن فایل
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void AddFile(object Sender, EventArgs e);
        public event AddFile OnAddFile;

        /// <summary>
        /// رویداد پس از افزودن فایل
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="e"></param>
        public delegate void FileAdded(object Sender, EventArgs e);
        public event FileAdded AfterFileAdded;

        public delegate void DescriptioEdited(object Sender, EventArgs e);
        public event DescriptioEdited AfterDescriptioEdited;

        public void LoadList()
        {
            if (ClassName.Length > 0)
            {
                try
                {
                    _LoadDataFromArchive();
                    grdArchive.Columns[JArchiveFields.ArchiveCode.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.AutoChange.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.ClassName.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.Code.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.ObjectCode.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.Owner.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.PlaceCode.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.Status.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.SubjectCode.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.EveryOne.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.OwnerPostCode.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.Action.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.JFile.ToString()].Visible = false;
                    grdArchive.Columns[JArchiveFields.ArchiveDate.ToString()].ReadOnly = true;
                    grdArchive.Columns["ArchiveTime"].Visible = false;

                    //grdArchive.Columns.Remove(JArchiveFields.ObjectCode.ToString());

                    //DataGridViewComboBoxColumn DGVCBC = CreateComboBoxColumn(JArchiveFields.PlaceCode.ToString());
                    //DGVCBC.HeaderText = JArchiveFields.PlaceCode.ToString();
                    //DGVCBC.Items.Add("test1");
                    //DGVCBC.Items.Add("test2");
                    //DGVCBC.Items.Add("test3");

                    //grdArchive.Columns.Add(DGVCBC);
                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
        }

        private DataGridViewComboBoxColumn CreateComboBoxColumn(string pColumnName)
        {
            DataGridViewComboBoxColumn column =
                new DataGridViewComboBoxColumn();
            {
                column.DataPropertyName = pColumnName;
                column.HeaderText = pColumnName;
                column.DropDownWidth = 160;
                column.Width = 90;
                column.MaxDropDownItems = 3;
                column.FlatStyle = FlatStyle.Flat;
            }
            return column;
        }

        private DataTable GetPlaceDataTable()
        {
            JPlacesTree PT = new JPlacesTree();
            return PT.GetData();
        }

        private void ImageList_Load(object sender, EventArgs e)
        {
            LoadList();
        }

        private void grdArchive_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdArchive.SelectedRows.Count == 0)
                return;
            JFile content;
            try
            {
                /// در صورتی که فایل جدیداً به لیست اضافه شده، بازیابی نمیشود، بلکه محتوای فایل از دیتاتیبل خوانده میشود
                if (e.RowIndex != -1)

                    if (grdArchive.CurrentRow.Cells[JArchiveFields.Action.ToString()].Value != null)
                        if (grdArchive.CurrentRow.Cells[JArchiveFields.Action.ToString()].Value.ToString() == FileActions.Insert.ToString())
                        {
                            content = (JFile)grdArchive.CurrentRow.Cells["JFile"].Value; // (JFile)_DataTable.Rows[e.RowIndex][JArchiveFields.JFile.ToString()];
                            content.Open();
                        }
                        else
                        {

                            /// کد آرشیو انتخاب شده در گرید
                            int Code = (int)grdArchive[JArchiveFields.ArchiveCode.ToString(), grdArchive.SelectedRows[0].Index].Value;
                            JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
                            try
                            {
                                //// بازیابی محتوای آرشیو
                                content = archive._RetrieveContent(Code);
                                content.Open();
                            }
                            catch (Exception ex)
                            {
                                JSystem.Except.AddException(ex);
                            }
                            finally
                            {
                                archive.Dispose();
                            }
                        }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }

        }

        private void btnAddImage_Click(object sender, EventArgs e)
        {
            try
            {
                if (OnAddFile != null)
                    OnAddFile(sender, e);
                if (this.ClassName == null)
                    return;
                ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
                if (imageForm.ShowDialog() == DialogResult.OK)
                {
                    JFile[] files = imageForm.SelectedFiles;
                    foreach (JFile _file in files)
                    {
                        if (_DataTable == null)
                        {
                            _LoadDataFromArchive();
                        }
                        DataRow row = _DataTable.NewRow();
                        row[JArchiveFields.ArchiveDate.ToString()] = ClassLibrary.JDateTime.Now();
                        row[JArchiveFields.ArchiveDesc.ToString()] = "";
                        row[JArchiveFields.Action.ToString()] = FileActions.Insert;
                        row[JArchiveFields.JFile.ToString()] = _file;
                        _DataTable.Rows.Add(row);

                        if (_file.Extension.ToLower() == ".jpg" && _file.Content != null)
                            CreateThumbLine(_file, row);
                    }
                }
                if (AfterFileAdded != null)
                    AfterFileAdded(sender, e);

                imageForm.Free();
                //ArchivedDocuments.JImageForm imageForm = new ArchivedDocuments.JImageForm();
                //if (imageForm.ShowDialog() == DialogResult.OK)
                //{
                //    _ArchiveFile(imageForm.SelectedFile);
                //}
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void grdArchive_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtDesc.Text = grdArchive[JArchiveFields.ArchiveDesc.ToString(), e.RowIndex].Value.ToString();
            if (e.RowIndex >= 0)
                CurrentDataRow = ((DataRowView)grdArchive.Rows[e.RowIndex].DataBoundItem).Row;
        }

        private void txtDesc_Leave(object sender, EventArgs e)
        {
            JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
            try
            {
                if (grdArchive.SelectedRows.Count == 0)
                    return;
                //int Code = (int)grdArchive[JArchiveFields.Code.ToString(), grdArchive.SelectedRows[0].Index].Value;
                //if (grdArchive[JArchiveFields.Action.ToString(), grdArchive.SelectedRows[0].Index].Value == null)
                //  archive.UpdateDescription(Code, txtDesc.Text);
                //else
                if (grdArchive[JArchiveFields.Action.ToString(), grdArchive.SelectedRows[0].Index].Value.ToString() == "" ||
                    grdArchive[JArchiveFields.Action.ToString(), grdArchive.SelectedRows[0].Index].Value == FileActions.NoAction.ToString())
                    grdArchive[JArchiveFields.Action.ToString(), grdArchive.SelectedRows[0].Index].Value = FileActions.Update;
                grdArchive[JArchiveFields.ArchiveDesc.ToString(), grdArchive.SelectedRows[0].Index].Value = txtDesc.Text;

                if (AfterDescriptioEdited != null)
                    AfterDescriptioEdited(sender, e);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                archive.Dispose();
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            if (OnAddFile != null)
                OnAddFile(sender, e);
            if (this.ClassName == null)
                return;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                foreach (string _FileName in openFileDialog1.FileNames)
                {
                    JFile file = new JFile();
                    file.FileName = _FileName;
                    file.FileSource = JFile.JFileSource.FromDisk;

                    if (_DataTable == null)
                    {
                        _LoadDataFromArchive();
                    }
                    DataRow row = _DataTable.NewRow();
                    row[JArchiveFields.ArchiveDate.ToString()] = ClassLibrary.JDateTime.Now();
                    row[JArchiveFields.ArchiveDesc.ToString()] = "";
                    row[JArchiveFields.Action.ToString()] = FileActions.Insert;
                    row[JArchiveFields.JFile.ToString()] = file;
                    _DataTable.Rows.Add(row);

                    try
                    {
                        if (file.Extension.ToLower() == ".jpg")
                            CreateThumbLine(file, row);
                    }
                    catch
                    {
                    }
                }
            }

            if (AfterFileAdded != null)
                AfterFileAdded(sender, e);

            //if (this.ObjectCode == 0 || this.ClassName == null)
            //    return;
            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    JFile file = new JFile();
            //    file.FileName = openFileDialog1.FileName;
            //    file.FileSource = JFile.JFileSource.FromDisk;
            //    _ArchiveFile(file);
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrentDataRow == null)
                {
                    CurrentDataRow = ((DataRowView)grdArchive.CurrentRow.DataBoundItem).Row;
                    if (CurrentDataRow == null)
                        return;
                }
                if (JMessages.Question("YouWantToDeleteDocument?", "Question") == DialogResult.Yes)
                {
                    //if (this.ClassName == null)
                    //return;
                    //grdArchive[JArchiveFields.Action.ToString(), grdArchive.SelectedRows[0].Index].Value = FileActions.Delete;
                    //DataView view = _DataTable.DefaultView;
                    //view.RowFilter = JArchiveFields.Action.ToString() + " IS Null OR " + JArchiveFields.Action.ToString() + " = " + JDataBase.Quote(FileActions.Delete.ToString(), false);
                    //grdArchive.DataSource = view;
                    //grdArchive.Rows.RemoveAt(grdArchive.SelectedRows[0].Index);
                    //_LoadDataFromArchive();
                    //return;
                    int Code = 0;
                    if (!String.IsNullOrEmpty(CurrentDataRow[JArchiveFields.Code.ToString()].ToString()))
                    {
                        Code = (int)CurrentDataRow[JArchiveFields.Code.ToString()];
                        DeleteCodes.Add(Code);
                    }

                    //DeleteCodes.Add(Code);
                    CurrentDataRow.Delete();
                    CurrentDataRow = null;
                    //_DataTable = (DataTable)(grdArchive.DataSource);
                    //_DataTable.Rows[grdArchive.SelectedRows[0].Index].Delete();
                    //grdArchive.DataSource = _DataTable;
                    //JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
                    //archive.DeleteArchive(Code, true);
                    //_LoadDataFromArchive();
                    if (AfterFileAdded != null)
                        AfterFileAdded(sender, e);
                }
            }
            catch
            {
            }
        }

        public bool DeleteAllArchive()
        {
            JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
            try
            {
                return archive.DeleteArchive(ClassName, ObjectCode, true);
            }
            finally
            {
                archive.Dispose();
            }

        }

        public bool DeleteAchive()
        {
            JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
            try
            {
                for (int i = 0; i < DeleteCodes.Count; i++)
                    if (!archive.DeleteArchive(DeleteCodes[i], false))
                        return false;
                return true;
            }
            finally
            {
                archive.Dispose();
            }
        }

        #endregion Events

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (OnAddFile != null)
                OnAddFile(sender, e);
            if (this.ObjectCode == 0 || this.ClassName == null)
                return;

        }


        private void JArchiveList_ControlRemoved(object sender, ControlEventArgs e)
        {
            try
            {
                if (_DataTable != null)
                    _DataTable.Dispose();
            }
            catch
            {
            }
        }

        private void ImagesView_Enter(object sender, EventArgs e)
        {
            if (!getImagesList)
                _LoadImagesFromArchive();
            getImagesList = true;
        }

        private void tsMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void grdArchive_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (grdArchive.SelectedRows.Count == 0)
                return;
            JFile content;
            try
            {
                /// در صورتی که فایل جدیداً به لیست اضافه شده، بازیابی نمیشود، بلکه محتوای فایل از دیتاتیبل خوانده میشود
                if (e.RowIndex != -1)

                    //if (grdArchive.CurrentRow.Cells[JArchiveFields.Action.ToString()].Value != null)
                    //  if (grdArchive.CurrentRow.Cells[JArchiveFields.Action.ToString()].Value.ToString() == FileActions.Insert.ToString())
                    if (((DataRowView)(grdArchive.CurrentRow.DataBoundItem)).Row.RowState == DataRowState.Added)
                    {
                        content = (JFile)grdArchive.CurrentRow.Cells["JFile"].Value; // (JFile)_DataTable.Rows[e.RowIndex][JArchiveFields.JFile.ToString()];
                        SetPreviewImage(content);
                    }
                    else
                    {

                        /// کد آرشیو انتخاب شده در گرید
                        int Code = (int)grdArchive[JArchiveFields.ArchiveCode.ToString(), grdArchive.SelectedRows[0].Index].Value;
                        JArchiveDocument archive = new JArchiveDocument(DataBaseClassName, DataBaseObjectCode);
                        try
                        {
                            //// بازیابی محتوای آرشیو
                            content = archive._RetrieveContent(Code);
                            SetPreviewImage(content);
                        }
                        catch (Exception ex)
                        {
                            JSystem.Except.AddException(ex);
                        }
                        finally
                        {
                            archive.Dispose();
                        }
                    }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
        }

        private void grdArchive_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (AfterDescriptioEdited != null)
                AfterDescriptioEdited(sender, e);
        }

        private void grdArchive_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            grdArchive_CellClick(sender, e);
        }

        private void JArchiveList_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        protected override bool ProcessKeyPreview(ref Message msg)
        {
            KeyEventArgs e = null;
            // if ((m.Msg != WM_CHAR) && (m.Msg != WM_SYSCHAR) && (m.Msg != WM_IME_CHAR))
            {
                e = new KeyEventArgs(((Keys)((int)((long)msg.WParam))) | ModifierKeys);
                if (e.KeyData == Keys.F1)
                    btnAddImage.PerformClick();
            }
            return base.ProcessKeyPreview(ref msg);
        }

        private void JArchiveList_KeyUp(object sender, KeyEventArgs e)
        {
            //if (KeyData == Keys.F1)
            //    btnAddImage.PerformClick();
        }

        private void btnGetWebCam_Click(object sender, EventArgs e)
        {
            ClassLibrary.WebCam.GetWebCam FWeb = new ClassLibrary.WebCam.GetWebCam();
            FWeb.ShowDialog();
            if (FWeb.current != null)
            {
                Image img = Image.FromHbitmap(FWeb.current.GetHbitmap());
                img.Save(System.IO.Path.GetTempPath() + "\\webcam.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                JFile _file = new JFile();
                _file.FileName = System.IO.Path.GetTempPath() + "\\webcam.jpg";
                DataRow row = _DataTable.NewRow();
                row[JArchiveFields.ArchiveDate.ToString()] = ClassLibrary.JDateTime.Now();
                row[JArchiveFields.ArchiveDesc.ToString()] = "";
                row[JArchiveFields.Action.ToString()] = FileActions.Insert;
                row[JArchiveFields.JFile.ToString()] = _file;
                _DataTable.Rows.Add(row);

                if (_file.Extension.ToLower() == ".jpg" && _file.Content != null)
                    CreateThumbLine(_file, row);
                FWeb.current.Dispose();
                FWeb.current = null;
            }
        }

        private void grdArchive_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex >= 0)
                if (grdArchive.Rows[e.RowIndex].Cells["ClassName"].Value.ToString() != this.ClassName)
                {
                    e.CellStyle.ForeColor = Color.Red;
                }

        }
    }

}
