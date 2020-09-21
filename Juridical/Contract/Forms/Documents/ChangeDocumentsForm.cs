using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Legal;

namespace Legal.Contract.Forms.Documents
{
    public partial class JChangeDocumentsForm : ClassLibrary.JBaseForm
    {
        public JChangeDocumentsForm(int pContractCode)
        {
            InitializeComponent();

            DataTable docs = JDocumentsContract.GetAllData(pContractCode);
            jDataGridOld.DataSource = docs;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public CancellDocument[] CancellDocuments = new CancellDocument[0];

        private void btnEbtal_Click(object sender, EventArgs e)
        {
            try
            {
                if (jDataGridOld.SelectedRows.Count == 1)
                {
                    int Code = int.Parse(jDataGridOld.SelectedRows[0].Cells["Code"].Value.ToString());
                    Legal.Contract.Forms.Documents.JCancellDocumentForm CDF = new JCancellDocumentForm(Code);
                    if (CDF.ShowDialog() == DialogResult.Yes)
                    {
                        Array.Resize(ref CancellDocuments, CancellDocuments.Length + 1);
                        CancellDocuments[CancellDocuments.Length - 1].CancellDesc = CDF.CancellDocument.CancellDesc;
                        CancellDocuments[CancellDocuments.Length - 1].CancellType = CDF.CancellDocument.CancellType;
                        CancellDocuments[CancellDocuments.Length - 1].Code = CDF.CancellDocument.Code;
                    }
                }
            }
            catch
            {

            }
            finally
            {

            }
        }

        private void btnCancelEbtal_Click(object sender, EventArgs e)
        {
            int Code = int.Parse(jDataGridOld.SelectedRows[0].Cells["Code"].Value.ToString());
            for (int i = 0; i < CancellDocuments.Length; i++)
            {
                if (CancellDocuments[i].Code == Code)
                {
                    RemoveAt(ref CancellDocuments, i );
                }
            }
        }

        public void RemoveAt(ref CancellDocument[] source, int index)
        {
            CancellDocument[] dest = new CancellDocument[source.Length - 1];
            if (index > 0)
                Array.Copy(source, 0, dest, 0, index);

            if (index < source.Length - 1)
                Array.Copy(source, index + 1, dest, index, source.Length - index - 1);
        }
    }

}
