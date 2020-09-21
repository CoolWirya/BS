using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JPatternFileTable:JTable
    {
        public JPatternFileTable()
            : base("patternfile")
        {
        }
        public string Name;
        public int Type;
        public string Pattern;
        public int User_Code;
    }
}
