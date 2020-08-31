using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public partial class SearchProduct : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        /* [JsonProperty("status")]
         [DataMember(Name = "status")]
         public string Status { get; set; }

         [JsonProperty("data")]
         [DataMember(Name = "data")]
         public Datum[] Data { get; set; }
     }
     public partial class Datum
     {
         */
        private double? discountPrice;
        private double discountPercent;
        private List<string> previewImages;
        private ObservableCollection<Review> reviews = new ObservableCollection<Review>();
        private bool isFavourite;
        private int totalQuantity;

        [DataMember(Name = "overallrating")]
        public double OverallRating { get; set; }
        [DataMember(Name = "reviews")]
        public ObservableCollection<Review> Reviews
        {
            get
            {
                return this.reviews;
            }

            set
            {
                this.reviews = value;
                this.NotifyPropertyChanged(nameof(Reviews));
            }
        }


        public bool AnyDiscount
        {
            get
            {
                if (SellingPrice < mrp)
                    return true;
                else
                    return false;
            }
        } 

        [DataMember(Name = "ImageLinkFlag")]
        public string ImageLinkFlag;

        [DataMember(Name = "IsDelete")]
        private string IsDelete;


        [DataMember(Name = "previewimage")]
        public string PreviewImage
        {
            get
            {
                if (string.IsNullOrEmpty(ImageLinkFlag))
                {
                    return App.product_url + this.productPicUrl;
                }
                if (ImageLinkFlag.ToLower() == "f")
                {
                    return this.productPicUrl;
                }
                else
                {
                    return App.product_url + this.productPicUrl;
                }
            }
            set { this.productPicUrl = value; }

        }
        [DataMember(Name = "previewimages")]
        public List<string> PreviewImages
        {
            get
            {
               
                this.previewImages[0] = App.product_url + this.productPicUrl;
                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
            }
        }
        [DataMember(Name = "actualprice")]
        public double? ActualPrice
        {
            get
            {
                return this.SellingPrice;
            }

            set
            {
                this.SellingPrice = value;
                this.NotifyPropertyChanged(nameof(ActualPrice));
            }
        }
        public double? DiscountPrice
        {
            get
            {
                return this.ActualPrice - (this.ActualPrice * (this.DiscountPercent / 100));
            }

            set
            {
                this.discountPrice = value;
                this.NotifyPropertyChanged(nameof(DiscountPrice));
            }
        }

        [DataMember(Name = "discountpercent")]
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }

            set
            {
                this.discountPercent = value;
                this.NotifyPropertyChanged(nameof(DiscountPercent));
            }
        }

        [DataMember(Name = "quantities")]
        public List<object> Quantities { get; set; } = new List<object> { 1, 2, 3, 4, 5 };

       
        [DataMember(Name = "sizevariants")]
        public List<string> SizeVariants { get; set; } = new List<string> { "XS", "S", "M", "L", "XL" };

        
        [DataMember(Name = "isfavourite")]
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }

            set
            {
                this.isFavourite = value;
                this.NotifyPropertyChanged(nameof(IsFavourite));
            }
        }

        
        [DataMember(Name = "totalquantity")]
        public int TotalQuantity
        {
            get
            {
                return this.totalQuantity;
            }

            set
            {
                this.totalQuantity = value;
                this.NotifyPropertyChanged(nameof(TotalQuantity));
            }
        }
        [DataMember(Name = "CitrineProdId")]

        public int CitrineProdId { get; set; }

        [DataMember(Name = "ProductIdId")]

        public int? ProductIdId { get; set; }

        [DataMember(Name = "productName")]

        public string productName { get; set; }

        [DataMember(Name = "productDesc")]

        public string ProductDesc { get; set; }

        [DataMember(Name = "SubCategoryId")]

        public int? SubCategoryId { get; set; }

        [DataMember(Name = "SubCategoryName")]
        public string SubCategoryName { get; set; }

        [DataMember(Name = "mrp")]

        public double? mrp { get; set; }

        [DataMember(Name = "discount")]

        public double? discount { get; set; }

        [DataMember(Name = "SellingPrice")]

        public double? SellingPrice { get; set; }

        [DataMember(Name = "UOM")]

        public string UOM { get; set; }

        [DataMember(Name = "CreatedBy")]
        public string CreatedBy { get; set; }

        [DataMember(Name = "VisibilityStatus")]
        public string VisibilityStatus { get; set; }

        [DataMember(Name = "QuantityList")]

        public string QuantityList { get; set; }

        [DataMember(Name = "CreeatedDate")]

        public DateTime CreeatedDate { get; set; }

        [DataMember(Name = "ModifiedDate")]

        public DateTime ModifiedDate { get; set; }

        [DataMember(Name = "productPicUrl")]

        public string productPicUrl { get; set; }

        [DataMember(Name = "MerchantBranchId")]

        public int MerchantBranchId { get; set; }

        [DataMember(Name = "Availability_Status")]

        public string Availability_Status { get; set; }
    }
}
