using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace RealEstate
{
    public class JInformationUnitBuildTable : JTable
    {
        public JInformationUnitBuildTable()
            : base(JRETableNames.InformationUnitBuild)
        {
        }
        public int UnitBuildCode;
        /// <summary>
        /// تلفن
        /// </summary>
        public string Tel;
        /// <summary>
        /// عنوان
        /// </summary>
        public int TelType;
        /// <summary>
        /// پیش فرض
        /// </summary>
        public bool DefaultValue;
    }
    enum InformationUnitBuild
    {
        UnitBuildCode,
        /// <summary>
        /// تلفن
        /// </summary>
        Tel,        
        /// <summary>
        /// عنوان
        /// </summary>
        TelType,
        /// <summary>
        /// پیش فرض
        /// </summary>
        DefaultValue,
    }
}
