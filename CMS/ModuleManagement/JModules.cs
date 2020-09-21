using System;
using CMSClassLibrary;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CMS.ModuleManagement
{
    public class JModules
    {
         CMSClassLibrary.Module.JModule NewModule;
        public int Code { get; set; }
        public string Name { get; set; }
        public bool State { get; set; }
        public string Parameters { get; set; }
        public int Site { get; set; }
        public string Position { get; set; }
        public int PosOrder { get; set; }
        public int ExtCode { get; set; }
        public bool Home { get; set; }

        public bool Insert()
        {
            NewModule = new CMSClassLibrary.Module.JModule();
            NewModule.Name = Name;
            NewModule.State = State;
            NewModule.Parameters = Parameters;
            NewModule.Site = Site;
            NewModule.Position = Position;
            NewModule.PosOrder = PosOrder;
            NewModule.ExtCode = ExtCode;
            NewModule.Home = Home;
            if (Code != 0)
            {
                NewModule.Code = Code;
                return NewModule.Update();
            }
            else
                return NewModule.Insert() > 0;
        }

        

    }
}