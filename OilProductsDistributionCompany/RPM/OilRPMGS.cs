using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace OilProductsDistributionCompany.RPM
{
    public class JOilRPMGS
    {
        public int Code { get; set; }
        public int Code_RPM { get; set; }
        public string GasStationCode { get; set; }
        public string StatusofGsRPM { get; set; }
        public DateTime DateIns { get; set; }
        public int PCode { get; set; }
        public string Version { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
        // public int FileCode { get; set; }

        public int Insert()
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            GH.SetValueProperty(this);
            return GH.Insert();
        }

        public bool Update()
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            GH.SetValueProperty(this);
            return GH.Update();
        }

        public bool Delete()
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            GH.SetValueProperty(this);
            return GH.Delete();
        }

        public static bool Find(int pCode)
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            return GH.Find(pCode);
        }

        public bool GetData(int pCode)
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            return GH.GetData(this, pCode);
        }


        public void Insert(string FilePath, int RPMCode )
        {
            ClassLibrary.JDataBase db = new ClassLibrary.JDataBase();
            try
            {
                OilProductsDistributionCompany.RPM.JOilRPMGS jOilRPMGS = new OilProductsDistributionCompany.RPM.JOilRPMGS();
                OilProductsDistributionCompany.Failure.JMalfunction Malfunction = new Failure.JMalfunction();
                OilProductsDistributionCompany.JSupplier jOilSupplier = new OilProductsDistributionCompany.JSupplier();
                ClassLibrary.JPerson Pr=new ClassLibrary.JPerson();


                if (db.beginTransaction("OilRPMGS"))
                {
                    foreach (DataRow dr in GetDataSourceFromFile(FilePath).Rows)
                    {
                        jOilRPMGS.Code_RPM = RPMCode;
                        jOilRPMGS.Comment = dr["Comment"].ToString();
                        jOilRPMGS.DateIns = Convert.ToDateTime(dr["InstallationDate"].ToString());
                        jOilRPMGS.GasStationCode = dr["GasStationCode"].ToString();
                        jOilRPMGS.StatusofGsRPM = dr["StatusOfGsRpm"].ToString();
                        jOilRPMGS.PCode = Convert.ToInt32(dr["Pcode"].ToString());
                        jOilRPMGS.Version = dr["Version"].ToString();
                        jOilRPMGS.Insert();

                        
                        Malfunction.DamageCode = (int)OilProductsDistributionCompany.Failure.JMalfunctiones.DamageReservedCode.Installing_RPM;
                        Malfunction.DateTimeMalfunction = DateTime.Now;
                        Malfunction.Description = "عدم نصب RPM";
                        Malfunction.GasStationCode = (int)dr["GasStationCode"];
                        Malfunction.HangerCode = 0;
                        Malfunction.HangerName = "درج اتوماتیک توسط سیستم";
                        Malfunction.IsOfficeDamage = true;
                        Malfunction.RegistrarCode = 0;
                        Malfunction.Status = Failure.JStatusMalfunction.Open;
                        Malfunction.SupplierCode = jOilSupplier.FindByGSCode((int)dr["GasStationCode"]);
                        Malfunction.TypeOfMalfunction = 0;
                        Malfunction.Insert();

                        jOilSupplier.GetData(Malfunction.SupplierCode);
                        int SupplierPostCode= Pr.GetPersonPostCode(jOilSupplier.PCode);
                        Automation.JARefer Ja = new Automation.JARefer();
                        Ja.Send(SupplierPostCode, "نصب RPM", 0, Malfunction.Code, string.Empty, "WebOilManagement.JWebOilManagement", 0, new DataTable());




                    }
                    db.Commit();
                }
            }
            catch (Exception Ex)
            {

            }
            finally
            {
                db.Dispose();
            }
        }
        public DataTable GetDataSourceFromFile(string fileName)
        {
            DataTable dt = new DataTable("OilRPMGS");
            string[] columns = null;

            var lines = System.IO.File.ReadAllLines(fileName);

            // assuming the first row contains the columns information
            if (lines.Count() > 0)
            {
                columns = lines[0].Split(new char[] { ',' });

                foreach (var column in columns)
                    dt.Columns.Add(column);
            }

            // reading rest of the data
            for (int i = 1; i < lines.Count(); i++)
            {
                DataRow dr = dt.NewRow();
                string[] values = lines[i].Split(new char[] { ',' });

                for (int j = 0; j < values.Count() && j < columns.Count(); j++)
                    dr[j] = values[j];

                dt.Rows.Add(dr);
            }
            return dt;
        }
    }

    public class JOilRPMGSes
    {
        public static DataTable GetDataTable()
        {
            return GetDataTable(0);
        }

        public static DataTable GetDataTable(int pCode)
        {
            JOilRPMGSTable GH = new JOilRPMGSTable();
            return GH.GetDataTable(pCode);
        }

        public static string GetWebQuery()
        {
            return @"SELECT  org.Code, org.StatusofGsRPM, org.DateIns, org.PCode, org.GasStationCode, org.Time
                        FROM OilRPMGS org ";
        }
    }

    public class JOilRPMGSTable : ClassLibrary.JTable
    {
        //public int Code;
        public int Code_RPM;
        public string GasStationCode;
        public string StatusofGsRPM;
        public DateTime DateIns;
        public int PCode;
        public string Version;
        public string Comment;
        public string Time;

        public JOilRPMGSTable()
            : base("OilRPMGS")
        {
        }
    }

}
