﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entidades
{
    public class Arquivo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Caminho { get; set; }

        public double Tamanho { get; set; }

        public string Tipo { get; set; }
    }
}
