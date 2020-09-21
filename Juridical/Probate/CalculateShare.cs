using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Legal
{
    public partial class JCalculateShare : JBaseForm
    {
        private string Zoj = "0/0";
        private string Zoje = "0/0";
        private string Father = "0/0";
        private string Mother = "0/0";
        private string Daughter = "0/0";
        private string Son = "0/0";
        private string Brother = "0/0";
        private string Sister = "0/0";
        public JCalculateShare()
        {
            InitializeComponent();
        }

        private void Clear()
        {

        }
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            Calc();
        }

        private string Sum(string A, string B)
        {
            int A1 = int.Parse(A.Split(new char[] { '/' })[0]);
            int A2 = int.Parse(A.Split(new char[] { '/' })[1]);
            int B1 = int.Parse(B.Split(new char[] { '/' })[0]);
            int B2 = int.Parse(B.Split(new char[] { '/' })[1]);
            if (A2 == 0)
                return B;
            if (B2 == 0)
                return A;
            int M, N;
            N = A2 * B2;
            M = (N / A2) * A1 + (N / B2) * B1;
            return M.ToString() + "/" + N.ToString();
        }
        private string Minus(string A, string B)
        {
            int A1 = int.Parse(A.Split(new char[] { '/' })[0]);
            int A2 = int.Parse(A.Split(new char[] { '/' })[1]);
            int B1 = int.Parse(B.Split(new char[] { '/' })[0]);
            int B2 = int.Parse(B.Split(new char[] { '/' })[1]);
            if (A2 == 0)
                return B;
            if (B2 == 0)
                return A;

            int M, N;
            N = A2 * B2;
            M = (N / A2) * A1 - (N / B2) * B1;
            if (M < 0) M *= -1;
            return M.ToString() + "/" + N.ToString();
        }

        private string Pow(string A, string B)
        {
            int A1 = int.Parse(A.Split(new char[] { '/' })[0]);
            int A2 = int.Parse(A.Split(new char[] { '/' })[1]);
            int B1 = int.Parse(B.Split(new char[] { '/' })[0]);
            int B2 = int.Parse(B.Split(new char[] { '/' })[1]);
            return (A1 * B1).ToString() + "/" + (A2 * B2).ToString();
        }

        private int bmm(string A)
        {
            int x = int.Parse(A.Split(new char[] { '/' })[0]);
            int y = int.Parse(A.Split(new char[] { '/' })[1]);

            try
            {

                int r = 0;
                do
                {
                    r = x % y;
                    if (r == 0)
                        return y;
                    else
                    {
                        x = y;
                        y = r;
                    }//else
                } while (r != 0);
                return 1;
            }
            catch
            {
                return 1;
            }
        }

        private string Sade(string A)
        {
            int r = bmm(A);

            int x = int.Parse(A.Split(new char[] { '/' })[0]);
            int y = int.Parse(A.Split(new char[] { '/' })[1]);

            return (x / r).ToString() + "/" + (y / r).ToString();
        }

        private void Calc()
        {
            LB.Items.Clear();
            Zoj = "0/0";
            Zoje = "0/0";
            Father = "0/0";
            Mother = "0/0";
            Daughter = "0/0";
            Son = "0/0";
            Brother = "0/0";
            Sister = "0/0";

            if (chkFather.Checked)
                Father = "1/6";
            if (chkMom.Checked)
                Mother = "1/6";
            if (chkBrother.Checked || chkSister.Checked)
            {
                string M = Sum(Mother, Father);
                decimal A = NDBrother.Value * 2 + NDSyster.Value;
                string N = Pow(M, "1/" + A.ToString());
                Brother = Sade(Pow("2/1", N));
                Sister = Sade(N);
            }

            if (RBZoj.Checked)
            {
                Zoj = "1/4";
            }
            if (RBZoje.Checked)
            {
                Zoje = "1/8";
            }
            string K =
                Sum(
                    Sum(
                        Sum(
                            Sum(
                                Sum(Father, Mother)
                            , Zoj)
                        , Zoje)
                    , Pow(Brother, NDBrother.Value.ToString() + "/1"))
                , Pow(Sister, NDSyster.Value.ToString() + "/1"));
            string L = Minus("6/6", K);
            if (chkBoy.Checked || chkDogther.Checked)
            {
                decimal B = NDBoye.Value * 2 + NDDogther.Value;
                if (B > 0)
                {
                    string N = Pow(L, "1/" + B.ToString());
                    if (NDBoye.Value > 0)
                        Son = Sade(Pow("2/1", N));
                    if (NDDogther.Value > 0)
                        Daughter = Sade(N);
                }
            }

            if (RBZoje.Checked)
            {
                Zoje = Pow("1/8", "1/" + nDZoje.Value.ToString());
            }
            LB.RightToLeft = RightToLeft.No;
            LB.Items.Add(JLanguages._Text("Zoj") + "=" + (Zoj.ToString()));
            LB.Items.Add(JLanguages._Text("Zoje") + "=" + (Zoje.ToString()));
            LB.Items.Add(JLanguages._Text("Father") + "=" + (Father.ToString()));
            LB.Items.Add(JLanguages._Text("Mother") + "=" + (Mother.ToString()));
            LB.Items.Add(JLanguages._Text("Boy") + "=" + (Son.ToString()));
            LB.Items.Add(JLanguages._Text("Dogther") + "=" + (Daughter.ToString()));
            LB.Items.Add(JLanguages._Text("Brother") + "=" + (Brother.ToString()));
            LB.Items.Add(JLanguages._Text("Sister") + "=" + (Sister.ToString()));
        }

        private void CalcChild()
        {

        }

        private void CalcBrother()
        {

        }

        private void CalcParent()
        {

        }

        private void chkFather_CheckedChanged(object sender, EventArgs e)
        {
            BrotherSisterInit();
        }

        private void BrotherSisterInit()
        {
            chkBrother.Enabled = !chkFather.Checked || !chkMom.Checked;
            chkSister.Enabled = !chkFather.Checked || !chkMom.Checked;
            if (!chkBrother.Enabled)
            {
                chkBrother.Checked = false;
                chkSister.Checked = false;
                NDBrother.Value = 0;
                NDSyster.Value = 0;
            }
        }
        private void chkMom_CheckedChanged(object sender, EventArgs e)
        {
            BrotherSisterInit();
        }

        public DataTable resultTable;
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (LB.Items.Count == 0)
            {
                JMessages.Error("هیچ مقداری محاسبه نشده است.", "خطا");
                return;
            }
            resultTable = new DataTable();
            resultTable.Columns.Add("FamilyRelation");
            resultTable.Columns.Add("inherText");
            for (int i = 0; i < LB.Items.Count; i++)
            {
                DataRow row = resultTable.NewRow();
                row["FamilyRelation"] = LB.Items[i].ToString().Split(new char[] { '=' })[0];
                row["inherText"] = LB.Items[i].ToString().Split(new char[] { '=' })[1];
                resultTable.Rows.Add(row);
            }
            DialogResult = DialogResult.OK;

        }
    }
}
