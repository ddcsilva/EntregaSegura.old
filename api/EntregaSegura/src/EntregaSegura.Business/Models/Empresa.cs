namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa uma empresa.
/// </summary>
public abstract class Empresa : BaseEntity
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    protected Empresa()
    {
        Nome = string.Empty;
        CNPJ = string.Empty;
        Telefone = string.Empty;
        Email = string.Empty;
    }
    
    public string Nome { get; set; }
    public string CNPJ { get; set; }
    public string Telefone { get; set; }
    public string Email { get; set; }
}