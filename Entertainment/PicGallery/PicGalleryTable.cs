using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entertainment
{
    public class PicGalleryTable:JTable
    {

        public PicGalleryTable()
            : base("entPicGallery")
        { }

        #region Properties
        public string Text;
        public string ClassName;
        public int ArchiveCode;
        #endregion
    }
}
