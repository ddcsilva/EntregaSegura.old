using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> ObterTodosFuncionarios(bool rastrearAlteracoes);
    Funcionario? ObterFuncionarioPorId(Guid funcionarioId, bool rastrearAlteracoes);
}