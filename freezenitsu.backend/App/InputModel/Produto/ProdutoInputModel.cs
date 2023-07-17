using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InputModel.Produto
{
    public class ProdutoInputModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string CategoriaId { get; set; }

        public string NomeImagem { get; set; }

        public string Preco { get; set; }
    }
}
