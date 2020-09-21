using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Automation;
using Communication.Letter;
using System.Windows.Forms;
using System.Drawing;

namespace Communication
{
    public class JCImportedLetter : JSystem
    {
        public const string _ConstClassName = "Communication.JCImportedLetter";
        public void ReferShow(int pCode, int referCode)
        {
            JCLetter letter = new JCLetter();
            letter.GetData(pCode);
            if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                (new JLetterForm(pCode, referCode)).ShowDialog();
            else if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(pCode, referCode)).ShowDialog();
            else if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                (new JExportedLetterForm(pCode, referCode)).ShowDialog();
        }

        public DataTable GetFlowChartData(int DynamicClassCode) 
        {
            return null;
        }

        /// <summary>
        /// اتوماسیون وب 
        /// </summary>
        /// <param name="referCode"></param>
        public string ShowRefer(int referCode)
        {
            var q = (new ClassLibrary.JAction("", WebAutomation.JCommunication._ConstClassName + ".ShowRefer", new object[] { referCode }, null)).run();
            if (q != null)
                return q.ToString();
            return "";
        }

        public static bool PermissionLetterImport()
        {
            if (JPermission.CheckPermission("Communication.JCImportedLetter.PermissionLetterImport", false))
                return true;
            else
                return false;
        }

