using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AndroidWebManagement.Forms
{
    public partial class JGroundUpdateControl : System.Web.UI.UserControl
    {
        int Code;
        protected void Page_Load(object sender, EventArgs e)
        {
            int.TryParse(Request["Code"], out Code);
            _SetForm();
        }

        public void _SetForm()
        {
            if (Code > 0)
            {
                System.Data.DataTable Dt = WebClassLibrary.JWebDataBase.GetDataTable(@"SELECT [Code]
                                                                                          ,[Metraj]
                                                                                          ,[Abad]
                                                                                          ,[MogheeyatJoghrafi]
                                                                                          ,[MogheeyatMakani]
                                                                                          ,[Address]
                                                                                          ,[Sanad]
                                                                                          ,[TedadShoraka]
                                                                                          ,[Tozihat]
                                                                                          ,[Gheymat]
                                                                                      FROM [dbo].[Android_Ground] where Code = " + Code);
                if (Dt != null)
                {
                    if (Dt.Rows.Count > 0)
                    {
                        txtMetarj.Text = Dt.Rows[0]["Metraj"].ToString();
                        txtAbad.Text = Dt.Rows[0]["Abad"].ToString();
                        txtMogheyatJoghrafi.Text = Dt.Rows[0]["MogheeyatJoghrafi"].ToString();
                        txtMogheyatMakani.Text = Dt.Rows[0]["MogheeyatMakani"].ToString();
                        txtAddress.Text = Dt.Rows[0]["Address"].ToString();
                        txtSanad.Text = Dt.Rows[0]["Sanad"].ToString();
                        txtTedadeShoraka.Text = Dt.Rows[0]["TedadShoraka"].ToString();
                        txtTozihat.Text = Dt.Rows[0]["Tozihat"].ToString();
                        txtGheymat.Text = Dt.Rows[0]["Gheymat"].ToString();
                    }
                }
            }
        }

        public bool Save()
        {
            ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
            if (Code > 0)
            {
                Db.setQuery(@"UPDATE [dbo].[Android_Ground]
                                   SET [Metraj] = N'" + txtMetarj.Text + @"'
                                      ,[Abad] = N'" + txtAbad.Text + @"'
                                      ,[MogheeyatJoghrafi] = N'" + txtMogheyatJoghrafi.Text + @"'
                                      ,[MogheeyatMakani] = N'" + txtMogheyatMakani.Text + @"'
                                      ,[Address] = N'" + txtAddress.Text + @"'
                                      ,[Sanad] = N'" + txtSanad.Text + @"'
                                      ,[TedadShoraka] = N'" + txtTedadeShoraka.Text + @"'
                                      ,[Tozihat] = N'" + txtTozihat.Text + @"'
                                      ,[Gheymat] = N'" + txtGheymat.Text + @"'
                                       where Code = " + Code);
            }
            else
            {
                Db.setQuery(@"INSERT INTO [dbo].[Android_Ground]
                                    ([Metraj]
                                    ,[Abad]
                                    ,[MogheeyatJoghrafi]
                                    ,[MogheeyatMakani]
                                    ,[Address]
                                    ,[Sanad]
                                    ,[TedadShoraka]
                                    ,[Tozihat]
                                    ,[Gheymat])
                                VALUES
                                    (N'" + txtMetarj.Text + @"'
                                    ,N'" + txtAbad.Text + @"'
                                    ,N'" + txtMogheyatJoghrafi.Text + @"'
                                    ,N'" + txtMogheyatMakani.Text + @"'
                                    ,N'" + txtAddress.Text + @"'
                                    ,N'" + txtSanad.Text + @"'
                                    ,N'" + txtTedadeShoraka.Text + @"'
                                    ,N'" + txtTozihat.Text + @"'
                                    ,N'" + txtGheymat.Text + @"')");
            }
            if (Db.Query_Execute() >= 0)
            {
                return true;
            }
            else { return false; }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Save())
                WebClassLibrary.JWebManager.CloseAndRefresh();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                ClassLibrary.JDataBase Db = new ClassLibrary.JDataBase();
                Db.setQuery(@"delete from [Android_Ground] where Code = " + Code);
                if (Db.Query_Execute() >= 0)
                    WebClassLibrary.JWebManager.CloseAndRefresh();
            }
        }
    }
}