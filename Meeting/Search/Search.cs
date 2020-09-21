using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Meeting
{
    public class JSearch : JSystem
    {
        public void ShowForm()
        {
            JfrmSearchMeeting p = new JfrmSearchMeeting();

            p.ShowDialog();
        }

        public DataTable Find(string pWhere, string pWhereLeg)
        {
            JDataBase Db = new JDataBase();
            try
            {
                string Query = @"select M.Code,(Select Fa_Date from StaticDates where En_Date=M.Date) 'Date',M.Subject,M.Location,M.Time 

From MetMeeting M where Code In (Select MeetingCode From MetLegistalation Where " + pWhereLeg + " ) And " + pWhere;

//                string Query = @"select M.Code,(Select Fa_Date from StaticDates where En_Date=M.Date) 'Date',M.Subject,M.Location,M.Time,ML.Legislation,ML.Description,clsAllPerson.Name
// from MetMeeting M inner join MetLegislation ML on M.Code=ML.MeetingCode inner join MetMeetingPersons P on
//M.Code=P.MeetingCode inner join clsAllPerson on clsAllPerson.Code=P.PersonCode where " + pWhere;
                Db.setQuery(Query);
                return Db.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                Db.Dispose();
            }
        }
    }
}
