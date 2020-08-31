using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.Views.Bookmarks;
using PyConsumerApp.Views.Catalog;
using PyConsumerApp.Views.Detail;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Catalog
{
    /// <summary>
    /// ViewModel for catalog page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class CatalogPageViewModel : BaseViewModel
    {
        #region Fields
        bool isBusy;// = false;
        private int Id = 1;



        private ObservableCollection<Product> products;

        private ObservableCollection<Category> filterOptions;

        private ObservableCollection<string> sortOptions;

        private Command addFavouriteCommand;

        private Command searchButtonCommand;

        private Command itemSelectedCommand;

        private Command sortCommand;

        private Command filterCommand;

        private Command addToCartCommand;

        private Command cardItemCommand;

        private int? cartItemCount;

        private Command backButtonCommand;

        //private Category category;
        private SubCategory category;
        private string categoryName;
        public string offerCode;
        public string CategoryName
        {
            get
            {
                return this.categoryName;
            }

            set
            {
                if (this.categoryName == value)
                {
                    return;
                }

                this.categoryName = value;
                this.NotifyPropertyChanged();
            }
        }
        public bool IsLoading
        {
            get { return isBusy; }
            set
            {
                isBusy = value;
                OnPropertyChanged("IsLoading");
                //this.NotifyPropertyChanged();
            }
        }

        #endregion


        #region Commands
        /// <summary>
        /// Gets or sets the command is executed when the back button is clicked.
        /// </summary>
        /// 
        public Command SearchButtonCommand
        {
            get { return searchButtonCommand ?? (this.searchButtonCommand = new Command(this.SearchButtonClicked)); }
        }

        public Command BackButtonCommand 
        {
            get { return backButtonCommand ?? (this.backButtonCommand = new Command(this.BackButtonClicked)); }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance for the <see cref="CatalogPageViewModel" /> class.
        /// </summary>
       // public CatalogPageViewModel(Category category)
        public CatalogPageViewModel(SubCategory category)
        {
            //BackButtonCommand = new Command(BackButtonClicked);
            CategoryName = category.Name;
            this.category = category;
            products = new ObservableCollection<Product>();
            LoadMoreData("categorypage");


            this.FilterOptions = new ObservableCollection<Category>
            {
                new Category
                {
                    Name = "Gender",
                    SubCategories = new List<string>
                    {
                        "Men",
                        "Women"
                    }
                },
                new Category
                {
                    Name = "Brand",
                    SubCategories = new List<string>
                    {
                        "Brand A",
                        "Brand B"
                    }
                },
                new Category
                {
                    Name = "Categories",
                    SubCategories = new List<string>
                    {
                        "Category A",
                        "Category B"
                    }
                },
                new Category
                {
                    Name = "Color",
                    SubCategories = new List<string>
                    {
                        "Maroon",
                        "Pink"
                    }
                },
                new Category
                {
                    Name = "Price",
                    SubCategories = new List<string>
                    {
                        "Above 3000",
                        "1000 to 3000",
                        "Below 1000"
                    }
                },
                new Category
                {
                    Name = "Size",
                    SubCategories = new List<string>
                    {
                        "S", "M", "L", "XL", "XXL"
                    }
                },
                new Category
                {
                    Name = "Patterns",
                    SubCategories = new List<string>
                    {
                        "Pattern 1", "Pattern 2"
                    }
                },
                new Category
                {
                    Name = "Offers",
                    SubCategories = new List<string>
                    {
                        "Buy 1 Get 1", "Buy 1 Get 2"
                    }
                },
                new Category
                {
                    Name = "Coupons",
                    SubCategories = new List<string>
                    {
                        "Coupon 1", "Coupon 2"
                    }
                },
            };

            this.SortOptions = new ObservableCollection<string>
            {
                "New Arrivals",
                "Price - high to low",
                "Price - Low to High",
                "Popularity",
                "Discount"
            };
        }
        public CatalogPageViewModel(string OfferCode)
        {
            //BackButtonCommand = new Command(BackButtonClicked);
            //CategoryName = category.Name;
            //this.category = category;
            this.offerCode = OfferCode;
            products = new ObservableCollection<Product>();
            LoadMoreData("offerpage");
        }
        #endregion

        #region Public properties

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the item details in tile.
        /// </summary>
        [DataMember(Name = "products")]
        public ObservableCollection<Product> Products
        {
            get
            {
                return this.products;
            }

            set
            {
                if (this.products == value)
                {
                    return;
                }

                this.products = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with a list view, which displays the filter options.
        /// </summary>
        public ObservableCollection<Category> FilterOptions
        {
            get
            {
                return this.filterOptions;
            }

            set
            {
                if (this.filterOptions == value)
                {
                    return;
                }

                this.filterOptions = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property has been bound with a list view, which displays the sort details.
        /// </summary>
        public ObservableCollection<string> SortOptions
        {
            get
            {
                return this.sortOptions;
            }

            set
            {
                if (this.sortOptions == value)
                {
                    return;
                }

                this.sortOptions = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the property that has been bound with view, which displays the cart items count.
        /// </summary>
        public int? CartItemCount
        {
            get
            {
                return this.cartItemCount;
            }
            set
            {
                this.cartItemCount = value;
                this.NotifyPropertyChanged();
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

        #endregion

        #region Command

        /// <summary>
        /// Gets or sets the command that will be executed when an item is selected.
        /// </summary>
        public Command ItemSelectedCommand
        {
            get { return this.itemSelectedCommand ?? (this.itemSelectedCommand = new Command(this.ItemSelected)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the sort button is clicked.
        /// </summary>
        public Command SortCommand
        {
            get { return this.sortCommand ?? (this.sortCommand = new Command(this.SortClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the filter button is clicked.
        /// </summary>
        public Command FilterCommand
        {
            get { return this.filterCommand ?? (this.filterCommand = new Command(this.FilterClicked)); }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the Favourite button is clicked.
        /// </summary>
        public Command AddFavouriteCommand
        {
            get
            {
                return this.addFavouriteCommand ?? (this.addFavouriteCommand = new Command(this.AddFavouriteClicked));
            }
        }

        /// <summary>
        /// Gets or sets the command that will be executed when the AddToCart button is clicked.
        /// </summary>
        public Command AddToCartCommand
        {
            get { return this.addToCartCommand ?? (this.addToCartCommand = new Command(this.AddToCartClicked)); }
        }

        /// <summary>
        /// Gets or sets the command will be executed when the cart icon button has been clicked.
        /// </summary>
        public Command CardItemCommand
        {
            get { return this.cardItemCommand ?? (this.cardItemCommand = new Command(this.CartClicked)); }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invoked when an item is selected.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private async void ItemSelected(object attachedObject)
        {

            IsBusy = true;
            // Do something
            //await Navigation.PushAsync(new DetailPage((Product)attachedObject));
            Log.Debug("[ItemSelected]", "Selected Item" + attachedObject);
            await Navigation.PushAsync(new DetailPage((Product)attachedObject));
            await Task.Delay(100);
            IsBusy = false;

        }

        /// <summary>
        /// Invoked when the items are sorted.
        /// </summary>
        /// <param name="attachedObject">The Object</param>
        private void SortClicked(object attachedObject)
        {
            // Do something
        }

        /// <summary>
        /// Invoked when the filter button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void FilterClicked(object obj)
        {
            // Do something
            var page = new CatalogFilterView();
            await PopupNavigation.Instance.PushAsync(page);
        }

        /// <summary>
        /// Invoked when the favourite button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private void AddFavouriteClicked(object obj)
        {
            if (obj is Product product)
                product.IsFavourite = !product.IsFavourite;
        }

        /// <summary>
        /// Invoked when the cart button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void AddToCartClicked(object obj)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    if (obj != null && obj is Product product && product != null)
                    {
                        var status = await CartDataService.Instance.AddCartItemAsync(product);
                        if (status != null && status.IsSuccess)
                        {
                            CartItemCount++;
                        }
                        else if (status != null && !status.IsSuccess)
                        {
                            var response = await CartDataService.Instance.RemoveCartItemsAsync(product.CitrineProdId);
                            if (response != null && response.IsSuccess)
                            {
                                var response2 = await CartDataService.Instance.AddCartItemAsync(product);
                                if (response2 != null && response.IsSuccess)
                                {

                                    /*var result = await Application.Current.MainPage.DisplayAlert("Alert",
                                            "Quantity has been updated", "Go to Cart", " ");
                                     if (result) await Application.Current.MainPage.Navigation.PushAsync(new CartPage());
                                     */
                                }
                            }
                            //UpdatePrice();

                            /* var result = await Application.Current.MainPage.DisplayAlert("Alert",
                                     "This item has been already added in cart", "Go to Cart", " ");*/

                        }
                    }
                }
                catch (Exception ex)
                {
                    try
                    {
                        DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                    }
                    catch { }
                }
            }
        }

        /// <summary>
        /// Invoked when cart icon button is clicked.
        /// </summary>
        /// <param name="obj"></param>
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
                Console.WriteLine(e.Message);
            }
            finally
            {
                IsBusy = false;
            }

           
        }

        /// <summary>
        /// Invoked when an back button is clicked.
        /// </summary>
        /// <param name="obj">The Object</param>
        private async void BackButtonClicked(object obj)
        {
            // Do something
            //await Navigation.PopAsync();
            await Application.Current.MainPage.Navigation.PopAsync();
        }


        public async void LoadMoreData(string DisplayPageType)
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                try
                {
                    //isBusy = false;
                    IsLoading = true;
                    int pageno = 0;
                    //To show ActivityIndicator if the items are loaded in the view. 
                    if (products.Count > 0)
                    {
                        pageno = (products.Count / 15) + 1;
                        //await Task.Delay(3000);
                    }
                    else
                    {
                        pageno = 1;
                    }
                    //To ignore if items are being added till delayed time.
                    //if (isBusy)
                    /* if (!isBusy)
                         return;
                     */
                    if(DisplayPageType == "categorypage")
                    {
                        try
                        {
                            ObservableCollection<Product> productlist = await CategoryDataService.Instance.GetItems(category, pageno);
                            if (productlist.Count != 0)
                            {
                                foreach (var item in productlist)
                                {
                                    try
                                    {
                                        /*
                                        if (string.IsNullOrEmpty(item.productDesc))
                                        {
                                            item.productDesc = " ";
                                        }*/
                                        try
                                        {
                                            if (item.productDesc.ToLower() == "null")
                                            {
                                                item.productDesc = " ";
                                            }
                                        }
                                        catch { }
                                        var isProductAlreadyAdded = products.Any(s => s.CitrineProdId == item.CitrineProdId);
                                        if (!isProductAlreadyAdded)
                                        {
                                            if (item.Availability_Status.ToString().ToLower() == "no")
                                                item.AvailabilityStatusBool = false;
                                            else
                                                item.AvailabilityStatusBool = true;
                                            Products.Add(item);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        var temp = e.Message;
                                    }
                                }
                                await Task.Delay(2000);
                            }
                        }
                        catch
                        {

                        }

                    }
                    else if (DisplayPageType == "offerpage")
                    {
                        try
                        {
                            ObservableCollection<Product> productlist = await OfferDataService.Instance.GetOfferProducts(offerCode, pageno);
                            if (productlist.Count != 0)
                            {
                                foreach (var item in productlist)
                                {
                                    try
                                    {
                                        if (string.IsNullOrEmpty(item.productDesc))
                                        {
                                            item.productDesc = " ";
                                        }
                                        var isProductAlreadyAdded = products.Any(s => s.CitrineProdId == item.CitrineProdId);
                                        if (!isProductAlreadyAdded)
                                        {
                                            if (item.Availability_Status.ToString().ToLower() == "no")
                                                item.AvailabilityStatusBool = false;
                                            else
                                                item.AvailabilityStatusBool = true;
                                            Products.Add(item);
                                        }
                                    }
                                    catch (Exception e)
                                    {
                                        var temp = e.Message;
                                    }
                                }
                                await Task.Delay(2000);
                            }
                        }
                        catch { }
                    }
                    //isBusy = true;
                    //isBusy = false;
                }
                catch (Exception e)
                {

                }
                finally
                {
                    IsLoading = false;
                }
            }
            else
            {
                DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                IsLoading = false;
            }
        }


        private async void SearchButtonClicked(object obj)
        {
            await Navigation.PushAsync(new SearchItem());
        }

        #endregion
    }
}