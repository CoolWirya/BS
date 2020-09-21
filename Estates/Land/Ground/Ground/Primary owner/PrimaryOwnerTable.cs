using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Estates
{
    class JPrimaryOwnerTable :JTable
    {
        public JPrimaryOwnerTable()
            : base(JTableNamesEstate.PrimaryOwnerGround)
        {
        }

        #region Field

        /// <summary>
        /// کدزمین
        /// </summary>
        public int CodeGround; 
        /// <summary>
        /// کدمالک اولیه
        /// </summary>
        public int PCode; 
        /// <summary>
        /// میزان سهم شخص از این زمین
        /// </summary>
        public float Share;
        #endregion


    }

    public enum JPrimaryOwnerField
    {
        Code,
        CodeGround, 
        PCode,
        Share
    }
}
