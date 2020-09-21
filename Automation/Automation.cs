using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ClassLibrary;

namespace Automation
{
    public class JAutomation : JSystem
    {
        public static JAFolderTypeEnum CurrentKartable;
        public static int CurrentAutomationPostCode;
    }

    public class JAutomationNode : JSystem
    {

        public void ListView()
        {
            JToolbarNode NewDocument = new JToolbarNode();
            NewDocument.Click = JAStaticAction._NewDocumentClick();
            NewDocument.Name = "test";
            Nodes.AddToolbar(NewDocument);
        }

        public JNode[] TreeView()
        {
            JKartable KarT = new JKartable();
            JNode[] N = new JNode[7];
            N[0] = KarT.Box(JAFolderTypeEnum.Inbox);
            N[1] = KarT.Box(JAFolderTypeEnum.SendItem);
            N[2] = Communication.JLetters.GetNode();
            N[3] = Communication.JLetters.GetSearchNode();
            N[4] = Communication.JCSecretariats.GetSecretariatNode();
            N[5] = ClassLibrary.SMS.JSMSess.GetNode();
            N[6] = ClassLibrary.EMail.JEMails.GetNode();

            return N;
        }

    }

    public class JAutomationBaseNode : JSystemNode
    {


    }
}
