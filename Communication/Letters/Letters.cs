using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using Automation;
using System.Data;

namespace Communication 
{
    /// <summary>
    /// کلاس پایه نامه
    /// </summary>
    public class JCLetter : JCommunication
    {
        // سازنده های کلاس
        #region Constructors
                /// <summary>
        /// سازنده
        /// </summary>
        public JCLetter()
        {
        }
        #endregion Constructors
        //properties
        #region Properties
        /// <summary>
        /// کد رکورد در جدول
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
        
        #endregion Properties
        // Insert , Update , Delete
        #region BaseFunctions

        #endregion BaseFunctions
        //Forms
        #region Forms


        public void ReferShow( int pLetterCode, int pReferCode)
        {
            Current_Refer_Code = pReferCode;
            JCLetterRegisterImport LRI = new JCLetterRegisterImport(pLetterCode);
            JFormState state;
            if(LRI.register_no != 0)
                state=JFormState.ReadOnly;
            else
                state = JFormState.Update;
            JfrmLetterRegister tmpJfrmLetterRegisterImport = new JfrmLetterRegister(LRI.letter_type, state, pLetterCode, pReferCode);
            tmpJfrmLetterRegisterImport.ShowDialog();
        }

        public JNode ReferShow(System.Data.DataRow DR)
        {
            int LetterCode = (int)DR[Objects.externalcode.ToString()];
            int ReferCode = (int)DR[Refer.Code.ToString()];

            JNode n = new JNode(LetterCode, this);
            n.Icone = (int)JImageIndex.mail_48;
            n.MouseDBClickAction = new JAction("Show", "Communication.JCLetter.ReferShow", new object[] { LetterCode, ReferCode }, null);
            return n;
        }
        /// <summary>
        /// گرفتن داده ها برای نمایش در کارتابل
        /// </summary>
        /// <param name="pLetterCode"></param>
        /// <param name="pReferCode"></param>
        /// <returns></returns>
        public DataTable ActionGetData(int pLetterCode, int pReferCode)
        {
            return null;
        }


