using Newtonsoft.Json;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class OrderResponse
    {
        [JsonProperty("status")]
        [DataMember(Name = "status")]
        public string Status { get; set; }


        [JsonProperty("data")]
        [DataMember(Name = "data")]
        public OrderData Data { get; set; }
    }
    public partial class OrderData
    {
        [JsonProperty("status")]
        [DataMember(Name = "status")]
        public string Status { get; set; }


        [JsonProperty("message")]
        [DataMember(Name = "message")]
        public string Message { get; set; }


        [JsonProperty("caption")]
        [DataMember(Name = "caption")]
        public string Caption { get; set; }
    }
}
