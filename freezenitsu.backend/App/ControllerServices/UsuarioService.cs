using App.ControllerServices.Interfaces;
using App.InputModel.Usuario;
using AutoMapper;
using Core.Entidades;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace App.ControllerServices
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UserManager<Usuario> _manager;
        private readonly IMapper _mapper;
        
        public UsuarioService(IMapper mapper, UserManager<Usuario> manager)
        {
            _mapper = mapper;
            _manager = manager;
        }
        public async Task Cadastrar(UsuarioCadastroInputModel usuario)
        {
            var usuarioMapeado = _mapper.Map<Usuario>(usuario);

            var resultado = await _manager.CreateAsync(usuarioMapeado,usuario.Senha);

            if (!resultado.Succeeded)
                return ;

            //Gerar codigoNotificaçao,
            


            await GerarConfirmacaoEmail(usuarioMapeado.Email);
        }

        public async Task GerarConfirmacaoEmail(string email)
        {
            var usuarioCadastrado = await _manager.FindByEmailAsync(email);

            var token =  _manager.GenerateNewAuthenticatorKey();

            var linkCadastro = $"http://localhost:4200/ativar?token={token}";
            
        }


    }
}
