using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Offers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Offers
{
    /// <summary>
    /// The Category Tile page.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OffersTilePage : ContentPage
    {
        OffersTileViewModel vm;
        public OffersTilePage()
        {
            InitializeComponent();
            vm = new OffersTileViewModel();
            this.BindingContext = vm;
            new Task(async () => {
                await GetOfferList();
            }).Start();
        }


        async private Task GetOfferList()
        {
            if (CrossConnectivity.Current.IsConnected)
            {
                ObservableCollection<OfferData> OfferCategories = await OfferDataService.Instance.PopulateOfferData();
                if (OfferCategories != null)
                {
                    vm.OfferList = OfferCategories;
                }
            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                }
                catch { }
            }
        }
    }
}