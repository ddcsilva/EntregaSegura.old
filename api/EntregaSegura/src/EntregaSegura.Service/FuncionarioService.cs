using EntregaSegura.Contracts;
using EntregaSegura.Entities.Models;
using EntregaSegura.Service.Contracts;

namespace EntregaSegura.Service;

public sealed class FuncionarioService : IFuncionarioService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public FuncionarioService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Funcionario> ObterTodosFuncionarios(bool rastrearAlteracoes)
    {
        try
        {
            var funcionarios = _repository.Funcionario.ObterTodosFuncionarios(rastrearAlteracoes);
            return funcionarios;
        }
        catch (Exception ex)
        {
            _logger.LogErro($"Ocorreu um erro ao tentar obter todas os funcionários: {ex.Message}");
            throw;
        }
    }
}