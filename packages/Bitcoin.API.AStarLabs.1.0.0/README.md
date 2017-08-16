# Bitcoin C# API Client

For more information, please visit [http://www.astarlabs.com](http://www.astarlabs.com)

<a name="frameworks-supported"></a>
## Frameworks supported
- .NET 4.0 or later
- Windows Phone 7.1 (Mango)

<a name="dependencies"></a>
## Dependencies
- [RestSharp](https://www.nuget.org/packages/RestSharp) - 105.1.0 or later
- [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) - 7.0.0 or later
- [jose-jwt](https://www.nuget.org/packages/jose-jwt/) - 2.3.0 or later
- [BouncyCastle](https://www.nuget.org/packages/BouncyCastle/) - 1.8.1 or later

The DLLs included in the package may not be the latest version. We recommend using [NuGet] (https://docs.nuget.org/consume/installing-nuget) to obtain the latest version of the packages:
```
Install-Package RestSharp
Install-Package Newtonsoft.Json
Install-Package jose-jwt
Install-Package BouncyCastle
```

<a name="installation"></a>
## Installation
Run the following command to generate the DLL
- [Mac/Linux] `/bin/sh build.sh`
- [Windows] `build.bat`

Then include the DLL (under the `bin` folder) in the C# project, and use the namespaces:
```csharp
using AStar.Client;
using AStar.Api;
using AStar.Model;
using AStar.Util;
```
<a name="packaging"></a>
## Packaging

A `.nuspec` is included with the project. You can follow the Nuget quickstart to [create](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#create-the-package) and [publish](https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package#publish-the-package) packages.

This `.nuspec` uses placeholders from the `.csproj`, so build the `.csproj` directly:

```
nuget pack -Build -OutputDirectory out AStar.csproj
```

Then, publish to a [local feed](https://docs.microsoft.com/en-us/nuget/hosting-packages/local-feeds) or [other host](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) and consume the new package via Nuget as usual.

<a name="getting-started"></a>
## Getting Started

```csharp
using System;
using System.Diagnostics;
using AStar.Client;
using AStar.Api;
using AStar.Model;
using AStar.Util;

namespace Example
{
    public class Example
    {
        public void main()
        {

            string token = Token.sign("YOUR PRIVATE KEY");
            int account = 15;
            string user = "test";
            string pass = "test";
            int id = 333;
            var response = instance.SearchByAPIID(token, account, user, pass, id);

        }
    }
}
```

<a name="documentation-for-api-endpoints"></a>
## Documentation for API Endpoints

All URIs are relative to fulladdress parameter: [**server-info.json**](https://github.com/astarlabs/bitcoin-client-server/blob/master/server-info.json)

Class | Method | HTTP request | Description
------------ | ------------- | ------------- | -------------
*SearchApi* | [**SearchByAPIID**](docs/SearchApi.md#searchbyapiid) | **POST** /search/registered/id | Get transaction informations by API ID
*SearchApi* | [**SearchByContent**](docs/SearchApi.md#searchbycontent) | **POST** /search/registered/content | Get transaction informations by file or string content
*SearchApi* | [**SearchByHash**](docs/SearchApi.md#searchbyhash) | **POST** /search/registered/hash | Get transaction informations by file or string hash
*SendApi* | [**SendFile**](docs/SendApi.md#sendfile) | **POST** /send/opreturn/base64 | Send file hash to bitcoin blockchain
*SendApi* | [**SendHash**](docs/SendApi.md#sendhash) | **POST** /send/opreturn/hash | Send hash to bitcoin blockchain
*SendApi* | [**SendPayAddress**](docs/SendApi.md#sendpayaddress) | **POST** /send/payaddress | Send a value for address
*SendApi* | [**SendString**](docs/SendApi.md#sendstring) | **POST** /send/opreturn/string | Send string to bitcoin blockchain


<a name="documentation-for-models"></a>
## Documentation for Models

 - [Model.SingleResult](docs/SingleResult.md)
 - [Model.Transaction](docs/Transaction.md)
