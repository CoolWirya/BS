using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    public class JPrimaryOwnerBuildTable : JTable
    {
        public JPrimaryOwnerBuildTable()
            : base(JTableNamesEstate.PrimaryOwnerBuild)
        {
        }
        /// <summary>
        /// کد اعیان
        /// </summary>
        public int BuildCode;
        /// <summary>
        /// کد مالک اولیه
        /// </summary>
        public int PCode;
        /// <summary>
        /// میزان سهم شخص از اعیان
        /// </summary>
        public float Share;
        /// <summary>
        /// کد مشارکتی دارایی
        /// </summary>
        public int AssetShareCode;
    }
    
        public enum JPrimaryOwnerBuildTableEnum
        {
        Code,
        /// <summary>
        /// کد اعیان
        /// </summary>
        BuildCode,
        /// <summary>
        /// کد مالک اولیه
        /// </summary>
        PCode,
       /// <summary>
       /// نام خانوادگی مالک اولیه
       /// </summary>
       
        fam,
            /// <summary>
            /// نام مالک اولیه
            /// </summary>
        Name,
            /// <summary>
            /// شماره شناسنامه مالک اولیه
            /// </summary>
         shsh,
        /// <summary>
        /// میزان سهم شخص از اعیان
        /// </summary>
        Share,
        /// <summary>
        /// پلاک اعیان
        /// </summary>
        Plaque,
        /// <summary>
        /// کدمشارکتی دارایی
        /// </summary>
        AssetShareCode
        

                

        }
}
