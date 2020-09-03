namespace TechTalkTestes.Infra.Database
{
    public static class PostgreConfiguration
    {
        public static string ConnectionString =>
            $"Server=localhost;" +
            $"Database=testes_db;" +
            $"Port=5432;" +
            $"User Id=sa;" +
            $"Password=sa";
    }
}
