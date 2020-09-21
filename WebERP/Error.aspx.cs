using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;

namespace WebERP
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //JDataBase db = new JDataBase(new System.Data.SqlClient.SqlConnectionStringBuilder(@"Provider=SQLOLEDB.1;Password=erp;Persist Security Info=True;User ID=erp;Initial Catalog=ERP_Sepad;Data Source=192.168.3.4\MSSQLSERVER12"));
            //if(db.Connect())
            //    Response.Write("OK");
        }
    }
}