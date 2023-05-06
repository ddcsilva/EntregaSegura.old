using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> ObterFuncionarios(bool rastrearAlteracoes);
    Funcionario? ObterFuncionario(Guid funcionarioId, bool rastrearAlteracoes);
}