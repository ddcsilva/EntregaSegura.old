using System.ComponentModel.DataAnnotations;

namespace EntregaSegura.API.DTOs;

/// <summary>
/// Classe DTO que representa um condomínio.
/// </summary>
public class CondominioDTO
{
    [Key]
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 14)]
    public string CNPJ { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
    public string Telefone { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
    public string Email { get; set; }

    // public IEnumerable<UnidadeDTO> Unidades { get; set; }

    public EnderecoDTO Endereco { get; set; }
}