# AStar.Api.SearchApi

All URIs are relative to *http://dev.astar.tech:8085/v2*

Method | HTTP request | Description
------------- | ------------- | -------------
[**SearchByAPIID**](SearchApi.md#searchbyapiid) | **POST** /search/registered/id | Get transaction informations by API ID
[**SearchByContent**](SearchApi.md#searchbycontent) | **POST** /search/registered/content | Get transaction informations by file or string content
[**SearchByHash**](SearchApi.md#searchbyhash) | **POST** /search/registered/hash | Get transaction informations by file or string hash


<a name="searchbyapiid"></a>
# **SearchByAPIID**
> Transaction SearchByAPIID (string token, int? account, string user, string pass, int? id)

Get transaction informations by API ID

Get transaction informations by API ID 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SearchByAPIIDExample
    {
        public void main()
        {
            
            var apiInstance = new SearchApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var id = 56;  // int? | API id for blockchain transaction

            try
            {
                // Get transaction informations by API ID
                Transaction result = apiInstance.SearchByAPIID(token, account, user, pass, id);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchByAPIID: " + e.Message );
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
 **id** | **int?**| API id for blockchain transaction | 

### Return type

[**Transaction**](Transaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchbycontent"></a>
# **SearchByContent**
> Transaction SearchByContent (string token, int? account, string user, string pass, string content)

Get transaction informations by file or string content

Get transaction informations by file or string content 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SearchByContentExample
    {
        public void main()
        {
            
            var apiInstance = new SearchApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var content = content_example;  // string | file or string content.

            try
            {
                // Get transaction informations by file or string content
                Transaction result = apiInstance.SearchByContent(token, account, user, pass, content);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchByContent: " + e.Message );
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
 **content** | **string**| file or string content. | 

### Return type

[**Transaction**](Transaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="searchbyhash"></a>
# **SearchByHash**
> Transaction SearchByHash (string token, int? account, string user, string pass, string hash)

Get transaction informations by file or string hash

Get transaction informations by file or string hash 

### Example
```csharp
using System;
using System.Diagnostics;
using AStar.Api;
using AStar.Client;
using AStar.Model;

namespace Example
{
    public class SearchByHashExample
    {
        public void main()
        {
            
            var apiInstance = new SearchApi();
            var token = token_example;  // string | a signed JWT token with the company privatekey.
            var account = 56;  // int? | API ID for Account where the coins must be spend.
            var user = user_example;  // string | API user name.
            var pass = pass_example;  // string | API user password.
            var hash = hash_example;  // string | hash of content.

            try
            {
                // Get transaction informations by file or string hash
                Transaction result = apiInstance.SearchByHash(token, account, user, pass, hash);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling SearchApi.SearchByHash: " + e.Message );
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
 **hash** | **string**| hash of content. | 

### Return type

[**Transaction**](Transaction.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/x-www-form-urlencoded
 - **Accept**: application/json

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

