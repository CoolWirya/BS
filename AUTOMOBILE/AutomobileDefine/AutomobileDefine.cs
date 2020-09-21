using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
using System.Data;

namespace AUTOMOBILE.AutomobileDefine
{


    public class JAutomobileDefine
    {
        public int Code { get; set; }
        public string Plaque { get; set; }
        public int Type { get; set; }
        public int Model { get; set; }
        public bool Active { get; set; }
        public int maker{ get; set; }
        /// <summary>
        /// Zarfiat
        /// </summary>
        public int Capacity { get; set; }

        public int IconCode { get; set; }

        #region AVL

        public const string _ConstClassName = "AUTOMOBILE.AutomobileDefine.JAutomobileDefine";
        public static string GridShow()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_GridShow";
            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
            //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "New", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null) });
            //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "Edit", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null) });

            //jGridView.SQL =
            //    @"SELECT * FROM AUTAutomobile ";
            jGridView.SQL =
               @"SELECT [Code],[ObjectCode],[Label],[Type] FROM AVLObjectList WHERE ClassName='AUTOMOBILE.AutomobileDefine.JAutomobileDefine' AND personCode=" + WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;


            jGridView.Title = "اتومبیل سواری";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
            //   jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
            //   jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }


        public static string GetIcon(string id="")
        {           
            return "/WebAVL/Icons/car.png";
        }
        public static string GetHtmlString(string id)
        {
            // here we can put some details as car is in own line (AVL.Controls.Map.Line.IsInTheLine).
            // Or geofence details with (AVL.Controls.Map.Line.IsInTheArea).
            AutomobileDefine.JAutomobileDefine a = new JAutomobileDefine();
            a.GetData(int.Parse(id));
            return string.Format("<strong>{0}</strong>",a.Plaque);
        }


        public int InsertAVLObjecList()
        {
                global::AVL.ObjectList.JObjectList ol = new global::AVL.ObjectList.JObjectList();
            try
            {
                ol.ClassName = "AUTOMOBILE.AutomobileDefine.JAutomobileDefine";
                ol.DynamicObjectCode = 0;
                ol.Label = "مدل " + this.Model;
                ol.Type = "خودرو";
                ol.ObjectCode = this.Code;
                ol.personCode = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUserCode;
                ol.RegisterDateTime = DateTime.Now;
                global::AVL.ObjectList.JObjectListTable olt = new global::AVL.ObjectList.JObjectListTable();
                olt.SetValueProperty(ol);
                ol.Code = olt.Insert();
                return ol.Code;
            }
            catch
            {
                return ol.Code;
            }
        }

        #endregion

        public bool Find(string pPalque)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("SELECT Code FROM AUTAutomobile WHERE Plaque=" + JDataBase.Quote(pPalque));
                DB.Query_DataReader();
                if (!DB.DataReader.Read())
                    return true;
                return false;
            }
            finally
            {
                DB.Dispose();
            }
        }

		public int Insert()
		{
			JAutomobileTable AT = new JAutomobileTable();
			AT.SetValueProperty(this);


            /*
             * AVL Project
            */
            if (AVL.Tools.IsAvlProject())
            {
                JAutomobileDefine au = new JAutomobileDefine();
                au.GetData(this.Plaque);
                if (au.Code < 1)
                {
                    Code = AT.Insert();
                    if (Code > 0)
                    {
                        InsertAVLObjecList();

                        return Code;
                    }
                }
                else
                    return -1;
            }
            /*		 */

			if (Find(Plaque))
			{
				Code = AT.Insert();
				return Code;
			}
			return 0;
		}

        public bool Update()
        {
            JAutomobileTable AT = new JAutomobileTable();
            AT.SetValueProperty(this);
            return AT.Update();
        }

        public bool Delete()
        {
            JAutomobileTable AT = new JAutomobileTable();
            AT.SetValueProperty(this);
            return AT.Delete();
        }

        public bool GetData(int pCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTAutomobile where code=" + pCode.ToString());
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

        public bool GetData(string plaque)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("select * from AUTAutomobile where Plaque=N'" + plaque.ToString()+"'");
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
            Node.Name = "Atumobile";
            Node.MouseClickAction = new JAction("Autombile", "AUTOMOBILE.AutomobileDefine.JAutomobileDefines.ListView");

            return Node;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "AUTOMOBILE.AutomobileDefine.JAutomobileDefine");
            Node.MouseDBClickAction = new JAction("EditAutomobile", "AUTOMOBILE.AutomobileDefine.JAutomobileForm.ShowDialog", null, new object[] { (int)pRow["Code"] });

            JAction NewItem = new JAction("New...", "AUTOMOBILE.AutomobileDefine.JAutomobileForm.ShowDialog", null, new object[] { });
            JAction EditItem = new JAction("Edit...", "AUTOMOBILE.AutomobileDefine.JAutomobileForm.ShowDialog", null, new object[] { (int)pRow["Code"] });
            JAction DeleteItem = new JAction("Delete", "AUTOMOBILE.AutomobileDefine.JAutomobileForm.Delete", null, new object[] { (int)pRow["Code"] });
            Node.Popup.Insert(DeleteItem);
            Node.Popup.Insert(EditItem);
            Node.Popup.Insert(NewItem);
            return Node;
            
            //AUTOMOBILE.Automobile.JAutomobileForm AForm = new Automobile.JAutomobileForm((int)pRow["Code"]);
            //AForm.ShowDialog();
            //return null;
        }

    }

    public class JAutomobileDefines
    {

        public void ListView()
        {
            JSystem.Nodes.DataTable = GetDataTable();
            JSystem.Nodes.ObjectBase = new JAction("Autombile", "AUTOMOBILE.AutomobileDefine.JAutomobileDefine.GetNode");

            JAction ActInsertAutombile = new JAction("Insert", "AUTOMOBILE.AutomobileDefine.JAutomobileForm.ShowDialog");
            
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
                DB.setQuery(@"
                                Select A.code , A.Plaque , D.name AS 'Type' , A.Model , A.Active , M.name AS 'Maker' , A.Capacity  from AUTAutomobile A
                                INNER JOIN subdefine D ON D.Code = A.Type
                                INNER JOIN subdefine M ON M.Code = A.maker
                             ");
                return DB.Query_DataTable();
            }
            catch(Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public static string GetWebQuery()
        {
            return @"Select A.code , A.Plaque , D.name AS 'Type' , A.Model , A.Active , M.name AS 'Maker' , A.Capacity  from AUTAutomobile A
                                INNER JOIN subdefine D ON D.Code = A.Type
                                INNER JOIN subdefine M ON M.Code = A.maker";
        }

    }
}
