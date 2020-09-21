using System;
using System.Collections.Generic;
using ProjectManagement;

namespace ProjectManagement.MixedObjects
{
    public class ItemFamily : Item.JItem
    {
        public int PriorityNumber { get; set; }
        public List<ItemFamily> Children { get; set; }

        public static List<ItemFamily> ExtractFamilies(System.Data.DataTable dt)
        {
            if (dt == null) return new List<ItemFamily>();
            List<ItemFamily> f = new List<ItemFamily>();
            ItemFamily i;
            foreach (System.Data.DataRow dr in dt.Select("ParentItemCode=-1"))
            {
                i = Create(dr["Code"].ToString().ToInt32(), dt, 0);
                if (i != null)
                    f.Add(i);
            }
            return f;
        }
        public static ItemFamily Create(int itemCode, System.Data.DataTable dt, int priorityNumber)
        {
            ItemFamily f = new ItemFamily();
            ClassLibrary.JTable.SetToClassProperty(f, dt.Select("Code=" + itemCode)[0]);
            f.PriorityNumber = priorityNumber;
            f.Children = new List<ItemFamily>();

            foreach (System.Data.DataRow dr in dt.Select("ParentItemCode=" + itemCode))
            {
                try
                {
                    f.Children.Add(Create(dr["Code"].ToString().ToInt32(), dt, priorityNumber + 1));
                }
                catch (Exception er)
                {

                }
            }

            return f;
        }
    }
}
