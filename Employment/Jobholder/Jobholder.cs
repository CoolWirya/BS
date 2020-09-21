using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    /// <summary>
    /// کارمند
    /// </summary>
    public class JJobholder: JEmployment
    {
        int Code;
        ClassLibrary.JPerson Person;
        JEPost Posts;
    }

    public class JJobholderUser : JEmployment
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pPCode">کد شخص</param>
        public JJobholderUser(int pPCode)
        {
        }
    }
    /// <summary>
    /// کارمندان
    /// </summary>
    public class JJobholders : JEmployment
    {
        JJobholder[] Items;
    }
}
