using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace Automation
{
    public class JReferFolder
    {
        public int ReferCode;
        public int ReferFolderCode;
        public int OldReferFolderCode;

        public int Delete(int ReferFolderCode, JDataBase DB)
        {
            try
            {
                DB.setQuery(" DELETE FROM " + JTableNamesAutomation.ReferFolders + " WHERE ReferFolderCode=" + ReferFolderCode);
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
            }
        }

        public bool DeleteReferFromFolder(int pReferCode)
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("" +
                " DELETE FROM " + JTableNamesAutomation.ReferFolders + " WHERE "
                + ReferFolder.ReferCode + " = " + pReferCode.ToString());
                return DB.Query_Execute() >= 0;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        public int Insert()
        {
            JDataBase DB = new JDataBase();
            try
            {
                DB.setQuery("" +
                " DELETE FROM " + JTableNamesAutomation.ReferFolders + " WHERE "
                + ReferFolder.ReferCode + " = " + ReferCode.ToString() + " AND "
                + ReferFolder.PostCode + " = " + JMainFrame.CurrentPostCode.ToString()
                + " Insert Into " + JTableNamesAutomation.ReferFolders + " Values(" + ReferCode.ToString() + "," + ReferFolderCode.ToString() + "," + JMainFrame.CurrentPostCode.ToString() + ")");
                return DB.Query_Execute();
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally
            {
                DB.Dispose();
            }
            return 0;
        }

        public void InsertReferFolder(JAFolderTypeEnum FolderEnum)
        {
            JDataBase DB = new JDataBase();
            try
            {
                JAFolders tmpFolder = new JAFolders();
                DataTable dt;
                foreach (DataRow dr in tmpFolder.GetFolderByInsert().Rows)
                {
                    string Where = "";
                    if ((dr["object_Type"].ToString() != "0" && dr["object_Type"].ToString() != "")  
                    || dr["Sender_User_post_code"].ToString() != "")
                    {
                        //Where = "status=" + (int)FolderEnum+ " AND ";
                        if (FolderEnum == JAFolderTypeEnum.Inbox)
                        {
                            Where += " R.sender_post_code=" + JMainFrame.CurrentPostCode;
                        }
                        else
                            if (FolderEnum == JAFolderTypeEnum.SendItem)
                            {
                                Where += " R.receiver_post_code=" + JMainFrame.CurrentPostCode;
                            }
						if (dr["object_Type"].ToString() != "")
                            Where += " AND O.ClassName+case when O.DynamicClassCode=0 then '' else cast(O.DynamicClassCode as varchar) end like '%'+(Select object_Type From Folders Where Code=" + dr["Code"] + ")+'%'";
						if (dr["Subject"].ToString() != "")
							Where += " AND O.Title like '%'+(Select Subject From Folders Where Code=" + dr["Code"] + ")+'%'";
						if (dr["Sender_User_post_code"].ToString() != "")
                        {
                            Where += " AND R.Sender_post_code = (Select Sender_User_post_code From Folders Where Code=" + dr["Code"] + ") ";
                        }

                        if (Where.Length > 0)
                        {
                            DB.setQuery(@"
                                    Select R.Code from Refer R inner join Objects O on R.object_code=O.Code 
                                    Where R.status=1 AND R.Code not in (Select ReferCode From ReferFolders where ReferFolderCode in (select Code from Folders where FolderType=" + FolderEnum.GetHashCode().ToString() + ") AND PostCode=" + JMainFrame.CurrentPostCode.ToString() + ") And " + Where);
                            dt = DB.Query_DataTable();
                            foreach (DataRow drIns in dt.Rows)
                            {
                                ReferCode = Convert.ToInt32(drIns["Code"]);
                                ReferFolderCode = Convert.ToInt32(dr["Code"]);
                                Insert();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Dispose();
            }
        }

    }

    public class JReferFolders
    {
    }
}
