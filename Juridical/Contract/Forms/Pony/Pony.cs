using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;
using ClassLibrary;

namespace Legal
{
    public class JPony : JLegal
    {
        #region Properties

        public int Code { get; set; }
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractSubjectCode { get; set; }
        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime Create_Date { get; set; }
        /// <summary>
        /// اجاره ماهیانه
        /// </summary>
        public bool PriceMonth { get; set; }
        /// <summary>
        /// مبلغ قرض الحسنه
        /// </summary>
        public bool Price { get; set; }
        /// <summary>
        /// مبلغ شارژ ماهانه
        /// </summary>
        public bool Sharj { get; set; }
        /// <summary>
        /// حق التحریر
        /// </summary>
        public bool RightStationery { get; set; }
        /// <summary>
        /// تبلیغات
        /// </summary>
        public bool Advertisement { get; set; }
        /// <summary>
        /// شهرداری
        /// </summary>
        public bool mayor { get; set; }
        /// <summary>
        /// دارایی
        /// </summary>
        public bool TaxOffice { get; set; }
        /// <summary>
        /// بیمه
        /// </summary>
        public bool InsuranceOffice { get; set; }
        /// <summary>
        /// برق
        /// </summary>
        public bool Power { get; set; }
        /// <summary>
        /// تلفن
        /// </summary>
        public bool Telephone { get; set; }
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// امضا موجر
        /// </summary>
        public bool RenterSignature { get; set; }
        /// <summary>
        /// امضا مساجر
        /// </summary>
        public bool LodgerSignature { get; set; }
        /// <summary>
        /// امضا اداری
        /// </summary>
        public bool OfficeSignature { get; set; }
        /// <summary>
        /// امضا مدیر
        /// </summary>
        public bool ManagerSignature { get; set; }

        #endregion

        #region سازنده

        public JPony()
        {
        }

        public JPony(int pCode)
        {
            Code=pCode;
            if (pCode > 0)
                GetData(Code);
        }
         
        #endregion

        #region Methods Insert,Update,delete,GetData
         
