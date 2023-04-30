namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa uma empresa.
/// </summary>
public abstract class Empresa : BaseEntity
{    
    public string? Nome { get; set; }
    public string? CNPJ { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
}