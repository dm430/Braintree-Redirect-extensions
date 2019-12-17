using System;
using System.Web;
using BraintreeRedirectExtensions.Models;
using BraintreeRedirectExtensions.Models.Configuration;
using BraintreeRedirectExtensions.Requests;

namespace BraintreeRedirectExtensions.Utilities
{
    internal class RequestFactory
    {
        public static LocalPaymentRequest CreateLocalPaymentRequest(LocalPayment localPayment, BraintreeClientConfiguration clientConfiguration)
        {
            var returnUrl = GenerateReturnUrl(localPayment.Fallback, clientConfiguration);
            var requestObject = new LocalPaymentRequest
            {
                FundingSource = localPayment.PaymentType,
                Intent = GatewayConstants.Intent,
                Amount = localPayment.Amount,
                ReturnUrl = returnUrl,
                CancelUrl = localPayment.Fallback.Url.ToString(),
                CurrencyCode = localPayment.CurrencyCode,
                CountryCode = localPayment.CountryCode,
                BraintreeLibraryVersion = $"braintree/web/{GatewayConstants.ApiVersion}", // Are custom strings ok here?
                MetaData = new MetaData()
                {
                    MerchantAppId = "Test", // TODO: Make configurable.
                    Platform = "web", // Should this be something else?S
                    SdkVersion = GatewayConstants.ApiVersion,
                    Source = "client",
                    Integration = "custom",
                    IntegrationType = "custom",
                    SessionId = Guid.NewGuid()
                },
                AuthorizationFingerprint = clientConfiguration.AuthorizationFingerprint
            };

            return requestObject;
        }

        private static string GenerateReturnUrl(PaymentFallback fallback, BraintreeClientConfiguration clientConfiguration)
        {
            var returnUrl = fallback.Url.ToString();

            if (fallback.HasRedirectButton)
            {
                var encodedReturnUrl = HttpUtility.UrlEncode(returnUrl);
                var encodedButtonText = Uri.EscapeDataString(fallback.ButtonText);

                returnUrl = $"{clientConfiguration.AssetsUrl}/web/{GatewayConstants.ApiVersion}/html/local-payment-redirect-frame.min.html?r={encodedReturnUrl}&t={encodedButtonText}";
            }

            return returnUrl;
        }
    }
}