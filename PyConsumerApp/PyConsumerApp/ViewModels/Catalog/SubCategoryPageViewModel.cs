using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.Views.Bookmarks;
using PyConsumerApp.Views.Catalog;
using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Catalog
{
    [Preserve(AllMembers = true)]
    [DataContract]
    public class SubCategoryPageViewModel : BaseViewModel
    {
        #region Fields

        bool isBusy;

        private int cartItemCount;

        private ObservableCollection<SubCategory> categories;

        private Command categorySelectedCommand;

        private Command expandingCommand;

        private Command notificationCommand;

        private Command backButtonCommand;

        private Command searchButtonCommand;

        private Command cardItemCommand;
        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with StackLayout, which displays the categories using ComboBox.
        /// </summary>
        [DataMember(Name = "categories")]
        public ObservableCollection<SubCategory> Categories
        {
            get { return this.categories; }
            set
            {
                if (this.categories == value)
                {
                    return;
                }

                this.categories = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Category is selected.
        /// </summary>
        public Command CategorySelectedCommand
        {
            get { return categorySelectedCommand ?? (categorySelectedCommand = new Command(CategorySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Notification button is clicked.
        /// </summary>
        public Command NotificationCommand
        {
            get { return notificationCommand ?? (notificationCommand = new Command(this.NotificationClicked)); }
        }

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand
        {
            get { return backButtonCommand ?? (this.backButtonCommand = new Command(this.BackButtonClicked)); }
        }

        public Command SearchButtonCommand
        {
            get { return searchButtonCommand ?? (this.searchButtonCommand = new Command(this.SearchButtonClicked)); }
        }

        public Command CardItemCommand
        {
            get { return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked)); }
        }
        #endregion

        #region Methods

        /// <summary>
        /// Invoked when the Category is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        /// 
        public bool IsLoading
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsLoading");
            }
        }
        public int CartItemCount
        {
            get => cartItemCount;
            set
            {
                cartItemCount = value;
                NotifyPropertyChanged();
            }
        }
        public async void UpdateCartItemCount()
        {
            try
            {
                {

                    var cartItems = await CartDataService.Instance.GetCartItemAsync();
                    if (cartItems != null) CartItemCount = cartItems.Count;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
        }
        private async void CategorySelected(object obj)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    IsBusy = true;
                    //var items = await CategoryDataService.Instance.GetSubCategories((Category)obj);
                    var items = await CategoryDataService.Instance.GetSubCategories((SubCategory)obj);
                    string selectedCategoryName = ((SubCategory)obj).Name;
                    if (items != null)
                    {
                        await Navigation.PushAsync(new SubCategoryPage(items));
                        await Task.Delay(100);
                        IsBusy = false;
                    }
                    else
                    {
                        //await Navigation.PushAsync(new CatalogListPage((Category)obj));
                        await Navigation.PushAsync(new CatalogListPage((SubCategory)obj));
                        await Task.Delay(100);
                        IsBusy = false;
                    }
                }
                finally
                {
                    //IsLoading = false;
                    IsBusy = false;
                }
            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().ShortTime("No Internet Connection");
                }
                catch { }
                IsBusy = false;
            }


        }
        private async void CartClicked(object obj)
        {
            try
            {
                IsBusy = true;
                if (CartItemCount > 0)
                    await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
            }
            catch (Exception e)
            {

            }
            finally
            {
                IsBusy = false;
            }
            

        }
        /// <summary>
        /// Invoked when the notification button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void NotificationClicked(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when an back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void BackButtonClicked(object obj)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
        private async void SearchButtonClicked(object obj)
        {
            await Navigation.PushAsync(new SearchItem());
        }
        #endregion
    }
}
