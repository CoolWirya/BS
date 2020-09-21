using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AUTOMOBILE
{
    public class JAutomobileTable: ClassLibrary.JTable
    {
        public string Plaque;
        public int Type;
        public int Model;
        public bool Active;
        /// <summary>
        /// Zarfiat
        /// </summary>
        public int Capacity;
        /// <summary>
        /// Console Code From Smart card
        /// </summary>
        public int CCode;
        /// <summary>
        /// Owner 
        /// </summary>
        public int PCode;

        public JAutomobileTable()
            : base("AUTAutomobile")
        {
        }
    }
}
