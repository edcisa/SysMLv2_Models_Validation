/*
 * SysML v2 API and Services
 *
 * REST/HTTP binding (PSM) for the SysML v2 standard API.
 *
 * The version of the OpenAPI document: 1.0.0
 * Generated by: https://github.com/openapitools/openapi-generator.git
 */

using System;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using RestSharp;
using Xunit;

using Org.OpenAPITools.Client;
using Org.OpenAPITools.Api;
// uncomment below to import models
//using Org.OpenAPITools.Model;

namespace Org.OpenAPITools.Test.Api
{
    /// <summary>
    ///  Class for testing ElementApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class ElementApiTests : IDisposable
    {
        private ElementApi instance;

        public ElementApiTests()
        {
            instance = new ElementApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of ElementApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' ElementApi
            //Assert.IsType<ElementApi>(instance);
        }

        /// <summary>
        /// Test GetElementByProjectCommitId
        /// </summary>
        [Fact]
        public void GetElementByProjectCommitIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid commitId = null;
            //Guid elementId = null;
            //var response = instance.GetElementByProjectCommitId(projectId, commitId, elementId);
            //Assert.IsType<Element>(response);
        }

        /// <summary>
        /// Test GetElementsByProjectCommit
        /// </summary>
        [Fact]
        public void GetElementsByProjectCommitTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid commitId = null;
            //string pageAfter = null;
            //string pageBefore = null;
            //int? pageSize = null;
            //var response = instance.GetElementsByProjectCommit(projectId, commitId, pageAfter, pageBefore, pageSize);
            //Assert.IsType<List<Element>>(response);
        }

        /// <summary>
        /// Test GetRootsByProjectCommit
        /// </summary>
        [Fact]
        public void GetRootsByProjectCommitTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid commitId = null;
            //string pageAfter = null;
            //string pageBefore = null;
            //int? pageSize = null;
            //var response = instance.GetRootsByProjectCommit(projectId, commitId, pageAfter, pageBefore, pageSize);
            //Assert.IsType<List<Element>>(response);
        }
    }
}
