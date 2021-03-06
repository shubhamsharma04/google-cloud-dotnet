﻿// Copyright 2016 Google Inc. All Rights Reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Google.Api.Gax;
using Google.Apis.Bigquery.v2.Data;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Google.Cloud.BigQuery.V2
{
    public abstract partial class BigQueryClient
    {
        /// <summary>
        /// Retrieves a dataset within this client's project given the dataset ID.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetDataset(DatasetReference,GetDatasetOptions)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The requested dataset.</returns>
        public virtual BigQueryDataset GetDataset(string datasetId, GetDatasetOptions options = null) =>
            GetDataset(GetDatasetReference(datasetId), options);

        /// <summary>
        /// Retrieves a dataset given a project ID and dataset ID.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetDataset(DatasetReference,GetDatasetOptions)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The requested dataset.</returns>
        public virtual BigQueryDataset GetDataset(string projectId, string datasetId, GetDatasetOptions options = null) =>
            GetDataset(GetDatasetReference(projectId, datasetId), options);

        /// <summary>
        /// Retrieves a dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The requested dataset.</returns>
        public virtual BigQueryDataset GetDataset(DatasetReference datasetReference, GetDatasetOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lists the datasets within this client's project.
        /// This method just creates a <see cref="ProjectReference"/> and delegates to <see cref="ListDatasets(ProjectReference, ListDatasetsOptions)"/>.
        /// </summary>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>A sequence of datasets within this project.</returns>
        public virtual PagedEnumerable<DatasetList, BigQueryDataset> ListDatasets(ListDatasetsOptions options = null) =>
            ListDatasets(GetProjectReference(ProjectId), options);

        /// <summary>
        /// Lists the datasets within the specified project.
        /// This method just creates a <see cref="ProjectReference"/> and delegates to <see cref="ListDatasets(ProjectReference, ListDatasetsOptions)"/>.
        /// </summary>
        /// <param name="projectId">The project to list the datasets from. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>A sequence of datasets within the specified project.</returns>
        public virtual PagedEnumerable<DatasetList, BigQueryDataset> ListDatasets(string projectId, ListDatasetsOptions options = null) =>
            ListDatasets(GetProjectReference(projectId), options);

        /// <summary>
        /// Lists the datasets within the specified project.
        /// </summary>
        /// <param name="projectReference">A fully-qualified identifier for the project. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>A sequence of datasets within the specified project.</returns>
        public virtual PagedEnumerable<DatasetList, BigQueryDataset> ListDatasets(ProjectReference projectReference, ListDatasetsOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a dataset with the specified ID in this client's project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="CreateDataset(DatasetReference,CreateDatasetOptions)"/>.
        /// </summary>
        /// <param name="datasetId">The new dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The created dataset.</returns>
        public virtual BigQueryDataset CreateDataset(string datasetId, CreateDatasetOptions options = null) =>
            CreateDataset(GetDatasetReference(datasetId), options);

        /// <summary>
        /// Creates a dataset with the specified ID in specified project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="CreateDataset(DatasetReference,CreateDatasetOptions)"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project in which to create the dataset. Must not be null.</param>
        /// <param name="datasetId">The new dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The created dataset.</returns>
        public virtual BigQueryDataset CreateDataset(string projectId, string datasetId, CreateDatasetOptions options = null) =>
            CreateDataset(GetDatasetReference(projectId, datasetId), options);

        /// <summary>
        /// Creates the specified dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The created dataset.</returns>
        public virtual BigQueryDataset CreateDataset(DatasetReference datasetReference, CreateDatasetOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Attempts to fetch the specified dataset within this client's project, creating it if it doesn't exist.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetOrCreateDataset(DatasetReference,GetDatasetOptions,CreateDatasetOptions)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The existing or new dataset.</returns>
        public virtual BigQueryDataset GetOrCreateDataset(string datasetId, GetDatasetOptions getOptions = null, CreateDatasetOptions createOptions = null) =>
            GetOrCreateDataset(GetDatasetReference(datasetId), getOptions, createOptions);

        /// <summary>
        /// Attempts to fetch the specified dataset within the given project, creating it if it doesn't exist.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetOrCreateDataset(DatasetReference,GetDatasetOptions,CreateDatasetOptions)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The existing or new dataset.</returns>
        public virtual BigQueryDataset GetOrCreateDataset(string projectId, string datasetId, GetDatasetOptions getOptions = null, CreateDatasetOptions createOptions = null) =>
            GetOrCreateDataset(GetDatasetReference(projectId, datasetId), getOptions, createOptions);

        /// <summary>
        /// Attempts to fetch the specified dataset, creating it if it doesn't exist.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The existing or new dataset.</returns>
        public virtual BigQueryDataset GetOrCreateDataset(DatasetReference datasetReference, GetDatasetOptions getOptions = null, CreateDatasetOptions createOptions = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deletes the specified dataset within this client's project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="DeleteDataset(DatasetReference,DeleteDatasetOptions)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        public virtual void DeleteDataset(string datasetId, DeleteDatasetOptions options = null) =>
            DeleteDataset(GetDatasetReference(datasetId), options);

        /// <summary>
        /// Deletes the specified dataset within the given project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="DeleteDataset(DatasetReference,DeleteDatasetOptions)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        public virtual void DeleteDataset(string projectId, string datasetId, DeleteDatasetOptions options = null) =>
            DeleteDataset(GetDatasetReference(projectId, datasetId), options);

        /// <summary>
        /// Deletes the specified dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        public virtual void DeleteDataset(DatasetReference datasetReference, DeleteDatasetOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified dataset to match the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="UpdateDataset(DatasetReference, Dataset, UpdateDatasetOptions)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset UpdateDataset(string projectId, string datasetId, Dataset resource, UpdateDatasetOptions options = null) =>
            UpdateDataset(GetDatasetReference(projectId, datasetId), resource, options);

        /// <summary>
        /// Updates the specified dataset within this client's project to match the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="UpdateDataset(DatasetReference, Dataset, UpdateDatasetOptions)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset UpdateDataset(string datasetId, Dataset resource, UpdateDatasetOptions options = null) =>
            UpdateDataset(GetDatasetReference(datasetId), resource, options);

        /// <summary>
        /// Updates the specified dataset to match the given resource.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset UpdateDataset(DatasetReference datasetReference, Dataset resource, UpdateDatasetOptions options = null) =>
            throw new NotImplementedException();

        /// <summary>
        /// Patches the specified dataset with fields in the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="PatchDataset(DatasetReference, Dataset, PatchDatasetOptions)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset PatchDataset(string projectId, string datasetId, Dataset resource, PatchDatasetOptions options = null) =>
            PatchDataset(GetDatasetReference(projectId, datasetId), resource, options);

        /// <summary>
        /// Patches the specified dataset within this client's project with fields in the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="PatchDataset(DatasetReference, Dataset, PatchDatasetOptions)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset PatchDataset(string datasetId, Dataset resource, PatchDatasetOptions options = null) =>
            PatchDataset(GetDatasetReference(datasetId), resource, options);

        /// <summary>
        /// Patches the specified dataset with fields in the given resource.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>The updated dataset.</returns>
        public virtual BigQueryDataset PatchDataset(DatasetReference datasetReference, Dataset resource, PatchDatasetOptions options = null) =>
            throw new NotImplementedException();

        /// <summary>
        /// Asynchronously retrieves a dataset within this client's project given the dataset ID.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetDatasetAsync(DatasetReference,GetDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the requested dataset.</returns>
        public virtual Task<BigQueryDataset> GetDatasetAsync(string datasetId, GetDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            GetDatasetAsync(GetDatasetReference(datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously retrieves a dataset given a project ID and dataset ID.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetDatasetAsync(DatasetReference,GetDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the requested dataset.</returns>
        public virtual Task<BigQueryDataset> GetDatasetAsync(string projectId, string datasetId,
            GetDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            GetDatasetAsync(GetDatasetReference(projectId, datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously retrieves a dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the requested dataset.</returns>
        public virtual Task<BigQueryDataset> GetDatasetAsync(DatasetReference datasetReference,
            GetDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously lists the datasets within this client's project.
        /// This method just creates a <see cref="ProjectReference"/> and delegates to <see cref="ListDatasetsAsync(ProjectReference, ListDatasetsOptions)"/>.
        /// </summary>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>An asynchronous sequence of datasets within this project.</returns>
        public virtual PagedAsyncEnumerable<DatasetList, BigQueryDataset> ListDatasetsAsync(ListDatasetsOptions options = null) =>
            ListDatasetsAsync(GetProjectReference(ProjectId), options);

        /// <summary>
        /// Asynchronously lists the datasets within the specified project.
        /// This method just creates a <see cref="ProjectReference"/> and delegates to <see cref="ListDatasetsAsync(ProjectReference, ListDatasetsOptions)"/>.
        /// </summary>
        /// <param name="projectId">The project to list the datasets from. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>An asynchronous sequence of datasets within the specified project.</returns>
        public virtual PagedAsyncEnumerable<DatasetList, BigQueryDataset> ListDatasetsAsync(string projectId, ListDatasetsOptions options = null) =>
            ListDatasetsAsync(GetProjectReference(projectId), options);

        /// <summary>
        /// Asynchronously lists the datasets within the specified project.
        /// </summary>
        /// <param name="projectReference">A fully-qualified identifier for the project. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>An asynchronous sequence of datasets within the specified project.</returns>
        public virtual PagedAsyncEnumerable<DatasetList, BigQueryDataset> ListDatasetsAsync(ProjectReference projectReference, ListDatasetsOptions options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously creates a dataset with the specified ID in this client's project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="CreateDatasetAsync(DatasetReference,CreateDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="datasetId">The new dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the created dataset.</returns>
        public virtual Task<BigQueryDataset> CreateDatasetAsync(string datasetId,
            CreateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            CreateDatasetAsync(GetDatasetReference(datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously creates a dataset with the specified ID in specified project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="CreateDatasetAsync(DatasetReference,CreateDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="projectId">The ID of the project in which to create the dataset. Must not be null.</param>
        /// <param name="datasetId">The new dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the created dataset.</returns>
        public virtual Task<BigQueryDataset> CreateDatasetAsync(string projectId, string datasetId,
            CreateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            CreateDatasetAsync(GetDatasetReference(projectId, datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously creates the specified dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the created dataset.</returns>
        public virtual Task<BigQueryDataset> CreateDatasetAsync(DatasetReference datasetReference,
            CreateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously attempts to fetch the specified dataset within this client's project, creating it if it doesn't exist.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetOrCreateDatasetAsync(DatasetReference,GetDatasetOptions,CreateDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the existing or new dataset.</returns>
        public virtual Task<BigQueryDataset> GetOrCreateDatasetAsync(string datasetId,
            GetDatasetOptions getOptions = null, CreateDatasetOptions createOptions = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            GetOrCreateDatasetAsync(GetDatasetReference(datasetId), getOptions, createOptions, cancellationToken);

        /// <summary>
        /// Asynchronously attempts to fetch the specified dataset within the given project, creating it if it doesn't exist.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="GetOrCreateDatasetAsync(DatasetReference,GetDatasetOptions,CreateDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the existing or new dataset.</returns>
        public virtual Task<BigQueryDataset> GetOrCreateDatasetAsync(string projectId, string datasetId,
            GetDatasetOptions getOptions = null, CreateDatasetOptions createOptions = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            GetOrCreateDatasetAsync(GetDatasetReference(projectId, datasetId), getOptions, createOptions, cancellationToken);

        /// <summary>
        /// Asynchronously attempts to fetch the specified dataset, creating it if it doesn't exist.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="getOptions">The options for the "get" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="createOptions">The options for the "create" operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the existing or new dataset.</returns>
        public virtual Task<BigQueryDataset> GetOrCreateDatasetAsync(DatasetReference datasetReference, GetDatasetOptions getOptions = null,
            CreateDatasetOptions createOptions = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously deletes the specified dataset within this client's project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="DeleteDatasetAsync(DatasetReference,DeleteDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual Task DeleteDatasetAsync(string datasetId, DeleteDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            DeleteDatasetAsync(GetDatasetReference(datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously deletes the specified dataset within the given project.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="DeleteDatasetAsync(DatasetReference,DeleteDatasetOptions,CancellationToken)"/>.
        /// </summary>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual Task DeleteDatasetAsync(string projectId, string datasetId, DeleteDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            DeleteDatasetAsync(GetDatasetReference(projectId, datasetId), options, cancellationToken);

        /// <summary>
        /// Asynchronously deletes the specified dataset.
        /// </summary>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public virtual Task DeleteDatasetAsync(DatasetReference datasetReference, DeleteDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronously updates the specified dataset to match the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="UpdateDatasetAsync(DatasetReference, Dataset, UpdateDatasetOptions, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> UpdateDatasetAsync(string projectId, string datasetId, Dataset resource, UpdateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            UpdateDatasetAsync(GetDatasetReference(projectId, datasetId), resource, options, cancellationToken);

        /// <summary>
        /// Asynchronously updates the specified dataset within this client's project to match the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="UpdateDatasetAsync(DatasetReference, Dataset, UpdateDatasetOptions, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> UpdateDatasetAsync(string datasetId, Dataset resource, UpdateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            UpdateDatasetAsync(GetDatasetReference(datasetId), resource, options, cancellationToken);

        /// <summary>
        /// Asynchronously updates the specified dataset to match the given resource.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the update. All updatable fields will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> UpdateDatasetAsync(DatasetReference datasetReference, Dataset resource, UpdateDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            throw new NotImplementedException();

        /// <summary>
        /// Asynchronously patches the specified dataset with fields in the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="PatchDatasetAsync(DatasetReference, Dataset, PatchDatasetOptions, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="projectId">The project ID. Must not be null.</param>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> PatchDatasetAsync(string projectId, string datasetId, Dataset resource, PatchDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            PatchDatasetAsync(GetDatasetReference(projectId, datasetId), resource, options, cancellationToken);

        /// <summary>
        /// Asynchronously patches the specified dataset within this client's project with fields in the given resource.
        /// This method just creates a <see cref="DatasetReference"/> and delegates to <see cref="PatchDatasetAsync(DatasetReference, Dataset, PatchDatasetOptions, CancellationToken)"/>.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetId">The dataset ID. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> PatchDatasetAsync(string datasetId, Dataset resource, PatchDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            PatchDatasetAsync(GetDatasetReference(datasetId), resource, options, cancellationToken);

        /// <summary>
        /// Asynchronously patches the specified dataset with fields in the given resource.
        /// </summary>
        /// <remarks>
        /// If the resource contains an ETag, it is used for optimistic concurrency validation.
        /// </remarks>
        /// <param name="datasetReference">A fully-qualified identifier for the dataset. Must not be null.</param>
        /// <param name="resource">The dataset resource representation to use for the patch. Only fields present in the resource will be updated.</param>
        /// <param name="options">The options for the operation. May be null, in which case defaults will be supplied.</param>
        /// <param name="cancellationToken">The token to monitor for cancellation requests.</param>
        /// <returns>A task representing the asynchronous operation. When complete, the result is
        /// the updated dataset.</returns>
        public virtual Task<BigQueryDataset> PatchDatasetAsync(DatasetReference datasetReference, Dataset resource, PatchDatasetOptions options = null, CancellationToken cancellationToken = default(CancellationToken)) =>
            throw new NotImplementedException();
    }
}
