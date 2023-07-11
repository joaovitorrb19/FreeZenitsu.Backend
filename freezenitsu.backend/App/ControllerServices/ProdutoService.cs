using App.AppServices.Interfaces;
using App.InputModel.Produto;
using App.Services.Interfaces;
using App.ViewModel.Produto;
using AutoMapper;
using Core.Entidades;
using Core.Exceptions;
using Core.Interfaces.Repositorios;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IArquivoService _arquivoService;
        private readonly IMapper _mapper;
        public ProdutoService(IProdutoRepository produtoRepository, IArquivoService arquivoService, IMapper mapper)
        {
            _produtoRepository = produtoRepository;
            this._arquivoService = arquivoService;
            _mapper = mapper;
        }

        public void Create(string Nome, string Preco, string CategoriaId, IFormFile Imagem)
        {

            var ArquivoCriado = this._arquivoService.ConverterFileParaArquivo(Imagem);

            var Produto = new Produto {Nome = Nome,URLImagem = ArquivoCriado.Caminho,ArquivoId = ArquivoCriado.Id,Preco = double.Parse(Preco),CategoriaId = int.Parse(CategoriaId)};

            if (_produtoRepository.GetByName(Produto.Nome) != null)
                throw new EntidadeJaCadastradaException("Produto já cadastrado..."); 

            var ProdutoCriado = _produtoRepository.Create(Produto);

            using (var FileStream = new FileStream(ArquivoCriado.Caminho, FileMode.Create))
            {
                Imagem.CopyTo(FileStream);
            }

        }

        public void Delete(ProdutoInputModel produto)
        {
            var produtoMapeado = this._mapper.Map<Produto>(produto);

            if(_produtoRepository.GetById(produtoMapeado.Id) == null)
                throw new EntidadeNaoExisteException("Produto não existente");

            _produtoRepository.Delete(produtoMapeado);

        }

        public List<ProdutoViewModel> Get()
        {
             
            var produtosNaoMapeados = this._produtoRepository.Get();

            var produtosMapeados = _mapper.Map<List<ProdutoViewModel>>(produtosNaoMapeados);

            return produtosMapeados;
        }

        public ProdutoViewModel Get(int id)
        {
            var produto = this._produtoRepository.GetById(id);

            if (produto == null)
                throw new EntidadeNaoExisteException("Produto não existente");

            var produtoMapeado = this._mapper.Map<ProdutoViewModel>(produto);
            return produtoMapeado;
        }

        public ProdutoViewModel Get(string nome)
        {
            var produto = _produtoRepository.GetByName(nome);

            if (produto == null)
                throw new EntidadeNaoExisteException("Produto não existente");

            var produtoMapeado = this._mapper.Map<ProdutoViewModel>(produto);
            return produtoMapeado;
        }

        public void Put(ProdutoInputModel produto)
        {
            var produtoMapeado = this._mapper.Map<Produto>(produto);

            if (_produtoRepository.GetById(produtoMapeado.Id) == null)
                throw new EntidadeNaoExisteException("Produto não existente");

            _produtoRepository.Put(produtoMapeado);
        }

    }
}
