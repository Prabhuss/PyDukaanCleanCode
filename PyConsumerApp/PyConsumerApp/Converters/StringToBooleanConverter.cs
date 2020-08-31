using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using PyConsumerApp.Controls;
using System.Diagnostics;

namespace PyConsumerApp.Converters
{
    /// <summary>
    /// This class have methods to convert the string values to boolean.     
    /// </summary>
    [Preserve(AllMembers = true)]
    public class StringToBooleanConverter : IValueConverter
    {
        /// <summary>
        /// This method is used to convert the string to boolean.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="targetType">The target</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="culture">The culture</param>
        /// <returns>The result</returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || !(parameter is BorderlessEntry control))
            {
                return false;
            }

            var isFocused = (bool)value;
            bool isValid = false;
            Debug.WriteLine("Element place holder is " + control.Placeholder);
            if(control.Placeholder.Contains("10 digit"))
            {
                isValid = ErrorValidationColorConverter.CheckValidNumber(control.Text);
            } else if(control.Placeholder.Contains("6 digit"))
            {
                isValid = OTPValidationColorConverter.CheckValidOTP(control.Text);
            }
            Debug.WriteLine("Element place holder is " + isValid + "----" + isFocused);
            var isInvalidEmail = !isFocused && !isValid;
            return !isValid;
            //return !isFocused && isInvalidEmail;
        }

        /// <summary>
        /// This method is used to convert the boolean to string.
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="targetType">The target</param>
        /// <param name="parameter">The parameter</param>
        /// <param name="culture">The culture</param>
        /// <returns>The result</returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return true;
        }

        /// <summary>
        /// Validates the email.
        /// </summary>
        /// <param name="email">Gets the email</param>
        /// <returns>Returns the boolean value.</returns>
        private static bool CheckValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return true;
            }

            var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return regex.IsMatch(email) && !email.EndsWith(".");
        }
    }
}