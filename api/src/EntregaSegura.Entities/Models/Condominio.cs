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

    public string? Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? CEP { get; set; }
    public string? Bairro { get; set; }
    public string? Cidade { get; set; }
    public string? Estado { get; set; }

    // Um condomínio possui várias unidades
    public ICollection<Unidade> Unidades { get; set; }

    // Um condomínio possui vários funcionários
    public ICollection<Funcionario> Funcionarios { get; set; }
}