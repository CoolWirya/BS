using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Communication
{
    public class JAStaticNode: JStaticNode
    {
        //-------------  تعاریف پایه ------------------
        #region BaseDefine

        public static JNode _BaseDefinesNode()
        {
            JNode Node = new JNode(0, "Communication.JCBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Communication.JCBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Communication.JCBaseDefine.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }
        public static JNode _BaseDefineNode(JBaseDefine pBaseDefine)
        {
            JNode Node = new JNode(pBaseDefine.Code, "Communication.JCBaseDefine");
            Node.Name = pBaseDefine.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCBaseDefine.UpdateForm", new object[] { pBaseDefine.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "Communication.JCBaseDefine.Delete", new object[] { pBaseDefine.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCBaseDefine.InsertForm");
            Node.Popup.Insert(InsertAction);
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }

        #endregion BaseDefine

        //------------- اطلاعات پایه  ------------------
        #region BaseInformation

        public static JNode _BaseInformationsNode()
        {
            JNode Node = new JNode(0, "");
            Node.Name = "BaseInformation";
            //Node.Icone = 4;
            Node.Hint = "BaseInformation";

            JAction Ac = new JAction("BaseInformation", "Communication.JCBaseInformations.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseInformation", "Communication.JCBaseInformations.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.BaseDefine.GetHashCode();
            return Node;
        }


 
        #endregion BaseInformation

        //------------- دبیرخانه  ------------------
        #region Secretariat

        public static JNode _SecretariatsNode()
        {
            JNode Node = new JNode(0, "Communication.JCSecretariat");
            Node.Name = "Secretariat";
            //Node.Icone = 4;
            Node.Hint = "Secretariat";

            JAction Ac = new JAction("Secretariat", "Communication.JCSecretariats.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Secretariat", "Communication.JCSecretariats.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterSecretariat.GetHashCode();
            return Node;
        }
        public static JNode _SecretariatNode(JCSecretariat pSecretariat)
        {
            JNode Node = new JNode(pSecretariat.Code, "Communication.JCSecretariat");
            Node.Name = pSecretariat.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCSecretariat.UpdateForm", new object[] { pSecretariat.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "Communication.JCSecretariat.Delete", new object[] { pSecretariat.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCSecretariat.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }

        #endregion Secretariat

        public static JNode _SubjectLetterNode()
        {
            JNode Node = new JNode(0, "ArchivedDocuments.JSubjectTree");
            Node.Name = "SubjectLetter";
            JAction Ac = new JAction("SubjectLetter", "ArchivedDocuments.JSubjectTree.ShowForm");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.LetterSubject.GetHashCode();
            return Node;
        }

        //------------- مخزن شماره نامه  ------------------
        #region StorageLetterNo
        public static JNode _StorageLetterNosNode()
        {
            JNode Node = new JNode(0, "Communication.JCStorageLetterNo");
            Node.Name = "StorageLetterNo";
            //Node.Icone = 4;
            Node.Hint = "StorageLetterNo";

            JAction Ac = new JAction("StorageLetterNo", "Communication.JCStorageLetterNos.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("StorageLetterNo", "Communication.JCStorageLetterNos.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterStorage.GetHashCode();            
            return Node;
        }
        public static JNode _StorageLetterNoNode(JCStorageLetterNo pStorageLetterNo)
        {
            JNode Node = new JNode(pStorageLetterNo.Code, "Communication.JCStorageLetterNos");
            Node.Name = pStorageLetterNo.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.Code }, null);
            Node.EnterClickAction = EnterAction;


            JAction DeleteAction = new JAction("Delete", "Communication.JCStorageLetterNo.Delete", new object[] { pStorageLetterNo.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCStorageLetterNo.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion StorageLetterNo

        //------------- نامه  ------------------
        #region Letter
        public static JNode _LettersNode()
        {
            JNode Node = new JNode(0, "Communication.JCLetter");
            Node.Name = "Minutes";
            //Node.Icone = 4;
            Node.Hint = "Minutes";

            JAction Ac = new JAction("Minutes", "Communication.JCLetters.ListView", null, null, true);

            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Minutes", "Communication.JCLetters.TreeView", null, null);
            Node.ChildsAction = CAc;

            return Node;
        }

        public static JNode _LetterNode(JCLetter pLetter)
        {
            JNode Node = new JNode(pLetter.Code, "Communication.JCLetters");
            Node.Name = pLetter.Name;

            //JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.pCode }, null);
            //Node.MouseDBClickAction = EditAction;
            //Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            //Node.Popup.Insert(EditAction);

            //JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.pCode }, null);
            //Node.EnterClickAction = EnterAction;


            //JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.pCode }, null);
            //Node.Popup.Insert(DeleteAction);

            //JAction InsertAction = new JAction("New", "Communication.JCLetters.InsertForm");
            //Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion Letter

        //------------- ثبت نامه  ------------------
        #region LetterRegister
        public static JNode _LetterRegistersNode()
        {
            JNode Node = new JNode(0, "Communication.JCLetterRegister");
            Node.Name = "RegisterLetter";
            //Node.Icone = 4;
            Node.Hint = "RegisterLetter";

            JAction Ac = new JAction("RegisterLetter", "Communication.JCLetterRegisters.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("RegisterLetter", "Communication.JCLetterRegisters.TreeView", null, null);
            Node.ChildsAction = CAc;

            return Node;
        }
        //public static JNode _LetterRegister(JCLetter pRegisterLetter)
        //{
        //    JNode Node = new JNode(pRegisterLetter.Code, "Communication.JCLetterRegisters");
        //    Node.Name = pRegisterLetter.Name;

        //    //JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.MouseDBClickAction = EditAction;
        //    //Node.MouseClickAction = EditAction;
        //    Node.Icone = 5;
        //    //Node.Popup.Insert(EditAction);

        //    //JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.EnterClickAction = EnterAction;


        //    //JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.Popup.Insert(DeleteAction);

        //    //JAction InsertAction = new JAction("New", "Communication.JCLetters.InsertForm");
        //    //Node.Popup.Insert(InsertAction);

        //    return Node;
        //}
        #endregion LetterRegister

        //------------- ثبت نامه وارده  ------------------
        #region LetterRegisterImport
        /// <summary>
        /// نود ثبت نامه وارده
        /// </summary>
        /// <returns></returns>
        public static JNode _LetterRegisterImportsNode()
        {
            JNode Node = new JNode(0, "Communication.JCLetterRegisterImport");
            Node.Name = "LetterImport";
            Node.Icone = 4;
            Node.Hint = "LetterImport";

            JAction Ac = new JAction("LetterImport", "Communication.JCLetterRegisterImports.ListView", null, null, true);
            //Node.MouseDBClickAction = Node.MouseClickAction;
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            //JAction CAc = new JAction("JCLetterRegisterImport", "Communication.JCLetterRegisterImports.TreeView");
            //Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterImport.GetHashCode();
            return Node;
        }
        //public static JNode _LetterRegisterImport(JCLetter pRegisterLetterImport)
        //{
        //    JNode Node = new JNode(pRegisterLetterImport.Code, "Communication.JCLetterRegisterImport");
        //    Node.Name = pRegisterLetterImport.Name;

        //    //JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.MouseDBClickAction = EditAction;
        //    //Node.MouseClickAction = EditAction;
        //    //Node.Icone = 5;
        //    //Node.Popup.Insert(EditAction);

        //    //JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.EnterClickAction = EnterAction;


        //    //JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.pCode }, null);
        //    //Node.Popup.Insert(DeleteAction);

        //    //JAction InsertAction = new JAction("New", "Communication.JCLetters.InsertForm");
        //    //Node.Popup.Insert(InsertAction);

        //    return Node;
        //}
        #endregion LetterRegisterImport

        //------------- ثبت نامه صادره  ------------------
        #region LetterRegisterExport
        public static JNode _LetterRegisterExportsNode()
        {
            JNode Node = new JNode(0, "Communication.JCLetterRegisterExport");
            Node.Name = "LetterExport";
            //Node.Icone = 4;
            Node.Hint = "LetterExport";

            JAction Ac = new JAction("JCLetterRegisterExport", "Communication.JCLetterRegisterExports.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JCLetterRegisterExport", "Communication.JCLetterRegisterExports.TreeView", null, null);
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterExport.GetHashCode();
            return Node;
        }
        public static JNode _LetterRegisterExport(JCLetter pRegisterLetterExport)
        {
            JNode Node = new JNode(pRegisterLetterExport.Code, "Communication.JCLetterRegisterExport");
            Node.Name = pRegisterLetterExport.Name;

            //JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.pCode }, null);
            //Node.MouseDBClickAction = EditAction;
            //Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            //Node.Popup.Insert(EditAction);

            //JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.pCode }, null);
            //Node.EnterClickAction = EnterAction;


            //JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.pCode }, null);
            //Node.Popup.Insert(DeleteAction);

            //JAction InsertAction = new JAction("New", "Communication.JCLetters.InsertForm");
            //Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion LetterRegisterExport

        //-------------  ثبت نامه درون سازمانی ------------------
        #region LetterRegisterInternal
        public static JNode _LetterRegisterInternalsNode()
        {
            JNode Node = new JNode(0, "Communication.JCLetterRegisterInternal");
            Node.Name = "LetterInternal";
            //Node.Icone = 4;
            Node.Hint = "LetterInternal";

            JAction Ac = new JAction("JCLetterRegisterInternal", "Communication.JCLetterRegisterInternals.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("JCLetterRegisterInternal", "Communication.JCLetterRegisterInternals.TreeView", null, null);
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterInternal.GetHashCode();
            return Node;
        }
        public static JNode _LetterRegisterInternal(JCLetter pRegisterLetterInternal)
        {
            JNode Node = new JNode(pRegisterLetterInternal.Code, "Communication.JCLetterRegisterInternal");
            Node.Name = pRegisterLetterInternal.Name;

            //JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.pCode }, null);
            //Node.MouseDBClickAction = EditAction;
            //Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            //Node.Popup.Insert(EditAction);

            //JAction EnterAction = new JAction("", "", new object[] { pStorageLetterNo.pCode }, null);
            //Node.EnterClickAction = EnterAction;


            //JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.pCode }, null);
            //Node.Popup.Insert(DeleteAction);

            //JAction InsertAction = new JAction("New", "Communication.JCLetters.InsertForm");
            //Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion LetterRegisterInternal

        //-------------  سازمان ها ------------------
        #region Organization

        public static JNode _OrganizationsNode()
        {
            JNode Node = new JNode(0, "ClassLibrary.JOrganization");
            Node.Name = "Organizations";
            //Node.Icone = 4;
            Node.Hint = "Organizations";

            JAction Ac = new JAction("Organization", "ClassLibrary.JOrganizations.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            //JAction CAc = new JAction("Organization", "ClassLibrary.JOrganizations.TreeView");
            //Node.ChildsAction = CAc;

            return Node;
        }
        public static JNode _OrganizationNode(JOrganization pOrganization)
        {
            JNode Node = new JNode(pOrganization.Code, "ClassLibrary.JOrganization");
            Node.Name = pOrganization.Name;

            JAction EditAction = new JAction("Edit...", "ClassLibrary.JOrganization.UpdateForm", new object[] { pOrganization.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction DeleteAction = new JAction("Delete", "ClassLibrary.JOrganization.Delete", new object[] { pOrganization.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "ClassLibrary.JOrganization.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }

        #endregion Organization

        //------------- فایل های الگوی نامه  ------------------
        #region PatternFiles
        public static JNode _PatternFilesNode()
        {
            JNode Node = new JNode(0, "Communication.JCPatternFile");
            Node.Name = "PatternFile";
            //Node.Icone = 4;
            Node.Hint = "PatternFile";

//            JAction Ac = new JAction("PatternFile", "Communication.JCPatternFiles.ListView", null, null, true);
            JAction Ac = new JAction("PatternFile", "Communication.JPatternFiles.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("PatternFile", "Communication.JPatternFiles.TreeView");
            Node.ChildsAction = CAc;
            Node.Icone = JImageIndex.LetterPattern.GetHashCode();
            return Node;
        }
        public static JNode _PatternFileNode(JCPatternFile pPatternFile)
        {
            JNode Node = new JNode(pPatternFile.Code, "Communication.JCPatternFiles");
            Node.Name = pPatternFile.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCPatternFile.UpdateForm", new object[] { pPatternFile.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;
            Node.Popup.Insert(EditAction);

            JAction EnterAction = new JAction("", "", new object[] { pPatternFile.Code }, null);
            Node.EnterClickAction = EnterAction;


            JAction DeleteAction = new JAction("Delete", "Communication.JCPatternFile.Delete", new object[] { pPatternFile.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCPatternFile.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion PatternFiles

        public static JNode _RelationPersons()
        {
            JNode Node = new JNode(0, "Communication.JRelationPersons");
            Node.Name = "RelationPersons";
            JAction Ac = new JAction("RelationPersons", "Communication.JRelationPersons.ShowForm");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Relation.GetHashCode();
            return Node;
        }

        public static JNode _SearchLetter()
        {
            JNode Node = new JNode(0, "Communication.JCSearchLetter");
            Node.Name = "SearchLetter";
            JAction Ac = new JAction("SearchLetter", "Communication.JCSearchLetter.ShowForm");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.SearchLetter.GetHashCode();
            return Node;
        }

        public static JNode _Help()
        {
            JNode Node = new JNode(0, "Communication.JCSearchLetter");
            Node.Name = "Help";
            JAction Ac = new JAction("Help", "Communication.JCSearchLetter.HelpForm");
            //Node.DBClick = Ac;
            Node.MouseDBClickAction = Ac;
            Node.MouseClickAction = Ac;
            Node.Icone = JImageIndex.Help.GetHashCode();
            return Node;
        }

    }

    public class JEmpStaticNode : JStaticNode
    {
        #region BaseDefine
        public static JNode _BaseDefinesNode()
        {
            JNode Node = new JNode(0, "Communication.JCBaseDefine");
            Node.Name = "BaseDefine";
            //Node.Icone = 4;
            Node.Hint = "BaseDefine";

            JAction Ac = new JAction("BaseDefine", "Communication.JCBaseDefine.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("BaseDefine", "Communication.JCBaseDefine.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }
        public static JNode _BaseDefineNode(JBaseDefine pBaseDefine)
        {
            JNode Node = new JNode(pBaseDefine.Code, "Communication.JCBaseDefine");
            Node.Name = pBaseDefine.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCBaseDefine.UpdateForm", new object[] { pBaseDefine.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;

            JAction DeleteAction = new JAction("Delete", "Communication.JCBaseDefine.Delete", new object[] { pBaseDefine.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCBaseDefine.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion BaseDefine

        #region Secretariat
        public static JNode _SecretariatsNode()
        {
            JNode Node = new JNode(0, "Communication.JCSecretariat");
            Node.Name = "Secretariat";
            //Node.Icone = 4;
            Node.Hint = "Secretariat";

            JAction Ac = new JAction("Secretariat", "Communication.JCSecretariats.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Secretariat", "Communication.JCSecretariats.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }
        public static JNode _SecretariatNode(JCSecretariat pSecretariat)
        {
            JNode Node = new JNode(pSecretariat.Code, "Communication.JCSecretariat");
            Node.Name = pSecretariat.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JCSecretariat.UpdateForm", new object[] { pSecretariat.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;

            JAction DeleteAction = new JAction("Delete", "Communication.JCSecretariat.Delete", new object[] { pSecretariat.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JCSecretariat.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion Secretariat
        
        #region StorageLetterNo
        public static JNode _StorageLetterNosNode()
        {
            JNode Node = new JNode(0, "Communication.JStorageLetterNo");
            Node.Name = "StorageLetterNo";
            //Node.Icone = 4;
            Node.Hint = "StorageLetterNo";

            JAction Ac = new JAction("StorageLetterNo", "Communication.JStorageLetterNos.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("StorageLetterNo", "Communication.JStorageLetterNos.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }
        public static JNode _StorageLetterNoNode(JCStorageLetterNo pStorageLetterNo)
        {
            JNode Node = new JNode(pStorageLetterNo.Code, "Communication.JStorageLetterNo");
            Node.Name = pStorageLetterNo.Name;

            JAction EditAction = new JAction("Edit...", "Communication.JStorageLetterNo.UpdateForm", new object[] { pStorageLetterNo.Code }, null);
            Node.MouseDBClickAction = EditAction;
            Node.MouseClickAction = EditAction;
            //Node.Icone = 5;

            JAction DeleteAction = new JAction("Delete", "Communication.JStorageLetterNo.Delete", new object[] { pStorageLetterNo.Code }, null);
            Node.Popup.Insert(DeleteAction);

            JAction InsertAction = new JAction("New", "Communication.JStorageLetterNo.InsertForm");
            Node.Popup.Insert(InsertAction);

            return Node;
        }
        #endregion StorageLetterNo
    }
}
