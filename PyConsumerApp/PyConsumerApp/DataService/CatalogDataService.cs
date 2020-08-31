using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using PyConsumerApp.Models;
using PyConsumerApp.ViewModels.Catalog;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.DataService
{
    /// <summary>
    /// Data service to load the data from json file.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CatalogDataService
    {
        #region fields

        private static CatalogDataService instance;

        private CatalogPageViewModel catalogPageViewModel;

        #endregion

        #region Constructor

        /// <summary>
        /// Creates an instance for the <see cref="CatalogDataService"/> class.
        /// </summary>
        private CatalogDataService()
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets an instance of the <see cref="CatalogDataService"/>.
        /// </summary>
        public static CatalogDataService Instance => instance ?? (instance = new CatalogDataService());

        /// <summary>
        /// Gets or sets the value of catalog page view model.
        /// </summary>
        public CatalogPageViewModel CatalogPageViewModel =>
            this.catalogPageViewModel ??
            (this.catalogPageViewModel = PopulateData<CatalogPageViewModel>("ecommerce.json"));

        #endregion

        #region Methods

        /// <summary>
        /// Populates the data for view model from json file.
        /// </summary>
        /// <typeparam name="T">Type of view model.</typeparam>
        /// <param name="fileName">Json file to fetch data.</param>
        /// <returns>Returns the view model object.</returns>
        private static T PopulateData<T>(string fileName)
        {
            var file = "PyConsumerApp.Data." + fileName;

            var assembly = typeof(App).GetTypeInfo().Assembly;

            T obj;

            using (var stream = assembly.GetManifestResourceStream(file))
            {
                var serializer = new DataContractJsonSerializer(typeof(T));
                obj = (T)serializer.ReadObject(stream);
            }

            return obj;
        }
        public async Task<List<Payment>> GetPaymentOptionsAsync()
        {
            var Payments = new List<Payment>();
            try
            {
                Payments = new List<Payment>
                {
                    //new Payment {PaymentMode = "Wells Fargo Bank Credit Card"},
                    //new Payment {PaymentMode = "Debit / Credit Card"},
                    //new Payment {PaymentMode = "NetBanking"},
                    new Payment {PaymentMode = "Online Payment"},
                    new Payment {PaymentMode = "Pay on Delivery"}
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Task.FromResult(Payments);
        }

        #endregion
    }
}