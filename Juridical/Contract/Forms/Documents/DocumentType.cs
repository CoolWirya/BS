using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Legal
{
    public class JDocumentType : JLegal
    {
        public string ClassName
        {
            get;
            set;
        }
        public override string ToString()
        {
            return JLanguages._Text(ClassName);
        }

        public JDocumentContract NewItem(int pExporter, int pReciever, string pPropClassName , int pLocation, int pForm, int pConcern, DateTime pDate, int pSerial , int pDtl1,int pDtl2,int pDtl3)
        {
            try
            {
                JAction action = new JAction("ShowDialog", ClassName + ".ShowDialog", new object[] { pExporter, pReciever, pPropClassName, pLocation,pForm,pConcern,pDate,pSerial,pDtl1,pDtl2,pDtl3 }, null);
                JDocumentContract Code = (JDocumentContract)action.run();
                return Code;
            }
            catch
            {
                return null;
            }
        }

        public List<JDocumentContract> NewItems(int pExporter, int pReciever, string pPropClassName, int pLocation, int pForm, int pConcern, DateTime pDate, int pSerial, int pDtl1, int pDtl2, int pDtl3)
        {
            try
            {

                JAction action = new JAction("ShowDialog", ClassName + ".ShowDialog", new object[] { pExporter, pReciever, pPropClassName, pLocation, pForm, pConcern, pDate, pSerial, pDtl1, pDtl2, pDtl3 }, null);
                List<JDocumentContract> Code = (List<JDocumentContract>)action.run();
                return Code;
            }
            catch
            {
                return null;
            }
        }

        public JDocumentContract EditItem(JDocumentContract pCode, string pPropClassName)
        {
            try
            {
                JAction action = new JAction("ShowDialog", ClassName + ".ShowDialog", new object[] { pPropClassName }, new object[] { pCode.ObjectCode });
                JDocumentContract Code = (JDocumentContract)action.run();
                return Code;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string GetContractText(int pCode)
        {
            try
            {
                JAction action = new JAction("Text", ClassName + ".GetContractText", null, new object[] { pCode });
                return  (string)action.run();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }

    public class JDocumentTypes : JLegal
    {
        public List<JDocumentType> Items = new List<JDocumentType>();
        public JDocumentTypes()
        {
            JDocumentType PriceType = new JDocumentType();
            PriceType.ClassName = "Finance.JRealPrice";
            Items.Add(PriceType);

            JDocumentType chType = new JDocumentType();
            chType.ClassName = "Finance.JCheque";
            Items.Add(chType);

            JDocumentType chseriType = new JDocumentType();
            chseriType.ClassName = "Finance.JCheques";
            Items.Add(chseriType);

            JDocumentType pnType = new JDocumentType();
            pnType.ClassName = "Finance.JPromissoryNote";
            Items.Add(pnType);

            JDocumentType fType = new JDocumentType();
            fType.ClassName = "Finance.JFish";
            Items.Add(fType);
        }
    }

}
