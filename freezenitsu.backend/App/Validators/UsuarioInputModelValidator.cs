using App.InputModel.Usuario;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Validators
{
    public class UsuarioInputModelValidator : AbstractValidator<UsuarioCadastroInputModel>
    {
        public UsuarioInputModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty().NotNull().EmailAddress();
            RuleFor(x => x.NomeCompleto).NotEmpty().NotNull();
            RuleFor(x => x.CPF).NotEmpty().NotNull();
            RuleFor(x => x.Senha).NotEmpty().NotNull();
            RuleFor(x => x.Telefone).NotEmpty().NotNull();
            RuleFor(x => x.ConfirmacaoSenha).NotEmpty().NotNull().Equal(x => x.Senha);
            RuleFor(x => x.DataNascimento).NotEmpty().NotNull();
        }
    }
}
