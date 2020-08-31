using Plugin.Connectivity;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Catalog;
using System.Collections.ObjectModel;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Catalog
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SubCategoryPage //: ContentPage
    {
        public SubCategoryPageViewModel vm;
        public SubCategoryPage(ObservableCollection<SubCategory> category)
        {
            InitializeComponent();
            vm = new SubCategoryPageViewModel();
            vm.Categories = category;
            this.BindingContext = vm;
           /* new Task(async () =>
            {
                await getSubCategories(category);
            }).Start();
            */

        }
       /* async private Task getSubCategories(Category category)
        {
            ObservableCollection<SubCategory> subCat = await CategoryDataService.Instance.GetSubCategories(category);
            vm.Categories = subCat;
        }*/
    }
}