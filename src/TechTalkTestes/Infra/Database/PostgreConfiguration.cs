namespace TechTalkTestes.Infra.Database
{
    public static class PostgreConfiguration
    {
        public static string ConnectionString =>
            $"Server={Host};" +
            $"Database={DatabaseName};" +
            $"Port={Port};" +
            $"User Id={User};" +
            $"Password={Password}";
    }
}
