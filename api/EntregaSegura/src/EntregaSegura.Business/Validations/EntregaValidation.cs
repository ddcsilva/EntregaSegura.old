using EntregaSegura.Business.Models;
using FluentValidation;

namespace EntregaSegura.Business.Validations;

/// <summary>
/// Classe de validação de entregas
/// </summary>
public class EntregaValidation : AbstractValidator<Entrega>
{
    /// <summary>
    /// Valida uma entrega
    /// </summary>
    public EntregaValidation()
    {
        RuleFor(c => c.Remetente)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Destinatario)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.DataRecebimento)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .GreaterThan(DateTime.Now).WithMessage("O campo {PropertyName} precisa ser maior que a data atual");

        RuleFor(c => c.DataRetirada)
            .GreaterThan(DateTime.Now).WithMessage("O campo {PropertyName} precisa ser maior que a data atual")
            .When(c => c.DataRetirada.HasValue);

        RuleFor(c => c.Descricao)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
            .When(c => c.Descricao != null);

        RuleFor(c => c.Observacao)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres")
            .When(c => c.Observacao != null);

        RuleFor(c => c.Status)
            .IsInEnum().WithMessage("O campo {PropertyName} precisa ser fornecido");
    }
}