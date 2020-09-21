using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.SubUserObjects
{
    public class JAVLSubUserObjectsTable : ClassLibrary.JTable
    {
        public int parentUserCode;
        public int userCode;
        public string objects;
        public JAVLSubUserObjectsTable()
            : base("AVLSubUserObjects")
        {
        }
    }
}
