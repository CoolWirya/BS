using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Employment
{
    public class JContractEmployeeTable : JTable
    {
        public JContractEmployeeTable()
            : base("EmpPersonnelContract")
        {
        }

        #region Property
                    
        /// <summary>
        ///  نوع فعالیت
        /// </summary>
        public int workKind ;
        /// <summary>
        ///  مکان فعالیت
        /// </summary>
        public int workPlace ;
        /// <summary>
        /// ساعت کاری
        /// </summary>
        public int workTime ;
        /// <summary>
        /// مزد ثابت
        /// </summary>
        public decimal constSallary ;
        /// <summary>
        /// حق مسکن
        /// </summary>
        public decimal maskanRight ;
         /// <summary>
        /// حق خواروبار
        /// </summary>
        public decimal kharobarRight;
        /// <summary>
        /// حق اولاد
        /// </summary>
        public decimal childRight;
        /// <summary>
        /// حق ایاب و ذهاب
        /// </summary>
        public decimal workPlaceCondition ;
        /// <summary>
        ///  حق کارایی
        /// </summary>
        public decimal performanceRight ;
        /// <summary>
        /// نوبت کاری
        /// </summary>
        public decimal shiftRight ;
        /// <summary>
        /// بن
        /// </summary>
        public decimal bonRight ;
        /// <summary>
        /// 
        /// </summary>
        public int id_employee;
        /// <summary>
        /// نوع قرارداد
        /// </summary>
        public int protocolKind ;
        /// <summary>
        /// کد قرارداد
        /// </summary>
        public int ContractCode ;
        /// <summary>
        /// کسر صندوق
        /// </summary>
        public decimal cashDec ;
        /// <summary>
        /// 
        /// </summary>
        public int id_protocolSheet ;
        /// <summary>
        /// حق سرپرستی
        /// </summary>
        public decimal sarparastyRight ;
        /// <summary>
        /// پایه سنواتی
        /// </summary>
        public decimal sanavatBase ;
        /// <summary>
        /// سایر مزایا
        /// </summary>
        public decimal otherRight ;
        /// <summary>
        /// حق جذب
        /// </summary>
        public decimal jazbRight ;
        /// <summary>
        /// 
        /// </summary>
        public decimal mahroomAzTahsilRight ;      
        /// <summary>
        /// مزایا 1
        /// </summary>
        public decimal maz1 ;
        /// <summary>
        /// مزایا 2
        /// </summary>
        public decimal maz2 ;
        /// <summary>
        /// مزایا 3
        /// </summary>
        public decimal maz3 ;
        /// <summary>
        /// عنوان مزایا 1
        /// </summary>
        public string mazTitle1 ;
        /// <summary>
        /// عنوان مزایا 2
        /// </summary>
        public string mazTitle2 ;      
        /// <summary>
        /// عنوان مزایا 3
        /// </summary>
        public string mazTitle3 ;
        /// <summary>
        /// نوع محاسبه
        /// </summary>
        public int CalcType ;
        /// <summary>
        /// مزد رتبه
        /// </summary>
        public decimal RotbeRight;
        /// <summary>
        /// مزد سختی کار
        /// </summary>
        public decimal SakhtiKarRight;
        /// <summary>
        /// مزد جبهه
        /// </summary>
        public decimal JebheRight;
        /// <summary>
        /// مزد سربازی
        /// </summary>
        public decimal MilitryRight;
        /// <summary>
        /// تفاوت تطبیق
        /// </summary>
        public decimal Tafavot;
        /// <summary>
        /// فوق العاده شغل
        /// </summary>
        public decimal FoghAlade;
        /// <summary>
        /// 
        /// </summary>
        public bool Test;
        #endregion
    }
}
