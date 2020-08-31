using Plugin.Connectivity;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.Views.Navigation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Transaction
{
    /// <summary>
    /// ViewModel for Payment page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class PaymentViewModel : BaseViewModel
    {

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="PaymentViewModel" /> class.
        /// </summary>
        public PaymentViewModel(OrderResponse OrderStatusInfo)
        {
            _paymentSuccessIcon = "PaymentSuccess.svg";
            _paymentFailureIcon = "NoItem.svg";
            ContinueShoppingCommand = new Command(ContinueShoppingClickedAsync);
            SetIcon(OrderStatusInfo);
            SetMessage(OrderStatusInfo.Data);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Gets or sets the command that will be executed when track order button is clicked.
        /// </summary>
        public Command ContinueShoppingCommand { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when track order button is clicked.
        /// </summary>
        private void ContinueShoppingClickedAsync(object obj)
        {
            Application.Current.MainPage = new NavigationPage(new BottomNavigationPage());
            BaseViewModel.Navigation = Application.Current.MainPage.Navigation;

        }
        private void SetIcon(OrderResponse OrderStatusData)
        {
            if (OrderStatusData.Status.ToUpper() == "SUCCESS")
            {
                OrderStatusIcon = _paymentSuccessIcon;
                MainButtonText = "Continue Shopping".ToUpper();
            }
            else
                OrderStatusIcon = _paymentFailureIcon;
        }
        private void SetMessage(OrderData OrderMessageData)
        {
            try
            {
                OrderConfirmCaption = OrderMessageData.Caption;
                OrderConfirmMessage = OrderMessageData.Message;
            }
            catch { }
        }

        private Task DisplayAlert(string v1, string settingMessage, string v2)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Fields

        public string orderConfirmCaption;
        public string orderConfirmMessage;
        private string _mainButtonText;
        public string _paymentSuccessIcon;
        public string _paymentFailureIcon;
        public string _orderStatusIcon;

        #endregion

        #region Properties

        public string OrderStatusIcon
        {
            get { return this._orderStatusIcon; }
            set
            {
                if (this._orderStatusIcon == value)
                {
                    return;
                }

                this._orderStatusIcon = value;
                this.NotifyPropertyChanged();
            }
        }
        public string OrderConfirmCaption
        {
            get { return this.orderConfirmCaption; }
            set
            {
                if (this.orderConfirmCaption == value)
                {
                    return;
                }

                this.orderConfirmCaption = value;
                this.NotifyPropertyChanged();
            }
        }
        public string OrderConfirmMessage
        {
            get { return this.orderConfirmMessage; }
            set
            {
                if (this.orderConfirmMessage == value)
                {
                    return;
                }

                this.orderConfirmMessage = value;
                this.NotifyPropertyChanged();
            }
        }


        public string MainButtonText
        {
            get
            {
                if (_mainButtonText != null)
                    return _mainButtonText;
                return "go back".ToUpper();
            }
            set
            {
                if (_mainButtonText != value)
                {
                    _mainButtonText = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion
    }
}
