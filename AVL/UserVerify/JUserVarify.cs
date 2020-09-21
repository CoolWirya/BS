using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.UserVerify
{
   public  class JUserVarify:ClassLibrary.JSystem
    {
        public string userID { get; set; }
        public string email { get; set; }
        public string phonenumber { get; set; }
        public bool phoneVarified { get; set; }
        public bool emailVarified { get; set; }
        public bool Varified()
        {
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"select * from AVLUserVarify 
 WHERE userID=@userID AND phoneVarified = @phoneVarified ");
                db.AddParams("@userID", this.userID);
                db.AddParams("@phoneVarified", true);
                if (db.Query_DataTable().Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Update()
        {
            //JPersonAddressTable addressTable = new JPersonAddressTable();
            //addressTable.SetValueProperty(this);
            //return addressTable.Update();
           ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"UPDATE AVLUserVarify SET
                email=@email , phonenumber = @phonenumber, phoneVarified = @phoneVarified, emailVarified = @emailVarified 
 WHERE userID=@userID");
                db.AddParams("@email", this.email);
                db.AddParams("@phonenumber", this.phonenumber);
                db.AddParams("@phoneVarified", this.phoneVarified);
                db.AddParams("@emailVarified", this.emailVarified);
                db.AddParams("@userID", this.userID);
                db.beginTransaction("UpdateAVLUserVarify");
                if (db.Query_Execute() > -1)
                {
                    if (db.Commit())
                        return true;
                }
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

        public bool Insert()
        {
            AVL.UserVerify.JUserVarifyTable uservarifytable = new AVL.UserVerify.JUserVarifyTable();
            uservarifytable.SetValueProperty(this);
            if (uservarifytable.Insert()>0)
                return true;
            return false;
        }   
        public bool VarifyPhonenumber()
        {
            //JPersonAddressTable addressTable = new JPersonAddressTable();
            //addressTable.SetValueProperty(this);
            //return addressTable.Update();
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"UPDATE AVLUserVarify SET  phoneVarified = @phoneVarified
 WHERE userID=@userID AND  phonenumber = @phonenumber AND  email=@email");
                db.AddParams("@email", this.email);
                db.AddParams("@phonenumber", this.phonenumber);
                db.AddParams("@phoneVarified", this.phoneVarified);
                db.AddParams("@userID", this.userID);
                db.beginTransaction("UpdateAVLUserVarify");
                if (db.Query_Execute() > -1)
                {
                    if (db.Commit())
                        return true;
                }
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

       public bool VarifyEmail()
        {
            //JPersonAddressTable addressTable = new JPersonAddressTable();
            //addressTable.SetValueProperty(this);
            //return addressTable.Update();
            ClassLibrary.JDataBase db = ClassLibrary.JGlobal.MainFrame.GetDBO();
            try
            {
                db.setQuery(@"UPDATE AVLUserVarify SET emailVarified = @emailVarified 
 WHERE userID=@userID AND   email=@email AND  phonenumber = @phonenumber ");
                db.AddParams("@email", this.email);
                db.AddParams("@phonenumber", this.phonenumber);
                db.AddParams("@emailVarified", this.emailVarified);
                db.AddParams("@userID", this.userID);
                db.beginTransaction("UpdateAVLUserVarify");
                if (db.Query_Execute() > -1)
                {
                    if (db.Commit())
                        return true;
                }
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            catch (Exception ex)
            {
                ClassLibrary.JSystem.Except.AddException(ex);
                db.Rollback("UpdateAVLUserVarify");
                return false;
            }
            finally
            {
                db.Dispose();
            }
        }

    }
}
