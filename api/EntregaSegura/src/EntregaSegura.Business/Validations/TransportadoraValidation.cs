using EntregaSegura.Business.Models;
using EntregaSegura.Business.Utils;
using FluentValidation;

namespace EntregaSegura.Business.Validations;

/// <summary>
/// Classe de validação de transportadoras
/// </summary>
public class TransportadoraValidation : AbstractValidator<Transportadora>
{
    /// <summary>
    /// Valida uma transportadora
    /// </summary>
    public TransportadoraValidation()
    {
        RuleFor(c => c.Nome)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.CNPJ)
            .Must(DocumentoValidation.ValidarCnpj).WithMessage("O CNPJ fornecido é inválido");

        RuleFor(c => c.Telefone)
            .Must(TelefoneValidation.ValidarTelefone).WithMessage("O telefone fornecido é inválido")
            .When(c => c.Telefone != null);

        RuleFor(c => c.Email)
            .Must(EmailValidation.ValidarEmail).WithMessage("O e-mail fornecido é inválido")
            .When(c => c.Email != null);
    }
}