# AStar.Api.SendApi

All URIs are relative to *http://dev.astar.tech:8085/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SendFile**](SendApi.md#sendfile) | **POST** /send/opreturn/base64 | Send file hash to bitcoin blockchain
[**SendHash**](SendApi.md#sendhash) | **POST** /send/opreturn/hash | Send hash to bitcoin blockchain
[**SendPayAddress**](SendApi.md#sendpayaddress) | **POST** /send/payaddress | Send a value for address
[**SendString**](SendApi.md#sendstring) | **POST** /send/opreturn/string | Send string to bitcoin blockchain


<a name="sendfile"></a>
# **SendFile**
> SingleResult SendFile (string token, int? account, string user, string pass, string base64, string coin, int? test)

Send file hash to bitcoin blockchain

Send an OP_RETURN transaction with a base64 encoded file and return the API id for the blockchain transaction. 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SendFileExample
    {
        public void main()
        {
            
            var apiInstance = new SendApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var base64 = base64_example;  // string | base64 encoded file.
            var coin = coin_example;  // string | the coin name - bitcoin/litecoin.
            var test = 56;  // int? | if test = 1 so use testnet else test = 0 for mainnet.

            try
            {
                // Send file hash to bitcoin blockchain
                SingleResult result = apiInstance.SendFile(token, account, user, pass, base64, coin, test);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SendApi.SendFile: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| a signed JWT token with the company privatekey. | 
 **account** | **int?**| API ID for Account where the coins must be spend. | 
 **user** | **string**| API user name. | 
 **pass** | **string**| API user password. | 
 **base64** | **string**| base64 encoded file. | 
 **coin** | **string**| the coin name - bitcoin/litecoin. | 
 **test** | **int?**| if test &#x3D; 1 so use testnet else test &#x3D; 0 for mainnet. | 

### Return type

[**SingleResult**](SingleResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendhash"></a>
# **SendHash**
> SingleResult SendHash (string token, int? account, string user, string pass, string hash, string coin, int? test)

Send hash to bitcoin blockchain

Send an OP_RETURN transaction with a hash and return the API id for the blockchain transaction. 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SendHashExample
    {
        public void main()
        {
            
            var apiInstance = new SendApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var hash = hash_example;  // string | hash to send.
            var coin = coin_example;  // string | the coin name - bitcoin/litecoin.
            var test = 56;  // int? | if test = 1 so use testnet else test = 0 for mainnet.

            try
            {
                // Send hash to bitcoin blockchain
                SingleResult result = apiInstance.SendHash(token, account, user, pass, hash, coin, test);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SendApi.SendHash: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| a signed JWT token with the company privatekey. | 
 **account** | **int?**| API ID for Account where the coins must be spend. | 
 **user** | **string**| API user name. | 
 **pass** | **string**| API user password. | 
 **hash** | **string**| hash to send. | 
 **coin** | **string**| the coin name - bitcoin/litecoin. | 
 **test** | **int?**| if test &#x3D; 1 so use testnet else test &#x3D; 0 for mainnet. | 

### Return type

[**SingleResult**](SingleResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendpayaddress"></a>
# **SendPayAddress**
> SingleResult SendPayAddress (string token, int? account, string user, string pass, string address, float? amount, string coin, int? test)

Send a value for address

Send a value for address by an blockchain transaction. 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SendPayAddressExample
    {
        public void main()
        {
            
            var apiInstance = new SendApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var address = address_example;  // string | Address to send the amount.
            var amount = 3.4;  // float? | Amount to send
            var coin = coin_example;  // string | the coin name - bitcoin/litecoin.
            var test = 56;  // int? | if test = 1 so use testnet else test = 0 for mainnet.

            try
            {
                // Send a value for address
                SingleResult result = apiInstance.SendPayAddress(token, account, user, pass, address, amount, coin, test);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SendApi.SendPayAddress: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| a signed JWT token with the company privatekey. | 
 **account** | **int?**| API ID for Account where the coins must be spend. | 
 **user** | **string**| API user name. | 
 **pass** | **string**| API user password. | 
 **address** | **string**| Address to send the amount. | 
 **amount** | **float?**| Amount to send | 
 **coin** | **string**| the coin name - bitcoin/litecoin. | 
 **test** | **int?**| if test &#x3D; 1 so use testnet else test &#x3D; 0 for mainnet. | 

### Return type

[**SingleResult**](SingleResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="sendstring"></a>
# **SendString**
> SingleResult SendString (string token, int? account, string user, string pass, string _string, string coin, int? test)

Send string to bitcoin blockchain

Send an OP_RETURN transaction with a string and return the API id for the blockchain transaction. 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SendStringExample
    {
        public void main()
        {
            
            var apiInstance = new SendApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var _string = _string_example;  // string | string to send.
            var coin = coin_example;  // string | the coin name - bitcoin/litecoin.
            var test = 56;  // int? | if test = 1 so use testnet else test = 0 for mainnet.

            try
            {
                // Send string to bitcoin blockchain
                SingleResult result = apiInstance.SendString(token, account, user, pass, _string, coin, test);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SendApi.SendString: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **token** | **string**| a signed JWT token with the company privatekey. | 
 **account** | **int?**| API ID for Account where the coins must be spend. | 
 **user** | **string**| API user name. | 
 **pass** | **string**| API user password. | 
 **_string** | **string**| string to send. | 
 **coin** | **string**| the coin name - bitcoin/litecoin. | 
 **test** | **int?**| if test &#x3D; 1 so use testnet else test &#x3D; 0 for mainnet. | 

### Return type

[**SingleResult**](SingleResult.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

