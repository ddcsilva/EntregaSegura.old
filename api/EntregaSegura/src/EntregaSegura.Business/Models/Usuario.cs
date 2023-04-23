using EntregaSegura.Business.Models.Enums;

namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um usuário.
/// </summary>
public class Usuario : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Usuario()
    {
        Nome = string.Empty;
        CPF = string.Empty;
    }

    public string Nome { get; set; }
    public string CPF { get; set; }
    public StatusConta Status { get; set; }
}