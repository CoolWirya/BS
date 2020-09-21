using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JDistraintAssetShareTable:JTable
    {
        public JDistraintAssetShareTable()
            : base(JTableNamesLegal.DistraintAssetShare)
        {
        }
       
        /// <summary>
        /// کددارایی جزء
        /// </summary>
        public int AssetShareCode;
        /// <summary>
        /// کدجدول اصلی توقیف اموال
        /// </summary>
        public int Distraint;
        /// <summary>
        /// تعداد سهم توقیف شده
        /// </summary>
        public float Distrainted;
        /// <summary>
        /// کد دارایی
        /// </summary>
        public int ACode;
  
    }
    enum JDistraintAssetShareTableEnum
    {
        Code,
         /// <summary>
        /// کددارایی جزء
        /// </summary>
        AssetShareCode,
        /// <summary>
        /// کدجدول اصلی توقیف اموال
        /// </summary>
        Distraint,
    }
}
