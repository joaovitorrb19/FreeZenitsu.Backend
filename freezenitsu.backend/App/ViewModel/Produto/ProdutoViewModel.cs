using App.ViewModel.Categoria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ViewModel.Produto
{
    public class ProdutoViewModel
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public string NomeImagem { get; set; }

        public string  Preco { get; set; }

        public CategoriaViewModel Categoria { get; set; }

        public int CategoriaId { get; set; }
    }
}
