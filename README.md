# Shift4 .NET Library

[![Build](https://github.com/shift4developer/shift4-net/actions/workflows/build.yml/badge.svg)](https://github.com/shift4developer/shift4-net/actions/workflows/build.yml)

If you don't already have Shift4 account you can create it [here](https://dev.shift4.com/signup). 

## Installation 

### NuGet

To install Shift4, run the following command in the [Package Manager Console](https://docs.nuget.org/consume/package-manager-console)

```
PM> Install-Package Shift4 
```
More info [here](https://www.nuget.org/packages/Shift4/)

### Manual

You can download the latest release from [here](https://github.com/shift4developer/shift4-net/releases).

## Quick start example

```cs
Shift4Gateway gateway = new Shift4Gateway("sk_test_[YOUR_SECRET_KEY]");

ChargeRequest request = new ChargeRequest()
{
    Amount = 499,
    Currency = "EUR",
    Card = new CardRequest()
    {
        Number = "4242424242424242",
        ExpMonth = "11",
        ExpYear = "2022"
    }
};

try
{
    Charge charge = await gateway.CreateCharge(request);

    // do something with charge object - see https://dev.shift4.com/docs/api#charge-object
    string chargeId = charge.Id;

}
catch (Shift4Exception e)
{
    // handle error response - see https://dev.shift4.com/docs/api#error-object
    ErrorType errorType = e.Error.Type;
    ErrorCode? errorCode = e.Error.Code;
    string errorMessage = e.Error.Message;
}
```

## Documentation

For further information, please refer to our official documentation at https://dev.shift4.com/docs.
