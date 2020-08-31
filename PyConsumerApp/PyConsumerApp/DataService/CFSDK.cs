using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;
using Xamarin.Forms;

namespace PyConsumerApp.DataService
{
    public class CFPaymentScreen : ContentPage
    {
        readonly string Stage;
        readonly Dictionary<string, string> InputParams;
        readonly string AppId;

        public CFPaymentScreen(string Stage, string AppId, Dictionary<string, string> InputParams, IPaymentResult result)
        {
            this.Stage = Stage;
            this.InputParams = InputParams;
            this.AppId = AppId;
            var htmlSource = new HtmlWebViewSource
            {
                Html = CreateForm()
            };
            var browser = new WebView()
            {
                Source = htmlSource
            };
            browser.Navigating += (sender, e) => {
                if (e.Url.StartsWith("ios-sdk://", System.StringComparison.CurrentCulture))
                {
                    e.Cancel = true;
                    result.onComplete(WebUtility.UrlDecode(e.Url.Substring(30)));
                    Navigation.PopAsync();
                }
            };
            Content = browser;
        }

        private string CreateForm()
        {
            string SecureURL;
            switch (Stage)
            {
                case "PROD":
                    SecureURL = "https://www.cashfree.com/checkout/post/submit";
                    break;
                default:
                    SecureURL = "https://test.cashfree.com/billpay/checkout/post/submit";
                    break;
            }
            var paymentInputFormHtml =
                "<html>"
                    + "<body onload=\'document.order.submit()\'>"
                        + $"<form name=\'order\' action=\'{SecureURL}\' method=\'post\'>"
                            + $"<input type=\'hidden\' name=\'appId\' value=\'{AppId}\'>";
            foreach (string Key in InputParams.Keys)
            {
                paymentInputFormHtml += CheckAndAdd(inputParams: InputParams, key: Key);
            }
            paymentInputFormHtml += $"<input type=\'hidden\' name=\'source\' value=\'iossdk\'/>" +
                                        //Adding this value will remove the header form the webpage.
                                        "<input type=\'hidden\' name=\'hideHeader\' value=\'1\'/>" +
                                "</form>"
                            + "</body>"
                        + "</html>";
            Debug.WriteLine(paymentInputFormHtml);
            return paymentInputFormHtml;
        }

        private string CheckAndAdd(Dictionary<string, string> inputParams, string key)
        {
            return inputParams[key].Length > 0 ? $"<input type=\'hidden\' name=\'{key}\' value=\'{inputParams[key]}\'/>" : "";
        }
    }
}
public interface IPaymentResult
{
    void onComplete(string result);
}