using Core.Entidades;
using Infra.Data.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Configs.Context
{
    public static class ContextConfig
    {
        public static void AddContext(this IServiceCollection service)
        {
            service.AddIdentity<Usuario,IdentityRole>(x =>
            {
                
                x.User.RequireUniqueEmail = true;
                x.Password.RequiredUniqueChars = 3;
                x.Password.RequireNonAlphanumeric = true;
                x.Password.RequireDigit = true;
                x.Password.RequireUppercase = true;
                x.Password.RequireLowercase = true;
                x.Password.RequiredLength = 8;
            }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDataContext>();

            service.AddDbContext<AppDataContext>(opt => opt.UseSqlServer("server=localhost,1433;database=apiteste;user id=sa;password=@Aa9988554400"));
        }
    }
}
