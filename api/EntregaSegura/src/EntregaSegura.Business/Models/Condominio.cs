namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um condomínio.
/// </summary>
public sealed class Condominio : Empresa
{
    /// <summary>
    /// Construtor padrão.
    /// </summary>
    public Condominio()
    {

    }

    // Relacionamento 1:1 (Um condomínio possui um endereço)
    public Endereco Endereco { get; set; }

    // Relacionamento 1:N (Um condomínio possui várias unidades)
    public IEnumerable<Unidade> Unidades { get; set; }
}