using EntregaSegura.Contracts;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class EnderecoService : IEnderecoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public EnderecoService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }
}