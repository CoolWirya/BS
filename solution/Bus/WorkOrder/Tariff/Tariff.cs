using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace BusManagment.WorkOrder
{
    public class JTariff : JSystem
    {
        public int Code { get; set; }
        public int LineCode { get; set; }
        public int BusCode { get; set; }
        public int DriverCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ShiftCode { get; set; }
        public JTariff()
        {
        }
        public JTariff(int pCode)
        {
            if (pCode > 0)
            {
                this.GetData(pCode);
            }
        }
        public int Insert(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Insert"))
            //    return 0;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            Code = AT.Insert();
            if (Code > 0 && !isWeb)
                Nodes.DataTable.Merge(JTariffs.GetDataTable(Code));
            return Code;
        }

        public bool Update(bool isWeb = false)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Update"))
            //    return false;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            if (AT.Update())
            {
                if (!isWeb)
                    Nodes.Refreshdata(Nodes.CurrentNode, JTariffs.GetDataTable(Code).Rows[0]);
                return true;
            }
            else
                return false;
        }

        public bool Delete()
        {
            if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariff.Delete"))
                return false;
            TariffTable AT = new TariffTable();
            AT.SetValueProperty(this);
            if (JMessages.Question("آیا میخواهید حکم انتخاب شده حذف شود؟", "") == System.Windows.Forms.DialogResult.Yes)
            {
                if (AT.Delete())
                {
                    Nodes.Delete(Nodes.CurrentNode);
                    return true;
                }
                else return false;
            }
            return false;
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTTariff where code=" + pCode.ToString());
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
            Node.Name = "WorkOrder";
            Node.MouseClickAction = new JAction("WorkOrder", "BusManagment.WorkOrder.JTariffs.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "BusManagment.WorkOrder.JTariff");
            Node.MouseDBClickAction = new JAction("EditFleet", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "BusManagment.WorkOrder.JTariff.Delete", null, new object[] { (int)pRow["Code"] });
            JAction NewItem = new JAction("New...", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "BusManagment.WorkOrder.JTariffForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction VacationItem = new JAction("RegisterVacation...", "BusManagment.WorkOrder.JVacationForm.ShowDialog", null, new object[] { 0,Convert.ToInt32(pRow["DriverCode"])});
            Node.Popup.Insert(VacationItem);
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            return Node;
        }
    }

    public class JTariffs : JSystem
    {
        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Tariff", "BusManagment.WorkOrder.JTariff.GetNode");
            JAction ActInsertAutombile = new JAction("Insert", "BusManagment.WorkOrder.JTariffForm.ShowDialog");
            JToolbarNode InsertAutombile = new JToolbarNode();
            InsertAutombile.Click = ActInsertAutombile;
            InsertAutombile.Icon = JImageIndex.Add;
            JSystem.Nodes.AddToolbar(InsertAutombile); 
        }

        public ClassLibrary.JNode[] TreeView()
        {
            JNode[] Node = new JNode[3];
            Node[0] = WorkOrder.JShift.GetTreeNode();
            Node[1] = WorkOrder.JTariff.GetTreeNode();
            Node[2] = WorkOrder.JAUTVacation.GetTreeNode();

            return Node;
        } 

        public static string GetWebQuery()
        {
            return @"Select 
	            AUTTariff.Code, clsAllPerson.Name DriverName, AUTLine.LineNumber , AUTBus .BUSNumber , AUTShift .Title Shift
	            , (Select Fa_Date From StaticDates Where En_Date = AUTTariff.StartDate)StartDate 
	            , (Select Fa_Date From StaticDates Where En_Date = AUTTariff.EndDate)EndDate 
             from AUTTariff 
	            inner join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	            inner join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	            inner join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	            inner join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode  ";
        }

        public static DataTable GetDataTable(int pCode = 0, int pShiftCode = 0)
        {
            //if (!JPermission.CheckPermission("BusManagment.WorkOrder.JTariffs.GetDataTable"))
            //    return null;
            JDataBase DB = new JDataBase();
            try
            {
                string query = @"Select 
	            AUTTariff.Code ,  AUTTariff.DriverCode , clsAllPerson.Name DriverName, AUTLine.LineNumber , AUTBus .BUSNumber , AUTShift .Title Shift
	            , (Select Fa_Date From StaticDates Where En_Date = AUTTariff.StartDate)StartDate 
	            , (Select Fa_Date From StaticDates Where En_Date = AUTTariff.EndDate)EndDate 
             from AUTTariff 
	            inner join clsAllPerson on  AUTTariff.DriverCode = clsAllPerson.Code 
	            inner join AUTLine  on  AUTLine.Code  = AUTTariff.LineCode 
	            inner join AUTBus   on  AUTBus.Code  = AUTTariff.BusCode 
	            inner join AUTShift    on  AUTShift.Code  = AUTTariff.ShiftCode WHERE  1=1 ";
                if (pCode > 0)
                    query += " AND AUTTariff.Code = " + pCode;
                if (pShiftCode > 0)
                    query += " AND AUTTariff.ShiftCode = " + pShiftCode;
                DB.setQuery(query);
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
    }
}


