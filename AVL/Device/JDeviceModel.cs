using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Device
{
    public class JDeviceModel:ClassLibrary.JSystem
    {
        public int RegDeviceCode { get; set; }
        public int Code { get; set; }
        public int Year { get; set; }
        public string Company { get; set; }
        public string Model { get; set; }
        public float UnitPrice { get; set; }

        public int Speed { get; set; }
        public int Insert(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Device.JDeviceModel.Insert"))
                return 0;
            JDeviceModelTable AT = new JDeviceModelTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();


            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save("AVL.Device.JDeviceModel", Code, 0, 0, 0, "ثبت مدل دستگاه", "", 0);
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JDeviceModels.GetDataTable(Code));
            return Code;
        }


        public bool Delete(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Device.JDeviceModel.Delete"))
                return false;
            JDeviceModelTable AT = new JDeviceModelTable();
            AT.SetValueProperty(this);
            if (AT.Delete())
            {
                if (!isWeb)
                    Nodes.Delete(Nodes.CurrentNode);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.Device.JDeviceModel", AT.Code, 0, 0, 0, "حذف مدل دستگاه", "", 0);
                return true;
            }
            else return false;
        }
        public bool Update(bool isWeb = false)
        {
            if (!ClassLibrary.JPermission.CheckPermission("AVL.Device.JDeviceModel.Update"))
                return false;
            JDeviceModelTable AT = new JDeviceModelTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JDeviceModels.GetDataTable(Code).Rows[0]);
                ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
                jHistory.Save("AVL.Device.JDeviceModel", AT.Code, 0, 0, 0, "ویرایش مدل دستگاه", "", 0);
                return true;
            }
            else
                return false;
        }

        public bool GetData(string Code)
        {
            ClassLibrary.JDataBase DB = new ClassLibrary.JDataBase();
            try
            {
                DB.setQuery("select top 1 * from AVLDeviceModel where Code=" + Code);
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }


        public string GetPersonWindow(string company, string model, string year,string code)
        {
            DeviceModelSeason devicemodel = new DeviceModelSeason("DeviceModelSearch");
            devicemodel.DeviceModelCompany = company;
            devicemodel.DeviceModelModel = model;
            devicemodel.DeviceModelYear = year;
            devicemodel.DeviceModelCode = code;
            devicemodel.title = ClassLibrary.JLanguages._Farsi("DeviceModelSearch");
            devicemodel.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("DeviceModelSearch", "~/WebAVL/Forms/DeviceModelList.ascx", "DeviceSearch", null, WebClassLibrary.WindowTarget.NewWindow, true, true, false, 500, 400,true);
        }


        public string getObjectList(string code, string label)
        {
            AVL.RegisterDevice.JDeviceObjectSeason devicemodel = new AVL.RegisterDevice.JDeviceObjectSeason("ObjectListSearchItem");
            devicemodel.ObjectListCode = code;
            devicemodel.ObjectListLabel = label;
            devicemodel.title = ClassLibrary.JLanguages._Farsi("ObjectListSearchItem");
            devicemodel.SessionSave();

            return WebClassLibrary.JWebManager.LoadClientControl("ObjectListSearchItem", "~/WebAVL/Forms/JObjectListItemList.ascx", "ObjectListItemSearch", null, WebClassLibrary.WindowTarget.NewWindow, true,true, false, 500, 400,true);
        }
    
    }
}
