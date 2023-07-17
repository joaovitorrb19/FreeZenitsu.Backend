using App.AppServices.Interfaces;
using Core.Entidades;
using Core.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppServices
{
    
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _repository;
        private string Caminho = "C:\\Users\\joaov\\OneDrive\\Área de Trabalho\\Projetos\\FreeZenitsu\\front\\src\\assets\\arquivos";
        public ArquivoService(IArquivoRepository repository)
        {
            _repository = repository;
        }

        public Arquivo ConverterFileParaArquivo(IFormFile file)
        {

            var arquivoPopulado = PopularArquivo(file);

            var arquivoCriado =  _repository.Create(arquivoPopulado);

            return arquivoCriado;
        }

        public IFormFile ConverterArquivoParaFile(Arquivo arquivo)
        {
            throw new NotImplementedException();
        }

        public Arquivo PopularArquivo(IFormFile file)
        {
            var arquivo = new Arquivo();

            arquivo.Nome = file.FileName;
            arquivo.Tamanho = file.Length;
            arquivo.Tipo = file.ContentType;

            arquivo.Nome = arquivo.Nome.Insert(arquivo.Nome.LastIndexOf('.'), $"{DateTime.Now}").Replace('/', '-').Replace(':', '-');

            arquivo.Caminho = Path.Combine(Caminho, arquivo.Nome);

            return arquivo;
        }

        public Arquivo AtualizarArquivo(int id,IFormFile file)
        {
            var arquivo = _repository.GetById(id);

            arquivo.Nome = file.FileName;
            arquivo.Tamanho = file.Length;
            arquivo.Tipo = file.ContentType;
            arquivo.Nome = arquivo.Nome.Insert(arquivo.Nome.LastIndexOf('.'), $"{DateTime.Now}").Replace('/', '-').Replace(':', '-');

            arquivo.Caminho = Path.Combine(Caminho, arquivo.Nome);

            _repository.Put(arquivo);


            return arquivo;
        }

        
    }
}
