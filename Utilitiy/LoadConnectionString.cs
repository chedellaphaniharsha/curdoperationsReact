namespace webapi.Utilitiy
{
    public class LoadConnectionString
    {
        public string LoadString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
             .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
             .AddJsonFile("appsettings.json").Build();
            string constr = configuration.GetConnectionString("constr");
            return constr;
        }
    }
}
