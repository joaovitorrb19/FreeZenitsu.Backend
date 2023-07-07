using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositorios
{
    public interface ICategoriaRepository
    {
        public List<Categoria> Get();
        public Categoria GetById(int id);
        public Categoria GetByName(string name);
        public void Delete(Categoria categoria);
        public void Put(Categoria categoria);
        public Categoria Create(Categoria categoria);
    }

}
