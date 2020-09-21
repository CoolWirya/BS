using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTOMOBILE.AutomobileDefine
{
    public class JAutomobileTable: ClassLibrary.JTable
    {
        public string Plaque;
        public int Type;
        public int Model;
        public bool Active;
        /// <summary>
        /// کارخانه سازنده
        /// </summary>
        public int maker;
        /// <summary>
        /// Zarfiat
        /// </summary>
        public int Capacity;
        public int IconCode;
        public JAutomobileTable()
            : base("AUTAutomobile")
        {
        }
    }
}
