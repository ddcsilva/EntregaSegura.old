using AutoMapper;
using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<CondominioService> _condominioService;
    private readonly Lazy<EntregaService> _entregaService;
    private readonly Lazy<FuncionarioService> _funcionarioService;
    private readonly Lazy<MoradorService> _moradorService;
    private readonly Lazy<TransportadoraService> _transportadoraService;
    private readonly Lazy<UnidadeService> _unidadeService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _condominioService = new Lazy<CondominioService>(() => new CondominioService(repository, logger, mapper));
        _entregaService = new Lazy<EntregaService>(() => new EntregaService(repository, logger, mapper));
        _funcionarioService = new Lazy<FuncionarioService>(() => new FuncionarioService(repository, logger, mapper));
        _moradorService = new Lazy<MoradorService>(() => new MoradorService(repository, logger, mapper));
        _transportadoraService = new Lazy<TransportadoraService>(() => new TransportadoraService(repository, logger, mapper));
        _unidadeService = new Lazy<UnidadeService>(() => new UnidadeService(repository, logger, mapper));
    }

    public ICondominioService CondominioService => _condominioService.Value;
    public IEntregaService EntregaService => _entregaService.Value;
    public IFuncionarioService FuncionarioService => _funcionarioService.Value;
    public IMoradorService MoradorService => _moradorService.Value;
    public ITransportadoraService TransportadoraService => _transportadoraService.Value;
    public IUnidadeService UnidadeService => _unidadeService.Value;
}