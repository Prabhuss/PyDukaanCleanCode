using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.Views.Transaction;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Bookmarks
{
    /// <summary>
    /// ViewModel for cart page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CartPageViewModel : BaseViewModel
    {
        #region Fields
        bool isBusy;

        private ObservableCollection<Product> cartDetails;

        private double? totalPrice;

        private double? discountPrice;

        private double discountPercent;

        private double percent;

        private bool isEmptyViewVisible;

        private ObservableCollection<Product> produts;

        private Command placeOrderCommand;

        private Command removeCommand;

        private Command quantitySelectedCommand;

        private Command variantSelectedCommand;

        private Command applyCouponCommand;
        private bool buttonActive;

        private Command backButtonCommand;
        private ObservableCollection<UserCart> userCarts;
        private readonly CartDataService cartDataService;
        #endregion

        public bool ButtonActive
        {
            get => buttonActive;

            set
            {
                if (buttonActive == value) return;

                buttonActive = value;
                NotifyPropertyChanged();
            }
        }

        public CartPageViewModel(CartDataService cartDataService)
        {
            ButtonActive = true;
            this.cartDataService = cartDataService;
        }

        #region Public properties

        public bool IsEmptyViewVisible
        {
            get => isEmptyViewVisible;

            set
            {
                if (isEmptyViewVisible == value) return;

                isEmptyViewVisible = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<UserCart> UserCarts
        {
            get => userCarts;

            set
            {
                if (userCarts == value) return;

                userCarts = value;
                NotifyPropertyChanged();
                this.UpdatePrice();
            }
        }


        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the cart details.
        /// </summary>
        public ObservableCollection<Product> CartDetails
        {
            get
            {
                return this.cartDetails;
            }

            set
            {
                if (this.cartDetails == value)
                {
                    return;
                }

                this.cartDetails = value;
                this.NotifyPropertyChanged();
                //this.GetProducts(CartDetails);
                //this.UpdatePrice();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays the total price.
        /// </summary>
        public double? TotalPrice
        {
            get
            {
                return this.totalPrice;
            }

            set
            {
                if (this.totalPrice == value)
                {
                    return;
                }

                this.totalPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays total discount price.
        /// </summary>
        public double? DiscountPrice
        {
            get
            {
                return this.discountPrice;
            }

            set
            {
                if (this.discountPrice == value)
                {
                    return;
                }

                this.discountPrice = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with label, which displays discount.
        /// </summary>
        public double DiscountPercent
        {
            get
            {
                return this.discountPercent;
            }

            set
            {
                if (this.discountPercent == value)
                {
                    return;
                }

                this.discountPercent = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with list view, which displays the collection of products from json.
        /// </summary>

        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.produts;
            }

            set
            {
                if (this.produts == value)
                {
                    return;
                }
                this.produts = value;
                this.NotifyPropertyChanged();
                this.GetProducts(Products);
                this.UpdatePrice();
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when the Edit button is clicked.
        /// </summary>
        public Command PlaceOrderCommand
        {
            get { return this.placeOrderCommand ?? (this.placeOrderCommand = new Command(this.PlaceOrderClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Remove button is clicked.
        /// </summary>
        public Command RemoveCommand
        {
            get { return this.removeCommand ?? (this.removeCommand = new Command(this.RemoveClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the quantity is selected.
        /// </summary>
        public Command QuantitySelectedCommand
        {
            get { return this.quantitySelectedCommand ?? (this.quantitySelectedCommand = new Command(this.QuantitySelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the variant is selected.
        /// </summary>
        public Command VariantSelectedCommand
        {
            get { return this.variantSelectedCommand ?? (this.variantSelectedCommand = new Command(this.VariantSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the apply coupon is clicked.
        /// </summary>
        public Command ApplyCouponCommand
        {
            get { return this.applyCouponCommand ?? (this.applyCouponCommand = new Command(this.ApplyCouponClicked)); }
        }

        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        public Command BackButtonCommand
        {
            get { return this.backButtonCommand ?? (this.backButtonCommand = new Command(this.BackButtonClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void PlaceOrderClicked(object obj)
        {
            IsBusy = true;
            if (!ButtonActive)
                return;
            ButtonActive = false;
             // Do something
             await Application.Current.MainPage.Navigation.PushAsync(new CheckoutPage());
            ButtonActive = true;
        }

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void RemoveClicked(object obj)
        {
            try
            {
                if (obj != null && obj is UserCart userCart && userCart != null)
                    {
                    var status = await cartDataService.RemoveCartItemsAsync(userCart.Product.CitrineProdId);
                    if (status != null && status.IsSuccess)
                    {
                        UserCarts.Remove(userCart);
                        UpdatePrice();

                        if (userCarts.Count == 0)
                        {
                           /* if (Application.Current.MainPage is NavigationPage &&
                                (Application.Current.MainPage as NavigationPage).CurrentPage is BottomNavigationPage)
                                */
                                IsEmptyViewVisible = true;
                            //else
                                //await Application.Current.MainPage.Navigation.PushAsync(new EmptyCartPage(true));
                        }
                        else
                        {
                            IsEmptyViewVisible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            /*
           // if (obj is Product product)
            //if (obj != null)
            {
                Product product = obj["Product"];
                this.CartDetails.Remove(product);
                this.UpdatePrice();

                if (this.CartDetails.Count == 0)
                {
                    SfPopupView sfPopupView = new SfPopupView();
                    sfPopupView.ShowPopUp(content: "Your cart is empty!", buttonText: "CONTINUE SHOPPING");
                }
            }
            */
        }

        /// <summary>
        /// Invoked when the quantity is selected.
        /// </summary>
        /// <param name="selectedItem">The Object</param>
        private async void QuantitySelected(object selectedItem)
        {
            try
            {
                if (selectedItem != null && selectedItem is UserCart userCart && userCart != null)
                {
                    var status = await cartDataService.UpdateQuantityAsync(userCart.Product.CitrineProdId, userCart.TotalQuantity);
                    if (status != null && status.IsSuccess) 
                    UpdatePrice();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            //Incident - 249030 - Issue in ComboBox Slection changed event.

            //var item = selectedItem as CartProduct;

            //this.UpdatePrice();
            //item.ActualPrice = item.ActualPrice * item.TotalQuantity;
            //item.DiscountPrice = item.DiscountPrice * item.TotalQuantity;
        }

        /// <summary>
        /// Invoked when the variant is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void VariantSelected(object obj)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the apply coupon button is selected.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void ApplyCouponClicked(object obj)
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

        /// <summary>
        /// This method is used to get the products from json.
        /// </summary>
        /// <param name="Products">The Products</param>
        private void GetProducts(ObservableCollection<Product> Products)
        {
            try
            {
                this.CartDetails = new ObservableCollection<Product>();
                if (Products != null && Products.Count > 0)
                    this.CartDetails = Products;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method is used to update the price amount.
        /// </summary>
        private void UpdatePrice()
        {
            this.ResetPriceValue();
            if (this.UserCarts != null && this.UserCarts.Count > 0)
            {
                foreach (var cartDetail in this.UserCarts)
                {
                    if (cartDetail.TotalQuantity == 0) cartDetail.TotalQuantity = 1;

                    this.TotalPrice += cartDetail.Product.ActualPrice * cartDetail.TotalQuantity;
                    this.DiscountPrice += cartDetail.Product.DiscountPrice * cartDetail.TotalQuantity;
                    this.percent += cartDetail.Product.DiscountPercent;
                }

                this.DiscountPercent = this.percent > 0 ? this.percent / this.CartDetails.Count : 0;
            }
            /* if (this.CartDetails != null && this.CartDetails.Count > 0)
             {
                 foreach (var cartDetail in this.CartDetails)
                 {
                     if (cartDetail.TotalQuantity == 0)
                         cartDetail.TotalQuantity = 1;
                     this.TotalPrice += (cartDetail.ActualPrice * cartDetail.TotalQuantity);
                     this.DiscountPrice += (cartDetail.DiscountPrice * cartDetail.TotalQuantity);
                     this.percent += cartDetail.DiscountPercent;
                 }

                 this.DiscountPercent = this.percent > 0 ? this.percent / this.CartDetails.Count : 0;
             }*/
        }


        public async void FetchCartProducts()
        {
            try
            {
                IsBusy = true;
                //if (App.CurrentUserId > 0)
                {
                    var cartProducts = await cartDataService.GetCartItemAsync();
                    if (cartProducts != null && cartProducts.Count > 0)
                    {
                        IsEmptyViewVisible = false;
                        UserCarts = new ObservableCollection<UserCart>(cartProducts);
                        foreach (var cart in UserCarts)
                        {
                            cart.Product.Quantities = new List<object> { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                        }
                        UpdatePrice();
                    }
                    else
                    {
                        IsEmptyViewVisible = true;
                    }
                    //else
                    //{
                    //    if (Application.Current.MainPage is NavigationPage &&
                    //        (Application.Current.MainPage as NavigationPage).CurrentPage is HomePage)
                    //        IsEmptyViewVisible = true;
                    //    else
                    //        await Application.Current.MainPage.Navigation.PushAsync(new EmptyCartPage(true));
                    //}
                }
                //else
                //{
                //    var result = await Application.Current.MainPage.DisplayAlert("Message",
                //        "Please login to view your cart items", "OK", "CANCEL");
                //    if (result) Application.Current.MainPage = new NavigationPage(new SimpleLoginPage());
                //}
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        /// <summary>
        /// This method is used to reset the price amount.
        /// </summary>
        private void ResetPriceValue()
        {
            this.TotalPrice = 0;
            this.DiscountPercent = 0;
            this.DiscountPrice = 0;
            this.percent = 0;
        }

        #endregion
    }
}
