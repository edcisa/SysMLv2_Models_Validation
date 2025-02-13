# Org.OpenAPITools.Api.RelationshipApi

All URIs are relative to *http://localhost*

| Method | HTTP request | Description |
|--------|--------------|-------------|
| [**GetRelationshipsByProjectCommitRelatedElement**](RelationshipApi.md#getrelationshipsbyprojectcommitrelatedelement) | **GET** /projects/{projectId}/commits/{commitId}/elements/{relatedElementId}/relationships | Get relationships by project, commit, and related element |

<a id="getrelationshipsbyprojectcommitrelatedelement"></a>
# **GetRelationshipsByProjectCommitRelatedElement**
> List&lt;Relationship&gt; GetRelationshipsByProjectCommitRelatedElement (Guid projectId, Guid commitId, Guid relatedElementId, string? direction = null, string? pageAfter = null, string? pageBefore = null, int? pageSize = null)

Get relationships by project, commit, and related element

### Example
```csharp
using System.Collections.Generic;
using System.Diagnostics;
using Org.OpenAPITools.Api;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Example
{
    public class GetRelationshipsByProjectCommitRelatedElementExample
    {
        public static void Main()
        {
            Configuration config = new Configuration();
            config.BasePath = "http://localhost";
            var apiInstance = new RelationshipApi(config);
            var projectId = "projectId_example";  // Guid | ID of the project
            var commitId = "commitId_example";  // Guid | ID of the commit
            var relatedElementId = "relatedElementId_example";  // Guid | ID of the related element
            var direction = "in";  // string? | Filter for relationships that are incoming (in), outgoing (out), or both relative to the related element (optional)  (default to both)
            var pageAfter = "pageAfter_example";  // string? | Page after (optional) 
            var pageBefore = "pageBefore_example";  // string? | Page before (optional) 
            var pageSize = 56;  // int? | Page size (optional) 

            try
            {
                // Get relationships by project, commit, and related element
                List<Relationship> result = apiInstance.GetRelationshipsByProjectCommitRelatedElement(projectId, commitId, relatedElementId, direction, pageAfter, pageBefore, pageSize);
                Debug.WriteLine(result);
            }
            catch (ApiException  e)
            {
                Debug.Print("Exception when calling RelationshipApi.GetRelationshipsByProjectCommitRelatedElement: " + e.Message);
                Debug.Print("Status Code: " + e.ErrorCode);
                Debug.Print(e.StackTrace);
            }
        }
    }
}
```

#### Using the GetRelationshipsByProjectCommitRelatedElementWithHttpInfo variant
This returns an ApiResponse object which contains the response data, status code and headers.

```csharp
try
{
    // Get relationships by project, commit, and related element
    ApiResponse<List<Relationship>> response = apiInstance.GetRelationshipsByProjectCommitRelatedElementWithHttpInfo(projectId, commitId, relatedElementId, direction, pageAfter, pageBefore, pageSize);
    Debug.Write("Status Code: " + response.StatusCode);
    Debug.Write("Response Headers: " + response.Headers);
    Debug.Write("Response Body: " + response.Data);
}
catch (ApiException e)
{
    Debug.Print("Exception when calling RelationshipApi.GetRelationshipsByProjectCommitRelatedElementWithHttpInfo: " + e.Message);
    Debug.Print("Status Code: " + e.ErrorCode);
    Debug.Print(e.StackTrace);
}
```

### Parameters

| Name | Type | Description | Notes |
|------|------|-------------|-------|
| **projectId** | **Guid** | ID of the project |  |
| **commitId** | **Guid** | ID of the commit |  |
| **relatedElementId** | **Guid** | ID of the related element |  |
| **direction** | **string?** | Filter for relationships that are incoming (in), outgoing (out), or both relative to the related element | [optional] [default to both] |
| **pageAfter** | **string?** | Page after | [optional]  |
| **pageBefore** | **string?** | Page before | [optional]  |
| **pageSize** | **int?** | Page size | [optional]  |

### Return type

[**List&lt;Relationship&gt;**](Relationship.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: Not defined
 - **Accept**: application/json, application/ld+json


### HTTP response details
| Status code | Description | Response headers |
|-------------|-------------|------------------|
| **200** | Ok |  -  |
| **415** | The requested content type is not acceptable. |  -  |
| **500** | Internal server error. |  -  |
| **0** | Unexpected response. |  -  |

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

