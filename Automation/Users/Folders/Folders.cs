using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation.Users.Folders
{
    class JFolders:JTree
    {
        public JFolders()
            : base(JTreeTypes.UserFolders, "Automation.JAUser")
        {
        }
    }
}
