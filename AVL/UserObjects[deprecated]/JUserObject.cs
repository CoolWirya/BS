using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.UserObjects
{
    public class JUserObject : ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int personCode { get; set; }
        /// <summary>
        /// It is related to Code of ObjectList table.
        /// </summary>
        public int objectListCode { get; set; }
        public DateTime registerDatetime { get; set; }
        public bool isActive { get; set; }
    
    }
}
