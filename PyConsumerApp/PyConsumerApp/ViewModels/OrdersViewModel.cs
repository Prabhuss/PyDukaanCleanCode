/*using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace PyConsumerApp.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Model> Info { get; set; }
        public ObservableCollection<Model> ContactsInfo { get; set; }
        //private bool _isExpanded;
        //public bool IsExpanded
        //{
        //    get { return _isExpanded; }
        //    set
        //    {
        //        _isExpanded = value;
        //        RaisedOnPropertyChanged("IsExpanded");
        //    }
        //}
        public OrdersViewModel()
        {
            Info = new ObservableCollection<Model>();
            Info.Add(new Model() { Name = "Item1", Description = "Information1" });
            Info.Add(new Model() { Name = "Item2", Description = "Information2" });
            Info.Add(new Model() { Name = "Item3", Description = "Information3" });
            Info.Add(new Model() { Name = "Item4", Description = "Information4" });
            Info.Add(new Model() { Name = "Item5", Description = "Information5" });
            //Info.Add(new Model() { Name = "Item1" });
            //Info.Add(new Model() { Name = "Item2" });
            //Info.Add(new Model() { Name = "Item3" });

            ContactsInfo = new ObservableCollection<Model>();
            int i = 0;
            Random r = new Random();
           /* foreach (var cusName in CustomerNames)
            {
                var contact = new Model(cusName);
                contact.CallTime = CallTime[i];
                contact.PhoneImage = ImageSource.FromResource("PyConsumerApp.Images.PhoneImage.png");
                contact.ContactImage = ImageSource.FromResource("PyConsumerApp.Images.Image" + r.Next(0, 19) + ".png");
                contact.AddContact = ImageSource.FromResource("PyConsumerApp.Images.AddContact.png");
                contact.NewContact = ImageSource.FromResource("PyConsumerApp.Images.NewContact.png");
                contact.SendMessage = ImageSource.FromResource("PyConsumerApp.Images.SendMessage.png");
                contact.BlockSpan = ImageSource.FromResource("PyConsumerApp.Images.BlockSpan.png");
                contact.CallDetails = ImageSource.FromResource("PyConsumerApp.Images.CallDetails.png");
                ContactsInfo.Add(contact);
            }*/

        /*}
       // public event PropertyChangedEventHandler PropertyChanged;
        //private void RaisedOnPropertyChanged(string v)
        //{
        //    if (PropertyChanged != null)
        //        PropertyChanged(this, new PropertyChangedEventArgs(v));
        //}

        #region Fields

       /* string[] CustomerNames = new string[] {
            "Kyle",
            "Gina",
            "Irene",
            "Katie",
            "Oscar",
            "Ralph",
            "Torrey",
            "William",
            "Bill",
            "Daniel",
            "Frank",
            "Brenda",
            "Danielle",
            "Fiona",
            "Howard",
            "Jack",
            "Larry",
            "Holly",
            "Liz",
            "Pete",
            "Steve",
            "Vince",
            "Katherin",
            "Aliza",
            "Masona" ,
            "Lia" ,
            "Jacob  " ,
            "Jayden " ,
            "Ethani  " ,
            "Noah   " ,
            "Lucas  " ,
            "Logan  " ,
            "John  " ,
        };

        string[] CallTime = new string[]
        {
            "Tunisia, 1 days ago",
            "Colombia, 1 days ago",
            "Fiji, 1 days ago",
            "Belgium, 1 days ago",
            "Japan, 1 days ago",
            "Argentina, 2 days ago",
            "Mexico, 2 days ago",
            "Guinea, 2 days ago",
            "Australia, 2 days ago",
            "Uruguay, 2 days ago",
            "Denmark, 3 days ago",
            "Peru, 3 days ago",
            "Greece, 3 days ago",
            "Austria, 3 days ago",
            "Hungary, 3 days ago",
            "Japan, 4 days ago",
            "Malaysia, 4 days ago",
            "Bermuda, 4 days ago",
            "Egypt, 4 days ago",
            "Philippines, 4 days ago",
            "Sweden, 5 days ago",
            "Vietnam, 5 days ago",
            "Yemen, 5 days ago",
            "Nepal, 5 days ago",
            "Kenya, 5 days ago",
            "Iceland, 6 days ago",
            "Canada, 6 days ago",
            "Angola, 6 days ago",
            "Italy, 6 days ago",
            "Monaco, 6 days ago",
            "Sudan, 1 week ago",
            "Togo, 1 week ago",
            "Benin, 1 week ago"
        };

        #endregion
    }

    public class Model : INotifyPropertyChanged
    {
        public string Name { get; set; }

        public string Description { get; set; }
        public double innerlistheight { get; set; }
        public ObservableCollection<Id> Idinfo { get; set; }

        private bool isVisible;
        public bool IsVisible
        {
            get { return isVisible; }
            set
            {
                isVisible = value;
                this.RaisedOnPropertyChanged("IsVisible");
            }
        }
        #region ExpandableListView

        private bool isExpanded;
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
                this.RaisedOnPropertyChanged("IsExpanded");
            }
        }

        private string contactName;
        public string ContactName
        {
            get { return contactName; }
            set
            {
                if (contactName != value)
                {
                    contactName = value;
                    this.RaisedOnPropertyChanged("ContactName");
                }
            }
        }

        private string callTime;
        public string CallTime
        {
            get { return callTime; }
            set
            {
                if (callTime != value)
                {
                    callTime = value;
                    this.RaisedOnPropertyChanged("CallTime");
                }
            }
        }

        private ImageSource contactImage;
        public ImageSource ContactImage
        {
            get { return this.contactImage; }
            set
            {
                this.contactImage = value;
                this.RaisedOnPropertyChanged("ContactImage");
            }
        }

        private ImageSource addContact;
        public ImageSource AddContact
        {
            get { return this.addContact; }
            set
            {
                this.addContact = value;
                this.RaisedOnPropertyChanged("AddContact");
            }
        }

        private ImageSource newContact;
        public ImageSource NewContact
        {
            get { return this.newContact; }
            set
            {
                this.newContact = value;
                this.RaisedOnPropertyChanged("NewContact");
            }
        }

        private ImageSource sendMessage;
        public ImageSource SendMessage
        {
            get { return this.sendMessage; }
            set
            {
                this.sendMessage = value;
                this.RaisedOnPropertyChanged("SendMessage");
            }
        }

        private ImageSource blockSpan;
        public ImageSource BlockSpan
        {
            get { return this.blockSpan; }
            set
            {
                this.blockSpan = value;
                this.RaisedOnPropertyChanged("BlockSpan");
            }
        }

        private ImageSource callDetails;
        public ImageSource CallDetails
        {
            get { return this.callDetails; }
            set
            {
                this.callDetails = value;
                this.RaisedOnPropertyChanged("CallDetails");
            }
        }

        private ImageSource phoneImage;
        public ImageSource PhoneImage
        {
            get { return this.phoneImage; }
            set
            {
                this.phoneImage = value;
                this.RaisedOnPropertyChanged("PhoneImage");
            }
        }

        public Model()
        {
            Idinfo = new ObservableCollection<Id>();
            Idinfo.Add(new Id() { Idno = "1" });
            Idinfo.Add(new Id() { Idno = "2" });
            Idinfo.Add(new Id() { Idno = "3" });
        }
        public Model(string Name)
        {
            contactName = Name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisedOnPropertyChanged(string _PropertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(_PropertyName));
            }
        }

        #endregion
    }

    public class Id
    {
        public string Idno { get; set; }
    }
}*/
