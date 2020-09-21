using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WarehouseManagement.Goods
{
    public class JGoodsHistory : ClassLibrary.JHistory
    {
        public const string ConstClassName = "WarehouseManagement.Goods.JGoodsHistory";
    }

    public class JGoodsHistories
    {
        public static void AddHistory(ActionType ActType, int TransactionCode, int GoodCode,string History, string Description)
        {
            ClassLibrary.JHistory jHistory = new ClassLibrary.JHistory();
            jHistory.Save(JGoodsHistory.ConstClassName, GoodCode, ActType.GetHashCode(), TransactionCode, 0, History, Description, new ClassLibrary.JDataBase());
        }

        public static DataTable GetHistory(int GoodCode)
        {
            return null;
        }
    }

    public enum ActionType
    {
        Goods_In = 1,
        Goods_Out = 2,
        Goods_Status = 3

    }
}

