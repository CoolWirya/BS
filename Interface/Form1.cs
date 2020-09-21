using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;

namespace ERP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            JDataBase dbs = new JDataBase();

            try
            {
                db.setQuery(@"select * from dbo.sahamcourse");
                DataTable dt = db.Query_DataTable();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int SahamNo = 0;
                    db.setQuery(@"select * 
                                    from SahamSheet 
                                    where CourseCode=" + dt.Rows[i]["Code"].ToString() + " order by code");
                    DataTable dtSood = db.Query_DataTable();

                    if (dtSood.Rows.Count > 0)
                    {
                        string _query="";
                        for (int j = 0; j < dtSood.Rows.Count; j++)
                        {
                            _query=_query+("UPDATE [SahamSheet] " +
                                          "SET [Az] = " + (SahamNo + 1).ToString() +
                                          ",[Ela] =   " + (SahamNo + Convert.ToInt32(dtSood.Rows[j]["ShareCount"])).ToString() + 
                                          " where code=" + dtSood.Rows[j]["Code"].ToString() + " and CourseCode=" + dt.Rows[i]["Code"].ToString() +"\r\n") ;
                            SahamNo = SahamNo + Convert.ToInt32(dtSood.Rows[j]["ShareCount"]);
                        }
                        dbs.beginTransaction("T1");
                        dbs.setQuery(_query);
                        dbs.Query_Execute();
                        dbs.Commit();
                    }
                }
            }
            catch(Exception ex)
            {
                dbs.Rollback("T1");
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                dbs.Commit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JDataBase db = new JDataBase();
            try
            {
                int SahamNo = 0;
                db.setQuery(@"select * 
                                    from ShareSheet
                                    where Status=1 and companycode="+txtCourseCode.IntValue.ToString()
                                    +" order by code");
                DataTable dt = db.Query_DataTable();

                if (dt.Rows.Count > 0)
                {
                    string _query = "";
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        _query = _query + ("UPDATE [ShareSheet] " +
                                      "SET [Az] = " + (SahamNo + 1).ToString() +
                                      ",[Ela] =   " + (SahamNo + Convert.ToInt32(dt.Rows[j]["ShareCount"])).ToString() +
                                      " where code=" + dt.Rows[j]["Code"].ToString() + " \r\n");
                        SahamNo = SahamNo + Convert.ToInt32(dt.Rows[j]["ShareCount"]);
                    }
                    db.beginTransaction("T1");
                    db.setQuery(_query);
                    db.Query_Execute();
                    db.Commit();
                }
            }
            catch (Exception ex)
            {
                db.Rollback("T1");
                MessageBox.Show(ex.Message.ToString());
            }
            finally
            {
                db.Commit();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                JDataBase db = new JDataBase();
                db.setQuery("select * from users where code > 1");
                DataTable dt = db.Query_DataTable();
                if (dt != null)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        try
                        {
                            int pcode = Convert.ToInt32(dt.Rows[i]["pcode"]);
                            JPerson jp = new JPerson(pcode);
							if (RBMelliCode.Checked == true)
							{
								db.setQuery("update users set password=ISNULL('" + JEnryption.EncryptStr(jp.ShMeli.ToString()) + "',0) where pcode=" + pcode.ToString());
							}
							else if (RBShSh.Checked == true)
							{
								db.setQuery("update users set password=ISNULL('" + JEnryption.EncryptStr(jp.ShSh.ToString()) + "',0) where pcode=" + pcode.ToString());
							}
                            db.Query_Execute();
                        }
                        catch
                        { 
                        }

                    }
                }
            }
            catch
            { 
            }
        }
    }
}
