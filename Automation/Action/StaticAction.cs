using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JAStaticAction
    {
        public static JAction _NewDocumentClick()
        {
            return new JAction("New", "OfficeWord.JOfficeWord.New");
        }
        
        public static JNode _BaseInformationsNode()
        {
            JNode Node = new JNode(0, "");
            Node.Name = "BaseInformation";
            //Node.Icone = 4;
            Node.Hint = "BaseInformation";

            JAction Ac = new JAction("BaseInformation", "Automation.JBaseInformations.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseInformation", "Automation.JBaseInformations.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }


        public static JNode _DefineKartablNode()
        {
            JNode Node = new JNode(0, "");
            //Node.Name = "DefineKartabl";
            ////Node.Icone = 4;
            //Node.Hint = "DefineKartabl";
            
            //JAction Ac = new JAction("DefineKartabl", "Automation.JAFolders.ListView", null, null, true);
            //Node.MouseClickAction = Ac;
            //Node.MouseDBClickAction = Ac;

            ////JAction CAc = new JAction("DefineKartabl", "Automation.JAFolder.TreeView");
            ////Node.ChildsAction = CAc;

            return Node;
        }

        #region SubsidiariesNode
        public static JNode _SubsidiariesNode(JASubsidiaries pSubsidiaries)
        {
            JNode Node = new JNode(pSubsidiaries.Code, "Automation.JASubsidiaries");
            Node.Name = pSubsidiaries.Name;

            JAction EditAction = new JAction("Edit...", "Automation.JASubsidiaries.UpdateForm", new object[] { pSubsidiaries.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "Automation.JASubsidiaries.Delete", new object[] { pSubsidiaries.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Automation.JASubsidiaries.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        public static JNode _SubsidiariessNode()
        {
            JNode Node = new JNode(0, "Automation.JASubsidiaries");
            Node.Name = "Subsidiaries";
            //Node.Icone = 4;
            Node.Hint = "Subsidiaries";

            JAction Ac = new JAction("Subsidiaries", "Automation.JASubsidiariess.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            //JAction CAc = new JAction("Subsidiaries", "Automation.JASubsidiariess.TreeView");
            //Node.ChildsAction = CAc;

            return Node;
        }
        #endregion SubsidiariesNode

    }
}
