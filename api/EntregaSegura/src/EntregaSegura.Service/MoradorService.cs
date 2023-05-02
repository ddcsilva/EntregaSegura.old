using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
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

    public IEnumerable<Morador> ObterTodosMoradores(bool rastrearAlteracoes)
    {
        try
        {
            var moradores = _repository.Morador.ObterTodosMoradores(rastrearAlteracoes);
            return moradores;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas os moradores: {ex.Message}");
            throw;
        }
    }
}