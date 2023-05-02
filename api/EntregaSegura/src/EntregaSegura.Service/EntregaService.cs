using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class EntregaService : IEntregaService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public EntregaService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Entrega> ObterTodasEntregas(bool rastrearAlteracoes)
    {
        try
        {
            var entregas = _repository.Entrega.ObterTodasEntregas(rastrearAlteracoes);
            return entregas;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as entregas: {ex.Message}");
            throw;
        }
    }
}