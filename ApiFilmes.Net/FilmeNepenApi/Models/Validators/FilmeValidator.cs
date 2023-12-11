using FluentValidation;
using static System.Net.WebRequestMethods;

namespace FilmeNepenApi.Models.Validators
{
    public class FilmeValidator : AbstractValidator<Filme>
    {
        public FilmeValidator()
        {
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O Nome do Filme não pode ser vazio!");
            
            RuleFor(p => p.Descricao)
                .NotEmpty()
                .WithMessage("A Descricao não pode ser vazio!");

            RuleFor(p => p.AnoLancamento)
                .NotEmpty()
                .WithMessage("O Ano de Lançamento não pode ser vazio!");
        }
    }
}
