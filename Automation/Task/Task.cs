using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{

   public class JTask : JAutomation
    {

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// نوع شی
        /// </summary>
        public int previouse_task_code { get; set; }
        /// <summary>
        /// آدرس تابعی که هنگام انتخاب شی باید اجرا شود
        /// </summary>
        public string next_task_code { get; set; }
        /// <summary>
        /// کد شی در سیستم خودش
        /// </summary>
        public int objecttype { get; set; }
        /// <summary>
        /// کد پست فرستنده
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// کد کاربر فرستنده
        /// </summary>
        public string description { get; set; }        

        #endregion

        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JTask()
        {
        }
        #endregion

        // Insert , Update , Delete
        #region BaseFunctions
        public int Insert()
        {
            JTaskTable ActionTable = new JTaskTable();
            ActionTable.SetValueProperty(this);
            Code = ActionTable.Insert();
            if (Code > 0)
            {
                //JRefer Refer = new JRefer();
                //Refer.ObjectCode = Code;
                //Refer.Reciever = Creator;
                //Refer.Insert();
            }
            return Code;
        }

        public void Delete()
        {
            JTaskTable ActionTable = new JTaskTable();
            ActionTable.SetValueProperty(this);
            ActionTable.Delete();
        }

        public void Save()
        {
            JTaskTable ActionTable = new JTaskTable();
            ActionTable.SetValueProperty(this);
            ActionTable.Update();
        }
        #endregion BaseFunctions

        //Forms
        #region Forms

        #endregion Forms

    }

    public class JTasks : JAutomation
    {
              
    }


}
