using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class LicenseDetails
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "data")]
        public LicenseData Data { get; set; }
    }

    public partial class LicenseData
    {
        [DataMember(Name = "Id")]
        public long Id { get; set; }

        [DataMember(Name = "MerchantBranchId")]
        public long MerchantBranchId { get; set; }

        [DataMember(Name = "MasterOTP")]
        public long MasterOtp { get; set; }

        [DataMember(Name = "LicenseStatus")]
        public string LicenseStatus { get; set; }

        [DataMember(Name = "LicenseStatusExpiryMsg")]
        public string LicenseStatusExpiryMsg { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [DataMember(Name = "CreatedBy")]
        public object CreatedBy { get; set; }

        [DataMember(Name = "SyncFusionkey")]
        public string SyncFusionkey { get; set; }
    }
}
