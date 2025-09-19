using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistence;

static class Configuration
{
    static public string? ConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
        
            // Mevcut klasör dışında bir yol belitmemiz gerekiyor.(appsetings.json API projesinde old. için)
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceAPI.API/")); 
            configurationManager.AddJsonFile("appsettings.json");
            
            return configurationManager.GetConnectionString("ETicaretAPIDb");
        }
    }
}