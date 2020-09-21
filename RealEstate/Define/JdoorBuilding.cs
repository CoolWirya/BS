using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;



namespace RealEstate
{
    public class JDoorBuilding : JSubBaseDefine
    {
        public JDoorBuilding()
            : base(JRealStatesBaseDefines.DoorBuilding)
        {

        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class JDoorBuildings : JSubBaseDefines
    {
        public JDoorBuildings()
            : base(JRealStatesBaseDefines.DoorBuilding)
        {

        }

    }
}
