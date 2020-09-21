using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
namespace Automation
{
        public enum JAFolderTypeEnum
        {
            Inbox = 1,
            SendItem = 2,
            Draft = 3,
            Trash = 4,
            Archive = 5,
        }


        public class JKartable : JAutomation
        {
            private System.Windows.Forms.Timer Timer;
            
            //private static JAFolderTypeEnum CurrentKartable;
            //constructor
            #region constructor
            public JKartable()
            {
                Timer = new System.Windows.Forms.Timer();
                Timer.Interval = 3000;
                Timer.Tick += new EventHandler(GetNewReferEvent);
            }
            #endregion constructor
            //GetInfo


        public static Janus.Windows.GridEX.GridEXFormatStyle GetUnReadRowStyle()
            {
                Janus.Windows.GridEX.GridEXFormatStyle _rowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
                _rowStyle.FontBold = Janus.Windows.GridEX.TriState.True;
                _rowStyle.BackColor = System.Drawing.Color.Lavender;
                return _rowStyle;
            }

            public void GetNewReferEvent(object sender, EventArgs e)
            {
                if (Nodes.Name == "JKartableInBOX" && !JDataBase.isTransaction)
                {
                    System.Data.DataTable DT = GetNewRefer();
                    if (DT != null && DT.Rows.Count > 0 && Nodes != null && Nodes.DataTable != null)
                    {
                        Nodes.DataTable.Merge(DT);
                    }
                }
                else
                {
                    //Timer.Stop();
                }
            GetNewSendEvent(sender, e);
            }

            public void GetNewSendEvent(object sender, EventArgs e)
            {
                if (Nodes.Name == "JKartableSendBOX" && !JDataBase.isTransaction)
                {
                    System.Data.DataTable DT = GetNewRefer();
                    if (DT != null && DT.Rows.Count > 0)
                    {
                        Nodes.DataTable.Merge(DT);
                    }
                }
                else
                {
                }
            }

            public static Janus.Windows.GridEX.GridEXFormatStyle GetReadRowStyle()
            {
                Janus.Windows.GridEX.GridEXFormatStyle _rowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
                return _rowStyle;
            }

        #region GetInfo
            public ClassLibrary.JNode GetNode(System.Data.DataRow DR)
        {

            JARefer R = new JARefer((int)DR["Code"]);
            if (R.receiver_post_code == JMainFrame.CurrentPostCode && R.status == (int)ClassLibrary.Domains.JAutomation.JReferStatus.Current)
                CurrentKartable = JAFolderTypeEnum.Inbox;
            else
                CurrentKartable = JAFolderTypeEnum.SendItem;


            ClassLibrary.JNode node = new JNode((int)DR["Code"], 0);
            node.ClassName = "Automation.JKartable";

            Nodes.hidColumns = "R.Code,ObjectCode,externalcode,action,Objecttype";

            /// اکشن باز کردن
            JAction editAction = new JAction("Open...", "Automation.JKartable.MouseDBClickKartable", new object[] { DR, CurrentKartable }, null);
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            node.Popup.Insert(editAction);
            // اکشن ارسال به پوشه
            JAction MoveToFolder = new JAction("SendToFolder...", "Automation.JKartable.MoveToFolder", new object[] { DR }, null);
            node.Popup.Insert(MoveToFolder);
            // اکشن حذف از پوشه
            JAction DeleteToFolder = new JAction("DeleteFromFolder...", "Automation.JKartable.DeleteFromFolder", new object[] { (int)DR["Code"] }, null);
            node.Popup.Insert(DeleteToFolder);

            // اکشن برگشت از ارجاع برای ارسال شده ها
            JARefer jaRefer = (new JARefer((int)DR["Code"]));
            if (jaRefer.status == 1 && jaRefer.sender_post_code == JMainFrame.CurrentPostCode)
            {
                if (JARefers.isReferView((int)DR["Code"]) == false)
                {
                    JAction ReturnRefer = new JAction("ReturnRefer...", "Automation.JKartable.ReturnRefer", new object[] { DR }, null);
                    node.Popup.Insert(ReturnRefer);
                }
            }

            // ارجا مجدد
            JAObject O = new JAObject(jaRefer.object_code);
            {
                JAction reRefer = new JAction("ReRefer...", O.ClassName + ".reRefer", new object[] { O.ObjectCode, jaRefer.Code }, null);
                node.Popup.Insert(reRefer);
            }



            //JAction SendReferAgain = new JAction("Open...", "Automation.JKartable.SendReferAgain", new object[] { (int)DR["Code"] }, null);
            //node.Popup.Insert(editAction);

            node.GetPanel = new JAction("GetPanel...", DR["ClassName"].ToString() + ".GetPanel", new object[] { DR["DynamicClassCode"], DR["ObjectCode"], DR["Code"] }, null);

            return node;
        }

