using System;
using NUnit.Framework;
using TechTalkTestes.Infra.Database.Postgres;

namespace TechTalkTestes.Integration.Tests
{
    [SetUpFixture]
    public class AssemblyConfigTests
    {
        [OneTimeSetUp]
        public void ApplicationTearDown()
        {
            SetEnvironmentVariablesDatabase();

            ConnectToDatabase();
        }

        private void SetEnvironmentVariablesDatabase()
        {
            Environment.SetEnvironmentVariable("POSTGRES_SERVERNAME", "postgreintegrationtests.postgres.database.azure.com");
            Environment.SetEnvironmentVariable("POSTGRES_DATABASE", "integrationtests_db");
            Environment.SetEnvironmentVariable("POSTGRES_USERID", "trapp@postgreintegrationtests");
            Environment.SetEnvironmentVariable("POSTGRES_PASSWORD", "15303@le");
        }

        private void ConnectToDatabase()
        {
            Repositories.CreateRepositoriesTest(DatabaseServices.OpenConnection());
        }
    }
}
