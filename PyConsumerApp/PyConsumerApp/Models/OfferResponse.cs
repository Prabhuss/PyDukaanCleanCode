using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class OfferData
    {
        [DataMember(Name = "Id")]
        public int Id { get; set; }

        [DataMember(Name = "MerchantBranchId")]
        public int MerchantBranchId { get; set; }

        [DataMember(Name = "OfferName")]
        public string OfferName { get; set; }

        [DataMember(Name = "OfferDescription")]
        public string OfferDescription { get; set; }

        [DataMember(Name = "OfferCode")]
        public string OfferCode { get; set; }

        [DataMember(Name = "OfferImgURL")]
        public string OfferImgURL { get; set; }

        [DataMember(Name = "ActiveStatus")]
        public string ActiveStatus { get; set; }

        [DataMember(Name = "CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [DataMember(Name = "CreatedBy")]
        public object CreatedBy { get; set; }

        [DataMember(Name = "OfferIconSource")]
        public ImageSource OfferIconSource
        {
            get
            {
                //return  ImageSource.FromResource("PyConsumerApp.Images." + this.icon);
                return App.CategoryPicUrl + this.OfferImgURL;
            }
        }


    }

    public class OfferResponse
    {

        [DataMember(Name = "status")]
        public string status { get; set; }

        [DataMember(Name = "data")]
        public List<OfferData> data { get; set; }

    }
}
