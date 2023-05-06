namespace EntregaSegura.Contracts;

public interface IRepositoryManager
{
    ICondominioRepository Condominio { get; }
    IEnderecoRepository Endereco { get; }
    IEntregaRepository Entrega { get; }
    IFuncionarioRepository Funcionario { get; }
    IMoradorRepository Morador { get; }
    ITransportadoraRepository Transportadora { get; }
    IUnidadeRepository Unidade { get; }
    void Salvar();
}