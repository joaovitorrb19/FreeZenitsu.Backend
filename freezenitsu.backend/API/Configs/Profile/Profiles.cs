using App.Profiles;
using App.Validators;

namespace API.Configs.Profile
{
    public static class Profiles
    {
        public static void AddProfiles(this IServiceCollection service)
        {
            service.AddAutoMapper(typeof(CategoriaProfile));
        }
    }
}
