using Legal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJsonAdditionalLibrary.WebLegal.Contract.Forms.SubjectContract
{
	public class JSubjectContract
	{
		public int SubjectCode { get; set; }
		public int FinanceCode { get; set; }
		public bool NoFinance { get; set; }

		public string PreSearchGround()
		{
			JContractdefine contractDefine = new JContractdefine(SubjectCode);
			JContractDynamicType dynamicContract = new JContractDynamicType(contractDefine.ContractType);
			if ((FinanceCode == 0) && (!NoFinance))
				return "ClassName:" + dynamicContract.ClassName + "?!?" + "Code:" + dynamicContract.Code;
			else
				return "ClassName:-1?!?Code:-1";
		}
	}
}