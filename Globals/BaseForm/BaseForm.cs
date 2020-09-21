using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using ClassLibrary;

namespace Globals
{
    
    /// <summary>
    /// تمام فرمهای سیستم از این فرم مشتق میگردد
    /// </summary>
    public partial class JBaseForm : ClassLibrary.JBaseForm
    {
        public JBaseForm()
        {
            InitializeComponent();
        }

        private void JBaseForm_Load(object sender, EventArgs e)
        {
            if (this.DesignMode == false)
            {
                InitController(this);
            }
        }

        public void InitController(object sender)
        {
            
            Type type = sender.GetType();
            //-----------------Permission-----------------
            string Name;
            string Parent;
            int Status;
            //DataTable dtControl = new DataTable();
            ClassLibrary.JPermissionControl tmpJPermissionControls = new ClassLibrary.JPermissionControl();
            tmpJPermissionControls.Type = 2;
            tmpJPermissionControls.Class_Name = type.FullName;
            tmpJPermissionControls.Object_Name = type.Name;
            Parent=tmpJPermissionControls.Class_Name;
            //dtControl = tmpJPermissionControls.GetData();
            //if (tmpJPermissionControls.CheckPermission(JMainFrame.CurrentPostCode))
            //{
             FieldInfo[] Finfo = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.CreateInstance);
             for (int count = 0; count < Finfo.Length; count++)
             {
                try
                {
                    object Obj = Finfo[count].GetValue(sender);
                    ////-----------------------------------       
                    if (Obj is Control)
                    {
                        tmpJPermissionControls.Class_Name = type.Namespace + "." + this.Name + "." + type.Name + "." + (Obj as Control).Name;
                        tmpJPermissionControls.Object_Name = (Obj as Control).Name;
                        //if (!tmpJPermissionControls.CheckPermission(JMainFrame.CurrentUserCode))
                        //  (Obj as Control).Enabled = false;

                        if (Obj is Button)
                        {
                            tmpJPermissionControls.Class_Name = type.Namespace + "." + this.Name;
                            tmpJPermissionControls.Object_Name = (Obj as Control).Name;
                            //if (!tmpJPermissionControls.CheckPermission(JMainFrame.CurrentPostCode))

                            //if(!tmpJPermissionControls.CheckPermissionByDataTable(dtControl))  
                            //(Obj as Control).Enabled = false; 
                        }
                        ////-----------------------------------       
                        Control Cont = (Obj as Control);
                        if (Cont != null)
                            Cont.Text = JLanguages._Text(Cont.Text);
                    }

                }
                catch (Exception ex)
                {
                    JSystem.Except.AddException(ex);
                }
            }
          //} //Permission
        }

    }
}
