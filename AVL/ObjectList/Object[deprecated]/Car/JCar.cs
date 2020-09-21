using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.ObjectList.Object.Car
{
    public class JCar //:AVL.INodeMenu
    {
        /*
         * Code
         * ObjectCode
         * LineCode
         * 
         * 
         * 
         */

        public const string _ConstClassName = "AVL.ObjectList.Object.Car.JCar";
        public static string GridShow()
        {
            WebControllers.MainControls.Grid.JGridView jGridView = new WebControllers.MainControls.Grid.JGridView(_ConstClassName.Replace(".", "_"));
            jGridView.ClassName = _ConstClassName.Replace(".", "_") + "_GridShow";
            //jGridView.ContextMenuItems = new List<WebControllers.MainControls.Grid.JContextMenuItem>();
          //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "New", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null) });
          //  jGridView.ContextMenuItems.Add(new WebControllers.MainControls.Grid.JContextMenuItem() { Text = "Edit", Action = new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null) });

            jGridView.SQL =
                @"SELECT * FROM AVLCar"; 

            jGridView.Title = "اتومبیل سواری";
            jGridView.Toolbar = new WebControllers.MainControls.ToolBar.JToolBar();
         //   jGridView.Toolbar.AddButton("New", "New", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._NewDevice", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Add));
         //   jGridView.Toolbar.AddButton("Edit", "Edit", new WebClassLibrary.JActionsInfo("Click", WebClassLibrary.JDomains.JActionEvents.MouseClick, _ConstClassName + "._DeviceUpdate", null, null), WebClassLibrary.JDomains.Images.GetFullPath(WebClassLibrary.JDomains.Images.ControlImages.Toolbar_Edit));
            jGridView.Actions = new List<WebClassLibrary.JActionsInfo>();

            return WebClassLibrary.JWebManager.GenerateClientWindow(jGridView.GenerateWindow(true, false, false), true);
        }


        public static string GetIcon()
        {
            return "/WebAVL/Icons/bus.png";
        }
        public static string GetHtmlString()
        {
            // here we can put some details as car is in own line (AVL.Controls.Map.Line.IsInTheLine).
            // Or geofence details with (AVL.Controls.Map.Line.IsInTheArea).
            return "<strong> Returned From JCar </strong>";
        }
    }
}
