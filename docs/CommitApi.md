# Org.OpenAPITools.Api.CommitApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetCommitByProjectAndId**](CommitApi.md#getcommitbyprojectandid) | **GET** /projects/{projectId}/commits/{commitId} | Get commit by project and ID |
| [**GetCommitsByProject**](CommitApi.md#getcommitsbyproject) | **GET** /projects/{projectId}/commits | Get commits by project |
| [**PostCommitByProject**](CommitApi.md#postcommitbyproject) | **POST** /projects/{projectId}/commits | Create commit by project |

<a id="getcommitbyprojectandid"></a>
# **GetCommitByProjectAndId**
> Commit GetCommitByProjectAndId (Guid projectId, Guid commitId)

Get commit by project and ID

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetCommitByProjectAndIdExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CommitApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var commitId = "commitId_example";  // Guid | ID of the commit

            try
            {
                // Get commit by project and ID
                Commit result = apiInstance.GetCommitByProjectAndId(projectId, commitId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommitApi.GetCommitByProjectAndId: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCommitByProjectAndIdWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get commit by project and ID
    ApiResponse<Commit> response = apiInstance.GetCommitByProjectAndIdWithHttpInfo(projectId, commitId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommitApi.GetCommitByProjectAndIdWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **commitId** | **Guid** | ID of the commit |  |

### Return type

[**Commit**](Commit.md)

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

<a id="getcommitsbyproject"></a>
# **GetCommitsByProject**
> List&lt;Commit&gt; GetCommitsByProject (Guid projectId, string? pageAfter = null, string? pageBefore = null, int? pageSize = null)

Get commits by project

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetCommitsByProjectExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CommitApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var pageAfter = "pageAfter_example";  // string? | Page after (optional) 
            var pageBefore = "pageBefore_example";  // string? | Page before (optional) 
            var pageSize = 56;  // int? | Page size (optional) 

            try
            {
                // Get commits by project
                List<Commit> result = apiInstance.GetCommitsByProject(projectId, pageAfter, pageBefore, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommitApi.GetCommitsByProject: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetCommitsByProjectWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get commits by project
    ApiResponse<List<Commit>> response = apiInstance.GetCommitsByProjectWithHttpInfo(projectId, pageAfter, pageBefore, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommitApi.GetCommitsByProjectWithHttpInfo: " + e.Message);
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

[**List&lt;Commit&gt;**](Commit.md)

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

<a id="postcommitbyproject"></a>
# **PostCommitByProject**
> Commit PostCommitByProject (Guid projectId, Commit body, Guid? branchId = null)

Create commit by project

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class PostCommitByProjectExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new CommitApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var body = new Commit(); // Commit | 
            var branchId = "branchId_example";  // Guid? | ID of the branch - project's default branch if unspecified (optional) 

            try
            {
                // Create commit by project
                Commit result = apiInstance.PostCommitByProject(projectId, body, branchId);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling CommitApi.PostCommitByProject: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the PostCommitByProjectWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Create commit by project
    ApiResponse<Commit> response = apiInstance.PostCommitByProjectWithHttpInfo(projectId, body, branchId);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling CommitApi.PostCommitByProjectWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **body** | [**Commit**](Commit.md) |  |  |
| **branchId** | **Guid?** | ID of the branch - project&#39;s default branch if unspecified | [optional]  |

### Return type

[**Commit**](Commit.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json
 - **Accept**: application/json, application/ld+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **201** | Created |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

