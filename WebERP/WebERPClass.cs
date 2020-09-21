using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebERP
{
    public class WebERPClass
    {
        public static object RunAction(ClassLibrary.JAction action)
        {
            return action.run();
        }
    }
}