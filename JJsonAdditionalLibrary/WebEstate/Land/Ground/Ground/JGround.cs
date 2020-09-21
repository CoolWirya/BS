using ClassLibrary;
using Estates;
using Finance;
using RealEstate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JJsonAdditionalLibrary.WebEstate.Land.Ground.Ground
{
	public class JGround
	{
		private Estates.JGround _newGround = new Estates.JGround();
		#region Properties
		public int Code { get; set; }
		public int Land { get; set; }
		public string MainAve { get; set; }
		public string SubNo { get; set; }
		public string PartNum { get; set; }
		public string BlockNum { get; set; }
		public int Usage { get; set; }
		public double Area { get; set; }
		//public DateTime Date { get; set; }
		public string Comment { get; set; }
		//public int Person { get; set; }
		//public string MakeFromName { get; set; }
		public int EstateType { get; set; }
		public int DocumentType { get; set; }
		public bool RightRoot { get; set; }
		public decimal Cost { get; set; }
		public string DocumentNumber { get; set; }
		#endregion

		public string cmbLand_OnChanged()
		{
			return new JLand(Land).Section;
		}

		public bool Insert()
		{
			_newGround.Land = Land;
			_newGround.MainAve = MainAve;
			_newGround.SubNo = SubNo;
			//_newGround.Section = txtSection.Text;
			_newGround.PartNum = PartNum;
			_newGround.BlockNum = BlockNum;
			_newGround.Usage = Usage;
			_newGround.Area = Area;
			_newGround.Date = DateTime.Now;
			_newGround.Comment = Comment;
			_newGround.Person = JMainFrame.CurrentPersonCode;
			_newGround.MakeFromName = "Estates.JPrimaryOwners";
			_newGround.EstateType = EstateType;
			_newGround.DocumentType = DocumentType;
			_newGround.RightRoot = RightRoot;
			_newGround.Cost = Cost;
			_newGround.DocumentNumber = DocumentNumber;
			if (Code == 0)
			{
				Code = _newGround.Insert(null);
				foreach (JDefaultOwner owner in JDefaultOwners.GetDefaultOwners())
				{
					POCode = owner.PCode;
					POShare = owner.Share;
					POGroundCode = Code;
					AddPrimaryOwner();
				}
				return true;
			}
			else if (Code > 0)
			{
				_newGround.Code = Code;
				if (_newGround.Update())
					return true;
			}
			return false;
		}

		public int POCode { get; set; }
		public decimal POShare { get; set; }
		public int POGroundCode { get; set; }
		public int POAssetCode { get; set; }
		public int POMakeFromCode { get; set; }
		public string POMakeFromName { get; set; }
		public bool AddPrimaryOwner()
		{
			if (POGroundCode == 0)
				return false;
			Estates.JGround tmpGround = new Estates.JGround(POGroundCode);
			POAssetCode = tmpGround.FinanceCode;
			POMakeFromCode = tmpGround.MakeFromCode;
			POMakeFromName = tmpGround.MakeFromName;
			Estates.JPrimaryOwner JPOB = new Estates.JPrimaryOwner();
			JDataBase pDb = new JDataBase();
			JPOB.PCode = POCode;
			JPOB.Share = float.Parse(POShare.ToString());
			JPOB.CodeGround = POGroundCode;
			int _Code = JPOB.Insert(pDb);
			JAssetTransfer AssetTransfer = new JAssetTransfer(POAssetCode, JOwnershipType.Definitive, pDb);
			if (AssetTransfer.Code == 0)
			{
				AssetTransfer.ClassName = POMakeFromName;
				if (POMakeFromCode == 0)
					POMakeFromCode = POGroundCode;
				AssetTransfer.ObjectCode = POMakeFromCode;
				AssetTransfer.ACode = POAssetCode;
				AssetTransfer.Comment = JLanguages._Text("PrimaryOwnersOfGroundPlaque:") + this.MainAve;
			}
			//Add Relation
			JRelation tmpJRelation = new JRelation();
			tmpJRelation.PrimaryClassName = "ClassLibrary.Person";
			tmpJRelation.PrimaryObjectCode = JPOB.PCode;
			tmpJRelation.ForeignClassName = "Estates.JPrimaryOwners";
			tmpJRelation.ForeignObjectCode = _Code;
			tmpJRelation.Comment = "برای این زمین مالک اولیه ثبت شده است";
			if (!tmpJRelation.Insert(pDb))
				return false;
			#region Insert AssetShare
			//ذخیره اطلاعات دارایی شخص در جدول دارایی
			JAssetShare AssetShare = new JAssetShare();
			AssetShare.ACode = AssetTransfer.ACode;
			AssetShare.PersonCode = JPOB.PCode;
			AssetShare.Share = JPOB.Share;
			AssetShare.ParentCode = 0;
			AssetShare.Status = JStatusType.Active;
			AssetTransfer.OwnershipType = JOwnershipType.Definitive;
			AssetTransfer.AddItems(AssetShare);
			#endregion
			return true;
		}
	}
}