using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    /// <summary>
    /// موضوع نامه محضر
    /// </summary>
    public class JNotaryLetterSubject:JSubBaseDefine
    {
        public JNotaryLetterSubject()
            : base(JBaseDefineLegal.NotaryLetterSubject)
        {
        }
    }
    public class JNotaryLetterSubjects : JSubBaseDefines
    {
        public JNotaryLetterSubjects()
            : base(JBaseDefineLegal.NotaryLetterSubject)
        {
        }
    }
    
}
