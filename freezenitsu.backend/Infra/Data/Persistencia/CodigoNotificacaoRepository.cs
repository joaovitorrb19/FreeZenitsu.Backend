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
    public class CodigoNotificacaoRepository : ICodigoNotificacaoRepository
    {
        private readonly AppDataContext _context;
        public CodigoNotificacaoRepository(AppDataContext context)
        {
            _context = context;
        }
        public CodigoNotificacao Create(CodigoNotificacao codigo)
        {
            var codigoCriado = _context.CodigoNotificacao.Add(codigo);
            _context.SaveChanges();
            return codigo;
        }

        public void Put(CodigoNotificacao codigo)
        {
            _context.Entry(codigo).State = EntityState.Modified;
            _context.SaveChanges();
        }

    }
}
