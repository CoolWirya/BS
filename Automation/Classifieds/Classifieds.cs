using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    class JClassifiedsNode : JAutomation
    {
        public int Code { get; set; }
        public int Name { get; set; }
        public string Index { get; set; }
        public int Parent { get; set; }
        public int[] Childs;

        public JClassifiedsNode()
        {
        }

        public Boolean Update()
        {
            return true;
        }

        public Boolean Delete()
        {
            return true;
        }

        public Boolean Insert()
        {
            return true;
        }

        /// <summary>
        /// کپی یک کلاسه در یک مکان دیگر
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public Boolean Insert(int pCode)
        {
            return true;
        }

        public Boolean GetData(int pCode)
        {
            return true;
        }

    }

    class JClassifieds : JAutomation
    {

        public JClassifieds()
        {
        }
    }
}
