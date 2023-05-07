namespace EntregaSegura.Service.Contracts;

public interface IServiceManager
{
    ICondominioService CondominioService { get; }
    IEntregaService EntregaService { get; }
    IFuncionarioService FuncionarioService { get; }
    IMoradorService MoradorService { get; }
    ITransportadoraService TransportadoraService { get; }
    IUnidadeService UnidadeService { get; }
}