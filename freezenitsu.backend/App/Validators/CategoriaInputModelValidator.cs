using App.InputModel.Categoria;
using FluentValidation;


namespace App.Validators
{
    public class CategoriaInputModelValidator : AbstractValidator<CategoriaInputModel>
    {
        public CategoriaInputModelValidator()
        {
            RuleFor(x => x.Nome).NotEmpty().NotNull();
        }
    }
}
