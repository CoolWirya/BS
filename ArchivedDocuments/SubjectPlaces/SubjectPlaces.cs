using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace ArchivedDocuments
{
    public class JSubjectPlaces 
    {
        public int Code
        {
            get;
            set;
        }
        public int PlaceCode
        {
            get;
            set;
        }
        public int SubjectCode
        {
            get;
            set;
        }
    }


        /// <summary>
        /// کد موضوع بایگانی 
    ////////-----------------  کدهای ثابت که باید جهت طبقه بندی موضوعی در نظر گرفته شوند //////////
    ///-----------------------              و توسط کاربر قابل تغییر نباشند            /////////////
    ///////////////////---------------------------------------------------------------/////////////
    /// </summary>
    public enum JConstantArchiveSubjects
    {
        /// <summary>
        /// تصویر شخص
        /// </summary>        
        ImagesArchiveCode = 2,  
        /// <summary>
        /// تصویر امضاء
        /// </summary>
        SignatureArchiveCode = 3,  
        /// <summary>
        /// تصویر شخص
        /// </summary>
        OtherImagesArchiveCode = 4,  
        /// <summary>
        /// تصویر آرم شرکتها 
        /// </summary>
        LegalPersonArm = 5,
        /// <summary>
        /// ضمائم نامه ها
        /// </summary>
        LetterAttachment = 6,
        /// <summary>
        /// متن نامه
        /// </summary>
        Letter = 7,
    }
    /// <summary>
    /// کدهای ثابت مکانهای بایگانی
    /// </summary>
    public enum JConstantArchivePalces
    {
        /// <summary>
        /// شرکت
        /// </summary>
        GeneralArchive = 1,
        /// <summary>
        /// واحد آرشیو
        /// </summary>
        ArchiveUnit = 2,
        /// <summary>
        /// ضمائم نامه ها
        /// </summary>
        LetterAttachment = 3,
        /// <summary>
        /// متن نامه
        /// </summary>
        Letter = 4,
    }
}
