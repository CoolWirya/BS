using ClassLibrary;
using JJson.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace JJsonAdditionalLibrary.JsonComponents
{
	public class JLoginManager
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public string NewPassword { get; set; }

		//Signup properties
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string FatherName { get; set; }
		public bool Gender { get; set; }
		public string Shsh { get; set; }
		public int Sader { get; set; }
		public string NCode { get; set; }
		public string PersonelCode { get; set; }
		public DateTime Birthday { get; set; }
		public bool LegalConfirm { get; set; }
		public string HomeAddress { get; set; }
		public string WorkAddress { get; set; }
		public string Desc { get; set; }
		public int BirthdayPlace { get; set; }
        public string HomePostalCode { get; set; }
        public string Tel { get; set; }
        public string Fax { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int City { get; set; }
        public string WorkPostalCode { get; set; }
        public string WorkTel { get; set; }
        public string WorkFax { get; set; }
        public int WorkCity { get; set; }
		public bool Login()
		{
			
			try
			{
				return WebClassLibrary.Authentication.Authentication.Authenticate(UserName, Password);
				
					
				
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				WebClassLibrary.SessionManager.Current.Dispose();
				
			}
		}

		public bool ChangePassword()
		{

			UserName = WebClassLibrary.SessionManager.Current.MainFrame.CurrentUser.username;
			try
			{
				if (!Login())
					return false;
				WebClassLibrary.Authentication.Authentication.ChangeUserPassword(NewPassword);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
			finally
			{
				WebClassLibrary.SessionManager.Current.Dispose();
				
			}
		}

		public bool Signup()
		{
			JPerson person = new JPerson();
			person.Name = FirstName;
			person.Fam = LastName;
			person.Gender = Gender;
			person.FatherName = FatherName;
			person.ShSh = Shsh;
			person.ShMeli = NCode;
			person.Sader = Sader;
			person.PDesc = Desc;
			person.LegelConfirm = LegalConfirm;
			person.BthDate = Birthday;
			person.BirthplaceCode = BirthdayPlace;
			int pCode=person.insert();
			if (pCode == 0)
				return false;
			person.HomeAddress = new JPersonAddress();
			person.HomeAddress.AddressType=JAddressTypes.Home;
			person.HomeAddress.Address=HomeAddress;
			person.HomeAddress.PCode = pCode;
            person.HomeAddress.City = City;
            person.HomeAddress.Email = Email;
            person.HomeAddress.Fax = Fax;
            person.HomeAddress.Mobile = Mobile;
            person.HomeAddress.PostalCode = HomePostalCode;
            person.HomeAddress.Tel = Tel;
			int hAddress=person.HomeAddress.Insert();
			if (hAddress == 0)
				return false;
			person.WorkAddress = new JPersonAddress();
			person.WorkAddress.AddressType=JAddressTypes.Work;
			person.WorkAddress.Address=WorkAddress;
			person.WorkAddress.PCode = pCode;
            person.WorkAddress.Fax = WorkFax;
            person.WorkAddress.PostalCode = WorkPostalCode;
            person.WorkAddress.Tel = WorkTel;
            person.WorkAddress.City = WorkCity;
			int wAddress=person.WorkAddress.Insert();
			if (wAddress == 0)
				return false;
			return true;
			
			
			
		}

		public int StateCode { get; set; }

		public string FillCity()
		{
			return JJson.Methods.GetJson(new JCities().GetCitiesByState(StateCode));
		}

        public bool gTest { get; set; }
        public string test()
        {
            if (gTest)
                return "زن";
            return "مرد";
        }
		
	}
}