namespace EF
{
    public static class ConnectionString
    {
        public static string MsSqlConnection => @"Server=.\SQLEXPRESS;Database=EF;User Id=User;Password=q;TrustServerCertificate=True";
    }
}