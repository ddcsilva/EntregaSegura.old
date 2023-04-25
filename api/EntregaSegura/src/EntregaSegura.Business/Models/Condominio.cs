namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um condomínio
/// </summary>
public sealed class Condominio : Empresa
{
    /// <summary>
    /// Construtor padrão que inicializa a propriedade Unidades.
    /// </summary>
    public Condominio()
    {
        Unidades = new List<Unidade>();
    }

     // Um condomínio possui um endereço
    public Endereco Endereco { get; set; }

    // Um condomínio possui várias unidades
    public ICollection<Unidade> Unidades { get; set; }
}