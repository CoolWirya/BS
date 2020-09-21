using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    class JPersonPetitionTable : JTable
    {
        #region Property
        /// <summary>
        /// کد دادخواست یا شکواییه
        /// </summary>
        public int PetitionCode;
        /// <summary>
        /// کد شخص
        /// </summary>
        public int PersonCode;
        /// <summary>
        /// نوع شخص
        /// </summary>
        public int Type;

        #endregion

        public JPersonPetitionTable()
            : base(JTableNamesLegal.PersonPetition, "")
        {
        }
    }
}
