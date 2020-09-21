using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Principal;
using System.DirectoryServices;
using System.Data;

namespace ClassLibrary
{
    public class GetInfoActiveDirectory
    {
       
        public  string GetCurrentUserName()
        {
            return  WindowsIdentity.GetCurrent().Name;
            
        }
    
        public System.Collections.Generic.SortedList<string,string> GetUsersInGroup()
        {
            System.Collections.Generic.SortedList<string, string> groupMemebers = new System.Collections.Generic.SortedList<string, string>();

            JConfig Conf = new JConfig();
            if (Conf.LDAPServer==null || Conf.LDAPServer.Length == 0)
                return groupMemebers;

            string sam = "";
            string fname = "";
            string lname = "";
            string active = "";


            DirectoryEntry de = new DirectoryEntry(Conf.LDAPServer);
            DirectorySearcher ds = new DirectorySearcher(de);
            ds.Filter = "(&(objectClass=user))";
            ds.PropertiesToLoad.Add("givenname");
            ds.PropertiesToLoad.Add("samaccountname");
            ds.PropertiesToLoad.Add("sn");
            ds.PropertiesToLoad.Add("useraccountcontrol");
            foreach (SearchResult sr in ds.FindAll())
            {
                try
                {
                    try
                    {
                        sam = sr.Properties["samaccountname"][0].ToString();
                        fname = sr.Properties["givenname"][0].ToString();
                        lname = sr.Properties["sn"][0].ToString();
                        active = sr.Properties["useraccountcontrol"][0].ToString();
                    }
                    catch
                    {
                    }
                }
                catch (Exception e)
                {
                }
                if (active.ToString() != "514")
                {
                    groupMemebers.Add(sam.ToString() +"@"+ Conf.DomainName, (fname.ToString() + " " + lname.ToString()));
                }
            }
            return groupMemebers;
        }
         

    }
}
