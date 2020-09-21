using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClassLibrary;
using RealEstate;

namespace JComponents
{
	[ToolboxData("<{0}:SearchUnitControl runat=\"server\">")]
	[Serializable()]
	public class SearchUnitControl : CompositeControl, ISerializable
	{
		private DropDownList ConstructionNameDropDownList;
		private DropDownList TypeDropDownList;
		private DropDownList FloorDropDownList;
		private TextBox PlaqueTextBox;
		private TextBox NumberTextBox;
		private Button SearchButton;
		private Button OKButton;
		private DataGridView DGV;
		private HiddenField SelectedCodeHiddenField;

		public SearchUnitControl()
		{
		}

		public SearchUnitControl(SerializationInfo info, StreamingContext ctxt)
		{
			ID = (string)info.GetValue("ID", typeof(string));
			SelectedCode = (int)info.GetValue("SelectedCode", typeof(int));
			ParentDialog = (string)info.GetValue("ParentDialog", typeof(string));
		}

		public void GetObjectData(SerializationInfo info, StreamingContext ctxt)
		{
			info.AddValue("ID", ID);
			info.AddValue("SelectedCode", SelectedCode);
			info.AddValue("ParentDialog", ParentDialog);
		}

		protected override void RecreateChildControls()
		{
			base.RecreateChildControls();
			EnsureChildControls();
		}

		protected override void CreateChildControls()
		{
			base.CreateChildControls();

			ConstructionNameDropDownList = new DropDownList();
			ConstructionNameDropDownList.ID = "ConstructionNameDropDownList";
			ConstructionNameDropDownList.AutoPostBack = true;
			ConstructionNameDropDownList.SelectedIndexChanged += ConstructionNameDropDownList_SelectedIndexChanged;
			this.Controls.Add(ConstructionNameDropDownList);

			TypeDropDownList = new DropDownList();
			TypeDropDownList.ID = "TypeDropDownList";
			this.Controls.Add(TypeDropDownList);

			FloorDropDownList = new DropDownList();
			FloorDropDownList.ID = "FloorDropDownList";
			this.Controls.Add(FloorDropDownList);

			PlaqueTextBox = new TextBox();
			PlaqueTextBox.ID = "PlaqueTextBox";
			this.Controls.Add(PlaqueTextBox);

			NumberTextBox = new TextBox();
			NumberTextBox.ID = "NumberTextBox";
			this.Controls.Add(NumberTextBox);

			SelectedCodeHiddenField = new HiddenField();
			SelectedCodeHiddenField.ID = "SelectedCodeHiddenField";
			this.Controls.Add(SelectedCodeHiddenField);

			DGV = new DataGridView();
			DGV.ID = "DGV";
			DGV.Columns = "code,type,market,marketcode,plaque,floor,number,area,initialarea,balcon,usage,plaqueregistration,status,udesc,finassetcode,gwowners,dfowners,reowners,firsttransferdate,statustitle,numbernewunitbuild,startdateannualrental,enddateannualrental,priceannualrental,tafsili2";
			DGV.PageSize = 10;
			DGV.SUID = this.ClientID + "WebRealEstate_JUnitBuid_SearchUnitControl_630N";
			DGV.SQL = "sss";//RealEstate.JUnitBuild.Query + " WHERE (UB.Status = 1) And 1=1 ";
			DGV.HasVariableSQL = true;
			//DGV.FilterItems = new List<FilterItem>();
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND Code = 0", Value = "" });
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND " + RealEstate.JUnitBuildTableEnum.TypeCode.ToString() + "=", Value = TypeDropDownList.ClientID, Property = "val()" });
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND " + RealEstate.JUnitBuildTableEnum.MarketCode.ToString() + "=", Value = ConstructionNameDropDownList.ClientID, Property = "val()" });
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND " + RealEstate.JUnitBuildTableEnum.Plaque.ToString() + "=", Value = PlaqueTextBox.ClientID, Property = "val()" });
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND " + RealEstate.JUnitBuildTableEnum.FloorCode.ToString() + "=", Value = FloorDropDownList.ClientID, Property = "val()" });
			//DGV.FilterItems.Add(new FilterItem() { Field = " AND " + RealEstate.JUnitBuildTableEnum.Number.ToString() + "=", Value = NumberTextBox.ClientID, Property = "val()" });
			DGV.Click = new GridEventArgs() { Field = "Code", Control = SelectedCodeHiddenField.ClientID };
			DGV.Bind();
			this.Controls.Add(DGV);

			SearchButton = new Button();
			SearchButton.ID = "SearchButton";
			SearchButton.Text = "جستجو";
			SearchButton.Attributes["onclick"] = "$.ajax({type: 'POST',url: 'Services/WebRealEstateService.asmx/GetSearchUnitSQL',data: '{\"type\": \"' + $(\"#" + TypeDropDownList.ClientID + "\").val() + '\", \"market\": \"' + $(\"#" + ConstructionNameDropDownList.ClientID + "\").val() + '\", \"plaque\": \"' + $(\"#" + PlaqueTextBox.ClientID + "\").val() + '\", \"floor\": \"' + $(\"#" + FloorDropDownList.ClientID + "\").val() + '\", \"number\": \"' + $(\"#" + NumberTextBox.ClientID + "\").val() + '\"}',contentType: 'application/json; charset=utf-8',dataType: 'json',success: function (response) {" +
				"$(\"" + DGV.ClientID + "_VarSQL\").val('('+response.d+')t1');" + DGV.ClientID + "GetTablePager('('+response.d+')t1',1,10,'code','asc',[]);" +
				"},error: function (response) {alert(response.d);}});return false;";
			//SearchButton.Click += SearchButton_Click;
			this.Controls.Add(SearchButton);

			OKButton = new Button();
			OKButton.ID = "OKButton";
			OKButton.Text = "تایید";
			//OKButton.Click += OKButton_Click;
			OKButton.Attributes["onclick"] = "alert($(\"#" + SelectedCodeHiddenField.ClientID + "\").val());$(\"#" + this.ClientID + "\").attr(\"value\",$(\"#" + SelectedCodeHiddenField.ClientID + "\").val());$(\"#" + ParentDialog + "\").dialog(\"close\");return false;";
			this.Controls.Add(OKButton);

			JUnitTypes UnitType = new JUnitTypes();
			JSubBaseDefine nullDeff = new JSubBaseDefine(0);
			nullDeff.Code = -1;
			nullDeff.Name = "-----------";
			TypeDropDownList.Items.Clear();
			TypeDropDownList.Items.Add(new ListItem(nullDeff.Name, nullDeff.Code.ToString()));
			TypeDropDownList.SelectedValue = nullDeff.Code.ToString();
			UnitType.SetDropDownList(TypeDropDownList, 0);
			DataTable Markets = jMarkets.GetDataTable(0);
			ConstructionNameDropDownList.DataTextField = estMarket.Title.ToString();
			ConstructionNameDropDownList.DataValueField = estMarket.Code.ToString();
			ConstructionNameDropDownList.DataSource = Markets;
			ConstructionNameDropDownList.DataBind();
			ConstructionNameDropDownList.SelectedValue = null;
		}

