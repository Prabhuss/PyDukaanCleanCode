using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class Data
    {
        [DataMember(Name = "distance")]
        public string distance { get; set; }

    }

    public class DistanceModel
    {
        [DataMember(Name = "status")]
        public string status { get; set; }
        [DataMember(Name = "data")]
        public Data data { get; set; }

    }


}
