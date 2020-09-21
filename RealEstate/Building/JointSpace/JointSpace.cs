using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JJointSpace : JRealEstate
    {
        #region Properties
                
        /// <summary>
        /// شماره اجاره
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// شماره محيط
        /// </summary>
        public int CodeEnviroment { get; set; }
        /// <summary>
        /// متراژ
        /// </summary>
        public int Area { get; set; }
        /// <summary>
        /// شماره مكان
        /// </summary>
        public int CodeSpace { get; set; }
        /// <summary>
        /// مبلغ متراژ
        /// </summary>
        public decimal moneyArea { get; set; }
        /// <summary>
        /// مبلغ شارژ
        /// </summary>
        public decimal ChargeAmount { get; set; }
        /// <summary>
        /// موضوع قرارداد
        /// </summary>
        public string Topics { get; set; }
        /// <summary>
        /// عنوان شغلي
        /// </summary>
        public int JobTitle { get; set; }
        /// <summary>
        /// موقعيت محيطي
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// كاربري
        /// </summary>
        public int Register { get; set; }

        #endregion

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
                if (JPermission.CheckPermission("RealEstate.JJointSpace.Insert"))
                {
                    JJointSpaceTable JST = new JJointSpaceTable();
                    JST.SetValueProperty(this);
                    Code = JST.Insert(pDB);
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
            if (JPermission.CheckPermission("RealEstate.JJointSpace.Update"))
            {
                JJointSpaceTable JST = new JJointSpaceTable();
                JST.SetValueProperty(this);
                return JST.Update();
            }
            else
                return false;
        }

        public bool Delete(int pCode)
        {
            if (JPermission.CheckPermission("RealEstate.JJointSpace.Delete"))
            {
                Code = pCode;
                JJointSpaceTable JST = new JJointSpaceTable();
                JST.SetValueProperty(this);
                if (JST.Delete())
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
                DB.setQuery("SELECT * FROM ReJointSpaceTable WHERE Code=" + pCode.ToString());
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

        public void ShowForm(int pCode)
        {
            if (pCode == 0)
            {
                JJointSpaceForm JF = new JJointSpaceForm(this);
                JF.State = JFormState.Insert;
                JF.ShowDialog();
            }
            else
            {
                GetData(pCode);
                JJointSpaceForm JF = new JJointSpaceForm(this);
                JF.State = JFormState.Update;
                JF.ShowDialog();
            }
        }
        public JNode GetNode(System.Data.DataRow pDR)
        {

            JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
            Node.Name = pDR["Register"].ToString();
            Node.MouseDBClickAction = new JAction("ShowDataJointSpace", "RealEstate.Building.JointSpace.JJointSpace.ShowForm", new object[] { (int)pDR["Code"] }, null);

            JAction DeleteAct = new JAction("Delete", "RealEstate.Building.JointSpace.JJointSpace.Delete", new object[] { (int)pDR["Code"] }, null);
            Node.Popup.Insert(DeleteAct);


            //Node.Hint = "name is " + (char)13 + Node.Name;
            return Node;
        }

    }

    public class JJointSpaces : JRealEstate
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
                string pWhere = " Where 1=1 ";
                if (pCode > 0)                
                    pWhere = pWhere + " And Code=" + pCode.ToString();                
                DB.setQuery("SELECT * FROM ReJointSpaceTable " + pWhere + " And " +
                          JPermission.getObjectSql("RealEstate.JJointSpaces.GetDataTable", "ReJointSpaceTable.Code"));
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
            Nodes.ObjectBase = new JAction("GetNode", "RealEstate.Building.JointSpace.JJointSpace.GetNode");
            Nodes.DataTable = GetDataTable();

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("JointSpace", "RealEstate.Building.JointSpace.JJointSpace.ShowForm", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }
}
