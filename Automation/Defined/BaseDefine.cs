using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Automation
{
    class JABaseDefine : JBaseDefine
    {
        /// <summary>
        /// انواع ضمیمه نامه
        /// </summary>
        public static readonly int AttachCode = 100;
        /// <summary>
        /// نحوه ارسال نامه
        /// </summary>
        public static readonly int SendTypeCode = 101;
        /// <summary>
        /// نحوه  دریافت نامه
        /// </summary>
        public static readonly int ReciveTypeCode = 102;
        /// <summary>
        /// انواع اقدامات
        /// </summary>
        public static readonly int EmpriseTypeCode = 103;
        /// <summary>
        /// انواع ارجاع
        /// </summary>
        public static readonly int ReferTypeCode = 104;
        /// <summary>
        /// انواع نتایج پیگیری
        /// </summary>
        public static readonly int PursueTypeCode = 105;
        /// <summary>
        /// انواع فوریت نامه
        /// </summary>
        public static readonly int UrgencyTypeCode = 106;       
        /// <summary>
        /// انواع محرمانگی
        /// </summary>
        public static readonly int PrivacyTypeCode = 107;
        public void ListView()
        {

            Nodes.AddColumn("Name");

            Nodes.Insert(GetNode(AttachCode));
            Nodes.Insert(GetNode(SendTypeCode));
            Nodes.Insert(GetNode(ReciveTypeCode));
            Nodes.Insert(GetNode(EmpriseTypeCode));
            Nodes.Insert(GetNode(ReferTypeCode));
            Nodes.Insert(GetNode(PursueTypeCode));

        }

        public JNode[] TreeView()
        {

            JNode[] N = new JNode[6];

            N[0] = GetNode(AttachCode);
            N[1] = GetNode(SendTypeCode);
            N[2] = GetNode(ReciveTypeCode);
            N[3] = GetNode(EmpriseTypeCode);
            N[4] = GetNode(ReferTypeCode);
            N[5] = GetNode(PursueTypeCode);

            return N;
        }

    }
    class JEmpBaseDefine : JBaseDefine
    {
        
        /// <summary>
        /// انواع شته تحصیلی
        /// </summary>
        public static readonly int MajorTypeCode = JBaseDefine.MajorCode;

        public void ListView()
        {
            Nodes.AddColumn("Name");

            Nodes.Insert(GetNode(MajorTypeCode));
        }

        public JNode[] TreeView()
        {
            JNode[] N = new JNode[6];

            N[0] = GetNode(MajorTypeCode);
            return N;
        }

    }
}
