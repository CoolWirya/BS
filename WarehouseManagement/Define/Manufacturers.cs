using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace WarehouseManagement
{
    /// <summary>
    /// سازنده ها
    /// </summary>
    public class JManufacturer : JSubBaseDefine
    {
        public JManufacturer()
            : base(Define.JDefine.Manufacturers)
        {
        }

    }

    public class JManufacturers : JSubBaseDefines
    {
        public JManufacturers()
            : base(Define.JDefine.Manufacturers)
        {
        }

    }
}
