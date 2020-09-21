using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMSClassLibrary;
using CMSClassLibrary.Template;
using System.Data;

namespace CMS.TemplateManagement
{
    public class JTemplates
    {
        CMSClassLibrary.Template.JTemplate NewTemplate;
        public int Code { get; set; }
        public string Path { get; set; }
        public bool IsDefault { get; set; }
        public int ExtensionCode { get; set; }

        public bool Insert()
        {
            NewTemplate = new JTemplate();
            NewTemplate.Path = Path;
            NewTemplate.IsDefault = IsDefault;
            NewTemplate.ExtensionCode = ExtensionCode;
            if (Code != 0)
            {
                NewTemplate.Code = Code;
                return NewTemplate.Update();
            }
            else
                return NewTemplate.Insert();
        }

        public int GetDefault()
        {
            int code = 0;
            DataTable templates = CMSClassLibrary.Template.JTemplates.GetDataTable("IsDefault=True");
            if(templates != null)
            {
                if(templates.Rows.Count >= 1)
                {
                    DataRow dr = templates.Rows[0];
                    code = Int32.Parse(dr["Code"].ToString());
                }
            }
            return code;

        }

        public void GetPositions()
        {

        }

    }
}
