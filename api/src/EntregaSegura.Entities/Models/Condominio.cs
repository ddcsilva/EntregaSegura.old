namespace EntregaSegura.Entities.Models;

/// <summary>
/// Classe que representa um condomínio
/// </summary>
public sealed class Condominio : Empresa
{
    public Condominio()
    {
        Unidades = new List<Unidade>();
        Funcionarios = new List<Funcionario>();
    }

    // Um condomínio possui um endereço
    public Endereco? Endereco { get; set; }

    // Um condomínio possui várias unidades
    public ICollection<Unidade> Unidades { get; set; }

    // Um condomínio possui vários funcionários
    public ICollection<Funcionario> Funcionarios { get; set; }
}