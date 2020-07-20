namespace UsersWebAPI.App_Start
{
    public static class WebApiConfig
    {
        public static string DATABASE_CONNECTION = "Server=(localdb)\\mssqllocaldb;Database=MarketDB;Trusted_Connection=True;MultipleActiveResultSets=true;";
        public static readonly int EXISTING_USER_RESPONSE = 0;
    }
}