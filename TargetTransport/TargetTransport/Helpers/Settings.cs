// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace TargetTransport.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

		#endregion


		public static string GeneralSettings
		{
			get
			{
				return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
			}
			set
			{
				AppSettings.AddOrUpdateValue(SettingsKey, value);
			}
		}

        #region Setting URL

        private const string url = "url_key";
        private static readonly string urlDefault = string.Empty;




        public static string Url
        {
            get
            {
                return AppSettings.GetValueOrDefault(url, urlDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(url, value);
            }
        }
        #endregion
        #region Setting UserName

        private const string username = "username_key";
        private static readonly string usernameDefault = string.Empty;




        public static string UserName
        {
            get
            {
                return AppSettings.GetValueOrDefault(username, usernameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(username, value);
            }
        }
        #endregion
        #region Setting Name

        private const string name = "name_key";
        private static readonly string nameDefault = string.Empty;




        public static string Name
        {
            get
            {
                return AppSettings.GetValueOrDefault(name, nameDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(name, value);
            }
        }
        #endregion
        #region Setting Email

        private const string email = "email_key";
        private static readonly string emailDefault = string.Empty;




        public static string Email
        {
            get
            {
                return AppSettings.GetValueOrDefault(email, emailDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(email, value);
            }
        }
        #endregion
        #region Setting Password

        private const string password = "password_key";
        private static readonly string passwordDefault = string.Empty;




        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault(password, passwordDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(password, value);
            }
        }
        #endregion
        #region Setting Gender

        private const string gender = "gender_key";
        private static readonly string genderDefault = string.Empty;




        public static string Gender
        {
            get
            {
                return AppSettings.GetValueOrDefault(gender, genderDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(gender, value);
            }
        }
        #endregion
        #region Setting PhoneNo

        private const string phoneNo = "phoneNo_key";
        private static readonly string phoneNoDefault = string.Empty;




        public static string PhoneNo
        {
            get
            {
                return AppSettings.GetValueOrDefault(phoneNo, phoneNoDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(phoneNo, value);
            }
        }
        #endregion
        #region Setting DOB

        private const string dob = "dob_key";
        private static readonly string dobDefault = string.Empty;

        public static string DOB
        {
            get
            {
                return AppSettings.GetValueOrDefault(dob, dobDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(dob, value);
            }
        }
        #endregion
        #region Setting ProfilePicture

        private const string profilepicture = "profilepicture_key";
        private static readonly string profilepictureDefault = string.Empty;




        public static string ProfilePicture
        {
            get
            {
                return AppSettings.GetValueOrDefault(profilepicture, profilepictureDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(profilepicture, value);
            }
        }
        #endregion
        #region Setting UserPin

        private const string userpin = "userpin_key";
        private static readonly int userpinDefault = 0;




        public static int UserPin
        {
            get
            {
                return AppSettings.GetValueOrDefault(userpin, userpinDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(userpin, value);
            }
        }
        #endregion
        #region Setting Address

        private const string address = "address_key";
        private static readonly string addressDefault = string.Empty;




        public static string Address
        {
            get
            {
                return AppSettings.GetValueOrDefault(address, addressDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(address, value);
            }
        }
        #endregion
        #region Setting TokenCode

        private const string tokenCode = "tokenCode_key";
        private static readonly string tokenCodeDefault = string.Empty;




        public static string TokenCode
        {
            get
            {
                return AppSettings.GetValueOrDefault(tokenCode, tokenCodeDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(tokenCode, value);
            }
        }
        #endregion
        #region Setting UserId

        private const string id = "id_key";
        private static readonly int idDefault = 0;




        public static int UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault(id, idDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(id, value);
            }
        }
        #endregion
        #region Setting RoleId

        private const string roleId = "roleId_key";
        private static readonly int roleIdDefault = 0;

        public static int RoleId
        {
            get
            {
                return AppSettings.GetValueOrDefault(roleId, roleIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(roleId, value);
            }
        }



        #endregion
        #region IsLoggedIn

        private const string isLoggedIn = "isLoggedIn_key";
        private static readonly bool isLoggedInDefault = false;


        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault("isLoggedIn", isLoggedInDefault);
            }
            set
            { AppSettings.AddOrUpdateValue("isLoggedIn", value); }
        }


        #endregion
        #region RememberMe

        private const string rememberme = "rememberme_key";
        private static readonly bool remembermeDefault = false;


        public static bool RememberMe
        {
            get
            {
                return AppSettings.GetValueOrDefault("rememberme", remembermeDefault);
            }
            set
            { AppSettings.AddOrUpdateValue("rememberme", value); }
        }


        #endregion
        #region Setting WorksheetID

        private const string worksheetId = "worksheetId_key";
        private static readonly int worksheetIdDefault = 0;




        public static int WorksheetID
        {
            get
            {
                return AppSettings.GetValueOrDefault(worksheetId, worksheetIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(worksheetId, value);
            }
        }
        #endregion
        #region Setting VehicleID

        private const string vehicleId = "vehicleId_key";
        private static readonly int vehicleIdDefault = 0;




        public static int VehicleID
        {
            get
            {
                return AppSettings.GetValueOrDefault(vehicleId, vehicleIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(vehicleId, value);
            }
        }
        #endregion
        #region Setting RegoNo

        private const string regono = "regono_key";
        private static readonly string regonoDefault = string.Empty;




        public static string RegoNo
        {
            get
            {
                return AppSettings.GetValueOrDefault(regono, regonoDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(regono, value);
            }
        }
        #endregion
        #region Setting CompanyId

        private const string companyId = "companyId_key";
        private static readonly int companyIdDefault = 0;




        public static int CompanyId
        {
            get
            {
                return AppSettings.GetValueOrDefault(companyId, companyIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(companyId, value);
            }
        }
        #endregion
        #region Setting RequestId

        private const string requestId = "requestId_key";
        private static readonly int requestIdDefault = 0;




        public static int RequestId
        {
            get
            {
                return AppSettings.GetValueOrDefault(requestId, requestIdDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(requestId, value);
            }
        }
        #endregion
    }
}