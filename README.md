# Braintree - Redirect extensions
[![Build Status](https://dev.azure.com/Dm430/Braintree%20-%20Redirect%20extensions/_apis/build/status/dm430.Braintree-Redirect-extensions?branchName=master)](https://dev.azure.com/Dm430/Braintree%20-%20Redirect%20extensions/_build/latest?definitionId=3&branchName=master) [![Nuget Version](https://img.shields.io/nuget/v/BraintreeRedirectExtensions)](https://www.nuget.org/packages/BraintreeRedirectExtensions/)

Provides extensions for the Braintree gateway to allow transparent redirects for payment methods. 
Note: At the moment this library only supplies an API for creating local payment methods.

# Example usage.

```C#
var braintreeGateway = new BraintreeGateway("sandbox", "MerchatId here", "Public key here", "Private key here");

var fallback = new PaymentFallback ("Some user controlled url here", "Return to checkout");

// optional object
var customer = new PaymentCustomer() 
{
    Email = "joe@getbraintree.com",
    Phone = "5101231234",
    FirstName = "Joe",
    LastName = "Doe",
};

var address = new PaymentAddress("NL")
{
    AddressLine1 = "Oosterdoksstraat 110",
    AddressLine2 = "Apt. B",
    Locality = "DK Amsterdam",
    PostalCode = "1011",
    Region = "NH",
};

var localPayment = new LocalPayment(
    paymentType: "ideal",
    amount: 16.00m,
    currencyCode: "EUR",
    customer: customer, // optional 
    addressEntryRequired: true, // optional 
    address: address,
    fallback: fallback,
    cancelUrl: "Some user controlled url here"
);

var payment = braintreeGateway.ClientToken.CreateLocalPayment("Some account id here", localPayment);
```
