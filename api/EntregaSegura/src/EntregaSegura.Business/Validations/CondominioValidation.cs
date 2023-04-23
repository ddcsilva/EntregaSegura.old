using EntregaSegura.Business.Models;
using EntregaSegura.Business.Utils.Validations;
using FluentValidation;

namespace EntregaSegura.Business.Validations;

/// <summary>
/// Classe de validação de condomínios
/// </summary>
public class CondominioValidation : AbstractValidator<Condominio>
{
    /// <summary>
    /// Valida um condomínio
    /// </summary>
    public CondominioValidation()
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