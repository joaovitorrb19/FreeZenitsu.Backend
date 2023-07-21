using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Persistencia
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly AppDataContext _context;
        public CategoriaRepository(AppDataContext context)
        {
            _context = context;
        }
        public Categoria Create(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            _context.SaveChanges();
            return categoria;
        }

        public void Delete(Categoria categoria)
        {
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
        }

        public List<Categoria> Get()
        {
            return _context.Categoria.AsNoTracking().ToList();
        }

        public Categoria GetById(int id)
        {
            return _context.Categoria.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public Categoria GetByName(string name)
        {
            return _context.Categoria.AsNoTracking().FirstOrDefault(x => x.Nome == name);
        }

        public void Put(Categoria categoria)
        {
            _context.Entry(categoria).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }


}
