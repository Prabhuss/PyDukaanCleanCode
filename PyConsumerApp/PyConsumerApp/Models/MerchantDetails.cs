using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class Merchantdata
    {
        [DataMember(Name = "ID")]
        public int ID { get; set; }
        [DataMember(Name = "MerchantBranchId")]
        public int MerchantBranchId { get; set; }
        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }
        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }
        [DataMember(Name = "ModifiedDate")]
        public DateTime ModifiedDate { get; set; }
        [DataMember(Name = "SettingCategory")]
        public string SettingCategory { get; set; }
        [DataMember(Name = "SettingName")]
        public string SettingName { get; set; }
        [DataMember(Name = "SettingIsActive")]
        public string SettingIsActive { get; set; }
        [DataMember(Name = "SettingValue")]
        public string SettingValue { get; set; }
        [DataMember(Name = "SettingMessage")]
        public string SettingMessage { get; set; }

    }

    public partial class Data
    {
        [DataMember(Name = "merchantdata")]
        public Merchantdata merchantdata { get; set; }

    }

    public class MerchantDetails
    {
        [DataMember(Name = "status")]
        public string status { get; set; }

        [DataMember(Name = "data")]
        public Data data { get; set; }
    }



}
