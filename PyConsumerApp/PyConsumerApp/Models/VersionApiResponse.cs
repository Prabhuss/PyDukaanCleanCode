using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    class VersionApiResponse
    {
        [DataMember(Name ="status")]
        public string Status { get; set; }

        [DataMember(Name ="data")]
        public VersionApiData Data { get; set; }

    }
    public partial class VersionApiData
    {
        [DataMember(Name ="AppInfo")]
        public VersionAppInfo AppInfo { get; set; }
    }

    public partial class VersionAppInfo
    {
        [DataMember(Name ="ID")]
        public long Id { get; set; }

        [DataMember(Name ="MerchantBranchId")]
        public long MerchantBranchId { get; set; }

        [DataMember(Name ="AppName")]
        public string AppName { get; set; }

        [DataMember(Name ="AppVersion")]
        public long AppVersion { get; set; }

        [DataMember(Name ="CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [DataMember(Name ="MessageForUpdateVersion")]
        public string MessageForUpdateVersion { get; set; }

        [DataMember(Name ="PlayStoreURL")]
        public string PlayStoreURL { get; set; }

        [DataMember(Name ="UpdateType")]
        public string UpdateType { get; set; }
    }
}