            public void MoveToFolder(System.Data.DataRow pDR)
            {
                JFoldersListForm FFL = new JFoldersListForm(CurrentKartable.GetHashCode());
                FFL.ShowDialog();
                if (FFL.DialogResult == System.Windows.Forms.DialogResult.OK && FFL.CodeSelect > -1)
                {
                    JReferFolder _Folder = new JReferFolder();
                    _Folder.ReferCode = (int)pDR["Code"];
                    _Folder.ReferFolderCode = FFL.CodeSelect;
                    _Folder.Insert();
                    JAFolder AF = new JAFolder(FFL.CodeSelect);
                    if(AF.DeleteFromKartable)
                        Nodes.Delete(Nodes.CurrentNode);
                }

            }

            public void DeleteFromFolder(int ReferCode)
            {
                JReferFolder _Folder = new JReferFolder();
                _Folder.DeleteReferFromFolder(ReferCode);
            }
            
            public void ReturnRefer(System.Data.DataRow pDR)
        {
            JARefers.ReturnRefer((int)pDR["Code"]);
            Nodes.RefreshDataTable();
            }
            
            
            /// <summary>
            /// تابع گت نود برای آرشیو شده
            /// </summary>
            /// <param name="DR"></param>
            /// <returns></returns>
            public ClassLibrary.JNode GetNodeArchive(System.Data.DataRow DR)
            {
                return null;
            }

            /// <summary>
            /// تابع گت نود برای ارسال شده
            /// </summary>
            /// <param name="DR"></param>
            /// <returns></returns>
            public ClassLibrary.JNode GetNodeSend(System.Data.DataRow DR)
            {
                return null;
            }

            public bool SaveViewDate(int pReferCode)
            {
                JARefer tmpRefer = new JARefer(pReferCode);
                if (tmpRefer.view_date_time != DateTime.MinValue)
                    return true;
                if ((tmpRefer.view_date_time == DateTime.MinValue)
                                        && (JMainFrame.CurrentPostCode != tmpRefer.sender_post_code ||
                    (JMainFrame.CurrentPostCode == tmpRefer.sender_post_code && JMainFrame.CurrentPostCode == tmpRefer.receiver_post_code))
                    )
                {
                    tmpRefer.view_date_time = (new JDataBase().GetCurrentDateTime());
                    return tmpRefer.Update();
                }
                return false;
            }

            public void MouseDBClickKartable(System.Data.DataRow pDR, JAFolderTypeEnum pAFolderTypeEnum)
            {
                JARefer tmpRefer = new JARefer((int)pDR["Code"]);
                if (pAFolderTypeEnum == JAFolderTypeEnum.Inbox && tmpRefer.view_date_time == DateTime.MinValue 
                    && (JMainFrame.CurrentPostCode != tmpRefer.sender_post_code || 
                    (JMainFrame.CurrentPostCode == tmpRefer.sender_post_code && JMainFrame.CurrentPostCode == tmpRefer.receiver_post_code)))
                {
                    tmpRefer.view_date_time = (new JDataBase().GetCurrentDateTime());
                    tmpRefer.Update();
                }
                JAction editAction = new JAction("Open...", pDR["action"].ToString(), new object[] { Convert.ToInt32(pDR["ObjectCode"]), (int)pDR["Code"] }, null);
                editAction.run();
            }


            public void GetInBoxRefer()
            {
                GetInBoxRefer(0);
            }

            public void GetInBoxRefer(int pFolderCode)
            {
                Timer.Stop();
                JReferFolder tmpJReferFolder = new JReferFolder();
                tmpJReferFolder.InsertReferFolder(JAFolderTypeEnum.Inbox);

                CurrentKartable = JAFolderTypeEnum.Inbox;
                Nodes.ObjectBase = new ClassLibrary.JAction("GetReferNode", "Automation.JKartable.GetNode", null, null);

                JRowStyles p = new JRowStyles();
                JRowStyle R = new JRowStyle();
                R.Expression = "[خوانده شده]='False'";
                Janus.Windows.GridEX.GridEXFormatStyle JanusRowStyle = new Janus.Windows.GridEX.GridEXFormatStyle();
                JanusRowStyle.BackColor = System.Drawing.Color.Silver;
                R.JanusRowStyle = JanusRowStyle;
                p.Add(R);
                Nodes.RowStyles = p;                

                Nodes.DataTable = JARefers.GetReferInInbox(ClassLibrary.JMainFrame.CurrentPostCode, pFolderCode);
                if (pFolderCode == 0)
                    Nodes.Name = "JKartableInBOX";
                else
                    Nodes.Name = "FolderInBOX_" + pFolderCode.ToString();
                Nodes.hidColumns = "View_date_Time,externalcode,ObjectType,Receiver_Full_Title,action,Code,ClassName,ObjectCode ,DynamicClassCode";
                Timer.Start();
            }

