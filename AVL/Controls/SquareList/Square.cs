using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AVL.Controls.SquareList
{
    public class Square
    {
        private string _name;
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        private string _caption;
        public string Caption
        {
            get { return this._caption; }
            set { this._caption = value; }
        }

        private string _icon;
        public string Icon
        {
            get { return this._icon; }
            set { this._icon = value; }
        }
        private string _navigationUrl;
        public string NavigationUrl
        {
            get { return this._navigationUrl; }
            set { this._navigationUrl = value; }
        }

        public bool _openInCurrentWindow = true;
        /// <summary>
        /// True, open link in current window
        /// false, open link in new window
        /// </summary>
        public bool OpenInCurrentWindow
        {
            get { return this._openInCurrentWindow; }
            set { _openInCurrentWindow = value; }
        }
    }
}
