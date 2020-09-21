using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using RealEstate.Building.Joint;

namespace RealEstate
{
    public class JJoint : JRealEstate
    {
        #region Property

        public int Code { get; set; }
        /// <summary>
        /// عنوان فضا
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// کد مجتمع
        /// </summary>
        public int MarketCode { get; set; }
        #endregion

        #region Method

        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                return Insert(DB);
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int Insert(JDataBase pDB)
        {
            try
            {
                if (JPermission.CheckPermission("RealEstate.JJoint.Insert"))
                {
                    JJointClassTable JCT = new JJointClassTable();
                    JCT.SetValueProperty(this);
                    Code = JCT.Insert(pDB);
                    if (Code > 0)
                    {
                        Nodes.DataTable.Merge(JJoints.GetDataTable(Code));
                    }
                    return Code;
                }
                else
                    return -1;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return 0;
            }
        }

        public bool Update()
        {
            if (JPermission.CheckPermission("RealEstate.JJoint.Update"))
            {
                JJointClassTable JCT = new JJointClassTable();
                JCT.SetValueProperty(this);
                return JCT.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("RealEstate.JJoint.Delete"))
            {
                Code = pCode;
                JJointClassTable JCT = new JJointClassTable();
                JCT.SetValueProperty(this);
                if (JCT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                return false;
            }
            else
                return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT * FROM ReJointTable WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public  void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                JJointForm JF = new JJointForm(this);
                JF.State = JFormState.Insert;
                JF.ShowDialog();
            }
            else
            {
                GetData(pCode);
                JJointForm JF = new JJointForm(this);
                JF.State = JFormState.Update;
                JF.ShowDialog();
            }
        }
        public static void ShowForms(int pCode)
        {
            
           
                JJointForm JF = new JJointForm();
                JF.State = JFormState.Insert;
                JF.ShowDialog();
           
        }

        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["Type"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataJoint", "RealEstate.JJoint.ShowForm", new object[] { (int)pDR["Code"] }, null);

            JAction DeleteAct = new JAction("Delete", "RealEstate.JJoint.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);
            Node.Icone = (int)JImageIndex.Default;

            Node.Hint = "name is " + (char)13 + Node.Name;
            return Node;
        }

        #endregion

    }

    public class JJoints : JRealEstate
    {

        public static System.Data.DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static System.Data.DataTable GetDataTable(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                string pWhere = " WHERE 1=1 ";
                if (pCode > 0)                
                    pWhere = pWhere + " And Code=" + pCode.ToString();                
                DB.setQuery("SELECT * FROM ReJointTable" + pWhere + " And " +
                   JPermission.getObjectSql("RealEstate.JJoints.GetDataTable", "ReJointTable.Code"));
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return GetDataTable();
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetNode", "RealEstate.JJoint.GetNode");
            Nodes.DataTable = GetDataTable();
           
            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("Joint", "RealEstate.JJoint.ShowForms", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;
            Nodes.AddToolbar(Tn);
        }

    }
}
