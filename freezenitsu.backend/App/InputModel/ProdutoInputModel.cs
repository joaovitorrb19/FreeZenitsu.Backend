using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InputModel
{
    public class ProdutoInputModel
    {
        public string Nome { get; set; }

        public int CategoriaId { get; set; }

        public IFormFile Imagem { get; set; }
    }
}
