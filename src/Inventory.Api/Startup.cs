using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Inventory.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {

            return null;
            

          

          
        }



    }
}
