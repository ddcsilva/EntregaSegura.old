using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class TransportadoraService : ITransportadoraService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public TransportadoraService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Transportadora> ObterTodasTransportadoras(bool rastrearAlteracoes)
    {
        try
        {
            var transportadoras = _repository.Transportadora.ObterTodasTransportadoras(rastrearAlteracoes);
            return transportadoras;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as transportadoras: {ex.Message}");
            throw;
        }
    }
}