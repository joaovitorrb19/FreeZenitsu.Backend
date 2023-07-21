using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistencia
{
    public class ArquivoRepository : IArquivoRepository
    {
        private readonly AppDataContext _context;
        public ArquivoRepository(AppDataContext context)
        {
            _context = context;
        }
        public Arquivo Create(Arquivo arquivo)
        {
            _context.Arquivo.Add(arquivo);
            return arquivo;
        }

        public void Delete(Arquivo arquivo)
        {
            _context.Arquivo.Remove(arquivo);
            _context.SaveChanges();
        }

        public List<Arquivo> Get()
        {
            return _context.Arquivo.AsNoTracking().ToList();
        }

        public Arquivo GetById(int id)
        {
            var arquivo = _context.Arquivo.AsNoTracking().FirstOrDefault(a => a.Id == id);
            return arquivo;
        }

        public Arquivo GetByName(string name)
        {
            var arquivo = _context.Arquivo.AsNoTracking().FirstOrDefault(x =>x.Nome == name);
            return arquivo;
        }

        public void Put(Arquivo arquivo)
        {
            _context.Entry(arquivo).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
