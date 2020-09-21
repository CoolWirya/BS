using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
 using ClassLibrary;
namespace AUTOMOBILE.Device
{
    public enum JDeviceType
    {
        Console = 1,
        Reader = 2,
    }

    public class JDevice
    {
        public int Code { get; set; }
        public int Type { get; set; }
        public string ID { get; set; }
        public string Tel { get; set; }
        public string MacAddress { get; set; }
        public string IMEI { get; set; }
        public string Barcode { get; set; }
        public string Model { get; set; }

        public int Insert()
        {
            DeviceTable AT = new DeviceTable();
            AT.SetValueProperty(this);
           
                Code = AT.Insert();
                return Code;
        }

        public bool Update()
        {
            DeviceTable AT = new DeviceTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            //if (BusManagment.JBusInstallAndUnistallDevise.FindByDeviceCode(Code) || BusManagment.JBusDevise.FindByDeviceCode(Code))
                //return false;
            DeviceTable AT = new DeviceTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTDevice where code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static JNode GetTreeNode()
        {
            JNode Node = new JNode(0, 0);
            Node.Name = "Device";
            Node.MouseClickAction = new JAction("Device", "AUTOMOBILE.Device.JDevices.ListView");
            
            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"],"AUTOMOBILE.Device.JDevice");
            Node.MouseDBClickAction = new JAction("EditDevice", "AUTOMOBILE.Device.DeviceForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "AUTOMOBILE.Device.DeviceForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "AUTOMOBILE.Device.DeviceForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "AUTOMOBILE.Device.DeviceForm.Delete", null, new object[] { (int)pRow["Code"] });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            
            return Node;

            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }
    }


 /// <summary>
 /// 
 /// </summary>
    public class JDevices
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Device", "AUTOMOBILE.Device.JDevice.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "AUTOMOBILE.Device.DeviceForm.ShowDialog");

            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;

            JSystem.Nodes.AddToolbar(InsertAutombile);
        }

        public JNode[] TreeView()
        {
            return null;
        }

        public DataTable GetDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"SELECT Code , ID , Tel , MacAddress , IMEI , CASE [Type] WHEN  1 THEN  'Consol' WHEN  2 THEN 'Reader' END AS 'Type' FROM AUTDevice ");
                return DB.Query_DataTable();
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
        public DataTable GetData()
        {
            return null;
        }

        public static string GetWebQuery()
        {
            return @"SELECT Code , ID , Tel , MacAddress , IMEI , CASE [Type] WHEN  1 THEN  'Consol' WHEN  2 THEN 'Reader' END AS 'Type' FROM AUTDevice ";
        }

    }

}
