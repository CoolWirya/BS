using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Legal
{
    class JProbateInheritance : JSystem
    {
        /// <summary>
        /// 
        /// </summary>
        public int Code{ get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int CodeProbate { get; set; }
        /// <summary>
        ///
        /// </summary>
        public int CodePerson { get; set; }
        /// <summary>
        ///
        /// </summary>
        public float inheritance { get; set; }
        /// <summary>
        /// میزان سهم بصورت رشته
        /// </summary>
        public string inherText { get; set; }
        /// <summary>
        /// شرح
        /// </summary>
        public string InherDesc { get; set; }
        /// <summary>
        /// کد نسبت خانوادگی شخص با متوفی
        /// </summary>
        public int RelationFamily { get; set; }
        public JProbateInheritance (int pCode)
        {
            CodeProbate=pCode;
        }

        public int Insert(JDataBase pDB)
        {
            //if (Find(this.CodePerson))
            //{
            //    JMessages.Error("PersonExistsInProbate", "Error");
            //    return 0;
            //}
            JProbateInheritanceTable table = new JProbateInheritanceTable();
            table.SetValueProperty(this);
            int code =  table.Insert(pDB);
            Histroy.Save(this, table, code, "Insert");
            return code;
        }

        public bool Delete (JDataBase pDB)
        {
            JProbateInheritanceTable table = new JProbateInheritanceTable();
            table.SetValueProperty(this);
            if (table.Delete(pDB))
            {
                Histroy.Save(this, table, table.Code, "Delete");
                return true;
            }
            else
                return false;
        }

        public bool Update(JDataBase pDB)
        {
            JProbateInheritanceTable table = new JProbateInheritanceTable();
            table.SetValueProperty(this);
            if (table.Update(pDB))
            {
                Histroy.Save(this, table, table.Code, "Delete");
                return true;
            }
            else
                return false;
        }
        /// <summary>
        /// یک شخص خاص را در گواهی جستجو میکند
        /// </summary>
        /// <param name="pCode"></param>
        /// <param name="pPersonCode"></param>
        /// <returns></returns>
        public bool Find(int pPersonCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery(" SELECT Code FROM " + JTableNamesLegal.ProbateInheritance + " WHERE " +
                    JProbateInheritanceTableEnum.CodeProbate + " = " + this.CodeProbate.ToString() +
                    " AND " + JProbateInheritanceTableEnum.CodePerson + " = " + pPersonCode.ToString());
                DB.Query_DataSet();
                return (DB.DataSet.Tables[0].Rows.Count > 0);
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }
        }
    }

    class JProbateInheritances : JSystem
    {
        //public static DataTable GetDataTable(int pCode)
        //{
        //    return null;
        //}

        private static float _ComputeShares(int[] Shares, int[] AllShares)
        {
            if (Shares.Length > 0 && AllShares.Length > 0)
            {

                float MultipleAllShares = 1;
                float[] NewShares = new float[Shares.Length];
                for (int i = 0; i < AllShares.Length; i++)
                {
                    MultipleAllShares = MultipleAllShares * AllShares[i];
                }
                for (int i = 0; i < Shares.Length; i++)
                {
                    NewShares[i] = Shares[i] * (MultipleAllShares / AllShares[i]);
                }
                return (NewShares.Sum() / MultipleAllShares);

            }
            return 0;
        }
        public static bool Insert(DataTable pHeirs, int pProbateCode, JDataBase pDB)
        {
            try
            {
                JProbateInheritance heris = new JProbateInheritance(pProbateCode);
                heris.CodeProbate = pProbateCode;
                int[] Shares = new int[0];
                int[] AllShares = new int[0];
                int i = 0;
                foreach (DataRow row in pHeirs.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                    {
                        Array.Resize(ref Shares, i + 1);
                        Array.Resize(ref AllShares, i + 1);
                        Shares[i] = Convert.ToInt32(row[JProbateInheritanceTableEnum.inherText.ToString()].ToString().Split('/')[0]);
                        AllShares[i] = Convert.ToInt32(row[JProbateInheritanceTableEnum.inherText.ToString()].ToString().Split('/')[1]);
                        i++;
                    }
                }
                /// چک کردن مقادیر سهم وارد شده
                //if (Shares.Length > 0 && AllShares.Length > 0)
                //    if (_ComputeShares(Shares, AllShares) > 1 || _ComputeShares(Shares, AllShares)<=0)
                //    {
                //        JMessages.Error("ShareAreNotCorrect", "Error");
                //        return false;
                //    }
                foreach (DataRow row in pHeirs.Rows)
                {
                    if (row.RowState == DataRowState.Added)
                    {
                        heris.CodePerson = Convert.ToInt32(row[JProbateInheritanceTableEnum.CodePerson.ToString()]);
                        heris.inherText = row[JProbateInheritanceTableEnum.inherText.ToString()].ToString();
                        //heris.Code = Convert.ToInt32(row[JProbateInheritanceTableEnum.Code.ToString()]); 
                        heris.RelationFamily =Convert.ToInt32( row[JProbateInheritanceTableEnum.RelationFamily.ToString()]);
                        heris.InherDesc = row["InherDesc"].ToString();
                        heris.Insert(pDB);
                    }
                    if (row.RowState == DataRowState.Modified)
                    {
                        heris.CodePerson = Convert.ToInt32(row[JProbateInheritanceTableEnum.CodePerson.ToString()]);
                        heris.Code = Convert.ToInt32(row[JProbateInheritanceTableEnum.Code.ToString()]);
                        heris.inherText = row[JProbateInheritanceTableEnum.inherText.ToString()].ToString();
                        heris.RelationFamily = Convert.ToInt32(row[JProbateInheritanceTableEnum.RelationFamily.ToString()]);
                        heris.InherDesc = row["InherDesc"].ToString();
                        heris.Update(pDB);
                    }
                        if (row.RowState == DataRowState.Deleted)
                    {
                        row.RejectChanges();
                        if (row[JProbateInheritanceTableEnum.Code.ToString()] != DBNull.Value)
                        {
                            heris.Code = Convert.ToInt32(row[JProbateInheritanceTableEnum.Code.ToString()]);
                            heris.Delete(pDB);
                            row.Delete();
                        }
                        else
                            row.Delete();
                    }
                }
                pHeirs.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return false;
            }

        }
    }
}
