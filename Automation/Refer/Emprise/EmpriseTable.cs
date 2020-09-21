using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JAEmpriseTable : JTable
    {
        #region Properties

        public int User_post_code;
        public string Description;

        #endregion

        public JAEmpriseTable() :
            base(JTableNamesAutomation.Emprise)
        {
        }

    }
}
