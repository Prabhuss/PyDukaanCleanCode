using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    /// <summary>
    /// Model for pages with product.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class Product : INotifyPropertyChanged
    {
        #region Fields

        private bool isFavourite;
        private bool anyDiscount;

        private string previewImage;

        [DataMember(Name = "ImageLinkFlag")]
        private string ImageLinkFlag;

        [DataMember(Name = "IsDelete")]
        private string IsDelete;

        private List<string> previewImages;

        private int totalQuantity;

        private double actualPrice;

        private double? discountPrice;

        private double discountPercent;

        private ObservableCollection<Review> reviews = new ObservableCollection<Review>();

        #endregion

        #region Event

        /// <summary>
        /// The declaration of property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the property that holds the product id.
        /// </summary>
        [DataMember(Name = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with Xamarin.Forms Image, which displays the product image.
        /// </summary>
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
            // get { return App.BaseImageUrl + this.previewImage; }
            /*  get { return App.product_url + this.previewImage; }
              set { this.previewImage = value; }
              */

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
            set { this.anyDiscount = value; }
        }
        /// <summary>
        /// Gets or sets the property that has been bound with SfRotator, which displays the item images.
        /// </summary>
        [DataMember(Name = "previewimages")]
        public List<string> PreviewImages
        {
            get
            {
                /* for (var i = 0; i < this.previewImages.Count; i++)
                 {
                     // this.previewImages[i] = this.previewImages[i].Contains(App.BaseImageUrl) ? this.previewImages[i] : App.BaseImageUrl + this.previewImages[i];
                     this.previewImages[i] = this.previewImages[i].Contains(App.product_url) ? this.previewImages[i] : App.product_url + this.previewImages[i];
                 }
                 */
                this.previewImages[0] = App.product_url + this.productPicUrl;
                return this.previewImages;
            }

            set
            {
                this.previewImages = value;
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product name.
        /// </summary>
        [DataMember(Name = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product summary.
        /// </summary>
        [DataMember(Name = "summary")]
        public string Summary { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the product description.
        /// </summary>
        [DataMember(Name = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the actual price of the product.
        /// </summary>
        [DataMember(Name = "actualprice")]
        public double? ActualPrice
        {
            get
            {
                //return this.actualPrice;
                return this.SellingPrice;
            }

            set
            {
                //this.actualPrice = value;
                this.SellingPrice = value;
                this.NotifyPropertyChanged(nameof(ActualPrice));
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the discounted price of the product.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the property that has been bound with a label, which displays the discounted percent of the product.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the overall rating of the product.
        /// </summary>
        [DataMember(Name = "overallrating")]
        public double OverallRating { get; set; }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the customer review.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the seller.
        /// </summary>
        public string SellerName { get; set; }

        /// <summary>
        /// Gets or sets the property has been bound with SfCombobox which displays selected quantity of product.
        /// </summary>
        [DataMember(Name = "quantities")]
        public List<object> Quantities { get; set; } = new List<object> { 1, 2, 3, 4, 5, 6, 7, 8 ,9  };

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the product variants.
        /// </summary>
        [DataMember(Name = "sizevariants")]
        public List<string> SizeVariants { get; set; } = new List<string> { "XS", "S", "M", "L", "XL" };

        /// <summary>
        /// Gets or sets a value indicating whether the cart is favorite.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the property that has been bound with SfCombobox, which displays the total quantity.
        /// </summary>
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
        public int ProductIdId { get; set; }

        [DataMember(Name = "productName")]
        public string productName { get; set; }

        [DataMember(Name = "productDesc")]
        public string productDesc { get; set; }

        [DataMember(Name = "Category")]
        public string Category { get; set; }

        [DataMember(Name = "SubCategory")]
        public string SubCategory { get; set; }

        [DataMember(Name = "mrp")]
        public double? mrp { get; set; }

        [DataMember(Name = "discount")]
        public double? discount { get; set; }

        [DataMember(Name = "SellingPrice")]
        // public int SellingPrice { get; set; }
        public double? SellingPrice { get; set; }

        [DataMember(Name = "UOM")]
        public string UOM { get; set; }

        [DataMember(Name = "CreatedBY")]
        public object CreatedBY { get; set; }

        [DataMember(Name = "VisibilityStatus")]
        public string VisibilityStatus { get; set; }

        [DataMember(Name = "QuantityList")]
        public string QuantityList { get; set; }

        [DataMember(Name = "CreeatedDate")]
        public DateTime CreeatedDate { get; set; }

        [DataMember(Name = "ModifiedDate")]
        public object ModifiedDate { get; set; }

        [DataMember(Name = "productPicUrl")]
        public string productPicUrl { get; set; }

        [DataMember(Name = "MerchantBranchId")]
        public int MerchantBranchId { get; set; }

        [DataMember(Name = "Availability_Status")]
        public object Availability_Status { get; set; }

        [DataMember(Name = "Availability_Status_Bool")]
        public bool AvailabilityStatusBool { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">Property name</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}