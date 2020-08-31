using Syncfusion.DataSource;
using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [DataContract]
    [Preserve(AllMembers = true)]
    public class UserCart : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private Product product;

       // [DataMember(Name = "id")] public int ID { get; set; }

       /// [DataMember(Name = "userid")] public int? UserId { get; set; }

        [DataMember(Name = "productid")] public int? ProductId { get; set; }

        [DataMember(Name = "totalquantity")] public int TotalQuantity { get; set; }

        [DataMember(Name = "product")]
        public Product Product
        {
            get => product;
            set
            {
                product = value;
                OnPropertyChanged();
            }
        }
        
    }
}
