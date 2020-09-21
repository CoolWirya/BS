using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebProjectManagement.Forms
{
    public partial class TotalReportsProjects : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ((WebControllers.MainControls.Date.JDateControl)dateFirst).SetDate(DateTime.Now);
            ((WebControllers.MainControls.Date.JDateControl)dateSecond).SetDate(DateTime.Now);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            pnlData.Controls.Add(createGrid());
        }

        private Control createGrid()
        {
            string query = "";
            query = @"
SELECT f.Code,f.Name,CONVERT(date, f.FirstDate) as FirstDate,
cast((CASE WHEN SUM(f.FirstTotalImprovement) IS NULL THEN 0 
ELSE SUM(f.FirstTotalImprovement) END) as numeric(36,2))  as FirstTotalImprovement,
 CONVERT(date,  f.SecondDate) as SecondDate,cast(SUM(f.SecondTotalImprovement) as numeric(36,2))  as SecondTotalImprovement
FROM 
(
SELECT p.Code,p.Name,
 CONVERT(datetime,N'{1}') as FirstDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i .code AND RegisterDate BETWEEN N'{0}' AND N'{1}' )*i.WeightPercentage/100 ) AS FirstTotalImprovement ,
 CONVERT(datetime, N'{2}') AS SecondDate,
 ((SELECT SUM(ir.WeightPercentage) FROM pmItemReport ir 
 WHERE ir.ItemCode=i.code AND RegisterDate BETWEEN N'{0}' AND N'{2}')*i.WeightPercentage/100 )AS SecondTotalImprovement 
 FROM 
 pmItems i 
inner join pmProjects p on p.Code=i.ProjectCode
WHERE i.Code in (select Code from pmItems where Code not in (select ParentItemCode from pmItems) AND i.ProjectCode=p.Code)
) as f
group by f.Code,f.Name,f.FirstDate, f.SecondDate ";
          query=  string.Format(query,
"1-1-1900 12:00:00",
((WebControllers.MainControls.Date.JDateControl)dateFirst).GetDate().AddHours(23).AddMinutes(59),
((WebControllers.MainControls.Date.JDateControl)dateSecond).GetDate().AddHours(23).AddMinutes(59));


            WebControllers.MainControls.Grid.JGridView jGridView =
                new WebControllers.MainControls.Grid.JGridView(JReports._ConstClassName.Replace(".", "_") + "_TotalProjectImprovementReport");
            jGridView.ClassName = JReports._ConstClassName.Replace(".", "_") + "._TotalProjectImprovementReport";

            jGridView.SQL = query;

            jGridView.Title = "Projects Imporovements";

            jGridView.Bind();

            return jGridView;
        }

    }
}