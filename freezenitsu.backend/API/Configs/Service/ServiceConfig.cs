using App.Services;
using App.Services.Interfaces;

namespace API.Configs.Service
{
    public static class ServiceConfig 
    {
       public static void AddServices(this IServiceCollection service)
        {
            
            service.AddScoped<ICategoriaService,CategoriaService>();

        }
    }
}
