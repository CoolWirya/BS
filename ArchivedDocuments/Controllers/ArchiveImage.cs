using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace ArchivedDocuments
{
    public partial class JArchiveImage : PictureBox
    {
        public JArchiveImage()
        {
            InitializeComponent();
            State = JFormState.None;
        }

        public JArchiveImage(IContainer container)
        {
            try
            {
                container.Add(this);
                InitializeComponent();
                BackgroundImageLayout = ImageLayout.Stretch;
                State = JFormState.None;
            }
            catch { }
            finally { }
        }

        public void Dispose()
        {
            if (Image != null)
                Image.Dispose();
        }

        public static bool IsInDesignMode()
        {
            return System.Reflection.Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        #region Properties

        public JFormState State
        {
            get;
            set;
        }

        [
        Category("Archive"),
        Description("نام کلاس")
        ]
        /// <summary>
        /// نام کلاس
        /// </summary>
        public string ClassName
        {
            get;
            set;
        }
        /// <summary>
        /// کد شیء
        /// </summary>
        [
        Category("Archive"),
        Description("کد شیء")
        ]
        public int ObjectCode
        {
            get;
            set;
        }
        /// <summary>
        /// کد بایگانی
        /// </summary>
        [
        Category("Archive"),
        Description("کد بایگانی")
        ]
        private int _ArchiveCode;
        public int ArchiveCode
        {
            get { return _ArchiveCode; }
            set
            {
                _ArchiveCode = value;
                if (!IsInDesignMode())
                    LoadDataFromArchive();
            }
        }

        /// <summary>
        /// توضیحات بایگانی
        /// </summary>
        [
        Category("Archive"),
        Description("توضیحات بایگانی")
        ]
        public string Description
        {
            get;
            set;
        }


        /// <summary>
        /// تغییر خودکار
        /// </summary>
        [
        Category("Archive"),
        Description("تغییر خودکار")
        ]
        public bool AutoChange
        {
            get;
            set;
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
        /// حذف کامل پس از ویرایش یا حذف
        /// </summary>
        [
        Category("Archive"),
        Description("حذف کامل پس از ویرایش یا حذف")
        ]
        public bool DeleteCompeletly
        {
            get;
            set;
        }

        public JFile ImageFile
        {
            get;
            set;
        }
        bool Changed = false;
        #endregion Properties

        #region Private Functions
        /// <summary>
        /// بازیابی لیست آرشیوها
        /// </summary>
        /// <returns></returns>
        public bool LoadDataFromArchive()
        {
            JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode);
            try
            {
                

                if (ClassName == null)
                    ClassName = "";
                archive.GetData(_ArchiveCode);
                JFile image = archive.RetrieveContent(archive.ArchiveCode);
                if (image == null)
                    return false;
                ClassName = archive.ClassName;
                ObjectCode = archive.ObjectCode;
                this.Image = System.Drawing.Image.FromStream(image.Stream);
                object tObject = this.Image;
                JSystem.AddObject(ref tObject);

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


        #endregion Private Functions

        #region Events
        public delegate void AddFile(object Sender, EventArgs e);
        public event AddFile OnAddFile;

        public delegate void FileAdded(object Sender, EventArgs e);
        public event FileAdded AfterFileAdded;

        private void mnuImages_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //if (this.ObjectCode == 0 || this.ClassName == null)
            //    return;
            //if (this.Description == null)
            //    this.Description = "";
            /// تصویر جدید
            if (e.ClickedItem == newItem)
            {
                if (OnAddFile != null)
                    OnAddFile(sender, e);
                //JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode);
                JImageForm image = new JImageForm();
                if (image.ShowDialog() == DialogResult.OK)
                {
                    //this.ArchiveCode = archive.ArchiveDocument(image.SelectedFile, this.ClassName, this.ObjectCode, this.Description, this.AutoChange);
                    //if (this.ArchiveCode > 0)
                    {
                        this.Image = image.SelectedImage;
                        this.ImageFile = image.SelectedFile;
                        this.State = JFormState.Insert;
                        if (AfterFileAdded != null)
                            AfterFileAdded(sender, e);
                    }
                }
                //JMessages.Information(this.ArchiveCode.ToString(), "");
            }
            /// ویرایش تصویر
            if (e.ClickedItem == editMenuItem)
            {
                //JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode);
                JImageForm image = new JImageForm();
                if (image.ShowDialog() == DialogResult.OK)
                {
                    //archive.UpdateArchive(image.SelectedFile, this.ArchiveCode, this.Description, DeleteCompeletly);
                    //if (this.ArchiveCode > 0)
                    {
                        Changed = true;
                        this.Image = image.SelectedImage;
                        this.ImageFile = image.SelectedFile;
                        this.State = JFormState.Update;
                    }
                }
            }
            /// حذف تصویر
            if (e.ClickedItem == deleteImageItem)
            {
                if (JMessages.Question("YouWantToDeletePicture?", "Question") == DialogResult.Yes)
                {
                    //JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode);
                    //if (archive.DeleteArchive(this.ArchiveCode, DeleteCompeletly))
                    this.Image = null;
                    this.State = JFormState.Delete;
                }
            }
        }

        private void mnuImages_Opening(object sender, CancelEventArgs e)
        {
            if (this.Image == null)
            {
                newItem.Enabled = true;
                editMenuItem.Enabled = false;
                deleteImageItem.Enabled = false;
            }
            else
            {
                newItem.Enabled = false;
                editMenuItem.Enabled = true;
                deleteImageItem.Enabled = true;
            }
        }
        #endregion Events

        #region Public Functions
        public void AddImage()
        {
            newItem.PerformClick();
        }

        public void EditImage()
        {
            editMenuItem.PerformClick();
        }

        public void DeleteImage()
        {
            deleteImageItem.PerformClick();
        }

        public int ArchiveImage()
        {
            JArchiveDocument archive = new JArchiveDocument(SubjectCode, PlaceCode);
            try
            {
                /// حذف
                if (Image == null && State == JFormState.Delete)
                {
                    if (archive.DeleteArchive(_ArchiveCode, DeleteCompeletly))
                        return 0;
                    else
                        return 0;
                }
                /// جدید
                //if (ArchiveCode == 0)
                {
                    if (this.Image != null && (State == JFormState.Insert || State == JFormState.Update))
                    {
                        _ArchiveCode = archive.ArchiveDocument(ImageFile, this.ClassName, this.ObjectCode, this.Description, true);
                    }
                    return _ArchiveCode;
                }
                //else
                /// ویرایش 
                //if (ArchiveCode > 0 && Changed)
                //{
                //return archive.ArchiveDocument(ImageFile, ArchiveCode, this.Description, DeleteCompeletly, true);
                //}
                return 0;
            }
            finally
            {
                archive.Dispose();
            }
        }
        #endregion Public Functions


    }
}
