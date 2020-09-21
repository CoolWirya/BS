using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public class JSQLViews
    {
        public static string Documents = @"
            SELECT Refer.Code, Refer.Sender, Refer.Reciver, Refer.SendDate, Refer.ReciveDate, Refer.ObjectCode, Objects.Action, 
                Objects.ActionName, Objects.ExternalCode, Objects.Creator, Objects.CreateDate, Objects.Title, Objects.Subject, 
                Objects.TransmittalType
                FROM  Objects INNER JOIN
                Refer ON Objects.Code = Refer.ObjectCode";

        public static string OrganisationUnitUsers = @"
            SELECT     users.code
            FROM         " + ClassLibrary.JTableNamesClassLibrary.PersonTable + @" person INNER JOIN 
                empposts INNER JOIN
                users ON empposts.activeusercode = users.code ON person.Code = users.pcode ";
        public static string MetierTopic = @"
            ";
    }
}
