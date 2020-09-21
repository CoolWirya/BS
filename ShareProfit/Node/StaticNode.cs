using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClassLibrary;
using System.Data;

namespace ShareProfit
{
    public class JSPStaticNode : JStaticNode
    {



        #region Courses
        /// <summary>
        /// دوره ها
        /// </summary>
        /// <returns></returns>
        public static JNode _CourseNode()
        {
            JNode Node = new JNode(0, "");
            Node.Name = "Courses";
            Node.Hint = "Courses";
            Node.Icone = JImageIndex.Courses.GetHashCode();

            JAction Ac = new JAction("Courses", "ShareProfit.JCourses.ListView", null, null, true);
            Node.MouseClickAction = Ac;
            Node.MouseDBClickAction = Ac;
            return Node;
        }

        public static JNode _CoursesPayNode()
        {
                JNode Node = new JNode(0, "");
                Node.Name = "Pay";
                Node.Hint = "Pay";
                Node.Icone = JImageIndex.Courses.GetHashCode();
                Node.ChildsAction = new JAction("Pay", "ShareProfit.JCourses.TreeView", null, null, true);

                return Node;

        }

		public static JNode _ReportNode()
		{
			JNode Node = new JNode(0, "");
			Node.Name = "Report";
			Node.Hint = "Report";
			Node.Icone = JImageIndex.Courses.GetHashCode();

			JAction Ac = new JAction("Rep", "ShareProfit.JCourse.ShowDialogs", null, null, true);
			Node.MouseClickAction = Ac;
			Node.MouseDBClickAction = Ac;
			return Node;
		}

        #endregion
    }
}
