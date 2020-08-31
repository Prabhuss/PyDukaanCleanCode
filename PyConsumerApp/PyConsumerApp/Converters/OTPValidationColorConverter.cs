using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using PyConsumerApp.Controls;
using PyConsumerApp.ViewModels.Forms;
using System.Diagnostics;

namespace PyConsumerApp.Converters
{
    /// <summary>
    /// This class have methods to convert the Boolean values to color objects. 
    /// This is needed to validate in the Entry controls. If the validation is failed, it will return the color code of error, otherwise it will be transparent.
    /// </summary>
    [Preserve(AllMembers = true)]
    public class OTPValidationColorConverter : IValueConverter
    {
        /// <summary>
        /// Identifies the simple and gradient login pages.
        /// </summary>
        public string PageVariantParameter { get; set; }

        /// <summary>
        /// This method is used to convert the bool to color.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the color.</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // For Gradient login page 
            if (PageVariantParameter == "0")
            {
                var emailEntry = parameter as BorderlessEntry;

                if (!(emailEntry?.BindingContext is OTPViewModel bindingContext))
                {
                    return Color.Transparent;
                }

                var isFocused = (bool)value;
                bindingContext.IsInvalidOtp = !CheckValidOTP(bindingContext.OTP);
                //!isFocused &&

                if (isFocused)
                {
                    return Color.FromRgba(255, 255, 255, 0.6);
                }
                return bindingContext.IsInvalidOtp ? Color.FromHex("#FF4A4A") : Color.Transparent;
            }
            else
            {
                var emailEntry = parameter as BorderlessEntry;

                if (!(emailEntry?.BindingContext is OTPViewModel bindingContext)) return Color.FromHex("#ced2d9");

                var isFocused1 = (bool)value;
                bindingContext.IsInvalidOtp = !isFocused1 && !CheckValidOTP(bindingContext.OTP);

                if (isFocused1)
                {
                    return Color.FromHex("#959eac");
                }
                return bindingContext.IsInvalidOtp ? Color.FromHex("#FF4A4A") : Color.FromHex("#ced2d9");
            }
        }

        /// <summary>
        /// This method is used to convert the color to bool.
        /// </summary>
        /// <param name="value">Gets the value.</param>
        /// <param name="targetType">Gets the target type.</param>
        /// <param name="parameter">Gets the parameter.</param>
        /// <param name="culture">Gets the culture.</param>
        /// <returns>Returns the string.</returns>        
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
        public static bool CheckValidOTP(string otpNumber)
        {
            Debug.WriteLine("OTP Number '" + otpNumber + "'");
            if (string.IsNullOrEmpty(otpNumber))
            {
                return true;
            }

            var regex = new Regex(@"^[0-9]{6}$");
            Debug.WriteLine("OTP Number '" + otpNumber + "', regular expression " + regex.IsMatch(otpNumber));
            return regex.IsMatch(otpNumber) && otpNumber.Length == 6;
        }
    }
}