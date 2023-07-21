using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositorios
{
    public interface ICodigoNotificacaoRepository
    {
        public void Put(CodigoNotificacao codigo);
        public CodigoNotificacao Create(CodigoNotificacao codigo);
    }
}