        public  static string _setLetterDescriptionObject(int pletter_status, string pletter_no)
        {
            string _tempText = " ";

            if (pletter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
            {
                _tempText = "پیش نویس ";
            }
            if (pletter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
            {
                _tempText = "پیش نویس امضا شده";
            }
            if (pletter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
            {
                _tempText = "نامه به شماره : " + pletter_no;
            }
            return _tempText;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Refer"></param>
        /// <param name="pDB"></param>
        /// <returns>
        /// 0 dont send refer
        /// 1 can send refer
        /// 2 refer send you cant need send it
        /// </returns>
        public int BeforRefer(JARefer Refer, JDataBase pDB)
        {
            JAObject obj = new JAObject();
            obj.GetData(Refer.object_code,pDB);

            JCLetterRegister LR = new JCLetterRegister(obj.externalcode);


            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
            {
                Refer.ReferGroup = 1;
            }
            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
            {
                Refer.ReferGroup = 2;
            }
            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
            {
                Refer.ReferGroup = 3;
            }

            Refer.DescriptionObject = _setLetterDescriptionObject(LR.letter_status, LR.letter_no) + JLanguages._Text(ClassLibrary.Domains.JAutomation.JReferStatus.GetName(ClassLibrary.Domains.JAutomation.JReferStatus.Sent));
            //اگر پیشنویس باشد
            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Minute)
                return 0;
            // اگر نامه امضا شده باشد فقط میتوان برای امضا کننده برگشت زد
            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Accept)
            {
                //if (Refer.receiver_post_code != LR.sender_post_code)
                //{
                //    return -1;
                //}
                //else
                //{
                    LR.Current_Refer_Code = Refer.parent_code;
                //  LR.letter_status = ClassLibrary.Domains.JCommunication.JLetterStatus.Minute;
                    return LR.RegisterRefer(Refer, pDB);
                //}
            }
            //اگر نامه باشد
            if (LR.letter_status == ClassLibrary.Domains.JCommunication.JLetterStatus.Letter)
            {
                LR.Current_Refer_Code = Refer.parent_code;
                return LR.RegisterRefer(Refer, pDB);
            }
            return 1;
        }

        #endregion Forms
        // GetInfo
        #region GetInfo

        #endregion GetInfo
        // Node
        #region Node

        public void RunAction()
        {
        }
        #endregion Node


    }
    /// <summary>
    ///  کلاس پایه لیست نامه ها
    /// </summary>
    public class JCLetters : JCommunication
    {
        // سازنده های کلاس
        #region Constructors
        /// <summary>
        /// سازنده
        /// </summary>
        public JCLetters()
        {
        }
        #endregion Constructors
        // Peroperties
        #region Properties

        private JCStorageLetterNo[] _Items;
        public JCStorageLetterNo[] Items
        {
            get
            {
                return _Items;
            }
        }
        #endregion Properties
        // View Nodes
        #region View
        public JNode[] TreeView()
        {

            JNode[] N = new JNode[0];
            //N[0] = (JAStaticNode._LetterRegisterImportsNode());
            //N[1] = (JAStaticNode._LetterRegisterExportsNode());
            //N[2] = (JAStaticNode._LetterRegisterInternalsNode());
            return N;
        }
        public void ListView()
        {
            Nodes.ObjectBase = new JAction("test", "Communication.JCLetterRegister.GetNode", null, new object[] { 0 });
            Nodes.DataTable = new JCLetterRegister(0).FindMinute(JMainFrame.CurrentUserCode, JMainFrame.CurrentPostCode,0);

            JToolbarNode RegisterInternalLetter = new JToolbarNode();
            RegisterInternalLetter.Icon = JImageIndex.mail_48;
            RegisterInternalLetter.Hint = "ثبت نامه داخلی";
            RegisterInternalLetter.Name = "ثبت نامه داخلی";
            RegisterInternalLetter.Click = new JAction("JCLetterRegisterImport", "Communication.JCLetterRegisterInternal.ShowDialog", new object[] { 0 }, new object[] { 0 });
            RegisterInternalLetter.ItemType = JToolbarNodeType.Button;
            Nodes.AddToolbar(RegisterInternalLetter);

            JToolbarNode RegisterImpoertLetter = new JToolbarNode();
            RegisterImpoertLetter.Icon = JImageIndex.InMail;
            RegisterImpoertLetter.Hint = "ثبت نامه وارده به سازمان";
            RegisterImpoertLetter.Name = "ثبت نامه وارده به سازمان";
            RegisterImpoertLetter.Click = new JAction("JCLetterRegisterImport", "Communication.JCLetterRegisterImport.ShowDialog", new object[] { 0 }, new object[] { 0 });
            RegisterImpoertLetter.ItemType = JToolbarNodeType.Button;
            Nodes.AddToolbar(RegisterImpoertLetter);

            JToolbarNode RegisterExportLetter = new JToolbarNode();
            RegisterExportLetter.Icon = JImageIndex.ExMail;
            RegisterExportLetter.Hint = "ثبت نامه ارسالی به خارج از سازمان";
            RegisterExportLetter.Name = "ثبت نامه ارسالی به خارج از سازمان";
            RegisterExportLetter.Click = new JAction("JCLetterRegisterImport", "Communication.JCLetterRegisterExport.ShowDialog", new object[] { 0 }, new object[] { 0 });
            RegisterExportLetter.ItemType = JToolbarNodeType.Button;
            Nodes.AddToolbar(RegisterExportLetter);

            JToolbarNode SearchLetter = new JToolbarNode();
            SearchLetter.Icon = JImageIndex.finddoc;
            SearchLetter.Hint = "جستجوی نامه";
            SearchLetter.Name = "جستجوی نامه";
            SearchLetter.Click = new JAction("SearchLetter", "Communication.JCSearchLetter.ShowForm");
            SearchLetter.ItemType = JToolbarNodeType.Button;
            Nodes.AddToolbar(SearchLetter);

            Nodes.hidColumns = @"letter_type,letter_status,subject_code,register_date_time,register_no,letter_no,incoming_no,incoming_date,incoming_signature_person,sender_post_code,sender_code,sender_external_code,receiver_post_code,receiver_code,receiver_external_code,register_post_code,register_user_code,receiver_type,secretariatename";
            //JToolbarNode DeleteLetter = new JToolbarNode();
            //DeleteLetter.Icon = JImageIndex.mail_48;
            //DeleteLetter.Click = new JAction("JCLetterRegisterImport", "Communication.JCLetterRegister.Delete_Nodes", null, new object[] { 0 });
            //DeleteLetter.ItemType = JToolbarNodeType.Button;
            //Nodes.AddToolbar(DeleteLetter);
        }

        #endregion View
    }
}
