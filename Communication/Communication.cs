using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Windows.Forms;
using System.Xml;
using System.Data;
using ClassLibrary;

namespace Communication
{
   public class JCommunication : JSystem 
    {
    }

    public class JCommunicationNode : JSystem
    {

        public void ListView()
        {
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[1];
            N[0] = JCommunicationBaseNode._LetterNode();

            return N;
        }

    }
    public class JCommunicationBaseNode : JSystemNode
    {

        public static JNode _LetterNode()
        {
            JNode Node = new JNode(0, "Communication.JLetter.Pattern");
            Node.Name = "Pattern";
            Node.Hint = "Pattern";

            JAction Ac = new JAction("JLetterPattern", "Communication.JPatterForm.ShowDialog", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            return Node;
        }
    }
}
