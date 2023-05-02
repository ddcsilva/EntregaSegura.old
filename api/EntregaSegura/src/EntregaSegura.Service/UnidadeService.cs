using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
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

    public IEnumerable<Unidade> ObterTodasUnidades(bool rastrearAlteracoes)
    {
        try
        {
            var unidades = _repository.Unidade.ObterTodasUnidades(rastrearAlteracoes);
            return unidades;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas as unidades: {ex.Message}");
            throw;
        }
    }
}