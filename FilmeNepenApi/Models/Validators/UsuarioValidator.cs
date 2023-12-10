using FluentValidation;

namespace FilmeNepenApi.Models.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(user =>  user.Nome)
                .NotEmpty()
                .WithMessage("O Nome do usuário não pode ficar vazio")
                .MinimumLength(3)
                .WithMessage("O Nome do usuário precisa ter mais de 3 caracteres");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("A Senha não pode ficar vazia");
            
            RuleFor(user => user.Username)
                .NotEmpty()
                .WithMessage("O Username não pode ficar vazia");


        }
    }
}
