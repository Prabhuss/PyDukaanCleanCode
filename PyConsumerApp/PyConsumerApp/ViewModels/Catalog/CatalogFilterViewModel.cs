using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace PyConsumerApp.ViewModels.Catalog
{
    public class CatalogFilterViewModel : BaseViewModel
    {
        bool isOpen, visible;
        string labelString, userName, password, showdetail;
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand PopupAcceptCommand { get; set; }
        public ICommand ShowPopupCommand { get; set; }
        public string LabelString
        {
            get { return labelString; }
            set
            {
                labelString = value;
                OnPropertyChanged(nameof(LabelString));
            }
        }
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        public string ShowDetail
        {
            get { return showdetail; }
            set
            {
                showdetail = value;
                OnPropertyChanged(nameof(ShowDetail));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public bool PopupOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                OnPropertyChanged(nameof(PopupOpen));
            }
        }
        public bool Visible
        {
            get { return visible; }
            set
            {
                visible = value;
                OnPropertyChanged(nameof(Visible));
            }
        }
        public CatalogFilterViewModel()
        {
            PopupAcceptCommand = new Command(PopupAccept); //CanExecute() will be call the PopupAccept method
            ShowPopupCommand = new Command(Popup);  //CanExecute() will be call the Popup method.
        }

        private void Popup()
        {
            PopupOpen = true;
            LabelString = "User Login";
            Visible = true;
        }

        private void PopupAccept()
        {
            // You can write your set of codes that needs to be executed.
            if ((UserName == "Syncfusion") && (Password == "12345"))
            {
                ShowDetail = "Login Successfully...";
                UserName = "";
                Password = "";
            }
            else
            {
                ShowDetail = "Login Failed";
                UserName = "";
                Password = "";
            }
        }
    }
}
