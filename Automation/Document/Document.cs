using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation
{
    public class JDocument: JAutomation
    {
        public JARefer Refer;
        public JAObject Object;

        public JDocument()
        {
        }

        public override void Dispose()
        {
            Refer.Dispose();
            Object.Dispose();
            base.Dispose();
        }
    }

    public class JDocuments: JAutomation
    {
        public JDocument[] Items = new JDocument[0];

        public void Insert(JDocument pDocument)
        {
            Array.Resize(ref Items, Items.Length + 1);
            Items[Items.Length - 1] = pDocument;
        }

        public override void Dispose()
        {
            foreach (JDocument Item in Items)
                Item.Dispose();
            base.Dispose();
        }
    }
}
