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
    ///  Class for testing TagApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class TagApiTests : IDisposable
    {
        private TagApi instance;

        public TagApiTests()
        {
            instance = new TagApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of TagApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' TagApi
            //Assert.IsType<TagApi>(instance);
        }

        /// <summary>
        /// Test DeleteTagByProjectAndId
        /// </summary>
        [Fact]
        public void DeleteTagByProjectAndIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid tagId = null;
            //var response = instance.DeleteTagByProjectAndId(projectId, tagId);
            //Assert.IsType<Tag>(response);
        }

        /// <summary>
        /// Test GetTagByProjectAndId
        /// </summary>
        [Fact]
        public void GetTagByProjectAndIdTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid tagId = null;
            //var response = instance.GetTagByProjectAndId(projectId, tagId);
            //Assert.IsType<Tag>(response);
        }

        /// <summary>
        /// Test GetTagsByProject
        /// </summary>
        [Fact]
        public void GetTagsByProjectTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //string pageAfter = null;
            //string pageBefore = null;
            //int? pageSize = null;
            //var response = instance.GetTagsByProject(projectId, pageAfter, pageBefore, pageSize);
            //Assert.IsType<List<Tag>>(response);
        }

        /// <summary>
        /// Test PostTagByProject
        /// </summary>
        [Fact]
        public void PostTagByProjectTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Tag body = null;
            //var response = instance.PostTagByProject(projectId, body);
            //Assert.IsType<Branch>(response);
        }
    }
}
