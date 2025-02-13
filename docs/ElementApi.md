# Org.OpenAPITools.Api.ElementApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetElementByProjectCommitId**](ElementApi.md#getelementbyprojectcommitid) | **GET** /projects/{projectId}/commits/{commitId}/elements/{elementId} | Get element by project, commit and ID |
| [**GetElementsByProjectCommit**](ElementApi.md#getelementsbyprojectcommit) | **GET** /projects/{projectId}/commits/{commitId}/elements | Get elements by project and commit |
| [**GetRootsByProjectCommit**](ElementApi.md#getrootsbyprojectcommit) | **GET** /projects/{projectId}/commits/{commitId}/roots | Get root elements by project and commit |

<a id="getelementbyprojectcommitid"></a>
# **GetElementByProjectCommitId**
> Element GetElementByProjectCommitId (Guid projectId, Guid commitId, Guid elementId)

Get element by project, commit and ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetElementByProjectCommitIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ElementApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var commitId = "commitId_example";  // Guid | ID of the commit
            var elementId = "elementId_example";  // Guid | ID of the element

            try
            {
                // Get element by project, commit and ID
                Element result = apiInstance.GetElementByProjectCommitId(projectId, commitId, elementId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ElementApi.GetElementByProjectCommitId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetElementByProjectCommitIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get element by project, commit and ID
    ApiResponse<Element> response = apiInstance.GetElementByProjectCommitIdWithHttpInfo(projectId, commitId, elementId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ElementApi.GetElementByProjectCommitIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **commitId** | **Guid** | ID of the commit |  |
| **elementId** | **Guid** | ID of the element |  |

### Return type

[**Element**](Element.md)

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

<a id="getelementsbyprojectcommit"></a>
# **GetElementsByProjectCommit**
> List&lt;Element&gt; GetElementsByProjectCommit (Guid projectId, Guid commitId, string? pageAfter = null, string? pageBefore = null, int? pageSize = null)

Get elements by project and commit

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetElementsByProjectCommitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ElementApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var commitId = "commitId_example";  // Guid | ID of the commit
            var pageAfter = "pageAfter_example";  // string? | Page after (optional) 
            var pageBefore = "pageBefore_example";  // string? | Page before (optional) 
            var pageSize = 56;  // int? | Page size (optional) 

            try
            {
                // Get elements by project and commit
                List<Element> result = apiInstance.GetElementsByProjectCommit(projectId, commitId, pageAfter, pageBefore, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ElementApi.GetElementsByProjectCommit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetElementsByProjectCommitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get elements by project and commit
    ApiResponse<List<Element>> response = apiInstance.GetElementsByProjectCommitWithHttpInfo(projectId, commitId, pageAfter, pageBefore, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ElementApi.GetElementsByProjectCommitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **commitId** | **Guid** | ID of the commit |  |
| **pageAfter** | **string?** | Page after | [optional]  |
| **pageBefore** | **string?** | Page before | [optional]  |
| **pageSize** | **int?** | Page size | [optional]  |

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

<a id="getrootsbyprojectcommit"></a>
# **GetRootsByProjectCommit**
> List&lt;Element&gt; GetRootsByProjectCommit (Guid projectId, Guid commitId, string? pageAfter = null, string? pageBefore = null, int? pageSize = null)

Get root elements by project and commit

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetRootsByProjectCommitExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new ElementApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var commitId = "commitId_example";  // Guid | ID of the commit
            var pageAfter = "pageAfter_example";  // string? | Page after (optional) 
            var pageBefore = "pageBefore_example";  // string? | Page before (optional) 
            var pageSize = 56;  // int? | Page size (optional) 

            try
            {
                // Get root elements by project and commit
                List<Element> result = apiInstance.GetRootsByProjectCommit(projectId, commitId, pageAfter, pageBefore, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling ElementApi.GetRootsByProjectCommit: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRootsByProjectCommitWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get root elements by project and commit
    ApiResponse<List<Element>> response = apiInstance.GetRootsByProjectCommitWithHttpInfo(projectId, commitId, pageAfter, pageBefore, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling ElementApi.GetRootsByProjectCommitWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **commitId** | **Guid** | ID of the commit |  |
| **pageAfter** | **string?** | Page after | [optional]  |
| **pageBefore** | **string?** | Page before | [optional]  |
| **pageSize** | **int?** | Page size | [optional]  |

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