        /// <summary>
        /// درج 
        /// </summary>
        /// <returns></returns>
        public int Insert(JDataBase pDB)
        {
            JPonyTable PDT = new JPonyTable();
            try
            {
                    PDT.SetValueProperty(this);
                    Code = PDT.Insert(pDB);
                    //Nodes.DataTable.Merge(JSubjectContracts.GetDataTable(Code));
                    if(Code > 0)
                        Histroy.Save(this, PDT, Code, "Insert");
                    return Code;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return -1;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int Insert()
        {
            try
            {
                JPonyTable PDT = new JPonyTable();
                PDT.SetValueProperty(this);
                Code = PDT.Insert();
                //Nodes.DataTable.Merge(JSubjectContracts.GetDataTable(Code));
                if(Code > 0)
                    Histroy.Save(this, PDT, Code, "Insert");
                return Code;
            }
            catch (Exception ex)
            {
                 Except.AddException(ex);
                 return -1;
            }
            finally
            {
                //DB.Dispose();
            }
        }
        /// <summary>
        ///بروزرسانی   
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            JPonyTable PDT = new JPonyTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Update())
                {
                    Histroy.Save(this, PDT, PDT.Code, "Update");
                    //Nodes.Refreshdata(Nodes.CurrentNode, JSubjectContracts.GetDataTable(Code).Rows[0]);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// حذف 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool delete()
        {
            JPonyTable PDT = new JPonyTable();
            try
            {
                PDT.SetValueProperty(this);
                if (PDT.Delete())
                {
                    Histroy.Save(this, PDT, PDT.Code, "Delete");
                    return true;
                }
                else
                    return false;
                //if (JMessages.Question("Delete", "Delete") == System.Windows.Forms.DialogResult.Yes && PDT.Delete())
                //{
                //    ArchivedDocuments.JArchiveDocument AD = new ArchivedDocuments.JArchiveDocument();
                //    AD.DeleteArchive("Legal.JNotaryLetter", Code, false);
                //    Nodes.Delete(Nodes.CurrentNode);
                //    Histroy.Save(PDT, Code, "Delete");
                //    return true;
                //}
                //else
                //    return false;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return false;
            }
            finally
            {
                PDT.Dispose();
            }
        }
        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetData(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.Pony + " WHERE Code=" + pCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }

        /// <summary>
        /// چک کردن وجود اطلاعات 
        /// </summary>
        /// <param name="pCode"></param>
        /// <returns></returns>
        public bool GetDataByContractCode(int pContractCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                DB.setQuery("SELECT * FROM " + JTableNamesContracts.Pony + " WHERE ContractSubjectCode=" + pContractCode.ToString());
                DB.Query_DataReader();
                if (DB.DataReader.Read())
                {
                    JTable.SetToClassProperty(this, DB.DataReader);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
            }
            finally
            {
                DB.Dispose();
            }
            return false;
        }
        /// <summary>
        /// جستجو نامه محضر 
        /// </summary>
        /// <returns></returns>
        public DataTable Search(DateTime EndDate)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                //string Exp = "";
                //if (JDateTime.FarsiDate(Date) != "") Exp = Exp + " And Date Between @date And @date1 ";
                //DB.Params.Add("@date", Date);
                //DB.Params.Add("@date1", EndDate);
                ////if (Result != "") Exp = Exp + " And Result Like '%" + Result + "%'";
                ////if (Reasons != "") Exp = Exp + " And Like Reasons '%" + Reasons + "%'";
                ////if (Subject != "")        Exp = Exp + " And Like Subject '%" + Subject + "%'";
                //DB.setQuery("SELECT * FROM " + JTableNamesLegal.SubjectContract + " N inner join legPetition P on P.Code=N.PetitionCode WHERE 1=1 " + Exp);
                //return DB.Query_DataTable();
                return null;
            }
            catch (Exception ex)
            {
                Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        #endregion

        #region Nodes

        public void ShowDialog()
        {
            if (this.Code == 0)
            {
                JPonyForm PE = new JPonyForm(0);
                PE.State = JFormState.Insert;
                PE.ShowDialog();
            }
            else
            {
                JPonyForm PE = new JPonyForm(this.Code);
                PE.State = JFormState.Update;
                PE.ShowDialog();
            }
        }

        public JNode GetNode(DataRow pRow)
        {
            JNode node = new JNode((int)pRow["Code"], "Legal.JPony");
            node.Icone = JImageIndex.advocacy.GetHashCode();
            node.Name = pRow["Create_Date"].ToString();
            node.Hint = JLanguages._Text("ManagerSignature:") + " " + pRow["ManagerSignature"] + "\n" +
                //JLanguages._Text("Type:") + " " + pRow[LegAdvocacy.Type.ToString()] + "\n" +
                       JLanguages._Text("Description:") + " " + pRow["Desc"];
            /// اکشن ویرایش
            JAction editAction = new JAction("Edit...", "Legal.JPony.ShowDialog", null, new object[] { node.Code });
            node.MouseDBClickAction = editAction;
            node.EnterClickAction = editAction;
            /// اکشن حذف
            JAction deleteAction = new JAction("Delete...", "Legal.JPony.DeleteManual", null, new object[] { node.Code });
            node.DeleteClickAction = deleteAction;
            //JPopupMenu pMenu = new JPopupMenu("ClassLibrary.JPerson", node.Code);
            /// اکشن جدید
            JAction newAction = new JAction("New...", "Legal.JPony.ShowDialog", null, null);

            node.Popup.Insert(deleteAction);
            node.Popup.Insert(editAction);
            node.Popup.Insert(newAction);

            return node;
        }
        #endregion
    }

    public class JPonys : JSystem
    {
        public JPonys[] Items = new JPonys[0];
        //  public String OrderName;
        public JPonys()
        {
            // OrderName = "Fam";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            return GetDataTable(0);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTable(int pCode)
        {
            JDataBase DB = JGlobal.MainFrame.GetDBO();
            try
            {
                string WHERE = "select * from " + JTableNamesContracts.Pony;
                if (pCode != 0)
                    WHERE = WHERE + " WHERE Code = " + pCode;
                DB.setQuery(WHERE);
                return DB.Query_DataTable();
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
                return null;
            }
            finally
            {
                DB.Dispose();
            }
        }

        public void ListView()
        {
            Nodes.ObjectBase = new JAction("GetPony", "Legal.JPony.GetNode");
            Nodes.DataTable = GetDataTable();

            JAction newAction = new JAction("New...", "Legal.JPony.ShowDialog", null, null);
            Nodes.GlobalMenuActions.Insert(newAction);
            JToolbarNode TN = new JToolbarNode();
            TN.Icon = JImageIndex.Add;
            TN.Hint = "New...";
            TN.Click = newAction;
            Nodes.AddToolbar(TN);

            //ListView(OrderName, "");
        }
    }
}
