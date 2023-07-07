using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace API.Configs.Context
{
    public static class ContextConfig
    {
        public static void AddContext(this IServiceCollection service)
        {
            service.AddDbContext<AppDataContext>(opt => opt.UseInMemoryDatabase("Teste"));
        }
    }
}
