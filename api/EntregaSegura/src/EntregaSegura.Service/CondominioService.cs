using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
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

    public IEnumerable<Condominio> ObterTodosCondominios(bool rastrearAlteracoes)
    {
        try
        {
            var condominios = _repository.Condominio.ObterTodosCondominios(rastrearAlteracoes);
            return condominios;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todos os condomínios: {ex.Message}");
            throw;
        }
    }
}