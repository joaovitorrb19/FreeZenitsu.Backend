using Core.Entidades;
using Core.Interfaces.Repositorios;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Persistencia
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly AppDataContext _context;
        public ProdutoRepository(AppDataContext context)
        {
            _context = context;
        }

        public Produto Create(Produto produto)
        {
            _context.Add(produto);
            _context.SaveChanges();
            return produto;
        }

        public void Delete(Produto produto)
        {
            _context.Remove(produto);
            _context.SaveChanges();
        }

        public List<Produto> Get()
        {
            return _context.Produto.Include(x => x.Categoria).ToList();
        }

        public Produto GetById(int id)
        {
            var produto = _context.Produto.FirstOrDefault(x => x.Id == id);
            return produto;
        }

        public Produto GetProdutoByArquivoId(int id){
            return _context.Produto.FirstOrDefault(x => x.ArquivoId == id);
            }

        public Produto GetByName(string name)
        {
            var produto = _context.Produto.FirstOrDefault(x => x.Nome == name);
            return produto;
        }

        public void Put(Produto produto)
        {
            _context.Produto.Entry(produto).State = EntityState.Modified;
            _context.SaveChanges() ;
        }
    }
}
