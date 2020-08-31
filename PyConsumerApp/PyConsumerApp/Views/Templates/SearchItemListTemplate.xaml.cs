using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace PyConsumerApp.Views.Templates
{
    [Preserve(AllMembers = true)]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SearchItemListTemplate : Grid
    {
        public static BindableProperty ParentBindingContextProperty =
         BindableProperty.Create(nameof(ParentBindingContext), typeof(object),
         typeof(SearchItemListTemplate), null);
        public object ParentBindingContext
        {
            get { return GetValue(ParentBindingContextProperty); }
            set { SetValue(ParentBindingContextProperty, value); }
        }

        public SearchItemListTemplate()
        {
            InitializeComponent();
        }

        private void numericUpDown_ValueChanged(object sender, Syncfusion.SfNumericUpDown.XForms.ValueEventArgs e)
        {

        }
        /*void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
{
double value = e.NewValue;
_rotatingLabel.Rotation = value;
_displayLabel.Text = string.Format("The Stepper value is {0}", value);
}*/
    }
}