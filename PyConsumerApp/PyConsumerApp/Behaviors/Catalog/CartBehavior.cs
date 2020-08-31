using PyConsumerApp.ViewModels.Bookmarks;
using PyConsumerApp.ViewModels.Catalog;
using PyConsumerApp.ViewModels.Detail;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace PyConsumerApp.Behaviors.Catalog
{
    /// <summary>
    /// This class extends the behavior of the catalog page and detail page
    /// </summary>
    [Preserve(AllMembers = true)]
    public class CartBehavior : Behavior<ContentPage>
    {
        #region Fields

        private ContentPage bindablePage;

        #endregion

        #region Method

        /// <summary>
        /// Invoked when adding catalog page and detail page.
        /// </summary>
        /// <param name="bindableContentPage">Bindable ContentPage</param>
        protected override void OnAttachedTo(ContentPage bindableContentPage)
        {
            if (bindableContentPage != null)
            {
                base.OnAttachedTo(bindableContentPage);
                this.bindablePage = bindableContentPage;
                bindableContentPage.Appearing += this.Bindable_Appearing;
            }
        }
        /// <summary>
        /// Invoked when exit from the page.
        /// </summary>
        /// <param name="bindableContentPage">Content Page</param>
        protected override void OnDetachingFrom(ContentPage bindableContentPage)
        {
            if (bindableContentPage != null)
            {
                base.OnDetachingFrom(bindableContentPage);
                bindableContentPage.Appearing -= this.Bindable_Appearing;
            }
        }

        /// <summary>
        /// Invoked when appearing the page.
        /// </summary>
        /// <param name="sender">Content Page</param>
        /// <param name="e">Event Args</param>
        private void Bindable_Appearing(object sender, EventArgs e)
        {
            // Do something
            if (bindablePage != null)
            {
                if (bindablePage.BindingContext is DetailPageViewModel detailPageViewModel &&
                    detailPageViewModel != null)
                    detailPageViewModel.UpdateCartItemCount();
                else if (bindablePage.BindingContext is CatalogPageViewModel catalogPageViewModel &&
                    catalogPageViewModel != null)
                    catalogPageViewModel.UpdateCartItemCount();
                else if(bindablePage.BindingContext is SearchItemViewModel searchItemViewModel &&
                    searchItemViewModel != null)
                    searchItemViewModel.UpdateCartItemCount();
                else if (bindablePage.BindingContext is SubCategoryPageViewModel subCategoryPageViewModel &&
                    subCategoryPageViewModel != null)
                    subCategoryPageViewModel.UpdateCartItemCount();
                /* else if (bindablePage.BindingContext is CatalogPageViewModel catalogPageViewModel &&
                            catalogPageViewModel != null)
                       catalogPageViewModel.UpdateCartItemCount();
                   else if (bindablePage.BindingContext is WishlistViewModel wishlistViewModel && wishlistViewModel != null)
                       wishlistViewModel.UpdateCartItemCount();*/
                else if (bindablePage.BindingContext is CartPageViewModel cartPageViewModel && cartPageViewModel != null)
                    cartPageViewModel.FetchCartProducts();
                

            }
        }

        #endregion
    }
}
