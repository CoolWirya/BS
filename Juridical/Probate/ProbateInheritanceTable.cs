using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JProbateInheritanceTable:JTable
    {
        public JProbateInheritanceTable()
            : base(JTableNamesLegal.ProbateInheritance)
        {
        }
       
        /// <summary>
        /// 
        /// </summary>
        public int CodeProbate;
        /// <summary>
        ///
        /// </summary>
        public int CodePerson;
        /// <summary>
        ///
        /// </summary>
        public float inheritance;
        /// <summary>
        /// میزان سهم بصورت رشته
        /// </summary>
        public string inherText;
        /// <summary>
        /// کد نسبت خانوادگی شخص با متوفی
        /// </summary>
        public int RelationFamily;
        /// <summary>
        /// شرح
        /// </summary>
        public string InherDesc;
    }
    enum JProbateInheritanceTableEnum
    {
        Code,
        CodeProbate,
        CodePerson,
        inheritance,
        inherText,
        Name, Fam, ShSh, FatherName, RelationFamily, RelationFamilyName
    }
}
