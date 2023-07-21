using App.InputModel.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ControllerServices.Interfaces
{
    public interface IUsuarioService
    {
        public Task Cadastrar(UsuarioCadastroInputModel usuario);
    }
}
