﻿using App.AppServices;
using App.AppServices.Interfaces;
using App.ControllerServices;
using App.ControllerServices.Interfaces;
using App.Services;
using App.Services.Interfaces;

namespace API.Configs.Service
{
    public static class ServiceConfig 
    {
       public static void AddServices(this IServiceCollection service)
        {
            
            service.AddScoped<ICategoriaService,CategoriaService>();
            service.AddScoped<IProdutoService,ProdutoService>();
            service.AddScoped<IArquivoService,ArquivoService>();
            service.AddScoped<IUsuarioService,UsuarioService>();
            service.AddScoped<ICodigoNotificacaoService,CodigoNotificacaoService>();

        }
    }
}
