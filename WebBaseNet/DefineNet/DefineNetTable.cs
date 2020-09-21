using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebBaseNet.BaseNet
{
    public class JDefineNetTable : ClassLibrary.JTable
    {
        public String DefineName;
        public int DefineType;
        public int DefineValue;
        public DateTime InsertDate;
        public int GroupCode;
        public int PlaceCode;
        public JDefineNetTable()
            : base("AUTNetDefine")
        {
        }

        public override int Insert()
        {
            InsertDate = DateTime.Now;
            return base.Insert();
        }
    }
}