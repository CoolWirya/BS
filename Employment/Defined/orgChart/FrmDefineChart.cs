using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ClassLibrary;

namespace Employment
{
    public partial class JfrmDefineChart : JBaseForm
    {
        public int Code;
        /// <summary>
        /// انتخاب شده
        /// </summary>
        public DataRow SelectedItem;

        public JfrmDefineChart()
        {
            InitializeComponent();            
        }

        public void FillTree()
        {            
            try
            {
                DataTable dt = new DataTable();
                dt = JorgCharts.GetAllDataWithFullTitle(0);
                DataRow dr = dt.NewRow();
                dr["Code"] = -1;
                dr["full_title"] = "چارت سازمانی";
                dr["ParentCode"] = DBNull.Value;
                dt.Rows.Add(dr);
                DataView dv = dt.DefaultView;
                dv.Sort = "Code ASC";
                dt = dv.ToTable();
                dtvOrganizatinChart.dtTree = dt.Copy();
                dtvOrganizatinChart.Title = "full_title";
                dtvOrganizatinChart.Code = "Code";
                dtvOrganizatinChart.ParentCode = "ParentCode";
                dtvOrganizatinChart.Refresh();                
            }
            catch (Exception ex)
            {
             //   Except.AddException(ex);
            }
        }

        private void JfrmDefineChart_Load(object sender, EventArgs e)
        {
            FillTree();
        }

        private void tsmAddChart_Click(object sender, EventArgs e)
        {
                JPostList p = new JPostList();
                p.ShowDialog();
                if ((p.Code > 0) && (JorgCharts.GetDataByExp(" Where PostCode=" + p.Code).Rows.Count == 0))
                {
                    JorgChart classList = new JorgChart();
                    classList.PostCode = p.Code;
                    if (SelectedItem != null)
                        if ((int)SelectedItem.ItemArray[0] != -1)
                        classList.ParentCode = (int)SelectedItem.ItemArray[0];
                    if (classList.Insert() > 0)
                        FillTree();
                }
                else
                    JMessages.Error("این پست قبلا در چارت استفاده شده است", "خطا ");
        }

        private void tsmDeleteChart_Click(object sender, EventArgs e)
        {
            JorgChart tmp = new JorgChart();
            tmp.Code = (int)SelectedItem.ItemArray[0];
            if (tmp.Delete())
                FillTree();
        }

        private void dtvOrganizatinChart_SelectedNodWithMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)dtvOrganizatinChart.SelectedItem).Tag);
        }

        private void dtvOrganizatinChart_SelectedItemChange(object sender, TreeViewEventArgs e)
        {
            SelectedItem = (DataRow)(((System.Windows.Forms.TreeNode)dtvOrganizatinChart.SelectedItem).Tag);
        }

    }
}
