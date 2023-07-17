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

            var Produto = new Produto {Nome = Nome, NomeImagem = ArquivoCriado.Nome,ArquivoId = ArquivoCriado.Id,Preco = double.Parse(Preco),CategoriaId = int.Parse(CategoriaId)};

            if (_produtoRepository.GetByName(Produto.Nome) != null)
                throw new EntidadeJaCadastradaException("Produto já cadastrado..."); 

            var ProdutoCriado = _produtoRepository.Create(Produto);

            using (var FileStream = new FileStream(ArquivoCriado.Caminho, FileMode.Create))
            {
                Imagem.CopyTo(FileStream);
            }

        }

        public void Delete(string produtoId)
        {
            

            if(_produtoRepository.GetById(int.Parse(produtoId)) == null)
                throw new EntidadeNaoExisteException("Produto não existente");

            var produto = _produtoRepository.GetById(int.Parse(produtoId));

            _produtoRepository.Delete(produto);

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

        public void Put(int id,string Nome, string Preco, string CategoriaId)
        {

            var produtoMapeado = this._produtoRepository.GetById(id);
            if(Nome != null)
                produtoMapeado.Nome = Nome;

            if (Preco != null)
                produtoMapeado.Preco = double.Parse(Preco);

            if (CategoriaId != null)
                produtoMapeado.CategoriaId = int.Parse(CategoriaId);

            if (produtoMapeado == null)
                throw new EntidadeNaoExisteException("Produto não existente");
            

            _produtoRepository.Put(produtoMapeado);
        }

        public void PutImg(int id, IFormFile Imagem)
        {

            var arquivoAtualizado = _arquivoService.AtualizarArquivo(id,Imagem);
                 if (arquivoAtualizado == null)
                     throw new EntidadeNaoExisteException("Arquivo não cadastrado...");

            var produtoCadastrado= _produtoRepository.GetProdutoByArquivoId(id);
                if(produtoCadastrado == null)
                        throw new EntidadeNaoExisteException("Produto não cadastrado...");

            produtoCadastrado.NomeImagem = arquivoAtualizado.Nome;
            _produtoRepository.Put(produtoCadastrado);

            using (var fileStream = new FileStream(arquivoAtualizado.Caminho, FileMode.Create))
            {
                Imagem.CopyTo(fileStream);
            }

        }

    }
}