        public Panel GetPanel(int pDynamicClassCode, int pObjectCode, int pReferCode)
        {
            JCLetter Letter = new JCLetter();
			return Letter.GetPanel(pDynamicClassCode, pObjectCode, pReferCode);
        }
        public void reRefer(int pLetterCode, int pReferCode)
        {
            JCLetter L = new JCLetter();
            L.reReferShow(pLetterCode, pReferCode);
        }

    }

    public class JCExportedLetter : JSystem
    {
        public const string _ConstClassName = "Communication.JCExportedLetter";

        public void ReferShow(int pCode, int referCode)
        {
            JCLetter letter = new JCLetter();
            letter.GetData(pCode);
            if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                (new JLetterForm(pCode, referCode)).ShowDialog();
            else if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(pCode, referCode)).ShowDialog();
            else if (letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                (new JExportedLetterForm(pCode, referCode)).ShowDialog();
        }

        public DataTable GetFlowChartData(int DynamicClassCode)
        {
            return null;
        }

		public static bool PermissionLetterExport()
		{
			if (JPermission.CheckPermission("Communication.JCExportedLetter.PermissionLetterExport", false))
				return true;
			else
				return false;
		}

		public static bool PermissionLetterExportSign()
		{
			if (JPermission.CheckPermission("Communication.JCExportedLetter.PermissionLetterExportSign", false))
				return true;
			else
				return false;
		}
		
/// <summary>
        /// اتوماسیون وب 
        /// </summary>
        /// <param name="referCode"></param>
        public string ShowRefer(int referCode)
        {
            var q = (new ClassLibrary.JAction("", WebAutomation.JCommunication._ConstClassName + ".ShowRefer", new object[] { referCode }, null)).run();
            if (q != null)
                return q.ToString();
            return "";
        }

        public Panel GetPanel(int pDynamicClassCode, int pObjectCode, int pReferCode)
        {
			JCLetter Letter = new JCLetter();
			return Letter.GetPanel(pDynamicClassCode, pObjectCode, pReferCode);
		}

        public void reRefer(int pLetterCode, int pReferCode)
        {
            JCLetter L = new JCLetter();
            L.reReferShow(pLetterCode, pReferCode);
        }

    }

    public class JCLetter : JSystem
    {
        //public static Control ActionGetData()
        //{
        //    Panel p = new Panel();
        //    return Panel;
        //}

        public const string _ConstClassName = "Communication.JCLetter";
        // ویژگیها و فیلد ها
        #region Peroperties

        /// <summary>
        /// کد
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نامه قبلی
        /// </summary>
        public int ParentCode { get; set; }
        /// <summary>
        /// نوع نامه - وارده ، صادره یا درون سازمانی
        /// </summary>
        public int letter_type { get; set; }
        /// <summary>
        /// وضعیت نامه
        /// </summary>
        public int letter_status { get; set; }
        /// <summary>
        /// کد موضوع نامه
        /// </summary>
        public int subject_code { get; set; }
        /// <summary>
        /// پیش نویس موضوع
        /// </summary>
        public string subject { get; set; }
        /// <summary>
        /// تاریخ و زمان ثبت
        /// </summary>
        public DateTime register_date_time { get; set; }
        /// <summary>
        /// شماره ثبت
        /// </summary>
        public int register_no { get; set; }
        /// <summary>
        /// شماره نامه
        /// </summary>
        public string letter_no { get; set; }
        /// <summary>
        /// شماره نامه وارده
        /// </summary>
        public string incoming_no { get; set; }
        /// <summary>
        /// تاریخ نامه وارده
        /// </summary>
        public DateTime incoming_date { get; set; }
        /// <summary>
        /// امضا کننده نامه وارده
        /// </summary>
        public string incoming_signature_person { get; set; }
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public int sender_post_code { get; set; }
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public int sender_code { get; set; }
        /// <summary>
        /// عنوان کامل فرستنده
        /// </summary>
        public string sender_full_title { get; set; }
        /// <summary>
        /// کد سازمان فرستنده نامه
        /// </summary>
        public int sender_external_code { get; set; }
        /// <summary>
        /// کد پست گیرنده
        /// </summary>
        public int receiver_post_code { get; set; }
        /// <summary>
        /// کد کاربر گیرنده
        /// </summary>
        public int receiver_code { get; set; }
        /// <summary>
        /// عنوان کامل گیرنده
        /// </summary>
        public string receiver_full_title { get; set; }
        /// <summary>
        /// کد سازمان گیرنده نامه
        /// </summary>
        public int receiver_external_code { get; set; }
        /// <summary>
        /// کد پست کاربر ثبت کننده
        /// </summary>
        public int register_post_code { get; set; }
        /// <summary>
        /// کد کاربر ثبت کننده
        /// </summary>
        public int register_user_code { get; set; }
        /// <summary>
        /// نام کامل ثبت کننده نامه
        /// </summary>
        public string register_user_full_title { get; set; }
        /// <summary>
        /// سطح محرمانگی
        /// </summary>
        public int secret_level { get; set; }
        /// <summary>
        /// فوریت
        /// </summary>
        public int urgency { get; set; }
        /// <summary>
        /// نحوه ارسال
        /// </summary>
        public int send_type { get; set; }
        /// <summary>
        /// نحوه دریافت
        /// </summary>
        public int receiver_type { get; set; }
        /// <summary>
        /// کد دبیرخانه
        /// </summary>
        public int secretariat_code { get; set; }
        /// <summary>
        /// پیوست
        /// </summary>
        public string appendix { get; set; }
        /// <summary>
        /// خلاصه نامه
        /// </summary>
        public string summary { get; set; }
        /// <summary>
        ///  پاسخ
        /// </summary>
        public DateTime respite_date_time { get; set; }

        public DateTime minute_register_date { get; set; }
        /// <summary>
        /// متن نامه
        /// </summary>
        public string LetterText { get; set; }
        /// <summary>
        /// متن ساده نامه
        /// </summary>
        public string NormalLetterText { get; set; }
        /// <summary>
        /// متن رونوشتها
        /// </summary>
        public string CopiesText { get; set; }
        /// <summary>
        /// وضعیت امضا
        /// </summary>
        public bool isSigned { get; set; }
        /// <summary>
        /// تاریخ امضا
        /// </summary>
        public DateTime SignDate { get; set; }
        /// <summary>
        /// کد تصویر در بایگانی تصاویر
        /// </summary>
        public int ImageCode { get; set; }
        /// <summary>
        /// نوع ارسال و تحویل
        /// </summary>
        public int DeliveryType { get; set; }
        /// <summary>
        /// تاریخ ارسال
        /// </summary>
        public DateTime DeliveryDate { get; set; }
        /// <summary>
        /// شخص تحویل گیرنده
        /// </summary>
        public string DeliveryPerson { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public string html { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int EditorType { get; set; }

        #endregion Peroperties
        /// <summary>
        /// فیلد رونوشت
        /// </summary>
        private bool _Copy = false;

        ///نام فعال ارسال شده است
        public bool LetterSend = false;

        public DataTable LetterCopies
        {
            get
            {
                return (new JCLetterCopy()).GetLetterCopies(this.Code);
            }
        }

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetter()
        {
        }
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetter(int pCode)
        {
            GetData(pCode);
        }

        public void ReferShow(int pCode, int referCode)
        {
            GetData(pCode);
            if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                (new JLetterForm(pCode, referCode)).ShowDialog();
            else if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                (new JImportedLetterForm(pCode, referCode)).ShowDialog();
            else if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                (new JExportedLetterForm(pCode, referCode)).ShowDialog();
        }

        public void reReferShow(int pCode, int referCode)
        {
            JCLetter Letter = new JCLetter();

            DataTable _DT = Letter.GetData(pCode);
            if (_DT.Rows.Count == 1)
            {
                string _PostCode = Letter.receiver_post_code.ToString();
                foreach (DataRow _row in Letter.LetterCopies.Rows)
                {
                    _PostCode = _PostCode + ";" + _row["receiver_post_code"];
                }

                _DT.Columns.Add("recivers");
                _DT.Rows[0]["recivers"] = _PostCode;

                Automation.JARefer Refer = new JARefer(referCode);
                JAObject Obj = new JAObject(Refer.object_code);
                

                Automation.Refer.frmRecieverSelector frmrs =
                    new Automation.Refer.frmRecieverSelector
                        (_DT, null, Obj.ClassName, 0, pCode, Obj.title, Refer.parent_code);
                if (frmrs.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                else
                {
                }
            }
        }

        public DataTable GetFlowChartData(int DynamicClassCode)
        {
            return null;
        }

        /// <summary>
        /// اتوماسیون وب 
        /// </summary>
        /// <param name="referCode"></param>
        public string ShowRefer(int referCode)
        {
            var q = (new ClassLibrary.JAction("", WebAutomation.JCommunication._ConstClassName + ".ShowRefer", new object[] { referCode }, null)).run();
            if (q != null)
                return q.ToString();
            return "";
        }

        #endregion Constructors

        #region Method
        public int Insert()
        {
            JDataBase db = new JDataBase();
            try
            {
				if (!JMainFrame.IsWeb())
				{
					html = RtfToHtmlConverter.ConvertRtfToHtml(LetterText);
				}
				else
				{
				}

                JCLetterTable jcLetterTable = new JCLetterTable();
                jcLetterTable.SetValueProperty(this);
                Code = jcLetterTable.Insert();
                if (Code > 0)
                {
                }
                return Code;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            JDataBase db = new JDataBase();
            try
            {
                JCLetterTable jcLetterTable = new JCLetterTable();
                jcLetterTable.SetValueProperty(this);
                return jcLetterTable.Update();
            }
            finally
            {
                db.Dispose();
            }
        }

        public string GetLetterNo()
        {
            JDataBase DB = new JDataBase();
            try
            {
                Employment.JEOrganizationChart E = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
                DB.setQuery("select Code,letter_no from secretariatLetters where Letter_Code=" + this.Code + " and secretariat_code=" + E.secretariat_code + ";");
                DB.Query_DataTable();
                DataTable DT = DB.Query_DataTable();
                if(DT.Rows.Count == 1)
                {
                    return DT.Rows[0]["letter_no"].ToString();
                }
                return "";

            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return "";
        }

        public DataTable GetLetterNoDataTable()
        {
            JDataBase DB = new JDataBase();
            try
            {
                Employment.JEOrganizationChart E = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
                DB.setQuery("select * from secretariatLetters where Letter_Code=" + this.Code);
                DB.Query_DataTable();
                DataTable DT = DB.Query_DataTable();
                return DT;

            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return null;
        }

        public string GetAllLetterNo()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery(@"select Code,
                                (select s.prifix from secretariat s where code = secretariat_code)
                                +cast(Letter_no as varchar(20))
                                +(select s.suffix from secretariat s where code = secretariat_code) name from secretariatLetters 
                                where Letter_Code=" + this.Code);
                DB.Query_DataTable();
                DataTable DT = DB.Query_DataTable();
                string[] S = JDataBase.DataTableToStringtArray(DT, "name");
                return string.Join(",", S);

            }
            catch
            {

            }
            finally
            {
                DB.Dispose();
            }
            return "";
        }

        public string SaveLetterNo(string pLetter_No)
        {
            if(GetLetterNo().Length == 0 && pLetter_No.Length > 0)
            {
                JSecretariatLettersTable SLT = new JSecretariatLettersTable();
                SLT.Letter_Code = Code;
                SLT.letter_no = pLetter_No;
                SLT.register_no = 0;
                SLT.register_post_code = JMainFrame.CurrentPostCode;
                Employment.JEOrganizationChart E = new Employment.JEOrganizationChart(JMainFrame.CurrentPostCode);
                SLT.secretariat_code = E.secretariat_code;
                int i = SLT.Insert();
            }
            return GetAllLetterNo();
        }

        public bool Delete()
        {
            JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
            jcLetterCopyTable.DeleteManual("letter_code = " + this.Code.ToString());
            JCLetterTable jcLetterTable = new JCLetterTable();
            bool ret = jcLetterTable.DeleteManual("Code = " + this.Code.ToString());

            string letter_no = GetLetterNo();

            if (letter_no.Length > 0 && ret)
            {
                int Year = (new System.Globalization.PersianCalendar()).GetYear(ClassLibrary.JDateTime.Now());
                string classname = "";
                if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    classname = _ConstClassName;
                else if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    classname = JImportedLetterForm._ConstClassName;
                else if (letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    classname = JExportedLetterForm._ConstClassName;

                DataTable DT = GetLetterNoDataTable();

                foreach (DataRow DR in DT.Rows)
                {
                    NoStorage NS = new NoStorage(classname, 0 , Year,(int)DR["secretariat_code"]);

                    JNoStorageReserved NSR = new JNoStorageReserved(NS.Code);
                    NSR.Reserve(int.Parse(letter_no));
                }
            }

            JSecretariatLettersTable ST = new JSecretariatLettersTable();
            ST.DeleteManual("letter_code = " + this.Code.ToString()
                + " and letter_no =" + letter_no);

            return ret;
        }

        public void reRefer(int pLetterCode, int pReferCode)
        {
            JCLetter L = new JCLetter();
            L.reReferShow(pLetterCode, pReferCode);
        }

        public bool Delete(int code)
        {
            JCLetterCopyTable jcLetterCopyTable = new JCLetterCopyTable();
            jcLetterCopyTable.DeleteManual("letter_code = " + code.ToString());
            JCLetterTable jcLetterTable = new JCLetterTable();
            return jcLetterTable.DeleteManual("Code = " + code.ToString());
        }

        #endregion


		public static bool PermissionLetter()
		{
			if (JPermission.CheckPermission("Communication.JCLetter.PermissionLetter", false))
				return true;
			else
				return false;
		}

        public DataTable GetData(int pCode)
        {
            JDataBase db = new JDataBase();
            try
            {
                db.setQuery("Select * From Letters WHERE Code=" + pCode.ToString());
                DataTable DT = db.Query_DataTable();
                if (DT.Rows.Count == 1)
                {
                    JTable.SetToClassProperty(this, DT.Rows[0]);
                }
                return DT;
            }
            finally
            {
                db.Dispose();
            }
        }

        public static string GetWebQuery(string where)
        {
            // JDataBase db = new JDataBase();
            try
            {
                //return "Select * From Letters ";
                string query = @"SELECT [Code],Letter_No
              ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
              ,[subject]
              ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
              ,[sender_full_title]
              ,[receiver_full_title]
              ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
              ,[incoming_no]
              ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
              ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
              ,[letter_type]
          FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Internal.ToString() + " " + (where == null ? "" : (" AND " + where));
                        query += @" union all SELECT [Code],Letter_No
              ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
              ,[subject]
              ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
              ,[sender_full_title]
              ,[receiver_full_title]
              ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
              ,[incoming_no]
              ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
              ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
              ,[letter_type]
          FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Export.ToString() + " " + (where == null ? "" : (" AND " + where));
                        query += @" union all SELECT [Code],Letter_No
              ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
              ,[subject]
              ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
              ,[sender_full_title]
              ,[receiver_full_title]
              ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
              ,[incoming_no]
              ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
              ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
              ,[letter_type]
          FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Import.ToString() + " " + (where == null ? "" : (" AND " + where)); ;
                query = "Select tbl.* From (" + query + ") tbl  "; //tbl Order By tbl.register_date_time desc
                return query;

            }
            finally
            {

            }
        }

        public DataTable GetDataForPrint(int pCode)
        {
            DataTable DT = GetData(pCode);
            DataTable NewDT = DT.Copy();
            for (int i = 0; i < DT.Columns.Count; i++)
            {
                if (DT.Columns[i].DataType == typeof(DateTime))
                {
                    string newColName = "PersianDate_" + DT.Columns[i].Caption.Replace(" ", "__");
                    NewDT.Columns.Add(newColName);
                    for (int j = 0; j < NewDT.Rows.Count; j++)
                    {
                        if (DT.Rows[j][i].ToString() != "" && DT.Rows[j][i] != null)
                            NewDT.Rows[j][newColName] = JDateTime.FarsiDate(Convert.ToDateTime(DT.Rows[j][i]));
                        //else
                        //    NewDT.Rows[j][newColName] = JDateTime.FarsiDate(Convert.ToDateTime("01/01/2014 00:00:00 PM"));
                    }
                }
            }
            return NewDT;
        }


        public void DeleteLetter(int code)
        {
            JCLetter jcLetter = new JCLetter(code);
            string classname = "";
            if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                classname = _ConstClassName;
            else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                classname = JImportedLetterForm._ConstClassName;
            else if (jcLetter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                classname = JExportedLetterForm._ConstClassName;

            DataTable dt = (new Automation.JARefer()).FindReferByObjectcode(code, classname);

            if (dt != null)
                if (dt.Rows.Count > 0 && CanDeleteLetterCompletely())
                {
                    if (JMessages.Question("برای این نامه " + dt.Rows.Count.ToString() + " ارجاع وجود دارد، آیا مطمئن هستید؟", "حذف") == DialogResult.Yes)
                    {
                        (new Automation.JARefer()).DeleteObjectAndRefers(classname, 0, code);
                        jcLetter.Delete();
                        ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                        jArchDoc.DeleteArchive(classname, code, true);
                        JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
                    }
                    return;
                }
                else if (dt.Rows.Count > 0)
                {
                    JMessages.Error("نامه ارجاع داده شده قابل حذف نیست.", "حذف");
                    return;
                }

            if (JMessages.Question("آیا از حذف این آیتم مطمئن هستید؟", "حذف") == DialogResult.Yes)
            {
                jcLetter.Delete();
                ArchivedDocuments.JArchiveDocument jArchDoc = new ArchivedDocuments.JArchiveDocument();
                jArchDoc.DeleteArchive(classname, code, true);
                JSystem.Nodes.Delete(JSystem.Nodes.CurrentNode);
            }

        }
        public bool CanDeleteLetterCompletely()
        {
            if (JPermission.CheckPermission("Communication.JCLetter.CanDeleteLetterCompletely"))
                return true;
            return false;
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode Node = new JNode((int)pRow["Code"], "Communication.JCLetter");
            Node.Name = pRow["Subject"].ToString();
            Node.Icone = JImageIndex.Default.GetHashCode();
            //اکشن ویرایش
            JAction editAction = new JAction();

            if (pRow != null)
                if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                    editAction = new JAction("edit...", "Communication.JLetterForm.ShowDialog", null, new object[] { Node.Code });
                else if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                    editAction = new JAction("edit...", "Communication.JImportedLetterForm.ShowDialog", null, new object[] { Node.Code });
                else if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                    editAction = new JAction("edit...", "Communication.JExportedLetterForm.ShowDialog", null, new object[] { Node.Code });

            //اکشن حذف
            JAction deleteaction = new JAction("Delete...", "Communication.JCLetter.DeleteLetter", new object[] { Node.Code }, null);

            string classname = "";
            if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Internal)
                classname = _ConstClassName;
            else if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Import)
                classname = JImportedLetterForm._ConstClassName;
            else if (Convert.ToInt32(pRow["letter_type"]) == ClassLibrary.Domains.JCommunication.JLetterType.Export)
                classname = JExportedLetterForm._ConstClassName;

            JAction ReserveAction = new JAction("رزرو...", "Communication.JCLetter.ShowReservForm", new object[] { classname }, null);

            Node.DeleteClickAction = deleteaction;
            //اکشن جدید
            JAction newAction = new JAction("نامه داخلی جدید...", "Communication.JLetters.ShowNewLetterForm", null, null);
            JAction newAction2 = new JAction("نامه وارده جدید...", "Communication.JLetters.ShowNewImportedLetterForm", null, null);
            JAction newAction3 = new JAction("نامه صادره جدید...", "Communication.JLetters.ShowNewExportedLetterForm", null, null);
            Node.MouseDBClickAction = editAction;

            Node.GetPanel = new JAction("Delete...", "Communication.JCLetter.GetPanel", new object[]{0,Node.Code,0}, null);

            JPopupMenu pMenu = new JPopupMenu("Communication.JCLetter", Node.Code);

            pMenu.Insert(editAction);
            pMenu.Insert(deleteaction);
            pMenu.Insert(newAction);
            pMenu.Insert(newAction2);
            pMenu.Insert(newAction3);
            if(ClassLibrary.JPermission.CheckPermission("CanCheckReservNumber",0))
                pMenu.Insert(ReserveAction);
            Node.Popup = pMenu;
            return Node;

        }

        public void ShowReservForm( string pConstClassName)
        {
            NoStorageForm noStorage = new NoStorageForm(pConstClassName, 0 , false);
            noStorage.ShowDialog();
        }

        private Image resizeImage(Image imgToResize, Size size)
		{
			int sourceWidth = imgToResize.Width;
			int sourceHeight = imgToResize.Height;

			float nPercent = 0;
			float nPercentW = 0;
			float nPercentH = 0;

			nPercentW = ((float)size.Width / (float)sourceWidth);
			nPercentH = ((float)size.Height / (float)sourceHeight);

			if (nPercentH < nPercentW)
				nPercent = nPercentH;
			else
				nPercent = nPercentW;

			int destWidth = (int)(sourceWidth * nPercent);
			int destHeight = (int)(sourceHeight * nPercent);

			Bitmap b = new Bitmap(destWidth, destHeight);
			Graphics g = Graphics.FromImage((Image)b);
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

			g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
			g.Dispose();

			return (Image)b;
		}

		private RichTextBox _InsertImage(RichTextBox rtbEditor, Image pPic)
		{
			try
			{
				System.Drawing.Size size = new Size(pPic.Width, pPic.Height);
				if (pPic.Height > 600)
				{
					size.Height = 600;
					size.Width = pPic.Width * 600 / pPic.Height;
				}
				if (pPic.Width > 600)
				{
					size.Width = 600;
					size.Height = pPic.Height * 600 / pPic.Width;
				}
				Image pic = resizeImage(pPic, size);
				Clipboard.SetImage(pic);
				DataFormats.Format myFormat = DataFormats.GetFormat(DataFormats.Bitmap);
				bool ReadOnly = rtbEditor.ReadOnly;
				rtbEditor.ReadOnly = false;
                rtbEditor.Select(0, 1);
				if (rtbEditor.CanPaste(myFormat))
				{
					rtbEditor.Paste(myFormat);
				}
				else
				{
					MessageBox.Show("The data format that you attempted site" +
					" is not supported by this control.");
				}
				rtbEditor.ReadOnly = ReadOnly;
				return rtbEditor;
			}
			catch
			{
			}
			return null;
		}
		
		public Panel GetPanel(int pDynamicClssCode, int pObjectCode, int pReferCode)
        {
			Panel p = new Panel();
			p.Size = new System.Drawing.Size(932, 180);
			p.AutoScroll = true;
			try
			{
				Automation.JKartable tmpK = new JKartable();
				if (!(tmpK.SaveViewDate(pReferCode)))
				{
				}

				JCLetter Letter = new JCLetter(pObjectCode);
                JEditor REditor = new JEditor();
                //REditor.RichTextBox.RightMargin = 100;

                REditor.InsertText(Letter.NormalLetterText);
				if (Letter.letter_type == ClassLibrary.Domains.JCommunication.JLetterType.Import)
				{
					if (Letter.ImageCode > 0)
					{
						try
						{
                            ArchivedDocuments.JArchiveImage jArchiveImage1 = new ArchivedDocuments.JArchiveImage();
                            jArchiveImage1.ArchiveCode = Letter.ImageCode;

                            //ArchivedDocuments.JArchiveDocument jArchiveDocument = new ArchivedDocuments.JArchiveDocument();
                            //jArchiveDocument.GetData(Letter.ImageCode);
                            //foreach (int item in jArchiveDocument.GetArchivesCodes(_ConstClassName, Letter.Code))
                            //{
                                //JFile f = jArchiveDocument.RetrieveContent(Letter.ImageCode);
                            REditor.InsertImage(jArchiveImage1.Image);
                            jArchiveImage1.Image.Dispose();
                            //}

						}
						catch
						{
						}
					}
				}
				else
				{
				}

				if (pReferCode != 0)
				{
					Automation.Refer.JRefersTextRTB jRefersTextRTB1 = new Automation.Refer.JRefersTextRTB();
					jRefersTextRTB1.LoadRefer(pReferCode);
                    //REditor.RichTextBox.Select(REditor.RichTextBox.TextLength, 0);
                    REditor.InsertText(Environment.NewLine);
                   // REditor.SetRTF(jRefersTextRTB1.Rtf);
				}
                REditor.Dock = DockStyle.Fill;
                REditor.BackColor = System.Drawing.Color.AntiqueWhite;
                p.Controls.Add(REditor);
			}
			catch
			{
			}
            return p;
        }

        #region GetData

        #endregion
    }

    public class JLetters
    {
        #region GetData
        public DataTable GetDataTable()
        {
            return GetDataTable("register_post_code = " + JMainFrame.CurrentPostCode.ToString());
        }

        public DataTable GetDataTable(int userPostCode)
        {
            return GetDataTable("register_post_code = " + userPostCode.ToString());
        }

        public DataTable GetDataTable(int userPostCode, ClassLibrary.Domains.JCommunication.JLetterStatus letterStatus)
        {
            return GetDataTable("register_post_code = " + userPostCode.ToString() + " AND letter_status = " + Convert.ToInt32(letterStatus).ToString());
        }
        public DataTable GetDataTable(string where)
        {
            JDataBase db = new JDataBase();
            try
            {
                string query = @"SELECT [Code],Letter_No
      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
      ,[subject]
      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
      ,[sender_full_title]
      ,[receiver_full_title]
      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
      ,[incoming_no]
      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
      ,[letter_type]
  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Internal.ToString() + " " + (where == null ? "" : (" AND " + where));
                query += @" union all SELECT [Code],Letter_No
      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
      ,[subject]
      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
      ,[sender_full_title]
      ,[receiver_full_title]
      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
      ,[incoming_no]
      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
      ,[letter_type]
  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Export.ToString() + " " + (where == null ? "" : (" AND " + where));
                query += @" union all SELECT [Code],Letter_No
      ,CASE letter_type WHEN 3 THEN N'داخلی' WHEN 2 THEN N'صادره' WHEN 1 THEN N'وارده' ELSE N'unknown' END 'نوع نامه'
      ,[subject]
      ,CASE WHEN [ParentCode] > 0 THEN CAST([ParentCode] as nvarchar) ELSE N'-' END 'پاسخ/پیرو نامه'
      ,[sender_full_title]
      ,[receiver_full_title]
      ,(select Fa_Date from StaticDates where En_Date = CAST([register_date_time] as date)) as [register_date_time]
      ,[incoming_no]
      ,(select Fa_Date from StaticDates where En_Date = CAST([incoming_date] as date)) as [incoming_date]
      ,(select Fa_Date from StaticDates where En_Date = CAST([SignDate] as date)) as [SignDate]
      ,[letter_type]
  FROM [Letters] Where letter_type = " + ClassLibrary.Domains.JCommunication.JLetterType.Import.ToString() + " " + (where == null ? "" : (" AND " + where)); ;
                db.setQuery("Select tbl.* From (" + query + ") tbl Order By tbl.register_date_time desc");
                return db.Query_DataTable();
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool ViewImportedLetterPermission()
        {
            if (JPermission.CheckPermission(".ViewImportedLetterPermission"))
                return true;
            return false;
        }
        #endregion

        public static JNode GetNode()
        {
            JNode Node = new JNode(0, "Communication.JLetters");
            Node.Name = "مکاتبات";

            JAction Ac = new JAction("Form", "Communication.JLetters.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode GetSearchNode()
        {
            JNode Node = new JNode(0, "Communication.JLetters");
            Node.Name = "جستجوی نامه ها";

            JAction Ac = new JAction("Form", "Communication.JLetters.SearchView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public void SearchView()
        {
            LetterSearch letterSearch = new LetterSearch();
            letterSearch.ShowDialog();
        }

        public void ListView()
        {
            JSystem.Nodes.ObjectBase = new JAction("GetPerson", "Communication.JCLetter.GetNode");
            JSystem.Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Communication.JLetters.ShowNewLetterForm", null, null);

            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "نامه داخلی جدید...";
            TN.Click = newAction;
            JSystem.Nodes.AddToolbar(TN);

            if (JCImportedLetter.PermissionLetterImport())
            {
                JAction newAction2 = new JAction("New...", "Communication.JLetters.ShowNewImportedLetterForm", null, null);
                JToolbarNode TN2 = new JToolbarNode();
                TN2.Icon = JImageIndex.LetterImport;
                TN2.Hint = "نامه وارده جدید...";
                TN2.Click = newAction2;
                JSystem.Nodes.AddToolbar(TN2);
            }

            JAction newAction3 = new JAction("New...", "Communication.JLetters.ShowNewExportedLetterForm", null, null);
            JToolbarNode TN3 = new JToolbarNode();
            TN3.Icon = JImageIndex.LetterExport;
            TN3.Hint = "نامه صادره جدید...";
            TN3.Click = newAction3;
            JSystem.Nodes.AddToolbar(TN3);
        }

        public JNode TreeView()
        {
            return null;
        }

        public void ShowNewLetterForm()
        {
            (new JLetterForm()).ShowDialog();
            JSystem.Nodes.RefreshDataTable();
        }

        public void ShowNewImportedLetterForm()
        {
            (new JImportedLetterForm()).ShowDialog();
            JSystem.Nodes.RefreshDataTable();
        }

        public void ShowNewExportedLetterForm()
        {
            (new JExportedLetterForm()).ShowDialog();
            JSystem.Nodes.RefreshDataTable();
        }

    }
}
