using Plugin.Connectivity;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Forms
{
    /// <summary>
    /// View used to show the email entry with validation status.
    /// </summary>
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PhoneNumberEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailEntry" /> class.
        /// </summary>
        public PhoneNumberEntry()
        {
            InitializeComponent();
        }
    }
}