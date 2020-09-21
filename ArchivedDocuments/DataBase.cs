using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchivedDocuments
{
    public class JArchiveDataBase:ClassLibrary.JDataBase
    {
        public JArchiveDataBase()
            : base(true)
        {
            ClassLibrary.JConfig DC = new ClassLibrary.JConfig();
            DC.Server = DC.ServerArchive;
            DC.Database = DC.DatabaseArchive;
            DC.Username = DC.UsernameArchive;
            DC.Password = DC.PasswordArchive;
            ConnectEmptyDataBase(DC);
        }
    }
}
