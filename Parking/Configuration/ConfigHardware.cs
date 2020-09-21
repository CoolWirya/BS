using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Parking
{
    public class JConfigHardware : JParking
    {
        #region Property

            public int Code { get; set; }
            /// <summary>
            /// مجتمع / بازار
            /// </summary>
            public int complex { get; set; }
            /// <summary>
            /// نوع دستگاه
            /// </summary>
            public int TypeDevice { get; set; }
            /// <summary>
            /// مدل
            /// </summary>
            public int ModelDevice { get; set; }
            /// <summary>
            /// پروتکل ارتباطی
            /// </summary>
            public int CommunicationProtocol { get; set; }
            /// <summary>
            /// شماره پورت
            /// </summary>
            public int NoProtocol { get; set; }
            /// <summary>
            /// نوع DVR
            /// </summary>
            public int TypeDvr { get; set; }
            /// <summary>
            /// مسیر ذخیره سازی عکس
            /// </summary>
            public string AddressSavePic { get; set; }

        #endregion
     
        #region method

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
                    if (JPermission.CheckPermission("Parking.JConfigHardware.Insert"))
                    {
                        JConfigHardwareTable JCHT = new JConfigHardwareTable();
                        JCHT.SetValueProperty(this);
                        Code = JCHT.Insert(pDB);
                        if (Code > 0)
                        {
                            Nodes.DataTable.Merge(JConfigHardwares.GetDataTable(Code));
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
                if (JPermission.CheckPermission("Parking.JConfigHardware.Update"))
                {
                    JConfigHardwareTable JCHT = new JConfigHardwareTable();
                    JCHT.SetValueProperty(this);
                    return JCHT.Update();
                }
                else
                    return false;
            }

            public bool Delete(int pCode)
            {
                if (JPermission.CheckPermission("Parking.JConfigHardware.Delete"))
                {
                    Code = pCode;
                    JConfigHardwareTable JCHT = new JConfigHardwareTable();
                    JCHT.SetValueProperty(this);
                    if (JCHT.Delete())
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
                    DB.setQuery("SELECT * FROM " + JTableNamesParking.ParkingSetting + " WHERE Code=" + pCode.ToString());
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
                    JConfigHardwareForm JF = new JConfigHardwareForm(this);
                    JF.State = JFormState.Insert;
                    JF.ShowDialog();
                }
                else
                {
                    GetData(pCode);
                    JConfigHardwareForm JF = new JConfigHardwareForm(this);
                    JF.State = JFormState.Update;
                    JF.ShowDialog();
                }
            }

            public JNode GetNode(System.Data.DataRow pDR)
            {

                JNode Node = new JNode((int)pDR["Code"], this.GetType().FullName);
                Node.Name = pDR["TypeDevice"].ToString();
                Node.MouseDBClickAction = new JAction("ShowDataParking", "Parking.JConfigHardware.ShowForm", new object[] { (int)pDR["Code"] }, null);

                JAction DeleteAct = new JAction("Delete", "Parking.JConfigHardware.Delete", new object[] { (int)pDR["Code"] }, null);
                Node.Popup.Insert(DeleteAct);
                Node.Icone = (int)JImageIndex.Default;

                Node.Hint = "تنظیمات دستگاه " + (char)13 + Node.Name;
                return Node;
            }


        #endregion


    }

    public class JConfigHardwares : JParking
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
                DB.setQuery("SELECT * FROM " + JTableNamesParking.ParkingSetting + pWhere + " And " +
                   JPermission.getObjectSql("Parking.JConfigHardware.GetDataTable", JTableNamesParking.ParkingSetting+".Code"));
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
            Nodes.ObjectBase = new JAction("GetNode", "Parking.JConfigHardware.GetNode");
            Nodes.DataTable = GetDataTable();

            JToolbarNode Tn = new JToolbarNode();
            Tn.Click = new JAction("ConfigHardware", "Parking.JConfigHardware.ShowForm", new object[] { 0 }, null);
            Tn.Icon = JImageIndex.Add;

            Nodes.AddToolbar(Tn);
        }

    }
   
}
