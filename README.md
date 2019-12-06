# Braintree - Transparent redirect extensions
Provides extensions for the Braintree gateway to allow transparent redirects for payment methods. 
Note: At the moment this library only supplies an API for creating local payment methods.

# Example usage.

```C#
var braintreeGateway = new BraintreeGateway("sandbox", "MerchatId here", "Public key here", "Private key here");

var fallback = new PaymentFallback ("Some user controlled url here", "Return to checkout")

var localPayment = new LocalPayment(
    PaymentType = "ideal",
    Amount = 16.00m,
    "EUR",
    "NL",
    fallback,
    "Some user controlled url here"
);

var payment = braintreeGateway.ClientToken.CreateLocalPayment("Some account id here", localPayment);
```
