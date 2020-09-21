using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClassLibrary;

namespace ShareProfit.CalcZamin
{
    public class ClassTempZamin
    {
        public ClassTempZamin()
        {
        }

        public DataTable CalcBed()
        {

            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select  a.pcode,round(a.amadebedeh,0,0) amadebedeh from 
(select Code,PCode,(select Name + ' ' + fam from clsPerson where Code=PCode) Name,SumSahm,SumSahm*3500000.0 midadidm,a.CostGround/a.SumG*SumSahm dadim, SumSahm*3500000.0 - a.CostGround/a.SumG*SumSahm kamdadim,SumSahm*500000.0 amademidadeh,SumSahm*500000 - (SumSahm*3500000.0 - a.CostGround/a.SumG*SumSahm) amadebedeh
from(select *, (select Cost from estGround where Code=GCode) CostGround,(select SUM(SumSahm) from lotteryResault where GCode = LR.GCode) SumG from lotteryResault  LR
where SumSahm>0 ) as a) as a order by a.PCode");
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public DataTable CalcBes(int CourseCode, int pcode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select SS.PCode,SN.Code,sum(isnull(SP.paycost,0)) PayCost from SahamNumber SN
left join SahamSheet SS on SN.Code>= SS.Az AND SN.Code<=SS.Ela and SS.CourseCode=" + CourseCode.ToString() + @" and SS.DeActive=0
left join sahampayment SP on SP.stockno = SN.Code AND SP.coursecode=" +CourseCode.ToString()+@"
where SS.PCode=" + pcode.ToString()+@"
group by SS.PCode,SN.Code
order by SN.Code");
                return DB.Query_DataTable();
            }
            catch
            {
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public int SetBedToBes(DataTable pDPerson, int Bed, int CourseCode, int ConstBes, int Sal, int docCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                foreach (DataRow DR in pDPerson.Rows)
                {
                    if (Bed <= 0) return 0;
                    int Sahm_No = (int)DR["Code"];
                    int PCode = (int)DR["PCode"];
                    if (CourseCode == 50)
                    {
                        //Bed++;
                        //Bed--;
                    }
                    int PayCost = decimal.ToInt32((decimal)DR["PayCost"]);
                    PayCost = ConstBes - PayCost;
                    if (PayCost > 0 && Bed > 0)
                    {
                        if (PayCost > Bed)
                            PayCost = Bed;
                            DB.setQuery(@"
        DECLARE @Code INT
        SET @Code = ISNULL((SELECT MAX(Code) FROM [sahampayment]),0) + 1
        insert into sahampayment 
        values( 
        @Code,
        " + docCode.ToString() + @",
        (select Code from shareSheet where Az<=" + Sahm_No.ToString() + @" And Ela>=" + Sahm_No.ToString() + @" And Status=1 and CompanyCode=1),
        " + PCode.ToString() + @",
        " + Sahm_No.ToString() + @",
        '1391/10/12',
        " + PayCost.ToString() + @",
        'پرداخت سود " + Sal.ToString() + @" بابت آماده سازی زمین','مدیر سیستم',
        " + CourseCode.ToString() + @",
        0,
        NULL,
        0,
        0,
        NULL)
        ");

                        DB.Query_Execute();
                        Bed -= PayCost;
                    }
                }
                return Bed;
            }
            catch
            {
                DB.Dispose();
                return -1;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void Calc()
        {
            DataTable DT = CalcBed();
            foreach(DataRow Dr in DT.Rows)
            {
                int Bed = decimal.ToInt32((decimal)Dr["amadebedeh"]);
                DataTable DPerson;

                DPerson = CalcBes(49, (int)Dr["pcode"]);
                Bed = SetBedToBes(DPerson, Bed, 49, 240000, 89, 256000454);

                DPerson = CalcBes(50, (int)Dr["pcode"]);
                Bed = SetBedToBes(DPerson, Bed, 50, 260000, 90, 256000455);
            }
        }
    }
}
