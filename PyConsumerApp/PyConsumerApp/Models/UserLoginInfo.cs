using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Models
{
    [DataContract]
    [Preserve(AllMembers = true)]
    public class UserLoginInfo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        [DataMember(Name = "phonenumber")]
        private string phonenumber ;// { get; set; }

        [DataMember(Name = "merchantid")]
        private string merchantid ;// { get; set; }

        public string PhoneNumber
        {
            get
            {
                return this.phonenumber;
            }

            set
            {
                this.phonenumber = value;
                this.NotifyPropertyChanged(nameof(PhoneNumber));
            }
        }

        public string MerchantBranchId
        {
            get
            {
                return this.merchantid;
            }

            set
            {
                this.merchantid = value;
                this.NotifyPropertyChanged(nameof(MerchantBranchId));
            }
        }


    }
}