		protected override void Render(HtmlTextWriter writer)
		{
			AddAttributesToRender(writer);

			writer.AddAttribute(
				HtmlTextWriterAttribute.Cellpadding,
				"1", false);
			writer.AddAttribute(
				HtmlTextWriterAttribute.Width,
				"400px", false);
			writer.RenderBeginTag(HtmlTextWriterTag.Table);
			SelectedCodeHiddenField.RenderControl(writer);
			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("نام مجتمع/بازار:");
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			ConstructionNameDropDownList.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("نوع واحد:");
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			TypeDropDownList.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("طبقه:");
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			FloorDropDownList.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("شماره شناسایی:");
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			PlaqueTextBox.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.Write("شماره واحد:");
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			NumberTextBox.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.AddAttribute(
				HtmlTextWriterAttribute.Colspan,
				"2", false);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			writer.AddAttribute(
				HtmlTextWriterAttribute.Style,
				"vertical-align: top;overflow-x:scroll;overflow-y:scroll;width:400px;height:250px;", false);
			writer.RenderBeginTag(HtmlTextWriterTag.Div);
			DGV.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			SearchButton.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			OKButton.RenderControl(writer);
			writer.RenderEndTag();
			writer.RenderEndTag();

			writer.RenderEndTag();
		}

		void OKButton_Click(object sender, EventArgs e)
		{
			try
			{
				SelectedCode = int.Parse(DGV.SelectedValue);
				this.Attributes["value"] = DGV.SelectedValue;
			}
			catch
			{
				SelectedCode = -1;
			}
		}

		void SearchButton_Click(object sender, EventArgs e)
		{
			int unitType = 0;
			if (int.TryParse(TypeDropDownList.SelectedValue, out unitType))
				unitType = Convert.ToInt32(TypeDropDownList.SelectedValue);
			int MarketCode = 0;
			if (int.TryParse(ConstructionNameDropDownList.SelectedValue, out MarketCode))
				MarketCode = Convert.ToInt32(ConstructionNameDropDownList.SelectedValue);
			int FloorCode = 0;
			if (int.TryParse(FloorDropDownList.SelectedValue, out FloorCode))
				FloorCode = Convert.ToInt32(FloorDropDownList.SelectedValue);
			DGV.DataSource = JUnitBuilds.Search(0, unitType, MarketCode, PlaqueTextBox.Text, NumberTextBox.Text, FloorCode);
		}

		void ConstructionNameDropDownList_SelectedIndexChanged(object sender, EventArgs e)
		{
			int CodeMarket = Convert.ToInt32(ConstructionNameDropDownList.SelectedValue);
			jMarketFloors Floor = new jMarketFloors();
			DataTable TableFloor = Floor.GetDataByMarketCode(CodeMarket);
			FloorDropDownList.DataSource = TableFloor;
			FloorDropDownList.DataTextField = estMarketFloors.Name.ToString();
			FloorDropDownList.DataValueField = estMarketFloors.Code.ToString();
			FloorDropDownList.DataBind();
		}

		#region Properties
		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public int SelectedCode
		{
			get
			{
				if (ViewState["SelectedCode"] != null)
					return (int)ViewState["SelectedCode"];
				return -1;
			}
			set
			{
				ViewState["SelectedCode"] = value;
			}
		}

		[Bindable(true)]
		[Category("Data")]
		[DefaultValue(null)]
		[Localizable(true)]
		public string ParentDialog
		{
			get
			{
				if (ViewState["ParentDialog"] != null)
					return ViewState["ParentDialog"].ToString();
				return null;
			}
			set
			{
				ViewState["ParentDialog"] = value;
			}
		}
		#endregion
	}
}
