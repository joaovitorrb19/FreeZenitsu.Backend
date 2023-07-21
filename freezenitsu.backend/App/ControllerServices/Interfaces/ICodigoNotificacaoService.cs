using Core.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ControllerServices.Interfaces
{
    public interface ICodigoNotificacaoService
    {
        public CodigoNotificacao Create(int usuarioId);

        public void Update(CodigoNotificacao codigo);
    }
}
