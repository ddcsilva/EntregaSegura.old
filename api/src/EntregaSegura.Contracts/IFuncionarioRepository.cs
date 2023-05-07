using EntregaSegura.Entities.Models;

namespace EntregaSegura.Contracts;

/// <summary>
/// Interface que define os métodos necessários para interagir com a tabela de Funcionarios no banco de dados.
/// </summary>
public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> ObterFuncionarios(Guid condominioId, bool rastrearAlteracoes);
    Funcionario ObterFuncionario(Guid condominioId, Guid funcionarioId, bool rastrearAlteracoes);
    void CriarFuncionarioParaCondominio(Guid condominioId, Funcionario funcionario);
}