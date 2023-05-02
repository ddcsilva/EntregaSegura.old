using EntregaSegura.Entities.Models;

namespace EntregaSegura.Service.Contracts;

public interface IFuncionarioService
{
    IEnumerable<Funcionario> ObterTodosFuncionarios(bool rastrearAlteracoes);
}