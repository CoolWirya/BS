using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    /// <summary>
    /// انواع فایل
    /// </summary>
    public class JAFileTypeDefine : JSubBaseDefine
    {
        public JAFileTypeDefine()
            : base(JABaseDefine.FileType)
        {
        }      
    }
}