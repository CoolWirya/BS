using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Globals
{
    public class JSqlOperation
    {
        public string Name
        {
            get;
            set;
        }
        public string Operation
        {
            get;
            set;
        }
        public override string ToString()
        {
            return Name;
        }
       
    }   
    

    public class JSqlOperations
    {
        public List<JSqlOperation> Opertions
        {
            get;
            set;
        }

        public JSqlOperations()
        {
            Opertions = new List<JSqlOperation>();
            //تعرف عملگر مساوی
            JSqlOperation op1 = new JSqlOperation();
            op1.Name =JLanguages._Text("Equal");
            op1.Operation = "=";
            Opertions.Add(op1);
            //تعریف عملگر بزرگتر
            JSqlOperation op2 = new JSqlOperation();
            op2.Name =JLanguages._Text("Larger");
            op2.Operation = ">";
            Opertions.Add(op2);
            //تعریف عملگر کوچکتر
            JSqlOperation op3 = new JSqlOperation();
            op3.Name =JLanguages._Text("Less");
            op3.Operation = "<";
            Opertions.Add(op3);
            //تعریف عملگر بزرگتر مساوی
            JSqlOperation op4 = new JSqlOperation();
            op4.Name =JLanguages._Text("Greater equal");
            op4.Operation = ">=";
            Opertions.Add(op4);
            //تعریف عملگر کوچکتر مساوی
            JSqlOperation op5 = new JSqlOperation();
            op5.Name =JLanguages._Text("Smaller equal");
            op5.Operation = "<=";
            Opertions.Add(op5);
            //تعریف عمگلر نامساوی
            JSqlOperation op6 = new JSqlOperation();
            op6.Name =JLanguages._Text("Unequal");
            op6.Operation = "<>";
            Opertions.Add(op6);
            //تعریف عملگر مشابه
            JSqlOperation op7 = new JSqlOperation();
            op7.Name = JLanguages._Text("Like");
            op7.Operation = " like ";
            Opertions.Add(op7);
            //تعریف عملگر نقیض مشابه
            JSqlOperation op8 = new JSqlOperation();
            op8.Name = JLanguages._Text("NotLike");
            op8.Operation=" Not Like ";
            Opertions.Add(op8);
            
           



        }
       
        
    }
    /// <summary>
    /// 
    /// </summary>
    class JField
    {
        public string FarsiName
        {
            get;
            set;
        }
        public string EnglishName
        {
            get;
            set;
        }
        public Type DataType
        {
            get;
            set;
        }
        public override string ToString()
        {
            return FarsiName;
        }

    }


}
