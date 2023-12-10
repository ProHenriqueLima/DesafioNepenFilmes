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
                .WithMessage("O Ano de Lançamento não pode ser vazio!")
                .LessThan(2024)
                .WithMessage("O Ano de Lançamento não pode ser após o ano atual")
                .GreaterThan(1895)
                .WithMessage("Não existe filme antes de 1895");
        }
    }
}
