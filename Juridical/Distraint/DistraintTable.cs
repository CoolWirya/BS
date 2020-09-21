using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDistraintTable:JTable
    {
        public JDistraintTable()
            : base(JTableNamesLegal.Distraint)
        {
        }
        /// <summary>
        /// تاریخ توقیف
        /// </summary>
        public DateTime DistDate;
        /// <summary>
        /// موضوع توقیف:1-شخص 2-دارایی 3-بخشی از دارایی
        /// </summary>
        public int Subject;
        /// <summary>
        /// کدشخص توقیف شده
        /// </summary>
        public long Person;
        /// <summary>
        /// کددارایی توقیف شده
        /// </summary>
        public int Asset;
        /// <summary>
        /// کد حکم توقیف اموال
        /// </summary>
        public int Committal;
        /// <summary>
        /// کد حکم رد توقیف اموال
        /// </summary>
        public int NotCommittal;
        /// <summary>
        /// توضیحات
        /// </summary>
        public string Comment;
        /// <summary>
        /// کد شخصی که جزئی از دارائی های آن توقیف شده است
        /// </summary>
        public int AssetSharePerson;
        /// <summary>
        /// نوع توقیف-حکم یا دستور
        /// </summary>
        public JArrestType ArrestType;
        /// <summary>
        /// مقام ارسال کننده دستور
        /// </summary>
        public string OrderSender;
        /// <summary>
        /// توضیحات مربوط به دستور توقیف
        /// </summary>
        public string OrderComment;
        /// <summary>
        /// توقیف فعال
        /// </summary>
        public bool Active;
      
        /// <summary>
        /// تاریخ رفع توقیف
        /// </summary>
        public DateTime UnDistDate;
       
        /// <summary>
        /// شرح رفع توقیف
        /// </summary>
        public string UnDistComment;
        
        /// <summary>
        /// حکم رفع توقیف
        /// </summary>
        public int UnDistCommittal;
        /// <summary>
        /// حکم / دستور رفع توقیف
        /// </summary>
        public int UnDistNotCommittal;
       
        /// <summary>
        /// فرستنده دستور رفع توقیف
        /// </summary>
        public string UnDistOrderSender;
        /// <summary>
        /// دستور رفع توقیف
        /// </summary>
        public string OrderCommentUnDist;
        
        
    }
    enum JDistraintTableEnum
    {
        Code,
         /// <summary>
        /// نوع :توقیف یا ممنوع المعامله
        /// </summary>
        Type,
        /// <summary>
        /// موضوع توقیف:1-شخص 2-دارایی 3-بخشی از دارایی
        /// </summary>
        Subject,
        /// <summary>
        /// کدشخص توقیف شده
        /// </summary>
        Person,
        /// <summary>
        /// کددارایی توقیف شده
        /// </summary>
        Asset,
        /// <summary>
        /// کد جزئی از دارایی توقیف شده
        /// </summary>
        AssetShare,
        /// <summary>
        /// کد حکم توقیف اموال
        /// </summary>
        Committal,
        /// <summary>
        /// کد حکم رد توقیف اموال
        /// </summary>
        NotCommittal,
        /// <summary>
        /// توضیحات
        /// </summary>
        Comment,
         /// <summary>
        /// کد شخصی که جزئی از دارائی های آن توقیف شده است
        /// </summary>
        AssetSharePerson,
        /// <summary>
        /// نوع توقیف-حکم یا دستور
        /// </summary>
        ArrestType,
        /// <summary>
        /// مقام ارسال کننده دستور
        /// </summary>
        OrderSender,
        /// <summary>
        /// توضیحات مربوط به دستور توقیف
        /// </summary>
       rderComment,


        
    }
   
    public enum JDistraintSubjectEnum
    {
        Person=1,
        Asset=2,
        AssetShare=3,

    }
}
