using Plugin.Connectivity;
using PyConsumerApp.DataService;
using PyConsumerApp.ViewModels.Bookmarks;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Bookmarks
{
    /// <summary>
    /// Page to show the cart list. 
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage
    {
        CartPageViewModel vm;
        /// <summary>
        /// Initializes a new instance of the <see cref="CartPage" /> class.
        /// </summary>
        public CartPage()
        {
            InitializeComponent();
            var cartSercice = CartDataService.Instance;
            BindingContext = new CartPageViewModel(cartSercice);
        }
        
    }
}