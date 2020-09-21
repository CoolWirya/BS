using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebBusManagement.FormsMaintenance
{
    public partial class JComparisonTicketTExtractTAndDailyTReportControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                btnSave_Click(null, null);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string Query = @"declare @TAUTTicket Table
                                (
                                BusNumber INT,
                                Date  Date,
                                CardType INT,
                                DriverPersonCode int,
                                LineNumber INT,
                                TicketPrice INT,
                                BusCode INT,
                                DriverCardSerial bigint,
                                C INT
                                )

                                declare @TAUTDelay Table
                                (
                                BusCode INT,
                                CardType INT,
                                Date  Date,
                                DriverCardSerial bigint,
                                DriverPersonCode int,
                                LineNumber INT,
                                OwnerCode INT,
                                TCount INT
                                )

                                declare @TAUTExtract Table
                                (
                                BusSerial INT,
                                Date  Date,
                                CardType INT,
                                LineNumber INT,
                                TicketPrice INT,
                                DriverSerialCard bigint,
                                c INT
                                )

                                insert into @TAUTExtract
                                select 
                                top 100 percent
                                at.BusSerial,cast(at.EventDate as date) date,at.CardType,at.LineNumber,at.TicketPrice,at.DriverSerialCard
                                ,count(*) AS c 
                                from 
                                (select top 100 percent eventdate,remainprice,passengercardserial,BusSerial,ticketprice,CardType,LineNumber,DriverSerialCard from ExtractedTickets 
                                group by eventdate,remainprice,passengercardserial,BusSerial,ticketprice,CardType,LineNumber,DriverSerialCard
                                order by BusSerial) at
                                group by at.BusSerial,cast(at.EventDate as date),at.CardType,at.LineNumber,at.TicketPrice,at.DriverSerialCard
                                order by at.BusSerial

                                insert into @TAUTDelay
                                select b.BusCode,b.CardType,b.Date,b.DriverCardSerial,b.DriverPersonCode,b.LineNumber,b.OwnerCode,sum(TCount) TCount from
                                AUTDailyPerformanceRportOnBus b
                                group by b.BusCode,b.CardType,b.Date,b.DriverCardSerial,b.DriverPersonCode,b.LineNumber,b.OwnerCode

                                insert into @TAUTTicket
                                select at.BusNumber,cast(at.EventDate as date) Date,at.CardType,at.DriverPersonCode,at.LineNumber,at.TicketPrice,BusCode,at.DriverCardSerial
                                ,count(*) c from AUTTicketTransaction at
                                group by at.BusNumber,cast(at.EventDate as date),at.CardType,at.DriverPersonCode,at.LineNumber,at.TicketPrice,at.BusCode,at.DriverCardSerial

                                select top 100 percent a.c TicketTable,c.c ExtractTable,ad.TCount DailyTable,a.c-ad.TCount ComparisonTicketTDailyT,* from
                                (
                                select * from @TAUTTicket
                                )a 
                                inner join
                                (
                                select * from @TAUTDelay
                                ) ad
                                on a.Buscode = ad.BusCode 
                                and a.CardType=ad.CardType 
                                and a.Date=ad.date
                                and a.DriverCardSerial = ad.DriverCardSerial
                                and a.DriverPersonCode=ad.DriverPersonCode 
                                and a.LineNumber=ad.LineNumber
                                inner join
                                (
                                select * from @TAUTExtract
                                )c
                                on a.BusNumber=c.BusSerial
                                and a.CardType=c.CardType 
                                and a.Date=c.date
                                and a.DriverCardSerial = c.DriverSerialCard
                                and a.LineNumber=c.LineNumber
                                where  --ad.Date between '2013-12-22' and '2014-01-20' 
                                --and 
                                ((a.c <> ad.TCount) OR (a.c<>c.c) OR(ad.TCount<>c.c))
                                and a.TicketPrice<>0
                                --and a.BusNumber=1891
                                order by a.BusNumber

                                --Drop Table @TAUTExtract";
            RadGridReport1.DataSource = WebClassLibrary.JWebDataBase.GetDataTable(Query);
            RadGridReport1.DataBind();
        }

        protected void RadGridReport1_PreRender(object sender, EventArgs e)
        {
            if (RadGridReport1.DataSource == null) return;
            foreach (DataColumn col in (RadGridReport1.DataSource as DataTable).Columns)
            {
                RadGridReport1.MasterTableView.GetColumn(col.ColumnName).HeaderText = ClassLibrary.JLanguages._Text(col.ColumnName);
                //if (col.ColumnName == "Code")
                //{
                //    RadGridReport1.MasterTableView.GetColumn(col.ColumnName).Visible = false;
                //}
            }
            RadGridReport1.MasterTableView.Rebind();
        }
    }
}