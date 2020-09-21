using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;

namespace Finance
{
    class JFStaticAction
    {

        public static JNode _FinanceShare()
        {
            JNode Node = new JNode(0, "");
            Node.Name = "Finance";
            //Node.Icone = 4;
            Node.Hint = "Finance";

            JAction Ac = new JAction("Finance", "Finance.JFinanceShare.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;

            JAction CAc = new JAction("Finance", "Finance.JFinanceShare.TreeView");
            Node.ChildsAction = CAc;

            return Node;
        }
        #region Courses Action

        //public static JNode _CourseNode(JCourse pCourse)
        //{
        //    JNode Node = new JNode(pCourse.Code, "Finance.JCourse");
        //    Node.Name = pCourse.Title;
            
        //    JAction EditAction = new JAction("Edit...", "Finance.JCourse.UpdateForm", new object[] { pCourse.Code }, null);
        //    Node.MouseDBClickAction = EditAction;
        //    Node.MouseClickAction = EditAction;
        //    //Node.Icone = 5;
        //    Node.Popup.Insert(EditAction);

        //    JAction DeleteAction = new JAction("Delete", "Finance.JCourse.Delete", new object[] { pCourse.Code }, null);
        //    Node.Popup.Insert(DeleteAction);

        //    JAction InsertAction = new JAction("New...", "Finance.JCourse.InsertForm");
        //    Node.Popup.Insert(InsertAction);

        //    JAction PaymentAction = new JAction("PayProfit...", "Finance.JCourse.DocumentForm" ,new object[] { pCourse.Code }, null);
        //    Node.Popup.Insert(PaymentAction);

        //    return Node;
        //}

        //public static JNode _CoursesNode()
        //{
        //    JNode Node = new JNode(0, "Finance.JCourse");
        //    Node.Name = "Courses";
        //    //Node.Icone = 4;
        //    Node.Hint = "Courses";

        //    JAction Ac = new JAction("Courses", "Finance.JCourses.ListView", null, null, true);
        //    Node.MouseClickAction = Ac;
        //    Node.MouseDBClickAction = Ac;

        //    JAction CAc = new JAction("Courses", "Finance.JCourses.TreeView");
        //    Node.ChildsAction = CAc;

        //    return Node;
        //}
        #endregion SubsidiariesNode
    }
}
