using EntregaSegura.Business.Models;
using FluentValidation;

namespace EntregaSegura.Business.Validations;

/// <summary>
/// Classe que representa a validação do modelo de endereço
/// </summary>
public class EnderecoValidation : AbstractValidator<Endereco>
{
    /// <summary>
    /// Construtor padrão que define as regras de validação
    /// </summary>
    public EnderecoValidation()
    {
        RuleFor(c => c.Logradouro)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Numero)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(1, 10).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.CEP)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(8).WithMessage("O campo {PropertyName} deve ter {MaxLength} caracteres");

        RuleFor(c => c.Bairro)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(2, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Cidade)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(2, 50).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");

        RuleFor(c => c.Estado)
            .NotEmpty().WithMessage("O campo {PropertyName} deve ser fornecido")
            .Length(2, 100).WithMessage("O campo {PropertyName} deve ter entre {MinLength} e {MaxLength} caracteres");
    }
}