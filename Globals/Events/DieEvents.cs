using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Globals
{
    public class JDieEvents
    {
        public bool BeforeDie()
        {
            return true;
        }

        public bool AfterDie(JDataBase db)
        {
            //Legal.JAdvocacy tmp = new Legal.JAdvocacy();
            //tmp.UpdateDiePerson(1, db);

            return true;
        }
    }
}
