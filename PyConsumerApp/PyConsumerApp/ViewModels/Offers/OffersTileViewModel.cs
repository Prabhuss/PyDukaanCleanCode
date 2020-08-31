using Plugin.Connectivity;
using PyConsumerApp.Controls;
using PyConsumerApp.DataService;
using PyConsumerApp.Models;
using PyConsumerApp.Views.Catalog;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Offers
{
    [Preserve(AllMembers = true)]
    [DataContract]
    class OffersTileViewModel :BaseViewModel
    {

        public ObservableCollection<OfferData> offerList;

        [DataMember(Name = "categories")]
        public ObservableCollection<OfferData> OfferList
        {
            get { return this.offerList; }
            set
            {
                if (this.offerList == value)
                {
                    return;
                }

                this.offerList = value;
                this.NotifyPropertyChanged();
            }
        }
        private Command searchButtonCommand;

        private Command offerSelectedCommand;
        public Command OfferSelectedCommand
        {
            get { return offerSelectedCommand ?? (offerSelectedCommand = new Command(OfferSelectedClicked)); }
        }

        public Command SearchButtonCommand
        {
            get { return searchButtonCommand ?? (this.searchButtonCommand = new Command(this.SearchButtonClicked)); }
        }
        private async void OfferSelectedClicked(object obj)//map this function to the listvied itemSelected command
        {
            var offerSelected = obj as OfferData;
            IsBusy = true;
            //await Navigation.PushAsync(new CatalogListPage((Category)obj));
            if (CrossConnectivity.Current.IsConnected)
            {
                    await Navigation.PushAsync(new CatalogListPage(offerSelected.OfferCode));
                    await Task.Delay(100);
                IsBusy = false;
            }
            else
            {
                try
                {
                    DependencyService.Get<IToastMessage>().LongTime("No Internet Connection");
                }
                catch { }
                IsBusy = false;
            }
        }

        private async void SearchButtonClicked(object obj)
        {
            await Navigation.PushAsync(new SearchItem());
        }
    }
}
