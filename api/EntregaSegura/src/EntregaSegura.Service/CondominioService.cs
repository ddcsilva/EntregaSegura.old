using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class CondominioService : ICondominioService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public CondominioService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}