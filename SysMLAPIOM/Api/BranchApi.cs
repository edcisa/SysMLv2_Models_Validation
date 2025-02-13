


using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Net.Mime;
using Org.OpenAPITools.Client;
using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Api
{

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBranchApiSync : IApiAccessor
    {
        #region Synchronous Operations
        /// <summary>
        /// Delete branch by project and ID
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        Branch DeleteBranchByProjectAndId(Guid projectId, Guid branchId, int operationIndex = 0);

        /// <summary>
        /// Delete branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        ApiResponse<Branch> DeleteBranchByProjectAndIdWithHttpInfo(Guid projectId, Guid branchId, int operationIndex = 0);
        /// <summary>
        /// Get branches by project
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;Branch&gt;</returns>
        List<Branch> GetBranchesByProject(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0);

        /// <summary>
        /// Get branches by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;Branch&gt;</returns>
        ApiResponse<List<Branch>> GetBranchesByProjectWithHttpInfo(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0);
        /// <summary>
        /// Get branch by project and ID
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        Branch GetBranchesByProjectAndId(Guid projectId, Guid branchId, int operationIndex = 0);

        /// <summary>
        /// Get branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        ApiResponse<Branch> GetBranchesByProjectAndIdWithHttpInfo(Guid projectId, Guid branchId, int operationIndex = 0);
        /// <summary>
        /// Create branch by project
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        Branch PostBranchByProject(Guid projectId, Branch body, int operationIndex = 0);

        /// <summary>
        /// Create branch by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        ApiResponse<Branch> PostBranchByProjectWithHttpInfo(Guid projectId, Branch body, int operationIndex = 0);
        #endregion Synchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBranchApiAsync : IApiAccessor
    {
        #region Asynchronous Operations
        /// <summary>
        /// Delete branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        System.Threading.Tasks.Task<Branch> DeleteBranchByProjectAndIdAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Delete branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        System.Threading.Tasks.Task<ApiResponse<Branch>> DeleteBranchByProjectAndIdWithHttpInfoAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get branches by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Branch&gt;</returns>
        System.Threading.Tasks.Task<List<Branch>> GetBranchesByProjectAsync(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get branches by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Branch&gt;)</returns>
        System.Threading.Tasks.Task<ApiResponse<List<Branch>>> GetBranchesByProjectWithHttpInfoAsync(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Get branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        System.Threading.Tasks.Task<Branch> GetBranchesByProjectAndIdAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Get branch by project and ID
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        System.Threading.Tasks.Task<ApiResponse<Branch>> GetBranchesByProjectAndIdWithHttpInfoAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        /// <summary>
        /// Create branch by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        System.Threading.Tasks.Task<Branch> PostBranchByProjectAsync(Guid projectId, Branch body, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        /// Create branch by project
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        System.Threading.Tasks.Task<ApiResponse<Branch>> PostBranchByProjectWithHttpInfoAsync(Guid projectId, Branch body, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
        #endregion Asynchronous Operations
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IBranchApi : IBranchApiSync, IBranchApiAsync
    {

    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public partial class BranchApi : IBranchApi
    {
        private Org.OpenAPITools.Client.ExceptionFactory _exceptionFactory = (name, response) => null;

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BranchApi() : this((string)null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchApi"/> class.
        /// </summary>
        /// <returns></returns>
        public BranchApi(string basePath)
        {
            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                new Org.OpenAPITools.Client.Configuration { BasePath = basePath }
            );
            this.Client = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchApi"/> class
        /// using Configuration object
        /// </summary>
        /// <param name="configuration">An instance of Configuration</param>
        /// <returns></returns>
        public BranchApi(Org.OpenAPITools.Client.Configuration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Configuration = Org.OpenAPITools.Client.Configuration.MergeConfigurations(
                Org.OpenAPITools.Client.GlobalConfiguration.Instance,
                configuration
            );
            this.Client = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            this.AsynchronousClient = new Org.OpenAPITools.Client.ApiClient(this.Configuration.BasePath);
            ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BranchApi"/> class
        /// using a Configuration object and client instance.
        /// </summary>
        /// <param name="client">The client interface for synchronous API access.</param>
        /// <param name="asyncClient">The client interface for asynchronous API access.</param>
        /// <param name="configuration">The configuration object.</param>
        public BranchApi(Org.OpenAPITools.Client.ISynchronousClient client, Org.OpenAPITools.Client.IAsynchronousClient asyncClient, Org.OpenAPITools.Client.IReadableConfiguration configuration)
        {
            if (client == null) throw new ArgumentNullException("client");
            if (asyncClient == null) throw new ArgumentNullException("asyncClient");
            if (configuration == null) throw new ArgumentNullException("configuration");

            this.Client = client;
            this.AsynchronousClient = asyncClient;
            this.Configuration = configuration;
            this.ExceptionFactory = Org.OpenAPITools.Client.Configuration.DefaultExceptionFactory;
        }

        /// <summary>
        /// The client for accessing this underlying API asynchronously.
        /// </summary>
        public Org.OpenAPITools.Client.IAsynchronousClient AsynchronousClient { get; set; }

        /// <summary>
        /// The client for accessing this underlying API synchronously.
        /// </summary>
        public Org.OpenAPITools.Client.ISynchronousClient Client { get; set; }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <value>The base path</value>
        public string GetBasePath()
        {
            return this.Configuration.BasePath;
        }

        /// <summary>
        /// Gets or sets the configuration object
        /// </summary>
        /// <value>An instance of the Configuration</value>
        public Org.OpenAPITools.Client.IReadableConfiguration Configuration { get; set; }

        /// <summary>
        /// Provides a factory method hook for the creation of exceptions.
        /// </summary>
        public Org.OpenAPITools.Client.ExceptionFactory ExceptionFactory
        {
            get
            {
                if (_exceptionFactory != null && _exceptionFactory.GetInvocationList().Length > 1)
                {
                    throw new InvalidOperationException("Multicast delegate for ExceptionFactory is unsupported.");
                }
                return _exceptionFactory;
            }
            set { _exceptionFactory = value; }
        }

        /// <summary>
        /// Delete branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        public Branch DeleteBranchByProjectAndId(Guid projectId, Guid branchId, int operationIndex = 0)
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = DeleteBranchByProjectAndIdWithHttpInfo(projectId, branchId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        public Org.OpenAPITools.Client.ApiResponse<Branch> DeleteBranchByProjectAndIdWithHttpInfo(Guid projectId, Guid branchId, int operationIndex = 0)
        {
            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("branchId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(branchId)); // path parameter

            localVarRequestOptions.Operation = "BranchApi.DeleteBranchByProjectAndId";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Delete<Branch>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteBranchByProjectAndId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Delete branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        public async System.Threading.Tasks.Task<Branch> DeleteBranchByProjectAndIdAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = await DeleteBranchByProjectAndIdWithHttpInfoAsync(projectId, branchId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Delete branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<Branch>> DeleteBranchByProjectAndIdWithHttpInfoAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("branchId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(branchId)); // path parameter

            localVarRequestOptions.Operation = "BranchApi.DeleteBranchByProjectAndId";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.DeleteAsync<Branch>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("DeleteBranchByProjectAndId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get branches by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>List&lt;Branch&gt;</returns>
        public List<Branch> GetBranchesByProject(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0)
        {
            Org.OpenAPITools.Client.ApiResponse<List<Branch>> localVarResponse = GetBranchesByProjectWithHttpInfo(projectId, pageAfter, pageBefore, pageSize);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get branches by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of List&lt;Branch&gt;</returns>
        public Org.OpenAPITools.Client.ApiResponse<List<Branch>> GetBranchesByProjectWithHttpInfo(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0)
        {
            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (pageAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[after]", pageAfter));
            }
            if (pageBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[before]", pageBefore));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[size]", pageSize));
            }

            localVarRequestOptions.Operation = "BranchApi.GetBranchesByProject";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<List<Branch>>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetBranchesByProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get branches by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of List&lt;Branch&gt;</returns>
        public async System.Threading.Tasks.Task<List<Branch>> GetBranchesByProjectAsync(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Org.OpenAPITools.Client.ApiResponse<List<Branch>> localVarResponse = await GetBranchesByProjectWithHttpInfoAsync(projectId, pageAfter, pageBefore, pageSize, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get branches by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="pageAfter">Page after (optional)</param>
        /// <param name="pageBefore">Page before (optional)</param>
        /// <param name="pageSize">Page size (optional)</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (List&lt;Branch&gt;)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<List<Branch>>> GetBranchesByProjectWithHttpInfoAsync(Guid projectId, string pageAfter = default(string), string pageBefore = default(string), int? pageSize = default(int?), int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            if (pageAfter != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[after]", pageAfter));
            }
            if (pageBefore != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[before]", pageBefore));
            }
            if (pageSize != null)
            {
                localVarRequestOptions.QueryParameters.Add(Org.OpenAPITools.Client.ClientUtils.ParameterToMultiMap("", "page[size]", pageSize));
            }

            localVarRequestOptions.Operation = "BranchApi.GetBranchesByProject";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<List<Branch>>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetBranchesByProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        public Branch GetBranchesByProjectAndId(Guid projectId, Guid branchId, int operationIndex = 0)
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = GetBranchesByProjectAndIdWithHttpInfo(projectId, branchId);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        public Org.OpenAPITools.Client.ApiResponse<Branch> GetBranchesByProjectAndIdWithHttpInfo(Guid projectId, Guid branchId, int operationIndex = 0)
        {
            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("branchId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(branchId)); // path parameter

            localVarRequestOptions.Operation = "BranchApi.GetBranchesByProjectAndId";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Get<Branch>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetBranchesByProjectAndId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Get branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        public async System.Threading.Tasks.Task<Branch> GetBranchesByProjectAndIdAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = await GetBranchesByProjectAndIdWithHttpInfoAsync(projectId, branchId, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Get branch by project and ID 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="branchId">ID of the branch</param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<Branch>> GetBranchesByProjectAndIdWithHttpInfoAsync(Guid projectId, Guid branchId, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.PathParameters.Add("branchId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(branchId)); // path parameter

            localVarRequestOptions.Operation = "BranchApi.GetBranchesByProjectAndId";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.GetAsync<Branch>("/projects/{projectId}/branches/{branchId}", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("GetBranchesByProjectAndId", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create branch by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>Branch</returns>
        public Branch PostBranchByProject(Guid projectId, Branch body, int operationIndex = 0)
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = PostBranchByProjectWithHttpInfo(projectId, body);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create branch by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <returns>ApiResponse of Branch</returns>
        public Org.OpenAPITools.Client.ApiResponse<Branch> PostBranchByProjectWithHttpInfo(Guid projectId, Branch body, int operationIndex = 0)
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'body' when calling BranchApi->PostBranchByProject");
            }

            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "BranchApi.PostBranchByProject";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = this.Client.Post<Branch>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration);
            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostBranchByProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

        /// <summary>
        /// Create branch by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of Branch</returns>
        public async System.Threading.Tasks.Task<Branch> PostBranchByProjectAsync(Guid projectId, Branch body, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Org.OpenAPITools.Client.ApiResponse<Branch> localVarResponse = await PostBranchByProjectWithHttpInfoAsync(projectId, body, operationIndex, cancellationToken).ConfigureAwait(false);
            return localVarResponse.Data;
        }

        /// <summary>
        /// Create branch by project 
        /// </summary>
        /// <exception cref="Org.OpenAPITools.Client.ApiException">Thrown when fails to make API call</exception>
        /// <param name="projectId">ID of the project</param>
        /// <param name="body"></param>
        /// <param name="operationIndex">Index associated with the operation.</param>
        /// <param name="cancellationToken">Cancellation Token to cancel the request.</param>
        /// <returns>Task of ApiResponse (Branch)</returns>
        public async System.Threading.Tasks.Task<Org.OpenAPITools.Client.ApiResponse<Branch>> PostBranchByProjectWithHttpInfoAsync(Guid projectId, Branch body, int operationIndex = 0, System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            // verify the required parameter 'body' is set
            if (body == null)
            {
                throw new Org.OpenAPITools.Client.ApiException(400, "Missing required parameter 'body' when calling BranchApi->PostBranchByProject");
            }


            Org.OpenAPITools.Client.RequestOptions localVarRequestOptions = new Org.OpenAPITools.Client.RequestOptions();

            string[] _contentTypes = new string[] {
                "application/json"
            };

            // to determine the Accept header
            string[] _accepts = new string[] {
                "application/json",
                "application/ld+json"
            };

            var localVarContentType = Org.OpenAPITools.Client.ClientUtils.SelectHeaderContentType(_contentTypes);
            if (localVarContentType != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Content-Type", localVarContentType);
            }

            var localVarAccept = Org.OpenAPITools.Client.ClientUtils.SelectHeaderAccept(_accepts);
            if (localVarAccept != null)
            {
                localVarRequestOptions.HeaderParameters.Add("Accept", localVarAccept);
            }

            localVarRequestOptions.PathParameters.Add("projectId", Org.OpenAPITools.Client.ClientUtils.ParameterToString(projectId)); // path parameter
            localVarRequestOptions.Data = body;

            localVarRequestOptions.Operation = "BranchApi.PostBranchByProject";
            localVarRequestOptions.OperationIndex = operationIndex;


            // make the HTTP request
            var localVarResponse = await this.AsynchronousClient.PostAsync<Branch>("/projects/{projectId}/branches", localVarRequestOptions, this.Configuration, cancellationToken).ConfigureAwait(false);

            if (this.ExceptionFactory != null)
            {
                Exception _exception = this.ExceptionFactory("PostBranchByProject", localVarResponse);
                if (_exception != null)
                {
                    throw _exception;
                }
            }

            return localVarResponse;
        }

    }
}
