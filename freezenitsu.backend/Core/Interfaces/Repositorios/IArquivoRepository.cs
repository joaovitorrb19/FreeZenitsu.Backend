using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositorios
{
    public interface IArquivoRepository
    {
        public List<Arquivo> Get();
        public Arquivo GetById(int id);
        public Arquivo GetByName(string name);
        public void Delete(Arquivo arquivo);
        public void Put(Arquivo arquivo);
        public Arquivo Create(Arquivo arquivo);
    }
}
