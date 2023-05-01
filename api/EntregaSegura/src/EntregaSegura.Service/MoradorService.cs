using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class MoradorService : IMoradorService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public MoradorService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}