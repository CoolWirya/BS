using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entertainment
{
    public class JAboutUsTable:JTable
    {

        public JAboutUsTable()
            : base("entAboutUs")
        { }

        #region Properties
        public string Text;
        public string ClassName;
        public int ArchiveCode;
        #endregion
    }
}
