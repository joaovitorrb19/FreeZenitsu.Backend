using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositorios
{
    public interface IProdutoRepository
    {
        public List<Produto> Get();
        public Produto GetById(int id);
        public Produto GetByName(string name);
        public void Delete(Produto produto);
        public void Put(Produto produto);
        public Produto Create(Produto produto);
        public Produto GetProdutoByArquivoId(int id);
    }
}
