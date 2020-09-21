using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Controls.Map
{
    public struct PointD
    {
        private double _x;
        public double X
        {
            get { return _x; }
            set { _x = value; }
        }

        private double _y;
        public double Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public PointD(double x, double y)
        {
            _x = 0;
            _y = 0;
            this.X = x;
            this.Y = y;
        }
    }
}
