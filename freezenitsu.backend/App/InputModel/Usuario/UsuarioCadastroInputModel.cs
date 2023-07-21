using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.InputModel.Usuario
{
    public class UsuarioCadastroInputModel
    {
        public string Email { get; set; }

        public string NomeCompleto { get; set; }

        public string CPF { get; set; }

        public string Telefone { get; set; }

        public string DataNascimento { get; set; }

        public string Senha { get; set; }

        public string ConfirmacaoSenha { get; set; }
    }
}
