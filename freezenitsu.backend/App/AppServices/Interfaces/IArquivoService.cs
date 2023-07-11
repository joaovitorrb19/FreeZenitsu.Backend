using Core.Entidades;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.AppServices.Interfaces
{
    public interface IArquivoService
    {
        public Arquivo ConverterFileParaArquivo(IFormFile file);

        public IFormFile ConverterArquivoParaFile(Arquivo arquivo);
    }
}
