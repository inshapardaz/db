using System;
using FluentMigrator.Runner;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

namespace Inshapardaz.Database.Migrations.Runner
{
    internal class Program
    {
        [Option(ShortName = "c", Description = "Connection string to connect to database. Defaults to localhost")]
        public string ConnectionString { get; } =
           "data source=.;Database=Nawishta;integrated security=True;";

        [Option(ShortName = "v", Description = "Version to rollback to")]
        public long? Version { get; } = null;

        public static int Main(string[] args)
        => CommandLineApplication.Execute<Program>(args);

        private void OnExecute()
        {
            var serviceProvider = CreateServices(ConnectionString);

            using (var scope = serviceProvider.CreateScope())
            {
                UpdateDatabase(scope.ServiceProvider, Version);
            }
        }

        private static IServiceProvider CreateServices(string connectionString)
        {
            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(rb => rb
                    .AddSqlServer()
                    .WithGlobalConnectionString(connectionString)
                    .ScanIn(typeof(Migration000001_CreateLibrarySchema).Assembly).For.Migrations())
                .AddLogging(lb => lb.AddFluentMigratorConsole())
                .BuildServiceProvider(false);
        }

        private static void UpdateDatabase(IServiceProvider serviceProvider, long? rollbackVersion = null)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            if (rollbackVersion.HasValue)
            {
                runner.MigrateDown(rollbackVersion.Value);
            }
            else
            {
                runner.MigrateUp();
            }
        }
    }
}