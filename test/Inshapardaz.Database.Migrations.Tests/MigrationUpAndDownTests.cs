using System;
using System.Linq;
using NUnit.Framework;

namespace Inshapardaz.Database.Migrations.Tests
{
    [TestFixture]
    public class MigrationUpAndDownTests
    {
        private MigrationHelper _helper; 
        private const string _connectionString = "data source=.;Database=nawishta_test;integrated security=True;"; 
        public MigrationUpAndDownTests() 
        { 
            _helper = new MigrationHelper(_connectionString); 
        }
        
        [Test]
        public void LatestMigrations_CanRunUpAndDown()
        {
            var startingMigrationState = _helper.GetMigrationInfo(); 
            var migrationsToRun = startingMigrationState.NotInDatabase.Any();
            var initialDatabaseVersion = startingMigrationState.LatestDatabaseVersion; 
            var latestMigrationVersion = startingMigrationState.LatestAssemblyVersion;
            
            Console.WriteLine($"Migrations to run: {migrationsToRun}"); 
            Console.WriteLine($"Latest database version: {initialDatabaseVersion}"); 
            Console.WriteLine($"Latest assembly version: {latestMigrationVersion}");
            
            if (migrationsToRun)
            {
                _helper.RunUpTo(latestMigrationVersion);
                var newMigrationState = _helper.GetMigrationInfo(); 
                Assert.That(newMigrationState.LatestDatabaseVersion, Is.EqualTo(latestMigrationVersion));
                _helper.RunDownTo(initialDatabaseVersion);
                var endingMigrationState = _helper.GetMigrationInfo(); 
                Assert.That(endingMigrationState.LatestDatabaseVersion, Is.EqualTo(initialDatabaseVersion));
            }
            else { Assert.Pass("No migrations to run"); }
        }
    }
}