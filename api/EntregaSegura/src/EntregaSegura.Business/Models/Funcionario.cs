using EntregaSegura.Business.Models.Enums;

namespace EntregaSegura.Business.Models;

/// <summary>
/// Classe que representa um funcionário.
/// </summary>
public sealed class Funcionario : Usuario
{
    /// <summary>
    /// Construtor padrão 
    /// </summary>
    public Funcionario()
    {
        Cargo = CargoFuncionario.Porteiro;
        DataAdmissao = DateTime.Now;
    }

    public CargoFuncionario Cargo { get; set; }
    public DateTime DataAdmissao { get; set; }
    public DateTime? DataDemissao { get; set; }

    // Relacionamento 1:1 (Um funcionário pode receber várias entregas)
    public IEnumerable<Entrega> Entregas { get; set; }
}