            public void GetReferSend()
            {
                GetReferSend(0);
            }

            public void GetReferSend(int pFolderCode)
            {
                Timer.Stop();
                JReferFolder tmpJReferFolder = new JReferFolder();
                tmpJReferFolder.InsertReferFolder(JAFolderTypeEnum.SendItem);

                CurrentKartable = JAFolderTypeEnum.SendItem;
                Nodes.ObjectBase = new ClassLibrary.JAction("GetReferNodeSend", "Automation.JKartable.GetNode", new object[] { JAFolderTypeEnum.SendItem }, null);
                Nodes.DataTable = JARefers.GetReferSend(ClassLibrary.JMainFrame.CurrentPostCode, 0, pFolderCode);
                Nodes.hidColumns = "Code,ObjectCode,ClassName,View_date_Time,externalObjectcode,Active,ObjectType,action,DynamicClassCode";
                if (pFolderCode == 0)
                    Nodes.Name = "JKartableSendBOX";
                else
                    Nodes.Name = "FolderInBOX_" + pFolderCode.ToString();

                Timer.Start();
            }

            public void GetFolderRefer(int pFolderCode)
            {
                JAFolder Folder = new JAFolder(pFolderCode);
                if (Folder.FolderType == JAFolderTypeEnum.Inbox.GetHashCode())
                    GetInBoxRefer(pFolderCode);
                if (Folder.FolderType == JAFolderTypeEnum.SendItem.GetHashCode())
                    GetReferSend(pFolderCode);
            }

            public System.Data.DataTable GetNewRefer()
            {
                if (Nodes.Name == "JKartableInBOX")
                {
                    return JARefers.GetReferInInbox(ClassLibrary.JMainFrame.CurrentPostCode, JDataBase.DataTableToStringtArray(Nodes.DataTable, "Code"), 0);
                }
                return null;
            }

            #endregion GetInfo
            //Node
            #region Node
            public ClassLibrary.JNode Box(JAFolderTypeEnum pKartabletype)
            {
                CurrentKartable = pKartabletype;

                JAFolders Folders = new JAFolders();
                JAFolder[] Folder = Folders.GetMainFolders((int)pKartabletype);

                ClassLibrary.JNode Node = new ClassLibrary.JNode(0, "Automation.JKartable");
                Node.Name = pKartabletype.ToString();
                Node.Popup.Insert(new ClassLibrary.JAction("New Folder", "Automation.JAFolder.showDialog", new object[] { (int)pKartabletype, Node.Code }, null));
                if (pKartabletype == JAFolderTypeEnum.Inbox)
                {
                    Node.MouseClickAction = new ClassLibrary.JAction(pKartabletype.ToString(), "Automation.JKartable.GetInBoxRefer");
                    Node.Icone = JImageIndex.Kartabl.GetHashCode();
                }
                if (pKartabletype == JAFolderTypeEnum.SendItem)
                {
                    Node.MouseClickAction = new ClassLibrary.JAction(pKartabletype.ToString(), "Automation.JKartable.GetReferSend");
                    Node.Icone = JImageIndex.KartablSender.GetHashCode();
                }
                if (pKartabletype == JAFolderTypeEnum.Archive)
                    Node.MouseClickAction = new ClassLibrary.JAction(pKartabletype.ToString(), "Automation.JKartable.GetReferArchive");

                Nodes.hidColumns = "R.Code,ObjectCode,externalcode,action,Objecttype";

                Node.Childs = new ClassLibrary.JNode[Folder.Length];
                int count = 0;
                foreach (JAFolder F in Folder)
                {
                    Node.Childs[count++] = F.GetNode();
                }                
                return Node;
            }

            public ClassLibrary.JNode[] TreeView()
            {

                return null;
            }


            public void DeleteFromInbox()
            {
            }

            public void AddToInbox()
            {
            }

            public void DeleteFromSend()
            {
            }

            public void AddToSend()
            {
            }

            #endregion Node
        }
}
