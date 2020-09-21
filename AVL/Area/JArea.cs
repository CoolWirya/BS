using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Area
{
    public class JArea:ClassLibrary.JSystem
    {
        public int code { get; set; }
        public int personCode { get; set; }
        /// <summary>
        /// List of objectlist codes seprated by ,
        /// </summary>
        public string ObjectsCodes { get; set; }
        public string Points { get; set; }
        public bool IsGeofence { get; set; }
        public string Name { get; set; }
        public bool isCircle { get; set; }
        public decimal radius { get; set; }
        public int clientAreaCode { get; set; }
        public int deviceCode { get; set; }

        public JArea()
        {

        }
        public JArea(string code,string personCode)
        {
            GetData(code,personCode);
            if (string.IsNullOrEmpty(this.Points))
                this.Points = "";
            if (string.IsNullOrEmpty(this.ObjectsCodes))
                this.ObjectsCodes = "";
        }
        public bool Update()
        {
            JAreaTable at = new JAreaTable();
            at.SetValueProperty(this);
            return at.Update();
        }
        public bool Delete()
        {
            JAreaTable at = new JAreaTable();
            at.SetValueProperty(this);
            return at.Delete();
        }
        public int Insert()
        {
            JAreaTable at = new JAreaTable();
            at.SetValueProperty(this);
            return at.Insert();
        }
        public bool GetData(string code,string pCode)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM [AVLArea] WHERE [code] = " + code + " AND [personCode]=" + pCode);
                if(code=="0")
                    db.setQuery("SELECT * FROM [AVLArea] WHERE  [personCode]=" + pCode);
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool GetData(string deviceCode,int personcode,string name)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT top 1 * FROM [AVLArea] WHERE [deviceCode]=" + deviceCode+ " and personCode="+personcode+ " and [Name]=N'"+name+"'");
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        /// <summary>
        /// If isGeofence was FALSE, it will return all the lines
        /// If isGeofence was TRUE, it will return all the geofence areas
        /// </summary>
        /// <param name="IsGeofence"></param>
        /// <returns></returns>
        public bool GetAreas(bool IsGeofence=false)
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("SELECT * FROM [AVLArea] WHERE [IsGeofence] = '" + IsGeofence + "'");
                if (db.Query_DataReader() && db.DataReader.Read())
                {
                    ClassLibrary.JTable.SetToClassProperty(this, db.DataReader);
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }
        public bool Remove()
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery("DELETE FROM [AVLArea] WHERE [code] = " +this.code+" AND personCode="+this.personCode);
                if (db.Query_Execute()>0)
                {
                    return true;
                }
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static List<AVL.Controls.Map.Point> ExtractPoints(string data)
        {
            List<AVL.Controls.Map.Point> points = new List<AVL.Controls.Map.Point>();
            string[] parts;
            foreach (string p in data.Split(new char[]{'|'},  StringSplitOptions.RemoveEmptyEntries))
            {
                parts=p.Split(',');
                points.Add(new Controls.Map.Point()
                {
                    Latitude = double.Parse(parts[0]),
                    Longitude = double.Parse(parts[1])
                });
            }
            return points;
        }

    }
}
