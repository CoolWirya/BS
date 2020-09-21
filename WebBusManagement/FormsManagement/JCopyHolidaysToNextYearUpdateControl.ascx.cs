using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebBusManagement.FormsManagement
{
    public partial class JCopyHolidaysToNextYearUpdateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //WHERE [Date] BETWEEN dbo.DateFaToEn(@FromYear,1,1) AND dbo.DateFaToEn(@FromYear,12,29)
        }

        public bool Save(int FromYear, int ShiftDays)
        {
            JDataBase db = new JDataBase();
            db.setQuery(@"
                declare @Fridays table(Date date) 
                declare @start_date date = dbo.DateFaToEn(@FromYear + 1,1,1), @end_date date = dbo.DateFaToEn(@FromYear + 1,12,29), @date_counter date = dbo.DateFaToEn(@FromYear + 1,1,1) 

                while(@date_counter <= @end_date)
                begin
                if(DATEPART(WEEKDAY, @date_counter) = 6)
	                insert into @Fridays select @date_counter
                set @date_counter = DATEADD(day, 1, @date_counter)
                end

                INSERT INTO [dbo].[AUTHolidays]
                           ([Date]
                           ,[Description]
                           ,[HoliDaysType]
                           ,[DateType])
                SELECT      DATEADD(DAY, - (case [DateType] when 1 then 0 else @ShiftDays end), dbo.DateFaToEn(cast(SUBSTRING(cast(dbo.DateEnToFa([Date]) as varchar), 1, 4) as int) + 1, SUBSTRING(cast(dbo.DateEnToFa([Date]) as varchar), 6, 2), SUBSTRING(cast(dbo.DateEnToFa([Date]) as varchar), 9, 2)))
                           ,[Description]
                           ,[HoliDaysType]
                           ,[DateType] 
                FROM [dbo].[AUTHolidays]
                WHERE [Date] BETWEEN dbo.DateFaToEn(@FromYear,1,1) AND dbo.DateFaToEn(@FromYear,12,29)  AND HoliDaysType = 2
                UNION
                SELECT Date, N'' Description, 1 HoliDaysType, 1 DateType FROM @Fridays"
                .Replace("@ShiftDays", ShiftDays.ToString()).Replace("@FromYear", FromYear.ToString()));
            
            try
            {
                return db.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int FromYear = Convert.ToInt32(rblFromYear.SelectedValue);
            int ToYear = Convert.ToInt32(rblToYear.SelectedValue);
            int ShiftDays = 0;
            if (ntbShiftDays.Value != null)
                ShiftDays = (int)ntbShiftDays.Value.Value;
            if (ShiftDays == 0)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('اختلاف روز سال شمسی با قمری نامعتبر است');", "ConfirmDialog");
                return;
            }
            if (ToYear != FromYear + 1)
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('انتقال از یک سال به سال بعد امکان پذیر است');", "ConfirmDialog");
                return;
            }
            if (Save(FromYear, Math.Abs(ShiftDays)))
            {
                WebClassLibrary.JWebManager.RunClientScript("alert('با موفقیت انجام است');", "ConfirmDialog");
                WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
    }
}