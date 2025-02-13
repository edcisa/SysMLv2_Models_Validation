# Org.OpenAPITools.Api.QueryApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**DeleteQueryByProjectAndId**](QueryApi.md#deletequerybyprojectandid) | **DELETE** /projects/{projectId}/queries/{queryId} | Delete query by project and ID |
| [**GetQueriesByProject**](QueryApi.md#getqueriesbyproject) | **GET** /projects/{projectId}/queries | Get queries by project |
| [**GetQueryByProjectAndId**](QueryApi.md#getquerybyprojectandid) | **GET** /projects/{projectId}/queries/{queryId} | Get query by project and ID |
| [**GetQueryResultsByProjectIdQuery**](QueryApi.md#getqueryresultsbyprojectidquery) | **GET** /projects/{projectId}/query-results | Get query results by project and query definition |
| [**GetQueryResultsByProjectIdQueryId**](QueryApi.md#getqueryresultsbyprojectidqueryid) | **GET** /projects/{projectId}/queries/{queryId}/results | Get query results by project and query |
| [**GetQueryResultsByProjectIdQueryPost**](QueryApi.md#getqueryresultsbyprojectidquerypost) | **POST** /projects/{projectId}/query-results | Get query results by project and query definition via POST |
| [**PostQueryByProject**](QueryApi.md#postquerybyproject) | **POST** /projects/{projectId}/queries | Create query by project |

<a id="deletequerybyprojectandid"></a>
# **DeleteQueryByProjectAndId**
> Query DeleteQueryByProjectAndId (Guid projectId, Guid queryId)

Delete query by project and ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class DeleteQueryByProjectAndIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var queryId = "queryId_example";  // Guid | ID of the query

            try
            {
                // Delete query by project and ID
                Query result = apiInstance.DeleteQueryByProjectAndId(projectId, queryId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.DeleteQueryByProjectAndId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the DeleteQueryByProjectAndIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Delete query by project and ID
    ApiResponse<Query> response = apiInstance.DeleteQueryByProjectAndIdWithHttpInfo(projectId, queryId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.DeleteQueryByProjectAndIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **queryId** | **Guid** | ID of the query |  |

### Return type

[**Query**](Query.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getqueriesbyproject"></a>
# **GetQueriesByProject**
> List&lt;Query&gt; GetQueriesByProject (Guid projectId, string? pageAfter = null, string? pageBefore = null, int? pageSize = null)

Get queries by project

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetQueriesByProjectExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var pageAfter = "pageAfter_example";  // string? | Page after (optional) 
            var pageBefore = "pageBefore_example";  // string? | Page before (optional) 
            var pageSize = 56;  // int? | Page size (optional) 

            try
            {
                // Get queries by project
                List<Query> result = apiInstance.GetQueriesByProject(projectId, pageAfter, pageBefore, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.GetQueriesByProject: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetQueriesByProjectWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get queries by project
    ApiResponse<List<Query>> response = apiInstance.GetQueriesByProjectWithHttpInfo(projectId, pageAfter, pageBefore, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.GetQueriesByProjectWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **pageAfter** | **string?** | Page after | [optional]  |
| **pageBefore** | **string?** | Page before | [optional]  |
| **pageSize** | **int?** | Page size | [optional]  |

### Return type

[**List&lt;Query&gt;**](Query.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getquerybyprojectandid"></a>
# **GetQueryByProjectAndId**
> Query GetQueryByProjectAndId (Guid projectId, Guid queryId)

Get query by project and ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetQueryByProjectAndIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var queryId = "queryId_example";  // Guid | ID of the query

            try
            {
                // Get query by project and ID
                Query result = apiInstance.GetQueryByProjectAndId(projectId, queryId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.GetQueryByProjectAndId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetQueryByProjectAndIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get query by project and ID
    ApiResponse<Query> response = apiInstance.GetQueryByProjectAndIdWithHttpInfo(projectId, queryId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.GetQueryByProjectAndIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **queryId** | **Guid** | ID of the query |  |

### Return type

[**Query**](Query.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getqueryresultsbyprojectidquery"></a>
# **GetQueryResultsByProjectIdQuery**
> List&lt;Element&gt; GetQueryResultsByProjectIdQuery (Guid projectId, Query body, Guid? commitId = null)

Get query results by project and query definition

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetQueryResultsByProjectIdQueryExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var body = new Query(); // Query | 
            var commitId = "commitId_example";  // Guid? | ID of the commit - defaults to head of project (optional) 

            try
            {
                // Get query results by project and query definition
                List<Element> result = apiInstance.GetQueryResultsByProjectIdQuery(projectId, body, commitId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQuery: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetQueryResultsByProjectIdQueryWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get query results by project and query definition
    ApiResponse<List<Element>> response = apiInstance.GetQueryResultsByProjectIdQueryWithHttpInfo(projectId, body, commitId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQueryWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **body** | [**Query**](Query.md) |  |  |
| **commitId** | **Guid?** | ID of the commit - defaults to head of project | [optional]  |

### Return type

[**List&lt;Element&gt;**](Element.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/ld+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getqueryresultsbyprojectidqueryid"></a>
# **GetQueryResultsByProjectIdQueryId**
> List&lt;Element&gt; GetQueryResultsByProjectIdQueryId (Guid projectId, Guid queryId, Guid? commitId = null)

Get query results by project and query

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetQueryResultsByProjectIdQueryIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var queryId = "queryId_example";  // Guid | ID of the query
            var commitId = "commitId_example";  // Guid? | ID of the commit - defaults to head of project (optional) 

            try
            {
                // Get query results by project and query
                List<Element> result = apiInstance.GetQueryResultsByProjectIdQueryId(projectId, queryId, commitId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQueryId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetQueryResultsByProjectIdQueryIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get query results by project and query
    ApiResponse<List<Element>> response = apiInstance.GetQueryResultsByProjectIdQueryIdWithHttpInfo(projectId, queryId, commitId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQueryIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **queryId** | **Guid** | ID of the query |  |
| **commitId** | **Guid?** | ID of the commit - defaults to head of project | [optional]  |

### Return type

[**List&lt;Element&gt;**](Element.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/ld+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="getqueryresultsbyprojectidquerypost"></a>
# **GetQueryResultsByProjectIdQueryPost**
> List&lt;Element&gt; GetQueryResultsByProjectIdQueryPost (Guid projectId, Query body, Guid? commitId = null)

Get query results by project and query definition via POST

For compatibility with clients that don't support GET requests with a body

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetQueryResultsByProjectIdQueryPostExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var body = new Query(); // Query | 
            var commitId = "commitId_example";  // Guid? | ID of the commit - defaults to head of project (optional) 

            try
            {
                // Get query results by project and query definition via POST
                List<Element> result = apiInstance.GetQueryResultsByProjectIdQueryPost(projectId, body, commitId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQueryPost: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetQueryResultsByProjectIdQueryPostWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get query results by project and query definition via POST
    ApiResponse<List<Element>> response = apiInstance.GetQueryResultsByProjectIdQueryPostWithHttpInfo(projectId, body, commitId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.GetQueryResultsByProjectIdQueryPostWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **body** | [**Query**](Query.md) |  |  |
| **commitId** | **Guid?** | ID of the commit - defaults to head of project | [optional]  |

### Return type

[**List&lt;Element&gt;**](Element.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/ld+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **404** | Not found. |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a id="postquerybyproject"></a>
# **PostQueryByProject**
> Query PostQueryByProject (Guid projectId, Query body)

Create query by project

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class PostQueryByProjectExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new QueryApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var body = new Query(); // Query | 

            try
            {
                // Create query by project
                Query result = apiInstance.PostQueryByProject(projectId, body);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling QueryApi.PostQueryByProject: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostQueryByProjectWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create query by project
    ApiResponse<Query> response = apiInstance.PostQueryByProjectWithHttpInfo(projectId, body);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling QueryApi.PostQueryByProjectWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **body** | [**Query**](Query.md) |  |  |

### Return type

[**Query**](Query.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

