﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Produto
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public int CategoriaId { get; set; }

        public Categoria Categoria { get; set; }

        public byte[] Imagem { get; set; }

    }
}
