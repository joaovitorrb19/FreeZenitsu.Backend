using Core.Interfaces.Repositorios;
using Infra.Data.Persistencia;

namespace API.Configs.Repository
{
    public static class RepositoryConfig
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();
            service.AddScoped<IArquivoRepository, ArquivoRepository>();
        }
    }
}
