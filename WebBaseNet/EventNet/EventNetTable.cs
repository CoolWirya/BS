using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace WebBaseNet.EventNet
{
    public class JEventNetTable : ClassLibrary.JTable
    {

        public DateTime DateEvent;
        public int DefineCode;
        public string Descs;
        public DateTime StartTime;
        public DateTime EndTime;
        public int BusCode;
        public int PlaceCode;
        public JEventNetTable()
            : base("AUTNetEvent")
        {
        }

        public override int Insert()
        {
            DateEvent = DateTime.Now;
            return base.Insert();
        }
    }
}