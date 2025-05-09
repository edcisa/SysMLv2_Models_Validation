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
    ///  Class for testing RelationshipApi
    /// </summary>
    /// <remarks>
    /// This file is automatically generated by OpenAPI Generator (https://openapi-generator.tech).
    /// Please update the test case below to test the API endpoint.
    /// </remarks>
    public class RelationshipApiTests : IDisposable
    {
        private RelationshipApi instance;

        public RelationshipApiTests()
        {
            instance = new RelationshipApi();
        }

        public void Dispose()
        {
            // Cleanup when everything is done.
        }

        /// <summary>
        /// Test an instance of RelationshipApi
        /// </summary>
        [Fact]
        public void InstanceTest()
        {
            // TODO uncomment below to test 'IsType' RelationshipApi
            //Assert.IsType<RelationshipApi>(instance);
        }

        /// <summary>
        /// Test GetRelationshipsByProjectCommitRelatedElement
        /// </summary>
        [Fact]
        public void GetRelationshipsByProjectCommitRelatedElementTest()
        {
            // TODO uncomment below to test the method and replace null with proper value
            //Guid projectId = null;
            //Guid commitId = null;
            //Guid relatedElementId = null;
            //string direction = null;
            //string pageAfter = null;
            //string pageBefore = null;
            //int? pageSize = null;
            //var response = instance.GetRelationshipsByProjectCommitRelatedElement(projectId, commitId, relatedElementId, direction, pageAfter, pageBefore, pageSize);
            //Assert.IsType<List<Relationship>>(response);
        }
    }
}
