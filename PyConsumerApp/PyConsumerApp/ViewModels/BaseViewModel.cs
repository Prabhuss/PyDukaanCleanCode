using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels
{
    /// <summary>
    /// This viewmodel extends in another viewmodels.
    /// </summary>
    [Preserve(AllMembers = true)]
    [DataContract]
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Event handler

        /// <summary>
        /// Occurs when the property is changed.
        /// </summary>
        public bool IsNotConnected { get; set; } /*Internet*/

        public event PropertyChangedEventHandler PropertyChanged;

        bool isBusy = false;

        /*Internet*/
        public BaseViewModel()
        {
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;
            IsNotConnected = Connectivity.NetworkAccess != NetworkAccess.Internet;
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { SetProperty(ref isBusy, value); }
        }

        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName]string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        #region INotifyPropertyChanged
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        public static INavigation Navigation
        {
            get; set;
        }
        #endregion

        #region Methods

        /// <summary>
        /// The PropertyChanged event occurs when changing the value of property.
        /// </summary>
        /// <param name="propertyName">The PropertyName</param>
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /*Internet*/
        ~BaseViewModel()
        {
            Connectivity.ConnectivityChanged -= Connectivity_ConnectivityChanged;
        }
        void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            IsNotConnected = e.NetworkAccess != NetworkAccess.Internet;
        }



        #endregion
    }
}
