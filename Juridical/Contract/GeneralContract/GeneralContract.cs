using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public struct ArgParameter
        {
            public string FormName;
            public string PrpertyName;
            public object Value;
        }
    public class JGeneralContractVirtual : JSystem
    {
        int Code;
        public JGeneralContractVirtual(int pCode)
        {
            Code = pCode;
        }
        public void Show()
        {
            JGeneralContract C = new JGeneralContract(0, Code, true);
            C.ShowForms();
        }
    }
        public class JGeneralContract : JSystem
        {

            public ArgParameter tmpArgParameter;

        private int _GroupCode;
        private int _ConcernCode;

        /// <summary>
        /// فرمهای قرارداد
        /// </summary>
        public JContractForms ContractForms
        {
            get;
            set;
        }

        /// <summary>
        /// سازنده
        /// </summary>
        /// <param name="pTypeCode">نوع قرارداد</param>
        public JGeneralContract(int pTypeCode)
            : this(pTypeCode, 0)
        {
        }

        public JGeneralContract(int pTypeCode, int pCCode)
            : this(pTypeCode, pCCode, false)
        {
        }

        public JGeneralContract(int pTypeCode, int pCCode, bool pView)
            : this(pTypeCode, pCCode, 0, pView)
        {
        }

        public JGeneralContract(int pTypeCode, int pCCode, int pFinanceCode, bool pView)
            : this(pTypeCode, pCCode, pFinanceCode, pView, 0,0,0)
        {

        }
        JBaseContractForm.JStateContractForm State;
        public JGeneralContract(int pTypeCode, int pCCode, int pFinanceCode, bool pView, int pSheetCode, int pGroupCode, int pConcernCode)
        {
            _GroupCode = pGroupCode;
            _ConcernCode = pConcernCode;

            if (pCCode > 0)
                State = JBaseContractForm.JStateContractForm.Update;
            if (pView)
                State = JBaseContractForm.JStateContractForm.View;
            GetData(pTypeCode, pCCode, pFinanceCode, pView, null);
            LoadForms(pTypeCode, pCCode, State, pSheetCode, pGroupCode, pConcernCode);
        }

        public JGeneralContract(int pTypeCode, int pCCode, int pFinanceCode, bool pView, int pSheetCode,ArgParameter[] pArg)
        {
            if (pCCode > 0)
                State = JBaseContractForm.JStateContractForm.Update;
            if (pView)
                State = JBaseContractForm.JStateContractForm.View;
            GetData(pTypeCode, pCCode, pFinanceCode, pView, pArg);
            LoadForms(pTypeCode, pCCode, State, pSheetCode);
        }

        public JGeneralContract(int pTypeCode, int pCCode, JBaseContractForm.JStateContractForm pView, ArgParameter[] pArg)
        {
            if (JBaseContractForm.JStateContractForm.View == pView)
                GetData(pTypeCode, pCCode, 0, true, pArg);
            else
                GetData(pTypeCode, pCCode, 0, false, pArg);
            LoadForms(pTypeCode, pCCode, pView, 0);
        }

        public void LoadForms(int pTypeCode, int pCCode, bool pView)
        {
            if (pCCode > 0)
                State = JBaseContractForm.JStateContractForm.Update;
            if (pView)
                State = JBaseContractForm.JStateContractForm.View;
            LoadForms(pTypeCode, pCCode, State, 0);
        }

        public void LoadForms(int pTypeCode, int pCCode, JBaseContractForm.JStateContractForm pView, int pSheetCode)
        {
            LoadForms(pTypeCode, pCCode, pView, pSheetCode, 0, 0);
        }

        public void LoadForms(int pTypeCode, int pCCode, JBaseContractForm.JStateContractForm pView, int pSheetCode, int pGroupCode , int pConncernCode)
        {
            _GroupCode = pGroupCode;
            _ConcernCode = pConncernCode;
            if (pTypeCode == 0)
                pTypeCode = ContractForms.Contract.Type;

            JContractFormsOrders formOrder = new JContractFormsOrders();
            formOrder.LoadAll(pTypeCode);
            int i = 0;
            foreach (JContractFormsOrder form in formOrder.Items)
            {
                object formObject = (new JAction(form.FormName, form.FormName + ".MakeForm", null, null)).run();
                ((JBaseContractForm)formObject).ContractTypeCode = pTypeCode;
                
                ((JBaseContractForm)formObject).State = pView;
                //if (pCCode > 0)
                //    ((JBaseContractForm)formObject).State = JBaseContractForm.JStateContractForm.Update;
                //if (pView)
                //    ((JBaseContractForm)formObject).State = JBaseContractForm.JStateContractForm.View;

                if (pSheetCode > 0 && formObject is JContractTarefeForm)
                    ((JContractTarefeForm)formObject).DefaultSheetCode = pSheetCode;

                ((JBaseContractForm)formObject).Index = i++;
                ((JBaseContractForm)formObject).GroupCode = _GroupCode;
                ((JBaseContractForm)formObject).ConcernCode = _ConcernCode;
                if (form.Show)
                {
                    ContractForms.Add((JBaseContractForm)formObject, form);
                }
            }
        }

        public void GetData(int pTypeCode, int pCCode, int pFinanceCode, bool pView)
        {
            GetData(pTypeCode, pCCode, pFinanceCode, pView, null);
        }

        public void GetData(int pTypeCode, int pCCode, int pFinanceCode, bool pView,ArgParameter[] pArg)
        {
            if (ContractForms == null)
                ContractForms = new JContractForms(pCCode);
            else
                ContractForms.Contract.GetData(pCCode);
            ContractForms.B = pArg;

            if (pTypeCode == 0)
                pTypeCode = ContractForms.Contract.Type;

            JDataBase db = JGlobal.MainFrame.GetDBO();
            try
            {
                /// در صورتی که فرم برای ویرایش باز شود مجوز چک میشود
                if (!pView && pCCode > 0)
                {
                    //-2 dont chek permission
                    if (ContractForms.Contract.ContractType.Code == -2 || JPermission.CheckPermission("Legal.JSubjectContract.Update", ContractForms.Contract.ContractType.Code))
                    {
                        /// در صورتی که قرارداد تائید شده، مجوز ویرایش پس از تائید چک میشود
                        if (ContractForms.Contract.Confirmed &&
                            !ContractForms.Contract.UpdateAfterConfirmed())
                            return;
                    }
                    else
                        return;
                }
                ContractForms.Contract.ContractType = new JContractDynamicType(pTypeCode);

                if (pTypeCode == -2 || JPermission.CheckPermission("Legal.JGeneralContract.ShowForms", ContractForms.Contract.ContractType.Code))
                {
                    #region AddForms

                    if (pCCode != 0)
                        foreach (JBaseContractForm contractForm in ContractForms.Forms)
                        {
                            contractForm.ContextMenuStrip = ContractForms.FormsItems.GetPopup(true);
                            contractForm.ConcernCode = _ConcernCode;
                            contractForm.GroupCode = _GroupCode;
                        }
                    if (pFinanceCode > 0)
                        ContractForms.Contract.FinanceCode = pFinanceCode;

                    #endregion AddForms

                    #region Set Settings
                    //JContractTypeSettings settings = new JContractTypeSettings();
                    ContractForms.Settings.LoadAll(pTypeCode);

                    #endregion Set Settings
                }
            }
            catch (Exception ex)
            {
                JSystem.Except.AddException(ex);
            }
            finally
            {
                db.Dispose();
            }
        }

        public void ShowForms()
        {
            ContractForms.GroupCode = _GroupCode;
            ContractForms.ConcernCode = _ConcernCode;
            ContractForms.ShowForm();
        }
    }
}
