using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebControllers.MainControls.CustomListSelector
{
    /// <summary>
    /// Summary description for JCustomListSelectorService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class JCustomListSelectorService : System.Web.Services.WebService
    {

        [WebMethod(EnableSession = true)]
        public void ShowListViewControl(string queryStringValue, string codeElementId, string titleElementId, string sql, string searchFields, string title)
        {
            // Creating Unique ID For Control
            sql = ClassLibrary.JEnryption.DecryptStr(sql, WebClassLibrary.SessionManager.Current.SessionID);
            string uId = WebClassLibrary.JWebManager.ResolveQueryStringValue(queryStringValue, "_");
            // Creating and saving new instance of JCustomListSelector needed for JCustomListView Control
            JCustomListSelector jCustomListSelector = new JCustomListSelector(uId);
            jCustomListSelector.CodeElementID = codeElementId;
            jCustomListSelector.TitleElementID = titleElementId;
            jCustomListSelector.SQL = sql;
            jCustomListSelector.SearchFields = searchFields;
            jCustomListSelector.Title = title;
            //jCustomListSelector.SessionSave();

            WebClassLibrary.JWebManager.LoadControl(uId, "~/WebControllers/MainControls/CustomListSelector/JCustomListViewControl.ascx", "Search", null, WebClassLibrary.WindowTarget.NewWindow, true, false, false, 500, 400);
        }
        //[WebMethod(EnableSession = true)]
        //public string test1(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
        //{
        //    if (requestType == JJson.JsonRequestType.Direct)
        //        return data.Split('|')[0].Split(':')[1];
        //    if (responseType == JJson.JsonResponseType.Table)
        //        return getDT(data);
        //    else if (responseType == JJson.JsonResponseType.Row)
        //        return data.Replace("|", "?!?");
        //    else if (responseType == JJson.JsonResponseType.Item)
        //        return data.Split('|')[0].Split(':')[1];//data.Contains("|") ? data.Split('|')[0].Contains(":") ? data.Split('|')[0].Split(':')[1] : data.Split('|')[0] :data.Split(':')[1] : data.Split('|')[0] ;
        //    //if (requestType == JJson.JsonRequestType.SQL)
        //    //	return data;
        //    //if (data.Contains("|"))
        //    return data.Split('|')[0].Split(':')[1];
        //    //	return data.Split(':')[1];
        //}

        #region Service
        [WebMethod(EnableSession = true)]
        public string Run(string data, JJson.JsonRequestType requestType, JJson.JsonResponseType responseType)
        {
            string response = "";
            switch (requestType)
            {
                case JJson.JsonRequestType.SQL:
                    switch (responseType)
                    {
                        case JJson.JsonResponseType.Table:
                            response = GetJson(ExecuteQuery(data));  
                            break;
                        case JJson.JsonResponseType.Row:
                            response = GetJson(ExecuteQuery(data), 0);
                            break;
                        case JJson.JsonResponseType.Item:
                            response = GetJson(ExecuteQuery(data), 0, 0);
                            break;
                        default:
                            break;
                    }
                    break;
                case JJson.JsonRequestType.Direct:
                    response = data;
                    break;
                case JJson.JsonRequestType.Other:
                    response = data;
                    break;
                default:
                    break;
            }
            return response;
        }
        private DataTable ExecuteQuery(string query)
        {
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable(query, true);
            return dt;
        }
        private string GetJson(DataTable dt)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            foreach (DataRow dr in dt.Rows)
            {
                row = new Dictionary<string, object>();
                foreach (DataColumn col in dt.Columns)
                    row.Add(col.ColumnName, dr[col]);
                rows.Add(row);
            }
            return serializer.Serialize(rows);
        }
        private string GetJson(DataTable dt, int rowIndex)
        {
            System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            Dictionary<string, object> row = null;
            DataRow dr = dt.Rows[rowIndex];
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
                row.Add(col.ColumnName, dr[col]);
            return serializer.Serialize(row);
        }
        private string GetJson(DataTable dt, int rowIndex, int colIndex)
        {
            //System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
            //Dictionary<string, object> row = null;
            //DataRow dr = dt.Rows[rowIndex];
            //row = new Dictionary<string, object>();
            //row.Add(dt.Columns[colIndex].ColumnName, dr[colIndex]);
            //return serializer.Serialize(row);
            if (dt == null || dt.Rows.Count <= 0)
                return "";
            return dt.Rows[rowIndex][colIndex].ToString();
        }
        #endregion
        [WebMethod(EnableSession = true)]
        public string GetTitleByCode(string code, string sql)
        {
            sql = ClassLibrary.JEnryption.DecryptStr(sql, WebClassLibrary.SessionManager.Current.SessionID);
            DataTable dt = WebClassLibrary.JWebDataBase.GetDataTable("Select title From (" + sql + ") weberp_tbl_customlistview_1 Where Code =" + code, true);
            if (dt != null && dt.Rows.Count != 0)
                return dt.Rows[0]["title"].ToString();
            return "undefined";
        }

        [WebMethod(EnableSession = true)]
        public string GetPersonByCode(string code)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            dt = WebClassLibrary.JWebDataBase.GetDataTable("Select Code, Name from clsAllPerson Where Code =" + code, true);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["Name"].ToString();
            return "undefined";
        }

        [WebMethod(EnableSession = true)]
        public string GetGasStationByCode(string code)
        {
            DataTable dt = new DataTable();
            dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT Code, ogs.Name Title,ogs.Number FROM OilGasStation ogs WHERE number = " + code, true);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["Title"].ToString() + "|" + dt.Rows[0]["Code"].ToString();
            return "undefined";
        }

        [WebMethod(EnableSession = true)]
        public string GetNozzleByGasStationCode(string gsCode, string nozzleCode)
        {
            DataTable dt = new DataTable();
            dt = WebClassLibrary.JWebDataBase.GetDataTable("SELECT on1.Code, on1.Number Title FROM OilNozzle on1 INNER JOIN OilPump op ON op.Code = on1.PumpCode WHERE Op.GasStationCode =" + gsCode + " and on1.code = " + nozzleCode, true);
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0]["Title"].ToString();
            return "undefined";
        }
    }
}
