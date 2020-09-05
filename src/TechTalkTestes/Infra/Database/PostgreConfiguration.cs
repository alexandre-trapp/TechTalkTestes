namespace TechTalkTestes.Infra.Database
{
    public static class PostgreConfiguration
    {
        public static string GetConnectionString(string serverName, string database,
            string userId, string password)
        {
            return $"Server={serverName};" +
                   $"Database={database};" +
                   $"Port=5432;" +
                   $"User Id={userId};" +
                   $"Password={password}";
        }
    }
}
