using App.InputModel.Categoria;
using App.InputModel.Produto;
using App.ViewModel.Categoria;
using App.ViewModel.Produto;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Interfaces
{
    public interface IProdutoService
    {
        public void Create(string Nome, string Preco,  string CategoriaId, IFormFile Imagem);
        public List<ProdutoViewModel> Get();
        public ProdutoViewModel Get(int id);
        public ProdutoViewModel Get(string nome);
        public void Delete(ProdutoInputModel categoria);
        public void Put(ProdutoInputModel categoria);
    }
}
