using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    /// <summary>
    /// نود پدر اطلاعات پایه
    /// </summary>
    public class JBaseInformation : JAutomation
    {        
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JBaseInformation()
        {
        }
        #endregion Constructors
        // Node
        #region Node
        public JNode GetNode()
        {
            //return JAStaticNode._BaseDefineNode(this);
            return null;
        }
        #endregion Node
    }
    /// <summary>
    /// کلاس پدر اطلاعات پایه
    /// </summary>
    public class JBaseInformations : JAutomation
    {
        #region View
        /// <summary>
        /// تشکیل نودهای کلاس اطلاعات پایه
        /// </summary>
        public void ListView()
        {
            Nodes.Insert(JAStaticAction._SubsidiariessNode());
            //Nodes.Insert(JAStaticAction._DefineKartablNode());

        }

        /// <summary>
        /// تشکیل زیردرخت کلاس اطلاعات پایه
        /// </summary>
        public JNode[] TreeView()
        {

            JNode[] N = new JNode[2];
            N[0] = JAStaticAction._SubsidiariessNode();
            //N[1] = JAStaticAction._DefineKartablNode();

            return N;
        }
        #endregion View
    }
}
