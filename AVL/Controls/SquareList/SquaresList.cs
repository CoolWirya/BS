using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AVL.Controls.SquareList
{
    [DefaultProperty("Text")]
    [ToolboxData("<{0}:SquaresList runat=server></{0}:SquaresList>")]
    public class SquaresList : WebControl
    {
        [Bindable(true)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string Text
        {
            get
            {
                String s = (String)ViewState["Text"];
                return ((s == null) ? String.Empty : s);
            }

            set
            {
                ViewState["Text"] = value;
            }
        }

        private List<Square> _squares = new List<Square>();
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public List<Square> Squares { get { return _squares; } }

        private int _squareCount = 4;
        /// <summary>
        /// Count of squares in each row.
        /// </summary>
        public int SquareCount { get { return this._squareCount; } set { this._squareCount = value; } }

        protected override void RenderContents(HtmlTextWriter output)
        {
            output.Write("<H1> " + this.Text + " </H1>");
            int squareWidth = (100 - 4 - this._squareCount) / this._squareCount;
            output.Write(string.Format("<table border=1 style='width:{0}%;margin-left:2%;text-align:center;' >", 100));
            int i = 0;
            output.Write("<tr>");
            string target = "";
            foreach (Square s in _squares)
            {
                if ((i % this.SquareCount) == 0)
                {
                    if (this.SquareCount >= i && i != 0)
                    {
                        output.Write("</tr>");
                        output.Write("<tr>");
                    }
                }

                output.Write("<td>");
                //output.Write(string.Format("<div id='{0}' style='width:{1}%;margin:auto 1% auto auto;text-align:center;'>", s.Name, squareWidth));
                output.Write(string.Format("<img id='img{0}' src='{1}' width='100%' height='100%'/>", s.Name, s.Icon));
                target = "";
                if (!s.OpenInCurrentWindow)
                    target = " target='_blank' ";
                output.Write(string.Format("<a id='lnk{0}' style='position:relative;left:1px;top:0px;z-index:100' href='{2}' {3} > {1} </a>", s.Name, s.Caption, s.NavigationUrl,target));
                output.Write("</div>");
                output.Write("</td>");
                if (i+1 == this.Squares.Count)
                {
                    //for (int j = 0; j < 4 - (i % 4); j++)
                    //    output.Write("<td></td>");
                    output.Write("</tr>");
                }
                i++;
            }
            output.Write("</table>");
        }
    }
}
