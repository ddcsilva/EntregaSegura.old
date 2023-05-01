using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class UnidadeService : IUnidadeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public UnidadeService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}