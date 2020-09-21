using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JsecretariatUserTable: ClassLibrary.JTable
    {
        public int secCode;
        public int pCode;

        public JsecretariatUserTable()
            : base("secretariatUser")
        {
        }


    }
}
