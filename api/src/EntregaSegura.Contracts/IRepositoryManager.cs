namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define propriedades para acessar repositórios específicos e um método para salvar as alterações no banco de dados.
/// </summary>
public interface IRepositoryManager
{
    ICondominioRepository Condominio { get; }
    IEntregaRepository Entrega { get; }
    IFuncionarioRepository Funcionario { get; }
    IMoradorRepository Morador { get; }
    ITransportadoraRepository Transportadora { get; }
    IUnidadeRepository Unidade { get; }
    void Salvar();
}