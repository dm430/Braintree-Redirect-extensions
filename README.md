# Braintree - Transparent redirect extensions
Provides extensions for the Braintree gateway to allow transparent redirects for payment methods. 
Note: At the moment this library only supplies an API for creating local payment methods.

# Example usage.

```C#
var braintreeGateway = new BraintreeGateway("sandbox", "MerchatId here", "Public key here", "Private key here");

var localPayment = new LocalPayment
{
    PaymentType = "ideal",
    Amount = 16.00m,
    Fallback = new PaymentFallback
    {
        Url = "Some user controlled url here",
        ButtonText = "Return to checkout"
    },
    CancelUrl = "Some user controlled url here",
    CurrencyCode = "EUR",
    CountryCode = "NL"
};

var payment = braintreeGateway.ClientToken.CreateLocalPayment("Some account id here", localPayment);
```
