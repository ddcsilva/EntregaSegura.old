using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Funcionarios no banco de dados.
/// </summary>
public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> ObterFuncionarios(bool rastrearAlteracoes);
    Funcionario ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes);
}