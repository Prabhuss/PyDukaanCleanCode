using Plugin.Connectivity;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Catalog;
using Syncfusion.GridCommon.ScrollAxis;
using Syncfusion.ListView.XForms;
using Syncfusion.ListView.XForms.Control.Helpers;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Catalog
{

    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogListPage
    {
        private CatalogPageViewModel vm;
        //pagination
        ScrollAxisBase scrollRows;
        public bool isFooterLoaded;
        VisualContainer visualContainer;
        //
        public CatalogListPage(SubCategory category)
        {
            InitializeComponent();
            vm = new CatalogPageViewModel(category);
            BindingContext = vm;

            /* ListViewList.FooterSize = 40;
             visualContainer = ListViewList.GetType().GetRuntimeProperties().First(p => p.Name == "VisualContainer").GetValue(ListViewList) as VisualContainer;
             scrollRows = visualContainer.GetType().GetRuntimeProperties().First(p => p.Name == "ScrollRows").GetValue(visualContainer) as ScrollAxisBase;
             scrollRows.Changed += ScrollRows_Changed;
             */

            visualContainer = ListViewList.GetVisualContainer();
            visualContainer.ScrollRows.Changed += ScrollRows_Changed;

            /*  new Task(async () =>
              {
                  await getProducts(category);
              }).Start();
              */
        }
        public CatalogListPage(string OfferCode)
        {
            InitializeComponent();
            vm = new CatalogPageViewModel(OfferCode);
            BindingContext = vm;
            visualContainer = ListViewList.GetVisualContainer();
            visualContainer.ScrollRows.Changed += ScrollRows_Changed;
        }
        private void ScrollRows_Changed(object sender, ScrollChangedEventArgs e)
        {
            var lastIndex = visualContainer.ScrollRows.LastBodyVisibleLineIndex;

            //To include header if used
            var header = (ListViewList.HeaderTemplate != null && !ListViewList.IsStickyHeader) ? 1 : 0;

            //To include footer if used
            var footer = (ListViewList.FooterTemplate != null && !ListViewList.IsStickyFooter) ? 1 : 0;
            var totalItems = ListViewList.DataSource.DisplayItems.Count + header + footer;
            /* var lastIndex = scrollRows.LastBodyVisibleLineIndex;
             var header = (ListViewList.HeaderTemplate != null && !ListViewList.IsStickyHeader) ? 1 : 0;
             var footer = (ListViewList.FooterTemplate != null && !ListViewList.IsStickyFooter) ? 1 : 0;
             var displayItemsCount = ListViewList.DataSource.DisplayItems.Count;
             var totalItems = displayItemsCount + header + footer;
             */

            //To stop loading when 60 items added to display items.
            /* if (displayItemsCount >= 60)
             {
                 ListViewList.FooterSize = 0;
                 return;
             }

             if (totalItems > 0 && lastIndex == (totalItems - 1))*/
            if (lastIndex == (totalItems - 1))
            {
                if (!isFooterLoaded)
                {
                    if(vm.offerCode != null)
                        vm.LoadMoreData("offerpage");
                    else
                        vm.LoadMoreData("categorypage");
                    isFooterLoaded = true;
                }
            }
            else
            {
                isFooterLoaded = false;
            }
        }
        async private Task getProducts(SubCategory category)
        {
           /* ObservableCollection<Product> products = await CategoryDataService.Instance.GetItems(category);
            vm.Products = products;
            */
        }

    }
}