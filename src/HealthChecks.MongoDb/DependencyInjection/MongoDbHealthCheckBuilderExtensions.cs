﻿using HealthChecks.MongoDb;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Collections.Generic;
using MongoDB.Driver;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class MongoDbHealthCheckBuilderExtensions
    {
        const string NAME = "mongodb";

        /// <summary>
        /// Add a health check for MongoDb database that list all databases on the system.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <param name="mongodbConnectionString">The MongoDb connection string to be used.</param>
        /// <param name="name">The health check name. Optional. If <c>null</c> the type name 'mongodb' will be used for the name.</param>
        /// <param name="failureStatus">
        /// The <see cref="HealthStatus"/> that should be reported when the health check fails. Optional. If <c>null</c> then
        /// the default status of <see cref="HealthStatus.Unhealthy"/> will be reported.
        /// </param>
        /// <param name="tags">A list of tags that can be used to filter sets of health checks. Optional.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/>.</returns></param>
        public static IHealthChecksBuilder AddMongoDb(this IHealthChecksBuilder builder, string mongodbConnectionString, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default)
        {
            var mongoDbHealthCheck = new MongoDbHealthCheck(mongodbConnectionString);
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => mongoDbHealthCheck,
                failureStatus,
                tags));
        }

        /// <summary>
        /// Add a health check for MongoDb database that list all collections from specified database on <paramref name="mongoDatabaseName"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <param name="mongodbConnectionString">The MongoDb connection string to be used.</param>
        /// <param name="mongoDatabaseName">The Database name to check.</param>
        /// <param name="name">The health check name. Optional. If <c>null</c> the type name 'mongodb' will be used for the name.</param>
        /// <param name="failureStatus">
        /// The <see cref="HealthStatus"/> that should be reported when the health check fails. Optional. If <c>null</c> then
        /// the default status of <see cref="HealthStatus.Unhealthy"/> will be reported.
        /// </param>
        /// <param name="tags">A list of tags that can be used to filter sets of health checks. Optional.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/>.</returns></param>
        public static IHealthChecksBuilder AddMongoDb(this IHealthChecksBuilder builder, string mongodbConnectionString, string mongoDatabaseName, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default)
        {
            var mongoDbHealthCheck = new MongoDbHealthCheck(mongodbConnectionString, mongoDatabaseName);
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => mongoDbHealthCheck,
                failureStatus,
                tags));
        }

        /// <summary>
        /// Add a health check for MongoDb database that list all collections from specified database on <paramref name="mongoDatabaseName"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <param name="mongoClientSettings">The MongoClientSettings to be used.</param>
        /// <param name="name">The health check name. Optional. If <c>null</c> the type name 'mongodb' will be used for the name.</param>
        /// <param name="failureStatus">
        /// The <see cref="HealthStatus"/> that should be reported when the health check fails. Optional. If <c>null</c> then
        /// the default status of <see cref="HealthStatus.Unhealthy"/> will be reported.
        /// </param>
        /// <param name="tags">A list of tags that can be used to filter sets of health checks. Optional.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/>.</returns></param>
        public static IHealthChecksBuilder AddMongoDb(this IHealthChecksBuilder builder, MongoClientSettings mongoClientSettings, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default)
        {
            var mongoDbHealthCheck = new MongoDbHealthCheck(mongoClientSettings);
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => mongoDbHealthCheck,
                failureStatus,
                tags));
        }

        /// <summary>
        /// Add a health check for MongoDb database that list all collections from specified database on <paramref name="mongoDatabaseName"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IHealthChecksBuilder"/>.</param>
        /// <param name="mongoClientSettings">The MongoClientSettings to be used.</param>
        /// <param name="mongoDatabaseName">The Database name to check.</param>
        /// <param name="name">The health check name. Optional. If <c>null</c> the type name 'mongodb' will be used for the name.</param>
        /// <param name="failureStatus">
        /// The <see cref="HealthStatus"/> that should be reported when the health check fails. Optional. If <c>null</c> then
        /// the default status of <see cref="HealthStatus.Unhealthy"/> will be reported.
        /// </param>
        /// <param name="tags">A list of tags that can be used to filter sets of health checks. Optional.</param>
        /// <returns>The <see cref="IHealthChecksBuilder"/>.</returns></param>
        public static IHealthChecksBuilder AddMongoDb(this IHealthChecksBuilder builder, MongoClientSettings mongoClientSettings, string mongoDatabaseName, string name = default, HealthStatus? failureStatus = default, IEnumerable<string> tags = default)
        {
            var mongoDbHealthCheck = new MongoDbHealthCheck(mongoClientSettings, mongoDatabaseName);
            return builder.Add(new HealthCheckRegistration(
                name ?? NAME,
                sp => mongoDbHealthCheck,
                failureStatus,
                tags));
        }
    }
}
