using App.Validators;

namespace API.Configs.Validator
{
    public static class ValidatorConfig
    {
        public static void AddValidators(this IServiceCollection service)
        {
            service.AddScoped<CategoriaInputModelValidator>();
        }
    }
}
