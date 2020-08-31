using Newtonsoft.Json;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    /// <summary>
    /// Model for health profile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]

    // public class HealthProfile : INotifyPropertyChanged
    public class CustomerProfile : INotifyPropertyChanged
    {
        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Property

        [JsonProperty("StoreCustomerId")]
        [DataMember(Name = "StoreCustomerId")]

        public int StoreCustomerId { get; set; }

        [JsonProperty("MerchantBranchId")]
        [DataMember(Name = "MerchantBranchId")]

        public int? MerchantBranchId { get; set; }

        [JsonProperty("Source")]
        [DataMember(Name = "Source")]

        public string Source { get; set; }

        [JsonProperty("CustomerType")]
        [DataMember(Name = "CustomerType")]

        public string CustomerType { get; set; }

        [JsonProperty("FirstName")]
        [DataMember(Name = "FirstName")]

        public string FirstName { get; set; }

        [JsonProperty("LastName")]
        [DataMember(Name = "LastName")]

        public string LastName { get; set; }

        [JsonProperty("CompanyName")]
        [DataMember(Name = "CompanyName")]

        public string CompanyName { get; set; }

        [JsonProperty("CompanyWebsite")]
        [DataMember(Name = "CompanyWebsite")]

        public string CompanyWebsite { get; set; }

        [JsonProperty("PrimaryPhone")]
        [DataMember(Name = "PrimaryPhone")]

        public string PrimaryPhone { get; set; }

        [JsonProperty("SecondaryPhone")]
        [DataMember(Name = "SecondaryPhone")]

        public string SecondaryPhone { get; set; }

        [JsonProperty("Email")]
        [DataMember(Name = "Email")]

        public string Email { get; set; }

        [JsonProperty("Address1")]
        [DataMember(Name = "Address1")]

        public string Address1 { get; set; }

        [JsonProperty("Address2")]
        [DataMember(Name = "Address2")]

        public string Address2 { get; set; }

        [JsonProperty("Country")]
        [DataMember(Name = "Country")]

        public string Country { get; set; }

        [JsonProperty("State")]
        [DataMember(Name = "State")]

        public string State { get; set; }

        [JsonProperty("City")]
        [DataMember(Name = "City")]

        public string City { get; set; }

        [JsonProperty("ZipCode")]
        [DataMember(Name = "ZipCode")]

        public string ZipCode { get; set; }

        [JsonProperty("BirthMonth")]
        [DataMember(Name = "BirthMonth")]

        public string BirthMonth { get; set; }

        [JsonProperty("BirthDay")]
        [DataMember(Name = "BirthDay")]

        public string BirthDay { get; set; }

        [JsonProperty("AnnivMonth")]
        [DataMember(Name = "AnnivMonth")]

        public string AnnivMonth { get; set; }

        [JsonProperty("AnnivDay")]
        [DataMember(Name = "AnnivDay")]

        public string AnnivDay { get; set; }

        [JsonProperty("PosId")]
        [DataMember(Name = "PosId")]

        public string PosId { get; set; }

        [JsonProperty("BranchId")]
        [DataMember(Name = "BranchId")]

        public string BranchId { get; set; }

        [JsonProperty("CreatedDate")]
        [DataMember(Name = "CreatedDate")]

        public string CreatedDate { get; set; }

        [JsonProperty("CreatedBy")]
        [DataMember(Name = "CreatedBy")]

        public string CreatedBy { get; set; }

        [JsonProperty("ModifiedDate")]
        [DataMember(Name = "ModifiedDate")]

        public string ModifiedDate { get; set; }

        [JsonProperty("ModifiedBy")]
        [DataMember(Name = "ModifiedBy")]

        public string ModifiedBy { get; set; }

        [JsonProperty("ExternalCustomerId")]
        [DataMember(Name = "ExternalCustomerId")]

        public object ExternalCustomerId { get; set; }

        [JsonProperty("Latitude")]
        [DataMember(Name = "Latitude")]

        public object Latitude { get; set; }

        [JsonProperty("Longitude")]
        [DataMember(Name = "Longitude")]

        public object Longitude { get; set; }

        [JsonProperty("GMAP_Address1")]
        [DataMember(Name = "GMAP_Address1")]

        public object GmapAddress1 { get; set; }

        [JsonProperty("GMAP_Address2")]
        [DataMember(Name = "GMAP_Address2")]

        public object GmapAddress2 { get; set; }

        [JsonProperty("GMAP_Country")]
        [DataMember(Name = "GMAP_Country")]

        public object GmapCountry { get; set; }

        [JsonProperty("GMAP_City")]
        [DataMember(Name = "GMAP_City")]

        public object GmapCity { get; set; }

        [JsonProperty("GMAP_ZipCode")]
        [DataMember(Name = "GMAP_ZipCode")]

        public object GmapZipCode { get; set; }

        [JsonProperty("OTP")]
        [DataMember(Name = "OTP")]

        public object Otp { get; set; }

        [JsonProperty("TotalLoyaltyPoints")]
        [DataMember(Name = "TotalLoyaltyPoints")]

        public object TotalLoyaltyPoints { get; set; }

        [JsonProperty("OTPNum")]
        [DataMember(Name = "OTPNum")]

        public object OtpNum { get; set; }

        [JsonProperty("NextDayTotalLoyaltyPoint")]
        [DataMember(Name = "NextDayTotalLoyaltyPoint")]

        public object NextDayTotalLoyaltyPoint { get; set; }

        [JsonProperty("FirstRegistrationDate")]
        [DataMember(Name = "FirstRegistrationDate")]

        public object FirstRegistrationDate { get; set; }

        [JsonProperty("SecondRegistrationDate")]
        [DataMember(Name = "SecondRegistrationDate")]

        public object SecondRegistrationDate { get; set; }

        [JsonProperty("ThirdRegistrationDate")]
        [DataMember(Name = "ThirdRegistrationDate")]

        public object ThirdRegistrationDate { get; set; }

        [JsonProperty("Device")]
        [DataMember(Name = "Device")]

        public object Device { get; set; }

        [JsonProperty("AccessKey")]
        [DataMember(Name = "AccessKey")]

        public string AccessKey { get; set; }

        [JsonProperty("VerifyFlag")]
        [DataMember(Name = "VerifyFlag")]

        public object VerifyFlag { get; set; }
        /* public string FirstName { get; set; }
         public string LastName { get; set; }
         public string PrimaryPhone { get; set; }
         public string Email { get; set; }
         public string Address1 { get; set; }
         public string City { get; set; }
         public string State { get; set; }
         public string Country { get; set; }
         public string ZipCode { get; set; }
         public string TotalLoyaltyPoints { get; set; }
         public string AddressType { get; set; }*/



        #endregion


        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        protected void OnPropertyChanged(string property)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #endregion
    }
}