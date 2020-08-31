using Xamarin.Forms.Internals;

namespace PyConsumerApp.ViewModels.Forms
{
    /// <summary>
    /// ViewModel for login page.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class LoginViewModel : BaseViewModel
    {
        #region Fields

        private string phoneNumber;

        private bool isInvalidPhoneNumber;

        #endregion

        #region Property

        /// <summary>
        /// Gets or sets the property that bounds with an entry that gets the email ID from user in the login page.
        /// </summary>
        public string PhoneNumber
        {
            get
            {
                return this.phoneNumber;
            }

            set
            {
                if (this.phoneNumber == value)
                {
                    return;
                }

                this.phoneNumber = value;
                this.NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the entered email is valid or invalid.
        /// </summary>
        public bool IsInvalidPhoneNumber
        {
            get
            {
                return this.isInvalidPhoneNumber;
            }

            set
            {
                if (this.isInvalidPhoneNumber == value)
                {
                    return;
                }

                this.isInvalidPhoneNumber = value;
                this.NotifyPropertyChanged();
            }
        }

        #endregion
    }
}
