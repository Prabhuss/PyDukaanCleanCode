using Plugin.Connectivity;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Catalog
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CatalogFilterView : PopupPage
    {
        public CatalogFilterView()
        {
            InitializeComponent();
            listView.ItemsSource = new List<string>
            {
                "Test ListView",
                "Test ListView",
                "Test ListView",
                "Test ListView"
            };
        }
        private async void OnClose(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();
        }
    }
}