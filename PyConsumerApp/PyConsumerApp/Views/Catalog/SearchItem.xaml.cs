using Plugin.Connectivity;
using PyConsumerApp.ViewModels.Catalog;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Catalog
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchItem //: ContentPage
    {
        SearchItemViewModel vm;
        public SearchItem()
        {
            InitializeComponent();
            vm = new SearchItemViewModel();
            this.BindingContext = vm;
        }
    }
}