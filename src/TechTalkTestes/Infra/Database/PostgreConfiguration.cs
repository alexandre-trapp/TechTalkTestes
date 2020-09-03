namespace TechTalkTestes.Infra.Database
{
    public static class PostgreConfiguration
    {
        public static string ConnectionString =>
            $"Server=postgreteste.postgres.database.azure.com;" +
            $"Database=testes_db;" +
            $"Port=5432;" +
            $"User Id=trapp@postgreteste;" +
            $"Password=15303@le";
    }
}
