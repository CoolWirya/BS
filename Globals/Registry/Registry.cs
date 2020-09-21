using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Win32;

namespace Globals
{
    public class JRegistry
    {
        public static object Read(string pObject)
        {
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Sepad\\Interface", false);
                string reg = pObject;
                if (pObject.Length > 255)
                    reg = pObject.Substring(pObject.Length - 255); 
                if (key != null)
                    return key.GetValue(reg);
                else
                    return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public static bool Write(string pObject,object pValue)
        {
            #region SaveRegistry
            try
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software\\Sepad\\Interface", RegistryKeyPermissionCheck.ReadWriteSubTree, System.Security.AccessControl.RegistryRights.FullControl);
                string reg = pObject;
                if (pObject.Length > 255)
                    reg = pObject.Substring(pObject.Length - 255);
                if (key == null)
                    key = Registry.CurrentUser.CreateSubKey("Software\\Sepad\\Interface");
                //if (key.GetValue(pObject) != null)
                key.SetValue(reg , pValue, RegistryValueKind.String);

            #endregion

                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
