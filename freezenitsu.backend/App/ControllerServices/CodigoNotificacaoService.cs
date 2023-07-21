using App.ControllerServices.Interfaces;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace App.ControllerServices
{
    public class CodigoNotificacaoService : ICodigoNotificacaoService
    {
        private readonly ICodigoNotificacaoRepository _repository;
        public CodigoNotificacaoService(ICodigoNotificacaoRepository repository)
        {
            _repository = repository;
        }

        public CodigoNotificacao Create(int usuarioId,string tipoNotificacao,string tipoNotificador)
        {
            var numeroAleatorio = new StringBuilder();

            var random = new Random();

           for(var i = 0; i < 6; i++)
            {
                numeroAleatorio =  numeroAleatorio.Append(random.Next(10));

            }

           var resultado = numeroAleatorio.ToString();

             var codigo = new CodigoNotificacao {Numero = resultado,TipoNotificacao = tipoNotificacao, TipoNotificador = tipoNotificador,
                UsuarioId = usuarioId,ValidoAte = DateTime.Now.AddMinutes(10)};

           _repository.Create(codigo);
        }

        public void Update(CodigoNotificacao codigo)
        {
            throw new NotImplementedException();
        }
    }
}
