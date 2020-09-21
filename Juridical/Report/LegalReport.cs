using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ArchivedDocuments;

namespace Legal
{
    public class JLegalReport
    {
        #region Nodes

        public void ShowDialog()
        {
            JReportForm PE = new JReportForm();
                PE.State = JFormState.Insert;
                PE.ShowDialog();
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow[LegPetition.Code.ToString()], "Legal.JLegalReport");
            node.Icone = JImageIndex.testimonial.GetHashCode();
            node.Name = "گزارشات";//pRow[LegPetition.Number.ToString()].ToString();

            node.Hint = ""; //JLanguages._Text("Date:") + " " + pRow[LegPetition.Date.ToString()];// + "\n" +
            //JLanguages._Text("Type:") + " " + pRow[LegAdvocacy.Type.ToString()] + "\n" +
            //       JLanguages._Text("Description:") + " " + pRow[LegPetition.Description.ToString()] + "\n" +
            //      JLanguages._Text("Confirm:") + " " + str;
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JLegalReport.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JLegalReport.ShowDialog", null, null);

            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }

    public class JLegalReports : JSystem
    {
        public JLegalReports[] Items = new JLegalReports[0];
        //  public String OrderName;
        public JLegalReports()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "select * from " + JTableNamesLegal.Petition;
                if (pCode != 0)
                    WHERE = WHERE + " WHERE Code = " + pCode;
                DB.setQuery(WHERE);
                return DB.Query_DataTable();
                //DB.setQuery(WHERE);
                //DB.Query_DataSet();
                //System.Data.DataTable tblResult = DB.DataSet.Tables[0];
                //return tblResult;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetLegalReport", "Legal.JLegalReport.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JLegalReport.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);
        }
    }
}
