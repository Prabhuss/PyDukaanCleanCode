using System.Collections.Generic;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
   
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SubCategory
    {
        private string icon;
        private bool isExpanded;
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "subcategories")]
        public List<string> SubCategories { get; set; }

        [DataMember(Name = "SubCategoryId")]
        public int SubCategoryId { get; set; }


        [DataMember(Name = "ImageLinkFlag")]
        public string ImageLinkFlag;


        [DataMember(Name = "IsDelete")]
        public string IsDelete { get; set; }

        [DataMember(Name = "CategoryId")]
        public int CategoryId { get; set; }

        [DataMember(Name = "MerchantId")]
        public int MerchantId { get; set; }


        [DataMember(Name = "icon")]
        public string Icon
        {
            get { return this.icon; }
            set { this.icon = value; }
        }

        public ImageSource IconSource
        {
            get
            {
                if( string.IsNullOrEmpty(ImageLinkFlag))
                {
                    return App.CategoryPicUrl + this.icon;
                }
                if (ImageLinkFlag.ToLower() == "f")
                {
                    return this.icon;
                }
                else
                {
                    return App.CategoryPicUrl + this.icon;
                }
            }
        }

       
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
            }
        }
        
       
    }
}