using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace SmartCard
{

    public enum JPriceState
    {
        None = 0,
        Const = 1,
        Prcent = 2,
    }

    public class JCardsType : JSystem
    {
        public int Code{get;set;}
        public int TypeCode { get; set; }
        public JCardsType()
        {
        }
        public JCardsType(int pCode)
        {
            if (pCode > 0)
                this.GetData(pCode);
        }
        public int Save()
        {
            if (!Find(TypeCode))
            {
                return Insert();
            }
            else
            {
                Update();
                return Code;
            }
        }

        public int Insert()
        {
            JCardsTypeTable CTT = new JCardsTypeTable();
            CTT.SetValueProperty(this);
            Code = CTT.Insert();
            if (Code > 0)
                Nodes.DataTable.Merge(JCards.GetDataTable(Code));
            return Code;
        }

        public bool Update()
        {
            JCardsTypeTable CTT = new JCardsTypeTable();
            CTT.SetValueProperty(this);
            return CTT.Update();
        }

        public bool Delete()
        {
            JCardsTypeTable CTT = new JCardsTypeTable();
            CTT.SetValueProperty(this);
            return CTT.Update();
        }

        public bool Find(int pCardType)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("SELECT Code From CardsType WHERE CardType=" + pCardType.ToString());
                return DB.Query_DataTable().Rows.Count >= 1;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetData(int pCode)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("SELECT * From CardsType WHERE Code=" + pCode.ToString());
                System.Data.DataTable DT =DB.Query_DataTable();
                if (DT.Rows.Count == 1)
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public bool GetDataType(int pCardType)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("SELECT * From CardsType WHERE TypeCode=" + pCardType);
                System.Data.DataTable DT = DB.Query_DataTable();
                if (DT.Rows.Count == 1)
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DT.Rows[0]);
                    return true;
                }
                else
                    return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ShowDialog(int pCode)
        {
            JCardsTypeForm form = new JCardsTypeForm(pCode);
            form.ShowDialog();
        }
        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "CardsTypes";
            Node.MouseClickAction = new JAction("CardsTypes", "SmartCard.JCardsTypes.ListView");
            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "JCardsType");
            JAction DeleteItem = new JAction("Delete", "SmartCard.JCardsType.Delete", null, new object[] { (int)pRow["Code"] });
            JAction editAction = new JAction("Edit...", "SmartCard.JCards.ShowDialog", new object[] { (int)pRow["Code"] }, null);
            Node.MouseDBClickAction = new JAction("EditProperties...", "SmartCard.JCardsType.ShowDialog", new object[] { (int)pRow["Code"] }, null);
            JAction NewItem = new JAction("New...", "SmartCard.JCardsType.ShowDialog", new object[] { 0 }, null);
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(Node.MouseDBClickAction);
            Node.Popup.Insert(NewItem);

            return Node;
        }
    }
    public class JCardsTypes : JSystem
    {
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase Db = JGlobal.MainFrame.GetDBO();
            string Where = " WHERE 1 = 1 ";
            try
            {
                if (pCode != 0)
                    Where = Where + "  And Code=" + pCode;
                Db.setQuery(@" SELECT *  From CardsType    " + Where);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("JCardsTypes", "SmartCard.JCardsType.GetNode");
            //Nodes.hidColumns = "Status";
            Nodes.DataTable = GetDataTable(0);

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JCardsTypes", "SmartCard.JCardsType.ShowDialog", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;
            Nodes.AddToolbar(Tn);
            Nodes.GlobalMenuActions.Insert(new JAction("new...", "SmartCard.JCardsType.ShowDialog", new object[] { 0 }, null));
        }

        public JNode[] TreeView()
        {
            return null;
        }
    }

}
