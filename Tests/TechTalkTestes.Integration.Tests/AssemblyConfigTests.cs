using System;
using NUnit.Framework;
using TechTalkTestes.Infra.Database.Postgres;

namespace TechTalkTestes.Integration.Tests
{
    [SetUpFixture]
    public class AssemblyConfigTests
    {
        /// <summary>
        /// Aqui você poderia realizar alguma ação
        /// antes dos testes de integração iniciarem finalizado, 
        /// como executar migrations, criar e conectar uma base de dados, tabelas, preencher
        /// parametrizações default na base, etc.
        /// </summary>
        [OneTimeSetUp]
        public void ApplicationSetUp()
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

        /// <summary>
        /// Aqui você poderia realizar alguma ação
        /// após todos os testes de integração terem finalizado, 
        /// como limpar todos os dados das tabelas, ou dropar a base de dados, se necessário
        /// </summary>
        [OneTimeTearDown]
        public void ApplicationTearDown()
        {
            //LimparTodasAsTabelas();
            //DropDatabase();
        }
    }
}
